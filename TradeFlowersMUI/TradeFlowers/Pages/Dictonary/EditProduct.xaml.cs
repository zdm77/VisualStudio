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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;
namespace TradeFlowers.Pages.Dictonary
{
    /// <summary>
    /// Логика взаимодействия для EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        private NpgsqlCommand comm;
        private NpgsqlConnection conn;
        public EditProduct()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            conn = new NpgsqlConnection(MainWindow.ConnectionString);
            conn.Open();
            StringBuilder sql = new StringBuilder("INSERT INTO продукция.категории (name_category) values ('");
            sql.Append(textName.Text+"')");
            
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
    }
}
