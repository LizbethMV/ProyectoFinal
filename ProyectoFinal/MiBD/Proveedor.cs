using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.MiBD
{
    public class Proveedor
    {
        [Key]
        public int idProv { get; set; }
        public string NombrePro { get; set; }
        public string Ciudad { get; set; }
        public int Telefono { get; set; }

        
    }
}
