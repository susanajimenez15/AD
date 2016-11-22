using Gtk;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;

using PArticulo;
using Org.InstitutoSerpis.Ad;


public partial class MainWindow: Gtk.Window
{	
	private IEntityDao<Articulo> entityDao;

	//base: llama al antecesor de MainWindow
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		App.Instance.DbConnection = new MySqlConnection (
			"Database=dbprueba;User Id=root;Password=sistemas"
			);
		App.Instance.DbConnection.Open ();

//		Porque no nos permite dejar el precio en blanco, hemos ejecutado esta sentencia SQL para que se pongan a 0 los null
//		IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
//		dbCommand.CommandText = "update articulo set precio = 0 where precio is null";
//		dbCommand.ExecuteNonQuery ();

		fill ();

		//Devuelve la seleccion en el TreeView
		treeView.Selection.Changed += delegate {
			bool selected = treeView.Selection.CountSelectedRows () > 0;
			editAction.Sensitive = selected;
			deleteAction.Sensitive = selected;
		
		};


		newAction.Activated += delegate {
			Articulo articulo = new Articulo();
			articulo.Nombre = string.Empty; //los entry esperan que no sea null
			articulo.Precio = 0; //Hasta que se permita null

			new ArticuloView(articulo);
		};

		editAction.Activated += delegate {
			Articulo articulo = entityDao.Load((long)TreeViewHelper.GetId(treeView));
			new ArticuloView(articulo);
		};

		
		deleteAction.Activated += delegate {
			if (WindowHelper.Confirm(this, "¿Quieres eliminarrrrrr el registro?"))
				ArticuloDao.Delete(TreeViewHelper.GetId(treeView));


		};

		refresh.Activated += delegate {
			fill ();

		};


	}

	public IEntityDao<Articulo> EntityDao {
		set { entityDao = value; }
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		App.Instance.DbConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}

	private void fill() {
		editAction.Sensitive = false;
		deleteAction.Sensitive = false;
		IList list = EntityDao.GetList<Articulo> ();
		TreeViewHelper.Fill (treeView, list);
	}

}
