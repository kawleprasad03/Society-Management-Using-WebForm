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
    public partial class FlatManagementAdmin : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                LoadFlatsData();
            }
        }

        private void LoadFlatsData()
        {


            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Flats", conn))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridViewFlats.DataSource = dt;
                    GridViewFlats.DataBind();
                }
            }

        }

        protected void GridViewFlats_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int flatId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Edit")
            {
                // Redirect to Edit page with the selected Flat ID
                Response.Redirect($"EditFlat.aspx?Id={flatId}");
            }
            else if (e.CommandName == "View")
            {
                // Redirect to View page with the selected Flat ID
                Response.Redirect($"ViewFlat.aspx?Id={flatId}");
            }
            else if (e.CommandName == "Delete")
            {
                // Delete the selected Flat record
                DeleteFlat(flatId);
                LoadFlatsData(); // Refresh the GridView
                Response.Redirect("FlatManagementAdmin.aspx");
            }
        }

        private void DeleteFlat(int id)
        {

            SqlCommand cmd1 = new SqlCommand($"select flatNumber,blockNumber from flats where id = '{id}'", conn);
            SqlDataReader reader = cmd1.ExecuteReader();
            string flatNumber = null;
            if (reader.Read()) {
                flatNumber = reader["blockNumber"].ToString() + "-" + reader["flatNumber"].ToString();
            }

            SqlCommand cmd2 = new SqlCommand($"delete from bills where flatNumber = '{flatNumber}'", conn);
            cmd2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand($"delete from complaints where flatNumber = '{flatNumber}'", conn);
            cmd3.ExecuteNonQuery();

            SqlCommand cmd4 = new SqlCommand($"delete from visitors where flatNumber = '{flatNumber}'", conn);
            cmd4.ExecuteNonQuery();

            SqlCommand cmd5 = new SqlCommand($"delete from notification where flatNumber = '{flatNumber}'", conn);
            cmd5.ExecuteNonQuery();

           


            SqlCommand cmd6 = new SqlCommand($"DELETE FROM allotments WHERE flatNumber = '{flatNumber}'", conn);
            cmd6.ExecuteNonQuery();

            SqlCommand cmd = new SqlCommand($"DELETE FROM Flats WHERE Id = '{id}'", conn);
            
           cmd.ExecuteNonQuery();

            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddFlat.aspx");
        }
    }
}