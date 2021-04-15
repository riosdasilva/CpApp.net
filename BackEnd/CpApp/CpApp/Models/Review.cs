using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CpApp.Models
{
    public class Review
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        [Display(Name = "Classificação")]
        public float Rating { get; set; }
    }
}
