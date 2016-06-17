using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Libraries.LibHelper.Extensors;

namespace TestSharpXmpp
{
	/// <summary>
	///		Formulario para seleccionar un servidor
	/// </summary>
	public partial class frmServer : Form
	{
		public frmServer()
		{	InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ txtServer.Text = Server;
		}

		/// <summary>
		///		Comprueba los datos introducidos
		/// </summary>
		private bool ValidateData()
		{ bool blnValidate = false;

				// Comprueba los datos
					if (txtServer.Text.IsEmpty())
						Bau.Controls.Forms.Helper.ShowMessage(this, "Introduzca el código de servidor");
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
						Server = txtServer.Text;
					// Cierra el formulario
						DialogResult = DialogResult.OK;
						Close();
				}
		}

		private void frmContact_Load(object sender, EventArgs e)
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
		public string Server { get; set; }
	}
}
