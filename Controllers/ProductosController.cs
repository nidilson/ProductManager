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


		/// <summary>
		/// Método que se encarga de guardar los productos, este es un método post
		/// que se ejecuta al enviar el formulario correspondiente
		/// </summary>
		/// <param name="producto">El producto a ingresar</param>
		/// <returns>Redireción a la lista de productos almacenados en el archivo json</returns>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Agregar(Producto producto)
		{
			//Se valida el modelo
			if (!ModelState.IsValid)
			{
				return View(producto);
			}
			try
			{
				//Se usa TempData para poder almacenar un mensaje a mostrar al usuario, en caso de que este
				//proceso sea exitoso o haya fallado
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

		/// <summary>
		/// Obtiene los datos de un producto para mostrar en pantalla
		/// </summary>
		/// <param name="sku">SKU del producto del cual se quiere obtener sus detalles</param>
		/// <returns>Objeto JSON con los detalles del objeto</returns>
		[HttpGet]
		public ActionResult Obtener(string sku)
		{
			Producto producto = ProductoService.ObtenerProducto(sku);
			return Json(producto, JsonRequestBehavior.AllowGet);
		}


		/// <summary>
		/// Método que elimina un producto del archivo
		/// </summary>
		/// <param name="sku">SKU del producto que se debe eliminar</param>
		/// <returns>Código de estado con el resultado de la operación</returns>
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