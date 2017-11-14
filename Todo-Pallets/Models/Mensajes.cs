using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Todo_Pallets.Models
{
	public class Mensajes
	{
		private int id;
		private String nombre;
		private String apellido;
		private String email;
		private String consulta;

		public Mensajes(int id, string nombre, string apellido, string email, string consulta)
		{
			this.id = id;
			this.nombre = nombre;
			this.apellido = apellido;
			this.email = email;
			this.consulta = consulta;
		}

		#region -gets-

		public int getID() { return id; }
		public String getNombre() {	return nombre; }
		public String getApellido() { return apellido; }
		public String getEmail() { return email; }
		public String getConsulta() {	return consulta; }

		#endregion

	}

	public static class Chequeo
	{ 
		public static string pagina { get; set; }
	}
}
