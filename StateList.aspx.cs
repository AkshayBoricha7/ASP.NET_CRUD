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
    public partial class StateList : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetStates();

                if (Request.QueryString["StateID"] != null)
                {
                    int StateID = Convert.ToInt32(Request.QueryString["StateID"]);
                    DeleteState(StateID);
                }

            }
        }

        protected void GetStates()
        {
            SqlConnection objConnection = new SqlConnection(connectionString);
            objConnection.Open();

            SqlCommand objCommand = new SqlCommand("PR_State_SelectAll", objConnection);
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

        protected void DeleteState(int StateID)
        {
            SqlConnection objConnection = new SqlConnection(connectionString);
            objConnection.Open();

            SqlCommand objCommand = new SqlCommand("PR_State_DeleteByStateID", objConnection);
            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.Parameters.AddWithValue("@StateID", StateID);

            objCommand.ExecuteNonQuery();

            objConnection.Close();

            GetStates();
        }
    }
}