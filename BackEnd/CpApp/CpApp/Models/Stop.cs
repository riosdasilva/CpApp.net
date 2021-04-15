using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CpApp.Models
{
    public class Stop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Lugares da próxima paragem")]
        public int SeatsToNextStop { get; set; }
        [Required]
        [Display(Name = "Tempo de paragem")]
        public string StopTime { get; set; }
        [Required]
        [Display(Name = "Paragem atual")]
        public int CurrentStationId { get; set; }
        public Station CurrentStation { get; set; }
        [Required]
        [Display(Name = "Próxima paragem")]
        public int NextStationId { get; set; }
        public Station NextStation { get; set; }

        public ICollection<Seat> Seats { get; set; }
    }
}
