using System;

namespace Bau.Libraries.LibXmppClient.EventArguments
{
	/// <summary>
	///		Agumentos del evento de cambio de estado de un usuario
	/// </summary>
	public class ChangedUserStatusEventArgs : AbstractJabberEventArgs
	{
		public ChangedUserStatusEventArgs(Core.JabberConnection objConnection, Users.JabberUser objUser) : base(objConnection)
		{ User = objUser;
		}

		/// <summary>
		///		Usuario
		/// </summary>
		public Users.JabberUser User { get; }
	}
}
