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
    public partial class AddBillDataAdmin : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);   
            conn.Open();
            if (!IsPostBack)
            {
                BindFlat();
            }


        }

        private void BindFlat()
        {
            //string query = "SELECT id, CONCAT(blockNumber, '-' ,flatNumber) AS FlatInfo FROM allotments";
            string query = "SELECT flatNumber FROM allotments";
            SqlCommand cmd = new SqlCommand(query, conn);
                
            SqlDataReader reader = cmd.ExecuteReader();
            DropDownList1.DataSource = reader;
            DropDownList1.DataTextField = "flatNumber"; 
            DropDownList1.DataValueField = "flatNumber";      
            DropDownList1.DataBind();

            DropDownList1.Items.Insert(0, new ListItem("Select Option", "Selected Option"));
            DropDownList1.Items[0].Selected = true;
            DropDownList1.Items[0].Attributes.Add("disabled", "true");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string billTitle = TextBox1.Text;
            string flatInfo = DropDownList1.SelectedValue; // Concatenated flat info
            string amount = TextBox2.Text;
            string month = TextBox3.Text;

            string query = "INSERT INTO bills (billTitle, flatNumber, billAmount, billMonth) VALUES (@BillTitle, @FlatInfo, @Amount, @Month)";


            SqlCommand cmd = new SqlCommand(query, conn);
                
            cmd.Parameters.AddWithValue("@BillTitle", billTitle);
            cmd.Parameters.AddWithValue("@FlatInfo", flatInfo);
            cmd.Parameters.AddWithValue("@Amount", amount);
            cmd.Parameters.AddWithValue("@Month", month);

            cmd.ExecuteNonQuery();


            string allotedTo = null;
            string query1 = $"Select allotedTo from allotments where flatNumber='{flatInfo}'";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.Read())
            {
                allotedTo = reader1["allotedTo"].ToString();
            }

            string seen = null;
            string query2 = $"insert into notification values('Bill','{allotedTo}','{flatInfo}','{billTitle}','Not Paid','{seen}')";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            cmd2.ExecuteNonQuery();
            Response.Write("<script>alert('Bill Added Successfully!');</script>");
            Response.Redirect("BillManagementAdmin.aspx");

        }
    }
}