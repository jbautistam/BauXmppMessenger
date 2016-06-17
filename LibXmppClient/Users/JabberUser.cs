using System;

namespace Bau.Libraries.LibXmppClient.Users
{
	/// <summary>
	///		Clase con los datos del usuario
	/// </summary>
	public class JabberUser : JabberContact
	{
		public JabberUser(string strHost, string strLogin, string strPassword) : base(strHost, strLogin)
		{ Password = strPassword;
		}

		/// <summary>
		///		Contraseña
		/// </summary>
		public string Password { get; }
	}
}
