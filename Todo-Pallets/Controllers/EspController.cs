using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using System.Data.SqlClient;
using Todo_Pallets.Models;


namespace Todo_Pallets.Controllers
{
    public class EspController : Controller
    {
        public ActionResult Comprar()
        {
          return View();
        }

		
				public ActionResult SubirProyecto()
				{
					return View();
				}
	}
}