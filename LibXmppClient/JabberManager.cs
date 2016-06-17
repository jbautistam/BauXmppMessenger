using System;

namespace Bau.Libraries.LibXmppClient
{
	/// <summary>
	///		Clase de conexión a XMPP
	/// </summary>
	public class JabberManager : IDisposable
	{ // Eventos públicos
			public event EventHandler<EventArguments.MessageReceivedEventArgs> MessageReceived;
			public event EventHandler<EventArguments.ChangedStatusEventArgs> ChangedStatus;
			public event EventHandler<EventArguments.SubscriptionRequestEventArgs> SubscriptionRequested;
			public event EventHandler<EventArguments.RosterUpdatedRequestArgs> RosterUpdated;
			public event EventHandler<EventArguments.ChangedUserStatusEventArgs> ChangedUserStatus;
			public event EventHandler<EventArguments.FormRequestedEventArgs> FormRequested;

		public JabberManager()
		{ Connections = new Core.JabberConnectionsCollection(this);
		}

		/// <summary>
		///		Registra un usuario
		/// </summary>
		public bool RegisterBegin(string strHost, out string strError)
		{ Core.Register.JabberRegisterConnection objConnection = new Core.Register.JabberRegisterConnection(this, new Servers.JabberServer(strHost));

				// Comienza el proceso de registro
					return objConnection.RegisterBegin(out strError);
		}

		/// <summary>
		///		Añade una conexión
		/// </summary>
		public Core.JabberConnection AddConnection(string strHost, string strUser, string strPassword)
		{ return AddConnection(new Servers.JabberServer(strHost), new Users.JabberUser(strHost, strUser, strPassword));
		}

		/// <summary>
		///		Añade una conexión
		/// </summary>
		public Core.JabberConnection AddConnection(Servers.JabberServer objServer, Users.JabberUser objUser)
		{ return Connections.Add(objServer, objUser);
		}

		/// <summary>
		///		Lanza el evento de solicitud de formulario
		/// </summary>
		internal void RaiseEventRequestForm(EventArguments.FormRequestedEventArgs objArguments)
		{ FormRequested?.Invoke(this, objArguments);
		}

		/// <summary>
		///		Lanza el evento de mensaje recibido
		/// </summary>
		internal void RaiseEventMessageReceived(EventArguments.MessageReceivedEventArgs objArguments)
		{ MessageReceived?.Invoke(this, objArguments);
		}

		/// <summary>
		///		Lanza el evento de cambio de estado
		/// </summary>
		internal void RaiseEventChangedStatus(EventArguments.ChangedStatusEventArgs objArguments)
		{ ChangedStatus?.Invoke(this, objArguments);
		}

		/// <summary>
		///		Lanza el evento de lista de contactos modificada
		/// </summary>
		internal void RaiseEventRosterUpdated(EventArguments.RosterUpdatedRequestArgs objArguments)
		{ RosterUpdated?.Invoke(this, objArguments);
		}

		/// <summary>
		///		Lanza el evento de solicitud de suscripción
		/// </summary>
		internal void RaiseEventSubscriptionRequest(EventArguments.SubscriptionRequestEventArgs objArguments)
		{ SubscriptionRequested?.Invoke(this, objArguments);
		}

		/// <summary>
		///		Lanza el evento de cambio de estado del usuario
		/// </summary>
		internal void RaiseEventUserStatusChanged(EventArguments.ChangedUserStatusEventArgs objArguments)
		{ ChangedUserStatus?.Invoke(this, objArguments);
		}

		/// <summary>
		///		Desconecta las conexiones
		/// </summary>
		public void Disconnect()
		{ if (Connections != null)
				{ Connections.Disconnect();
					Connections.Clear();
				}
		}

		/// <summary>
		///		Libera la memoria
		/// </summary>
		protected virtual void Dispose(bool blnDisposing)
		{	if (!IsDisposed)
				{ // Desconecta
						if (blnDisposing)
							Disconnect();
					// Indica que se ha liberado
					IsDisposed = true;
				}
		}

		/// <summary>
		///		Libera el objeto
		/// </summary>
		public void Dispose()
		{	Dispose(true);
		}

		/// <summary>
		///		Conexiones
		/// </summary>
		public Core.JabberConnectionsCollection Connections { get; private set; }

		/// <summary>
		///		Indica si se ha liberado la conexión
		/// </summary>
		public bool IsDisposed { get; private set; }
	}
}
