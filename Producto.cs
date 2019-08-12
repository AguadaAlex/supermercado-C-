
using System;

namespace Supermercado
{

	public class Producto
	{
		private string TipoProducto;
		private string Envase;
		private string Marca;
		private float Precio;
		private int [] Promocion = new int [] {1,1};
		
//-------------------------1.1 OPCIONAGREGARPRODUCTO>>>>MODULOPRODUCTO		
		public Producto(string TipoProducto,string Envase, string Marca, float Precio)
		{	
			this.TipoProducto = TipoProducto;
			this.Envase = Envase;
			this.Marca = Marca;
			this.Precio = Precio;
		}
//-------------------------1.2 OPCIONAGREGARPROMOCION>>>MODULOPRODUCTO
		public void OpcionAgregarPromocion(int lleva,int paga)
		{
			this.Promocion[0]=lleva;
			this.Promocion[1]=paga;
		}
			
//-------------------------1.3 OPCIONLISTADOPRODUCTO>>>>MODULOPRODUCTO
		public string Txt_LineaProducto(int numeracion)
		{
			string PreImpresion;
			int Longitud;
			
			PreImpresion = numeracion+") "+ToString();
			Longitud = PreImpresion.Length;
			Longitud = ((80-Longitud)/8)-1;		//Cantidad de tabs a usar
			
			return (PreImpresion+tab(Longitud)+"$"+Precio);
		}
//-------------------------1.4 OPCIONLISTADOPROMOCION>>>>MODULOPRODUCTO
		public string Txt_LineaPromocion(int numeracion)
		{
			string PreImpresion;
			int Longitud;
			
			PreImpresion = numeracion+") "+ ToString() +" ==> "+Promocion[0]+"x"+Promocion[1];
			Longitud = PreImpresion.Length;
			Longitud = ((80-Longitud)/8)-1;		//Cantidad de tabs a usar
			
			return (PreImpresion+tab(Longitud)+"$"+Precio);	
		}
//-----------------------Cambiar Nombre para enlistado---------------
		public override string ToString()
		{
			return (TipoProducto+" "+Marca+"<"+Envase+">");
		}


//-----------------------------------Comienzo------------------------Ayuda para Txt_ModuloProducto
		private string tab(int n)
		{
			if (n== 1)
				return "\t";
			else
				return "\t"+ tab(n-1);
		}
		public float getPrecio
		{
			get{
			return this.Precio;
			}
		}
		public int getLleva
		{
			get{
				return this.Promocion[0];
			}
		}
		public int getPaga
		{
			get{
				return this.Promocion[1];
			}
		}
		

	}
}
