using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Todo_Pallets.Models
{
	public class Productos
	{
		private String nombreProducto;
		private String fecha;
		private int precio;
		private String descripcionProducto;
		private int visitas;
		private float puntaje;
		
		public Productos(string nombreProducto, string fecha, int precio, string descripcionProducto, int visitas, float puntaje)
		{
			this.nombreProducto = nombreProducto;
			this.fecha = fecha;
			this.precio = precio;
			this.descripcionProducto = descripcionProducto;
			this.visitas = visitas;
			this.puntaje = puntaje;
		}

		#region -gets-

		public String getNombreProducto() { return nombreProducto; }
		public String getFecha() { return fecha; }
		public int getPrecio() { return precio; }
		public String getDescripcionProducto() { return descripcionProducto; }
		public int getVisitas() { return visitas; }
		public float getPuntaje() { return puntaje; }
		
		#endregion

	}
}