package org.institutoserpis.ad;


import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

import org.hibernate.tuple.entity.EntityTuplizer;

public class Hibernate {

	public static void main (String [] args) {
			
		EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("org.institutoserpis.ad");
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		
		// Para añadir la fecha en formato Date en la BD
		java.util.Date date = new java.util.Date();
		java.sql.Date fecha = new java.sql.Date(date.getTime());
		
		// Creamos un cliente
		Cliente susana = new Cliente();
		susana.setName("Susana");
		entityManager.persist(susana);
		
		entityManager.getTransaction().commit();
		entityManager.close();
		
		entityManagerFactory.close();
		
//		
//		// Creamos un pedido
//		Pedido pedido = new Pedido();
//		pedido.setCliente(susana);
//		pedido.setFecha(fecha);
//		pedido.setName("Pedido 1");
//		entityManager.persist(pedido);
//		
//		// Creamos pedidoLinea
//		

	
	
	}
	
}
