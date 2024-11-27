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
    public partial class ViewBillAdmin : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            string billId = Request.QueryString["id"];
            string notificationid = Request.QueryString["notifid"];
            if (!IsPostBack)
            {
           
                LoadBillData(billId);
                if (!string.IsNullOrEmpty(notificationid))
                {
                    SqlCommand cmd6 = new SqlCommand($"update notification set seen = 'View' where id = '{notificationid}'", conn);
                    cmd6.ExecuteNonQuery();
                }

            }
        }

        private void LoadBillData(string billId)
        {
            string query = "SELECT billTitle, flatNumber, billAmount, billMonth, paidAmount, paymentDate, paymentMethod FROM bills WHERE id = @Id";

            
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", billId);

              
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                LabelBillTitleValue.Text = reader["billTitle"].ToString();
                LabelFlatNumberValue.Text = reader["flatNumber"].ToString();
                LabelBillAmountValue.Text = reader["billAmount"].ToString();
                LabelBillMonthValue.Text = reader["billMonth"].ToString();

                // Check if paidAmount, paymentDate, and paymentMethod have values
                if (!DBNull.Value.Equals(reader["paidAmount"]) && !DBNull.Value.Equals(reader["paymentDate"]) && !DBNull.Value.Equals(reader["paymentMethod"]))
                {
                    LabelPaidAmountValue.Text = reader["paidAmount"].ToString();
                    LabelPaymentDateValue.Text = reader["paymentDate"].ToString();
                    LabelPaymentMethodValue.Text = reader["paymentMethod"].ToString();

                    // Make the payment details panel visible
                    PanelPaymentDetails.Visible = true;
                }
            }
            else
            {
                Response.Write("<script>alert('Bill not found');</script>");
                Response.Redirect("BillList.aspx"); // Redirect if no data is found
            }
        }
        
    }
}