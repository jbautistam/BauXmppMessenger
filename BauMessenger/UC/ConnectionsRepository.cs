using System;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibXmppClient;
using Bau.Libraries.LibXmppClient.Core;
using Bau.Libraries.LibXmppClient.Servers;
using Bau.Libraries.LibXmppClient.Users;

namespace TestSharpXmpp.UC
{
	/// <summary>
	///		Repository para las conexiones
	/// </summary>
	public class ConnectionsRepository
	{ // Constantes privadas
			private const string cnstStrTagRoot = "Connections";
			private const string cnstStrTagConnection = "Connection";
			private const string cnstStrTagServer = "Server";
			private const string cnstStrTagAddress = "Address";
			private const string cnstStrTagPort = "Port";
			private const string cnstStrTagUseSsl = "UseSsl";
			private const string cnstStrTagUser = "User";
			private const string cnstStrTagLogin = "Login";
			private const string cnstStrTagPassword = "Password";
			private const string cnstStrTagStatus = "Status";

		/// <summary>
		///		Carga las conexiones
		/// </summary>
		public void Load(JabberManager objManager, string strFileName)
		{ if (System.IO.File.Exists(strFileName))
				{ MLFile objMLFile = new Bau.Libraries.LibMarkupLanguage.Services.XML.XMLParser().Load(strFileName);

						// Carga los datos
							foreach (MLNode objMLNode in objMLFile.Nodes)
								if (objMLNode.Name == cnstStrTagRoot)
									foreach (MLNode objMLConnection in objMLNode.Nodes)
										if (objMLConnection.Name == cnstStrTagConnection)
											{ JabberServer objServer = null;
												JabberUser objUser = null;

													// Carga los datos del servidor
														foreach (MLNode objMLServer in objMLConnection.Nodes)
															if (objMLServer.Name == cnstStrTagServer)
																objServer = new JabberServer(objMLServer.Attributes[cnstStrTagAddress].Value,
																														 objMLServer.Attributes[cnstStrTagPort].Value.GetInt(5222),
																														 objMLServer.Attributes[cnstStrTagUseSsl].Value.GetBool(true));
													// Carga los datos del usuario
														foreach (MLNode objMLUser in objMLConnection.Nodes)
															if (objMLUser.Name == cnstStrTagUser)
																{ // Crea el usuario
																		objUser = new JabberUser(objMLUser.Attributes[cnstStrTagAddress].Value, 
																														 objMLUser.Attributes[cnstStrTagLogin].Value,
																														 objMLUser.Attributes[cnstStrTagPassword].Value);
																	// Y le asigna el estado
																		objUser.Status.Status = (JabberContactStatus.Availability) objMLUser.Attributes[cnstStrTagStatus].Value.GetInt(0);
																}
													// Añade la conexión
														if (objServer != null && objUser != null)
															objManager.AddConnection(objServer, objUser);
											}
				}
		}

		/// <summary>
		///		Graba las conexiones
		/// </summary>
		public void Save(JabberManager objManager, string strFileName)
		{ MLFile objMLFile = new MLFile();
			MLNode objMLNode = objMLFile.Nodes.Add(cnstStrTagRoot);
			
				// Asigna los nodos de las conexión
					foreach (JabberConnection objConnection in objManager.Connections)
						{ MLNode objMLConnection = objMLNode.Nodes.Add(cnstStrTagConnection);
							MLNode objMLServer = objMLConnection.Nodes.Add(cnstStrTagServer);
							MLNode objMLUser = objMLConnection.Nodes.Add(cnstStrTagUser);

								// Añade los datos del servidor
									objMLServer.Attributes.Add(cnstStrTagAddress, objConnection.Host.Address);
									objMLServer.Attributes.Add(cnstStrTagPort, objConnection.Host.Port);
									objMLServer.Attributes.Add(cnstStrTagUseSsl, objConnection.Host.UseTls);
								// Añade los datos del usuario
									objMLUser.Attributes.Add(cnstStrTagAddress, objConnection.User.Host);
									objMLUser.Attributes.Add(cnstStrTagLogin, objConnection.User.Login);
									objMLUser.Attributes.Add(cnstStrTagPassword, objConnection.User.Password);
									objMLUser.Attributes.Add(cnstStrTagServer, (int) objConnection.User.Status.Status);
						}
				// Crea el directorio
					Bau.Libraries.LibHelper.Files.HelperFiles.MakePath(System.IO.Path.GetDirectoryName(strFileName));
				// Graba el archivo
					new Bau.Libraries.LibMarkupLanguage.Services.XML.XMLWriter().Save(objMLFile, strFileName);
		}
	}
}
