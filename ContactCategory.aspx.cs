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
    public partial class ContactCategory : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {   
            if (!IsPostBack)
            {
                GetContactCategories();

                if (Request.QueryString["ContactCategoryID"] != null)
                {
                    DeleteContactCategory(Convert.ToInt32(Request.QueryString["ContactCategoryID"]));
                }

            }
        }

        protected void GetContactCategories()
        {
            SqlConnection objConnection = new SqlConnection(connectionString);
            objConnection.Open();

            SqlCommand objCommand = new SqlCommand("PR_ContactCategory_SelectAll", objConnection);
            objCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataReader dr = objCommand.ExecuteReader();
                rptState.DataSource = dr;
                rptState.DataBind();
            }
            catch (Exception e)
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Unable to delete it. Because attributes of other relations referencing it.";
            }
        }

        protected void DeleteContactCategory(int ContactCategoryID)
        {
            SqlConnection objConnection = new SqlConnection(connectionString);
            objConnection.Open();

            SqlCommand objCommand = new SqlCommand("PR_ContactCategory_DeleteByContactCategoryID", objConnection);
            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID);

            objCommand.ExecuteNonQuery();

            objConnection.Close();

            Response.Redirect("ContactCategory.aspx");
        }
    }
}