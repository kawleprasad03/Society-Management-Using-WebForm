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
    public partial class AddComplaintUser : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();
        }

        protected void btnAddComplaint_Click(object sender, EventArgs e)
        {
            // Assuming user data is available in session
            //string userName = Session["UserName"]?.ToString() ?? "Anonymous";
            //string flatNumber = Session["FlatNumber"]?.ToString() ?? "Unknown";  

            string userName = Session["email"].ToString();
            string flatNumber = null;
            string q = $"Select flatNumber from allotments where allotedTo='{userName}'";
            SqlCommand cmd1 = new SqlCommand(q, conn);
            SqlDataReader reader = cmd1.ExecuteReader();
            if (reader.Read()) 
            {
                flatNumber = reader["flatNumber"].ToString();
            }

            string complaintDescription = txtComplaintDescription.Text.Trim();
            string status = "Pending";
            string createdAtDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Insert the complaint into the database
            string query = "INSERT INTO complaints (userName, flatNumber, complaintDescription, status, createdAtDate) " +
                           "VALUES (@userName, @flatNumber, @complaintDescription, @status, @createdAtDate)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.Parameters.AddWithValue("@flatNumber", flatNumber);
            cmd.Parameters.AddWithValue("@complaintDescription", complaintDescription);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@createdAtDate", createdAtDate);

            cmd.ExecuteNonQuery();


            string complaintfor = "Admin@gmail.com";
            string seen = null;
            string query2 = $"insert into notification values('Complaint','{complaintfor}','{flatNumber}','{complaintDescription}','{status}','{seen}')";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            cmd2.ExecuteNonQuery();
           
            Response.Redirect("CompliantManagementUser.aspx");
        }
    }
}