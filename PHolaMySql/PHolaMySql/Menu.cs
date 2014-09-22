using System;
using MySql.Data.MySqlClient;

namespace PHolaMySql
{
	public class Menu
	{
		public Menu ()
		{
			int opcion, id;
			string nuevo;

			do {

				Console.WriteLine ("Seleccione un opción:");
				Console.WriteLine ("_____________________");
				Console.WriteLine ("0.Salir");
				Console.WriteLine ("1.Nuevo");
				Console.WriteLine ("2.Modifificar");
				Console.WriteLine ("3.Eliminar");
				Console.WriteLine ("4.Ver");

				opcion = int.Parse (Console.ReadLine ());
			} while(opcion!=0);

			switch(opcion) {
				case 0:
					Console.WriteLine("Hasta pronto!!");
					break;
				case 1:
					Console.WriteLine("Nuevo registro");
					Console.WriteLine("Introduce Nombre: ");
					nuevo=Console.ReadLine();

					break;
				case 2:
					Console.WriteLine("Modificar registro");
					Console.WriteLine("Introduce ID: ");
					id=int.Parse(Console.ReadLine());
					Console.WriteLine("Introduce Nombre: ");
					string nombre=Console.ReadLine();
					break;
				case 3:
					Console.WriteLine("Eliminar registro");
					Console.WriteLine("Introduce el ID: ");
					id=int.Parse(Console.ReadLine());
					break;
				case 4:
					Console.WriteLine("Listado registros:");
					break;
				default:
					Console.WriteLine("No has elegido ninguna opción correcta");
					break;

			}
		}
	}
}

