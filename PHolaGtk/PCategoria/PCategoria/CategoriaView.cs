using System;

namespace PCategoria
{
	public partial class CategoriaView : Gtk.Window
	{
		public CategoriaView () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();

		}

		public CategoriaView(object id) :this(){
			entryNombre.Text= "id: "+id;
		}	
	}
}

