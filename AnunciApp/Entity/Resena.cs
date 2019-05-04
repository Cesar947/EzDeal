using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Resena
    {
        public int codigoResena { get; set; }
        public Publicacion codigoPublicacion { get; set; }
        public Usuario codigoCliente { get; set; }
        [Required(ErrorMessage = "Por favor, ingrese el cuerpo de su resena")]
        [DisplayName("Contenido de la reseña")]
        public string contenido { get; set; }
        public float valoracion { get; set; } 
    }
}