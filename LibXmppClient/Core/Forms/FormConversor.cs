using System;
using Sharp.Xmpp.Extensions.Dataforms;

namespace Bau.Libraries.LibXmppClient.Core.Forms
{
	/// <summary>
	///		Conversor de un formulario devuelto por la librería
	/// </summary>
	internal class FormConversor
	{
		/// <summary>
		///		Convierte un DataForm de Xmpp en un formulario de la librería
		/// </summary>
		internal JabberForm Convert(DataForm objDataForm)
		{ JabberForm objForm = new JabberForm(ConvertType(objDataForm.Type), objDataForm.Title, objDataForm.Instructions);

				// Convierte los tipos
					for (int intIndex = 0; intIndex < objDataForm.Fields.Count; intIndex++)
						{ string strName = GetName(objDataForm.Fields[intIndex].Name, intIndex);

								// Añade el elemento convertido
									objForm.Items.Add(strName, ConvertField(objDataForm.Fields[intIndex], strName));
						}
				// Comprueba si el formulario tiene un captcha
					objForm.HasCaptcha = CheckHasCaptcha(objForm);
				// Devuelve el formulario
					return objForm;
		}

		/// <summary>
		///		Comprueba si el formulario tiene un captcha
		/// </summary>
		private bool CheckHasCaptcha(JabberForm objForm)
		{ // Comprueba si el formulario tiene un captcha
				foreach (System.Collections.Generic.KeyValuePair<string, JabberFormItem> objFormItem in objForm.Items)
					if (objFormItem.Value.Name == "FORM_TYPE" && objFormItem.Value.FirstValue == "urn:xmpp:captcha")
						return true;
			// Devuelve el valor que indica si tiene un captcha
				return false;
		}

		/// <summary>
		///		Obtiene el nombre
		/// </summary>
		private string GetName(string strName, int intIndex)
		{	if (!string.IsNullOrEmpty(strName))
				return strName;
			else
				return $"__Fixed_{intIndex}";
		}

		/// <summary>
		///		Convierte el tipo
		/// </summary>
		private JabberForm.FormType ConvertType(DataFormType intType)
		{ switch (intType)
				{	case DataFormType.Cancel:
						return JabberForm.FormType.Cancel;
					case DataFormType.Result:
						return JabberForm.FormType.Result;
					case DataFormType.Submit:
						return JabberForm.FormType.Submit;
					default:
						return JabberForm.FormType.Form;
				}
		}

		/// <summary>
		///		Convierte un campo
		/// </summary>
		private JabberFormItem ConvertField(DataField objDataField, string strName)
		{ JabberFormItem objFormItem = new JabberFormItem(ConvertFieldType(objDataField.Type), strName, objDataField.Label, objDataField.Required);

				// Añade los valores
					objFormItem.Values.AddRange(objDataField.Values);
				// Devuelve el campo
					return objFormItem;
		}

		/// <summary>
		///		Convierte el tipo de campo
		/// </summary>
		private JabberFormItem.FormItemType ConvertFieldType(DataFieldType? intType)
		{ if (intType == null)
				return JabberFormItem.FormItemType.TextSingle;
			else
				switch (intType)
					{	case DataFieldType.Boolean:
							return JabberFormItem.FormItemType.Boolean;
						case DataFieldType.Fixed:
							return JabberFormItem.FormItemType.Fixed;
						case DataFieldType.Hidden:
							return JabberFormItem.FormItemType.Hidden;
						case DataFieldType.JidMulti:
							return JabberFormItem.FormItemType.JidMulti;
						case DataFieldType.JidSingle:
							return JabberFormItem.FormItemType.JidSingle;
						case DataFieldType.ListMulti:
							return JabberFormItem.FormItemType.ListMultiple;
						case DataFieldType.ListSingle:
							return JabberFormItem.FormItemType.ListSingle;
						case DataFieldType.TextMulti:
							return JabberFormItem.FormItemType.TextMultiple;
						case DataFieldType.TextPrivate:
							return JabberFormItem.FormItemType.TextPrivate;
						case DataFieldType.TextSingle:
							return JabberFormItem.FormItemType.TextSingle;
						default:
							return JabberFormItem.FormItemType.Hidden;
					}
		}
	}
}
