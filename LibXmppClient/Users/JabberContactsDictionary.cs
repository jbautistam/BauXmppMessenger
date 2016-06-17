using System;
using System.Collections.Generic;

namespace Bau.Libraries.LibXmppClient.Users
{
	/// <summary>
	///		Diccionario de contactos
	/// </summary>
	public class JabberContactsDictionary : Dictionary<string, JabberContact>
	{
		/// <summary>
		///		Añade un contacto
		/// </summary>
		public void Add(JabberContact objContact)
		{ Add(objContact.Jid, objContact);
		}

		/// <summary>
		///		Obtiene un contacto
		/// </summary>
		public JabberContact GetContact(string strJid)
		{ JabberContact objContact;

				// Obtiene el contacto del diccionario
					if (TryGetValue(strJid, out objContact))
						return objContact;
					else
						return null;
		}

		/// <summary>
		///		Busca un contacto por dominio y nombre
		/// </summary>
		internal JabberContact Search(string strHost, string strLogin)
		{ return GetContact($"{strLogin}@{strHost}");
		}
	}
}
