using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace SemenovWPFDB
{
    /// <summary>
    /// Логика взаимодействия для EditWorker.xaml
    /// </summary>
    public partial class EditWorker : Window
    {
        public ObservableCollection<string> comboItems { get; set; }
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable dt;
        public DataRow resultRow { get; set; }
        public EditWorker(DataRow dataRow)
        {
            InitializeComponent();
            resultRow = dataRow;

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboItems = new ObservableCollection<string>();
            SurTB.Text = resultRow["surname"].ToString();
            NameTB.Text = resultRow["name"].ToString();
            AgeTB.Text = resultRow["age"].ToString();
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "workers_db"
            };

            connection = new SqlConnection(connectionStringBuilder.ConnectionString);
            adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT depname FROM Departments", connection);
            adapter.SelectCommand = command;
            dt = new DataTable();
            adapter.Fill(dt);
            for(int i=0; i<dt.Rows.Count; i++)
            {
                comboItems.Add(dt.Rows[i]["depname"].ToString());
            }
            DepCB.ItemsSource = comboItems;
            if(SurTB.Text.Length>0) DepCB.SelectedIndex = (int)resultRow["Department"] - 1;
        }
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            resultRow["surname"] = SurTB.Text;
            resultRow["name"] = NameTB.Text;
            resultRow["age"] = AgeTB.Text;
            resultRow["Department"] = DepCB.SelectedIndex + 1;
            this.DialogResult = true;
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}