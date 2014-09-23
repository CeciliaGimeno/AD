using System;

namespace PHolaMySql
{
	public class Menu
	{
		public Menu ()
		{
			Console.WriteLine ("seleccione un opción:");
			Console.WriteLine ("_____________________");
			Console.WriteLine ("0.Salir");
			Console.WriteLine ("1.Nuevo");
			Console.WriteLine ("2.Modifificar");
			Console.WriteLine ("3.Eliminar");
			Console.WriteLine ("4.Ver");

			//int opcion=Console.ReadLine();

			switch(opcion) {
				case 0:
					Console.WriteLine("Hasta pronto!!");
					break;
				case 1:
					Console.WriteLine("The number is zero!");
					break;
				case 2:
					Console.WriteLine("The number is zero!");
					break;
				case 3:
					Console.WriteLine("The number is zero!");
					break;
				case 4:
					Console.WriteLine("The number is zero!");
					break;
			}

		}
	}
}

