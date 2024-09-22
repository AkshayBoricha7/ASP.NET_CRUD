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
    public partial class ContactList : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllContacts();

            if (Request.QueryString["ContactID"] != null)
            {
                DeleteContact(Convert.ToInt32(Request.QueryString["ContactID"]));
            }
        }
        public void GetAllContacts()
        {
            SqlConnection objConnection = new SqlConnection(connectionString);
            objConnection.Open();

            SqlCommand objCommand = new SqlCommand("PR_Contact_SelectAll", objConnection);
            objCommand.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = objCommand.ExecuteReader();

            rptContact.DataSource = dr;
            rptContact.DataBind();

            dr.Close();
            objConnection.Close();
        }
        private void DeleteContact(int contactID)
        {
            SqlConnection objConnection = new SqlConnection(connectionString);
            objConnection.Open();

            SqlCommand objCommand = new SqlCommand("PR_Contact_DeleteByContactID", objConnection);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@ContactID", contactID);

            SqlDataReader dr = objCommand.ExecuteReader();
            Response.Redirect("ContactList.aspx");
        }
    }
}