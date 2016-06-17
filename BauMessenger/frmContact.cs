using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Bau.Libraries.LibHelper.Extensors;

namespace TestSharpXmpp
{
	/// <summary>
	///		Formulario para añadir / modificar un contacto
	/// </summary>
	public partial class frmContact : Form
	{
		public frmContact()
		{	InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ txtJid.Text = Jid;
			txtName.Text = ContactName;
		}

		/// <summary>
		///		Comprueba los datos introducidos
		/// </summary>
		private bool ValidateData()
		{ bool blnValidate = false;

				// Comprueba los datos
					if (txtJid.Text.IsEmpty())
						Bau.Controls.Forms.Helper.ShowMessage(this, "Introduzca el código de usuario");
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
						Jid = txtJid.Text;
						ContactName = txtName.Text;
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
		///		Jid
		/// </summary>
		public string Jid { get; set; }

		/// <summary>
		///		Nombre del contacto
		/// </summary>
		public string ContactName { get; set; }
	}
}
