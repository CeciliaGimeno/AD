using System;
using Gtk;
using MySql.Data.MySqlClient;

using PCategoria;

public partial class MainWindow: Gtk.Window
{
	private ListStore listStore;
	private MySqlConnection mySqlConnection;
	private MySqlCommand mySqlCommand; 
		

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		deleteAction.Sensitive =false;
		editAction.Sensitive = false;

		mySqlConnection = App.Instance.MySqlConnection;//parecido a una variable global

		//Añadir columnas tv.AppendColumn ("Demo", new CellRendererText (), "text", 0);
		treeView.AppendColumn ("Id", new CellRendererText (),"text",0 );
		treeView.AppendColumn ("Nombre", new CellRendererText (),"text",1 );
		listStore = new ListStore (typeof(ulong), typeof(string));
		treeView.Model= listStore; //en java seria treeView.setModel(listStrore)
		LeerDatos ();

		//solo se ejecutará cuando ocurra este método.
		treeView.Selection.Changed += selectionChanged;//+= delegate() seria otra forma de escribir lo mismo
	}

	private void selectionChanged(object sender, EventArgs e){
		Console.WriteLine("selectionChanged");
		bool hasSelected= treeView.Selection.CountSelectedRows () > 0;
		deleteAction.Sensitive = hasSelected;
		editAction.Sensitive = hasSelected;
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
		listStore.Clear ();
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
	

	protected void OnDeleteActionActivated (object sender, EventArgs e)
	{
		//confirmar la eliminación con una ventana
		MessageDialog messageDialog = new MessageDialog (
			this,
			DialogFlags.Modal,
			MessageType.Question,
			ButtonsType.YesNo,
			"¿Quieres eliminar el registro?"
			);
		messageDialog.Title = Title;
		ResponseType response= (ResponseType)messageDialog.Run();
		messageDialog.Destroy();

		if (response != ResponseType.Yes)
			return;

		TreeIter treeIter;
		treeView.Selection.GetSelected (out treeIter);//out para devolver un valor

		object id = listStore.GetValue (treeIter, 0);
		string deleteSql = string.Format ("delete from categoria where id={0}", id);

		mySqlCommand = mySqlConnection.CreateCommand ();
		mySqlCommand.CommandText =  deleteSql;
		mySqlCommand.ExecuteNonQuery();
	}

	protected void OnEditActionActivated (object sender, EventArgs e)
	{
		TreeIter treeIter;
		treeView.Selection.GetSelected (out treeIter);//out para devolver un valor

		object id = listStore.GetValue (treeIter, 0);

		CategoriaView categoriaView = new CategoriaView(id);
	}

}
