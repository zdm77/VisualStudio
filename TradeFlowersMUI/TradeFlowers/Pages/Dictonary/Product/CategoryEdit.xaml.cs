using FirstFloor.ModernUI.Windows.Controls;
using Npgsql;
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
using TradeFlowers.Model.Dictonary;

namespace TradeFlowers.Pages.Dictonary.Product
{
    /// <summary>
    /// Interaction logic for CategoryEdit.xaml
    /// </summary>
    public partial class CategoryEdit : ModernDialog
    {
        private NpgsqlCommand comm;
        private NpgsqlConnection conn;
        //private CategoryModel Category;
        public CategoryEdit(CategoryModel category)
        {
            InitializeComponent();
            //if (category is null)
            //{
            //    CategoryModel Category = new CategoryModel();
            //} else
            //{
            //    Category = category;
            //}           
            this.DataContext = category;
            textName.Focus();
            // define the dialog buttons
            this.Buttons = new Button[] { };
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

        private void TextBox_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Error.ErrorContent.ToString() != "")
            {
                btnSave.IsEnabled = false;
            }
            else
            {
                btnSave.IsEnabled = true;
            }
           
        }
    }
}
