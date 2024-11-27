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
    public partial class EditComplaintUser : System.Web.UI.Page
    {

        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(connStr);
            conn.Open();

            if (!IsPostBack)
            {
                // Check if the ComplaintId is passed in the query string
                if (Request.QueryString["id"] != null)
                {
                    int complaintId = Convert.ToInt32(Request.QueryString["id"]);
                    LoadComplaintData(complaintId);
                }
                else
                {
                    // Redirect back if no complaint ID is provided
                    Response.Redirect("ComplaintManagement.aspx");
                }
            }
        }

        private void LoadComplaintData(int complaintId)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Complaints WHERE id = @ComplaintId", conn);
            cmd.Parameters.AddWithValue("@ComplaintId", complaintId);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                // Populate the form fields with the existing complaint data
                lblComplaintIdValue.Text = reader["id"].ToString();
                txtComplaint.Text = reader["complaintDescription"].ToString();
                // Status section removed from here
            }
            reader.Close();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int complaintId = Convert.ToInt32(lblComplaintIdValue.Text);
            string complaintDescription = txtComplaint.Text;

            SqlCommand cmd1 = new SqlCommand("Select complaintDescription,flatNumber FROM Complaints WHERE id = @id", conn);
            cmd1.Parameters.AddWithValue("@id", complaintId);
            SqlDataReader reader = cmd1.ExecuteReader();
            string complaintDescriptionOld = null;
            string flatnumber = null;
            if (reader.Read())
            {
                complaintDescriptionOld = reader["complaintDescription"].ToString();
                flatnumber = reader["flatNumber"].ToString();
            }


            SqlCommand cmd2 = new SqlCommand($"UPDATE notification SET notificationMessage = '{complaintDescription}' WHERE notificationMessage = '{complaintDescriptionOld}' AND flatNumber = '{flatnumber}'", conn);
            cmd2.ExecuteNonQuery();

            SqlCommand cmd = new SqlCommand("UPDATE Complaints SET complaintDescription = @ComplaintDescription WHERE id = @ComplaintId", conn);
            cmd.Parameters.AddWithValue("@ComplaintId", complaintId);
            cmd.Parameters.AddWithValue("@ComplaintDescription", complaintDescription);

            cmd.ExecuteNonQuery();

            // Redirect to the complaint management page after saving the changes
            Response.Redirect("CompliantManagementUser.aspx");
        }

        //protected void Page_Unload(object sender, EventArgs e)
        //{
        //    if (conn != null && conn.State == System.Data.ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }
        //}
    }
}