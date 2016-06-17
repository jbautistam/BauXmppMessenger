using System;

using Bau.Libraries.LibHelper.Extensors;

namespace Bau.Libraries.LibXmppClient.Users
{
	/// <summary>
	///		Clase con los datos de un contacto
	/// </summary>
	public class JabberContact
	{
		public JabberContact(string strHost, string strLogin, string strResource = null, string strName = "")
		{ Host = strHost;
			Login = strLogin;
			Resource = strResource;
			Name = strName;
		}

		/// <summary>
		///		Comprueba si dos contactos son iguales
		/// </summary>
		public bool EqualsTo(JabberContact objUser)
		{ return Host.EqualsIgnoreCase(objUser.Host) && Login.EqualsIgnoreCase(objUser.Login);
		}

		/// <summary>
		///		Servidor
		/// </summary>
		public string Host { get; }

		/// <summary>
		///		Código de usuario
		/// </summary>
		public string Login { get; }

		/// <summary>
		///		Recurso
		/// </summary>
		public string Resource { get; set; }

		/// <summary>
		///		Nombre del usuario
		/// </summary>
		public string Name { get; }

		/// <summary>
		///		Obtiene el nombre completo
		/// </summary>
		public string FullName
		{ get
				{ if (string.IsNullOrWhiteSpace(Name))
						return Jid;
					else
						return Name;
				}
		}

		/// <summary>
		///		Jid del contacto
		/// </summary>
		public string Jid
		{ get { return $"{Login}@{Host}"; }
		}

		/// <summary>
		///		Jid completo del contacto (con el recurso en su caso
		/// </summary>
		public string FullJid
		{ get 
				{ if (string.IsNullOrWhiteSpace(Resource))
						return Jid; 
					else
						return $"{Jid}/{Resource}";
				}
		}

		/// <summary>
		///		Estado del contacto
		/// </summary>
		public JabberContactStatus Status { get; } = new JabberContactStatus();

		/// <summary>
		///		Estado de la suscripción
		/// </summary>
		public JabberSubscriptionStatus Subscription { get; } = new JabberSubscriptionStatus();
	}
}
