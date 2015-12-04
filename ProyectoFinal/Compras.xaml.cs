﻿using ProyectoFinal.MiBD;
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
            if (Regex.IsMatch(txtid.Text, @"^\d+$"))
            {
                bdPrincipal db = new bdPrincipal();
                int id = int.Parse(txtid.Text);
                var ar = db.producto
                    .SingleOrDefault(x => x.idPro == id);
                if (ar != null)
                {

                    db.producto.Add(ar);
                    db.SaveChanges();
                }
            }
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //Borra
            if (Regex.IsMatch(txtnew.Text, @"^[a-zA-Z]+$")){
            if (Regex.IsMatch(txtcan.Text, @"\d+$")){
                bdPrincipal db = new bdPrincipal();
                int cant = int.Parse(txtcan.Text);
                var prod = db.producto
                    .SingleOrDefault(x=> x.Cantidad == cant);
                if (prod != null){
                    db.producto.Remove(prod);
                    db.SaveChanges();
                      }
                   }
              else { MessageBox.Show("solo letras en  #producto"); }
            }
            else { MessageBox.Show("Solo numeros en #cantidad"); }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
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
    }
}
