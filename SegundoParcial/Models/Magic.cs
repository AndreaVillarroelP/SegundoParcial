using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcial.Models
{
    public class Magic
    {
        [Key]
        public string FuturoId { get; set; }
        [Required(ErrorMessage ="EL campo es requerido")]
        [StringLength(60,MinimumLength =10,ErrorMessage ="Deben haber entre 10 y 60 caracteres")]
        [Display(Name = "Vision")]
        public string Vision { get; set; }
        [Url]
        [Required(ErrorMessage = "EL campo es requerido")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Deben haber entre 10 y 1000 caracteres")]
        [Display(Name = "Imagen de la suerte")]
        public string Imagen { get; set; }
    }
}
