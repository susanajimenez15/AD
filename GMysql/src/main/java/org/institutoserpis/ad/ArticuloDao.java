package org.institutoserpis.ad;

import java.sql.*;

public class ArticuloDao {
	
	public static void main(String [] args) throws SQLException{

		//Si no indicamos la base de datos, se conectara al servidor solamente
		Connection connection = DriverManager.getConnection("jdbc:mysql://localhost/dbprueba", "root", "sistemas");
		
		Statement statement = connection.createStatement();
		ResultSet resultSet = statement.executeQuery("select * from articulo");
		
		//Para sacarlo con fromato
		//Sustituye %5d\ por el primer valor de la variable
		System.out.printf("%5s %30s %10s  %5s\n", "Id", "Nombre", "Precio", "Categoria");
		System.out.println();
		while(resultSet.next()) {
			System.out.printf("%5d  %30s %10s  %5s\n", resultSet.getObject("id"), resultSet.getObject("nombre"), resultSet.getObject("precio"), resultSet.getObject("categoria") );
			//System.out.printf(" nombre = %s\n", resultSet.getObject("nombre"));
		}
		
		statement.close();
		connection.close();
		System.out.println("FIN DE LA CONEXION");
		
		
		
	}
}
