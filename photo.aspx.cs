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
  public static string photo_filename;

  public void goHome(object sender, EventArgs e){
    Response.Redirect("photo.aspx");
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
      connection.Open();

      if (!IsPostBack)
      {
        command = new SqlCommand("SELECT * FROM instructor", connection);

        reader = command.ExecuteReader();
        intructorNameDDL.DataSource = reader;
        intructorNameDDL.DataTextField = "instructor_lname";
        intructorNameDDL.DataValueField = "instructor_id";
        intructorNameDDL.DataBind();
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
  } // end of onLoad

/*****************************************************************************************************/
/*********************************** ADD A PHOTO ****************************************************/
/*****************************************************************************************************/

/*********************************** PATH PHOTO ******************************************************/

protected void UploadButton_Click(object sender, EventArgs e)
{
    if(FileUploadControl.HasFile)
    {
        try
        {
            if(FileUploadControl.PostedFile.ContentType == "image/jpeg")
            {
                if(FileUploadControl.PostedFile.ContentLength < 102400)
                {
                    string filename = System.IO.Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("~/largeProject2/") + filename);
                    string mapname = (Server.MapPath("~/largeProject2/") + filename);
                   
                   photo_filename = filename; 
			      
             //StatusLabel.Text = mapname;
				 Image1.ImageUrl = filename;
	
                   // StatusLabel.Text = "Upload status: File uploaded!";
                }
                else
                    StatusLabel.Text = "Upload status: The file has to be less than 100 kb!";
            }
            else
                StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
        }
        catch(Exception ex)
        {
            StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
        }
    }
   } // end uploadButton

  

protected void Update_Photo_Click(object sender, EventArgs e)
{ 
  conn();

  try
  {
    connection.Open();

    command = new SqlCommand("INSERT INTO photo (instructor_id, photo_filename)" +
      " VALUES (@id, @file_name)", connection);
          
    command.Parameters.AddWithValue("@id", intructorNameDDL.SelectedValue);
    command.Parameters.AddWithValue("@file_name", photo_filename);
          
    command.ExecuteNonQuery();      
    connection.Close();

    addConformation.Visible = true;
    addPanel.Visible = false;
  }
  catch (Exception err)
  {
    // Handle an error by displaying the information.
            lblInfo.Text = "Error reading the database. ";
            lblInfo.Text += err.Message;
            Response.Write("you have error add records");  
        }
    finally
    {
            connection.Close();
            lblInfo.Text += "<br /><b>Record has been added</b> ";
            //lblInfo.Text += connection.State.ToString();
      
    } 
  }
} // end class db