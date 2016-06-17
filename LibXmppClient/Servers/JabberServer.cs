using System;

using Bau.Libraries.LibHelper.Extensors;

namespace Bau.Libraries.LibXmppClient.Servers
{
	/// <summary>
	///		Clase con los datos de un servidor
	/// </summary>
	public class JabberServer
	{
		public JabberServer(string strAddress, int intPort = 5222, bool blnUseTls = true)
		{ Address = strAddress;
			Port = intPort;
			UseTls = blnUseTls;
		}

		/// <summary>
		///		Comprueba si dos elementos son iguales
		/// </summary>
		public bool EqualsTo(JabberServer objHost)
		{ return Address.EqualsIgnoreCase(objHost.Address) && Port == objHost.Port && UseTls == objHost.UseTls;
		}

		/// <summary>
		///		Dirección del servidor
		/// </summary>
		public string Address { get; }

		/// <summary>
		///		Puerto de conexión
		/// </summary>
		public int Port { get; } = 5222;

		/// <summary>
		///		Indica si se va a utilizar TLS para la conexión
		/// </summary>
		public bool UseTls { get; } = true;
	}
}
