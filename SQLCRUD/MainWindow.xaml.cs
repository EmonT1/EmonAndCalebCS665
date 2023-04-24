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
            Loadgrid();
        }

        public static List<string> tablesList = new List<string>() { "Table 1", "Table 2", "Table 3" };
       


        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\ProjectModels;Initial Catalog=Example;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public void clear()
        {
            SQLTableComboBox.ItemsSource = tablesList;
            //SQLTableComboBox.Clear()
            ycoord.Clear();
            DelID.Clear();
        }

        public void Loadgrid()
        {
            //SqlCommand command = new SqlCommand("select * from [Table]", conn);
            //DataTable dt = new DataTable();
            //conn.Open();
            //SqlDataReader sdr = command.ExecuteReader();
            //dt.Load(sdr);
            //conn.Close();
            //SQLTableInfoInDataGrid.ItemsSource = dt.DefaultView;

        }
        private void clearbtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }
        public bool isValid()
        {
            if(SQLTableComboBox.Text == string.Empty && ycoord.Text == string.Empty)
            {
                MessageBox.Show("Coordinates are required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void Insertbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isValid())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [Table] VALUES (@xcoord, @ycoord)", conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@xcoord", int.Parse(SQLTableComboBox.Text));
                    cmd.Parameters.AddWithValue("@ycoord", int.Parse(ycoord.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Loadgrid();
                    MessageBox.Show("Successfully added coordinate", "saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    clear();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Deletebtn_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from [Table] where  ID = " + DelID.Text, conn);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("coordinate has been deleted", "deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                conn.Close();
                clear();
                Loadgrid();
                conn.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Not Deleted" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Updatebtn_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update [Table] set xcoord = '" + SQLTableComboBox.Text + "', ycoord = '" + ycoord.Text + "' WHERE ID = '" + DelID.Text + "'", conn);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Coord updated", "updated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                clear();
                Loadgrid();
            }
        }
    }
}
