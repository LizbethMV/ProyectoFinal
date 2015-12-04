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
    /// Interaction logic for Productosxaml.xaml
    /// </summary>
    public partial class Productosxaml : Window
    {
        public Productosxaml()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtno.Text, "^[a-zA-Z]+$") && (Regex.IsMatch(txtCa.Text, "^[a-zA-Z]+$")
            && (Regex.IsMatch(txtCan.Text, @"^\d+$"))))
                {
                    bdPrincipal bd = new bdPrincipal();
                    ProyectoFinal.MiBD.Productos prod = new ProyectoFinal.MiBD.Productos();
                    prod.NombreProdu = txtno.Text;
                    prod.Categoria = txtCa.Text;
                    prod.Cantidad = int.Parse(txtCan.Text);

                    bd.producto.Add(prod);
                    bd.SaveChanges();
                    MessageBox.Show("Datos almacenados correctamente");
                }
                else
                {
                    MessageBox.Show("datos no validos");
                }

                Compras vb = new Compras();
                vb.Show();
                this.Close();
            }
        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
