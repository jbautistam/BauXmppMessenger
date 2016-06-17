using System;

namespace TestSharpXmpp.UC
{
	/// <summary>
	///		Argumentos del evento de cambio de estado
	/// </summary>
	public class SetStatusEventArgs : EventArgs
	{
		public SetStatusEventArgs(Bau.Libraries.LibXmppClient.Core.JabberConnection objConnection,
															Bau.Libraries.LibXmppClient.Users.JabberContactStatus.Availability intStatus)
		{ Connection = objConnection;
			Status = intStatus;
		}

		/// <summary>
		///		Conexión
		/// </summary>
		public Bau.Libraries.LibXmppClient.Core.JabberConnection Connection { get; private set; }

		/// <summary>
		///		Estado
		/// </summary>
		public Bau.Libraries.LibXmppClient.Users.JabberContactStatus.Availability Status { get; private set; }
	}
}
