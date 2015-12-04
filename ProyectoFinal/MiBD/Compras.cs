using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.MiBD
{
     public class Compras
    {
         [Key]
         public int idCom { get; set; }
         public string Nombre { get; set; }
         public string newProd { get; set; }
         public int cantidades { get; set; }

        
    }
}
