package org.institutoserpis.ad;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

@Entity
public class Cliente {
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	public long id;
	
	public String name; 
	
	public long getId(){ return id; }
	public void setId(long id){ this.id = id; }
	
	public String getName(){ return name; }
	public void setName(String name){ this.name = name; }

}
