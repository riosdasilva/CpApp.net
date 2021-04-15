using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CpApp.Models
{
    public class Trip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tempo do final da viagem")]
        public string FinalTime { get; set; }
        [Required]
        [Display(Name = "Tempo do ínicio da viagem")]
        public string InitialTime { get; set; }
        [Display(Name = "Paragem inicial")]
        public int InitialStationId { get; set; }
        public Station InitialStation { get; set; }
        [Display(Name = "Paragem final")]
        public int FinalStationId { get; set; }
        public Station FinalStation { get; set; }

    }
}
