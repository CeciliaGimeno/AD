using System;
using MySql.Data.MySqlClient;

namespace PHolaMySql
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			MySqlConnection mySqlConnection = new MySqlConnection (
				"Data Source=localhost;Database=dbprueba;User ID=root;Password=sistemas");
			mySqlConnection.Open ();
			Console.WriteLine ("Hello World!");
			/*MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			mySqlCommand.CommandText=
				string.Format("Insert into categoria(nombre) values ('{0}')", 
				              DateTime.Now);
			//Si el dato lo introduce el usuario puede dar problemas de seguridad.

			//para ejecutar comandos sencillos, nos devuelve un entero, que son las filas afectadas.
			mySqlCommand.ExecuteNonQuery();*/

			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			mySqlCommand.CommandText = "select * from categoria";
			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();

			Console.WriteLine ("FieldCount={0}",mySqlDataReader.FieldCount);
			//sustituye directamente {0} por lo que se indica tras la coma.
			Console.WriteLine ("FieldType={0}",mySqlDataReader.FieldCount);
			for (int index=0; index< mySqlDataReader.FieldCount; index ++)
				Console.WriteLine ("column {0}={1}", index, mySqlDataReader.GetName(index));

			mySqlConnection.Close ();


		}
	}
}
