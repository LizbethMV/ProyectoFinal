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
            bdPrincipal bd = new bdPrincipal();
            var registros = from s in bd.producto
                            select s;
            dbgrid.ItemsSource = registros.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Actualiza
            //if (Regex.IsMatch(txtpro.Text, "^[
            //if (Regex.IsMatch(txtId.Text, @"\d+$"))
            //{
            //    demoEF db = new demoEF();
            //    int id = int.Parse(txtId.Text);
            //    var emp = db.Empleados
            //                .SingleOrDefault(x => x.id == id);

            //    if (emp != null)
            //    {
            //        //eliminar el registros
            //        db.Empleados.Remove(emp);
            //        db.SaveChanges();
            //    }
            //}
            //else { MessageBox.Show("Solo numeros #id"); }
        }
    }
}
