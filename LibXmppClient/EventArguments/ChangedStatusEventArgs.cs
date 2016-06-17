using System;

namespace Bau.Libraries.LibXmppClient.EventArguments
{
	/// <summary>
	///		Argumentos del evento de cambio de estado
	/// </summary>
	public class ChangedStatusEventArgs : AbstractContactEventArgs
	{
		public ChangedStatusEventArgs(Core.JabberConnection objConnection, Users.JabberContact objContact, Users.JabberContactStatus objNewStatus)
								: base(objConnection, objContact)
		{ NewStatus = objNewStatus;
		}

		/// <summary>
		///		Nuevo estado del contacto
		/// </summary>
		public Users.JabberContactStatus NewStatus { get; }
	}
}
