using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TradeFlowers.Model;
using TradeFlowers.Model.Dictonary;
using TradeFlowers.Pages.Dictonary.Product;

namespace TradeFlowers.Pages.Dictonary
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl
    {
        private List<Node> categoryList = new List<Node>();
        private NpgsqlCommand comm;
        private NpgsqlConnection conn;
        private List<ProductModel> productList = new List<ProductModel>();
        //private CategoryModel category;
        //цвета ячеек
        private SolidColorBrush hb = new SolidColorBrush(Colors.Orange);

        private SolidColorBrush nb = new SolidColorBrush(Colors.White);

        public ProductView()
        {
            InitializeComponent();
            conn = new NpgsqlConnection(MainWindow.ConnectionString);
            conn.Open();
            SearchAll.Focus();
            ShowCategory();
            ShowProducts(0);
        }

        private void categoryGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            // CategoryModel c = (tree.SelectedItem as CategoryModel);
            // c.PId ==0 ? ShowProducts(c.Id) : ShowProducts(0);
            if ((tree.SelectedItem as Node).Name != "Все")
            {
                ShowProducts((tree.SelectedItem as Node).Id);
            }
            else
            {
                ShowProducts(0);
            }
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
            //try
            //{
            NpgsqlDataReader dr = comm.ExecuteReader();

            while (dr.Read())
            {
                try
                {
                    categoryList.Add(new Node (dr["name_category"].ToString(),(int)dr["pid_category"],  (int)dr["id_category"] ));
                }
                catch { }
            }

            var root = Node.CreateTree(categoryList);
            tree.ItemsSource = new[] { root };
            conn.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        //private void ShowCategory()
        //{
        //    string sql = "SELECT id_category, pid_category, name_category, order_category FROM продукция.категории order by order_category";
        //    comm = new NpgsqlCommand(sql, conn);
        //    //  IDbConnection conn = null;
        //    try
        //    {
        //        NpgsqlDataReader dr = comm.ExecuteReader();

        //        while (dr.Read())
        //        {
        //            try
        //            {
        //                categoryList.Add(new CategoryModel((int)dr.GetValue(0), (int)dr.GetValue(1), dr.GetValue(2).ToString(), 0));
        //                // string result = reader.GetString(1);//Получаем значение из второго столбца! Первый это (0)!
        //            }
        //            catch { }
        //        }
        //        categoryGrid.ItemsSource = categoryList;
        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

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

        //Добавить катеогрию

        private void addCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoryEdit edt = new CategoryEdit(new CategoryModel());
            edt.ShowDialog();
            // ProductEdit edtp = new ProductEdit();
            // edtp.ShowDialog();
        }
        //редактировать категорию
        private void edtCategory_Click(object sender, RoutedEventArgs e)
        {
            //category = new CategoryModel((tree.SelectedItem as Node).Id, (tree.SelectedItem as Node).PId, (tree.SelectedItem as Node).Name, "");
         //   CategoryEdit edt = new CategoryEdit(category);
         //   edt.ShowDialog();
           // ProductEdit edtp = new ProductEdit();
            //edtp.ShowDialog();
        }

        //метод раскраски по условию
        private void productsGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            //ProductModel product = (ProductModel)e.Row.DataContext;
            //if (product.Id > 50)
            //    e.Row.Background = hb;
            //else
            //    e.Row.Background = nb;
            // e.Row.Background = product.Id > 50 ? hb : nb;
        }
    }
}