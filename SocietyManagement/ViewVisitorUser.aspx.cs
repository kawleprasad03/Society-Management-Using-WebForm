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
    public partial class ViewVisitorUser : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                string visitorId = Request.QueryString["id"];
                string notificationid = Request.QueryString["notifid"];
                if (!string.IsNullOrEmpty(visitorId))
                {
                    DisplayVisitorData(visitorId);
                }
                if (!string.IsNullOrEmpty(notificationid))
                {
                    SqlCommand cmd6 = new SqlCommand($"update notification set seen = 'View' where id = '{notificationid}'", conn);
                    cmd6.ExecuteNonQuery();
                }
            }
        }

        private void DisplayVisitorData(string visitorId)
        {
            

            // SQL query to get the visitor's details by ID
            string query = $"SELECT flatNumber, visitorName, visitorPhone, personToVisit, inTime,outTime, outRemark, address, reasonToVisit, status, createdAtDate FROM visitors WHERE  id = '{visitorId}'";


            SqlCommand cmd = new SqlCommand(query, conn);



            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                // Bind data to labels
                lblFlatNumber.Text = reader["flatNumber"].ToString();
                lblVisitorName.Text = reader["visitorName"].ToString();
                lblVisitorPhone.Text = reader["visitorPhone"].ToString();
                lblPersonToVisit.Text = reader["personToVisit"].ToString();
                lblInTime.Text = reader["inTime"].ToString();
                //lblAddress.Text = reader["address"].ToString();
                lblReasonToVisit.Text = reader["reasonToVisit"].ToString();
                lblStatus.Text = reader["status"].ToString();
                lblCreatedAtDate.Text = reader["createdAtDate"].ToString();

                // Conditionally display outTime and outRemark
                if (reader["status"].ToString() == "Out")
                {
                    lblOutTime.Text = reader["outTime"].ToString();
                    lblOutRemark.Text = reader["outRemark"].ToString();
                    panelOutDetails.Visible = true; // Show the panel
                }
                else
                {
                    panelOutDetails.Visible = false; // Hide the panel
                }
            }
            else
            {
                // Handle case where visitor ID is not found
                lblError.Text = "Visitor not found.";
            }

        }
    }
}