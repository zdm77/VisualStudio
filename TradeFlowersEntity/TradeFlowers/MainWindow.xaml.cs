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
                //  var q = db.prod_category;

                /*запрос в стиле */
                //var q = from t in db.категории
                //        where t.name_category.ToUpper().StartsWith("В")
                //        orderby t.name_category
                //        select t;

                /*Можно совмещать с обычным SQL*/
                //var comps = db.Database.SqlQuery<prod_Category>("SELECT * FROM ");

                // вставка
                // int numberOfRowInserted = db.Database.ExecuteSqlCommand("INSERT INTO prod_category (category_name) VALUES ('Тест')");
                //prod_poduct p = new prod_poduct();
                //p.product_name = "Тест";
                //p.product_category_id = 6;
                //db.prod_poduct.Add(p);
                //db.SaveChanges();
                var q = db.prod_category.Join(
                    db.prod_poduct,
                    c=>c.category_id,
                    p=>p.product_category_id,
                    (p,c)=> new
                    {
                        Name=p.category_name
                    });

                foreach (var t in q)
                {
                    Console.WriteLine(t.Name);
                }

            }
        }
    }
}
