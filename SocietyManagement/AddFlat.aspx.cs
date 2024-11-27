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
    public partial class AddFlat : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string flatNumber = txtFlatNumber.Text.Trim();
            string floorNumber = txtFloorNumber.Text.Trim();
            string blockNumber = txtBlockNumber.Text.Trim();
            string type = ddlType.SelectedValue.Trim();

            if (string.IsNullOrEmpty(flatNumber) || string.IsNullOrEmpty(floorNumber) || string.IsNullOrEmpty(blockNumber) || string.IsNullOrEmpty(type))
            {
                Response.Write("<script>alert('All fields must be filled out.');</script>");
                return;
            }

            string query = "INSERT INTO Flats (FlatNumber, FloorNumber, BlockNumber, Type) " +
                           "VALUES (@FlatNumber, @FloorNumber, @BlockNumber, @Type)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Set parameters
                cmd.Parameters.AddWithValue("@FlatNumber", flatNumber);
                cmd.Parameters.AddWithValue("@FloorNumber", floorNumber);
                cmd.Parameters.AddWithValue("@BlockNumber", blockNumber);
                cmd.Parameters.AddWithValue("@Type", type);


                cmd.ExecuteNonQuery();
                Response.Redirect("FlatManagementAdmin.aspx");

            }


        }
    }
}