using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinal.MiBD;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;


namespace ProyectoFinal
{
    public partial class Factura : Form
    {
        public Factura()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            //buscar
            if (Regex.IsMatch(textBox1.Text.Trim(), @"^\d+$"))
            {
                bdPrincipal db = new bdPrincipal();
                //parse the product code as int from the TextBox
                int idProd = int.Parse(textBox1.Text);
                //We query the database for the product
                MiBD.Productos p = db.producto.SingleOrDefault(x => x.idPro == idProd);
                if (p != null)  //if product was found
                {
                    //store in a temp variable (if user clicks on add we will need this for the Array)
                    product = p;
                    //We display the product information on a label 
                    label2.Text = string.Format("ID: {0}, Name: {1}, Price: {2}", p.idPro, p.NombreProdu, p.Categoria, p.Cantidad);
                }
                else
                {
                    //if product was not found we display a user notification window
                    // MessageBox.Show("Product not found. (Only numbers allowed)", "Product code error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //agregar
            //we first check if a product has been selected
            if (product == null)
            {
                //if not we call the search button method
                Buscar_Click(null, null);
                //we check again if the product was found
                if (product == null)
                {
                    //if tmpProduct is empty (Product not found) we exit the procedure

                    System.Windows.MessageBox.Show("No product was selected", "No product", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                    //exit procedure
                    return;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //limpiar
            CleanUp();
        }
        private void CleanUp(){
        //shopping cart = a new empty list
            ShoppingCart = new List<MiBD.Productos>();
           //Textboxes and labels are set to defaults
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;

            label2.Text = "Current product N/A";
            //    label6.Text= " ";
            //DataGrid items are set to null
            dataGridView1.DataSource = null;
           //dataGridView1.Items.Refresh();
          //Tmp variable is erased using null
            product = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //guardar
           //we make sure there is at least one item in the cart and a sales person has been selected
            if (ShoppingCart.Count > 0 && comboBox1.SelectedIndex > -1){
           //auto dispose after no longer in scope
                using(bdPrincipal db = new bdPrincipal()){
           //All database transactions are considered 1 unit of work
           using (var dbTransaction = db.Database.BeginTransaction())
           {
            try {
           //we create the invoice object
           invoice inv = new invoice();
           inv.SaleDate = DateTime.Now;
           //assign sales person by querying the database using the Combobox selection
           //comboBox1.SelectedIndex = 0;
           inv.id =
              db.Registro.SingleOrDefault(s => s.id == (int)comboBox1.SelectedValue);

           //for each product in the shopping cart we query the database
          foreach (var prod in ShoppingCart)
          {
           //get product record with id
              MiBD.Productos p = db.producto.SingleOrDefault(i => i.idPro == prod.idPro);
              //reduce inventory
              int RemainingItems = p.Qty - prod.Qty >= 0 ? (p.Qty - prod.Qty) : p.Qty;
              if (p.Qty == RemainingItems)
              {
              System.Windows.MessageBox.Show(
                            string.Format(
                          "Unable to sell Product #{0} not enough inventory, Do want to continue?",
                                       p.idPro),
                                    "Not Enough Inventory", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                             //end transaction
                               dbTransaction.Rollback();
                            //exit procedure
                            return;
                             }
                           else
                       {
                       //If Qty is ok we sell the product
                             p.Qty = RemainingItems;
                             inv.SaleList.Add(p);
                           }

                       }

                      //we add the generated invoice to the Invoice Entity (Table)
                       db.invoices.Add(inv);
               //Save Changed to the database
                 db.SaveChanges();
                     // Make the changes permanent 
                     dbTransaction.Commit();
                    //We restore the form with defaults
                     CleanUp();
                     //Show confirmation message to the user
                      System.Windows.MessageBox.Show(string.Format("Transaction #{0}  Saved", inv.invoiceId), "Success", MessageBoxButton.OK,
                          MessageBoxImage.Information);
                  }
                  catch
                 {
                     //if an error is produced, we rollback everything
                    dbTransaction.Rollback();
                    //We notify the user of the error
               System.Windows.MessageBox.Show("Transaction Error, unable to generate invoice", "Fatal Error", MessageBoxButton.OK,
                           MessageBoxImage.Error);
                     }
                  }
              }
           }
            else
            {
              System.Windows.MessageBox.Show("Please select at least one product and a Sales Person", "Data Error",
                   MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //salir
            this.Hide();
        }

        public List<Productos> ShoppingCart { get; set; }
    }
}
