package org.SusiGuay.org;

import java.awt.Menu;
import java.sql.*;
import java.util.Scanner;

public class ArticuloDao {
	
	static Scanner scanner = new Scanner(System.in);
	
	public static void main(String [] args) throws SQLException{

		//RECUERDA: AÑADIR LINEA A build.gradle	PARA CONECTOR MYSQL
		
		//Si no indicamos la base de datos, se conectara al servidor solamente
		Connection connection = DriverManager.getConnection("jdbc:mysql://localhost/dbprueba", "root", "sistemas");
		
		
		PreparedStatement preparedStatement = connection.prepareStatement("select * from articulo where id > ?");
		preparedStatement.setObject(1, Long.parseLong(args[0]));
		ResultSet resultSet = preparedStatement.executeQuery();
		
		//Para conectarnos podemos usar el statement
//		Statement statement = connection.createStatement();
//		ResultSet resultSet = statement.executeQuery("select * from articulo");
		
		//Para sacarlo con fromato
		//Sustituye %5d\ por el primer valor de la variable
		System.out.printf("%5s %30s %10s  %5s\n", "Id", "Nombre", "Precio", "Categoria");
		System.out.println();
		while(resultSet.next()) {
			System.out.printf("%5d  %30s %10s  %5s\n", 
					resultSet.getObject("id"), 
					resultSet.getObject("nombre"), 
					resultSet.getObject("precio"), 
					resultSet.getObject("categoria") 
			);
			//System.out.printf(" nombre = %s\n", resultSet.getObject("nombre"));
		}
		int opc = 0;
		
		do{
			System.out.println("------------------ MENU ------------------");
			System.out.println("1. Nuevo articulo. ");
			System.out.println("2. Modificar articulo. ");
			System.out.println("3. Eliminar articulo. ");
			System.out.println("4. Consultar articulo.");
			System.out.println("5. Listar todos los articulos. ");
			System.out.println("0. Salir");
			System.out.println("------------------------------------------");
			System.out.println("Introduce un valor: ");
			opc = scanner.nextInt();
		
			switch (opc) {
				case 1:
					nuevo();
					
				case 2:
					
				case 3:
					
				case 4:
					
				case 5:
					
				case 0:
					System.out.println("Adios");
					
				
			}
		}while( opc == 0 );
		
		preparedStatement.close();
		connection.close();
		System.out.println("FIN DE LA CONEXION");
		
		
		
	}


	public static void nuevo() throws SQLException{
		
		
		System.out.println("Nuevo articulo: ");
		System.out.println("Nombre del articulo: ");
		String nombre = scanner.nextLine();
		System.out.println("Precio del articulo: ");
		double precio = scanner.nextDouble();
		System.out.println("Categoria del articulo (numero) : ");
		int categoria = scanner.nextInt();
		

		
		
		
	}

}
