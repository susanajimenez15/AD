using Gtk;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using PArticulo;
using Org.InstitutoSerpis.Ad;


public partial class MainWindow: Gtk.Window
{	
	private IDbConnection dbConnection;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
//		Build ();
//		//dbConnection = new MySqlConnection ( "Database=dbprueba; User Id= root; Password=sistemas" );
//		App.Instance.DbConnection = new MySqlConnection {
//			"Database=dbprueba; User Id= root; Password=sistemas"
//		};
//		App.Instance.DbConnection.Open ();
		Build ();
		App.Instance.DbConnection = new MySqlConnection (
			"Database=dbprueba;User Id=root;Password=sistemas"
			);
		App.Instance.DbConnection.Open ();

		fill ();

		//Devuelve la seleccion en el TreeView
		treeView.Selection.Changed += delegate {
			bool selected = treeView.Selection.CountSelectedRows () > 0;
			editAction.Sensitive = selected;
			deleteAction.Sensitive = selected;
			//Console.WriteLine("Ha ocurrido el evento treeView.Selection.Changed selected={0}",selected);
		};


		newAction.Activated += delegate {
			new ArticuloView();
		};



		refresh.Activated += delegate {
			fill ();

		};

		new ArticuloView ();

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		dbConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}

	protected void fill()
	{

		List<Articulo> list = new List<Articulo> ();
		string selectSql = "select * from articulo";
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = selectSql;
		IDataReader dataReader = dbCommand.ExecuteReader ();
			while (dataReader.Read ()) {
				long id = (long)dataReader ["id"];
				string nombre = (string)dataReader ["nombre"];
				//Ponemos ? para un tipo de datos más abstrcto.
				decimal? precio = dataReader ["precio"] is DBNull ? null : (decimal?)dataReader ["precio"];
				long? categoria = dataReader["categoria"] is DBNull ? null : (long?)dataReader["categoria"];
				Articulo articulo = new Articulo(id, nombre, precio, categoria);
				list.Add (articulo);
			}

		dataReader.Close ();

		//Para dejar no clickable el boton de edit y delete
		editAction.Sensitive = false;
		deleteAction.Sensitive = false;

		TreeViewHelper.Fill (treeView, list);
	}

}
