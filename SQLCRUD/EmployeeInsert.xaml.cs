using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
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


       // SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=Project1;Integrated Security=True");
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=665Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");//Emon
        public int TableTab { get; set; }
        private void Insertbtn_click(object sender, RoutedEventArgs e)
        {
            if(TableTab != null)
            {
                if (TableTab == 0) 
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
                }

                else if (TableTab ==1) 
                {

                    string q = "INSERT INTO TimeCards (TCID, EmployeeID, WeekEndingDate, TotalHours) VALUES (@TCID, @EmpID, @WED, @TH)";
                    SqlCommand cmd = new SqlCommand(q, conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@TCID", int.Parse(TCIDtxt.Text));
                    cmd.Parameters.AddWithValue("@EmpID", TCEIDtxt.Text);
                    cmd.Parameters.AddWithValue("@WED", WeekEndingDatetxt.Text);
                    cmd.Parameters.AddWithValue("@TH", TotalHourstxt.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
                else if (TableTab ==2) 
                {
                    string q = "INSERT INTO TimeEntries (TEID, TimeCardID, Date, [Start Time], [End Time], TaskID) VALUES (@TEID, @TimeCardID, @Date, @StartTime, @EndTime, @Taskid)";
                    SqlCommand cmd = new SqlCommand(q, conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@TEID", int.Parse(EIDtxt.Text));
                    cmd.Parameters.AddWithValue("@TimeCardID", Fnametxt.Text);
                    cmd.Parameters.AddWithValue("@Date", Lnametxt.Text);
                    cmd.Parameters.AddWithValue("@StartTime", Departmenttxt.Text);
                    cmd.Parameters.AddWithValue("@EndTime", Departmenttxt.Text);
                    cmd.Parameters.AddWithValue("@Taskid", Departmenttxt.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();


                }
                else if (TableTab ==3) 
                {

                 //   [TaskID] INT NOT NULL, 
	                //[Task Description] NVARCHAR(MAX) NOT NULL,

                 //   [Priority Level] INT NOT NULL, 
	                //[Task Lead] NVARCHAR(MAX) NOT NULL,
                    string q = "INSERT INTO Tasks (TaskID, [Task Description], [Priority Level], [Task Lead]) VALUES (@Task_ID, @Task_Description, @Priority, @Lead)";
                    SqlCommand cmd = new SqlCommand(q, conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@Task_ID", int.Parse(Task_ID.Text));
                    cmd.Parameters.AddWithValue("@Task_Description", TaskDescriptiontxt.Text);
                    cmd.Parameters.AddWithValue("@Priority", PriorityLeveltxt.Text);
                    cmd.Parameters.AddWithValue("@Lead", TaskLeadtxt.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }

            
            }

            this.Close();
            
            
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TableTab = TabConTables.SelectedIndex;

        }
    }
}
