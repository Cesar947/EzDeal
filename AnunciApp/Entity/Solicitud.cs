using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Solicitud
    {
        public int codigoSolicitud { get; set; }
        public Publicacion codigoPublicacion { get; set; }
        public Usuario codigoCliente { get; set; }

       
        [Required(ErrorMessage = "Por favor, ingrese el contenido de su solicitud")]
        [DisplayName("Contenido de la solicitud")]
        public string mensajeSolicitud { get; set; }
    }
}

