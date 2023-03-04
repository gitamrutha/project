using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project
{
    public partial class log : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String str = "select count(Reg_id) from Log_table_1 where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";

            String cid = obj.Fun_exescalar(str);
            int cid1 = Convert.ToInt32(cid);
            if (cid1 == 1)
            {
                String str1 = "select Reg_id from Log_table_1 where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                String regid = obj.Fun_exescalar(str1);
                Session["User_id"] = regid;
                String str2 = "select Log_type from Log_table_1 where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                String logtype = obj.Fun_exescalar(str2);

                if (logtype == "Admin")
                {
                    //Label1.Text = "Admin";
                    Response.Redirect("category.aspx");
                }
                else if (logtype == "User")
                {
                    //Label1.Text = "User";
                }
            }

        }
    }
}