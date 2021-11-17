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
    Response.Redirect("parent.aspx");
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
      command = new SqlCommand("INSERT INTO parent (parent_lname, parent_fname, parent_email, parent_phone, parent_password)" +
        " VALUES (@parent_lname, @parent_fname, @parent_email, @parent_phone, @parent_password)", connection);
   
      command.Parameters.AddWithValue("@parent_fname", add_parentfNameTB.Text);
      command.Parameters.AddWithValue("@parent_lname", add_parentlNameTB.Text);
      command.Parameters.AddWithValue("@parent_email", add_parentEmailTB.Text);
      command.Parameters.AddWithValue("@parent_phone", add_parentPhoneTB.Text);
      command.Parameters.AddWithValue("@parent_password", add_parentPasswordTB.Text);

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
      command = new SqlCommand("SELECT * FROM parent", connection);
              
      reader = command.ExecuteReader();
      update_parentNamesLB.DataSource = reader;
      update_parentNamesLB.DataTextField = "parent_lname";
      update_parentNamesLB.DataValueField = "parent_id";
      update_parentNamesLB.DataBind();
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
            
      command = new SqlCommand("SELECT * FROM parent WHERE parent_id=@id", connection);
      command.Parameters.AddWithValue("@id", update_parentNamesLB.SelectedValue);
      reader = command.ExecuteReader();
            
      while (reader.Read())
      {
        update_parentfNameTB.Text = (string) reader["parent_fname"];
        update_parentlNameTB.Text = (string) reader["parent_lname"];
        update_parentEmailTB.Text = (string) reader["parent_email"];
        update_parentPhoneTB.Text = (string) reader["parent_phone"];
        update_parentPasswordTB.Text = (string) reader["parent_password"];
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
            
      command = new SqlCommand("UPDATE parent SET parent_lname=@parentlName, parent_fname=@parentfName," + 
        "parent_email=@parentEmail, parent_phone=@parentPhone, parent_password=@parentPassword WHERE parent_id=@id", connection);

      command.Parameters.AddWithValue("@id", update_parentNamesLB.SelectedValue);
      command.Parameters.AddWithValue("@parentfName", update_parentfNameTB.Text);
      command.Parameters.AddWithValue("@parentlName", update_parentlNameTB.Text);
      command.Parameters.AddWithValue("@parentEmail", update_parentEmailTB.Text);
      command.Parameters.AddWithValue("@parentPhone", update_parentPhoneTB.Text);
      command.Parameters.AddWithValue("@parentPassword", update_parentPasswordTB.Text);
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
      command = new SqlCommand("SELECT * FROM parent", connection);
              
      reader = command.ExecuteReader();
      delete_parentNamesLB.DataSource = reader;
      delete_parentNamesLB.DataTextField = "parent_lname";
      delete_parentNamesLB.DataValueField = "parent_id";
      delete_parentNamesLB.DataBind();
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
            
      command = new SqlCommand("SELECT * FROM parent WHERE parent_id=@id", connection);
      command.Parameters.AddWithValue("@id", delete_parentNamesLB.SelectedValue);

      reader = command.ExecuteReader();
            
      while (reader.Read())
      {
        delete_parentfNameTB.Text = (string) reader["parent_fname"];
        delete_parentlNameTB.Text = (string) reader["parent_lname"];
        delete_parentEmailTB.Text = (string) reader["parent_email"];
        delete_parentPhoneTB.Text = (string) reader["parent_phone"];
        delete_parentPasswordTB.Text = (string) reader["parent_password"];
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

      command = new SqlCommand("DELETE from parent WHERE parent_id=@id", connection);
      command.Parameters.AddWithValue("@id", delete_parentNamesLB.SelectedValue);
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