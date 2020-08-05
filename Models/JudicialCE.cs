using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trabajo2.Models
{
    public class JudicialCE
    {
       
        [Required]
         [Display(Name = "Ingrese Rol")]
        public string Rol { get; set; }

        [Required]
        [Display(Name = "Ingrese Nombres")]
        public string Nombres { get; set; }

        [Required]
        [Display(Name = "Ingrese Apellidos:")]
        public string Apellidos { get; set; }

         [Required]
         [Display(Name = "Ingrese Año de la Causa:")]
        public int AñoCausa { get; set; }

        [Display(Name = "Ingrese Correo Electronico:")]
        public int CorreoElectronico { get; set; }


    }

    [MetadataType(typeof(JudicialCE))]
    public partial class Judicial
    {
        public string NombreCompleto { get{ return Nombres + " " + Apellidos; } }
    }

  

}