using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibXmppClient.Core;
using Bau.Libraries.LibXmppClient.EventArguments;
using Bau.Libraries.LibXmppClient.Users;

namespace TestSharpXmpp
{
	/// <summary>
	///		Formulario principal de la aplicación
	/// </summary>
	public partial class frmMain : Form
	{	// Variables privadas
			private Bau.Libraries.LibXmppClient.JabberManager objXmppClient = new Bau.Libraries.LibXmppClient.JabberManager();

		public frmMain()
		{	InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ // Conecta
				Connect();
		}

		/// <summary>
		///		Conecta a Jabber
		/// </summary>
		private void Connect()
		{  // Crea el objeto cliente
				objXmppClient = new Bau.Libraries.LibXmppClient.JabberManager();
			// Añade los manejadores de eventos
				objXmppClient.MessageReceived += (objSender, objEventArgs) =>
																							{ BeginInvoke((Action) (() => ShowMessageReceived(objEventArgs)),
																														null);
																							};
				objXmppClient.ChangedStatus += (objSender, objEventArgs) =>
																							{ BeginInvoke((Action) (() => TreatChangedStatus(objEventArgs)),
																														null);
																							};
				objXmppClient.SubscriptionRequested += (objSender, objEventArgs) =>
																									{ if (this.InvokeRequired)
																											this.Invoke(new EventHandler(delegate
																																								{ TreatSubscriptionRequested(objEventArgs);
																																								})
																															);
																										else
																											TreatSubscriptionRequested(objEventArgs);
																									};
				objXmppClient.FormRequested += (objSender, objEventArgs) =>
																									{ if (this.InvokeRequired)
																											this.Invoke(new EventHandler(delegate
																																								{ TreatRequestForm(objEventArgs);
																																								})
																														);
																										else
																											TreatRequestForm(objEventArgs);
																									};
				objXmppClient.RosterUpdated += (objSender, objEventArgs) =>
																						{ BeginInvoke((Action) (() => LoadListContacts()),
																													null);
																						};
				objXmppClient.ChangedUserStatus += (objSender, objEventArgs) =>
																							{ BeginInvoke((Action) (() =>
																																						{ SetUserStatus(objEventArgs.Connection,
																																														objEventArgs.User.Status.Status,
																																														objEventArgs.User.Status.Message);
																																						}
																																			),
																														null);
																							};
			// Carga los datos de conexión
				try
					{ new UC.ConnectionsRepository().Load(objXmppClient, GetConfigurationFileName());
					}
				catch (Exception objException)
					{ System.Diagnostics.Debug.WriteLine("Error al cargar el archivo de conexión: " + objException.Message);
					}
			// Conecta los datos
				foreach (JabberConnection objConnection in objXmppClient.Connections)
					if (objConnection.User.Status.Status != JabberContactStatus.Availability.Offline)
						objConnection.Connect();
			// Muestra la lista de contactos
				LoadListContacts();
			// Graba la configuración
				SaveConfiguration();
		}

		/// <summary>
		///		Obtiene el nombre del archivo de configuración
		/// </summary>
		private string GetConfigurationFileName()
		{ return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XmppConnections.xml");
		}

		/// <summary>
		///		Log de datos de contacto
		/// </summary>
		private void LogContact(JabberContact objContact)
		{ LogMessage($"[{DateTime.Now}] {objContact.FullName}:");
		}

		/// <summary>
		///		Log de un mensaje
		/// </summary>
		private void LogMessage(string strMessage)
		{ if (!strMessage.IsEmpty())
				txtMessages.AppendText(strMessage + Environment.NewLine);
		}

		/// <summary>
		///		Fin de log
		/// </summary>
		private void LogEnd()
		{ LogMessage(new string('-', 50) + Environment.NewLine + Environment.NewLine);
		}

		/// <summary>
		///		Trata el evento de cambio de estado
		/// </summary>
		private void TreatChangedStatus(ChangedStatusEventArgs objEventArgs)
		{ // Log
				LogContact(objEventArgs.Contact);
				LogMessage($" --> Cambio de estado: {objEventArgs.NewStatus.Status} -- {objEventArgs.NewStatus.Message}");
				LogEnd();
			// Actualiza la lista de contactos
				LoadListContacts();
		}

		/// <summary>
		///		Trata el evento de recepción de solicitud de amistad
		/// </summary>
		private void TreatSubscriptionRequested(SubscriptionRequestEventArgs objEventArgs)
		{ if (Bau.Controls.Forms.Helper.ShowQuestion(this, "Ha recibido una petición de suscripción de '" + objEventArgs.Jid + "'. ¿Desea aceptarla?"))
				objEventArgs.Status = SubscriptionRequestEventArgs.SubscriptionStatus.Accepted;
			else
				objEventArgs.Status = SubscriptionRequestEventArgs.SubscriptionStatus.Refused;
		}

		/// <summary>
		///		Trata la solicitud de formulario
		/// </summary>
		private void TreatRequestForm(FormRequestedEventArgs objEventArgs)
		{ frmFormFiller frmNewFiller = new frmFormFiller();

				// Asigna las propiedades
					frmNewFiller.FormData = objEventArgs.Form;
				// Muestra el formulario
					frmNewFiller.ShowDialog();
				// Obtiene los datos
					if (frmNewFiller.DialogResult != DialogResult.OK)
						objEventArgs.Cancel = true;
		}

		/// <summary>
		///		Muestra la lista de contactos
		/// </summary>
		private void LoadListContacts()
		{	trvContacts.LoadContacts(objXmppClient);
		}

		/// <summary>
		///		Modifica el estado del usuario
		/// </summary>
		private void SetUserStatus(JabberConnection objConnection, JabberContactStatus.Availability intNewStatus, string strText)
		{ if (objConnection != null)
				try
					{ // Envía el nuevo estado
							if (objConnection.User.Status.Status != intNewStatus)
								{ // Si no está conectado, conecta 
										if (!objConnection.IsConnected)
											objConnection.Connect();
									// Envía el estado
										objConnection.SetStatus(intNewStatus, strText);
									// Actualiza el árbol de contactos
										LoadListContacts();
									// Muestra el mensaje
										LogContact(objConnection.User);
										LogMessage($">> Cambio de estado del usuario {objConnection.User.FullName} --> {intNewStatus} [{strText}]");
										LogEnd();
								}
					}
				catch (Exception objException)
					{ LogContact(objConnection.User);
						LogMessage($">> Error en la conexión {objException.Message}");
						LogEnd();
						Bau.Controls.Forms.Helper.ShowMessage(this, $"Error en la conexión {objException.Message}");
					}
		}

		/// <summary>
		///		Crea una conexión
		/// </summary>
		private void CreateConnection()
		{	frmConnection frmNewConnection = new frmConnection();

				// Muestra el formulario
					frmNewConnection.ShowDialog();
				// Añade la conexión a la colección
					if (frmNewConnection.DialogResult == DialogResult.OK)
						{ // Añade la conexión
								objXmppClient.AddConnection(frmNewConnection.Server, frmNewConnection.User);
							// Graba la configuración
								SaveConfiguration();
							// Recarga el árbol
								LoadListContacts();
						}
		}

		/// <summary>
		///		Crea un uusario
		/// </summary>
		private void CreateUser()
		{	string strServer = GetServer();

				if (!strServer.IsEmpty())
					{ Bau.Libraries.LibXmppClient.JabberManager objXmppRegisterClient = new Bau.Libraries.LibXmppClient.JabberManager();
						string strError;

							// Asigna el manejador de eventos
								objXmppRegisterClient.FormRequested += (objSender, objEventArgs) =>
																														{ if (this.InvokeRequired)
																																this.Invoke(new EventHandler(delegate
																																													{ TreatRequestForm(objEventArgs);
																																													})
																																			);
																															else
																																TreatRequestForm(objEventArgs);
																														};
							// Comienza el registro
								if (!objXmppRegisterClient.RegisterBegin(strServer, out strError))
									Bau.Controls.Forms.Helper.ShowMessage(this, strError);
								else
									Bau.Controls.Forms.Helper.ShowMessage(this, "Se ha creado el usuario correctamente");
					}
		}

		/// <summary>
		///		Prepara el formulario para enviar un mensaje de chat
		/// </summary>
		private UC.Chat PrepareChat(JabberConnection objConnection, JabberContact objContact)
		{ UC.Chat udtChat = null;

				// Añade u obtiene el control de chat adecuado
					if (objConnection != null && objContact != null)
						{ int intIndex = GetChatTabIndex(objConnection, objContact);

								if (intIndex >= 0)
									{ // Selecciona el tab de chat
											tabChat.SelectedIndex = intIndex;
										// Obtiene el control
											foreach (Control ctlControl in tabChat.TabPages[intIndex].Controls)
												if (ctlControl is UC.Chat)
													udtChat = ctlControl as UC.Chat;
									}
								else
									{ string strKey = GetChatKey(objConnection, objContact);

											// Crea un nuevo control de chat
												udtChat = new UC.Chat();
											// Inicaliza el control
												udtChat.InitControl(objConnection, objContact);
												udtChat.CloseRequest += (objSender, objEventArgs) =>
																											{ CloseChat(strKey);
																											};
											// Lo añade a la ficha
												tabChat.TabPages.Add(objContact.Login);
												tabChat.TabPages[tabChat.TabPages.Count - 1].Controls.Add(udtChat);
												tabChat.TabPages[tabChat.TabPages.Count - 1].Tag = strKey;
												tabChat.SelectedIndex = tabChat.TabPages.Count - 1;
											// y por último ocupa toda la ficha
												udtChat.Dock = DockStyle.Fill;
									}
						}
				// Devuelve el control
					return udtChat;
		}

		/// <summary>
		///		Cierra una vista de chat
		/// </summary>
		private void CloseChat(string strKey)
		{ int intIndex = GetChatTabIndex(strKey);

				if (intIndex > 0)
					tabChat.TabPages.RemoveAt(intIndex);
		}

		/// <summary>
		///		Muestra un mensaje recibido
		/// </summary>
		private void ShowMessageReceived(MessageReceivedEventArgs objEventArgs)
		{ UC.Chat udtChat;

				// Prepara una ventana de chat o selecciona la existente
					udtChat = PrepareChat(objEventArgs.Connection, objEventArgs.Contact);
				// Si se ha encontrado, añade el mensaje
					if (udtChat != null)
						udtChat.AddReceivedMessage(objEventArgs.Subject, objEventArgs.Body);
					else // ... si no, se escribe el mensaje en el log (no debería pasar nunca)
						{ LogContact(objEventArgs.Contact);
							LogMessage(objEventArgs.Subject);
							LogMessage(objEventArgs.Body);
							LogEnd();
						}
		}

		/// <summary>
		///		Obtiene la clave de una ficha de chat
		/// </summary>
		private string GetChatKey(JabberConnection objConnection, JabberContact objContact)
		{ return $"{objConnection.Host.Address}_{objContact.FullJid}";
		}

		/// <summary>
		///		Obtiene el índice de la ficha con el chat de un contacto
		/// </summary>
		private int GetChatTabIndex(JabberConnection objConnection, JabberContact objContact)
		{ return GetChatTabIndex(GetChatKey(objConnection, objContact));
		}

		/// <summary>
		///		Obtiene el índice de la ficha con un chat
		/// </summary>
		private int GetChatTabIndex(string strKey)
		{ // Recorre las fichas buscando el chat adecuado
				for (int intIndex = 0; intIndex < tabChat.TabPages.Count; intIndex++)
					if (tabChat.TabPages[intIndex].Tag != null &&
							(tabChat.TabPages[intIndex].Tag as string).EqualsIgnoreCase(strKey))
						return intIndex;
			// Si ha llegado hasta aquí es porqe no ha encontrado nada
				return -1;
		}

		/// <summary>
		///		Obtiene el servidor
		/// </summary>
		private string GetServer()
		{ frmServer frmNewServer = new frmServer();

				// Asigna el host
					frmNewServer.Server = "jabberes.org";
				// Muestra el formulario
					frmNewServer.ShowDialog();
				// Obtiene el servidor
					if (frmNewServer.DialogResult == DialogResult.OK)
						return frmNewServer.Server;
					else
						return null;
		}

		/// <summary>
		///		Graba la configuración
		/// </summary>
		private void SaveConfiguration()
		{ // Graba el archivo con las conexiones
				if (objXmppClient != null)
					new UC.ConnectionsRepository().Save(objXmppClient, GetConfigurationFileName());
		}

		/// <summary>
		///		Desconecta
		/// </summary>
		private void CloseApplication()
		{ // Graba la configuración
				SaveConfiguration();
			// Desconecta
				if (objXmppClient != null)
					{ // Cierra la conexión
							objXmppClient.Disconnect();
						// Libera el objeto
							objXmppClient = null;
					}
		}

		private void frmMain_Load(object sender, EventArgs e)
		{ InitForm();
		}

		private void cmdRegister_Click(object sender, EventArgs e)
		{ CreateUser();
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{ CloseApplication();
		}

		private void trvContacts_CreateUser(object sender, EventArgs e)
		{ CreateUser();
		}

		private void trvContacts_CreateConnection(object sender, EventArgs e)
		{ CreateConnection();
		}

		private void trvContacts_SetStatus(object sender, UC.SetStatusEventArgs e)
		{ SetUserStatus(e.Connection, e.Status, null);
		}

		private void trvContacts_SelectedContact(object sender, UC.SelectedContactEventArgs e)
		{ PrepareChat(e.Connection, e.Contact);
		}
	}
}
