using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal.MiBD;

namespace ProyectoFinal
{
    public class invoice
    {
        public invoice()
        {
            this.Idusu= new MiBD.Usuario();
        }
        public int invoiceId { get; set; }
        public virtual Usuario Idusu { get; set; }
        public DateTime SaleDate { get; set; }
        public virtual List<Productos> SaleList { get; set; }

    }
}
