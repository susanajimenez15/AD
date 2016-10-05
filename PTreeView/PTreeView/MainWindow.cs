using System;
using Gtk;
using System.Data;
using MySql.Data.MySqlClient;
using Org.InstitutoSerpis.Ad;


public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		string[] columnNames = {"id", "nombre", "precio"};
		TreeViewHelper.AppendColumns(treeView,columnNames);
		//treeview.AppendColumn ("id", new CellRendererText(), "text", 0);
		//treeview.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		/*treeview.AppendColumn ("precio", new CellRendererText (),
		                       delegate(TreeViewColumn tree_column, CellRenderer CellView, TreeModel tree_model,
		         CellRendererText CellRendererText=(CellRendererText)cell)
		 );


		//los delegados no se ejecutan hasta que alguien lo llame 
		treeview.AppendColumn("categoria", new CellRendererText (), "text", 3);

		//IMP: el typeof(decimal) no es reconocido por el treeview
		ListStore listStore = new ListStore (typeof(long), typeof(string), typeof(string), typeof(long));

		treeview.Model = listStore;

		listStore.AppendValues(1L, "categoria 1", 1)

		IDbConnection connect = new MySqlConnection ("Database=dbprueba;user=root;password=sistemas");
		connect.Open ();

		fillListStore (listStore, connect);

	 */
	}

	protected void fillListStore (ListStore listStore, IDbConnection connect)
	{
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

	protected void listar()
	{
	
	}
}
