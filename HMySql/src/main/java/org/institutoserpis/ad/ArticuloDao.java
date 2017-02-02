package org.institutoserpis.ad;

import javax.persistence.EntityManager;

import java.awt.geom.Arc2D;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;


public class ArticuloDao {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		EntityManagerFactory  entityManagerFactory = 
				Persistence.createEntityManagerFactory("org.institutoserpis.ad.hmysql");
			System.out.println("Phil mola");
		//TODO usar
			
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		// Empieza la transaction
		entityManager.getTransaction().begin();
		
		Categoria categoria = new Categoria();
		categoria.setNombre("Nueva "+ Calendar.getInstance().getTime());
		entityManager.persist(categoria);
		
		System.out.println("-------------  CATEGORIA -------------");
		List<Categoria> categorias = entityManager.createQuery("from Categoria", Categoria.class).getResultList();
		for( Categoria item : categorias){
			System.out.printf("%d %s\n", item.getId(),item.getNombre());
		}
		
		System.out.println("-------------  ARTICULO -------------");
		
		Articulo articulo = new Articulo();
		articulo.setNombre("Nuevo "+ Calendar.getInstance().getTime());
		
		
		//entityManager.persist(articulo);
		
		List<Articulo> articulos = entityManager.createQuery("from Articulo", Articulo.class).getResultList();
		for( Articulo item: articulos){
			System.out.printf("%d %s %d $d\n", item.getId(), item.getNombre(), item.getPrecio(), item.getId());
		}
		
		// Cerramos la transaction
		entityManager.getTransaction().commit();
		
		entityManager.close();
		
		entityManagerFactory.close();
	}

}
