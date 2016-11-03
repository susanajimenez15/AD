using Gtk;
using System;
using System.Collections;
using System.Reflection;

namespace Org.InstitutoSerpis.Ad
{
	public class ComboBoxHelper
	{
		public static void Fill(ComboBox comboBox, IList list, string propertyName) {
			Type listType = list.GetType ();
			Type elementType = listType.GetGenericArguments () [0];
			PropertyInfo propertyInfo = elementType.GetProperty (propertyName);
			ListStore listStore = new ListStore (typeof(object));
			foreach (object item in list)
				listStore.AppendValues (item);
			comboBox.Model = listStore;
			CellRendererText cellRendererText = new CellRendererText ();
			comboBox.PackStart (cellRendererText, false);
			comboBox.SetCellDataFunc (cellRendererText, 
				delegate(CellLayout cell_layout, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
					object item = tree_model.GetValue(iter, 0);
					object value = propertyInfo.GetValue(item, null);
					cellRendererText.Text = value.ToString();
				}
			);
		}

		public static object GetId (ComboBox comboBox)
		{
			TreeIter treeIter;
			comboBox.GetActiveIter (out treeIter);
			object item = comboBox.Model.GetValue (treeIter, 0);
//			return item == Null.Value ? null : (object)(((Categoria)item).Id);
//			if (item == Null.Value)
//				return null;
//			Type elementType = item.GetType ();
////			PropertyInfo propertyInfo = elementType.GetProperty ("Id");
//			return propertyInfo.GetValue (item, null);
			return item == Null.Value ? null : item.GetType ().GetProperty ("Id").GetValue (item, null);
		}
	}
}

