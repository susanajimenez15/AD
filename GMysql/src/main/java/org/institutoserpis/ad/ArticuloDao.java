package org.institutoserpis.ad;

import java.awt.Menu;
import java.sql.*;
import java.util.Scanner;

public class ArticuloDao {
	
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
		
		
		preparedStatement.close();
		connection.close();
		System.out.println("FIN DE LA CONEXION");
		
		
		
	}


}
