using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.MiBD
{
     public class bdPrincipal : DbContext
    {
         public DbSet<Usuario> usuarios {get; set; }
         public DbSet<Proveedor> proveedores { get; set; }
         public DbSet<Productos> producto { get; set; }
         public DbSet<Compras> compra { get; set; }

         // public DbSet<Registro> SalesPersons { get; set; }
         public DbSet<invoice> invoices { get; set; }

         
    }
}
