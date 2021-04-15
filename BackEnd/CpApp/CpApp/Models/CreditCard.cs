using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CpApp.Models
{
    public class CreditCard
    {

        [Display(Name = "Número")]
        public string Number { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Display(Name = "Tipo de cartão")]
        public string Type { get; set; }
        [Display(Name = "Validade")]
        public string Validity { get; set; }

        public User User { get; set; }

    }
}
