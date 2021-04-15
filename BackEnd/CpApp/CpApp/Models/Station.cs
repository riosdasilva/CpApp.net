using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CpApp.Models
{
    public class Station
    {
        [Required]
        [Display(Name = "Nome")]
        public string Name{get; set;}
        [Key]
        [Required]
        [Display(Name = "Número da estação")]
        public int StationNumber { get; set; }

        public ICollection<Trip> TripsI { get; set; }
        public ICollection<Trip> TripsF { get; set; }
        public ICollection<Stop> StopsC { get; set; }
        public ICollection<Stop> StopsF { get; set; }
    }
}
