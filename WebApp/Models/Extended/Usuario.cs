using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebGrease.Css.Ast;

namespace WebApp.Models
{
    [MetadataType(typeof(usuariometadata))]
  
    public class usuariometadata
    {
        [Display(Name ="nombre")]
        [Required(AllowEmptyStrings = false, ErrorMessage ="Name requerido")]
        public string nombre { get; set; }

        [Display(Name = "apellido")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Apellido requerido")]
        public string apellido { get; set; }

        [Display(Name = "telefono")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Telefono requerido")]
        public Nullable<int> telefono { get; set; }

        [Display(Name = "correo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email requerido")]
        [DataType(DataType.EmailAddress)]
        public string correo { get; set; }


        //[Required(AllowEmptyStrings = false, ErrorMessage = "Contraseña requireda")]
        //[MinLength(6, ErrorMessage = "Minimo 6 caracteres requeridos")]
        [DataType(DataType.Password)]
        public string contrasena { get; set; }

        //[Display(Name = "Confirmar Contrasena")]
        //[DataType(DataType.Password)]
        //[Compare("contrasena", ErrorMessage ="Confirmar contraseña que sea identica.")]
        //public string ConfirmarContrasena { get; set; }
    }
}