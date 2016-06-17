using System;

namespace Bau.Libraries.LibXmppClient.EventArguments
{
	/// <summary>
	///		Argumentos del evento de recepción de un mensaje
	/// </summary>
	public class MessageReceivedEventArgs : AbstractContactEventArgs
	{
		public MessageReceivedEventArgs(Core.JabberConnection objConnection, Users.JabberContact objContact, 
																		string strSubject, string strBody) : base(objConnection, objContact)
		{ Subject = strSubject;
			Body = strBody;
		}

		/// <summary>
		///		Asunto del mensaje
		/// </summary>
		public string Subject { get; }

		/// <summary>
		///		Cuerpo del mensaje
		/// </summary>
		public string Body { get; }
	}
}
