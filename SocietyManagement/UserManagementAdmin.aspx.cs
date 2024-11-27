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
    public partial class UserManagementAdmin : System.Web.UI.Page
    {
        SqlConnection conn;

        public object UserId { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                LoadUsersData();
            }
        }

        private void LoadUsersData()
        {


            using (SqlCommand cmd = new SqlCommand("SELECT * FROM users", conn))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridViewFlats.DataSource = dt;
                    GridViewFlats.DataBind();
                }
            }

        }

        protected void GridViewFlats_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int flatId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Edit")
            {
                int userId = Convert.ToInt32(e.CommandArgument);
                // Redirect to EditUsers.aspx with the userId as a query parameter
                Response.Redirect("EditUserAdmin.aspx?Id=" + userId);
            }

            else if (e.CommandName == "Delete")
            {

                DeleteUser(flatId);
                LoadUsersData();
                Response.Redirect("UserManagementAdmin.aspx");
            }
        }

        private void DeleteUser(int id)
        {
            SqlCommand cmdd = new SqlCommand($"select email from users where id = '{id}'", conn);
            SqlDataReader reader1 = cmdd.ExecuteReader();
            string userEmail = null;
            if (reader1.Read())
            {
                userEmail = reader1["email"].ToString();
            }


            SqlCommand cmd1 = new SqlCommand($"select flatNumber from allotments where allotedTo = '{userEmail}'", conn);
            SqlDataReader reader = cmd1.ExecuteReader();
            string flatNumber = null;
            if (reader.Read())
            {
                flatNumber = reader["flatNumber"].ToString();
            }

            if (flatNumber != null)
            {
                SqlCommand cmd2 = new SqlCommand($"delete from bills where flatNumber = '{flatNumber}'", conn);
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand($"delete from complaints where flatNumber = '{flatNumber}'", conn);
                cmd3.ExecuteNonQuery();

                SqlCommand cmd4 = new SqlCommand($"delete from visitors where flatNumber = '{flatNumber}'", conn);
                cmd4.ExecuteNonQuery();

                SqlCommand cmd5 = new SqlCommand($"delete from notification where flatNumber = '{flatNumber}'", conn);
                cmd5.ExecuteNonQuery();

                SqlCommand cmd6 = new SqlCommand($"DELETE FROM allotments WHERE flatNumber = '{flatNumber}'", conn);
                cmd6.ExecuteNonQuery();
            }


            using (SqlCommand cmd = new SqlCommand("DELETE FROM users WHERE Id = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddUserAdmin.aspx");
        }
    }
}