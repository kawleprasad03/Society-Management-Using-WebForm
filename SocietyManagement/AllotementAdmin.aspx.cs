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
    public partial class AllotementAdmin : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                LoadAllotmentsData();
            }
        }

        private void LoadAllotmentsData()
        {
            string query = "SELECT id, allotedTo, flatNumber, type, moveInDate, moveOutDate FROM allotments";


            SqlCommand cmd = new SqlCommand(query, conn);
                
                   
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
                
            
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int allotmentId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Edit")
            {
                
                Response.Redirect($"EditAllotment.aspx?id={allotmentId}");
            }
            else if (e.CommandName == "Delete")
            {
                // Delete the selected record
                DeleteAllotment(allotmentId);
                LoadAllotmentsData();
                Response.Redirect("AllotementAdmin.aspx");
            }
        }

        private void DeleteAllotment(int id)
        {
            SqlCommand cmd1 = new SqlCommand($"select flatNumber from allotments where id = '{id}'", conn);
            SqlDataReader reader = cmd1.ExecuteReader();
            string flatNumber = null;
            if (reader.Read()) {
                flatNumber = reader["flatNumber"].ToString();
            }

            SqlCommand cmd2 = new SqlCommand($"delete from bills where flatNumber = '{flatNumber}'", conn);
            cmd2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand($"delete from complaints where flatNumber = '{flatNumber}'", conn);
            cmd3.ExecuteNonQuery();

            SqlCommand cmd4 = new SqlCommand($"delete from visitors where flatNumber = '{flatNumber}'", conn);
            cmd4.ExecuteNonQuery();

            SqlCommand cmd5 = new SqlCommand($"delete from notification where flatNumber = '{flatNumber}'", conn);
            cmd5.ExecuteNonQuery();

            string query = $"DELETE FROM allotments WHERE id = '{id}'";


            SqlCommand cmd = new SqlCommand(query, conn);
                
                  
            cmd.ExecuteNonQuery();
                
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAllotment.aspx");
        }
    }
}