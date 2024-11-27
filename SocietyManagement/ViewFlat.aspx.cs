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
    public partial class ViewFlat : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    int flatId;
                    if (int.TryParse(Request.QueryString["Id"], out flatId))
                    {
                        LoadFlatDetails(flatId);
                    }
                    else
                    {
                        // Invalid ID, handle as needed
                        lblFlatNumber.Text = "Invalid Flat ID.";
                    }
                }
                else
                {
                    lblFlatNumber.Text = "Flat ID not provided.";
                }
            }
        }

        private void LoadFlatDetails(int flatId)
        {

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Flats WHERE Id = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", flatId);


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblFlatNumber.Text = reader["FlatNumber"].ToString();
                        lblFloorNumber.Text = reader["FloorNumber"].ToString();
                        lblBlockNumber.Text = reader["BlockNumber"].ToString();
                        lblType.Text = reader["Type"].ToString();
                    }
                    else
                    {
                        lblFlatNumber.Text = "Flat not found.";
                    }
                }


            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("FlatManagementAdmin.aspx");
        }
    }
}