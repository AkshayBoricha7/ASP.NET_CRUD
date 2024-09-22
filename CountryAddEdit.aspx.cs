using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD
{
    public partial class CountryAddEdit : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["CountryID"] != null)
                {
                    GetCountryById(Convert.ToInt32(Request.QueryString["CountryID"]));
                }
            }
        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection objConnection = new SqlConnection(connectionString);
            objConnection.Open();

            if (Request.QueryString["CountryID"] != null)
            {
                int CountryId = Convert.ToInt32(Request.QueryString["CountryID"]);
                lblTitle.Text = CountryId.ToString();
                try
                {
                    SqlCommand objCommand = new SqlCommand("PR_Country_UpdateByCountryID", objConnection);
                    objCommand.Parameters.AddWithValue("@CountryID", CountryId);
                    objCommand.Parameters.AddWithValue("@CountryName", txtCountryName.Text);
                    objCommand.Parameters.AddWithValue("@CountryCode", txtCountryCode.Text);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                SqlCommand objCommand = new SqlCommand("PR_Country_Insert", objConnection);
                objCommand.Parameters.AddWithValue("@CountryName", txtCountryName.Text);
                objCommand.Parameters.AddWithValue("@CountryCode", txtCountryCode.Text);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.ExecuteNonQuery();
            }
            objConnection.Close();
            Response.Redirect("CountryList.aspx");
        }

        public void GetCountryById(int CountryID)
        {
            SqlConnection objConnection = new SqlConnection(connectionString);
            objConnection.Open();

            SqlCommand objCommand = new SqlCommand("PR_Country_SelectByCountryID", objConnection);
            objCommand.Parameters.AddWithValue("@CountryID", CountryID);
            objCommand.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = objCommand.ExecuteReader();
            DataTable dt = new DataTable();

            dt.Load(dr);
            objConnection.Close();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    txtCountryName.Text = row["CountryName"].ToString();
                    txtCountryCode.Text = row["CountryCode"].ToString();
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CountryList.aspx");
        }
    }
}