using System;
using Gtk;
using MySql.Data.MySqlClient;

public partial class MainWindow: Gtk.Window
{
	private ListStore listStore;
	private MySqlConnection mySqlConnection;
	private MySqlCommand mySqlCommand;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		//Añadir columnas tv.AppendColumn ("Demo", new CellRendererText (), "text", 0);
		treeView.AppendColumn ("Id", new CellRendererText (),"text",0 );
		treeView.AppendColumn ("Nombre", new CellRendererText (),"text",1 );

		listStore = new ListStore (typeof(string), typeof(string));
		treeView.Model= listStore; //en java seria treeView.setModel(listStrore)
		LeerDatos ();



	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		mySqlConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}
	protected void OnAddActionActivated (object sender, EventArgs e)
	{
		MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
		mySqlCommand.CommandText= string.Format("Insert into categoria(nombre) values ('{0}')", DateTime.Now);
		//Si el dato lo introduce el usuario puede dar problemas de seguridad.

		//para ejecutar comandos sencillos como insert, nos devuelve un entero, que son las filas afectadas.
		mySqlCommand.ExecuteNonQuery();
		listStore.Clear ();
		LeerDatos ();


	}

	protected void OnRefreshActionActivated (object sender, EventArgs e)
	{
		listStore.Clear ();
		LeerDatos ();
	}
	protected void LeerDatos()
	{
		listStore.Clear ();
		mySqlConnection = new MySqlConnection (
			"Data Source=localhost;" +
			"Database=dbprueba;" +
			"User ID=root;" +
			"Password=sistemas");
		//abrir la conexión
			mySqlConnection.Open ();

		mySqlCommand = mySqlConnection.CreateCommand ();
		mySqlCommand.CommandText = "select * from categoria";
		MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();
		while (mySqlDataReader.Read()) {
			//lo guarda en un object para evitar castings
			object id= mySqlDataReader ["id"].ToString();
			object nombre= mySqlDataReader ["nombre"];
			listStore.AppendValues (id, nombre);
			//Console.WriteLine ("id={0} Nombre={1}", id, nombre);
		}
		mySqlDataReader.Close ();

	}


}
