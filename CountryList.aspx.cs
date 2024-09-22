using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CRUD
{
    public partial class CountryList : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllCountries();

            if (Request.QueryString["CountryID"] != null)
            {
                DeleteCountry(Convert.ToInt32(Request.QueryString["CountryID"]));
            }
        }
        public void GetAllCountries()
        {
            SqlConnection objConnection = new SqlConnection(connectionString);
            objConnection.Open();

            SqlCommand objCommand = new SqlCommand("PR_Country_SelectAll", objConnection);
            objCommand.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = objCommand.ExecuteReader();

            rptCountry.DataSource = dr;
            rptCountry.DataBind();

            dr.Close();
            objConnection.Close();
        }
        private void DeleteCountry(int countryId)
        {
            SqlConnection objConnection = new SqlConnection(connectionString);
            objConnection.Open();

            SqlCommand objCommand = new SqlCommand("PR_Country_DeleteByCountryID", objConnection);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@CountryID", countryId);

            try
            {
                SqlDataReader dr = objCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Unable to delete it. Because attributes of other relations referencing it.";
            }
        }
    }
}