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

  public void goHome(object sender, EventArgs e){
    Response.Redirect("assignClasses.aspx");
  }

  public void goAdminHome(object sender, EventArgs e){
    Response.Redirect("adminPage.aspx");
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
  protected void Page_Load(object sender, EventArgs e)
  {      
    conn();

    try
    {
      // Try to open the connection.
      connection.Open();
      if (!IsPostBack)
      {
        command = new SqlCommand("SELECT * FROM enrollment WHERE instructor_id=-1", connection);

        reader = command.ExecuteReader();
        classAssignDDL.DataSource = reader;
        classAssignDDL.DataTextField = "enrollment_id";
        classAssignDDL.DataValueField = "enrollment_id";
        classAssignDDL.DataBind();


        command = new SqlCommand("SELECT * FROM instructor", connection);

        reader = command.ExecuteReader();
        instuctorAssignDDL.DataSource = reader;
        instuctorAssignDDL.DataTextField = "instructor_lname";
        instuctorAssignDDL.DataValueField = "instructor_id";
        instuctorAssignDDL.DataBind();
      }
    }
    catch (Exception err)
    {
      // Handle an error by displaying the information.
      lblInfo.Text = "Error reading the database. ";
      lblInfo.Text += err.Message;
    }
    finally
    {
      connection.Close();
      lblInfo.Text += "<br /><b>Now Connection Is:</b> ";
      lblInfo.Text += connection.State.ToString();
    }
  } // end Page_Load

  public void updateEnrolTable(object sender, EventArgs e)
  {
    conn();

    try
    {
      connection.Open();
      command = new SqlCommand("UPDATE enrollment SET instructor_id=@instructor_id WHERE enrollment_id=@id", connection);
      command.Parameters.AddWithValue("@id", classAssignDDL.SelectedValue);
      command.Parameters.AddWithValue("@instructor_id", instuctorAssignDDL.SelectedValue);

      command.ExecuteNonQuery();  
    }
    catch (Exception err)
    {
      // Handle an error by displaying the information.
      lblInfo.Text = "Error reading the database. ";
      lblInfo.Text += err.Message;
    }
    finally
    {
      connection.Close();
      updateComplete.Visible = true;
      subEnrolTable.Visible = false;
      instuctorAssign.Visible = false;
    }
  }

  public void Get_data(Object Src, EventArgs E)
  {  
    subEnrolTable.Visible = true;
    classAssign.Visible = false;
    instuctorAssign.Visible = true;

    conn();

    try
    {
      connection.Open();
          
      command = new SqlCommand("SELECT * FROM enrollment WHERE enrollment_id=@id", connection);
      command.Parameters.AddWithValue("@id", classAssignDDL.SelectedValue);

      reader = command.ExecuteReader();
      one_data.DataSource = reader;
      one_data.DataBind();
      reader.Close();
    }
    catch (Exception err)
        {
            // Handle an error by displaying the information.
            lblInfo.Text = "Error reading the database. ";
            lblInfo.Text += err.Message;
        }
        finally
        {
            // Either way, make sure the connection is properly closed.
            // (Even if the connection wasn't opened successfully,
            //  calling Close() won't cause an error.)
            connection.Close();
            lblInfo.Text += "<br /><b>Now Connection Is:</b> ";
            lblInfo.Text += connection.State.ToString();
        }
    } // end of get one data
}