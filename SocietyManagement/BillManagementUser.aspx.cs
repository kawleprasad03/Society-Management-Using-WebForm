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
    public partial class BillManagementUser : System.Web.UI.Page
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

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("AddBillDataAdmin.aspx");
        //}

        private void LoadBillsData()
        {

            string email = Session["email"].ToString();

            SqlCommand cmd1 = new SqlCommand($"select flatNumber from allotments where allotedTo='{email}'",conn);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            string flatnumber = null; 
            if (reader1.Read()) {
                flatnumber = reader1["flatNumber"].ToString();
            }


            string query = $"SELECT id, billTitle, flatNumber, billAmount, paidAmount, billMonth FROM bills WHERE flatNumber='{flatnumber}'";

            SqlCommand cmd = new SqlCommand(query, conn);


            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int billId = Convert.ToInt32(e.CommandArgument);

            //if (e.CommandName == "Edit")
            //{
            //    Response.Redirect($"EditBillAdmin.aspx?id={billId}");
            //}
            if (e.CommandName == "View")
            {
                Response.Redirect($"ViewBillUser.aspx?id={billId}");
            }
            //else if (e.CommandName == "Delete")
            //{
            //    DeleteBill(billId);
            //    LoadBillsData(); // Refresh data after deletion
            //    Response.Redirect("BillManagementAdmin.aspx");
            //}
        }


    }
}