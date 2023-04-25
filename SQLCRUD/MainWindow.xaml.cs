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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Remoting.Contexts;
using System.Windows.Markup;
using System.ComponentModel;
using System.Reflection;

namespace SQLCRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// SQL wpf program to base out project on
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static List<string> tablesList = new List<string>() { "Table 1", "Table 2", "Table 3" };



        SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=Project1;Integrated Security=True");

        private string selectedTableName;
        private void SQLTableComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem Selected = comboBox.SelectedItem as ComboBoxItem;
            DataTable dataTable = new DataTable();
            if (Selected != null)
            {
                selectedTableName = Selected.Content.ToString();
                LoadTable(selectedTableName);                
            }


        }

        public void LoadTable(string TableName)
        {
            SqlCommand command = new SqlCommand("select * from " + TableName, conn);
            DataTable dataTable = new DataTable();
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            conn.Close();
            SQLTableInfoInDataGrid.ItemsSource = dataTable.DefaultView;

        }
        public void LoadJoinGrid(string query)
        {
            SqlCommand command = new SqlCommand(query, conn);
            DataTable dataTable = new DataTable();
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            conn.Close();
            SQLTableInfoInDataGrid.ItemsSource = dataTable.DefaultView;
        }
        public void ClearFields()
        {
            DelID.Clear();
        }

        private void Deletebtn_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTableName != null && selectedTableName == "Employee")
            {
                string query = "DELETE FROM " + selectedTableName + " WHERE EID = " + DelID.Text;
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                LoadTable(selectedTableName);
                ClearFields();
            }
        }
        private void Window_closing(object sender, CancelEventArgs e)
        {
            LoadTable(selectedTableName);
        }
        private void Insertbtn_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTableName != null && selectedTableName == "Employee")
            {
                EmployeeInsert employeeInsert = new EmployeeInsert();
                employeeInsert.Owner = this;
                employeeInsert.Closing += Window_closing;
                employeeInsert.ShowDialog();
            }

        }
        private void Updatebtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void JoinEmployeeTimeCard(object sender, RoutedEventArgs e)
        {
            string query = "SELECT Employee.EID, Employee.[First Name], TimeCards.TCID, TimeCards.WeekEndingDate, TimeCards.TotalHours FROM Employee INNER JOIN TimeCards ON Employee.EID = TimeCards.EmployeeID;";
            LoadJoinGrid(query);
        }

        private void JoinTimeCardTimeEntries(object sender, RoutedEventArgs e)
        {
            string query = "SELECT TimeCards.TCID, TimeCards.EmployeeID, TimeEntries.[Date], TimeEntries.TaskID FROM TimeCards INNER JOIN TimeEntries ON TimeCards.TCID = TimeEntries.TimeCardID";
            LoadJoinGrid(query);
        }
    }
}
