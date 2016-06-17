using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Libraries.LibHelper.Extensors;

namespace TestSharpXmpp
{
	/// <summary>
	///		Formulario para añadir / modificar una conexión
	/// </summary>
	public partial class frmConnection : Form
	{
		public frmConnection()
		{	InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ if (Server != null)
				{ txtHost.Text = Server.Address;
					nudPort.Value = Server.Port;
					chkUseTls.Checked = Server.UseTls;
				}
			if (User != null)
				{ txtLogin.Text = User.Name;
					txtPassword.Text = User.Password;
				}
		}

		/// <summary>
		///		Comprueba los datos introducidos
		/// </summary>
		private bool ValidateData()
		{ bool blnValidate = false;

				// Comprueba los datos
					if (txtHost.Text.IsEmpty())
						Bau.Controls.Forms.Helper.ShowMessage(this, "Introduzca la dirección del servidor");
					else if (txtLogin.Text.IsEmpty())
						Bau.Controls.Forms.Helper.ShowMessage(this, "Introduzca el código de inicio de sesión");
					else if (txtPassword.Text.IsEmpty())
						Bau.Controls.Forms.Helper.ShowMessage(this, "Introduzca la contraseña del usuario");
					else
						blnValidate = true;
				// Devuelve el valor que indica si los datos son correctos
					return blnValidate;
		}

		/// <summary>
		///		Guarda los datos
		/// </summary>
		private void Save()
		{ if (ValidateData())
				{ // Guarda los datos
						Server = new Bau.Libraries.LibXmppClient.Servers.JabberServer(txtHost.Text, (int) nudPort.Value, chkUseTls.Checked);
						User = new Bau.Libraries.LibXmppClient.Users.JabberUser(txtHost.Text, txtLogin.Text, txtPassword.Text);
					// Cierra el formulario
						DialogResult = DialogResult.OK;
						Close();
				}
		}

		private void frmConnection_Load(object sender, EventArgs e)
		{ InitForm();
		}

		private void cmdAccept_Click(object sender, EventArgs e)
		{ Save();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{ DialogResult = DialogResult.Cancel;
			Close();
		}

		/// <summary>
		///		Servidor
		/// </summary>
		public Bau.Libraries.LibXmppClient.Servers.JabberServer Server { get; set; }

		/// <summary>
		///		Usuario
		/// </summary>
		public Bau.Libraries.LibXmppClient.Users.JabberUser User { get; set; }
	}
}
