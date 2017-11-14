using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using System.Data.SqlClient;
using Todo_Pallets.Models;


namespace Todo_Pallets.Controllers
{
	public class HomeController : Controller
  {
    public ActionResult Index()
    {

			#region -BD- 

			List<Productos> listaProductos = new List<Productos>();

			// Esta variable guarda los datos necesarios para conectarse a la BD:
			string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

			// La consulta:
			string sql = @"SELECT nombreProducto,CONVERT (varchar(10),fecha,103) as fecha,precio,descripcionProducto,visitas,puntaje FROM TodoPallets.dbo.TablaProductos";

			SqlConnection connection = new SqlConnection(connectionString);

			try
			{
				// Iniciando conexión con la BD:
				connection.Open();
				SqlCommand command = new SqlCommand(sql, connection);
				SqlDataReader dataReader = command.ExecuteReader();

				while (dataReader.Read())
				{
					// Al 'dataReader' le preguntamos por la info de cada columna de la fila actual:
					string nombreProducto = dataReader["nombreProducto"].ToString();
					string fecha = dataReader["fecha"].ToString();
					int precio = (int)dataReader["precio"];
					string descripcionProducto = dataReader["descripcionProducto"].ToString();
					int visitas = (int)dataReader["visitas"];
					float puntaje = (float)(double)dataReader["puntaje"];

					// Sacando acentos y diéresis en 'nombreProducto' para evitar el problema del cambio involuntario de tipografía en la títulos:
					nombreProducto = nombreProducto.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ü", "u");

					// Creando objeto 'productos' con los datos de la BD consultada:
					Productos producto = new Productos(nombreProducto, fecha, precio, descripcionProducto, visitas, puntaje);

					listaProductos.Add(producto);
				}

				// Cerrando la conexión con la BD:
				dataReader.Close();
				command.Dispose();
				connection.Close();
			}
			catch (Exception /*problemaProductos*/)
			{
				// No poner nada acá.
				// return "Error: hay algún problema con el ingreso de datos a la BD (problema: " + problemaProductos + ").";
			}

			#endregion

			ViewBag.lstProductos = listaProductos;

			return View();
    }
		

    public ActionResult Proyectos()
    {

			#region -BD-

			List<Proyectos> listaProyectos = new List<Proyectos>();

			// Esta variable guarda los datos necesarios para conectarse a la BD:
			string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

			// La consulta:
			string sql = @"SELECT nombreProyecto,autor,CONVERT (varchar(10),fecha,103) as fecha,descripcionProyecto,visitas,puntaje FROM TodoPallets.dbo.TablaProyectos";

			SqlConnection connection = new SqlConnection(connectionString);

			try
			{
				// Iniciando conexión con la BD:
				connection.Open();
				SqlCommand command = new SqlCommand(sql, connection);
				SqlDataReader dataReader = command.ExecuteReader();

				while (dataReader.Read())
				{
					// Al 'dataReader' le preguntamos por la info de cada columna de la fila actual:
					string nombreProyecto = dataReader["nombreProyecto"].ToString();
					string autor = dataReader["autor"].ToString();
					string fecha = dataReader["fecha"].ToString();
					string descripcionProyecto = dataReader["descripcionProyecto"].ToString();
					int visitas = (int)dataReader["visitas"];
					float puntaje = (float)(double)dataReader["puntaje"];

					// Sacando acentos y diéresis en 'descripcionProyecto' para evitar el problema del cambio involuntario de tipografía en la títulos:
					nombreProyecto = nombreProyecto.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ü", "u");

					// Creando objeto 'proyectos' con los datos de la BD consultada:
					Proyectos proyectos = new Proyectos(nombreProyecto, autor, fecha, descripcionProyecto, visitas, puntaje);

					listaProyectos.Add(proyectos);
				}

				// Cerrando la conexión con la BD:
				dataReader.Close();
				command.Dispose();
				connection.Close();
			}
			catch (Exception /*problemaProyectos*/)
			{
				// No poner nada acá.
				// return "Error: hay algún problema con el ingreso de datos a la BD (problema: " + problemaProyectos + ").";
			}

			#endregion

			ViewBag.lstProyectos = listaProyectos;

			return View();
    }


    public ActionResult SubirProyectos()
    {
      return View();
    }


    public ActionResult Acerca()
    {
      return View();
    }


    public ActionResult Contacto()
    {
      return View();
    }
  }
}