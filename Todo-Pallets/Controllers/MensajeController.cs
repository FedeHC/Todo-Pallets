using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using Todo_Pallets.Models;


namespace Todo_Pallets.Controllers
{
	public class MensajeController : Controller
  {

		public ActionResult MandarMensaje(String nombre, String apellido, String edad, String email, String emailPadres, String consulta, String ofertasNovedades)
			{
				#region -Validando datos formulario-
				// Chequeando si edad contiene algún número, usando try-catch por si surge un error:
				int edadParseada = 0; 
				
				try
				{
					edadParseada = Int32.Parse(edad); 
				}
				catch
				{ 
					ViewBag.resultadoMensaje = "Error: La edad tiene que ser si o si un número (edad = " + edad + " ).";
					return View();
				}

				// Chequeando si el campo nombre tiene algo escrito:
				if (String.IsNullOrEmpty(nombre))
				{
					ViewBag.resultadoMensaje = "Error: El campo \"nombre\" está vacío (nombre = " + nombre + ")."; 
					return View();
				}

				// Chequeando si el campo apellido tiene algo escrito:
				if (String.IsNullOrEmpty(apellido))
				{
					ViewBag.resultadoMensaje = "Error: El campo \"Apellido\" está vacío (apellido = " + apellido + ")."; 
					return View();
				}

				// Chequeando si el campo email tiene algo escrito:
				if (String.IsNullOrEmpty(email))
					{
						ViewBag.resultadoMensaje = "Error: El campo \"Email\" está vacío (email = " + email + ").";
						return View();
					}

				// Chequeando si el campo email tiene arroba y punto:
				if (!(email.Contains("@") && email.Contains(".")))
					{
						ViewBag.resultadoMensaje = "Error: El campo \"Email\" no contiene arroba o no contiene punto alguno (email = " + email + ")."; 
						return View();
					}

				// Chequeando si el campo edad es menor a '14':
				if (edadParseada < 14)
				{
					// Chequeando si el campo "email de los padres" tiene algo escrito:
					if (String.IsNullOrEmpty(emailPadres))
					{
						ViewBag.resultadoMensaje = "Error: El campo \"Email de los Padres\" está vacío (email padres = " + emailPadres + ")."; 
						return View();
					}

					// Chequeando si el campo "email de los padres" tiene arroba y punto:
					if (!(emailPadres.Contains("@") && emailPadres.Contains(".")))
					{
						ViewBag.resultadoMensaje = "Error: El campo \"Email de los Padres\" no contiene arroba o no contiene punto alguno (email padres = " + emailPadres + ").";
						return View();
					}
				}

				// Chequeando si el campo consulta tiene algo escrito:
				if (String.IsNullOrEmpty(consulta))
				{
					ViewBag.resultadoMensaje = "Error: El campo \"Consulta\" está vacío (consulta = " + consulta + ")."; 
					return View();
				}
			#endregion

				#region -Conexión a BD-
				// ----------------------------------------
				// Conectado con la base de datos (BD):
				// ----------------------------------------

				// Esta variable guarda los datos necesarios para conectarse a la BD:
				string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

				SqlConnection connection = new SqlConnection(connectionString);

				try
				{
					connection.Open();

					// Hacemos el ingreso de datos a la tabla correspondiente:
					string sqlTemplate = @"INSERT INTO TodoPallets.dbo.FormularioContacto
																						 (nombre,apellido,edad,email,emailPadres,consulta)
																			 VALUES
																						 ('{0}','{1}','{2}','{3}','{4}','{5}')";

					string sqlQuery = String.Format(sqlTemplate, nombre, apellido, edad, email, emailPadres, consulta);

					SqlCommand command = new SqlCommand(sqlQuery, connection);
					int affectedRows = command.ExecuteNonQuery();

					// Cerrando la conexión con la BD:
					command.Dispose();
					connection.Close();
				}
				catch (Exception /*problemaBD*/)
				{
					// No poner nada acá.
					// return "Error: hay algún problema con el ingreso de datos a la BD (problema: " + problemaBD + ").";
				}
			#endregion

				#region -Enviando Mail-
				// ----------------------------------------------------------------------
				// Enviado mail desde cuenta de gmail (a partir de envio de formulario):
				// ----------------------------------------------------------------------

				try
				{
					// Pasando dirección de mensaje de la persona que realiza la consulta,
					// usando su nombre y apellido que completó en el formulario de contacto:
					string desde = nombre + " " + apellido;
					MailAddress from = new MailAddress(email, desde);

					// Pasando dirección de mensaje de la empresa:
					MailAddress to = new MailAddress("todo.pallets.consultas@gmail.com");

					// Mensaje y título:
					MailMessage mail = new MailMessage(from, to);
					mail.Subject = ConfigurationManager.AppSettings["ContactMailSubject"];

					// El cuerpo del mensaje del formulario de contacto se copiará al cuerpo del mail:
					string cuepoMensaje = "Consulta desde formulario:\n\n- Nombre: {0}\n- Apellido: {1}\n- Edad: {2}\n- Email: {3}\n- Email de padres: {4}\n\n- Consulta: {5}";
					string elMensaje = String.Format(cuepoMensaje, nombre, apellido, edad, email, emailPadres, consulta);

			 		mail.Body = elMensaje;
					mail.IsBodyHtml = false;

					// Envío:
					string host = ConfigurationManager.AppSettings["ContactMailSMTPHost"];
					int port = Int32.Parse(ConfigurationManager.AppSettings["ContactMailSMTPPort"]);
					string usuario = ConfigurationManager.AppSettings["ContactMailSMTPUsername"];
					string contraseña = ConfigurationManager.AppSettings["ContactMailSMTPPassword"];

					SmtpClient smtp = new SmtpClient(host, port);
					smtp.UseDefaultCredentials = false;
					smtp.Credentials = new NetworkCredential(usuario, contraseña);
					smtp.EnableSsl = true;
					smtp.Send(mail);
				}
				catch (Exception problemaSMTP)
				{
					ViewBag.resultadoMensaje = "Error: No se ha podido enviar mensaje a casilla de gmail (problema: " + problemaSMTP + ").";
					return View();
				}
			
				// Si todo lo anterior está bien, se devuelve una confirmacion al usuario:
				ViewBag.resultadoMensaje = "Su consulta ha sido enviada con total éxito!\nEn la brevedad nos contactaremos con ud.";

				#endregion

				return View();
		}


		public ActionResult ListaMensaje()
    {
			List<Mensajes> lstDetalle = new List<Mensajes>();
			// Esta variable guarda los datos necesarios para conectarse a la BD:
			string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

			// La consulta:
			string sql = @"SELECT * FROM TodoPallets.dbo.FormularioContacto WHERE deleted = 0";

			SqlConnection connection = new SqlConnection(connectionString);

      try
      {
				// Iniciando conexión con la BD:
        connection.Open();

				// Creando un objeto para unir la query SQL con la conexion a la BD:
        SqlCommand command = new SqlCommand(sql, connection);
				// Se ejecuta el comando:
        SqlDataReader dataReader = command.ExecuteReader();

				// El 'while' entra una vez por cada fila que es retornada por la query:
				while (dataReader.Read())
        {
					// Al 'dataReader' le preguntamos por la info de cada columna de la fila actual:
          int mensajeId = (int)dataReader["id"];
          string nombre = dataReader["nombre"].ToString();
          string apellido = dataReader["apellido"].ToString();
          string email = dataReader["email"].ToString();

					Mensajes detalle = new Mensajes(mensajeId, nombre, apellido, email, string.Empty);
          lstDetalle.Add(detalle);
        }

				// Cerrando la conexión con la BD:
        dataReader.Close();
        command.Dispose();
        connection.Close();
      }
      catch (Exception /*problemaLM*/)
      {
				// No poner nada acá.
				// return "Error: hay algún problema con el ingreso de datos a la BD (problema: " + problemaLM + ").";
      }

      ViewBag.lstMensajes = lstDetalle;

			// Pasando tipo de página, para la sección de 'BorrarMensajes':

			Chequeo.pagina = "LM";

			return View();
    }


		public ActionResult DetalleMensaje(string id)
		{
			// Esta variable guarda los datos necesarios para conectarse a la BD:
			string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

			// La consulta:
			string sql = @"SELECT * FROM TodoPallets.dbo.FormularioContacto	WHERE deleted = 0 AND id=" + id;

			SqlConnection connection = new SqlConnection(connectionString);
			try
			{
				// Iniciando conexión con la BD:
				connection.Open();

				SqlCommand command = new SqlCommand(sql, connection);
				SqlDataReader dataReader = command.ExecuteReader();

				if (dataReader.Read())
				{
					// Al 'dataReader' le preguntamos por la info de cada columna de la fila actual:
					int mensajeId = (int)dataReader["id"];
					string nombre = dataReader["nombre"].ToString();
					string apellido = dataReader["apellido"].ToString();
					string email = dataReader["email"].ToString();
					string consulta = dataReader["consulta"].ToString();

					Mensajes detalle = new Mensajes(mensajeId, nombre, apellido, email, consulta);
					ViewBag.mensaje = detalle;
				}

				// Cerrando la conexión con la BD:
				dataReader.Close();
				command.Dispose();
				connection.Close();
			}
			catch (Exception /*problemaDM*/)
			{
				// No poner nada acá.
				// return "Error: hay algún problema con el ingreso de datos a la BD (problema: " + problemaMD + ").";
			}
			return View();
		}


		public ActionResult BorrarMensaje(string id)
		{
			// Esta variable guarda los datos necesarios para conectarse a la BD:
			string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

			// La consulta:
			string sql = @"UPDATE TodoPallets.dbo.FormularioContacto SET deleted=1 WHERE id=" + id;

			int affectedRows = 0;
			SqlConnection connection = new SqlConnection(connectionString);

			try
			{
				// Iniciando conexión con la BD:
				connection.Open();
				// Creando un objeto para unir la query SQL con la conexion a la BD:
				SqlCommand command = new SqlCommand(sql, connection);
				// Se ejecuta el comando:
				affectedRows = command.ExecuteNonQuery();

				// Cerrando la conexión con la BD:
				command.Dispose();
				connection.Close();
			}
			catch (Exception /*problemaBM*/)
			{
				// No poner nada acá (lo importante es que 'affectedRows' quede en cero).
				// return "Error: hay algún problema con el ingreso de datos a la BD (problema: " + problemaBM + ").";
			}

			if (affectedRows == 0)
			{
				ViewBag.resultadoMensaje = "No se ha podido borrar este mensaje (ID = " + id + ").";
			}
			else
			{
				ViewBag.resultadoMensaje = "El mensaje seleccionado ha sido borrado.";
			}

			return View();
		}


		public ActionResult ListaYDetalleMensaje(int? id)
		{
			#region -Lista-

			List<Mensajes> lstDetalle = new List<Mensajes>();
			// Esta variable guarda los datos necesarios para conectarse a la BD:
			string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

			// La consulta:
			string sql = @"SELECT * FROM TodoPallets.dbo.FormularioContacto WHERE deleted = 0";

			SqlConnection connection = new SqlConnection(connectionString);

      try
      {
				// Iniciando conexión con la BD:
        connection.Open();
				// Creando un objeto para unir la query SQL con la conexion a la BD:
        SqlCommand command = new SqlCommand(sql, connection);
				// Se ejecuta el comando:
        SqlDataReader dataReader = command.ExecuteReader();

				// El 'while' entra una vez por cada fila que es retornada por la query:
				while (dataReader.Read())
				{
					// Al 'dataReader' le preguntamos por la info de cada columna de la fila actual:
					int mensajeId = (int)dataReader["id"];
					string nombre = dataReader["nombre"].ToString();
					string apellido = dataReader["apellido"].ToString();
					string email = dataReader["email"].ToString();

					Mensajes detalle = new Mensajes(mensajeId, nombre, apellido, email, string.Empty);
					lstDetalle.Add(detalle);
				}

				// Cerrando la conexión con la BD:
				dataReader.Close();
				command.Dispose();
				connection.Close();
			}
			catch (Exception /*problemaLDMLista*/)
			{
				Mensajes detalle = new Mensajes(0, "Error", "", "", "");
				lstDetalle.Add(detalle);
			}

			ViewBag.lstMensajes = lstDetalle;

			#endregion

			#region -Detalles (por ID)-
			// Comprobando si 'id' tiene algún valor:
			if (id.HasValue)
			{
				ViewBag.mensajeID = id.Value;

				// Iniciando Detalle:

				// La consulta:
				string sql2 = @"SELECT * FROM TodoPallets.dbo.FormularioContacto	WHERE deleted = 0 AND id=" + id.Value;

				SqlConnection connection2 = new SqlConnection(connectionString);
				try
				{
					// Iniciando conexión con la BD:
					connection2.Open();

					SqlCommand command2 = new SqlCommand(sql2, connection2);
					SqlDataReader dataReader2 = command2.ExecuteReader();

					if (dataReader2.Read())
					{
						// Al 'dataReader2' le preguntamos por la info de cada columna de la fila actual:
						int mensajeId = (int)dataReader2["id"];
						string nombre = dataReader2["nombre"].ToString();
						string apellido = dataReader2["apellido"].ToString();
						string email = dataReader2["email"].ToString();
						string consulta = dataReader2["consulta"].ToString();

						Mensajes detalle2 = new Mensajes(mensajeId, nombre, apellido, email, consulta);
						ViewBag.mensaje2 = detalle2;
					}

					// Cerrando la conexión con la BD:
					dataReader2.Close();
					command2.Dispose();
					connection2.Close();
				}
				catch (Exception /*problemaLDMDetalle*/)
				{
					// No poner nada acá.
					// return "Error: hay algún problema con el ingreso de datos a la BD (problema: " + problemaLDMDetalle + ").";
				}
			}
			else
			{
				ViewBag.mensajeID = 0;
			}
			#endregion

			// Pasando tipo de página, para la sección de 'BorrarMensajes':
			Chequeo.pagina = "LYDM";

			return View();
		}

	}
}