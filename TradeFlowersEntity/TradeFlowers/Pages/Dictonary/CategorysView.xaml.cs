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
using TradeFlowers.Model;

namespace TradeFlowers.Pages.Dictonary
{
    /// <summary>
    /// Логика взаимодействия для CategorysView.xaml
    /// </summary>
   
    public partial class CategorysView : UserControl
    {
        //public event Action<> getCategorySelect;
        //private List<Record> categoryList = new List<Record>();
        public static int categoryId;
        public CategorysView()
        {
            InitializeComponent();
            using (tradeEntities db = new tradeEntities())
            {
                //foreach (prod_category c in db.prod_category)
                //{
                //    categoryList.Add(
                //        new Record
                //        {
                //            Name = c.category_name,
                //            TreeId = c.category_id,
                //            ParentId = (int)c.paerent_category,
                //        }
                //        );
                //}
                var root = prod_category_tree.CreateTree(db.prod_category.ToList());
                tree.ItemsSource = new[] { root };
            }

        }
        //public void  categoryGrid_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    MessageBox.Show("1");
        //    getCategorySelect();
          
        //}
        public int getCategorySelect()
        {
            prod_category c = (tree.SelectedItem as prod_category);
            //c.PId == 0 ? ShowProducts(c.Id) : ShowProducts(0);
            try
            {
                if ((tree.SelectedItem as prod_category).category_name != "Все")
                {
                    categoryId = (tree.SelectedItem as prod_category).category_id;
                }
                else
                {
                    categoryId = 0;
                }
                return categoryId;

            }
            catch { return 0; }
        }
    }
}
