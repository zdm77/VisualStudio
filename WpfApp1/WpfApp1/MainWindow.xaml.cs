using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Npgsql;
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable phonesTable;
        public MainWindow()
        {
            InitializeComponent();
            // получаем строку подключения из app.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            string sql = "SELECT * FROM \"Phones\"";
            phonesTable = new DataTable();
          //  IDbConnection conn = null;
            try
            {              
                NpgsqlConnection conn = new NpgsqlConnection(connectionString);              
                NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
                // установка команды на добавление для вызова хранимой процедуры
              //  adapter.InsertCommand = new SqlCommand("sp_InsertPhone", connection);
             //   adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
             //   adapter.InsertCommand.Parameters.Add(new SqlParameter("@title", SqlDbType.NVarChar, 50, "Title"));
             //   adapter.InsertCommand.Parameters.Add(new SqlParameter("@company", SqlDbType.NVarChar, 50, "Company"));
             //   adapter.InsertCommand.Parameters.Add(new SqlParameter("@price", SqlDbType.Int, 0, "Price"));
             //   SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            //    parameter.Direction = ParameterDirection.Output;

                conn.Open();
                NpgsqlDataReader dr = comm.ExecuteReader();               
                phonesGrid.ItemsSource = dr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }

        private void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(phonesTable);
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (phonesGrid.SelectedItems != null)
            {
                for (int i = 0; i < phonesGrid.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = phonesGrid.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
            UpdateDB();
        }
    }
}

