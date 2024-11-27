using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VisualStudioConfiguration;

namespace SocietyManagement
{
    public partial class invoice : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
                conn = new SqlConnection(cs);
                conn.Open();
                if (Request.QueryString["billid"] != null)
                {
                    int billId = Convert.ToInt32(Request.QueryString["billid"]);
                    int notificationid = Convert.ToInt32(Request.QueryString["notifid"]);
                    string paymentAmount = Session["paymentAmount"].ToString();
                    string paymentdate = Session["paymentdate"].ToString();
                    string paymentmode = Session["paymentmode"].ToString();

                    SqlCommand cmd = new SqlCommand($"UPDATE bills SET paidAmount = '{paymentAmount}', paymentDate = '{paymentdate}', paymentMethod = '{paymentmode}' WHERE id = '{billId}'",conn);
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand($"UPDATE notification SET status = 'Paid' WHERE id = '{notificationid}'", conn);
                    cmd1.ExecuteNonQuery();
                    LoadBillDetails(billId);


                    SqlCommand cmd2 = new SqlCommand($"select * from bills WHERE id = '{billId}'", conn);
                    SqlDataReader reader = cmd2.ExecuteReader();
                    string billtitle = null;
                    string flatnumber = null;
                    string billAmount = null;
                    string paidAmount = null;
                    string paymentDate = null;
                    string paymentMethod = null;
                    string billMonth = null;
                    if (reader.Read()) {
                        billtitle = reader["billTitle"].ToString();
                        flatnumber = reader["flatNumber"].ToString();
                        billAmount = reader["billAmount"].ToString();
                        paidAmount = reader["paidAmount"].ToString();
                        billMonth = reader["billMonth"].ToString();
                        paymentDate = reader["paymentDate"].ToString();
                        paymentMethod = reader["paymentMethod"].ToString();
                    }

                    string invoiceHtml = GenerateInvoiceHtml(flatnumber, billMonth, billtitle, paymentDate, billAmount, paidAmount, paymentMethod);

                    // Generate PDF from HTML and send email
                    byte[] pdfBytes = GeneratePdfFromHtml(invoiceHtml);
                    SendEmailWithAttachment(pdfBytes);
                }
            }
        }

        private void LoadBillDetails(int billId)
        {
           
                string query = @"SELECT billTitle, flatNumber, billAmount, paidAmount, billMonth, paymentDate, paymentMethod 
                             FROM bills 
                             WHERE id = @BillId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BillId", billId);

              
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Assign data to labels
                    LabelBillTitle.Text = reader["billTitle"].ToString();
                    LabelFlatNumber.Text = reader["flatNumber"].ToString();
                    LabelBillAmount.Text = reader["billAmount"].ToString();
                    LabelPaidAmount.Text = reader["paidAmount"].ToString();
                    LabelBillMonth.Text = reader["billMonth"].ToString();
                    LabelPaymentDate.Text = reader["paymentDate"].ToString();
                    LabelPaymentMethod.Text = reader["paymentMethod"].ToString();
                }

                
            
        }

        private string GenerateInvoiceHtml(string flatNumber, string billMonth, string billTitle, string paymentDate, string billAmount,string paidAmount,string paymentMethod)
        {

            //string name = null;
            //SqlCommand cmd = new SqlCommand($"select username from users where email = '{email}'", conn);
            //SqlDataReader reader = cmd.ExecuteReader();
            //if (reader.Read())
            //{
            //    name = reader["username"].ToString();
            //}
            Random random = new Random();
            int invoice_no = random.Next(1000, 9999);
            string s = @"
<style>
 body {
   font-family: Arial, sans-serif;
   background-color: #f4f4f4;
   padding: 20px;
 }

 .invoice {
   background-color: #fff;
   border-radius: 8px;
   box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
   padding: 30px;
   max-width: 600px;
   margin: 0 auto;
 }

 .invoice-header {
   border-bottom: 2px solid #f1f1f1;
   padding-bottom: 20px;
   margin-bottom: 20px;
   text-align: center;
 }

 .invoice-header h1 {
   font-size: 32px;
   margin: 0;
   color: #333;
 }

 .invoice-info {
   display: flex;
   justify-content: space-between;
   margin-bottom: 15px;
 }

 .invoice-info p {
   margin: 5px 0;
   color: #555;
 }

 .invoice-table {
   width: 100%;
   border-collapse: collapse;
   margin-bottom: 20px;
 }

 .invoice-table th, .invoice-table td {
   padding: 12px;
   border-bottom: 1px solid #f1f1f1;
   text-align: left;
 }

 .invoice-table th {
   background-color: blue;
   color: #fff;
   font-weight: bold;
 }

 .invoice-table td {
   color: #666;
 }

 .invoice-total {
   display: flex;
   justify-content: space-between;
   font-weight: bold;
   font-size: 18px;
   margin-top: 10px;
 }

 .footer {
   margin-top: 20px;
   text-align: center;
   color: #888;
   font-size: 14px;
 }
</style>

<body>
 <div class='invoice'>
   <div class='invoice-header'>
     <h1>Bill Invoice</h1>
   </div>
   <div class='invoice-info'>
     <p><strong>Invoice Number:</strong> BILL-" + $"{invoice_no}" + @"</p>
     <p><strong>Flat Number:</strong> " + $"{flatNumber}" + @"</p>
     <p><strong>Bill Date:</strong> " + $"{billMonth}" + @"</p>
   </div>
   <div class='invoice-info'>
     <p><strong>Bill Title:</strong> " + $"{billTitle}" + @"</p>
     <p><strong>Payment Date:</strong> " + $"{paymentDate}" + @"</p>
   </div>
   <table class='invoice-table'>
     <thead>
       <tr>
         <th>Bill Amount</th>
         <th>Paid Amount</th>
         <th>Payment Method</th>
       </tr>
     </thead>
     <tbody>
       <tr>
         <td>" + $"{billAmount}" + @"</td>
         <td>" + $"{paidAmount}" + @"</td>
         <td>" + $"{paymentMethod}" + @"</td>
       </tr>
     </tbody>
   </table>

   <div class='invoice-total'>
     <p><strong>Total Paid Amount:</strong></p>
     <p>" + $"{paidAmount}" + @"</p>
   </div>
 </div>
</body>
";


            return s;
        }


        private byte[] GeneratePdfFromHtml(string htmlContent)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                using (StringReader stringReader = new StringReader(htmlContent))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, stringReader);
                }

                document.Close();
                return memoryStream.ToArray();
            }
        }

        private void SendEmailWithAttachment(byte[] attachmentBytes)
        {
            //string email = Session["email"].ToString();
            string email = "kawleprasad03@gmail.com";
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("kawleprasad03@gmail.com");
            mailMessage.To.Add(email);
            mailMessage.Subject = "Fees Receipt";
            mailMessage.Body = "Please find the Fees Receipt attachment.";
            mailMessage.IsBodyHtml = true;

            // Attach PDF
            MemoryStream stream = new MemoryStream(attachmentBytes);
            mailMessage.Attachments.Add(new Attachment(stream, "Receipt.pdf", "application/pdf"));

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("kawleprasad03@gmail.com", "fzdo rrmf uhce iptx");
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(mailMessage);
                Response.Write("<script>alert('Invoice Sent Successfully');</script>");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                stream.Dispose();
                mailMessage.Dispose();
            }
        }


    }
}