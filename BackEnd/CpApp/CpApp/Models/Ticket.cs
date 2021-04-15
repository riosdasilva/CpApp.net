using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CpApp.Models
{
    public class Ticket
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Display(Name = "Data do bilhete")]
		public string Date { get; set; }

		[Required]
		[Display(Name = "Preço")]
		public int Price { get; set; }
		[Display(Name = "Validade")]
		public string Time { get; set; }
		[Display(Name = "Usado")]
		public bool Used { get; set; }
		[Display(Name = "Inspector")]
		public Inspector Inspector { get; set; }
		[Display(Name = "Cliente")]
		public Client Client { get; set; }
	}
}
