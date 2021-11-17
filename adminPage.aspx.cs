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

  public void changeTable(object sender, EventArgs e)
  {
      switch (selectTable.SelectedItem.Text)
      {
        case "Session":
            Response.Redirect("table/session.aspx");
          break;
        case "Class":
            Response.Redirect("table/class.aspx");
          break;
        case "Time":
            Response.Redirect("table/time.aspx");
          break;
        case "Instructor":
            Response.Redirect("table/instructor.aspx");
          break;
        case "Parent":
          Response.Redirect("table/parent.aspx");
          break;
        case "Enrollment":
          Response.Redirect("table/enrollment.aspx");
          break;
        default:
          break;
      }
  }

}