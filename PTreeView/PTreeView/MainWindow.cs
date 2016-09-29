using System;
using Gtk;
using System.Data;
using MySql.Data.MySqlClient;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		treeview.AppendColumn ("id", new CellRendererText(), "text", 0);
		treeview.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		treeview.AppendColumn ("precio", new CellRendererText (), "text", 2);
			treeview.AppendColumn("categoria", new CellRendererText (), "text", 3);

		ListStore listStore = new ListStore (typeof(long), typeof(string), typeof(string), typeof(long));

		treeview.Model = listStore;

		IDbConnection connect = new MySqlConnection ("Database=dbprueba;user=root;password=sistemas");
		connect.Open ();

		fillListStore (listStore, connect);


	}

	protected void fillListStore (ListStore listStore, IDbConnection connect){
		listStore.Clear ();
		IDbCommand dbcommand = connect.CreateCommand ();
		dbcommand.CommandText = "select * from articulo order by id";
		IDataReader dataReader = dbcommand.ExecuteReader ();
		while (dataReader.Read()) {
			listStore.AppendValues (dataReader ["id"], dataReader ["nombre"],""+dataReader ["precio"], dataReader ["categoria"]);
		}
		dataReader.Close ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
