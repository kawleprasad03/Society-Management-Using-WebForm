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
    public partial class AddAllotment : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                LoadUserData();
                LoadFlatNumber();
            }
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
            //string query = "SELECT id, CONCAT(blockNumber, '-' ,flatNumber) AS FlatInfo FROM flats";
            string query = @"
            SELECT f.id, CONCAT(f.blockNumber, '-', f.flatNumber) AS FlatInfo
            FROM flats f
            LEFT JOIN allotments a ON CONCAT(f.blockNumber, '-', f.flatNumber) = a.flatNumber
            WHERE a.flatNumber IS NULL";
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
            string allotedTo = DropDownList1.SelectedValue;
            string flatNumBlock = DropDownList2.SelectedValue;
            string moveInDate = TextBox1.Text;
            string[] args = flatNumBlock.Split('-');
            string Block = args[0];
            string flatNumber = args[1];

            string query = $"SELECT id,type FROM flats where flatNumber='{flatNumber}' AND blockNumber='{Block}'";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            string type = null;
            if (reader.Read()) {
                type = reader["type"].ToString();
            }

            string query1 = "INSERT INTO allotments (allotedTo, flatNumber, type, moveInDate) VALUES (@allotedTo, @flatNumber, @type, @moveInDate)";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.Parameters.AddWithValue("@allotedTo", allotedTo);
            cmd1.Parameters.AddWithValue("@flatNumber", flatNumBlock);
            cmd1.Parameters.AddWithValue("@type", type); 
            cmd1.Parameters.AddWithValue("@moveInDate", moveInDate);

            cmd1.ExecuteNonQuery();
            Response.Write("<script>alert('Data added successfully');</script>");
            Response.Redirect("AllotementAdmin.aspx");
        }
    }
}