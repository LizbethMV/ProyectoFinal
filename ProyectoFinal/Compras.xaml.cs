using ProyectoFinal.MiBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace ProyectoFinal
{
    /// <summary>
    /// Interaction logic for Compras.xaml
    /// </summary>
    public partial class Compras : Window
    {
        public Compras()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //ver todo
            bdPrincipal bd = new bdPrincipal();
            var registros = from s in bd.producto
                            select s;
            dbgrid.ItemsSource = registros.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Actualiza
            if (Regex.IsMatch(txtid.Text, @"^\d+$"))
            {
                bdPrincipal db = new bdPrincipal();
                int id = int.Parse(txtid.Text);
                var prod = db.compra
                    .SingleOrDefault(x => x.idCom == id);
                if (prod != null)
                {
                    db.compra.Add(prod);
                    db.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Solo numeros en id");}
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //Borrar
                if (Regex.IsMatch(txtid.Text, @"\d+$"))
                {
                    bdPrincipal db = new bdPrincipal();
                    int id = int.Parse(txtid.Text);
                    var com = db.producto
                        .SingleOrDefault(x => x.idPro == id);
                    if (com != null)
                    {
                        db.producto.Remove(com);
                        db.SaveChanges();
         
                        MessageBox.Show("dato eliminado satisfactoriamente ");
                    }
                }
                else { MessageBox.Show("solo capture numeros "); }
                txtid.Clear();
        
            }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //buscarid
            if (Regex.IsMatch(txtid.Text, @"\d+$"))
            {

                bdPrincipal bd = new bdPrincipal();
                int id = int.Parse(txtid.Text);
                var registros = from s in bd.producto
                                where s.idPro == id
                                select new
                                {
                                    s.idPro,
                                    s.NombreProdu,
                                    s.Categoria,
                                    s.Cantidad,

                                };
                dbgrid.ItemsSource = registros.ToList();
            }
            else { MessageBox.Show("Ingresa solo numeros en id"); }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //modificar

            bdPrincipal db = new bdPrincipal();
            int idPro = int.Parse(txtid.Text);
            var registro = db.producto
                .SingleOrDefault(x => x.idPro == idPro);
            if (registro != null)
            {
                registro.NombreProdu = txtnew.Text;
                registro.Categoria = txtcate.Text;
                registro.Cantidad = int.Parse(txtcan.Text);
                db.SaveChanges();
            }
            MessageBox.Show("Modificar a sido exitoso");
            txtnew.Clear();
            txtcate.Clear();
            txtcan.Clear();

        }
    }
}
