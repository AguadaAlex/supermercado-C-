using System.Collections;
using System;

namespace Supermercado
{
	public class BaseDeDato
	{
		private string Nombre;
		private ArrayList ListaProd= new ArrayList();
		private ArrayList ListaProm= new ArrayList();
		private ArrayList ListaCajero = new ArrayList();
		private Cajero [] ListaCaja = new Cajero[5];
		
		private ArrayList ListaCompra = new ArrayList();
		private ArrayList ListaMonto = new ArrayList();
		private ArrayList ListaCliente = new ArrayList();
		
		private ArrayList ProductoCompra = new ArrayList();
		private ArrayList CantidadCompra = new ArrayList();
		private Cajero CajaCompra;
		private int numCajaCompra;
		private Cliente ClienteCompra;
		

		
		public BaseDeDato(string Nombre)
		{
			this.Nombre= Nombre;
			for(int i=0;i<5;i++)
			{
				Cajero estadoCaja=new Cajero();
				ListaCaja[i] = estadoCaja;
			}
		}

//------------------------------MODULOPRODUCTO------------------------------//		
		
//-------------------------1.1 OPCIONAGREGARPRODUCTO>>>>MODULOPRODUCTO
		public void OpcionAgregarProducto()
		{
			Console.WriteLine("Ingrese el tipo de producto");
			string dato1= Console.ReadLine();
			Console.WriteLine("Ingrese la marca");
			string dato2 = Console.ReadLine();
			Console.WriteLine("Ingrese el envase");
			string dato3 = Console.ReadLine();
			Console.WriteLine("Ingrese el precio(PESOS,CENTAVOS)");
			string dato4 = Console.ReadLine();
		try{
			evaluarString(dato1);
			evaluarString(dato2);
			evaluarString(dato3);
			float num4 = float.Parse(dato4);
				
			Producto unProducto = new Producto(dato1,dato2,dato3,num4);
			enlistarObjeto(unProducto,ListaProd);
			Console.WriteLine("\nEl producto fue dado de alta correctamente");
			}
			catch(DatoVacioException)
			{
				Console.WriteLine("\nHay un error en los datos ingresados, el producto no fue dado de alta.");
			}
			catch(FormatException)
			{
				Console.WriteLine("\nHay un error en los datos ingresados, el producto no fue dado de alta.");
			}
			
		}
//-------------------------1.2 OPCIONAGREGARPROMOCION>>>MODULOPRODUCTO
		public void OpcionAgregarPromocion()
		{
		OpcionListadoProducto();
		Console.WriteLine("\nSeleccione el producto para la promoción");
		string dato1 = Console.ReadLine();
		Console.WriteLine("Llevando:");
		string dato2 = Console.ReadLine();
		Console.WriteLine("Pagar:");
		string dato3 = Console.ReadLine();
		
		try{
			int num1 = int.Parse(dato1);
			int num2 = int.Parse(dato2);
			int num3 = int.Parse(dato3);
			
			num1--;
			Producto unProducto = (Producto) ListaProd[num1];
			unProducto.OpcionAgregarPromocion(num2,num3);
			ListaProd[num1] = unProducto;
			enlistarObjeto(unProducto,ListaProm);
			Console.WriteLine("\nLa promoción fue dada de alta correctamente.");
		}
	catch(FormatException)
			{
				Console.WriteLine("\nHay un error en los datos ingresados, la promoción no fue dado de alta.");
			}
	catch(ArgumentOutOfRangeException)
			{
				Console.WriteLine("\nHay un error en los datos ingresados, la promoción no fue dado de alta.");
			}
		}
//-----------------------METODOS COMPLEMENTARIOS/1.1/1.2---------------//
//-Reconocer la posición de Object en Lista --
		private int numLista(object elObjeto,ArrayList Lista)
		{
			int posicion = 0;
			foreach(object unObjeto in Lista)
			{
				if(unObjeto.ToString()== elObjeto.ToString())
					return posicion;
				posicion++;
			}
			return -1;
		}
//-Agrega nuevo Object a lista, si es nuevo reemplaza--
		private void enlistarObjeto(object elObjeto,ArrayList Lista)
		{
		int n = numLista(elObjeto,Lista);
			if (n== -1)
				Lista.Add(elObjeto);
			else
				Lista[n] = elObjeto;	
		}
//-------------------------1.3 OPCIONLISTADOPRODUCTO>>>>MODULOPRODUCTO
		public void OpcionListadoProducto()
		{
			int cont = 1;
			foreach (Producto unProducto in ListaProd)
			{
				Console.WriteLine(unProducto.Txt_LineaProducto(cont));
				cont++;
			}
		}
//-------------------------1.4 OPCIONLISTADOPROMOCION>>>>MODULOPRODUCTO
		public void OpcionListadoPromocion()
		{
			int cont = 1;
			foreach (Producto unProducto in ListaProm)
			{
				Console.WriteLine(unProducto.Txt_LineaPromocion(cont));
				cont++;
			}
		}
//------------------------------MODULOCAJA------------------------------//

//-------------------------2.1 OPCIONAGREGARCAJERO>>>>MODULOCAJA
		public void OpcionAgregarCajero()
		{
			Console.WriteLine("Ingrese el nombre");
			string dato1 = Console.ReadLine();
			Console.WriteLine("Ingrese el apellido");
			string dato2 = Console.ReadLine();
			Console.WriteLine("Ingrese el dni");
			string dato3 = Console.ReadLine();
			Console.WriteLine("Ingrese el horario de trabajo(XX-XX ej. 08-15)");
			string dato4 = Console.ReadLine();
				
		try{
			evaluarString(dato1);
			evaluarString(dato2);
			int num3 = int.Parse(dato3);
			string [] num4 = ObtenerHorario(dato4);
			
			Cajero unCajero = new Cajero(dato1,dato2,num3,num4);
			enlistarObjeto(unCajero,ListaCajero);
			Console.WriteLine("\nEl cajero fue dado de alta correctamente.");
			}
		catch(DatoVacioException)
			{
				Console.WriteLine("\nHay un error en los datos ingresados, el cajero no fue dado de alta.");
			}
			catch(HoraErroneaException)
			{
				Console.WriteLine("\nHay un error en los datos ingresados, el cajero no fue dado de alta.");
			}
			catch(FormatException)
			{
				Console.WriteLine("\nHay un error en los datos ingresados, el cajero no fue dado de alta.");
			}
			catch(IndexOutOfRangeException)
			{
				Console.WriteLine("\nHay un error en los datos ingresados, el cajero no fue dado de alta.");
			}
		}
//-A cadena horario, evalua y termina creando un arreglo Horario--
		private string[] ObtenerHorario(string Horario)
		{
			
			string [] HoraTrabajo = Horario.Split(new char[]{'-'});
			evaluarHora(int.Parse(HoraTrabajo[0]));
			evaluarHora(int.Parse(HoraTrabajo[1]));
			return HoraTrabajo;
		}
//-------------------------2.2 OPCIONABRIRCAJA>>>>MODULOCAJA
		public void OpcionAbrirCaja()
		{
			Console.WriteLine("\n¿Qué caja desea abrir [1-5]?");
			string dato1 = Console.ReadLine();
		try{
				int num1= int.Parse(dato1);
				num1--;
				Cajero unaCaja = (Cajero) ListaCaja[num1];
				evaluarCaja(unaCaja,true,num1);
				
				Console.WriteLine("\nSeleccione el cajero que va atender en la caja\n");
				Txt_ListaCajero();
				int num2 = int.Parse(Console.ReadLine());
				num2--;
				
				Cajero unCajero = (Cajero) ListaCajero[num2];
				evaluarCajero(unCajero,true);
				//FALTA REUTILIZAR EL CAJERO SALIENTE
				unCajero.getLibre=false;
				ListaCaja[num1] = unCajero;
				ListaCajero[num2] = unCajero;
				Console.WriteLine("La caja "+(num1+1)+" fue abierta");
				}
		catch(IndexOutOfRangeException)
			{
				Console.WriteLine("\nHay un error en los datos ingresados, la caja no fue dado de alta.");
			}
		catch(ArgumentOutOfRangeException)
			{
				Console.WriteLine("\nHay un error en los datos ingresados, la caja no fue dado de alta.");
			}
		catch(CajaNoDisponibleException f)
			{
				Console.WriteLine("\nLa caja "+(f.num+1)+" ya está siendo atendida por "+f.fuente);
			}
		catch(CajeroNoDisponibleException g)
			{
				Console.WriteLine("\n"+g.fuente+" ya está trabajando en otra caja");
			}
		catch(FormatException)
			{
				Console.WriteLine("\nHay un error en los datos ingresados, la caja no fue dado de alta.");
			}
		}
//-------------------------2.3 OPCIONCERRARCAJA>>>>MODULOCAJA
		public void OpcionCerrarCaja()//
		{
			Console.WriteLine("\n¿Qué caja desea cerrar [1-5]?");//
			string dato1 = Console.ReadLine();
		try{
				int num1= int.Parse(dato1);
				num1--;
				Cajero unaCaja = (Cajero) ListaCaja[num1];//
				evaluarCaja(unaCaja,false,num1);
				int num2 = numLista(unaCaja,ListaCajero);
				unaCaja.getLibre=true;
				
				ListaCaja[num1] = new Cajero();
				ListaCajero[num2] = unaCaja;
				Console.WriteLine("La caja "+(num1+1)+" fue cerrada");//
				}
		catch(IndexOutOfRangeException)
			{
				Console.WriteLine("\nHay un error en los datos ingresados, la caja no realizó cambios.");
			}
		catch(ArgumentOutOfRangeException)
			{
				Console.WriteLine("\nHay un error en los datos ingresados, la caja no realizó cambios.");
			}
		catch(CajaNoDisponibleException f)//
			{
				Console.WriteLine("\nLa caja "+(f.num+1)+" no esta abierta");
			}
		catch(FormatException)
			{
				Console.WriteLine("\nHay un error en los datos ingresados, la caja no realizó cambios.");
			}
		}
//-Imprime lista de cajero--
		private void Txt_ListaCajero()
		{
				int cont = 1;
				foreach(Cajero elCajero in ListaCajero)
					{
					Console.WriteLine(elCajero.Txt_LineaCajero(cont));
					cont++;
					}
		}
			
//-------------------------2.4 OPCIONLISTADOCAJA>>>>MODULOCAJA
	public void OpcionListadoCaja()
	{
		int cont = 1;
		foreach (Cajero unCajero in ListaCaja)
			{
			Console.WriteLine(unCajero.Txt_LineaCaja(cont));
			cont++;		
			}
	}
//------------------------------MODULOCLIENTE------------------------------//

//-------------------------3.0 OPCIONMENUCLIENTE>>>>MODULOCLIENTE
//---------------------3.1 LISTADECOMPRA>>>>OPCIONMENUCLIENTE
	public bool IniciarCompra()
	{
		ProductoCompra.Clear();
		CantidadCompra.Clear();
		foreach(Cajero elCajero in ListaCaja)
		{
			if(elCajero.getLibre==false)
				return false;
		}
		return true;
	}
	public void ListadoPreLista()
	{
		for(int num=0;num<ProductoCompra.Count;++num)
		{
			Console.WriteLine(ProductoCompra[num]+" ("+CantidadCompra[num]+" unidades)");
		}
	}
//---------------------3.1 LISTADECOMPRA>>>>OPCIONMENUCLIENTE
	public bool CargarLista()
	{
	try{
		int num1 = int.Parse(Console.ReadLine());
		if(num1==0)
			return false;
		num1--;
		Console.WriteLine("¿Cuántas Unidades agrega?");
		int num2 = int.Parse(Console.ReadLine());
		Producto unProducto = (Producto) ListaProd[num1];
		
		enlistarObjeto(unProducto,ProductoCompra);	//1.Requisito de Compra>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>REVISAR
		int num3 = numLista(unProducto,ProductoCompra);
		if(num3==CantidadCompra.Count)
			CantidadCompra.Add(num2);
		else
		{
			int num4 = (int)CantidadCompra[num3];
			num4 = num4 + num2;
			CantidadCompra[num3]=num4;//2.Requisito de Compra>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		}
		}
		catch(IndexOutOfRangeException)
			{
				Console.WriteLine("\nHay un error en los datos ingresados, la lista de compra no realizó cambios.");
			}
		catch(ArgumentOutOfRangeException)
			{
				Console.WriteLine("\nHay un error en los datos ingresados, la lista de compra no realizó cambios.");
			}
		catch(FormatException)
			{
				Console.WriteLine("\nHay un error en los datos ingresados, la lista de compra no realizó cambios.");
			}
		Console.ReadKey(true);
		return true;
	}
	public void ListadoPreCaja()
	{
		int cont = 1;
		foreach (Cajero unCajero in ListaCaja)
			{
			if(!unCajero.getLibre)
				Console.WriteLine(unCajero.Txt_LineaCaja(cont));
			cont++;		
			}
	}
//---------------------3.2 SELECCIONDECAJA>>>>OPCIONMENUCLIENTE
	public bool CargarCaja()
	{
	try{
		int num1 = int.Parse(Console.ReadLine());
		num1--;
		Cajero PreCajaCompra = (Cajero) ListaCaja[num1];
		evaluarCaja(PreCajaCompra,false,num1);
		
		CajaCompra = PreCajaCompra;//	3.Requisito de Compra
		numCajaCompra = ++num1;	   //	4.Requisito de Compra
		return false;
		}
	catch(IndexOutOfRangeException)
			{
				Console.WriteLine("\nHay un error en el número ingresado, la caja no ha sido seleccionada.");
			}
		catch(ArgumentOutOfRangeException)
			{
				Console.WriteLine("\nHay un error en el número ingresado, la caja no ha sido seleccionada.");
			}
		catch(CajaNoDisponibleException f)
			{
				Console.WriteLine("\nLa caja "+(f.num+1)+" no esta abierta");
			}
		catch(FormatException)
			{
				Console.WriteLine("\nHay un error en el número ingresado, la caja no ha sido seleccionada.");
			}
		Console.ReadKey(true);
		return true;
	}
//---------------------3.3 >>>>OPCIONMENUCLIENTE
	public bool CargarCliente()
	{
		try{
		Console.WriteLine("Ingrese DNI del cliente");
		int num1 = int.Parse(Console.ReadLine());
		Cliente preCliente = DNIBuscarCliente(num1);
		if(preCliente.ToString()==" ")
			return RegistrarCliente(num1);
		ClienteCompra= preCliente;//5.Requisito de Compra
		Console.WriteLine("\nCliente "+ClienteCompra.ToString());
		return false;
		}
		catch(FormatException)
		{
			Console.WriteLine("\nHay un error en el número ingresado, el DNI no ha sido registrado.");
		}
		return true;
	}
	private Cliente DNIBuscarCliente(int num1)
	{
		foreach(Cliente unCliente in ListaCliente)
			{if(unCliente.getDni==num1)
				return unCliente;
		}
		Cliente sinCliente = new Cliente();
		return sinCliente;
	}
		
	private bool RegistrarCliente(int dni)
	{
		Console.WriteLine("\nNuevo Cliente");
		Console.WriteLine("\nIngrese el nombre");
		string dato1 = Console.ReadLine();
		Console.WriteLine("\nIngrese el apellido");
		string dato2 = Console.ReadLine();
		Console.WriteLine("\nIngrese la fecha de nacimiento(DD-MM-AAAA ej. 21-12-1993)");
		string dato3 = Console.ReadLine();
		try{
		evaluarString(dato1);
		evaluarString(dato2);
		string [] num3 = ObtenerFecha(dato3);
		Cliente preCliente = new Cliente(dato1,dato2,dni,num3);
		ClienteCompra = preCliente;//5.Requisito de Compra
		ListaCliente.Add(ClienteCompra);
		return false;
		}
		catch(DatoVacioException)
			{
				Console.WriteLine("\nHay un error en los datos ingresados, el cliente no ha sido registrado.");
			}
		catch(FechaErroneaException e)
			{
				Console.WriteLine("\nHay un error en el "+e.fuente+" ingresado,el cliente no ha sido registrado.");
			}
		catch(FormatException)
			{
				Console.WriteLine("\nHay un error en los datos ingresados,el cliente no ha sido registrado.");
			}
		catch(IndexOutOfRangeException)
			{
				Console.WriteLine("\nHay un error en los datos ingresados,el cliente no ha sido registrado");
			}
		catch(ArgumentOutOfRangeException)
			{
				Console.WriteLine("\nHay un error en los datos ingresados,el cliente no ha sido registrado");
			}
		Console.ReadKey(true);
		return true;
	}
	private string[] ObtenerFecha(string Fecha)
		{
			string [] laFecha = Fecha.Split(new char[]{'-'});
			evaluarDia(int.Parse(laFecha[0]));
			evaluarMes(int.Parse(laFecha[1]));
			int.Parse(laFecha[2]);
			return laFecha;
		}
	public void TerminarCompra()
	{
		Compra laCompra= new Compra(ProductoCompra,CantidadCompra,CajaCompra,numCajaCompra,ClienteCompra);
		laCompra.MontoCompra();
		Console.WriteLine("\nTotal a pagar: "+laCompra.getMontoTotal);
		Console.WriteLine("Con su Compra ahorró: "+laCompra.getMontoAhorro);
		ListaCompra.Add(laCompra);
	}
//------------------------------MODULOADMINISTRACION------------------------------//
//-----------------------------------Comienzo------------------------Ayuda para Txt_Menu
	private float sumarLista(int num,ArrayList Lista)
		{
			if(Lista.Count==0)
				return 0;
			if(num==0)
				return (float)Lista[0];
			else
				return (float)Lista[num]+sumarLista(num-1,Lista);
		
		}
//-------------------------4.1 OPCIONTOTALRECAUDADO>>>>MODULOCLIENTE
	public void OpcionTotalRecaudado()
		{
		Console.WriteLine("Total recaudado en el supermercado: "+ TotalRecaudo());
		}
	private float TotalRecaudo()
		{
		ArrayList unaListaMonto= new ArrayList();
		foreach(Compra unaCompra in ListaCompra)
			{
			unaListaMonto.Add(unaCompra.getMontoTotal);
			}
		int num = (unaListaMonto.Count)-1;
		return sumarLista(num,unaListaMonto);
		}
//-------------------------4.2 OPCIONTOTALRECAUDADOCAJA>>>>MODULOCLIENTE
	public void OpcionTotalRecaudadoCaja()
		{
		Console.WriteLine("Total recaudado en el supermercado discriminado por caja:\n");
		ArrayList unaListaMontoCaja= new ArrayList();
		int num;
		for(int i=0;i<5;++i)
			{
			unaListaMontoCaja.Clear();
			foreach(Compra unaCompra in ListaCompra)
			{	
			num = unaCompra.getlaCaja;
			num--;
			if(i==num)
				unaListaMontoCaja.Add(unaCompra.getMontoTotal);
			}
			Console.WriteLine("Caja "+(i+1)+": "+sumarLista((unaListaMontoCaja.Count)-1,unaListaMontoCaja)+" pesos");
			}
		}
//-------------------------4.3 OPCIONTOTALRECAUDADOCAJERO>>>>MODULOCLIENTE
public void OpcionTotalRecaudadoCajero()
		{
	Console.WriteLine("Total recaudado en el supermercado discriminado por cajero:\n");
	ArrayList unaListaMontoCajero= new ArrayList();
	float num;
	foreach(Cajero unCajero in ListaCajero)
	{
		unaListaMontoCajero.Clear();
		foreach(Compra unaCompra in ListaCompra)
		{
			if(unCajero.Igual(unaCompra.getCajero))
				unaListaMontoCajero.Add(unaCompra.getMontoTotal);
		}
		if(unaListaMontoCajero.Count==0)
			continue;
		num = sumarLista((unaListaMontoCajero.Count)-1,unaListaMontoCajero);
		Console.WriteLine(unCajero.ToString()+": "+num+" pesos");
	}
		}
//-------------------------4.4 OPCIONTOTALRECAUDADOCLIENTE>>>>MODULOCLIENTE
public void OpcionTotalRecaudadoCliente()
		{
	Console.WriteLine("Total recaudado en el supermercado discriminado por cliente:\n");
	ArrayList unaListaMontoCliente= new ArrayList();
	float num;
	foreach(Cliente unCliente in ListaCliente)
	{
		unaListaMontoCliente.Clear();
		foreach(Compra unaCompra in ListaCompra)
		{
			if(unCliente.Igual(unaCompra.getCliente))
				unaListaMontoCliente.Add(unaCompra.getMontoTotal);
		}
		if(unaListaMontoCliente.Count==0)
			continue;
		num = sumarLista((unaListaMontoCliente.Count)-1,unaListaMontoCliente);
		Console.WriteLine(unCliente.ToString()+": "+num+" pesos");
	}
		}
//***********************Fin de class Program************************************************	
	private void evaluarCaja(Cajero laCaja,bool condicion,int num)
		{
		if(laCaja.getLibre!=condicion)
			throw new CajaNoDisponibleException(laCaja.ToString(),num);
		}
	private void evaluarString(string dato)
		{
			if (dato=="")
			throw new DatoVacioException();
		}
	private void evaluarHora(int hora)
		{
		if(hora<0 | 24<hora)
			throw new HoraErroneaException(hora);
		}
	private void evaluarDia(int dia)
		{
		if(dia<1 | 31<dia)
			throw new FechaErroneaException(dia,"día");
		}
	private void evaluarMes(int mes)
		{
		if(mes<1 | 12<mes)
			throw new FechaErroneaException(mes,"mes");
		}
	private void evaluarCajero(Cajero elCajero,bool condicion)
		{
		if(elCajero.getLibre !=condicion)
			throw new CajeroNoDisponibleException(elCajero.ToString());
		}
	}
}