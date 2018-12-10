using FirstFloor.ModernUI.Windows.Controls;

namespace TradeFlowers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        static private string _connectionString;
        static public string ConnectionString { get => _connectionString; set => _connectionString = value; }

        public MainWindow()
        {
            ConnectionString = "Server=pgsql.uniflora.mass.hc.ru;Port=5432;User=uniflora_trade;Password=Kkd37Ckqfm;Database=wwwunifloragroup_trade;";
            InitializeComponent();
        }
    }
}