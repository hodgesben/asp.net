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
    Response.Redirect("Roster.aspx");
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
  }  // end conn

  protected void Page_Load(object sender, EventArgs e)
  {      
    conn();

    try
    {
      // Try to open the connection.
      connection.Open();
      if (!IsPostBack)

      command = new SqlCommand("SELECT * FROM session", connection);

      reader = command.ExecuteReader();
      sessionDDL.DataSource = reader;
      sessionDDL.DataTextField = "session_name";
      sessionDDL.DataValueField = "session_id";
      sessionDDL.DataBind();

      command = new SqlCommand("SELECT * FROM class", connection);
      
      reader = command.ExecuteReader();
      classDDL.DataSource = reader;
      classDDL.DataTextField = "class_name";
      classDDL.DataValueField = "class_id";
      classDDL.DataBind();
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
  }

  protected void getRoster(object sender, EventArgs e)
  {      
    conn();
    rosterSelectForm.Visible = false;
    classInformationTable.Visible = true;
    instructorInformationTable.Visible = true;
    childInformationTable.Visible = true;
    errorCheck.Visible = true;

    try
    {
      // Try to open the connection.
      connection.Open();
      command = new SqlCommand("SELECT * FROM class WHERE class_id=@class_id", connection);
      command.Parameters.AddWithValue("@class_id", classDDL.SelectedValue);
      
      reader = command.ExecuteReader();

      while (reader.Read())
      {
        className.Text = (string) reader["class_name"];
        className.Text += " || ";
        classDes.Text = (string) reader["class_desc"];
      }

      command = new SqlCommand("SELECT * FROM session WHERE session_id=@session_id", connection);
      command.Parameters.AddWithValue("@session_id", sessionDDL.SelectedValue);
      
      reader = command.ExecuteReader();

      while (reader.Read())
      {
        sessionName.Text = (string) reader["session_name"];
        sessionName.Text += " || ";
        sessionDates.Text = (string) reader["session_dates"];
      }

      command = new SqlCommand("SELECT * FROM ((enrollment inner join instructor ON enrollment.instructor_id=instructor.instructor_id) inner join photo ON photo.instructor_id=instructor.instructor_id) WHERE class_id=@class_id AND session_id=@session_id" , connection);
      command.Parameters.AddWithValue("@class_id", classDDL.SelectedValue);
      command.Parameters.AddWithValue("@session_id", sessionDDL.SelectedValue);
      
      reader = command.ExecuteReader();

      instructor_data.DataSource = reader;
      instructor_data.DataBind();
      reader.Close();


      command = new SqlCommand("SELECT * from ((enrollment inner join child ON enrollment.child_id=child.child_id) inner join parent ON child.parent_id=parent.parent_id) WHERE class_id=@class_id AND session_id=@session_id" , connection);
      command.Parameters.AddWithValue("@class_id", classDDL.SelectedValue);
      command.Parameters.AddWithValue("@session_id", sessionDDL.SelectedValue);
      reader = command.ExecuteReader();

      child_data.DataSource = reader;
      child_data.DataBind();
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
      connection.Close();
    }
  } // end get roster
}