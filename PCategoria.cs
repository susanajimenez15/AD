using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace PDbPrueba
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("CONECTANDOOOOOOOOOOOOO");
			IDbConnection dbConnection = new MySqlConnection ("Database=dbprueba; User Id=root; Password=sistemas");

			dbConnection.Open ();
			//operaciones
			dbConnection.CreateCommand ();

			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = "insert into categoria (nombre) values (@nombre)";

			//Creamos el parametro a insertar, creamos la tabla categoria 4 e insertamos el parametro en la tabla
			//Más adelante crearemos un metodo para hacer eso más fluido
			IDbDataParameter dbDataParameter = dbCommand.CreateParameter ();
			dbDataParameter.ParameterName = "nombre";
			//TIENE QUE COINCIDIR EL VALOR CON EL PARAMETRO PARA QUE ENCUENTRE BIEN EL VALOR
			dbDataParameter.Value = "categoria 4";
			dbCommand.Parameters.Add (dbDataParameter);
			dbCommand.ExecuteNonQuery ();

			//mySqlConnection.CreateCommand ();
			/*
			do {
				Console.WriteLine ("Selecciona una opcion: ");
				Console.WriteLine ("0. Salir " + "\n" + "1. Nuevo " + "\n" + "2. Editar " + "\n" + "3. Eliminar " + "\n" + "4. Listar todos " + "\n");
			} while(Console.Read < 0 || Console.Read > 4);


			switch (Console.Read ()) {
			case '0':
				Console.Write ("Adios");
				conexion.Close ();
				Environment.Exit (0);
				break;
			case '1':
				Console.Write ("Nuevo");
				break;
			case '2':
				Console.Write ("Editar");
				break;
			case '3':
				Console.Write ("Eliminar");
				break;
			case '4':
				Console.Write ("Listar todos");
				break;
			}
*/
			dbConnection.Close ();

		}
	}
}
