using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		treeview.AppendColumn ("id", new CellRendererText(), "text", 0);
		treeview.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		ListStore listStore = new ListStore (typeof(long), typeof(string));
		treeview.Model = listStore;
		listStore.AppendValues (1L, "categoria 1");


	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
