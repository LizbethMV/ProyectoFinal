using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.MiBD
{
   public class Productos
    {
       [Key]
       public int idPro { get; set; }
       public string NombreProdu { get; set; }
       public string Categoria { get; set; }
       public int Cantidad { get; set; }
    }
}
