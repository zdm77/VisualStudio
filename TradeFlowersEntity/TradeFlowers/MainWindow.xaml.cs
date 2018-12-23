using FirstFloor.ModernUI.Windows.Controls;
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

namespace TradeFlowers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public tradeEntities db;
        public MainWindow()
        {
            InitializeComponent();
            using (tradeEntities db = new tradeEntities())
            {
                var q = db.prod_Category;
                
                //var q = from t in db.категории
                //        where t.name_category.ToUpper().StartsWith("В")
                //        orderby t.name_category
                //        select t;


                foreach (prod_Category t in q)
                {
                    Console.WriteLine(t.categoryName);
                }

            }
        }
    }
}
