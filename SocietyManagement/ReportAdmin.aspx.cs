using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace SocietyManagement
{
    public partial class ReportAdmin : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string selectedOption = DropDownList1.SelectedValue;
            string startDate = TextBox1.Text;
            string endDate = TextBox2.Text;

            // Ensure a valid option is selected and dates are filled
            if (string.IsNullOrEmpty(selectedOption) || selectedOption == "Select Option")
            {
                // Show an error message (not implemented here)
                return;
            }

            DataTable dataTable = new DataTable();

           
                string query = "";

                // Set query based on selected option
                if (selectedOption == "Bills")
                {
                    query = "SELECT * FROM bills WHERE paymentDate BETWEEN @StartDate AND @EndDate";
                }
                else if (selectedOption == "Complaints")
                {
                    query = "SELECT * FROM complaints WHERE createdAtDate BETWEEN @StartDate AND @EndDate";
                }
                else if (selectedOption == "Visitor")
                {
                    query = "SELECT * FROM visitors WHERE createdAtDate BETWEEN @StartDate AND @EndDate";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
            

            // Bind the data to the GridView
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ExportGridViewToCSV();
        }

        private void ExportGridViewToCSV()
        {
            // Make sure there is data in the GridView
            if (GridView1.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=DataExport.csv");
                Response.Charset = "";
                Response.ContentType = "application/text";

                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                // Write column headers
                for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
                {
                    sw.Write(GridView1.HeaderRow.Cells[i].Text);
                    if (i < GridView1.HeaderRow.Cells.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);

                // Write rows
                foreach (GridViewRow row in GridView1.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        sw.Write(row.Cells[i].Text);
                        if (i < row.Cells.Count - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                }

                // Write the response
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
    }
}