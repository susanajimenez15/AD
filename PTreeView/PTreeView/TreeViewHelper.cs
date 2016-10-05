using System;
using Gtk;
using Org.InstitutoSerpis.Ad;


namespace PTreeView
{
	public class TreeViewHelper
	{
		public static void  AppendColumns (TreeView treeView ,string[] columnsNames )
		{
		
			int index = 0;
			foreach (string columnName in columnsNames) {
				int column = index++;
				treeView.AppendColumn (columnName, new CellRendererText (), 
				                      delegate (TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
					int Column = Array.IndexOf (treeView.Columns, tree_column);
					CellRendererText cellRendererText = (CellRendererText)cell;
					object value = tree_model.GetValue (iter, 2);
					cellRendererText.Text = value.ToString ();
				}

				);
			
			}
		
		}
	}
}

