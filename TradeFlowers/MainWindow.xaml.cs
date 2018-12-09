using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Npgsql;
using System.Collections.Generic;

using TradeFlowers.View;
namespace TradeFlowers
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static private string _connectionString;
        static public string ConnectionString { get=>_connectionString; set=>_connectionString=value; }
        public MainWindow()
        {
            InitializeComponent();
            ConnectionString= ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
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
