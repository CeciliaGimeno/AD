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
			MySqlConnection mySqlConnection = new MySqlConnection ("Data Source=localhost;Database=dbprueba;User ID=root;Password=sistemas");
			//abrir la conexión

			try
			{
				mySqlConnection.Open ();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}

				do { 
					Console.WriteLine ("Seleccione un opción:");
					Console.WriteLine ("_____________________");
					Console.WriteLine ("0.Salir");
					Console.WriteLine ("1.Nuevo");
					Console.WriteLine ("2.Modifificar");
					Console.WriteLine ("3.Eliminar");
					Console.WriteLine ("4.Ver");
					opcion = int.Parse (Console.ReadLine ());

					switch (opcion) {
					case 0:
						System.Console.Clear ();
						Console.WriteLine ("Hasta pronto!!");
						break;
					case 1:
						System.Console.Clear ();
						Console.WriteLine ("Nuevo registro");
						Console.WriteLine ("Introduce nombre");
						nuevo = Console.ReadLine ();
						MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
						mySqlCommand.CommandText = string.Format ("Insert into categoria(nombre) values ('{0}')", nuevo);
							//mySqlCommand.ExecuteNonQuery();
						if (mySqlCommand.ExecuteNonQuery () != 0) {
							Console.WriteLine ("Se ha añadido " + nuevo + " a la base de datos");
						} else {
							Console.WriteLine ("No se ha podido insertar");
						}
						break;
					case 2:
						System.Console.Clear ();
						Console.WriteLine ("Modificar registro");
						Console.WriteLine ("Introduce id a modificar");
						id = int.Parse (Console.ReadLine());
						Console.WriteLine ("Introduce nuevo nombre");
						nombre = Console.ReadLine ();
						MySqlCommand mySqlCommand2 = mySqlConnection.CreateCommand ();
						mySqlCommand2.CommandText = "UPDATE categoria SET nombre='"+nombre+"' WHERE id="+id;
						if (mySqlCommand2.ExecuteNonQuery()!=0) {
						Console.WriteLine ("Se ha acualizado a " + nombre);
						} else {
						Console.WriteLine ("No se ha podido actualizar");
						}
						break;
					case 3:
						System.Console.Clear ();
						Console.WriteLine ("Eliminar registro");
						Console.WriteLine ("Introduce id");
						id = int.Parse (Console.ReadLine ());
						MySqlCommand mySqlCommand3 = mySqlConnection.CreateCommand ();
						mySqlCommand3.CommandText = "DELETE FROM categoria WHERE id="+id;
					//Console.WriteLine (mySqlCommand3.ExecuteNonQuery());
						if (mySqlCommand3.ExecuteNonQuery()!=0) {
							Console.WriteLine ("Se ha eliminado " + nombre);
						} else {
							Console.WriteLine ("No se ha podido eliminar.");
						}
						break;
					case 4:
						System.Console.Clear ();
						Console.WriteLine ("Ver registros");
						MySqlCommand mySqlCommand4 = mySqlConnection.CreateCommand ();
						mySqlCommand4.CommandText = "select * from categoria";
						MySqlDataReader mySqlDataReader = mySqlCommand4.ExecuteReader ();
						for (int index=0; index< mySqlDataReader.FieldCount; index ++)
							Console.WriteLine ("column {0}={1}", index, mySqlDataReader.GetName(index));
						while (mySqlDataReader.Read()) {
							//lo guarda en un object para evitar castings
							object ides= mySqlDataReader ["id"];
							object nombres= mySqlDataReader ["nombre"];
							Console.WriteLine ("id={0} Nombre={1}", ides, nombres);
						}
						mySqlDataReader.Close ();
						break;
					}
				} while (opcion!=0);
			mySqlConnection.Close ();
		}
	}
}

