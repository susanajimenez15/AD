using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace PDbPrueba
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			Boolean salir = false;

			Console.WriteLine ("CONECTANDOOOOOOOOOOOOO");
			IDbConnection dbConnection = new MySqlConnection ("Database=dbprueba; User Id=root; Password=sistemas");

			dbConnection.Open ();

			IDbCommand crearNuevo = dbConnection.CreateCommand ();
			IDataParameter dataparametername = crearNuevo.CreateParameter ();
			IDataParameter dataparameterid = crearNuevo.CreateParameter ();
			

			//operaciones
			/*
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
			*/
				Console.WriteLine ("Selecciona una opcion: ");
				Console.WriteLine ("0. Salir " + "\n" + "1. Nuevo " + "\n" + "2. Editar " + "\n" + "3. Eliminar " + "\n" + "4. Listar todos " + "\n");

				dbConnection.CreateCommand ();

			do {
				Console.WriteLine("Elige una opcion: ");
			switch (Console.Read ()) {
			case '0':
				Console.Write ("Adios");
					salir = true;
				Environment.Exit (0);
				break;
			case '1':
				Console.WriteLine ("Nuevo");

				
					crearNuevo.CommandText = "insert into categoria (nombre) values (@nombre)";

					//Creamos el parametro a insertar, creamos la tabla categoria 4 e insertamos el parametro en la tabla
					//Más adelante crearemos un metodo para hacer eso más fluido

					//TIENE QUE COINCIDIR EL VALOR CON EL PARAMETRO PARA QUE ENCUENTRE BIEN EL VALOR
					Console.WriteLine("Dime el nombre de la fila nueva: ");
					String filaNueva = Console.ReadLine();

					parametrosNombre("nombre", filaNueva,  crearNuevo, dataparametername);
					crearNuevo.ExecuteNonQuery ();
					Console.WriteLine("Nueva fila creada");
					//Console.WriteLine("inserte otra opcion");

				break;
			case '2':
				Console.Write ("Editar");

					IDbCommand editarID = dbConnection.CreateCommand();
					editarID.CommandText = "update categoria set nombre = @nombre where id = @id";

					IDbDataParameter parametroEditado = editarID.CreateParameter();
					parametroEditado.ParameterName = 
					Console.WriteLine("Elige el id de la fila que quieras editar");

					IDbDataParameter ;
					parametroEditado.ParameterName = "";
				break;
			case '3':
				Console.Write ("Eliminar");
				break;
			case '4':
				Console.WriteLine ("Listar todos");

					IDbCommand comandoListar = dbConnection.CreateCommand();
					comandoListar.CommandText = "select * from categoria";
					IDataReader dr = comandoListar.ExecuteReader();

					while (dr.Read()){
						Console.WriteLine(Convert.ToString(dr["id"]));
						Console.WriteLine(Convert.ToString(dr["nombre"]));
					}
					dr.Close();
				break;
			}
			} while(salir !=  true);
			dbConnection.Close ();

		}

		private static void parametrosNombre(String parametro, String valor, IDbCommand comand, IDbDataParameter dataparameternombre)
		{
			//Método para crear parametro para el Nombre, le decimos el nombre, el valor y lo añadimos.
			dataparameternombre.ParameterName = parametro;
			dataparameternombre.Value = valor;
			comand.Parameters.Add(dataparameternombre);

		}

		private static void parametrosId(String parametro, int valor, IDbCommand comand, IDbDataParameter dataparameterid)
		{
			//Método para crear parametro para el Id, le decimos el id, el valor y lo añadimos.
			dataparameterid.ParameterName = parametro;
			dataparameterid.Value = valor;
			comand.Parameters.Add (dataparameterid);
		}
	}
}
