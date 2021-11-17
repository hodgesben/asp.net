using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class db : System.Web.UI.Page
{

  SqlConnection connection;
  SqlCommand command;
  SqlDataReader reader;
  int parentID = 0;
  int CHILD_ID = -1;

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
      lblInfo.Text = "<b>Server Version:</b> " + connection.ServerVersion;
      lblInfo.Text += "<br /><b>Connection Is:</b> " + connection.State.ToString();
            
      command = new SqlCommand("SELECT * FROM session", connection);
      reader =  command.ExecuteReader();
      sessionData.DataSource = reader;
      sessionData.DataBind();
            
      command = new SqlCommand("SELECT * FROM class", connection);
      reader = command.ExecuteReader();
      costFeeTable.DataSource = reader;
      costFeeTable.DataBind();

    if (!IsPostBack)
    {
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


      command = new SqlCommand("SELECT * FROM time", connection);
      
      reader = command.ExecuteReader();
      timeDDL.DataSource = reader;
      timeDDL.DataTextField = "time_name";
      timeDDL.DataValueField = "time_id";
      timeDDL.DataBind();
    }

      command = new SqlCommand("SELECT * FROM parent WHERE parent_email=@parentEmail", connection);
      command.Parameters.AddWithValue("@parentEmail", Session["parentEmail"]);
      reader = command.ExecuteReader();

      while (reader.Read())
      {
        parentID = (int) reader["parent_id"];
        pName.Text = (string) reader["parent_fname"];
        pName.Text += " ";
        pName.Text += (string) reader["parent_lname"];
        pEmail.Text = (string) reader["parent_email"];
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
  } // end of onLoad

 /********************************* Registers child *************************************************** */

  public void regChild(Object Src, EventArgs E)
  {
    if(noChild())
    {
      addChild();
    }

    Session["name"] = child_fName.Text + " " + child_lName.Text;
    Session["session"] = sessionDDL.SelectedItem;
    Session["class"] = classDDL.SelectedItem;
    Session["cost"] = getCost(Session["class"]);
    Session["time"] = timeDDL.SelectedItem;


    enroll(child_fName.Text, child_lName.Text, Session["session"], Session["class"]);


    Response.Redirect("thankYou.aspx");
  } 


 /********************************* Enroll child into ENrollment table ************************************************ */

  public void enroll(String childfName, String childlName, Object sessionName, Object className)
  {
    int childId = -1;
    int classId = -1;
    int sessionId = -1;

    conn();

    try 
    {
      connection.Open();
      command = new SqlCommand("SELECT * FROM child WHERE parent_id=@parent_id AND child_fname=@child_fname AND child_lname=@child_lname", connection);
      command.Parameters.AddWithValue("@parent_id", parentID);
      command.Parameters.AddWithValue("@child_fname", childfName);
      command.Parameters.AddWithValue("@child_lname", childlName);
      reader = command.ExecuteReader();

      while (reader.Read())
      {
        childId = (int) reader["child_id"];
      }
      reader.Close();

      command = new SqlCommand("SELECT * FROM class WHERE class_name=@class_name", connection);
      command.Parameters.AddWithValue("@class_name", className.ToString());
      reader = command.ExecuteReader();

      while (reader.Read())
      {
        classId = (int) reader["class_id"];
      }
      reader.Close();

      command = new SqlCommand("SELECT * FROM session WHERE session_name=@session_name", connection);
      command.Parameters.AddWithValue("@session_name", sessionName.ToString());
      reader = command.ExecuteReader();

      while (reader.Read())
      {
        sessionId = (int) reader["session_id"];
      }
      reader.Close();

      //  ADD INTO ENROLMENT TABLE
   
      command = new SqlCommand("INSERT INTO enrollment (class_id, session_id, instructor_id, child_id)" +
        " VALUES (@class_id, @session_id, @instructor_id, @child_id)", connection);
   
      command.Parameters.AddWithValue("@class_id", classId);
      command.Parameters.AddWithValue("@session_id", sessionId);
      command.Parameters.AddWithValue("@instructor_id", -1);
      command.Parameters.AddWithValue("@child_id", childId);

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
    }  
  } // end enroll

/********************************* Gets cost based on class ***************************************************** */

  public String getCost(Object className)
  {
    conn();
    String cost = "";

    try 
    {
      connection.Open();
      command = new SqlCommand("SELECT class_name, class_cost FROM class WHERE class_name=@class_name", connection);
      command.Parameters.AddWithValue("@class_name", className.ToString());
      reader = command.ExecuteReader();

      while (reader.Read())
      {
        cost = (string) reader["class_cost"];
        return cost;
      }
      reader.Close();
      return cost;
    }
    catch (Exception err)
    {
      // Handle an error by displaying the information.
      lblInfo.Text = "Error reading the database. ";
      lblInfo.Text += err.Message;
      return cost;
    }
    finally
    {
      connection.Close();
    }  
  } // end getCost

    /********************************* Checks If child is registered *********************************************** */

  protected bool noChild()
  {
    conn();

  try {
  connection.Open();
  command = new SqlCommand("SELECT parent_id, child_fname, child_lname FROM child WHERE parent_id=@parent_id AND child_fname=@child_fname AND child_lname=@child_lname", connection);
  command.Parameters.AddWithValue("@parent_id", parentID);
  command.Parameters.AddWithValue("@child_fname", child_fName.Text);
  command.Parameters.AddWithValue("@child_lname", child_lName.Text);

      SqlDataAdapter da = new SqlDataAdapter(command);
      DataTable dt = new DataTable();

       da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            return false;
        }
        else
        {
          return true;
        }
    } 
    
    catch (Exception err)
    {
      return false;
    }

    finally
    {
      connection.Close();
    }
  } // end noChild

    /********************************* ADD A CHILD ROCORD *********************************************** */

  protected void addChild()
  {
    conn();

    try
    {
      connection.Open();    
      command = new SqlCommand("INSERT INTO child (parent_id, child_fname, child_lname)" +
        " VALUES (@parent_id, @child_fname, @child_lname)", connection);
   
      command.Parameters.AddWithValue("@parent_id", parentID);
      command.Parameters.AddWithValue("@child_fname", child_fName.Text);
      command.Parameters.AddWithValue("@child_lname", child_lName.Text);

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
    }  
  } // end addChild
} 