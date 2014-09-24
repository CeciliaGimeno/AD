using System;
using Gtk;

namespace PHolaGtk
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//poner en marcha una aplicacion gtk
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
