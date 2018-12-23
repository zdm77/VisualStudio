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
    /// Логика взаимодействия для CategoryProductView.xaml
    /// </summary>
    public partial class CategoryProductView : UserControl
    {
        public CategoryProductView()
        {
            InitializeComponent();          
           categoryView.tree.MouseLeftButtonUp += new MouseButtonEventHandler(showProducts);

        }
        private void showProducts(object sender, RoutedEventArgs e)
        {
            productView.showProduct(categoryView.getCategorySelect());           
        }
    }
}
