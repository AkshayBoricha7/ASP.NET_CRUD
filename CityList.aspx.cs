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
    public partial class CityList : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCities();

                if (Request.QueryString["CityID"] != null)
                {
                    int CityID = Convert.ToInt32(Request.QueryString["CityID"]);
                    DeleteCity(CityID);
                }

            }
        }

        protected void GetCities()
        {

            SqlConnection objConnection = new SqlConnection(connectionString);
            objConnection.Open();

            SqlCommand objCommand = new SqlCommand("PR_City_SelectAll", objConnection);
            objCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataReader dr = objCommand.ExecuteReader();
                rptCity.DataSource = dr;
                rptCity.DataBind();
            }
            catch (Exception e)
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Unable to delete it. Because attributes of other relations referencing it.";
            }
        }

        protected void DeleteCity(int CityID)
        {

            SqlConnection objConnection = new SqlConnection(connectionString);
            objConnection.Open();

            SqlCommand objCommand = new SqlCommand("PR_City_DeleteByCityID", objConnection);
            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.Parameters.AddWithValue("@CityID", CityID);

            objCommand.ExecuteNonQuery();

            objConnection.Close();

            Response.Redirect("CityList.aspx");
        }
    }
}