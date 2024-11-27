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
    public partial class VisitorManagementAdmin : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();


            if (!IsPostBack)
            {

                LoadVisitorData();
            }
        }
        protected void LoadVisitorData()
        {

            string q = "SELECT * FROM visitors";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string visitorId = e.CommandArgument.ToString();
            if (e.CommandName == "View")
            {
                // Retrieve the Visitor ID from CommandArgument

                // Redirect to view_visitor.aspx with the Visitor ID as query string
                Response.Redirect($"ViewVisitorAdmin.aspx?id={visitorId}");
            }
            else if (e.CommandName == "Edit")
            {
                Response.Redirect($"EditVisitorAdmin.aspx?id={visitorId}");
            }
            else if (e.CommandName == "Delete")
            {
                DeleteVisitor(visitorId);
            }
        }

        private void DeleteVisitor(string visitorId)
        {
            SqlCommand cmd1 = new SqlCommand("Select visitorName,flatNumber FROM visitors WHERE id = @id", conn);
            cmd1.Parameters.AddWithValue("@id", visitorId);
            SqlDataReader reader = cmd1.ExecuteReader();
            string visitorname = null;
            string flatnumber = null;
            if (reader.Read())
            {
                visitorname = reader["visitorName"].ToString() + " wants to meet";
                flatnumber = reader["flatNumber"].ToString();
            }

            SqlCommand cmd2 = new SqlCommand($"DELETE FROM notification WHERE notificationMessage = '{visitorname}' AND flatNumber = '{flatnumber}'", conn);
            cmd2.ExecuteNonQuery();

            SqlCommand cmd = new SqlCommand("DELETE FROM visitors WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", visitorId);
            cmd.ExecuteNonQuery();

            Response.Redirect("VisitorManagementAdmin.aspx");
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Find the Status field value
                string status = DataBinder.Eval(e.Row.DataItem, "Status")?.ToString();

                // Find the Edit and Delete buttons in the row
                Button btnEdit = (Button)e.Row.FindControl("btnEdit");
                Button btnDelete = (Button)e.Row.FindControl("btnDelete");

                // Disable Edit and Delete buttons if status is "OUT"
                if (status == "Out")
                {
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }
            }
        }

        protected string GetBadgeClass(string status)
        {
            switch (status)
            {
                case "In":
                    return "badge badge-success";
                case "Out":
                    return "badge badge-danger";
                default:
                    return "badge badge-secondary";
            }
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddVisitorAdmin.aspx");

        }
    }
}