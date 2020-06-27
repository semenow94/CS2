using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SemenovWPFDB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable dt;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "workers_db"
            };

            connection = new SqlConnection(connectionStringBuilder.ConnectionString);
            adapter = new SqlDataAdapter();

            #region select

            SqlCommand command =
                new SqlCommand("SELECT * FROM Workers inner join Departments on Workers.Department=Departments.Id",
                connection);
            adapter.SelectCommand = command;


            #endregion

            #region insert

            command = new SqlCommand(@"INSERT INTO Workers (surname, name, age, Department) 
                          VALUES (@surname, @name, @age, @Department); SET @ID = @@IDENTITY;",
                          connection);

            command.Parameters.Add("@surname", SqlDbType.NVarChar, -1, "surname");
            command.Parameters.Add("@name", SqlDbType.NVarChar, -1, "name");
            command.Parameters.Add("@age", SqlDbType.Int, -1, "age");
            command.Parameters.Add("@Department", SqlDbType.Int, -1, "Department");
            SqlParameter param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");

            param.Direction = ParameterDirection.Output;
            param.SourceVersion = DataRowVersion.Original;
            adapter.InsertCommand = command;

            #endregion

            #region update

            command = new SqlCommand(@"UPDATE Workers SET surname = @surname,
                                                            name = @name,
                                                            age = @age,
                                                            Department= @Department
                                        WHERE ID = @ID", connection);

            command.Parameters.Add("@surname", SqlDbType.NVarChar, -1, "surname");
            command.Parameters.Add("@name", SqlDbType.NVarChar, -1, "name");
            command.Parameters.Add("@age", SqlDbType.Int, -1, "age");
            command.Parameters.Add("@Department", SqlDbType.Int, -1, "Department");
            param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");

            param.SourceVersion = DataRowVersion.Original;

            adapter.UpdateCommand = command;


            #endregion

            #region delete


            command = new SqlCommand("DELETE FROM Workers WHERE ID = @ID", connection);
            param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            param.SourceVersion = DataRowVersion.Original;
            adapter.DeleteCommand = command;

            #endregion

            dt = new DataTable();
            adapter.Fill(dt);
            WorkersDG.DataContext = dt.DefaultView;
        }

        private void workerDel_Click(object sender, RoutedEventArgs e)
        {
            DataRowView newRow = (DataRowView)WorkersDG.SelectedItem;
            newRow.Row.Delete();
            adapter.Update(dt);
        }

        private void workerAdd_Click(object sender, RoutedEventArgs e)
        {
            DataRow newRow = dt.NewRow();
            EditWorker editWindow = new EditWorker(newRow);
            editWindow.ShowDialog();

            if (editWindow.DialogResult.Value)
            {
                dt.Rows.Add(editWindow.resultRow);
                adapter.Update(dt);
                dt.Clear();
                adapter.Fill(dt);
            }
        }

        private void workerEdit_Click(object sender, RoutedEventArgs e)
        {
            DataRowView newRow = (DataRowView)WorkersDG.SelectedItem;
            newRow.BeginEdit();

            EditWorker editWindow = new EditWorker(newRow.Row);
            editWindow.ShowDialog();

            if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
            {
                newRow.EndEdit();
                adapter.Update(dt);
                dt.Clear();
                adapter.Fill(dt);
            }
            else
            {
                newRow.CancelEdit();
            }
        }
    }
}
