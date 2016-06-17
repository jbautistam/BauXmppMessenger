using System;
using System.Collections.Generic;
using System.Linq;

using Bau.Libraries.LibHelper.Extensors;

namespace Bau.Libraries.LibXmppClient.Users
{
	/// <summary>
	///		Colección de <see cref="JabberGroup"/>
	/// </summary>
	public class JabberGroupsCollection : List<JabberGroup>
	{
		/// <summary>
		///		Añade un grupo
		/// </summary>
		public JabberGroup Add(JabberGroup.GroupType intType, string strName)
		{ JabberGroup objGroup = Search(intType, strName);

				// Si no existe el grupo lo añade
					if (objGroup == null)
						{ objGroup = new JabberGroup(intType, strName);
							Add(objGroup);
						}
				// Devuelve el grupo	
					return objGroup;
		}

		/// <summary>
		///		Comprueba si existe un grupo
		/// </summary>
		public bool Exists(JabberGroup.GroupType intType, string strName)
		{ return Search(intType, strName) != null;
		}

		/// <summary>
		///		Busca un grupo
		/// </summary>
		public JabberGroup Search(JabberGroup.GroupType intType, string strName)
		{ return this.FirstOrDefault(objGroup => objGroup.Type == intType && objGroup.Name.EqualsIgnoreCase(strName));
		}
	}
}
