using System;
using Gtk;
using MySql.Data.MySqlClient;

namespace PCategoria
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			App.Instance.MySqlConnection=new MySqlConnection (
				"Data Source=localhost;" +
				"Database=dbprueba;" +
				"User ID=root;" +
				"Password=sistemas");

			App.Instance.MySqlConnection.Open ();

			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
