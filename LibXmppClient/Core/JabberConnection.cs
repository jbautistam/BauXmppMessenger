using System;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibXmppClient.Users;
using Sharp.Xmpp;
using Sharp.Xmpp.Im;

namespace Bau.Libraries.LibXmppClient.Core
{
	/// <summary>
	///		Cliente de Jabber
	/// </summary>
	public class JabberConnection : IDisposable
	{ 
		internal JabberConnection(JabberManager objManager, Servers.JabberServer objHost, JabberUser objUser)
		{ Manager = objManager;
			Host = objHost;
			User = objUser;
		}

		/// <summary>
		///		Conecta al servidor
		/// </summary>
		public void Connect()
		{ // Desconecta
				Disconnect();
			// Conecta al servidor
				XmppClient = new Sharp.Xmpp.Client.XmppClient(Host.Address, User.Login, User.Password);
				XmppClient.Connect();
				// XmppClient.DebugStanzas = true;
			// Inicializa los eventos
				InitEventHandlers();
			// Carga el roster
				LoadRoster();
			// Cambia el estado a online
				SetStatus(JabberContactStatus.Availability.Online, "En línea");
		}

		/// <summary>
		///		Carga el roster
		/// </summary>
		private void LoadRoster()
		{ JabberGroup objGroupUndefined, objGroupSubscription;

				// Limpia los grupos y los contactos
					Groups.Clear();
					Contacts.Clear();
				// Crea el grupo de "indefinidos"
					objGroupUndefined =	Groups.Add(JabberGroup.GroupType.User, "<No agrupados>");
					objGroupSubscription = Groups.Add(JabberGroup.GroupType.Subscription, "<Pendientes suscripción>");
				// Añade los contactos al diccionario y los grupos
					foreach (RosterItem objRosterItem in XmppClient.GetRoster())
						{ JabberContact objContact = new JabberContact(objRosterItem.Jid.Domain, objRosterItem.Jid.Node, 
																													 objRosterItem.Jid.Resource, objRosterItem.Name);
							bool blnAdded = false;

								// Asigna el estado
									objContact.Subscription.Mode = GetSubscriptionMode(objRosterItem.SubscriptionState, objRosterItem.Pending);
								// Añade el contacto 
									Contacts.Add(objContact);
								// Añade el contacto a los grupos
									if (objContact.Subscription.Mode != JabberSubscriptionStatus.SubscriptionMode.Both)
										{ objGroupSubscription.Contacts.Add(objContact);
											blnAdded = true;
										}
									else
										foreach (string strGroupName in objRosterItem.Groups)
											{ JabberGroup objGroup = Groups.Add(JabberGroup.GroupType.User, strGroupName);

													// Añade el contacto
														objGroup.Contacts.Add(objContact);
													// Indica que se ha añadido al menos a un grupo
														blnAdded = true;
											}
								// Si no se ha añadido a ningún grupo, se añade al de "Indefinidos"
									if (!blnAdded)
										objGroupUndefined.Contacts.Add(objContact);
						}
				// Lanza el evento de modificación del roster
					Manager.RaiseEventRosterUpdated(new EventArguments.RosterUpdatedRequestArgs(this));
		}

		/// <summary>
		///		Obtiene el modo de suscripción de un contacto
		/// </summary>
		private JabberSubscriptionStatus.SubscriptionMode GetSubscriptionMode(SubscriptionState intState, bool blnIsPending)
		{ switch (intState)
				{	case SubscriptionState.Both:
						return JabberSubscriptionStatus.SubscriptionMode.Both;
					case SubscriptionState.To:
						return JabberSubscriptionStatus.SubscriptionMode.UserPendingResponseFromContact;
					case SubscriptionState.From:
						return JabberSubscriptionStatus.SubscriptionMode.ContactPendingResponseFromUser;
					default:
						return JabberSubscriptionStatus.SubscriptionMode.None;
				}
		}

		/// <summary>
		///		Inicializa los manejadores de eventos
		/// </summary>
		private void InitEventHandlers()
		{ // Asigna la función callback de suscripción
				XmppClient.SubscriptionRequest = OnSubscriptionRequestCallbak;
			// Inicializa los manejadores de eventos
				XmppClient.Message += (objSender, objEventArgs) =>
																			{ ReceiveMessage(objEventArgs.Jid, objEventArgs.Message);
																			};
				XmppClient.RosterUpdated += (objSender, objEventArgs) => LoadRoster();
				XmppClient.SubscriptionApproved += (objSender, objEventArgs) =>
																							{ ApproveSubscription(objEventArgs.Jid);
																							};
				XmppClient.SubscriptionRefused += (objSender, objEventArgs) =>
																							{ DeleteContact(GetContact(objEventArgs.Jid));
																							};
				XmppClient.StatusChanged += (objSender, objEventArgs) =>
																			{ ReceiveStatus(objEventArgs.Jid, objEventArgs.Status);
																			};
				XmppClient.Error += (objSender, objEventArgs) =>
																			{ Console.WriteLine(objEventArgs.Reason);
																			};
				XmppClient.Unsubscribed += (objSender, objEventArgs) =>
																					{ Console.WriteLine("Unsubscribed " + objEventArgs.Jid);
																					};
				XmppClient.ChatStateChanged += (objSender, objEventArgs) =>
																					{ Console.WriteLine("ChatStateChanged");
																					};
		}

		/// <summary>
		///		Callback para el tratamiento de solicitudes de recepción
		/// </summary>
		private bool OnSubscriptionRequestCallbak(Jid objJid)
		{ EventArguments.SubscriptionRequestEventArgs objArguments = new EventArguments.SubscriptionRequestEventArgs(this, $"{objJid.Node}@{objJid.Domain}");
			
				// Lanza el evento
					Manager.RaiseEventSubscriptionRequest(objArguments);
				// Si se ha aceptado, envía una solicitud
					switch (objArguments.Status)
						{	case EventArguments.SubscriptionRequestEventArgs.SubscriptionStatus.Accepted:
									ApproveSubscription(objJid);
								break;
							case EventArguments.SubscriptionRequestEventArgs.SubscriptionStatus.Refused:
									XmppClient.Im.RefuseSubscriptionRequest(objJid);
								break;
						}
				// Devuelve el valor que indica si se ha aceptado
					return objArguments.Status == EventArguments.SubscriptionRequestEventArgs.SubscriptionStatus.Accepted;
		}

		/// <summary>
		///		Aprueba una solicitud de suscripción
		/// </summary>
		private void ApproveSubscription(Jid objJid)
		{ // Indica que se ha aprobado la solicitud
				XmppClient.Im.ApproveSubscriptionRequest(objJid);
			// Añade el contacto
				XmppClient.AddContact(objJid);
		}

		/// <summary>
		///		Trata la recepción de un mensaje
		/// </summary>
		private void ReceiveMessage(Jid objJid, Message objMessage)
		{ JabberContact objContact = GetContact(objJid);

				if (objContact != null)
					Manager.RaiseEventMessageReceived(new EventArguments.MessageReceivedEventArgs(this, objContact,
																																												objMessage.Subject,
																																												objMessage.Body));
				else
					Console.WriteLine("Se ha recibido un mensaje de un desconocido: " + objJid.ToString() + objMessage.Body);
		}

		/// <summary>
		///		Recibe un cambio de estado
		/// </summary>
		private void ReceiveStatus(Jid objJid, Status objStatus)
		{ JabberContact objContact = GetContact(objJid);

				if (objContact != null)
					{ // Cambia el estado
							objContact.Status.Status = GetContactStatus(objStatus.Availability);
							objContact.Status.Message = objStatus.Message;
							objContact.Status.Priority = objStatus.Priority;
						// Lanza el evento de cambio de estado
							Manager.RaiseEventChangedStatus(new EventArguments.ChangedStatusEventArgs(this, objContact, objContact.Status));
					}
				else if (objJid.Domain.EqualsIgnoreCase(User.Host) && objJid.Node.EqualsIgnoreCase(User.Login))
					{ User.Status.Status = GetContactStatus(objStatus.Availability);
						Manager.RaiseEventUserStatusChanged(new EventArguments.ChangedUserStatusEventArgs(this, User));
					}
		}

		/// <summary>
		///		Obtiene la disponiblidad de un contacto
		/// </summary>
		private JabberContactStatus.Availability GetContactStatus(Availability intAvailability)
		{ switch (intAvailability)
				{	case Availability.Away:
						return JabberContactStatus.Availability.Away;
					case Availability.Chat:
						return JabberContactStatus.Availability.Chat;
					case Availability.Dnd:
						return JabberContactStatus.Availability.Dnd;
					case Availability.Online:
						return JabberContactStatus.Availability.Online;
					case Availability.Xa:
						return JabberContactStatus.Availability.Xa;
					default:
						return JabberContactStatus.Availability.Offline;
				}
		}

		/// <summary>
		///		Modifica el estado del usuario
		/// </summary>
		public void SetStatus(JabberContactStatus.Availability intStatus, string strMessage)
		{ // Cambia el estado del usuario
				User.Status.Status = intStatus;
				User.Status.Message = strMessage;
			// Evita los errores con el estado Offline
				if (intStatus == JabberContactStatus.Availability.Offline) 
					Disconnect();
				else
					XmppClient.Im.SetStatus(GetContactAvailability(intStatus), strMessage);
		}

		/// <summary>
		///		Obtiene la disponibilidad de un contacto a partir de su estado
		/// </summary>
		private Availability GetContactAvailability(JabberContactStatus.Availability intStatus)
		{ switch (intStatus)
				{	case JabberContactStatus.Availability.Away:
						return Availability.Away;
					case JabberContactStatus.Availability.Chat:
						return Availability.Chat;
					case JabberContactStatus.Availability.Dnd:
						return Availability.Dnd;
					case JabberContactStatus.Availability.Online:
						return Availability.Online;
					default:
						return Availability.Xa;
				}
		}

		/// <summary>
		///		Añade un contacto
		/// </summary>
		public void AddContact(string strJid, string strNickName)
		{ XmppClient.AddContact(new Jid(strJid), strNickName);
		}

		/// <summary>
		///		Añade una sala de chat
		/// </summary>
		public void AddChatRoom(string strJid, string strChatRoom)
		{ XmppClient.Im.RequestSubscription(new Jid(strJid));
			XmppClient.AddContact(new Jid(strJid), strChatRoom);
		}

		/// <summary>
		///		Elimina un contacto
		/// </summary>
		public void DeleteContact(JabberContact objContact)
		{ if (objContact != null)
				{ XmppClient.Im.RefuseSubscriptionRequest(new Jid(objContact.Jid));
					XmppClient.RemoveContact(new Jid(objContact.Jid));
				}
		}

		/// <summary>
		///		Obtiene un contacto del diccionario
		/// </summary>
		private JabberContact GetContact(Jid objJid)
		{ return Contacts.Search(objJid.Domain, objJid.Node);
		}

		/// <summary>
		///		Envía un mensaje de chat a un contacto
		/// </summary>
		public void SendMessage(JabberContact objContact, string strText)
		{ XmppClient.SendMessage(objContact.FullJid, strText, null, null, MessageType.Chat);
		}

		/// <summary>
		///		Desconecta del servidor
		/// </summary>
		public void Disconnect()
		{ if (XmppClient != null)
				XmppClient.Close();
		}

		/// <summary>
		///		Libera la memoria
		/// </summary>
		public void Dispose()
		{	Dispose(true);
		}

		/// <summary>
		///		Libera la memoria
		/// </summary>
		protected virtual void Dispose(bool blnDisposing)
		{	if (!IsDisposed)
				{	// Desconecta
						if (blnDisposing)
							Disconnect();
					// Indica que ya se ha liberado
						IsDisposed = true;
				}
		}

		/// <summary>
		///		Manager de Jabber
		/// </summary>
		private JabberManager Manager { get; }

		/// <summary>
		///		Servidor
		/// </summary>
		public Servers.JabberServer Host { get; }

		/// <summary>
		///		Cliente de la librería de acceso Xmpp
		/// </summary>
		private Sharp.Xmpp.Client.XmppClient XmppClient { get; set; } = null;

		/// <summary>
		///		Usuario conectado al servidor
		/// </summary>
		public JabberUser User { get; }

		/// <summary>
		///		Grupos de contactos
		/// </summary>
		public JabberGroupsCollection Groups { get; } = new JabberGroupsCollection();

		/// <summary>
		///		Contactos
		/// </summary>
		public JabberContactsDictionary Contacts { get; } = new JabberContactsDictionary();

		/// <summary>
		///		Indica si está conectado
		/// </summary>
		public bool IsConnected
		{ get
				{ if (XmppClient == null)
						return false;
					else
						return XmppClient.Connected;
				}
		}

		/// <summary>
		///		Indica si se ha liberado la memoria
		/// </summary>
		public bool IsDisposed { get; private set; }
	}
}
