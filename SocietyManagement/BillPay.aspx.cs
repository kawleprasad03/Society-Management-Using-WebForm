using Razorpay.Api;
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
    public partial class BillPay : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int billId = Convert.ToInt32(Request.QueryString["id"]);
                    LoadBillDetails(billId);
                }
            }
        }

        private void LoadBillDetails(int billId)
        {
            
                string query = @"SELECT id,billTitle, flatNumber, billAmount, billMonth, paidAmount, paymentDate, paymentMethod 
                             FROM bills 
                             WHERE id = @BillId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BillId", billId);

                
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                // Display data in labels
                HiddenField1.Value = reader["id"].ToString();
                    LabelBillTitleValue.Text = reader["billTitle"].ToString();
                    LabelFlatNumberValue.Text = reader["flatNumber"].ToString();
                    LabelBillAmountValue.Text = reader["billAmount"].ToString();
                    LabelBillMonthValue.Text = reader["billMonth"].ToString();

                    // Set default values for editable fields (TextBox and DropDownList)
                    TextBox1.Text = reader["billAmount"].ToString();
                    //TextBox2.Text = reader["paymentDate"].ToString();
                    //DropDownList1.SelectedValue = reader["paymentMethod"].ToString();
                }

              
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string billid = HiddenField1.Value;
            string paymentAmount = TextBox1.Text;
            string paymentdate = TextBox2.Text;
            string paymentmode = DropDownList1.SelectedValue;
            int notificationid = Convert.ToInt32(Request.QueryString["notifid"]);
            Session["paymentAmount"] = paymentAmount;
            Session["paymentdate"] = paymentdate;
            Session["paymentmode"] = paymentmode;
            if (paymentmode.Equals("Cash"))
            {
                Response.Redirect($"invoice.aspx?billid={billid}&notifid={notificationid}");
            }
            else if (paymentmode.Equals("Online"))
            {
                string keyId = "rzp_test_Kl7588Yie2yJTV";
                string keySecret = "6dN9Nqs7M6HPFMlL45AhaTgp";
              
                RazorpayClient razorpayClient = new RazorpayClient(keyId, keySecret);
                //int userId = 10;
                double amount = int.Parse(paymentAmount);

                string email = Session["email"].ToString();
                // Create an order
                Dictionary<string, object> options = new Dictionary<string, object>();
                options.Add("amount", amount * 100); // Amount should be in paisa (multiply by 100 for rupees)
                options.Add("currency", "INR");
                options.Add("receipt", "order_receipt_123");
                options.Add("payment_capture", 1); // Auto capture payment

                Razorpay.Api.Order order = razorpayClient.Order.Create(options);

                string orderId = order["id"].ToString();

                // Generate checkout form and redirect user to Razorpay payment page
                string razorpayScript = $@"
    var options = {{
        'key': '{keyId}',
        'amount': {amount * 100},
        'currency': 'INR',
        'name': 'Housing Society',
        'description': 'Checkout Payment',
        'order_id': '{orderId}',
        'handler': function(response) {{
           
     
            alert('Payment successful. Payment ID: ' + response.razorpay_payment_id);

           window.location.href = 'invoice.aspx?billid=' + '{billid}' + '&notifid=' + '{notificationid}';
        }},
        'prefill': {{
            'name': 'Krish Kheloji',
            'email': 'khelojikrish@gmail.com',
            'contact': '7208921898'
        }},
        'theme': {{
            'color': '#F37254'
        }}
    }};
    var rzp1 = new Razorpay(options);
    rzp1.open();";

                // Register the script on the page

                ClientScript.RegisterStartupScript(this.GetType(), "razorpayScript", razorpayScript, true);
            }
        }
    }
}