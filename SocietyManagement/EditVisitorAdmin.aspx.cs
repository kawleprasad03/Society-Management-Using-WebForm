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
    public partial class EditVisitorAdmin : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                string visitorId = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(visitorId))
                {
                    LoadVisitorDetails(visitorId);

                    //if (lblStatus.Text == "OUT")
                    //{
                    //    DisableEditing();
                    //    //Session["VisitorEditingCompleted"] = true;
                    //}

                }
            }
        }

        private void LoadVisitorDetails(string visitorId)
        {
            // Fetch visitor details from the database using visitorId

            string query = "SELECT FlatNumber, VisitorName, VisitorPhone, personToVisit, InTime, reasonToVisit,outTime,outRemark,status FROM Visitors WHERE id = @VisitorID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@VisitorID", visitorId);
            //conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lblFlatNumber.Text = reader["FlatNumber"].ToString();
                lblVisitorName.Text = reader["VisitorName"].ToString();
                lblVisitorPhone.Text = reader["VisitorPhone"].ToString();
                lblPersonToMeet.Text = reader["personToVisit"].ToString();
                lblInTime.Text = Convert.ToDateTime(reader["InTime"]).ToString("yyyy-MM-dd HH:mm:ss");
                lblReasonToVisit.Text = reader["reasonToVisit"].ToString();
                txtOutTime.Text = reader["outTime"].ToString();
                txtOutRemark.Text = reader["outRemark"].ToString();
                lblStatus.Text = reader["status"].ToString();
            }
            reader.Close();
        }
        //private void DisableEditing()
        //{
        //    txtOutTime.Enabled = false;
        //    txtOutRemark.Enabled = false;
        //    btnSave.Enabled = false;

        //    // Store a flag in the session to indicate that editing has been completed for this visitor
        //    Session["VisitorEditingCompleted"] = true;
        //}


        protected void btnSave_Click(object sender, EventArgs e)
        {
            string visitorId = Request.QueryString["id"];
            string outTime = txtOutTime.Text;
            string outRemark = txtOutRemark.Text;


            SqlCommand cmd1 = new SqlCommand("Select visitorName,flatNumber FROM visitors WHERE id = @id", conn);
            cmd1.Parameters.AddWithValue("@id", visitorId);
            SqlDataReader reader = cmd1.ExecuteReader();
            string visitorname = null;
            string flatnumber = null;
            if (reader.Read())
            {
                visitorname = reader["visitorName"].ToString();
                flatnumber = reader["flatNumber"].ToString();
            }

            if (!string.IsNullOrEmpty(visitorId) && !string.IsNullOrEmpty(outTime) && !string.IsNullOrEmpty(outRemark))
            {

                string updateQuery = "UPDATE Visitors SET status='Out', OutTime = @OutTime, OutRemark = @OutRemark WHERE id = @VisitorID";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@OutTime", outTime);
                cmd.Parameters.AddWithValue("@OutRemark", outRemark);
                cmd.Parameters.AddWithValue("@VisitorID", visitorId);
                //conn.Open();
                cmd.ExecuteNonQuery();

                //DisableEditing();
                // Redirect or show a success message
                //Response.Redirect("Visitor.aspx");

                string status = "Out";
                string seen = null;
                SqlCommand cmd2 = new SqlCommand($"UPDATE notification SET notificationMessage = '{visitorname};Gone',status = '{status}',seen = '{seen}'  WHERE notificationMessage = '{visitorname}; wants to meet' AND flatNumber = '{flatnumber}'", conn);
                cmd2.ExecuteNonQuery();
                Response.Redirect("VisitorManagementAdmin.aspx");
            }
            else
            {
                Response.Write("<script>alert('Please enter OutTime and Remark')</script>");
                // Show an error message if outTime is missing
                // You could use a label to display this error
            }
        }
    }
}