using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElsaConcept.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Categoria")]
        public string Category { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tamanho")]
        public string Size { get; set; }

        [Display(Name = "Stock")]
        public Stock Stock { get; set; }
    }
}
