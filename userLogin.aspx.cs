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

  public void loginUser(Object Src, EventArgs E)
  {    
    errorChecker.Visible = true;
    userFormPanel.Visible = false;
        // function with connection information
    conn();
    try
    {
      // Try to open the connection.
      connection.Open();

      command = new SqlCommand("SELECT parent_email, parent_password FROM parent WHERE parent_email=@email AND parent_password=@password", connection);
      command.Parameters.AddWithValue("@email", userTB.Text);
      command.Parameters.AddWithValue("@password", passwordTB.Text);
      SqlDataAdapter da = new SqlDataAdapter(command);
      DataTable dt = new DataTable();

       da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Session["parentEmail"] = userTB.Text;
            Response.Redirect("userPage.aspx");
        }
        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username or Password\\n Try again')</script>");
            userFormPanel.Visible = true;
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
          connection.Close();
            errorInfo.Text += "<br /><b>Now Connection Is:</b> ";
            errorInfo.Text += connection.State.ToString();
        }
    } // end of loginUser

  public void regUser(Object Src, EventArgs E)
  { 
    Response.Write("you have connected to your .cs page add records");
    errorChecker.Visible = true; 
    userFormPanel.Visible = false;
        // function with connection information
    conn();
    try
    {
      // Try to open the connection.
      connection.Open();

       command = new SqlCommand("INSERT INTO parent (parent_email, parent_password, parent_fname, parent_lname, parent_phone)" +
         " VALUES (@email, @password, @firstname, @lastname, @phone)", connection);
   
          
      command.Parameters.AddWithValue("@email", newUserEmail.Text);
      command.Parameters.AddWithValue("@password", newUserPassword.Text);
      command.Parameters.AddWithValue("@firstname", newUserFirstName.Text);
      command.Parameters.AddWithValue("@lastname", newUserLastName.Text);
      command.Parameters.AddWithValue("@phone", newUserPhone.Text);
      command.ExecuteNonQuery();

      Session["parentEmail"] = newUserEmail.Text;
      connection.Close();
    }
        catch (Exception err)
        {
            // Handle an error by displaying the information.
            errorInfo.Text = "Error reading the database. ";
            errorInfo.Text += err.Message;
        }
        finally
        {
            connection.Close();

            Response.Redirect("userPage.aspx");
        }
    } // end of regUser

    public void adminLogin(Object Src, EventArgs E)
    {
       Response.Redirect("adminLogin.aspx");
    }
}