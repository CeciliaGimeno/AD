using System;
using MySql.Data.MySqlClient;

namespace PHolaMySql
{
	public class Menu
	{
		int opcion,id;
		string nombre,nuevo;

		public Menu ()
		{
			do {
			//System.Console.Clear(); 
			Console.WriteLine ("Seleccione un opción:");
			Console.WriteLine ("_____________________");
			Console.WriteLine ("0.Salir");
			Console.WriteLine ("1.Nuevo");
			Console.WriteLine ("2.Modifificar");
			Console.WriteLine ("3.Eliminar");
			Console.WriteLine ("4.Ver");

			opcion=int.Parse(Console.ReadLine());

			switch(opcion) {
				case 0:
					Console.WriteLine("Hasta pronto!!");
					break;
				case 1:
					Console.WriteLine("Nuevo registro");
					Console.WriteLine("Introduce nombre");
					nuevo=Console.ReadLine();
					MySqlConnection mySqlConnection = new MySqlConnection ("Data Source=localhost;Database=dbprueba;User ID=root;Password=sistemas");
					//abrir la conexión
					mySqlConnection.Open ();
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
					mySqlCommand.CommandText= string.Format("Insert into categoria(nombre) values ('{0}')", nuevo);
					mySqlCommand.ExecuteNonQuery();
					mySqlConnection.Close ();
					break;
				case 2:
					Console.WriteLine("Modificar registro");
					Console.WriteLine("Introduce nombre");
					nombre=Console.ReadLine();
					Console.WriteLine("Introduce id");
					id=int.Parse(Console.ReadLine());
					break;
				case 3:
					Console.WriteLine("Eliminar registro");
					Console.WriteLine("Introduce id");
					id=int.Parse(Console.ReadLine());
					break;
				case 4:
					Console.WriteLine("Ver registros");
					break;
			}
			} while (opcion!=0);

		}
	}
}

