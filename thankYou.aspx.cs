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
	public void Page_Load(object sender, EventArgs e) {
		name.Text = "Name: " + Session["name"];
    class2.Text = "Class: " + Session["class"];
		session.Text = "Session: "  + Session["session"];
		cost.Text = "Cost: " + Session["cost"];
		time.Text = "Time: " + Session["time"];
	}
	public void emailAdmin(Object Src, EventArgs E) {
      Response.Redirect("email.aspx");
	}
}