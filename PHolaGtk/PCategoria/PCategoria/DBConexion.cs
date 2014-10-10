using System;
using MySql.Data.MySqlClient;
using Gtk;
using System.Configuration;

namespace PCategoria
{
	public class DBConexion
	{
		private static MySqlConnection instancia = null;
		private static readonly object padlock = new object();

		private DBConexion()
		{
		}

		public static MySqlConnection Conexion
		{
			get
			{
				lock (padlock)
				{
					if (instancia == null)
					{
						instancia = new MySqlConnection();
						instancia.ConnectionString = ConfigurationManager.ConnectionStrings["SqlSibecConnection"].ConnectionString;
					}
					return instancia;
				}
			}
		}

		public static void Open()
		{
			if (instancia != null)
				instancia.Open();
		}

		public static void Close()
		{
			if (instancia != null)
				instancia.Close();
		}


	}



}

