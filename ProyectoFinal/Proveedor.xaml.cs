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
    /// Interaction logic for Proveedor.xaml
    /// </summary>
    public partial class Proveedor : Window
    {
        public Proveedor()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtnom.Text, "^[a-zA-Z]+$") && (Regex.IsMatch(txtCi.Text, "^[a-zA-Z]+$")
                && (Regex.IsMatch(txtTel.Text,  @"^\d+$"))))
            {
                bdPrincipal bd = new bdPrincipal();
                ProyectoFinal.MiBD.Proveedor pro = new ProyectoFinal.MiBD.Proveedor();
                pro.NombrePro = txtnom.Text;
                pro.Ciudad = txtCi.Text;
                pro.Telefono = int.Parse(txtTel.Text);
                bd.proveedores.Add(pro);
                bd.SaveChanges();
                MessageBox.Show("Datos guardados exitosamente");
            }else
            {
                MessageBox.Show("datos no validos");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Productosxaml r = new Productosxaml();
            r.Show();
            this.Close();
        }
    }
}
