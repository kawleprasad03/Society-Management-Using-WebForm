using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagement
{
    public partial class AdminHome : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                CountFlats();
                CountBills();
                CountAllotements();
                CountVisitors();
                CountComplaints();
                CountResolveComplaints();
                CountUnResolveComplaints();
                CountInProgressComplaints();
            }
        }

        private void CountFlats()
        {
            
            string query = "SELECT COUNT(*) AS TotalFlats FROM flats";

          
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    
                    int totalFlats = (int)cmd.ExecuteScalar();
                    Label1.Text = totalFlats.ToString();
                }
                catch (Exception ex)
                {
                    // Handle exception (optional)
                }
            
        }

        private void CountBills()
        {
            
            string query = "SELECT COUNT(*) AS TotalBills FROM bills";

          
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    
                    int totalBills = (int)cmd.ExecuteScalar();
                    Label2.Text = totalBills.ToString();
                }
                catch (Exception ex)
                {
                    // Handle exception (optional)
                }
            
        }

        private void CountAllotements()
        {
            string query = "SELECT COUNT(*) AS TotalAllotments FROM allotments";


            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {

                int TotalAllotments = (int)cmd.ExecuteScalar();
                Label3.Text = TotalAllotments.ToString();
            }
            catch (Exception ex)
            {
                // Handle exception (optional)
            }
        }

         private void CountVisitors()
        {
            string query = "SELECT COUNT(*) AS TotalVisitors FROM visitors";


            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {

                int TotalVisitors = (int)cmd.ExecuteScalar();
                Label4.Text = TotalVisitors.ToString();
            }
            catch (Exception ex)
            {
                // Handle exception (optional)
            }
        }

        private void CountComplaints()
        {
            string query = "SELECT COUNT(*) AS TotalComplaints FROM complaints";


            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {

                int TotalComplaints = (int)cmd.ExecuteScalar();
                Label5.Text = TotalComplaints.ToString();
            }
            catch (Exception ex)
            {
                // Handle exception (optional)
            }
        }

        private void CountResolveComplaints()
        {
            string query = "SELECT COUNT(*) AS TotalComplaints FROM complaints WHERE status = 'Resolved'";


            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {

                int TotalComplaints = (int)cmd.ExecuteScalar();
                Label6.Text = TotalComplaints.ToString();
            }
            catch (Exception ex)
            {
                // Handle exception (optional)
            }
        }

        private void CountUnResolveComplaints()
        {
            string query = "SELECT COUNT(*) AS TotalComplaints FROM complaints WHERE status = 'Pending'";


            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {

                int TotalComplaints = (int)cmd.ExecuteScalar();
                Label7.Text = TotalComplaints.ToString();
            }
            catch (Exception ex)
            {
                // Handle exception (optional)
            }
        }

        private void CountInProgressComplaints()
        {
            string query = "SELECT COUNT(*) AS TotalComplaints FROM complaints WHERE status = 'In Process'";


            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {

                int TotalComplaints = (int)cmd.ExecuteScalar();
                Label8.Text = TotalComplaints.ToString();
            }
            catch (Exception ex)
            {
                // Handle exception (optional)
            }
        }
    }
}