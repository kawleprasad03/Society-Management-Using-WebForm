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
    public partial class EditBillAdmin : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                string billid = Request.QueryString["id"];
                LoadBillData(billid);
                BindFlat();
            }
        }

        private void LoadBillData(string billId)
        {
            string query = "SELECT billTitle, flatNumber, billAmount, billMonth FROM bills WHERE id = @Id";

            SqlCommand cmd = new SqlCommand(query, conn);
                
            cmd.Parameters.AddWithValue("@Id", billId);
                    
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TextBox1.Text = reader["billTitle"].ToString();
                DropDownList1.SelectedValue = reader["flatNumber"].ToString(); // Ensure the dropdown has the value loaded
                TextBox2.Text = reader["billAmount"].ToString();
                TextBox3.Text = reader["billMonth"].ToString();
            }
                
            
        }
        private void BindFlat()
        {
            // string query = "SELECT id, CONCAT(blockNumber, '-' ,flatNumber) AS FlatInfo FROM allotments";
            string query = "SELECT flatNumber FROM allotments";
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            DropDownList1.DataSource = reader;
            DropDownList1.DataTextField = "flatNumber";
            DropDownList1.DataValueField = "flatNumber";
            DropDownList1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string billid = Request.QueryString["id"];
            string billTitle = TextBox1.Text;
            string flatInfo = DropDownList1.SelectedValue; // Concatenated flat info
            string amount = TextBox2.Text;
            string month = TextBox3.Text;
            string query = "UPDATE bills SET billTitle = @BillTitle, flatNumber = @FlatNumber, billAmount = @BillAmount, billMonth = @BillMonth WHERE id = @Id";


            SqlCommand cmd = new SqlCommand(query, conn);
                    
            cmd.Parameters.AddWithValue("@Id", billid);
            cmd.Parameters.AddWithValue("@BillTitle", billTitle);
            cmd.Parameters.AddWithValue("@FlatNumber", flatInfo);
            cmd.Parameters.AddWithValue("@BillAmount", amount);
            cmd.Parameters.AddWithValue("@BillMonth", month);

                        
            cmd.ExecuteNonQuery();



            Response.Write("<script>alert('Updated Successfully!')</script>");

            LoadBillData(billid);
            Response.Redirect("BillManagementAdmin.aspx");

        }

    }
}