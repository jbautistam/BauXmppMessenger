using System;

namespace TestSharpXmpp.UC
{
	/// <summary>
	///		Argumentos del evento de cambio de estado
	/// </summary>
	public class SelectedContactEventArgs : EventArgs
	{
		public SelectedContactEventArgs(Bau.Libraries.LibXmppClient.Core.JabberConnection objConnection,
																		Bau.Libraries.LibXmppClient.Users.JabberContact objContact)
		{ Connection = objConnection;
			Contact = objContact;
		}

		/// <summary>
		///		Conexión
		/// </summary>
		public Bau.Libraries.LibXmppClient.Core.JabberConnection Connection { get; private set; }

		/// <summary>
		///		Contacto
		/// </summary>
		public Bau.Libraries.LibXmppClient.Users.JabberContact Contact { get; private set; }
	}
}
