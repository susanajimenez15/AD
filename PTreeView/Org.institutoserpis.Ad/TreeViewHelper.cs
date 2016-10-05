using System;
using Gtk;

namespace PTreeView
{
	public class TreeViewHelper
	{
		public static void  AppendColumns (TreeView treeView ,string[] columnNames )
		{
		
			int index = 0;
			foreach (string columnName in columnNames) {
				int column = index++;
				treeView.AppendColumn(columnName, new CellRendererText (), 
             	delegate {
					TreeViewColumn tree_column, CellRenderer CellView, TreeModel tree_model, 
					CellRenderer CellRendererText = (CellRendererText)cell;
					object ValueType=tree_model.GetValue(iter,column);
					CellRendererText.TextTag = ValueType.ToString();
			      }
				)
			
			}
		
		}
	}
}

