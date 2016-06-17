using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Controls.ListProperties;
using Bau.Libraries.LibXmppClient.Core.Forms;

namespace TestSharpXmpp
{
	public partial class frmFormFiller : Form
	{
		public frmFormFiller()
		{	InitializeComponent();
		}

		/// <summary>
		///		Inicializa los datos del formulario
		/// </summary>
		private void InitForm()
		{ LoadForm();
		}

		/// <summary>
		///		Muestra los controles del formulario
		/// </summary>
		private void LoadForm()
		{ // Asigna las instrucciones
				lblInstructions.Text = FormData.Instructions;
			// Asigna los controles
				foreach (KeyValuePair<string, JabberFormItem> objKeyItem in FormData.Items)
					{ JabberFormItem objFormItem = objKeyItem.Value;

							// Añade el control si es necesario
								if (MustShow(objFormItem))
									{ ListProperties.ControlType intType = GetType(objFormItem.Type);

											if (intType != ListProperties.ControlType.Unknown)
												{ string strValue = "";

														// Obtiene el valor
															if (objFormItem.Values != null && objFormItem.Values.Count > 0)
																strValue = objFormItem.Values[0];
														// Añade el control
															udtListControls.AddControl(objKeyItem.Key, intType,
																												 objFormItem.Title, strValue, objFormItem.IsRequired);
												}
									}
								else
									System.Diagnostics.Debug.WriteLine("Oops: " + objFormItem.Title);
					}
		}

		/// <summary>
		///		Comprueba si se debe mostrar un elemento
		/// </summary>
		private bool MustShow(JabberFormItem objFormItem)
		{ return objFormItem.Type != JabberFormItem.FormItemType.Hidden;
		}

		/// <summary>
		///		Obtiene el tipo del control
		/// </summary>
		private ListProperties.ControlType GetType(JabberFormItem.FormItemType intType)
		{	switch (intType)
				{	case JabberFormItem.FormItemType.Boolean:
						return ListProperties.ControlType.CheckBox;
					case JabberFormItem.FormItemType.Fixed:
						return ListProperties.ControlType.Label;
					case JabberFormItem.FormItemType.TextSingle:
					case JabberFormItem.FormItemType.TextPrivate:
						return ListProperties.ControlType.TextBox;
					case JabberFormItem.FormItemType.TextMultiple:
						return ListProperties.ControlType.MultiLine;
					default:
						return ListProperties.ControlType.Unknown;
				}
		}

		/// <summary>
		///		Comprueba si los datos introducidos son correctos
		/// </summary>
		private bool ValidateData()
		{ bool blnValidate = false;
			string strError;

				// Comprueba los datos
					if (!udtListControls.ValidateData(out strError))
						Bau.Controls.Forms.Helper.ShowMessage(this, strError);
					else
						blnValidate = true;
				// Devuelve el valor que indica si los datos son correctos
					return blnValidate;
		}

		/// <summary>
		///		Comprueba los datos
		/// </summary>
		private void Save()
		{ if (ValidateData())
				{ // Recupera los valores
						foreach (KeyValuePair<string, JabberFormItem> objItem in FormData.Items)
							if (MustShow(objItem.Value))
								objItem.Value.Results.Add(udtListControls.GetValue(objItem.Key));
					// Cierra el formulario
						DialogResult = DialogResult.OK;
						Close();
				}
		}

		/// <summary>
		///		Datos del formulario
		/// </summary>
		public JabberForm FormData { get; set; }

		private void frmFormFiller_Load(object sender, EventArgs e)
		{	InitForm();
		}

		private void cmdAccept_Click(object sender, EventArgs e)
		{ Save();
		}
	}
}
