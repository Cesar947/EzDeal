using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Servicio
    {
        public int codigoServicio { get; set; }


        [Required(ErrorMessage = "Ingrese nombre de servicio")]
        [DisplayName("Nombre de servicio")]
        public string nombre { get; set; }


        [Required(ErrorMessage = "Por favor, ingrese descripcion de servicio")]
        [DisplayName("Escriba una descripicion...")]
        public string descripcion { get; set; }
    }
}

