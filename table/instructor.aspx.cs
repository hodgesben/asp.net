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
    Response.Redirect("instructor.aspx");
  }

    public void goAdminHome(object sender, EventArgs e){
    Response.Redirect("../adminPage.aspx");
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

  public void buttonAUD(object sender, EventArgs e)
  {
    modifyList.Visible = false;
    addConformation.Visible = false;
    updateConformation.Visible = false;
    deleteConformation.Visible = false;

    switch (selectTable.SelectedItem.Text)
    {
      case "Add":
        addPanel.Visible = true;
        break;
      case "Update":
        makeUpdateTable();
        break;
      case "Delete":
        makeDeleteTable();
        break;
      default:
        break;
      }  // end switch
  } // end buttonAUD

/*****************************************************************************************************/
/*********************************** ADD A ROCORD ****************************************************/
/*****************************************************************************************************/

/*********************************** ADD RECORD ******************************************************/

  public void add_record(Object Src, EventArgs E)
  {     
    conn();
    errorCheck.Visible = true;
    try
    {
      connection.Open();    
      command = new SqlCommand("INSERT INTO instructor (instructor_lname, instructor_fname, instructor_email, instructor_phone, instructor_password)" +
        " VALUES (@instructor_lname, @instructor_fname, @instructor_email, @instructor_phone, @instructor_password)", connection);
   
      command.Parameters.AddWithValue("@instructor_fname", add_instructorfNameTB.Text);
      command.Parameters.AddWithValue("@instructor_lname", add_instructorlNameTB.Text);
      command.Parameters.AddWithValue("@instructor_email", add_instructorEmailTB.Text);
      command.Parameters.AddWithValue("@instructor_phone", add_instructorPhoneTB.Text);
      command.Parameters.AddWithValue("@instructor_password", add_instructorPasswordTB.Text);

      command.ExecuteNonQuery();
      
      connection.Close();
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
      addConformation.Visible = true;
      addPanel.Visible = false;
    }    
  }  // end add_record

/*****************************************************************************************************/
/*********************************** UPDATE A ROCORD *************************************************/
/*****************************************************************************************************/

  /*************************** UPDATE RECORD Table *****************************************/

  public void makeUpdateTable()
  {
    updateTable.Visible = true;
    conn();

    try
    {
      connection.Open();
      lblInfo.Text = "<b>Server Version:</b> " + connection.ServerVersion;
      lblInfo.Text += "<br /><b>Connection Is:</b> " + connection.State.ToString(); 
      command = new SqlCommand("SELECT * FROM instructor", connection);
              
      reader = command.ExecuteReader();
      update_instructorNamesLB.DataSource = reader;
      update_instructorNamesLB.DataTextField = "instructor_lname";
      update_instructorNamesLB.DataValueField = "instructor_id";
      update_instructorNamesLB.DataBind();
      reader.Close();
    }
    catch (Exception err)
    {
      lblInfo.Text = "Error reading the database. ";
      lblInfo.Text += err.Message;
    }
    finally
    {
      connection.Close();
      lblInfo.Text += "<br /><b>Now Connection Is:</b> ";
      lblInfo.Text += connection.State.ToString();
    }
  }  // end makeTable


    /*************************** UPDATE RECORD LISTBOX *****************************************/
      
  public void update_record(Object Src, EventArgs E)
  {  
    updateTable.Visible = false;
    updatePannel.Visible = true;

    conn();
    try
    {
      // Try to open the connection.
      connection.Open();
      lblInfo.Text = "<b>Server Version:</b> " + connection.ServerVersion;
      lblInfo.Text += "<br /><b>Connection Is:</b> " + connection.State.ToString();
            
      command = new SqlCommand("SELECT * FROM instructor WHERE instructor_id=@id", connection);
      command.Parameters.AddWithValue("@id", update_instructorNamesLB.SelectedValue);
      reader = command.ExecuteReader();
            
      while (reader.Read())
      {
        update_instructorfNameTB.Text = (string) reader["instructor_fname"];
        update_instructorlNameTB.Text = (string) reader["instructor_lname"];
        update_instructorEmailTB.Text = (string) reader["instructor_email"];
        update_instructorPhoneTB.Text = (string) reader["instructor_phone"];
        update_instructorPasswordTB.Text = (string) reader["instructor_password"];
      }
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
      lblInfo.Text += "<br /><b>Now Connection Is:</b> ";
      lblInfo.Text += connection.State.ToString();
    }
  } // end update_data

    /*************************** UPDATE RECORD Button *****************************************/

  public void update_recordBTN(Object Src, EventArgs E)
  {
    conn();

    try
    {
      // Try to open the connection.
      connection.Open();
      lblInfo.Text = "<b>Server Version:</b> " + connection.ServerVersion;
      lblInfo.Text += "<br /><b>Connection Is:</b> " + connection.State.ToString();
            
      command = new SqlCommand("UPDATE instructor SET instructor_lname=@instructorlName, instructor_fname=@instructorfName," + 
        "instructor_email=@instructorEmail, instructor_phone=@instructorPhone, instructor_password=@instructorPassword WHERE instructor_id=@id", connection);

      command.Parameters.AddWithValue("@id", update_instructorNamesLB.SelectedValue);
      command.Parameters.AddWithValue("@instructorfName", update_instructorfNameTB.Text);
      command.Parameters.AddWithValue("@instructorlName", update_instructorlNameTB.Text);
      command.Parameters.AddWithValue("@instructorEmail", update_instructorEmailTB.Text);
      command.Parameters.AddWithValue("@instructorPhone", update_instructorPhoneTB.Text);
      command.Parameters.AddWithValue("@instructorPassword", update_instructorPasswordTB.Text);
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
      updateConformation.Visible = true;
      updatePannel.Visible = false;
    }
  } // end update_recordBTN

/*****************************************************************************************************/
/*********************************** DELETE A ROCORD *************************************************/
/*****************************************************************************************************/

/****************************** DELETE A ROCORD Table **********************************************/

  public void makeDeleteTable()
  {
    deleteTable.Visible = true;
    conn();

    try
    {
      connection.Open();
      lblInfo.Text = "<b>Server Version:</b> " + connection.ServerVersion;
      lblInfo.Text += "<br /><b>Connection Is:</b> " + connection.State.ToString(); 
      command = new SqlCommand("SELECT * FROM instructor", connection);
              
      reader = command.ExecuteReader();
      delete_instructorNamesLB.DataSource = reader;
      delete_instructorNamesLB.DataTextField = "instructor_lname";
      delete_instructorNamesLB.DataValueField = "instructor_id";
      delete_instructorNamesLB.DataBind();
      reader.Close();
    }
    catch (Exception err)
    {
      lblInfo.Text = "Error reading the database. ";
      lblInfo.Text += err.Message;
    }
    finally
    {
      connection.Close();
    }
  }  // end makeDeleteTable

/****************************** DELETE A ROCORD ListBox **********************************************/

  public void delete_record(Object Src, EventArgs E)
  {
    deleteTable.Visible = false;
    deletePannel.Visible = true;

    conn();
    try
    {
      // Try to open the connection.
      connection.Open();
      lblInfo.Text = "<b>Server Version:</b> " + connection.ServerVersion;
      lblInfo.Text += "<br /><b>Connection Is:</b> " + connection.State.ToString();
            
      command = new SqlCommand("SELECT * FROM instructor WHERE instructor_id=@id", connection);
      command.Parameters.AddWithValue("@id", delete_instructorNamesLB.SelectedValue);

      reader = command.ExecuteReader();
            
      while (reader.Read())
      {
        delete_instructorfNameTB.Text = (string) reader["instructor_fname"];
        delete_instructorlNameTB.Text = (string) reader["instructor_lname"];
        delete_instructorEmailTB.Text = (string) reader["instructor_email"];
        delete_instructorPhoneTB.Text = (string) reader["instructor_phone"];
        delete_instructorPasswordTB.Text = (string) reader["instructor_password"];
      }
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
  } // end delete_record


  /*************************** DELETE RECORD BUTTON *****************************************/

  public void delete_recordBTN(Object Src, EventArgs E)
  {  
    conn();

    try
    {
      connection.Open();
      lblInfo.Text = "<b>Server Version:</b> " + connection.ServerVersion;
      lblInfo.Text += "<br /><b>Connection Is:</b> " + connection.State.ToString(); 

      command = new SqlCommand("DELETE from instructor WHERE instructor_id=@id", connection);
      command.Parameters.AddWithValue("@id", delete_instructorNamesLB.SelectedValue);
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
      deleteConformation.Visible = true;
      deletePannel.Visible = false;
    }
  } // end delete_recordBTN
} // end class db