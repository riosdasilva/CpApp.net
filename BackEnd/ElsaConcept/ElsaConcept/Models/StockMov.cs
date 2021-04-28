using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElsaConcept.Models
{
    public class StockMov
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Produto")]
        public Product Product { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public User User { get; set; }
    }
}
