using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagement
{
    public partial class EditComplaintAdmin : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(connectionString);
            conn.Open();
            if (!IsPostBack)
            {
                int complaintId = Convert.ToInt32(Request.QueryString["id"]);
                if (complaintId > 0)
                {
                    LoadComplaintDetails(complaintId);
                }
            }
        }

        private void LoadComplaintDetails(int complaintId)
        {
            // Set your connection string here
           
                try
                {
                    // Query adjusted to match your table schema (comment, status, etc.)
                    string query = "SELECT userName, flatNumber, complaintDescription, status, comment FROM complaints WHERE id = @complaintId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@complaintId", complaintId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            lblUserName.Text = reader["userName"].ToString();
                            lblFlatNumber.Text = reader["flatNumber"].ToString();
                            lblComplaintDescription.Text = reader["complaintDescription"].ToString();
                            lblStatus.Text = reader["status"].ToString();
                            txtMasterComment.Text = reader["comment"].ToString(); // Pre-fill the comment textbox
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Complaint not found.";
                        lblMessage.CssClass = "text-danger";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error fetching data: " + ex.Message;
                    lblMessage.CssClass = "text-danger";
                }
            
        }

        protected void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            try
            {
                int complaintId = Convert.ToInt32(Request.QueryString["id"]); // Ensure correct parameter name is used here
                string status = ddlStatus.SelectedValue;
                string comment = txtMasterComment.Text; // Comment entered by the admin
                DateTime updatedAt = DateTime.Now;

                // Call the method to update the complaint status
                UpdateComplaintStatus(complaintId, status, comment, updatedAt);

                // Optionally, redirect back to the Complaint Management page
                Response.Redirect("ComplaintManagementAdmin.aspx");
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.CssClass = "text-danger";
            }
        }

        private void UpdateComplaintStatus(int complaintId, string status, string comment, DateTime updatedAt)
        {
           

            try
            {

                SqlCommand cmd1 = new SqlCommand("Select userName,complaintDescription,flatNumber FROM Complaints WHERE id = @id", conn);
                cmd1.Parameters.AddWithValue("@id", complaintId);
                SqlDataReader reader = cmd1.ExecuteReader();
                string complaintDescription = null;
                string flatnumber = null;
                string userName = null;
                if (reader.Read())
                {
                    userName = reader["userName"].ToString();
                    complaintDescription = reader["complaintDescription"].ToString();
                    flatnumber = reader["flatNumber"].ToString();
                }

                string seen = null;
                SqlCommand cmd2 = new SqlCommand($"UPDATE notification SET notificationFor = '{userName}',status = '{status}',seen = '{seen}' WHERE notificationMessage = '{complaintDescription}' AND flatNumber = '{flatnumber}'", conn);
                cmd2.ExecuteNonQuery();

                // Ensure the stored procedure matches your table structure
                SqlCommand cmd = new SqlCommand("UPDATE complaints SET status = @status, comment = @comment  WHERE id = @id", conn);
                    
                        
                
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@comment", comment); // Passing comment here
                cmd.Parameters.AddWithValue("@id", complaintId);
                //cmd.Parameters.AddWithValue("@updatedAtDate", updatedAt);

                       
                cmd.ExecuteNonQuery();  // Ensure this executes properly
                    
               



                lblMessage.Text = "Complaint status updated successfully.";
                lblMessage.CssClass = "text-success";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error updating complaint status: " + ex.Message;
                lblMessage.CssClass = "text-danger";
            }
        }
    }
}