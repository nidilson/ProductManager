using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ProductManager.Models
{
	public class ProductoService
	{
		private static string ruta = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/productos.json");
		public static List<Producto> ObtenerTodos()
		{
			string json = File.ReadAllText(ruta);

			List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(json);

			if(productos.Count == 0 || productos == null) {
				productos = new List<Producto>();
			}

			return productos;
		}
		public static Producto ObtenerProducto(string sku)
		{

			List<Producto> productos = ObtenerTodos();
			
			return productos.Where(prod => prod.SKU.Equals(sku)).FirstOrDefault();
		}

		public static bool GuardarProducto(Producto nuevo)
		{
			List<Producto> productos = new List<Producto>();

			if (File.Exists(ruta))
			{
				productos = ProductoService.ObtenerTodos();
			}
			try
			{
				productos.Add(nuevo);

				string jsonFinal = JsonConvert.SerializeObject(productos, Formatting.Indented);

				File.WriteAllText(ruta, jsonFinal);
				
				return true;
			}
			catch (Exception)
			{
				return false;
			}
			
		}

		public static bool EliminarProducto(string sku)
		{
			List<Producto> productos = new List<Producto>();

			if (File.Exists(ruta))
			{
				productos = ProductoService.ObtenerTodos();
			}
			try
			{
				productos.Remove(productos.Where(prod => prod.SKU.Equals(sku)).FirstOrDefault());

				string jsonFinal = JsonConvert.SerializeObject(productos, Formatting.Indented);

				File.WriteAllText(ruta, jsonFinal);

				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}
	}
}