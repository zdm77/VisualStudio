using FirstFloor.ModernUI.Windows.Controls;
using Npgsql;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using TradeFlowers.Model.Dictonary;

namespace TradeFlowers.Pages.Dictonary.Product
{
    /// <summary>
    /// Interaction logic for ProductEdit.xaml
    /// </summary>
    public partial class ProductEdit : ModernDialog
    {
        private NpgsqlCommand comm;
        private NpgsqlConnection conn;
        
        public ProductEdit()
        {
            InitializeComponent();

            // define the dialog buttons
            this.Buttons = new Button[] {};
        }
        

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            conn = new NpgsqlConnection(MainWindow.ConnectionString);
            conn.Open();
            StringBuilder sql = new StringBuilder("INSERT INTO продукция.категории (name_category) values ('");
            sql.Append(textName.Text + "')");

            comm = new NpgsqlCommand(sql.ToString(), conn);
            //  IDbConnection conn = null;
            try
            {
                NpgsqlDataReader dr = comm.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ModernDialog_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}