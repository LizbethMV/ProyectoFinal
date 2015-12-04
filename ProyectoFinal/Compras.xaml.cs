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
            //guardar
            if(Regex.IsMatch(txtnew.Text, @"^[a-zA-Z]+$") && (Regex.IsMatch(txtcate.Text, @"^[a-zA-Z]+$"))){
                if (Regex.IsMatch(txtcan.Text, @"\d+$")){
                    bdPrincipal db = new bdPrincipal();
                    ProyectoFinal.MiBD.Compras com = new ProyectoFinal.MiBD.Compras();
                    com.newProd = txtnew.Text;
                    com.cantidades = int.Parse(txtcan.Text);
                    db.compra.Add(com);
                    db.SaveChanges();
                }
                else{ MessageBox.Show("solo letras en nuevo producto y categoria");}
            }
            else{ MessageBox.Show("solo numeros en cantidad");} 
        }
    }
}
