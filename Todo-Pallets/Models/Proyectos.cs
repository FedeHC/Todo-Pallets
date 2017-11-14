using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Todo_Pallets.Models
{
	public class Proyectos
	{
		private String nombreProyecto;
		private String autor;
		private String fecha;
		private String descripcionProyecto;
		private int visitas;
		private float puntaje;

		public Proyectos(string nombreProyecto, string autor, string fecha, string descripcionProyecto, int visitas, float puntaje)
		{
			this.nombreProyecto = nombreProyecto;
			this.autor = autor;
			this.fecha = fecha;
			this.descripcionProyecto = descripcionProyecto;
			this.visitas = visitas;
			this.puntaje = puntaje;
		}

		#region -gets-

		public String getNombreProyecto()	{	return nombreProyecto; }
		public String getAutor() { return autor; }
		public String getFecha() { return fecha; }
		public String getDescripcionProyecto() { return descripcionProyecto; }
		public int getVisitas()	{	return visitas;	}
		public float getPuntaje()	{	return puntaje;	}

		#endregion
	}
}