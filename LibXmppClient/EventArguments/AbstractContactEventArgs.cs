using System;

namespace Bau.Libraries.LibXmppClient.EventArguments
{
	/// <summary>
	///		Clase abstracta para los argumentos de eventos relacionados con un contacto
	/// </summary>
	public abstract class AbstractContactEventArgs : AbstractJabberEventArgs
	{
		public AbstractContactEventArgs(Core.JabberConnection objConnection, Users.JabberContact objContact) : base(objConnection)
		{ Contact = objContact;
		}

		/// <summary>
		///		Contacto para el que se lanza el evento
		/// </summary>
		public Users.JabberContact Contact { get; }
	}
}
