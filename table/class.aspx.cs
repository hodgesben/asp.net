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
    Response.Redirect("class.aspx");
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
      command = new SqlCommand("INSERT INTO class (class_name, class_desc, class_cost)" +
        " VALUES (@class_name, @class_desc, @class_cost)", connection);
   
      command.Parameters.AddWithValue("@class_name", add_classNameTB.Text);
      command.Parameters.AddWithValue("@class_desc", add_classDescTB.Text);
      command.Parameters.AddWithValue("@class_cost", add_classCostTB.Text);

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
      command = new SqlCommand("SELECT * FROM class", connection);
              
      reader = command.ExecuteReader();
      update_classNamesLB.DataSource = reader;
      update_classNamesLB.DataTextField = "class_name";
      update_classNamesLB.DataValueField = "class_id";
      update_classNamesLB.DataBind();
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
            
      command = new SqlCommand("SELECT * FROM class WHERE class_id=@id", connection);
      command.Parameters.AddWithValue("@id", update_classNamesLB.SelectedValue);
      reader = command.ExecuteReader();
            
      while (reader.Read())
      {
        update_classNameTB.Text = (string) reader["class_name"];
        update_classDateTB.Text = (string) reader["class_desc"];
        update_classCostTB.Text = (string) reader["class_cost"];
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
            
      command = new SqlCommand("UPDATE class SET class_name=@className, class_desc=@classDesc, class_cost=@classCost WHERE class_id=@id", connection);

      command.Parameters.AddWithValue("@id", update_classNamesLB.SelectedValue);
      command.Parameters.AddWithValue("@className", update_classNameTB.Text);
      command.Parameters.AddWithValue("@classDesc", update_classDateTB.Text);
      command.Parameters.AddWithValue("@classCost", update_classCostTB.Text);
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
      command = new SqlCommand("SELECT * FROM class", connection);
              
      reader = command.ExecuteReader();
      delete_classNamesLB.DataSource = reader;
      delete_classNamesLB.DataTextField = "class_name";
      delete_classNamesLB.DataValueField = "class_id";
      delete_classNamesLB.DataBind();
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
            
      command = new SqlCommand("SELECT * FROM class WHERE class_id=@id", connection);
      command.Parameters.AddWithValue("@id", delete_classNamesLB.SelectedValue);

      reader = command.ExecuteReader();
            
      while (reader.Read())
      {
        delete_classNameTB.Text = (string) reader["class_name"];
        delete_classDateTB.Text = (string) reader["class_desc"];
        delete_classCostTB.Text = (string) reader["class_cost"];
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

      command = new SqlCommand("DELETE from class WHERE class_id=@id", connection);
      command.Parameters.AddWithValue("@id", delete_classNamesLB.SelectedValue);
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