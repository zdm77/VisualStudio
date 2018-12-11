using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TradeFlowers.Model.Dictonary;

namespace TradeFlowers.View
{
    /// <summary>
    /// Логика взаимодействия для Product.xaml
    /// </summary>
    public partial class ProductView
    {
        private List<CategoryModel> categoryList = new List<CategoryModel>();
        private NpgsqlCommand comm;
        private NpgsqlConnection conn;
        private List<ProductModel> productList = new List<ProductModel>();

        public ProductView()
        {
            InitializeComponent();
            conn = new NpgsqlConnection(MainWindow.ConnectionString);
            conn.Open();
        }

        private void categoryGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            ShowProducts((categoryGrid.SelectedItem as CategoryModel).Id);
        }

        private void SearchAll_KeyUp(object sender, KeyEventArgs e)
        {
            var filterT = productList.Where(t => t.Name.StartsWith(SearchAll.Text, StringComparison.InvariantCultureIgnoreCase));
            //var query = from produ in games
            //            where db.name.Contains(word, StringComparer.InvariantCultureIgnoreCase)
            //            select db;
            productsGrid.ItemsSource = filterT;
        }

        //Загружаем категории
        private void ShowCategory()
        {
            string sql = "SELECT id_category, pid_category, name_category, order_category FROM продукция.категории order by order_category";
            comm = new NpgsqlCommand(sql, conn);
            //  IDbConnection conn = null;
            try
            {
                NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    try
                    {
                        categoryList.Add(new CategoryModel((int)dr.GetValue(0), (int)dr.GetValue(1), dr.GetValue(2).ToString(), 0));
                        // string result = reader.GetString(1);//Получаем значение из второго столбца! Первый это (0)!
                    }
                    catch { }
                }
                categoryGrid.ItemsSource = categoryList;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //загружаем номенклатуру
        private void ShowProducts(int categoryID)
        {
            productsGrid.ItemsSource = null;
            productList.Clear();
            StringBuilder sql = new StringBuilder("SELECT id, name FROM продукция.продукция where 1=1 ");
            sql.Append(categoryID != 0 ? " AND pid=" + categoryID.ToString() : "");
            sql.Append(" order by id");
            //  IDbConnection conn = null;
            try
            {
                //  NpgsqlConnection conn = new NpgsqlConnection(MainWindow.ConnectionString);
                comm = new NpgsqlCommand(sql.ToString(), conn);

                conn.Open();
                NpgsqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())

                {
                    try
                    {
                        productList.Add(new ProductModel((int)dr["id"], dr["name"].ToString()));
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SearchAll.Focus();
            ShowCategory();
            ShowProducts(0);
        }
    }
}