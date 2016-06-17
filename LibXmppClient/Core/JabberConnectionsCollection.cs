using System;
using System.Collections.Generic;

namespace Bau.Libraries.LibXmppClient.Core
{
	/// <summary>
	///		Colección de conexiónes
	/// </summary>
	public class JabberConnectionsCollection : List<JabberConnection>
	{
		internal JabberConnectionsCollection(JabberManager objManager)
		{ Manager = objManager;
		}

		/// <summary>
		///		Añade una conexión
		/// </summary>
		internal JabberConnection Add(Servers.JabberServer objHost, Users.JabberUser objUser)
		{ JabberConnection objConnection = Search(objHost, objUser);

				// Si no existía la conexión, se añade
					if (objConnection == null)
						{ // Crea el objeto
								objConnection = new JabberConnection(Manager, objHost, objUser);
							// Añade la conexión
								Add(objConnection);
						}
				// Devuelve la conexión
					return objConnection;
		}

		/// <summary>
		///		Busca una conexión en la colección
		/// </summary>
		internal JabberConnection Search(Servers.JabberServer objHost, Users.JabberUser objUser)
		{ // Recorre las conexiones
				foreach (JabberConnection objConnection in this)
					if (objConnection.Host.EqualsTo(objHost) && objConnection.User.EqualsTo(objUser))
						return objConnection;
			// Si ha llegado hasta aquí es porque no existe
				return null;
		}

		/// <summary>
		///		Desconecta
		/// </summary>
		internal void Disconnect()
		{ foreach (JabberConnection objConnection in this)
				objConnection.Disconnect();
		}

		/// <summary>
		///		Manager de conexiones
		/// </summary>
		private JabberManager Manager { get; }
	}
}
