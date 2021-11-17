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
    Response.Redirect("session.aspx");
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
      command = new SqlCommand("INSERT INTO session (session_name, session_dates)" +
        " VALUES (@session_name, @session_date)", connection);
   
      command.Parameters.AddWithValue("@session_name", add_sessionNameTB.Text);
      command.Parameters.AddWithValue("@session_date", add_sessionDateTB.Text);
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
      command = new SqlCommand("SELECT * FROM session", connection);
              
      reader = command.ExecuteReader();
      update_sessionNamesLB.DataSource = reader;
      update_sessionNamesLB.DataTextField = "session_name";
      update_sessionNamesLB.DataValueField = "session_id";
      update_sessionNamesLB.DataBind();
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
            
      command = new SqlCommand("SELECT * FROM session WHERE session_id=@id", connection);
      command.Parameters.AddWithValue("@id", update_sessionNamesLB.SelectedValue);
      reader = command.ExecuteReader();
            
      while (reader.Read())
      {
        update_SessionNameTB.Text = (string) reader["session_name"];
        update_SessionDateTB.Text = (string) reader["session_dates"];
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
  } // end update_data

    /*************************** UPDATE RECORD Button *****************************************/

  public void update_recordBTN(Object Src, EventArgs E)
  {
    conn();
    errorCheck.Visible = true;

    try
    {
      // Try to open the connection.
      connection.Open();
      lblInfo.Text = "<b>Server Version:</b> " + connection.ServerVersion;
      lblInfo.Text += "<br /><b>Connection Is:</b> " + connection.State.ToString();
            
      command = new SqlCommand("UPDATE session SET session_name=@sessionName, session_dates=@sessionDates WHERE session_id=@id", connection);

      command.Parameters.AddWithValue("@id", update_sessionNamesLB.SelectedValue);
      command.Parameters.AddWithValue("@sessionName", update_SessionNameTB.Text);
      command.Parameters.AddWithValue("@sessionDates", update_SessionDateTB.Text);
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
      command = new SqlCommand("SELECT * FROM session", connection);
              
      reader = command.ExecuteReader();
      delete_sessionNamesLB.DataSource = reader;
      delete_sessionNamesLB.DataTextField = "session_name";
      delete_sessionNamesLB.DataValueField = "session_id";
      delete_sessionNamesLB.DataBind();
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
            
      command = new SqlCommand("SELECT * FROM session WHERE session_id=@id", connection);
      command.Parameters.AddWithValue("@id", delete_sessionNamesLB.SelectedValue);

      reader = command.ExecuteReader();
            
      while (reader.Read())
      {
        delete_SessionNameTB.Text = (string) reader["session_name"];
        delete_SessionDateTB.Text = (string) reader["session_dates"];
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

      command = new SqlCommand("DELETE from session WHERE session_id=@id", connection);
      command.Parameters.AddWithValue("@id", delete_sessionNamesLB.SelectedValue);
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