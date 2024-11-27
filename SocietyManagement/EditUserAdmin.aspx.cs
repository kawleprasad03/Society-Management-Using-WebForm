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
    public partial class EditUserAdmin : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                // Check if there's a user ID in the query string
                if (Request.QueryString["Id"] != null)
                {
                    int userId;
                    if (int.TryParse(Request.QueryString["Id"], out userId))
                    {
                        LoadUserDetails(userId);
                        ViewState["UserId"] = userId; // Save ID in ViewState for later use
                    }
                }
            }
        }

        // Load user details from the database based on the user ID
        private void LoadUserDetails(int userId)
        {
            string query = "SELECT userName, email, password, urole FROM users WHERE id = @Id";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", userId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtusersname.Text = reader["userName"].ToString();
                        txtemail.Text = reader["email"].ToString();
                        txtpass.Text = reader["password"].ToString();
                        //txtrole.Text = reader["urole"].ToString();
                    }
                }
            }
        }

        // Event handler for the Edit Users button click
        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (ViewState["UserId"] != null)
            {
                int userId = (int)ViewState["UserId"];

                string userName = txtusersname.Text.Trim();
                string email = txtemail.Text.Trim();
                string password = txtpass.Text.Trim();
                //string role = txtrole.Text.Trim();

                // Validation
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    // Alert if any field is empty
                    Response.Write("<script>alert('All fields must be filled out.');</script>");
                    return;
                }

                // Update the user details in the database
                string query = "UPDATE users SET userName = @userName, email = @email, password = @password WHERE id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    //cmd.Parameters.AddWithValue("@urole", role);
                    cmd.Parameters.AddWithValue("@Id", userId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Redirect to the users list page (or wherever you'd like after updating)
                        Response.Redirect("UserManagementAdmin.aspx");
                    }
                    else
                    {
                        // Alert if update failed
                        Response.Write("<script>alert('Update failed. Please try again.');</script>");
                    }
                }
            }
        }
    }
}