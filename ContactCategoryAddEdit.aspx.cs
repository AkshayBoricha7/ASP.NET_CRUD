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
    public partial class ContactCategoryAddEdit : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ContactCategoryID"]))
                {
                    txtContactCategoryName.Text = Request.QueryString["ContactCategoryName"];
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["ContactCategoryID"]))
            {
                AddNewContactCategory();
            }
            else
            {
                int contactCategoryID = Convert.ToInt32(Request.QueryString["ContactCategoryID"].ToString());
                UpdateContactCategory(contactCategoryID);
            }
            Clear_Controls();
        }

        private void AddNewContactCategory()
        {
            string contactCategoryName = txtContactCategoryName.Text;

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PR_ContactCategory_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ContactCategoryName", contactCategoryName);

                    conn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        lblMessage.Text = "Contact Category added successfully.";
                    }
                    catch (Exception e)
                    {
                        lblMessage.Text = e.Message.ToString();
                    }
                    Response.Redirect("ContactCategory.aspx");
                }
            }
        }

        private void UpdateContactCategory(int contactCategoryID)
        {
            string contactCategoryName = txtContactCategoryName.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PR_ContactCategory_UpdateByContactCategoryID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ContactCategoryID", contactCategoryID);
                    cmd.Parameters.AddWithValue("@ContactCategoryName", contactCategoryName);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("ContactCategory.aspx");
                }
            }
        }

        private void Clear_Controls()
        {
            txtContactCategoryName.Text = "";
        }
    }
}