using System.Windows;

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

        private void Init()
        {
            DataContext = this;
        }

        public void SaveFile(object sender, RoutedEventArgs e)
        {
        }
    }
}