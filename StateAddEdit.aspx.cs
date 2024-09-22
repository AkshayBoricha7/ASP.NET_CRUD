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
    public partial class StateAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setCountryDropDown();
                if (Request.QueryString["StateID"] != null)
                {
                    int StateID = Convert.ToInt32(Request.QueryString["StateID"]);

                    txtStateName.Text = Request.QueryString["StateName"];
                    txtStateCode.Text = Request.QueryString["StateCode"];


                }
            }
        }

        protected void LoadStateDetails(int StateID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            SqlConnection objConnection = new SqlConnection(connectionString);
            objConnection.Open();

            SqlCommand objCommand = new SqlCommand("PR_State_SelectByStateID", objConnection);
            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.Parameters.AddWithValue("@StateID", StateID);

            SqlDataReader dr = objCommand.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                txtStateName.Text = dr["StateName"].ToString();
                txtStateCode.Text = dr["StateCode"].ToString();
                ddlCountry.SelectedValue = dr["CountryID"].ToString();
            }

            dr.Close();
            objConnection.Close();
        }

        protected void setCountryDropDown()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            SqlConnection objConnection = new SqlConnection(connectionString);
            objConnection.Open();

            SqlCommand objCommand = new SqlCommand("PR_Country_SelectAll", objConnection);
            objCommand.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = objCommand.ExecuteReader();

            ddlCountry.DataSource = dr;
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataValueField = "CountryID";
            ddlCountry.DataBind();

            dr.Close();
            objConnection.Close();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            SqlConnection objConnection = new SqlConnection(connectionString);
            objConnection.Open();

            if (Request.QueryString["StateID"] == null || Request.QueryString["StateID"] == String.Empty)
            {
                SqlCommand objCommand = new SqlCommand("PR_State_Insert", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;

                objCommand.Parameters.AddWithValue("@StateName", txtStateName.Text);
                objCommand.Parameters.AddWithValue("@StateCode", txtStateCode.Text);
                objCommand.Parameters.AddWithValue("@CountryID", Convert.ToInt32(ddlCountry.SelectedValue));

                objCommand.ExecuteNonQuery();
            }
            else
            {
                SqlCommand objCommand = new SqlCommand("PR_State_UpdateByStateID", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;

                objCommand.Parameters.AddWithValue("@StateID", Convert.ToInt32(Request.QueryString["StateID"]));
                objCommand.Parameters.AddWithValue("@StateName", txtStateName.Text);
                objCommand.Parameters.AddWithValue("@StateCode", txtStateCode.Text);
                objCommand.Parameters.AddWithValue("@CountryID", Convert.ToInt32(ddlCountry.SelectedValue));

                objCommand.ExecuteNonQuery();
            }
            objConnection.Close();

            Response.Redirect("StateList.aspx");
        }
    }
}