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
    public partial class BillManagementAdmin : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                LoadBillsData();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBillDataAdmin.aspx");
        }

        private void LoadBillsData()
        {
            string query = "SELECT id, billTitle, flatNumber, billAmount, paidAmount, billMonth FROM bills";

            SqlCommand cmd = new SqlCommand(query, conn);
                
                   
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
                
            
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int billId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Edit")
            {
                Response.Redirect($"EditBillAdmin.aspx?id={billId}");
            }
            else if (e.CommandName == "View")
            {
                Response.Redirect($"ViewBillAdmin.aspx?id={billId}");
            }
            else if (e.CommandName == "Delete")
            {
                DeleteBill(billId);
                LoadBillsData(); // Refresh data after deletion
                Response.Redirect("BillManagementAdmin.aspx");
            }
        }

       


        private void DeleteBill(int billId)
        {
            SqlCommand cmd1 = new SqlCommand("Select billTitle,flatNumber FROM bills WHERE id = @id", conn);
            cmd1.Parameters.AddWithValue("@id", billId);
            SqlDataReader reader = cmd1.ExecuteReader();
            string billDescription = null;
            string flatnumber = null;
            if (reader.Read())
            {
                billDescription = reader["billTitle"].ToString();
                flatnumber = reader["flatNumber"].ToString();
            }

            SqlCommand cmd2 = new SqlCommand($"DELETE FROM notification WHERE notificationMessage = '{billDescription}' AND flatNumber = '{flatnumber}'", conn);
            cmd2.ExecuteNonQuery();

            string query = "DELETE FROM bills WHERE id = @Id";

            SqlCommand cmd = new SqlCommand(query, conn);
                
            cmd.Parameters.AddWithValue("@Id", billId);
                    
            cmd.ExecuteNonQuery();
                
            
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Retrieve the "paidAmount" field value from the DataTable
                string paidAmount = DataBinder.Eval(e.Row.DataItem, "paidAmount").ToString();

                // Find the Edit and Delete buttons in the GridView row
                Button btnEdit = (Button)e.Row.FindControl("btnEdit");
                Button btnDelete = (Button)e.Row.FindControl("btnDelete");

                // Conditionally hide Edit and Delete buttons if paidAmount is not empty
                if (!string.IsNullOrEmpty(paidAmount))
                {
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }
            }
        }

        //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1.PageIndex = e.NewPageIndex;
        //    LoadBillsData(); // Rebind the data for the new page
        //}

    }
}