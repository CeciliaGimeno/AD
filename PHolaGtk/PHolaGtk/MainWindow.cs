using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

protected void OnButtonClicked (object sender, EventArgs e)
{
	//throw new NotImplementedException ();
	Console.WriteLine ("Has hecho click en Aceptar");
	labelSaludo.LabelProp = "Buenos días "+entry.Text;
	//labelSaludo.Text = "Buenos días "+entry.Text;
	//otra opcion con format para cadenas más complejas
	labelSaludo.LabelProp = string.Format("Hola {0}", entry.Text);
}

}