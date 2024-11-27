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
    public partial class ViewComplaintUser : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(connString);
            conn.Open();

            if (!IsPostBack)
            {
                int complaintId = Convert.ToInt32(Request.QueryString["id"]);
                string notificationid = Request.QueryString["notifid"];
                if (complaintId > 0)
                {
                    LoadComplaintDetails(complaintId);
                    LoadComments(complaintId);
                }
                if (!string.IsNullOrEmpty(notificationid))
                {
                    SqlCommand cmd6 = new SqlCommand($"update notification set seen = 'View' where id = '{notificationid}'", conn);
                    cmd6.ExecuteNonQuery();
                }
            }
        }

        private void LoadComplaintDetails(int complaintId)
        {
            try
            {
                string query = "SELECT userName, flatNumber, complaintDescription, status FROM complaints WHERE id = @complaintId";
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
                    }
                }
                else
                {
                    lblMessage.Text = "Complaint not found.";
                    lblMessage.CssClass = "text-danger";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error fetching data: " + ex.Message;
                lblMessage.CssClass = "text-danger";
            }
        }

        private void LoadComments(int complaintId)
        {
            try
            {
                string query = "SELECT comment, createdAtDate FROM complaints WHERE id = @complaintId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@complaintId", complaintId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptComments.DataSource = dt;
                rptComments.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error fetching comments: " + ex.Message;
                lblMessage.CssClass = "text-danger";
            }
        }

        //protected void Page_Unload(object sender, EventArgs e)
        //{
        //    if (conn != null && conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }
        //}
    }
}