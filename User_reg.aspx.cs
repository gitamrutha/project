using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace project
{

    public partial class User_reg : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select max(Reg_id) from Log_table_1";
            String regid = obj.Fun_exescalar(sel);
            int Reg_id = 0;
            if (regid == "")
            {
                Reg_id = 1;
            }
            else
            {
                int newregid = Convert.ToInt32(regid);
                {
                    Reg_id = newregid + 1;
                }
                string ch = DropDownList1.SelectedItem.Text;
                string r = RadioButtonList1.SelectedItem.Text;
                string img = "~/phs/" + FileUpload1.FileName;
                FileUpload1.SaveAs(MapPath(img));
                string ins = "insert into User_table_1 values(" + Reg_id + ",'" + TextBox1.Text + "','" + TextBox3.Text + "','" + TextBox5.Text + "','" + ch + "','" + TextBox6.Text + "','" + TextBox2.Text + "','" + TextBox4.Text + "','" + r + "','" + img + "')";
                int i = obj.Fun_exenonquery(ins);
                String inslog = "insert into Log_table_1 values(" + Reg_id + ",'User','" + TextBox7.Text + "','" + TextBox8.Text + "','Active')";
                int s = obj.Fun_exenonquery(inslog);
                if (i != 0 && s != 0)
                {
                    Label1.Text = "Registered";
                }



            }
        }
    }
}
