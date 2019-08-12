using System;

namespace Supermercado
{
	public class Persona
	{
		protected string Nombre;
		protected string Apellido;
		protected int Dni;
		public Persona(string Nombre,string Apellido,int Dni)
		{
			this.Nombre= Nombre;
			this.Apellido = Apellido;
			this.Dni = Dni;
		}
		public Persona()
		{}
		public override string ToString()
		{
			return (Nombre+" "+Apellido);
		}
		public bool Igual(Persona unaPersona)
		{
			return(ToString() == unaPersona.ToString());
		}
	}
//-------------------------2.1 OPCIONAGREGARCAJERO>>>>MODULOCAJA
	public class Cajero:Persona
	{
		private string[] HorarioTrabajo;
		private bool Libre = true;
		public Cajero(string Nombre,string Apellido,int Dni,string[]HoraTrabajo):base(Nombre,Apellido,Dni)
		{
			this.HorarioTrabajo = HoraTrabajo;
		}
		public Cajero():base()
		{
			this.Nombre="CERRADO";
		}
	
//-------------------------2.2 OPCIONABRIRCAJA>>>>MODULOCAJA
		
		
		public bool getLibre
		{
			get{
				return Libre;
			}
			set{
				Libre = value;
			}
		}
		
		public string Txt_LineaCajero(int numeracion)
		{
			return (numeracion+") "+ToString());
		}
//-------------------------2.4 OPCIONLISTADOCAJA>>>>MODULOCAJA
		public string Txt_LineaCaja(int numeracion)
		{
			return ("Caja "+numeracion+"\t"+ToString());
		}		

//-----------------------Cambiar Nombre para enlistado---------------
		
	}
	public class Cliente:Persona
	{
	private string[]FechaDeNacimiento;
	public Cliente():base(){}
	public Cliente(string Nombre,string Apellido,int Dni,string[]FechaDeNacimiento):base(Nombre,Apellido,Dni)
		{
			this.FechaDeNacimiento = FechaDeNacimiento;
		}
	public int getDni
		{
			get{
			return Dni;
			}
		}
	}
}
