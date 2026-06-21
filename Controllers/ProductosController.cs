using ProductManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
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
			try
			{
				ProductoService.GuardarProducto(producto);
				TempData["Mensaje"] = "El producto fue guardado exitosamente.";
				TempData["TipoMensaje"] = "success";
			}
			catch (Exception)
			{
				TempData["Mensaje"] = "El producto no se pudo guardar.";
				TempData["TipoMensaje"] = "danger";
			}
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Obtener(string sku)
		{
			Producto producto = ProductoService.ObtenerProducto(sku);
			return Json(producto, JsonRequestBehavior.AllowGet);
		}

		[HttpDelete]
		public ActionResult Eliminar(string sku)
		{
			if (ProductoService.EliminarProducto(sku))
			{
				return new HttpStatusCodeResult(200);
			}
			return new HttpStatusCodeResult(500);
		}
	}
}