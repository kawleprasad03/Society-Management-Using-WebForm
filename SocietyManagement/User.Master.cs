using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagement
{
    public partial class User : System.Web.UI.MasterPage
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                string userEmail = Session["email"].ToString();
                SqlCommand cmd = new SqlCommand($"select userName from users where email = '{userEmail}'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) {
                    Label1.Text = reader["userName"].ToString();
                }

                LoadNotifications();
            }
        }

        private void LoadNotifications()
        {
            string userEmail = Session["email"].ToString(); // Replace with the actual user email
            string query = @"SELECT id, notificationName, notificationMessage, status 
                     FROM notification 
                     WHERE notificationFor = @UserEmail
                     AND ((notificationName = 'Bill' AND status != 'Paid') 
                          OR (notificationName = 'Complaint' AND (status = 'Resolved' OR status = 'In Process') AND seen != 'View')
                          OR (notificationName = 'Visitor' AND (status = 'In' OR status = 'Out') AND seen != 'View'))";


            SqlCommand cmd = new SqlCommand(query, conn);
                
                cmd.Parameters.AddWithValue("@UserEmail", userEmail);
                   

                SqlDataReader reader = cmd.ExecuteReader();
                NotificationRepeater.DataSource = reader;
                NotificationRepeater.DataBind();
                
            
        }

        protected string GetNotificationLink(object notificationName, object id)
        {
            string pageUrl = "#";
            if (notificationName != null)
            {
                string name = notificationName.ToString();
                int notificationId = Convert.ToInt32(id);

                // Set the appropriate URL based on the notification type
                switch (name)
                {
                    case "Bill":
                        SqlCommand cmd4 = new SqlCommand($"select notificationFor,flatNumber,notificationMessage from notification where id = '{notificationId}'", conn);
                        SqlDataReader reader4 = cmd4.ExecuteReader();
                        string paymentform = null;
                        string flatNumberforbill = null;
                        string billdescription = null;
                        if (reader4.Read())
                        {
                            paymentform = reader4["notificationFor"].ToString();
                            flatNumberforbill = reader4["flatNumber"].ToString();
                            billdescription = reader4["notificationMessage"].ToString();
                        }

                        SqlCommand cmd5 = new SqlCommand($"select id from bills where flatNumber='{flatNumberforbill}' and billTitle = '{billdescription}'",conn);
                        SqlDataReader reader5 = cmd5.ExecuteReader();
                        string billid = null;
                        if (reader5.Read())
                        {
                            billid = reader5["id"].ToString();
                        }

                        pageUrl = $"BillPay.aspx?id={billid}&notifid={notificationId}";
                        break;
                    case "Complaint":

                        SqlCommand cmd = new SqlCommand($"select notificationFor,flatNumber,notificationMessage from notification where id = '{notificationId}'", conn);
                        SqlDataReader reader = cmd.ExecuteReader();
                        string username = null;
                        string flatNumber = null;
                        string description = null; 
                        if (reader.Read())
                        {
                            username = reader["notificationFor"].ToString();
                            flatNumber = reader["flatNumber"].ToString();
                            description = reader["notificationMessage"].ToString();
                        }

                        SqlCommand cmd1 = new SqlCommand($"select id from complaints where userName = '{username}' and flatNumber = '{flatNumber}' and complaintDescription = '{description}'", conn);
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        string cmpid = null;
                        if (reader1.Read())
                        {
                            cmpid = reader1["id"].ToString();
                          
                        }

                        pageUrl = $"ViewComplaintUser.aspx?id={cmpid}&notifid={notificationId}";
                        break;
                    case "Visitor":
                        SqlCommand cmd2 = new SqlCommand($"select notificationFor,flatNumber,notificationMessage from notification where id = '{notificationId}'", conn);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        string visitorfor = null;
                        string flatnumber = null;
                        string visitormessage = null;
                        if (reader2.Read())
                        {
                            visitorfor = reader2["notificationFor"].ToString();
                            flatnumber = reader2["flatNumber"].ToString();
                            visitormessage = reader2["notificationMessage"].ToString();
                        }

                        string[] args = visitormessage.Split(';');
                        string visitorname = args[0];

                        SqlCommand cmd3 = new SqlCommand($"select id from visitors where flatNumber = '{flatnumber}' and visitorName = '{visitorname}'", conn);
                        SqlDataReader reader3 = cmd3.ExecuteReader();
                        string visitorid = null;
                        if (reader3.Read())
                        {
                            visitorid = reader3["id"].ToString();

                        }

                       
                        pageUrl = $"ViewVisitorUser.aspx?id={visitorid}&notifid={notificationId}";
                        break;
                }
            }
            return pageUrl;
        }
    }
}