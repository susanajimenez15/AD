using System;
using MySql.Data.MySqlClient;

namespace PDbPrueba
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//Console.WriteLine ("Probando acceso a dbprueba");
			//MySqlConnection mySqlConnection = new MySqlConnection("Database=dbprueba; User Id=root; Password=sistemas");

			//mySqlConnection.Open ();
			//operaciones

			//mySqlConnection.CreateCommand ();

			Console.WriteLine ("Selecciona una opcion: ");
			Console.WriteLine ("0. Salir " + "\n" + "1. Nuevo " + "\n" + "2. Editar " + "\n" + "3. Eliminar " + "\n" + "4. Listar todos " + "\n");

			switch (Console.Read ()) 
			{
			case '0':
				Console.Write ("Adios");
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

			//mySqlConnection.Close ();

		}
	}
}
