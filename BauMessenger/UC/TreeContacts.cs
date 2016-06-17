using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Libraries.LibXmppClient;
using Bau.Libraries.LibXmppClient.Core;
using Bau.Libraries.LibXmppClient.Users;

namespace TestSharpXmpp.UC
{
	/// <summary>
	///		Arbol de contacots
	/// </summary>
	public partial class TreeContacts : UserControl
	{ // Eventos públicos
			public event EventHandler CreateConnection;
			public event EventHandler CreateUser;
			public event EventHandler<SetStatusEventArgs> SetStatus;
			public event EventHandler<SelectedContactEventArgs> SelectedContact;
		// Enumerados privados
			/// <summary>Nodo del árbol</summary>
			private enum TreeNodeType
				{ 
					/// <summary>Conexión</summary>
					Connection,
					/// <summary>Grupo de contactos</summary>
					Group,
					/// <summary>Contacto</summary>
					Contact
				}
			/// <summary>Clave de imagen</summary>
			private enum ImageKey
				{ Connection,
					ServerDisconnected,
					Group,
					Contact,
					ContactOnline,
					ContactChat,
					ContactOffline,
					ContactRequested
				}

		public TreeContacts()
		{	InitializeComponent();
		}

		/// <summary>
		///		Carga el árbol de contactos
		/// </summary>
		internal void LoadContacts(JabberManager objXmppClient)
		{ // Asigna las propiedades
				Manager = objXmppClient;
			// Inicializa el árbol
				trvContacts.SaveOpenNodes();
				trvContacts.Nodes.Clear();
				trvContacts.ImageList = imgList;
			// Carga los grupos
				if (Manager != null)
					foreach (JabberConnection objConnection in objXmppClient.Connections)
						{ TreeNode trnConnection = AddNode(null, TreeNodeType.Connection, GetImage(objConnection), 
																							 $"{objConnection.User.Jid} - {objConnection.Host.Address}" + new string(' ', 20), 
																							 true, Color.Navy, objConnection);
								
								// Añade los grupos
									foreach (JabberGroup objGroup in objConnection.Groups)
										{ TreeNode trnGroup = AddNode(trnConnection, TreeNodeType.Group, ImageKey.Group, 
																									objGroup.Name + new string(' ', 20), 
																									true, Color.Red, objGroup);

												// Añade los contactos
													foreach (KeyValuePair<string, JabberContact> objContact in objGroup.Contacts)
														AddNode(trnGroup, TreeNodeType.Contact, GetImage(objContact.Value.Status), 
																		objContact.Value.FullName, false, Color.Black, objContact.Value);
										}
						}
			// Recarga el árbol
				trvContacts.RestoreOpenNodes();
		}

		/// <summary>
		///		Obtiene la imagen asociada a una conexión
		/// </summary>
		private ImageKey GetImage(JabberConnection objConnection)
		{ if (objConnection.IsConnected)
				return ImageKey.Connection;
			else
				return ImageKey.ServerDisconnected;
		}

		/// <summary>
		///		Obtiene la clave de imagen asociada a un estado
		/// </summary>
		private ImageKey GetImage(JabberContactStatus objStatus)
		{ switch (objStatus.Status)
				{	case JabberContactStatus.Availability.Away:
						return ImageKey.ContactOffline;
					case JabberContactStatus.Availability.Chat:
						return ImageKey.ContactChat;
					case JabberContactStatus.Availability.Dnd:	
						return ImageKey.Contact;
					case JabberContactStatus.Availability.Offline:
						return ImageKey.ContactOffline;
					case JabberContactStatus.Availability.Online:
						return ImageKey.ContactOnline;
					case JabberContactStatus.Availability.Xa:
						return ImageKey.Contact;
					default:
						return ImageKey.Contact;
				}
		}

		/// <summary>
		///		Añade un nodo
		/// </summary>
		private TreeNode AddNode(TreeNode trnParent, TreeNodeType intNode, ImageKey intImage, string strText, bool blnBold, 
														 Color clrColor, object objTag)
		{ Bau.Controls.Tree.TreeNodeKey objKey = new Bau.Controls.Tree.TreeNodeKey((int) intNode, trvContacts.Nodes.Count + 1, objTag);

				// Añade el nodo
					return trvContacts.AddNode(trnParent, objKey, strText, false, (int) intImage, clrColor, blnBold);
		}

		/// <summary>
		///		Obtiene el contacto seleccionado
		/// </summary>
		internal JabberContact GetSelectedContact()
		{ Bau.Controls.Tree.TreeNodeKey objKey = trvContacts.GetKey(trvContacts.SelectedNode);

				// Obtiene el contacto seleccionado
					if (objKey != null && objKey.IDType == (int) TreeNodeType.Contact && objKey.Tag is JabberContact)
						return objKey.Tag as JabberContact;
					else
						return null;
		}

		/// <summary>
		///		Obtiene la conexión seleccionada
		/// </summary>
		internal JabberConnection GetSelectedConnection()
		{ return GetSelectedConnection(trvContacts.SelectedNode);
		}

		/// <summary>
		///		Obtiene la conexión seleccionada en el árbol
		/// </summary>
		private JabberConnection GetSelectedConnection(TreeNode trnNode)
		{ JabberConnection objConnection = null;

				// Obtiene la conexión
					if (trnNode != null)
						{ Bau.Controls.Tree.TreeNodeKey objKey = trvContacts.GetKey(trnNode);

								if (objKey != null && objKey.IDType == (int) TreeNodeType.Connection && objKey.Tag is JabberConnection)
									objConnection = objKey.Tag as JabberConnection;
								else if (trnNode.Parent != null)
									objConnection = GetSelectedConnection(trnNode.Parent);
						}
				// Devuelve la conexión
					return objConnection;
		}

		/// <summary>
		///		Abre el formulario de modificación de contacto
		/// </summary>
		private void OpenFormUpdateContact(JabberContact objContact)
		{ JabberConnection objConnection = GetSelectedConnection();

				if (objConnection == null)
					Bau.Controls.Forms.Helper.ShowMessage(ParentForm, "Seleccione una conexión");
				else
					{ frmContact frmNewContact = new frmContact();

							// Asigna las propiedades
								frmNewContact.Jid = objContact?.Jid;
								frmNewContact.ContactName = objContact?.Name;
							// Abre el formulario
								frmNewContact.ShowDialog();
							// Si todo es correcto ...
								if (frmNewContact.DialogResult == DialogResult.OK)
									objConnection.AddContact(frmNewContact.Jid, frmNewContact.ContactName);
					}
		}

		/// <summary>
		///		Elimina un contacto
		/// </summary>
		private void RemoveContact(JabberConnection objConnection, JabberContact objContact)
		{ if (objConnection != null)
				{ if (objContact != null)
						{ if (Bau.Controls.Forms.Helper.ShowQuestion(ParentForm, $"¿Realmente desea eliminar al contacto {objContact.FullName}?"))
								objConnection.DeleteContact(objContact);
						}
					else if (Bau.Controls.Forms.Helper.ShowQuestion(ParentForm, $"¿Realmente desea eliminar la conexión {objConnection.Host.Address} - usuario {objConnection.User.Login}"))
						{ // Desconecta la conexión
								objConnection.Disconnect();
							// Elimina la conexión 
								Manager.Connections.Remove(objConnection);
							// Actualiza el árbol
								LoadContacts(Manager);
						}
				}
		}

		/// <summary>
		///		Habilita / inhabilita los menús
		/// </summary>
		private void ShowMenus()
		{ JabberConnection objConnection = GetSelectedConnection();

				// Inhabilita los menús
					mnuConnect.Enabled = false;
					mnuDisconnect.Enabled = false;
					mnuOnline.Enabled = false;
					mnuAway.Enabled = false;
					mnuChat.Enabled = false;
					mnuDnd.Enabled = false;
					mnuXa.Enabled = false;
				// Habilita los menús
					if (objConnection != null)
						{ if (objConnection.User.Status.Status == JabberContactStatus.Availability.Offline)
								mnuConnect.Enabled = true;
							else
								{ mnuDisconnect.Enabled = true;
									mnuOnline.Enabled = true;
									mnuAway.Enabled = true;
									mnuChat.Enabled = true;
									mnuDnd.Enabled = true;
									mnuXa.Enabled = true;
								}
						}
		}

		/// <summary>
		///		Lanza el evento de cambio de estado
		/// </summary>
		private void RaiseEventSetStatus(JabberContactStatus.Availability intStatus)
		{ JabberConnection objConnection = GetSelectedConnection();

				if (objConnection != null)
					{ SetStatus?.Invoke(this, new SetStatusEventArgs(objConnection, intStatus));
						ShowMenuStatus(intStatus);
						Focus();
					}
		}

		/// <summary>
		///		Cambia los estados de los menús
		/// </summary>
		private void ShowMenuStatus(JabberContactStatus.Availability intStatus)
		{ // Deselecciona los menús
				mnuAway.Checked = false;
				mnuChat.Checked = false;
				mnuDnd.Checked = false;
				mnuOnline.Checked = false;
				mnuXa.Checked = false;
			// Selecciona el menú adecuado
				switch (intStatus)
					{	case JabberContactStatus.Availability.Away:
								mnuAway.Checked = true;
							break;
						case JabberContactStatus.Availability.Chat:
								mnuChat.Checked = true;
							break;
						case JabberContactStatus.Availability.Dnd:
								mnuDnd.Checked = true;
							break;
						case JabberContactStatus.Availability.Online:
								mnuOnline.Checked = true;
							break;
						case JabberContactStatus.Availability.Xa:
								mnuXa.Checked = true;
							break;
					}
		}

		/// <summary>
		///		Añade una conexión
		/// </summary>
		private void RaiseEventCreateConnection()
		{ CreateConnection?.Invoke(this, EventArgs.Empty);
		}

		/// <summary>
		///		Lanza el evento de creación de usuario
		/// </summary>
		private void RaiseEventCreateUser()
		{ CreateUser?.Invoke(this, EventArgs.Empty);
		}

		/// <summary>
		///		Lanza el evento de contacto seleccionado
		/// </summary>
		private void RaiseEventSelectedContact()
		{ SelectedContact?.Invoke(this, new SelectedContactEventArgs(GetSelectedConnection(), GetSelectedContact()));
		}

		/// <summary>
		///		Manager de XMPP
		/// </summary>
		private JabberManager Manager { get; set; }

		private void cmdNew_Click(object sender, EventArgs e)
		{ OpenFormUpdateContact(null);
		}

		private void cmdDelete_Click(object sender, EventArgs e)
		{ RemoveContact(GetSelectedConnection(), GetSelectedContact());
		}

		private void cmdNewConnection_Click(object sender, EventArgs e)
		{ RaiseEventCreateConnection();
		}

		private void cmdCreateUser_Click(object sender, EventArgs e)
		{ RaiseEventCreateUser();
		}

		private void cmdSetStatus_DropDownOpening(object sender, EventArgs e)
		{ ShowMenus();
		}

		private void mnuConnect_Click(object sender, EventArgs e)
		{ RaiseEventSetStatus(JabberContactStatus.Availability.Online);
		}

		private void mnuDisconnect_Click(object sender, EventArgs e)
		{ RaiseEventSetStatus(JabberContactStatus.Availability.Offline);
		}

		private void mnuOnline_Click(object sender, EventArgs e)
		{ RaiseEventSetStatus(JabberContactStatus.Availability.Online);
		}

		private void mnuAway_Click(object sender, EventArgs e)
		{ RaiseEventSetStatus(JabberContactStatus.Availability.Away);
		}

		private void mnuChat_Click(object sender, EventArgs e)
		{ RaiseEventSetStatus(JabberContactStatus.Availability.Chat);
		}

		private void mnuDnd_Click(object sender, EventArgs e)
		{ RaiseEventSetStatus(JabberContactStatus.Availability.Dnd);
		}

		private void mnuXa_Click(object sender, EventArgs e)
		{ RaiseEventSetStatus(JabberContactStatus.Availability.Xa);
		}

		private void trvContacts_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{ RaiseEventSelectedContact();
		}
	}
}
