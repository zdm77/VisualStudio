using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Input;




namespace TradeFlowers.View
{
    /// <summary>
    /// Логика взаимодействия для StandartForm.xaml
    /// </summary>
    public partial class StandartForm 
    {
        public StandartForm()
        {
            InitializeComponent();
            Init();
        }
     


        void Init()
        {
            DataContext = this;
           
        }
        public void SaveFile(object sender, RoutedEventArgs e)
        {

        }
    }
}
