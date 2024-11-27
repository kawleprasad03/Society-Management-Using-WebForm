using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocietyManagement
{
    public partial class AddVisitorAdmin : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                fetchFlat();
            }
        }


        public void fetchFlat()
        {
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


        protected void btnSave_Click(object sender, EventArgs e)
        {
            string flatNumber = DropDownList1.SelectedValue;

            SqlCommand cmd1 = new SqlCommand($"select allotedTo from allotments where flatNumber = '{flatNumber}'", conn);
            SqlDataReader reader = cmd1.ExecuteReader();
            string notificatiofor = null;
            if (reader.Read()) {

                notificatiofor = reader["allotedTo"].ToString();
            }

            string createdAtDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //string q = "\"INSERT INTO Visitors (FlatNumber, VisitorName, VisitorPhone, PersonToMeet, InTime, OutTime, Status) VALUES (@FlatNumber, @VisitorName, @VisitorPhone, @PersonToMeet, @InTime, @OutTime, @Status)";
            string q = "INSERT INTO visitors (flatNumber, visitorName, visitorPhone, personToVisit, inTime, reasonToVisit, status, createdAtDate) VALUES (@flatNumber, @VisitorName, @VisitorPhone, @personToVisit, @InTime,@reasonToVisit, 'In', @createdAtDate)";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.Parameters.AddWithValue("@FlatNumber", DropDownList1.SelectedValue);
            cmd.Parameters.AddWithValue("@VisitorName", txtVisitorName.Text);
            cmd.Parameters.AddWithValue("@VisitorPhone", txtVisitorPhone.Text);
            cmd.Parameters.AddWithValue("@personToVisit", txtPersonToMeet.Text);
            cmd.Parameters.AddWithValue("@InTime", txtInTime.Text);
            //cmd.Parameters.AddWithValue("@OutTime", txtOutTime.Text);
            cmd.Parameters.AddWithValue("@reasonToVisit", txtReasonToVisit.Text);
            cmd.Parameters.AddWithValue("@createdAtDate", createdAtDate);

            cmd.ExecuteNonQuery();

            string status = "In";
            string seen = null;
            string visitordescription = txtVisitorName.Text + "; wants to meet";
            string query2 = $"insert into notification values('Visitor','{notificatiofor}','{flatNumber}','{visitordescription}','{status}','{seen}')";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            cmd2.ExecuteNonQuery();
            Response.Write("<script>alert('New Vistor Added')</script>");


            Response.Redirect("VisitorManagementAdmin.aspx");
            //LoadVisitorData();

        }
    }
}