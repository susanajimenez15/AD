using System;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using Gtk;

using Org.InstitutoSerpis.Ad;

namespace PArticulo
{

	public class ArticuloDao : IEntityDao<Articulo>
	{

		private const string SELECT_SQL = "select * from articulo";
		public static List<Articulo> GetList() {
			List<Articulo> list = new List<Articulo>();
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = SELECT_SQL;
			IDataReader dataReader = dbCommand.ExecuteReader ();
			while (dataReader.Read()) {

				long id = (long)dataReader ["id"];
				string nombre = (string)dataReader ["nombre"];
				decimal? precio = dataReader ["precio"] is DBNull ? null : (decimal?)dataReader ["precio"];
				long? categoria = dataReader["categoria"] is DBNull ? null : (long?)dataReader["categoria"];
				Articulo articulo = new Articulo((long)id, nombre, precio, categoria);
				list.Add (articulo);
			}
			dataReader.Close ();
			return list;
		}

		private const string SELECT_ID_SQL = "select * from articulo where id = @id";
		public Articulo Load(object id) {
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = SELECT_ID_SQL;
			DbCommandHelper.AddParameter (dbCommand, "id", id);
			IDataReader dataReader = dbCommand.ExecuteReader ();
			dataReader.Read ();
			//TODO if !Read -> lanzar exception
			string nombre = (string)dataReader ["nombre"];
			decimal? precio = dataReader ["precio"] is DBNull ? null : (decimal?)dataReader ["precio"];
			long? categoria = dataReader["categoria"] is DBNull ? null : (long?)dataReader["categoria"];
			Articulo articulo = new Articulo((long) id, nombre, precio, categoria);
			dataReader.Close ();
			return articulo;
		}




		public static void Save(Articulo articulo) {
			if (articulo.Id == 0) { //insert..
				insert (articulo);
			} else { // update 
				update (articulo);
			}
		}

		
		private const string INSERT_SQL = "insert into articulo (nombre, precio, categoria) " +
			"values (@nombre, @precio, @categoria)";
		private static void insert(Articulo articulo){
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = INSERT_SQL;
			DbCommandHelper.AddParameter (dbCommand, "nombre", articulo.Nombre);
			DbCommandHelper.AddParameter (dbCommand, "precio", articulo.Precio);
			DbCommandHelper.AddParameter (dbCommand, "categoria", articulo.Categoria);
			dbCommand.ExecuteNonQuery ();
		
		}
		private const string UPDATE_SQL = "update articulo set nombre = @nombre, " + "precio = @precio, categoria = @categoria where id = @id ";
		private static void update (Articulo articulo){
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = INSERT_SQL;
			DbCommandHelper.AddParameter (dbCommand, "nombre", articulo.Nombre);
			DbCommandHelper.AddParameter (dbCommand, "precio", articulo.Precio);
			DbCommandHelper.AddParameter (dbCommand, "categoria", articulo.Categoria);
			DbCommandHelper.AddParameter (dbCommand, "id", articulo.Id);
			dbCommand.ExecuteNonQuery ();

		}

		private const string DELETE_SQL= "delete from articulo where id = @id";
		public static void Delete(object id){
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = DELETE_SQL;
			DbCommandHelper.AddParameter(dbCommand, "id", id);
			dbCommand.ExecuteNonQuery();

		}
	}
}