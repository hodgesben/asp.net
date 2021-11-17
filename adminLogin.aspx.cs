using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class db : System.Web.UI.Page
{
  SqlConnection connection;
  SqlCommand command;
  SqlDataReader reader;

  protected void Page_Load(object sender, EventArgs e)
  {

  }

  public void conn() {
    string connectionString =
      "Data Source = teach-web01.park.edu\\MSSQLSER2;" +
      " Initial Catalog = bhodges_db;" +
      " Integrated Security = False;" +
      " User Id = bhodges_usn;" +
      " Password = mRwk603$;" +
      " MultipleActiveResultSets = True";

    connection = new SqlConnection(connectionString);
  }

  public void loginAdmin(Object Src, EventArgs E)
  {
      conn();

      // Try to open the connection.

      try {
      connection.Open();
      command = new SqlCommand("SELECT adm_username, adm_password FROM adm_swim WHERE adm_username=@userName AND adm_password=@password", connection);
      command.Parameters.AddWithValue("@userName", Aname.Text);
      command.Parameters.AddWithValue("@password", AdminPass.Text);
      SqlDataAdapter da = new SqlDataAdapter(command);
      DataTable dt = new DataTable();

       da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Response.Redirect("adminPage.aspx");
        }
        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username or Password\\n Try again')</script>");
            adminFormPanel.Visible = true;
        }
        } 
    
        catch (Exception err)
        {
            // Handle an error by displaying the information.
            errorInfo.Text = "Error reading the database. ";
            errorInfo.Text += err.Message;
        }

        finally
        {
            // Either way, make sure the connection is properly closed.
            // (Even if the connection wasn't opened successfully,
            //  calling Close() won't cause an error.)
            connection.Close();
            errorInfo.Text += "<br /><b>Now Connection Is:</b> ";
            errorInfo.Text += connection.State.ToString();
        }


  }
}
