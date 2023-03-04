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
    public partial class UserProfileView : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Bind_Grid();
            }

        }
        public void Bind_Grid()
        {
            string strsel = "select User_table_1.User_id,User_table_1.User_name,Log_table_1.Username,Log_table_1.Status from User_table_1 join Log_table_1 on User_table_1.User_id=Log_table_1.Reg_id";
            DataSet ds = obj.Fun_exeAdapter(strsel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Bind_Grid();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Bind_Grid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int Reg_id = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox ststxt = (TextBox)GridView1.Rows[i].Cells[4].Controls[0];
            string strup="update Log_table_1 set Status='"+ststxt.Text+"' where Reg_id=" + Reg_id + "";
            int s = obj.Fun_exenonquery(strup);
            GridView1.EditIndex = -1;
            Bind_Grid();
        }
    }
}