using System;
using System.Collections.Generic;
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

namespace SQLCRUD
{
    /// <summary>
    /// Interaction logic for EmployeeInsert.xaml
    /// </summary>
    public partial class EmployeeInsert : Window
    {
        public EmployeeInsert()
        {
            InitializeComponent();
        }


        SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=Project1;Integrated Security=True");
        private void Insertbtn_click(object sender, RoutedEventArgs e)
        {

            string q = "INSERT INTO EMPLOYEE (EID,[First Name], [Last Name], Deparment) VALUES (@EID, @Fname, @Lname, @Department)";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@EID", int.Parse(EIDtxt.Text));
            cmd.Parameters.AddWithValue("@Fname", Fnametxt.Text);
            cmd.Parameters.AddWithValue("@Lname", Lnametxt.Text);
            cmd.Parameters.AddWithValue("@Department", Departmenttxt.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            
            this.Close();
            
            
        }
    }
}
