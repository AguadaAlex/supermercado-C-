
using System;

namespace Supermercado
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			BaseDeDato SuperMercado = new BaseDeDato("Trabajo Final");
			bool menu;
			string opcion;
			do
			{
				//MENU PRINCIPAL
				Txt_MenuPrincipal();
				opcion= Console.ReadLine();
				menu= true;
				switch(opcion)
			{
				case "1"://MODULO PRODUCTO
						bool menu_producto;
						string opcion_producto;
						do
						{
						Txt_MenuProductos();
						opcion_producto = Console.ReadLine();
						menu_producto= true;
						switch(opcion_producto)
						{
							case "1":
								OpcionAgregarProducto(SuperMercado);
								Console.WriteLine("Presione una tecla para continuar.");
								Console.ReadKey(true);
								break;
							case "2":
								OpcionAgregarPromocion(SuperMercado);
								Console.WriteLine("Presione una tecla para continuar.");
								Console.ReadKey(true);
								break;
							case "3":
								OpcionListadoProducto(SuperMercado);
								Console.WriteLine("\nPresione una tecla para continuar.");
								Console.ReadKey(true);
								break;
							case "4":
								OpcionListadoPromocion(SuperMercado);
								Console.WriteLine("\nPresione una tecla para continuar.");
								Console.ReadKey(true);
								break;
							case "5":
								menu_producto =false;
								break;
							default:
								Console.WriteLine("La opción ingresada es invalida. Presion una tecla para continuar");
								Console.ReadKey(true);
								break;		
						}
						}
						while(menu_producto);
					break;
				case "2":
						bool menu_caja;
						string opcion_caja;
						do
						{
						Txt_MenuCaja();
						opcion_caja = Console.ReadLine();
						menu_caja= true;
						switch(opcion_caja)
						{
							case "1":
								OpcionAgregarCajero(SuperMercado);
								Console.WriteLine("Presione una tecla para continuar.");
								Console.ReadKey(true);
								break;
							case "2":
								OpcionAbrirCaja(SuperMercado);
								Console.WriteLine("Presione una tecla para continuar.");
								Console.ReadKey(true);
								break;
							case "3":
								OpcionCerrarCaja(SuperMercado);
								Console.WriteLine("Presione una tecla para continuar.");
								Console.ReadKey(true);
								break;
							case "4":
								OpcionListadoCaja(SuperMercado);
								Console.WriteLine("\nPresione una tecla para continuar.");
								Console.ReadKey(true);
								break;
							case "5":
								menu_caja = false;
								break;
							default:
								Console.WriteLine("La opción ingresada es invalida. Presion una tecla para continuar");
								Console.ReadKey(true);
								break;		
						}
						}
						while(menu_caja);
					break;
				case "3":
					OpcionMenuCliente(SuperMercado);
					Console.WriteLine("\nPresione una tecla para continuar.");
					Console.ReadKey(true);
					break;
				case "4":
					bool menu_admin;
						string opcion_admin;
						do
						{
						Txt_MenuAdministracion();
						opcion_admin = Console.ReadLine();
						menu_admin= true;
						switch(opcion_admin)
						{
							case "1":
								OpcionTotalRecaudado(SuperMercado);
								Console.WriteLine("Presione una tecla para continuar.");
								Console.ReadKey(true);
								break;
							case "2":
								OpcionTotalRecaudadoCaja(SuperMercado);
								Console.WriteLine("Presione una tecla para continuar.");
								Console.ReadKey(true);
								break;
							case "3":
								OpcionTotalRecaudadoCajero(SuperMercado);
								Console.WriteLine("Presione una tecla para continuar.");
								Console.ReadKey(true);
								break;
							case "4":
								OpcionTotalRecaudadoCliente(SuperMercado);
								Console.WriteLine("\nPresione una tecla para continuar.");
								Console.ReadKey(true);
								break;
							case "5":
								menu_admin = false;
								break;
							default:
								Console.WriteLine("La opción ingresada es invalida. Presion una tecla para continuar");
								Console.ReadKey(true);
								break;		
						}
						}
						while(menu_admin);
					break;
				case "5":
					menu = false;
					break;
				default:
					Console.WriteLine("La opción ingresada es invalida. Presion una tecla para continuar");
					Console.ReadKey(true);
					break;
			}
			}
			while(menu);
		}
//------------------------- Comienzo---------------------  Txt de varios Menu
		
		public static void Txt_MenuPrincipal()
		{
			Console.Clear();
			Rayado();
			Titulo("SUPERMERCADO");
			Rayado();
			
			Console.WriteLine("\n¿A qué módulo desea ingresar?\n");
			Console.WriteLine("1) Productos");
			Console.WriteLine("2) Cajas");
			Console.WriteLine("3) Cliente");
			Console.WriteLine("4) Administración");
			Console.WriteLine("5) Salir del sistema");
			                  	
		}
		
		public static void Txt_MenuProductos()
		{
			Txt_Modulo("Productos");
			
			Console.WriteLine("\n1) Nuevo producto");
			Console.WriteLine("2) Nueva promoción");
			Console.WriteLine("3) Listado de productos");
			Console.WriteLine("4) Listado de promociones");
			Console.WriteLine("5) Volver");
		}
		
		public static void Txt_MenuCaja()
		{
			Txt_Modulo("Cajas");
			
			Console.WriteLine("\nSección cajas y cajeros\n");
			Console.WriteLine("1) Nuevo cajero");
			Console.WriteLine("2) Abrir caja");
			Console.WriteLine("3) Cerrar cajas");
			Console.WriteLine("4) Listado de cajas");
			Console.WriteLine("5) Volver");
		}
		
		public static void Txt_MenuAdministracion()
		{
			Txt_Modulo("Administración");

			Console.WriteLine("\nSección Administración\n");
			Console.WriteLine("1) Total recaudado");
			Console.WriteLine("2) Total recaudado por caja");
			Console.WriteLine("3) Total recaudado por cajero");
			Console.WriteLine("4) Total recaudado por cliente");
			Console.WriteLine("5) Volver");
		}
//-----------------------------------Comienzo------------------------Ayuda para Txt_Menu	
		public static void Txt_SUPERMERCADO()
		{
			Console.Clear();
			Rayado();
			Titulo("SUPERMERCADO");
			Rayado();
		}
		public static void Txt_Modulo(string cadena)
		{
			Console.Clear();
			Rayado();
			Titulo("SUPERMERCADO");
			Titulo("Módulo "+cadena);
			Rayado();
		}
		public static void Titulo(string cadena)
		{
			string asterisco="********";
			int medida = (84-10-10)-(cadena.Length);//Resultado de operacion: digitos de espacios en blanco
			Console.Write(asterisco);
			int d=0;
			while(d<(medida+1))
			{
				if (d!=(medida/2))
					Console.Write(" ");
				else
					Console.Write(cadena);
				d++;
			}
			Console.Write(asterisco);
		}
		public static void Rayado()
		{
		string asterisco="********";
			for (int c=0;c <10;c++)
				Console.Write(asterisco);
		}
//------------------------------MODULOPRODUCTO------------------------------//		
		
//-------------------------1.1 OPCIONAGREGARPRODUCTO>>>>MODULOPRODUCTO
		public static void OpcionAgregarProducto(BaseDeDato BaseDato)
		{
			//Txt_OpcionAgregarProducto(){};
			BaseDato.OpcionAgregarProducto();
		}
//-------------------------1.2 OPCIONAGREGARPROMOCION>>>MODULOPRODUCTO
		public static void OpcionAgregarPromocion(BaseDeDato BaseDato)
		{
			Txt_Modulo("Productos");
			Console.WriteLine("\nListado de productos\n");
			BaseDato.OpcionAgregarPromocion();
		}
//-------------------------1.3 OPCIONLISTADOPRODUCTO>>>>MODULOPRODUCTO	
		public static void OpcionListadoProducto(BaseDeDato BaseDato)
		{
			Txt_Modulo("Productos");
			Console.WriteLine("\nListado de productos\n");
			BaseDato.OpcionListadoProducto();
		}
//-------------------------1.4 OPCIONLISTADOPROMOCION>>>>MODULOPRODUCTO
		public static void OpcionListadoPromocion(BaseDeDato BaseDato)
		{
			Txt_Modulo("Productos");
			Console.WriteLine("\nListado de promociones\n");
			BaseDato.OpcionListadoPromocion();
		}		
//------------------------------MODULOCAJA------------------------------//

//-------------------------2.1 OPCIONAGREGARCAJERO>>>>MODULOCAJA
		public static void OpcionAgregarCajero(BaseDeDato BaseDato)
		{
			//Txt_OpcionAgregarCajero(){};
			BaseDato.OpcionAgregarCajero();
		}
//-------------------------2.2 OPCIONABRIRCAJA>>>>MODULOCAJA
		public static void OpcionAbrirCaja(BaseDeDato BaseDato)
		{
			Txt_Modulo("Cajas");
			BaseDato.OpcionAbrirCaja();
		}
//-------------------------2.3 OPCIONCERRARCAJA>>>>MODULOCAJA
		public static void OpcionCerrarCaja(BaseDeDato BaseDato)
		{
			Txt_Modulo("Cajas");
			BaseDato.OpcionCerrarCaja();
		}
//-------------------------2.4 OPCIONLISTADOCAJA>>>>MODULOCAJA
		public static void OpcionListadoCaja(BaseDeDato BaseDato)
		{
			Txt_Modulo("Cajas");
			Console.WriteLine("\nListado de cajas\n");
			BaseDato.OpcionListadoCaja();
		}
//------------------------------MODULOCLIENTE------------------------------//
//-------------------------3.1 OPCIONMENUCLIENTE>>>>MODULOCLIENTE
		public static void OpcionMenuCliente(BaseDeDato BaseDato)	
		{
			try{
			if(IniciarCompra(BaseDato))
				throw new CajaSinCajeroException();
			}
			catch(CajaSinCajeroException){
				Console.WriteLine("No hay cajero libre en cajas, el módulo cliente no se encuentra disponible.");
				return;
			}
			bool preOpcion= true;
			do{
			Txt_PreLista(BaseDato);
			preOpcion = CargarLista(BaseDato);
			}while(preOpcion);
			
			preOpcion = true;
			do{
			Txt_PreCaja(BaseDato);
			preOpcion = CargarCaja(BaseDato);
			}while(preOpcion);
			Console.WriteLine("\nNueva Compra");
			
			bool opcionLogIn;
			do{	
			opcionLogIn = CargarCliente(BaseDato);
			}while(opcionLogIn);
			
			TerminarCompra(BaseDato);
		}
		public static void Txt_PreLista(BaseDeDato BaseDato)
		{
			Txt_Modulo("Cliente");
			Console.WriteLine("\nProductos disponibles\n");
			BaseDato.OpcionListadoProducto();
			Console.WriteLine("\n");
			Rayado();
			Console.WriteLine("\nProductos en el carro\n");
			BaseDato.ListadoPreLista();
			Console.WriteLine("\n");
			Rayado();
			Console.WriteLine("\nAgrege un producto al carro o 0 para finalizar");
		}
		public static bool CargarLista(BaseDeDato BaseDato)	
		{
			return BaseDato.CargarLista();
		}
		public static void Txt_PreCaja(BaseDeDato BaseDato)
		{
			Txt_SUPERMERCADO();
			Console.WriteLine("\nProductos en el carro\n");
			BaseDato.ListadoPreLista();
			Console.WriteLine("\n");
			Rayado();
			Console.WriteLine("\nCajas abiertas\n");
			BaseDato.ListadoPreCaja();
			Console.WriteLine("\n");
			Rayado();
			Console.WriteLine("\n¿Qué caja elige para pagar?\n");
		}
		public static bool IniciarCompra(BaseDeDato BaseDato)	
		{
			return BaseDato.IniciarCompra();
		}
		public static bool CargarCaja(BaseDeDato BaseDato)	
		{
			return BaseDato.CargarCaja();
		}
		public static bool CargarCliente(BaseDeDato BaseDato)	
		{
			return BaseDato.CargarCliente();
		}
		public static void Txt_PreCliente(BaseDeDato BaseDato)
		{
			Txt_SUPERMERCADO();
			Console.WriteLine("\nProductos en el carro\n");
			BaseDato.ListadoPreLista();
			Console.WriteLine("\n");
			Rayado();
			Console.WriteLine("\nCajas abiertas\n");
			BaseDato.ListadoPreCaja();
			Console.WriteLine("\n");
			Rayado();
			
		}
		public static void TerminarCompra(BaseDeDato BaseDato)
		{
			BaseDato.TerminarCompra();
		}
//------------------------------MODULOADMINISTRACION------------------------------//
//-------------------------4.1 OPCIONTOTALRECAUDADO>>>>MODULOCLIENTE
public static void OpcionTotalRecaudado(BaseDeDato BaseDato)
		{
	BaseDato.OpcionTotalRecaudado();
		}
//-------------------------4.2 OPCIONTOTALRECAUDADOCAJA>>>>MODULOCLIENTE
public static void OpcionTotalRecaudadoCaja(BaseDeDato BaseDato)
		{
	BaseDato.OpcionTotalRecaudadoCaja();
		}
//-------------------------4.3 OPCIONTOTALRECAUDADOCAJERO>>>>MODULOCLIENTE
public static void OpcionTotalRecaudadoCajero(BaseDeDato BaseDato)
		{
	BaseDato.OpcionTotalRecaudadoCajero();
		}
//-------------------------4.4 OPCIONTOTALRECAUDADOCLIENTE>>>>MODULOCLIENTE
public static void OpcionTotalRecaudadoCliente(BaseDeDato BaseDato)
		{
	BaseDato.OpcionTotalRecaudadoCliente();
		}

//***********************Fin de class Program*************************

	}
//-------------------------DATOVACIO:EXCEPCCION,CONDICION:EVALUAR
	public class DatoVacioException:Exception
	{
		public DatoVacioException()
		{
		}
	}
	public class HoraErroneaException:Exception
	{
		public int numero;
		public HoraErroneaException(int numero)
		{
			this.numero= numero;
		}
	}
	public class FechaErroneaException:Exception
	{
		public int numero;
		public string fuente;
		public FechaErroneaException(int num,string fuente)
		{
			this.fuente= fuente;
			this.numero = num;
		}
	}
	public class CajaNoDisponibleException:Exception
	{
		public string fuente;
		public int num;
		public CajaNoDisponibleException(string fuente, int num)
		{
			this.fuente= fuente;
			this.num = num;
		}
	}
	public class CajeroNoDisponibleException:Exception
	{
		public string fuente;
		public CajeroNoDisponibleException(string fuente)
		{
			this.fuente= fuente;
		}
	}
	public class CajaSinCajeroException:Exception
	{
		public CajaSinCajeroException()
		{}
	}
}