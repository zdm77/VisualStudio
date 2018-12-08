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

using TradeFlowers.View;
namespace TradeFlowers
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Product p = new Product();
            //p.Name = "Тест";
            //MessageBox.Show(p.Name);
            

        }
        private void NewClick(object sender, RoutedEventArgs e)
        {
            NewDocument();
        }

      private void ShowProducts(object sender, RoutedEventArgs e)
        {
            var prod = new Product { Title = "Номенклатура" };
            prod.Show(DockManager);
            prod.Activate();
        }
        private void NewDocument()
        {       

            var doc = new StandartForm { Title = "Новая форма" };
            doc.Show(DockManager);
            doc.Activate();
        }


        private void DockManagerDocumentClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Закрыть окно?", ".Net Notepad", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }


    }
}
