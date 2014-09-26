using System;
using Gtk;
using MySql.Data.MySqlClient;

public partial class MainWindow: Gtk.Window
{
	private ListStore listStore;
	private MySqlConnection mySqlConnection;
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		//Añadir columnas tv.AppendColumn ("Demo", new CellRendererText (), "text", 0);
		treeView.AppendColumn ("Id", new CellRendererText (),"text",0 );
		treeView.AppendColumn ("Nombre", new CellRendererText (),"text",1 );
		listStore = new ListStore (typeof(string), typeof(string));
		treeView.Model= listStore; //en java seria treeView.setModel(listStrore)
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected void OnAddActionActivated (object sender, EventArgs e)
	{
		listStore.AppendValues ("1", "uno");
	}

}
