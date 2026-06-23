using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductManager.Models
{
	public enum CategoriaEnum
	{
		[Display(Name = "Computadoras")]
		COMPUTADORAS = 1,
		[Display(Name = "Móviles")]
		MOVILES = 2,
		[Display(Name = "Periféricos")]
		PERIFERICOS = 3,
		[Display(Name = "Redes")]
		REDES = 4,
		[Display(Name = "Otros")]
		OTROS = 5
	}
}