using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Usuario
    {
        public int codigoUsuario { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese correo UPC")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Por favor ingrese un email valido")]
        public string email { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese contraseña creativa")]
        [DisplayName("Contraseña")]
        public string contrasena { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese nombre")]
        [DisplayName("Nombre de publicista")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese apellido")]
        [DisplayName("Apellido de publicista")]
        public string apellidos { get; set; }

      

        [Required(ErrorMessage = "Por favor, ingrese link de contacto(FB, WEB, etc)")]
        [DisplayName("Link contacto")]
        public string urlContacto { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese telefono")]
        [DisplayName("Telefono")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese su distrito")]
        [DisplayName("Distrito")]
        public Distrito codigoDistrito { get; set; }

        public int rol { get; set; }
    }
}