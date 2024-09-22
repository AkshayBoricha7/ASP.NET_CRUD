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
    public partial class CityAddEdit : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCountries();
                if (!string.IsNullOrEmpty(Request.QueryString["CityID"]))
                {
                    int cityID = Convert.ToInt32(Request.QueryString["CityID"]);
                    LoadCityDetails(cityID);
                }
            }
        }

        private void LoadCityDetails(int cityID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PR_City_SelectByCityID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CityID", cityID);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtCityName.Text = reader["CityName"].ToString();

                        int selectedStateID = Convert.ToInt32(reader["StateID"]);
                        int selectedCountryID = Convert.ToInt32(reader["CountryID"]);

                        txtSTDCode.Text = reader["STDCode"].ToString();
                        txtPinCode.Text = reader["PinCode"].ToString();

                        LoadCountries();
                        ddlCountry.SelectedValue = selectedCountryID.ToString();

                        LoadStates(selectedCountryID);
                        ddlState.SelectedValue = selectedStateID.ToString();
                    }

                    conn.Close();
                }
            }
        }


        private void LoadStates(int countryID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PR_State_SelectByCountryID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CountryID", countryID);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    ddlState.DataSource = reader;
                    ddlState.DataTextField = "StateName";
                    ddlState.DataValueField = "StateID";  
                    ddlState.DataBind();

                    conn.Close();
                }
            }
        }



        private void LoadCountries()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PR_Country_SelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    ddlCountry.DataSource = reader;
                    ddlCountry.DataTextField = "CountryName";
                    ddlCountry.DataValueField = "CountryID";
                    ddlCountry.DataBind();

                    ddlCountry.Items.Insert(0, new ListItem("Select Country", "0"));

                    conn.Close();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (string.IsNullOrEmpty(Request.QueryString["CityID"]))
            {
                AddNewCity();
            }
            else
            {
                int cityID = Convert.ToInt32(Request.QueryString["CityID"].ToString());
                UpdateCity(cityID);
            }
            Clear_Controls();
        }

        private void AddNewCity()
        {
            if (ddlState.SelectedValue == "0")
            {
                lblMessage.Text = "Please select a valid state.";
                return;
            }

            string cityName = txtCityName.Text;
            int stateID = Convert.ToInt32(ddlState.SelectedValue);
            string stdCode = txtSTDCode.Text;
            string pinCode = txtPinCode.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PR_City_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CityName", cityName);
                    cmd.Parameters.AddWithValue("@StateID", stateID);
                    cmd.Parameters.AddWithValue("@StdCode", stdCode);
                    cmd.Parameters.AddWithValue("@PinCode", pinCode);

                    conn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        lblMessage.Text = "City added successfully.";
                    }
                    catch (Exception e)
                    {
                        lblMessage.Text = "Unable to add city";
                    }
                }
            }
        }

        private void UpdateCity(int cityID)
        {
            string cityName = txtCityName.Text;
            int stateID = Convert.ToInt32(ddlState.SelectedValue);
            int countryID = Convert.ToInt32(ddlCountry.SelectedValue);
            string stdCode = txtSTDCode.Text;
            string pinCode = txtPinCode.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PR_City_UpdateByCityID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CityID", cityID);
                    cmd.Parameters.AddWithValue("@CityName", cityName);
                    cmd.Parameters.AddWithValue("@StateID", stateID);
                    cmd.Parameters.AddWithValue("@STDCode", stdCode);
                    cmd.Parameters.AddWithValue("@PinCode", pinCode);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    lblMessage.Text = "Successfully updated";
                }
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            int countryID = Convert.ToInt32(ddlCountry.SelectedValue);
            if (countryID > 0)
            {
                LoadStates(countryID);  
                if (ddlState.Items.Count > 1)
                {
                    ddlState.SelectedIndex = 0;
                }
            }
        }

        private void Clear_Controls()
        {
            txtCityName.Text = "";
            ddlCountry.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;
            txtPinCode.Text = "";
            txtSTDCode.Text = "";
        }
    }
}