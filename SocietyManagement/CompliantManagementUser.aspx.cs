using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagement
{
    public partial class CompliantManagementUser : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(connectionString);
            conn.Open();

            if (!IsPostBack)
            {
                LoadComplaints();
            }
        }

        private void LoadComplaints()
        {
            string userName = Session["email"].ToString();
            // Query to fetch complaints along with the status and creation date
            SqlDataAdapter da = new SqlDataAdapter($"SELECT id, userName, flatNumber, complaintDescription, status, createdAtDate FROM Complaints WHERE userName='{userName}'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvAdminComplaints.DataSource = dt;
            gvAdminComplaints.DataBind();
        }

        protected void gvAdminComplaints_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Retrieve the "status" field value from the DataTable
                string status = DataBinder.Eval(e.Row.DataItem, "status").ToString();

                // Find the Edit and Delete buttons in the GridView row
                Button btnEdit = (Button)e.Row.FindControl("btnEdit");
                Button btnDelete = (Button)e.Row.FindControl("btnDelete");

                // Conditionally hide Edit and Delete buttons based on status
                if (status == "In Process" || status == "Resolved")
                {
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }
            }
        }


        protected void gvAdminComplaints_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int complaintId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "View")
            {
                // Redirect to AdminViewComplaint.aspx with the complaint ID
                Response.Redirect("ViewComplaintUser.aspx?id=" + complaintId);
            }
            else if (e.CommandName == "Edit")
            {
                // Redirect to EditComplaint.aspx with the complaint ID
                Response.Redirect("EditComplaintUser.aspx?id=" + complaintId);
            }
            else if (e.CommandName == "Delete")
            {
                // Delete the complaint
                DeleteComplaint(complaintId);
                LoadComplaints(); // Reload the grid after deletion
            }
        }

        protected string GetBadgeClass(string status)
        {
            switch (status)
            {
                case "Pending":
                    return "badge badge-danger";
                case "Resolved":
                    return "badge badge-primary";
                case "In Process":
                    return "badge badge-warning";
                default:
                    return "badge badge-secondary";
            }
        }


        //protected void gvAdminComplaints_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        string status = DataBinder.Eval(e.Row.DataItem, "status").ToString();

        //        // Hide Edit and Delete buttons if the complaint is resolved
        //        if (status == "Resolved")
        //        {
        //            Button btnEdit = (Button)e.Row.FindControl("btnEdit");
        //            Button btnDelete = (Button)e.Row.FindControl("btnDelete");

        //            if (btnEdit != null) btnEdit.Visible = false;
        //            if (btnDelete != null) btnDelete.Visible = false;
        //        }
        //    }
        //}

        private void DeleteComplaint(int complaintId)
        {
            SqlCommand cmd1 = new SqlCommand("Select complaintDescription,flatNumber FROM Complaints WHERE id = @id", conn);
            cmd1.Parameters.AddWithValue("@id", complaintId);
            SqlDataReader reader = cmd1.ExecuteReader();
            string complaintDescription = null;
            string flatnumber = null;
            if (reader.Read()) {
                complaintDescription = reader["complaintDescription"].ToString();
                flatnumber = reader["flatNumber"].ToString();
            }

            SqlCommand cmd2 = new SqlCommand($"DELETE FROM notification WHERE notificationMessage = '{complaintDescription}' AND flatNumber = '{flatnumber}'", conn);
            cmd2.ExecuteNonQuery();

            SqlCommand cmd = new SqlCommand("DELETE FROM Complaints WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", complaintId);
            cmd.ExecuteNonQuery();

            Response.Redirect("CompliantManagementUser.aspx");
        }

        //protected void Page_Unload(object sender, EventArgs e)
        //{
        //    if (conn != null && conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddComplaintUser.aspx");
        }
    }
}