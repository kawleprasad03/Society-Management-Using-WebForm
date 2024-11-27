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
    public partial class EditFlat : System.Web.UI.Page
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
                        ViewState["FlatId"] = flatId; // Save ID in ViewState for later use
                    }

                }

            }
        }
        private void LoadFlatDetails(int flatId)
        {

            string query = "SELECT FlatNumber, FloorNumber, BlockNumber, Type FROM Flats WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", flatId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtFlatNumber.Text = reader["FlatNumber"].ToString();
                        txtFloorNumber.Text = reader["FloorNumber"].ToString();
                        txtBlockNumber.Text = reader["BlockNumber"].ToString();
                        string type = reader["Type"].ToString();
                        ddlType.SelectedValue = reader["Type"].ToString();
                    }

                }

            }

        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (ViewState["FlatId"] != null)
            {
                int flatId = (int)ViewState["FlatId"];

                string flatNumber = txtFlatNumber.Text.Trim();
                string floorNumber = txtFloorNumber.Text.Trim();
                string blockNumber = txtBlockNumber.Text.Trim();
                string type = ddlType.SelectedValue;


                if (string.IsNullOrEmpty(flatNumber) || string.IsNullOrEmpty(floorNumber) || string.IsNullOrEmpty(blockNumber) || string.IsNullOrEmpty(type))
                {

                    Response.Write("<script>alert('All fields must be filled out.');</script>");
                    return;
                }

                string flatNumBlockNew = blockNumber + "-" + flatNumber;
                SqlCommand cmd1 = new SqlCommand($"select flatNumber,blockNumber from flats where id = '{flatId}'", conn);
                SqlDataReader reader = cmd1.ExecuteReader();
                string flatNumBlockOld = null;
                if (reader.Read()) {
                    flatNumBlockOld = reader["blockNumber"].ToString() + "-" + reader["flatNumber"].ToString();
                }

                SqlCommand cmd2 = new SqlCommand($"select flatNumber from allotments where flatNumber = '{flatNumBlockOld}'", conn);
                SqlDataReader reader1 = cmd2.ExecuteReader();
                string allotedFlatNumber = null;
                if (reader1.Read())
                {
                    allotedFlatNumber = reader1["flatNumber"].ToString();
                }

                if (allotedFlatNumber != null)
                {
                    SqlCommand cmd3 = new SqlCommand($"update allotments set flatNumber = '{flatNumBlockNew}',type = '{type}' where flatNumber = '{allotedFlatNumber}'", conn);
                    cmd3.ExecuteNonQuery();

                    SqlCommand cmd4 = new SqlCommand($"update bills set flatNumber = '{flatNumBlockNew}' where flatNumber = '{allotedFlatNumber}'", conn);
                    cmd4.ExecuteNonQuery();

                    SqlCommand cmd5 = new SqlCommand($"update complaints set flatNumber = '{flatNumBlockNew}' where flatNumber = '{allotedFlatNumber}'", conn);
                    cmd5.ExecuteNonQuery();

                    SqlCommand cmd6 = new SqlCommand($"update visitors set flatNumber = '{flatNumBlockNew}' where flatNumber = '{allotedFlatNumber}'", conn);
                    cmd6.ExecuteNonQuery();

                    SqlCommand cmd7 = new SqlCommand($"update notification set flatNumber = '{flatNumBlockNew} ' where flatNumber = ' {allotedFlatNumber}'", conn);
                    cmd7.ExecuteNonQuery();
                }


                string query = "UPDATE Flats SET FlatNumber = @FlatNumber, FloorNumber = @FloorNumber, BlockNumber = @BlockNumber, Type = @Type WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FlatNumber", flatNumber);
                    cmd.Parameters.AddWithValue("@FloorNumber", floorNumber);
                    cmd.Parameters.AddWithValue("@BlockNumber", blockNumber);
                    cmd.Parameters.AddWithValue("@Type", type);
                    cmd.Parameters.AddWithValue("@Id", flatId);


                    int rowsAffected = cmd.ExecuteNonQuery();



                }
                Response.Redirect("FlatManagementAdmin.aspx");
            }

        }
    }
}