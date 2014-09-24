using System;
using MySql.Data.MySqlClient;

namespace PHolaMySql
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//Conexión con su constructor y su cadena de conexión
			MySqlConnection mySqlConnection = new MySqlConnection (
				"Data Source=localhost;Database=dbprueba;User ID=root;Password=sistemas");
			//abrir la conexión
			mySqlConnection.Open ();
			/*//Para insertar en la bbdd
			 MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			mySqlCommand.CommandText=
				string.Format("Insert into categoria(nombre) values ('{0}')", 
				              DateTime.Now);
			//Si el dato lo introduce el usuario puede dar problemas de seguridad.

			//para ejecutar comandos sencillos como insert, nos devuelve un entero, que son las filas afectadas.
			mySqlCommand.ExecuteNonQuery();*/

			//para ejecutar comandos como select de varias filas y columnas, con create comand que nos devuelve un mysqlcommand
			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			mySqlCommand.CommandText = "select * from categoria";

			//mySqlCommand.ExecuteReader nos devuelve un mysqlsdatareader 
			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();


			Console.WriteLine ("FieldCount={0}",mySqlDataReader.FieldCount);
			//sustituye directamente {0} por lo que se indica tras la coma.
			Console.WriteLine ("FieldType={0}",mySqlDataReader.FieldCount);
			for (int index=0; index< mySqlDataReader.FieldCount; index ++)
				Console.WriteLine ("column {0}={1}", index, mySqlDataReader.GetName(index));

			// para acceder a cada fila hace falta Read() 
			while (mySqlDataReader.Read()) {
				//lo guarda en un object para evitar castings
				object id= mySqlDataReader ["id"];
				object nombre= mySqlDataReader ["nombre"];
				Console.WriteLine ("id={0} Nombre={1}", id, nombre);

			}
			//hay que cerrar los datareader, al terminar o para abrir otro pues no puede haber dos abiertos.
			mySqlDataReader.Close ();

			//cerramos la conexión
			mySqlConnection.Close ();
			new Menu();
		}
	}
}
