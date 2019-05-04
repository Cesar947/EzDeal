using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Entity
{
    public class Publicacion
    {
        public int codigoPublicacion { get; set; }

        public Usuario codigoPublicista { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese un titulo")]
        [DisplayName("Titulo")]
        public string titulo { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese un descripcion")]
        [DisplayName("Descripcion")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese un costo estimado")]
        [DisplayName("Costo")]
        public int costoServicio { get; set; }

        [Required(ErrorMessage = "Por favor, seleccione un servicio")]
        [DisplayName("Servicio")]
        public Servicio codigoServicio { get; set; }


        public int estaHabilitado { get; set; }
    }
}

