using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibXmppClient.Core;
using Bau.Libraries.LibXmppClient.Users;

namespace TestSharpXmpp.UC
{
	/// <summary>
	///		Control para manejo de un chat con un contacto
	/// </summary>
	public partial class Chat : UserControl
	{ // Eventos
			public event EventHandler CloseRequest;

		public Chat()
		{ InitializeComponent();
		}

		/// <summary>
		///		Inicializa el control
		/// </summary>
		public void InitControl(JabberConnection objConnection, JabberContact objContact)
		{ Connection = objConnection;
			Contact = objContact;
		}

		/// <summary>
		///		Envía un mensaje
		/// </summary>
		private void SendMessage()
		{	if (Contact != null && Connection != null)
				{ // Envía el mensaje
						Connection.SendMessage(Contact, txtChat.Text);
					// Muestra el mensaje enviado
						LogContact(Connection.User);
						LogMessage(txtChat.Text, false);
					// Limpia el texto
						txtChat.Text = "";
				}
		}

		/// <summary>
		///		Añade el mensaje recibido
		/// </summary>
		internal void AddReceivedMessage(string strSubject, string strBody)
		{	LogContact(Contact);
			LogMessage(strSubject, true);
			LogMessage(strBody, true);
			LogText("");
		}

		/// <summary>
		///		Log de datos de contacto
		/// </summary>
		private void LogContact(JabberContact objContact)
		{ LogText($"[{DateTime.Now}] {objContact.FullName}:");
		}

		/// <summary>
		///		Log de un mensaje
		/// </summary>
		private void LogMessage(string strMessage, bool blnReceived)
		{ if (!strMessage.IsEmpty())
				{ // Añade el prefijo
						if (blnReceived)
							strMessage = $"<<< {strMessage}";
						else
							strMessage = $">>> {strMessage}";
					// y lo envía
						LogText(strMessage);
						LogText("");
				}
		}

		/// <summary>
		///		Log de un texto
		/// </summary>
		private void LogText(string strText)
		{ txtMessages.AppendText(strText + Environment.NewLine);
		}

		/// <summary>
		///		Conexión
		/// </summary>
		public JabberConnection Connection { get; private set; }

		/// <summary>
		///		Contacto
		/// </summary>
		public JabberContact Contact { get; private set; }

		private void cmdSend_Click(object sender, EventArgs e)
		{ SendMessage();
		}

		private void cmdClose_Click(object sender, EventArgs e)
		{ CloseRequest?.Invoke(this, EventArgs.Empty);
		}
	}
}
