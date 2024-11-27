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
    public partial class EditAllotment : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                // Populate DropDownLists if necessary
                LoadUserData();
                LoadFlatNumber();

                // Load data if "id" is present in the query string
                string allotid = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(allotid))
                {
                    LoadData(allotid);
                }
            }

        }

        private void LoadData(string allotid)
        {
            
            string query = "SELECT allotedTo, flatNumber, moveInDate FROM allotments WHERE id = @id";


            SqlCommand command = new SqlCommand(query, conn);
                
            command.Parameters.AddWithValue("@id", allotid);
                    

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                // Set DropDownList1 based on allotedTo value
                string allotedTo = reader["allotedTo"].ToString();
                DropDownList1.SelectedValue = allotedTo;

                // Set DropDownList2 based on flatNumber value
                string flatNumber = reader["flatNumber"].ToString();
                DropDownList2.SelectedValue = flatNumber;

                // Set TextBox1 based on moveInDate value
                DateTime moveInDate;
                if (DateTime.TryParse(reader["moveInDate"].ToString(), out moveInDate))
                {
                    TextBox1.Text = moveInDate.ToString("yyyy-MM-dd"); // For date input
                }
            }
            reader.Close();
                
            
        }

        private void LoadUserData()
        {
            string query = "SELECT userName, email FROM users WHERE urole!='Admin'";


            SqlCommand cmd = new SqlCommand(query, conn);


            SqlDataReader reader = cmd.ExecuteReader();

            // Bind data to DropDownList
            DropDownList1.DataSource = reader;
            DropDownList1.DataTextField = "userName";
            DropDownList1.DataValueField = "email";
            DropDownList1.DataBind();

            DropDownList1.Items.Insert(0, new ListItem("Select Option", "Selected Option"));
            DropDownList1.Items[0].Selected = true;
            DropDownList1.Items[0].Attributes.Add("disabled", "true");

        }

        private void LoadFlatNumber()
        {
            string query = "SELECT id, CONCAT(blockNumber, '-' ,flatNumber) AS FlatInfo FROM flats";

            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            DropDownList2.DataSource = reader;
            DropDownList2.DataTextField = "FlatInfo";
            DropDownList2.DataValueField = "FlatInfo";
            DropDownList2.DataBind();

            DropDownList2.Items.Insert(0, new ListItem("Select Option", "Selected Option"));
            DropDownList2.Items[0].Selected = true;
            DropDownList2.Items[0].Attributes.Add("disabled", "true");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string allotid = Request.QueryString["id"];
            string allotedTo = DropDownList1.SelectedValue;
            string flatNumBlock = DropDownList2.SelectedValue;
            string moveInDate = TextBox1.Text;
            string[] args = flatNumBlock.Split('-');
            string Block = args[0];
            string flatNumber = args[1];
            string moveOutDate = TextBox2.Text;

            string query = $"SELECT id,type FROM flats where flatNumber='{flatNumber}' AND blockNumber='{Block}'";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            string type = null;
            if (reader.Read())
            {
                type = reader["type"].ToString();
            }

            SqlCommand cmd2 = new SqlCommand($"select flatNumber from allotments where id = '{allotid}'", conn);
            SqlDataReader reader1 = cmd2.ExecuteReader();
            string flatnumberold = null;
            if (reader1.Read()) {
                flatnumberold = reader1["flatNumber"].ToString();
            }

            
            SqlCommand cmd3 = new SqlCommand($"update bills set flatNumber = '{flatNumBlock}' where flatNumber = '{flatnumberold}'", conn);
            cmd3.ExecuteNonQuery();

            SqlCommand cmd4 = new SqlCommand($"update complaints set flatNumber = '{flatNumBlock}',userName = '{allotedTo}' where flatNumber = '{flatnumberold}'", conn);
            cmd4.ExecuteNonQuery();

            SqlCommand cmd5 = new SqlCommand($"update visitors set flatNumber = '{flatNumBlock}' where flatNumber = '{flatnumberold}'", conn);
            cmd5.ExecuteNonQuery();

            SqlCommand cmd6 = new SqlCommand($"update notification set flatNumber = '{flatNumBlock}',notificationFor = '{allotedTo}' where flatNumber = '{flatnumberold}'", conn);
            cmd6.ExecuteNonQuery();

            string query1 = "UPDATE allotments SET allotedTo = @allotedTo, flatNumber = @flatNumber, type = @type, moveInDate = @moveInDate, moveOutDate = @moveOutDate WHERE id = @Id";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.Parameters.AddWithValue("@allotedTo", allotedTo);
            cmd1.Parameters.AddWithValue("@flatNumber", flatNumBlock);
            cmd1.Parameters.AddWithValue("@type", type);
            cmd1.Parameters.AddWithValue("@moveInDate", moveInDate);
            cmd1.Parameters.AddWithValue("@moveOutDate", moveOutDate);
            cmd1.Parameters.AddWithValue("@Id", allotid);

            cmd1.ExecuteNonQuery();
            Response.Write("<script>alert('Data added successfully');</script>");
            Response.Redirect("AllotementAdmin.aspx");
        }
    }
}