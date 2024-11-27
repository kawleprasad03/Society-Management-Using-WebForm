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
    public partial class VisitorManagementUser : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();


            if (!IsPostBack)
            {

                LoadVisitorData();
            }
        }
        protected void LoadVisitorData()
        {
            string email = Session["email"].ToString();

            SqlCommand cmd1 = new SqlCommand($"select flatNumber from allotments where allotedTo = '{email}'", conn);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            string flatnumber = null;
            if (reader1.Read())
            {
                flatnumber = reader1["flatNumber"].ToString();
            }
            string q = $"SELECT * FROM visitors where flatNumber = '{flatnumber}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string visitorId = e.CommandArgument.ToString();
            if (e.CommandName == "View")
            {
                
                Response.Redirect($"ViewVisitorUser.aspx?id={visitorId}");
            }
           
        }

        protected string GetBadgeClass(string status)
        {
            switch (status)
            {
                case "In":
                    return "badge badge-success";
                case "Out":
                    return "badge badge-danger";
                default:
                    return "badge badge-secondary";
            }
        }


    }
}