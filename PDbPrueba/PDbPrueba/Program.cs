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

			Console.WriteLine ("Conectando con la base de datos");
			IDbConnection dbConnection = new MySqlConnection ("Database=dbprueba; User Id=root; Password=sistemas");

			dbConnection.Open ();

			String sid;
			int id;

			IDbCommand crearNuevo = dbConnection.CreateCommand ();
			IDataParameter dataparametername = crearNuevo.CreateParameter ();
			IDataParameter dataparameterid = crearNuevo.CreateParameter ();

			dbConnection.CreateCommand ();

			//Podemos crear un public enum OPTION (SALIR, BORRAR, EDITAR...) 



			do {
			
				Console.WriteLine ("\nSelecciona una opcion: \n");
				Console.WriteLine ("0. Salir " + "\n" + "1. Nuevo " + "\n" + "2. Editar " + "\n" + "3. Eliminar " + "\n" + "4. Listar todos " + "\n");
			
				switch (Console.Read ()) {
				case '0':
					
					Console.Write ("\nAdios");
						salir = true;
						Environment.Exit (0);
					break;

				case '1':
					
					Console.WriteLine ("\nNuevo");

					
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
					visualizar(crearNuevo);
						Console.Write ("Editar");

						IDbCommand editarID = dbConnection.CreateCommand();
						editarID.CommandText = "update categoria set nombre = @nombre where id = @id";

						Console.WriteLine("Elige el id de la fila que quieras editar");
						sid = Console.ReadLine();
						id = int.Parse(sid);
						
						Console.WriteLine("Elige el nombre de la fila que quieras editar");
						String nombreNuevo = Console.ReadLine();

					parametrosNombre("nombre", nombreNuevo, editarID, dataparametername);
					parametrosId("id", id, editarID, dataparameterid);

						editarID.ExecuteNonQuery();
						
						Console.WriteLine("Editado hecho ");
						
					break;

				case '3':
					
						Console.Write ("Eliminar");

						visualizar(crearNuevo);
						
						crearNuevo.CommandText = "delete from categoria where id = @id";

						Console.WriteLine("Dime el id de la fila que quieras eliminar:");
						sid = Console.ReadLine();
						id = int.Parse(sid);
						
						parametrosId("id", id, crearNuevo, dataparameterid);
						
						crearNuevo.ExecuteNonQuery();
						
						Console.WriteLine("Fila eliminada");
					
						break;

				case '4':
					
						Console.WriteLine ("Listar todos");
						
						visualizar(crearNuevo);
						
					
						break;
					}
				
			} while(salir !=  true);
			dbConnection.Close ();

		}

		private static void parametrosNombre(String parametro, String valor, IDbCommand comand, IDataParameter dataparameternombre)
		{
			//Método para crear parametro para el Nombre, le decimos el nombre, el valor y lo añadimos.
			dataparameternombre.ParameterName = parametro;
			dataparameternombre.Value = valor;
			comand.Parameters.Add(dataparameternombre);

		}

		private static void parametrosId(String parametro, int valor, IDbCommand comand, IDataParameter dataparameterid)
		{
			//Método para crear parametro para el Id, le decimos el id, el valor y lo añadimos.
			dataparameterid.ParameterName = parametro;
			dataparameterid.Value = valor;
			comand.Parameters.Add (dataparameterid);
		}

		private static void visualizar (IDbCommand comandoVisualizar)
		{

			comandoVisualizar.CommandText = "select * from categoria order by id";	
			IDataReader dr = comandoVisualizar.ExecuteReader();

			while (dr.Read()){
				Console.WriteLine(Convert.ToString(dr["id"]));
				Console.WriteLine(Convert.ToString(dr["nombre"]));
			}

			dr.Close();

		}
	}
}
