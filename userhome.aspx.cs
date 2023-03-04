using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace project
{
    public partial class userhome : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string sel = "select Cat_id,Cat_image,Cat_name,Cat_dec from Category_table_1";
                DataSet ds = obj.Fun_exeAdapter(sel);
                DataList1.DataSource = ds;
                DataList1.DataBind();
            }
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Session["Cat_id"] = id;
            Response.Redirect("UserPdtDisplay.aspx");
        }
    }
}