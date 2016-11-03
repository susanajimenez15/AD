using Gtk;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace PArticulo
{
	public partial class ArticuloView : Gtk.Window
	{
		public ArticuloView () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			spinbuttonPrecio.Value = 0;
			saveAction.Sensitive = false;
			saveAction.Activated += delegate {
				Console.WriteLine("saveAction.Activated");
			};
			
			entryNombre.Changed += delegate {
				string value = entryNombre.Text.Trim();
				saveAction.Sensitive =  value != String.Empty;
			};

			List<Categoria> list = new List<Categoria> ();
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();

			list.Add (new Categoria (1L, "categoria 1"));
			list.Add (new Categoria (2L, "categoria 2"));
			list.Add (new Categoria (3L, "categoria 3"));

			ComboBoxHelper.Fill (comboBoxCategoria, list, "Nombre");

		}

	}



	public class Categoria {
		public Categoria (long id, string nombre){

			Id = id;
			Nombre = nombre;
		}
		public long Id { set; get; }
		public string Nombre { set; get; }
	}
}

