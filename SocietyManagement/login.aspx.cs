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
    public partial class login : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(s);
            conn.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string em = TextBox1.Text, pass = TextBox2.Text;
           
            string q = $"select * from users where email='{em}' and password='{pass}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    if (rdr["email"].Equals(em) && rdr["password"].Equals(pass) && rdr["urole"].Equals("User"))
                    {
                        Session["email"] = em;
                        Response.Redirect("UserHome.aspx");
                    }
                    else if (rdr["email"].Equals(em) && rdr["password"].Equals(pass) && rdr["urole"].Equals("Admin"))
                    {
                        Session["email"] = em;
                        Response.Redirect("AdminHome.aspx");
                    }

                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Credintial');</script>");
            }
        }
    }
}