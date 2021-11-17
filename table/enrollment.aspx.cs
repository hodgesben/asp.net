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
    Response.Redirect("enrollment.aspx");
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
    updateConformation.Visible = false;
    deleteConformation.Visible = false;

    switch (selectTable.SelectedItem.Text)
    {
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
      command = new SqlCommand("SELECT * FROM enrollment", connection);
              
      reader = command.ExecuteReader();
      update_enrollLB.DataSource = reader;
      update_enrollLB.DataTextField = "enrollment_id";
      update_enrollLB.DataValueField = "enrollment_id";
      update_enrollLB.DataBind();
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
            
      command = new SqlCommand("SELECT * FROM enrollment WHERE enrollment_id=@id", connection);
      command.Parameters.AddWithValue("@id", update_enrollLB.SelectedValue);
      reader = command.ExecuteReader();
            
      while (reader.Read())
      {
        update_enrollIDTB.Text = ((int) reader["enrollment_id"]).ToString();
        update_classIDTB.Text = ((int) reader["class_id"]).ToString();
        update_sessionIDTB.Text = ((int) reader["session_id"]).ToString();
        update_instructorIDTB.Text = ((int) reader["instructor_id"]).ToString();
        update_childIDTB.Text = ((int) reader["child_id"]).ToString();
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
            
      command = new SqlCommand("UPDATE enrollment SET class_id=@classid," + 
        "session_id=@sessionid, instructor_id=@instructorid, child_id=@childid WHERE enrollment_id=@enrollid", connection);

      command.Parameters.AddWithValue("@enrollid", update_enrollLB.SelectedValue);
      command.Parameters.AddWithValue("@classid", update_classIDTB.Text);
      command.Parameters.AddWithValue("@sessionid", update_sessionIDTB.Text);
      command.Parameters.AddWithValue("@instructorid", update_instructorIDTB.Text);
      command.Parameters.AddWithValue("@childid", update_childIDTB.Text);
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
      command = new SqlCommand("SELECT * FROM enrollment", connection);
              
      reader = command.ExecuteReader();
      delete_enrollLB.DataSource = reader;
      delete_enrollLB.DataTextField = "enrollment_id";
      delete_enrollLB.DataValueField = "enrollment_id";
      delete_enrollLB.DataBind();
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
            
      command = new SqlCommand("SELECT * FROM enrollment WHERE enrollment_id=@id", connection);
      command.Parameters.AddWithValue("@id", delete_enrollLB.SelectedValue);

      reader = command.ExecuteReader();
            
      while (reader.Read())
      {
        delete_enrollIDTB.Text = (string) reader["enrollment_id"].ToString();
        delete_classIDTB.Text = (string) reader["class_id"].ToString();
        delete_sessionIDTB.Text = (string) reader["session_id"].ToString();
        delete_instructorIDTB.Text = (string) reader["instructor_id"].ToString();
        delete_childIDTB.Text = (string) reader["child_id"].ToString();
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

      command = new SqlCommand("DELETE from enrollment WHERE enrollment_id=@id", connection);
      command.Parameters.AddWithValue("@id", delete_enrollLB.SelectedValue);
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