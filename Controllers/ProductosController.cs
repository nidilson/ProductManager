using ProductManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManager.Controllers
{
	public class ProductosController: Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			List<Producto> productos = ProductoService.ObtenerTodos();

			return View(productos);
		}

		[HttpGet]
		public ActionResult Agregar()
		{			
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Agregar(Producto producto)
		{
			if (!ModelState.IsValid)
			{
				return View(producto);
			}
			ProductoService.GuardarProducto(producto);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Obtener(int sku)
		{

			return View();
		}
	}
}