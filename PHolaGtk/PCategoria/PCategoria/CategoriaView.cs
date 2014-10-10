using System;
using MySql.Data.MySqlClient;

namespace PCategoria
{
	public partial class CategoriaView : Gtk.Window
	{
		public CategoriaView () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();

		}
		private object id;
		public CategoriaView(object id) :this(){
			this.id= id;
			MySqlCommand mySqlCommand = App.Instance.MySqlConnection.CreateCommand();
			mySqlCommand.CommandText = String.Format (
				"select * from categoria where id={0}", id);

			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();
			mySqlDataReader.Read ();

			entryNombre.Text= mySqlDataReader ["nombre"].ToString ();

			mySqlDataReader.Close ();
		}	


		protected void OnSaveActionActivated (object sender, EventArgs e)
		{
			MySqlCommand mySqlCommand = App.Instance.MySqlConnection.CreateCommand ();
			//parametros para formateo 
			mySqlCommand.CommandText= String.Format(
				"update categoria set nombre=@nombre where id={0}", id
				);

			MySqlParameter mySqlParameter = mySqlCommand.CreateParameter ();
			mySqlParameter.ParameterName= "nombre";
			mySqlParameter.Value = entryNombre.Text;
			mySqlCommand.Parameters.Add (mySqlParameter);

			mySqlCommand.ExecuteNonQuery ();
			Destroy ();
		}

	}
}

