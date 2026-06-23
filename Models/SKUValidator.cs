using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductManager.Models
{
	public class SKUValidator : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value == null)
				return ValidationResult.Success;

			string sku = value.ToString();

			if (ProductoService.ObtenerProducto(sku) != null)
			{
				return new ValidationResult("Ya existe un producto con ese SKU.");
			}
			return ValidationResult.Success;
		}
	}
}