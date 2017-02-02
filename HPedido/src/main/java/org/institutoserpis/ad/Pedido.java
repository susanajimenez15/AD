package org.institutoserpis.ad;

import java.util.Date;
import java.util.List;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

@Entity
public class Pedido {

	public long id;
	public String name;
	public Cliente cliente;
	public List<PedidoLinea> pedidoLinea;
	private Date fecha;
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	public long getId() { return id; }
	public void setId(long id) { this.id = id; }
	
	public String getName(){ return name; }
	public void setName(String name) { this.name = name; }
	
	public Cliente getCliente(){ return cliente; }
	public void setCliente(Cliente cliente){ this.cliente = cliente; }
	
	public List<PedidoLinea> getPedidoLinea(){ return pedidoLinea; }
	public void addPedidoLinea(Pedido pedido){
		addPedidoLinea(pedido);
	}
	public void removePedidoLinea(Pedido pedido){
		removePedidoLinea(pedido);
	}
	
	public Date getFecha(){ return fecha; }
	public void setFecha(Date fecha){ this.fecha = fecha; }
	
}
