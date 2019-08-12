using System.Collections;
using System;

namespace Supermercado
{
	public class Compra
	{
		private Cliente elCliente;//puedo verDni
		private int laCaja;//Según el caja elegida se guardara num
		private Cajero elCajero;//elCajero.Tostring() 
		private ArrayList ListaProducto = new ArrayList();
		private ArrayList ListaCantidad = new ArrayList();
		private float MontoTotal;//Total y dif ahorrando
		private float MontoAhorro;
		
		public Compra(ArrayList ListProducto,ArrayList ListCantidad,Cajero unCajero,int numCaja,Cliente unCliente)
		{
			this.ListaProducto = ListProducto;
			this.ListaCantidad = ListCantidad;
			this.elCajero = unCajero;
			this.laCaja =numCaja;
			this.elCliente = unCliente;
		}
		public void MontoCompra()//Algo para realizar una suma producto
		{
			ArrayList MontoTotal = new ArrayList();
			ArrayList MontoAhorro = new ArrayList();
			float montoParcial;
			float montoPAhorro;
			
			Producto unProducto;
			int unaCant;
			int nuevaCant;
			
			for(int i=0;i<ListaProducto.Count;++i)
				{
				unProducto = (Producto) ListaProducto[i];
				unaCant = (int) ListaCantidad[i];
				
				nuevaCant =cantTotal(unaCant,unProducto.getLleva,unProducto.getPaga);
				unaCant = unaCant- nuevaCant;
				montoParcial = (unProducto.getPrecio)*nuevaCant;
				montoPAhorro = (unProducto.getPrecio)*unaCant;
				MontoTotal.Add(montoParcial);
				MontoAhorro.Add(montoPAhorro);				
				}
			this.MontoTotal=sumarLista((MontoTotal.Count)-1,MontoTotal);
			this.MontoAhorro=sumarLista((MontoAhorro.Count)-1,MontoAhorro);
		}
		private float sumarLista(int num,ArrayList Lista)
		{
			if(Lista.Count==0)
				return 0;
			if(num==0)
				return (float)Lista[0];
			else
				return (float)Lista[num]+sumarLista(num-1,Lista);
		
		}
		private int cantTotal(int cant,int lleva,int paga)
		{
			if(cant>=lleva)
			{
				return(paga+ cantTotal(cant-lleva,lleva,paga));
			}
			else
				return cant;
		}
		public float getMontoTotal
		{
			get{
				return MontoTotal;
			}
		}
		public float getMontoAhorro
		{
			get{
				return MontoAhorro;
			}
		}
		public int getlaCaja
		{
			get{
				return laCaja;
			}
		}
		public Cliente getCliente
		{
			get{
			return elCliente;
			}
		}
		public Cajero getCajero
		{
			get{
			return elCajero;
			}
		}
	}
}
