using System;
using System.Collections.Generic;

using Bau.Libraries.LibHelper.Extensors;
using Sharp.Xmpp.Extensions.Dataforms;

namespace Bau.Libraries.LibXmppClient.Core.Forms
{
	/// <summary>
	///		Convierte los datos de un formulario para enviarlos
	/// </summary>
	public class FormSubmitConversor
	{
		/// <summary>
		///		Convierte los datos de un formulario
		/// </summary>
		internal DataField[] Convert(JabberForm objForm)
		{ List<DataField> objColResult = new List<DataField>();

				// Convierte los resultados
					foreach (KeyValuePair<string, JabberFormItem> objKeyValue in objForm.Items)
						if (MustSend(objKeyValue.Value))
							objColResult.Add(Convert(objKeyValue.Value));
				// Devuelve los datos
					return objColResult.ToArray();
		}

		/// <summary>
		///		Comprueba si se debe enviar un resultado
		/// </summary>
		private bool MustSend(JabberFormItem objFormItem)
		{ return objFormItem.Type != JabberFormItem.FormItemType.Fixed;
		}

		/// <summary>
		///		Convierte los valores de un elemento de formulario
		/// </summary>
		private DataField Convert(JabberFormItem objFormItem)
		{ switch (objFormItem.Type)
				{	case JabberFormItem.FormItemType.Hidden:
						return new HiddenField(objFormItem.Name, objFormItem.Values.ToArray());
					case JabberFormItem.FormItemType.Boolean:
						return new BooleanField(objFormItem.Name, objFormItem.GetFirstResult().GetBool());
					case JabberFormItem.FormItemType.TextMultiple:
						return new TextMultiField(objFormItem.Name, objFormItem.Results.ToArray());
					case JabberFormItem.FormItemType.TextPrivate:
						return new PasswordField(objFormItem.Name, objFormItem.GetFirstResult());
					case JabberFormItem.FormItemType.TextSingle:
						return new TextField(objFormItem.Name, objFormItem.GetFirstResult());
					default:
						return null;
				}
		}
	}
}
