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
    
    public partial class UserPdtDisplay : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
          if(!IsPostBack)
            {
                string sel = "select * from Product_table_1 where Cat_id='" + Session["Cat_id"] + "'";
                DataSet ds = obj.Fun_exeAdapter(sel);
                DataList1.DataSource = ds;
                DataList1.DataBind();
            }
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int pid = Convert.ToInt32(e.CommandArgument);
            Session["Pdt_id"] = pid;
            Response.Redirect("productview.aspx");

        }
    }
}