//using proyecto.New_bd;
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
//using System.Text.RegularExpressions;
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
            ////if (Regex.IsMatch(txtnom.Text, "^[a-zA-Z]+$") && (Regex.IsMatch(txtci.Text, "^[a-zA-Z]+$")
            //    && (Regex.IsMatch(txtdire.Text, "^[a-zA-Z]+$"))))
            //{
            //    bdPrincipal bd = new bdPrincipal();
            //    proyecto.New_bd.Proveedor pro = new proyecto.New_bd.Proveedor();
            //    pro.Nombre = txtnom.Text;
            //    pro.Ciudad = txtci.Text;
            //    pro.Direccion = txtdire.Text;
            //    bd.Proveedores.Add(pro);
            //    bd.SaveChanges();
            //    MessageBox.Show("Datos guardados exitosamente");
            //}
            //else { MessageBox.Show("Datos no validos"); 
            //}
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
