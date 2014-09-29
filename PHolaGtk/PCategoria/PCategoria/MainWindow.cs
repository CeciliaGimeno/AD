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
		mySqlConnection = new MySqlConnection (
			"Data Source=localhost;" +
			"Database=dbprueba;" +
			"User ID=root;" +
			"Password=sistemas");
		mySqlConnection.Open ();

		//Añadir columnas tv.AppendColumn ("Demo", new CellRendererText (), "text", 0);
		treeView.AppendColumn ("Id", new CellRendererText (),"text",0 );
		treeView.AppendColumn ("Nombre", new CellRendererText (),"text",1 );
		listStore = new ListStore (typeof(ulong), typeof(string));
		treeView.Model= listStore; //en java seria treeView.setModel(listStrore)
		LeerDatos ();
		string texto = "la";
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		mySqlConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}
	protected void OnAddActionActivated (object sender, EventArgs e)
	{
		mySqlCommand = mySqlConnection.CreateCommand ();
		//mySqlCommand.CommandText = string.Format("Insert into categoria(nombre) values ('{0}')", DateTime.Now);
		string insertSql = "Insert into categoria(nombre) values ('{0}')";
		insertSql = string.Format (insertSql, DateTime.Now);
		mySqlCommand.CommandText = insertSql;

		mySqlCommand.ExecuteNonQuery();
		LeerDatos ();
	}

	protected void OnRefreshActionActivated (object sender, EventArgs e)
	{
		//listStore.Clear ();
		LeerDatos ();
	}
	protected void LeerDatos()
	{
		listStore.Clear ();


		mySqlCommand = mySqlConnection.CreateCommand ();
		mySqlCommand.CommandText = "select * from categoria";
		MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();
		while (mySqlDataReader.Read()) {
			//object id= mySqlDataReader ["id"].ToString();
			object id= mySqlDataReader ["id"];
			//Console.WriteLine ("id.GetType()={0}", id.GetType ());//Ver de que tipo es un object
			object nombre= mySqlDataReader ["nombre"];
			listStore.AppendValues (id, nombre);
		}
		mySqlDataReader.Close ();
	}
	private void fillListStore(){

	}
}
