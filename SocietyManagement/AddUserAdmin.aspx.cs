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
    public partial class AddUserAdmin : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // Get the values from the textboxes
            //string userid = txtusersid.Text.Trim();
            string name = txtusersname.Text.Trim();
            string email = txtemail.Text.Trim();
            string pass = txtpass.Text.Trim();
            //string role = txtrole.Text.Trim();

            // Validate that none of the fields are empty
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
            {
                Response.Write("<script>alert('All fields must be filled out.');</script>");
                return;
            }

            // SQL Query to insert the data into the users table
            string query = "INSERT INTO users (userName, email, password, urole) " +
                           "VALUES (@userName, @email, @password, @urole)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Use .Text property to pass the value from TextBox controls
                cmd.Parameters.AddWithValue("@userName", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", pass);
                cmd.Parameters.AddWithValue("@urole", "User");

                // Execute the query
                cmd.ExecuteNonQuery();

                // Redirect to another page after successful insert
                Response.Redirect("UserManagementAdmin.aspx");
            }
        }
    }
}