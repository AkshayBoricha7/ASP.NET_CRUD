using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace CRUD
{
    public partial class ContactAddEdit : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountries();
                BindContactCategories();
                if (Request.QueryString["ContactID"] != null)
                {
                    int contactID = Convert.ToInt32(Request.QueryString["ContactID"]);
                    LoadContactDetails(contactID);
                }
            }
        }

        private void BindCountries()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Country_SelectAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                ddlCountry.DataSource = cmd.ExecuteReader();
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataBind();
                con.Close();
            }
            ddlCountry.Items.Insert(0, new ListItem("Select Country", "0"));
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindStates();
        }

        private void BindStates()
        {
            int countryID = Convert.ToInt32(ddlCountry.SelectedValue);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_State_SelectByCountryID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CountryID", countryID);
                con.Open();
                ddlState.DataSource = cmd.ExecuteReader();
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateID";
                ddlState.DataBind();
                con.Close();
            }
            ddlState.Items.Insert(0, new ListItem("Select State", "0"));
        }

        private void BindContactCategories()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_ContactCategory_SelectAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                ddlContactCategory.DataSource = cmd.ExecuteReader();
                ddlContactCategory.DataTextField = "ContactCategoryName";
                ddlContactCategory.DataValueField = "ContactCategoryID";
                ddlContactCategory.DataBind();
                con.Close();
            }
            ddlContactCategory.Items.Insert(0, new ListItem("Select Contact Category", "0"));
        }


        private void LoadContactDetails(int contactID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Contact_SelectByContactID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContactID", contactID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    txtContactName.Text = dr["ContactName"].ToString();
                    txtContactNo.Text = dr["ContactNo"].ToString();
                    txtWhatsAppNo.Text = dr["WhatsAppNo"].ToString();
                    ddlCountry.SelectedValue = dr["CountryID"].ToString();

                    // Bind states based on the selected country
                    BindStates();
                    ddlState.SelectedValue = dr["StateID"].ToString();

                    // Bind cities based on the selected state
                    BindCities();
                    ddlCity.SelectedValue = dr["CityID"].ToString();

                    ddlContactCategory.SelectedValue = dr["ContactCategoryID"].ToString();
                    txtBirthDate.Text = dr["BirthDate"].ToString();
                    txtEmail.Text = dr["Email"].ToString();
                    txtAge.Text = dr["Age"].ToString();
                    txtAddress.Text = dr["Address"].ToString();
                    txtBloodGroup.Text = dr["BloodGroup"].ToString();
                    txtFacebookID.Text = dr["FacebookID"].ToString();
                    txtLinkedINID.Text = dr["LinkedINID"].ToString();
                }
                con.Close();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ContactID"] != null)
            {
                // Edit mode
                int contactID = Convert.ToInt32(Request.QueryString["ContactID"]);
                UpdateContact(contactID);
            }
            else
            {
                // Insert mode
                InsertContact();
            }
        }

        private void InsertContact()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Contact_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContactName", txtContactName.Text.Trim());
                cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text.Trim());
                cmd.Parameters.AddWithValue("@WhatsAppNo", txtWhatsAppNo.Text.Trim());
                cmd.Parameters.AddWithValue("@CountryID", ddlCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@StateID", ddlState.SelectedValue);
                cmd.Parameters.AddWithValue("@ContactCategoryID", ddlContactCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@CityID", ddlCity.SelectedValue);
                cmd.Parameters.AddWithValue("@BirthDate", txtBirthDate.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Age", txtAge.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@BloodGroup", txtBloodGroup.Text.Trim());
                cmd.Parameters.AddWithValue("@FacebookID", txtFacebookID.Text.Trim());
                cmd.Parameters.AddWithValue("@LinkedINID", txtLinkedINID.Text.Trim());

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Redirect("ContactList.aspx");
            }
        }

        // Method to update an existing contact
        private void UpdateContact(int contactID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Contact_UpdateByContactID", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContactID", contactID);
                cmd.Parameters.AddWithValue("@ContactName", txtContactName.Text.Trim());
                cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text.Trim());
                cmd.Parameters.AddWithValue("@WhatsAppNo", txtWhatsAppNo.Text.Trim());
                cmd.Parameters.AddWithValue("@CountryID", ddlCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@StateID", ddlState.SelectedValue);
                cmd.Parameters.AddWithValue("@CityID", ddlCity.SelectedValue);
                cmd.Parameters.AddWithValue("@ContactCategoryID", ddlContactCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@BirthDate", txtBirthDate.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Age", txtAge.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@BloodGroup", txtBloodGroup.Text.Trim());
                cmd.Parameters.AddWithValue("@FacebookID", txtFacebookID.Text.Trim());
                cmd.Parameters.AddWithValue("@LinkedINID", txtLinkedINID.Text.Trim());

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                lblMessage.Text = "Contact updated successfully!";
                Response.Redirect("ContactList.aspx");
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCities();
        }

        private void BindCities()
        {
            int stateID = Convert.ToInt32(ddlState.SelectedValue);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_City_SelectByStateID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StateID", stateID);
                con.Open();
                ddlCity.DataSource = cmd.ExecuteReader();
                ddlCity.DataTextField = "CityName";
                ddlCity.DataValueField = "CityID";
                ddlCity.DataBind();
                con.Close();
            }
            ddlCity.Items.Insert(0, new ListItem("Select City", "0"));
        }
    }
}
