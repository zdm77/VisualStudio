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
using Npgsql;
using TradeFlowers.Model.Dictonary;

namespace TradeFlowers.View
{
    /// <summary>
    /// Логика взаимодействия для Product.xaml
    /// </summary>
    public partial class Product 
    {
        private List<ProductModel> productList = new List<ProductModel>();
        public Product()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SearchAll.Focus();
            ShowProducts();

        }
        //загружаем номенклатуру
        private void ShowProducts()
        {
            string sql = "SELECT id, name FROM продукция.продукция order by id";

            //  IDbConnection conn = null;
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(MainWindow.ConnectionString);
                NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

                conn.Open();
                NpgsqlDataReader dr = comm.ExecuteReader();
               
                while (dr.Read())
                {
                    try
                    {
                        productList.Add(new ProductModel((int)dr.GetValue(0), dr.GetValue(1).ToString()));
                        // string result = reader.GetString(1);//Получаем значение из второго столбца! Первый это (0)!
                    }
                    catch { }

                }
                productsGrid.ItemsSource = productList;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchAll_KeyUp(object sender, KeyEventArgs e)
        {
            var filterT=  productList.Where(t => t.Name.StartsWith(SearchAll.Text,StringComparison.InvariantCultureIgnoreCase));
            //var query = from produ in games
            //            where db.name.Contains(word, StringComparer.InvariantCultureIgnoreCase)
            //            select db;
            productsGrid.ItemsSource = filterT;

        }
    }
}
