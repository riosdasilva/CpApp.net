using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CpApp.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de nascimento")]
        public string Birthday { get; set; }

        [Required]
        [Display(Name = "Nome de utilizador")]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Nacionalidade")]
        public string Nationaly { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
