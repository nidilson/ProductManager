using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductManager.Models
{
	public class Producto
	{
		
		[Required(ErrorMessage = "Este campo es requerido")]
		[MaxLength(20)]
		public string SKU { get; set; }

		[DisplayName("Nombre del producto")]
		[Required(ErrorMessage = "Este campo es requerido")]
		[MaxLength(50, ErrorMessage = "No se permiten más de 50 caracteres")]
		public string Nombre { get; set; }

		[DisplayName("Categoría de producto")]
		[Required(ErrorMessage = "Este campo es requerido")]
		public CategoriaEnum Categoria { get; set; }

		[DisplayName("Descripción del producto")]
		[Required(ErrorMessage = "Este campo es requerido")]
		[MaxLength(1000, ErrorMessage = "No se permiten más de 1000 caracteres")]
		public string Descripcion { get; set; }


		[Required(ErrorMessage = "Este campo es requerido")]
		[Range(0, 999999999, ErrorMessage = "El valor tiene que estar entre 0 y 999999999")]
		public decimal Precio { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		[Range(0, 999999999, ErrorMessage = "El valor tiene que estar entre 0 y 999999999")]
		public int Inventario { get; set; }
	}
}