using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.MiBD
{
    public class Ventas
    {
        [Key]
        public int idventa { get; set; } 
        public string nomfinal { get; set; }
        public string Descripcion { get; set; }
    }
}
