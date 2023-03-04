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
    public partial class product_updation : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind_Grid();
            }
        }
            public void Bind_Grid()
            {
                string strsel = "select * from Product_table_1";
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
            int Pdt_id = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtdsec = (TextBox)GridView1.Rows[i].Cells[5].Controls[0];
            TextBox txtdprice = (TextBox)GridView1.Rows[i].Cells[6].Controls[0];
            TextBox txtstatus = (TextBox)GridView1.Rows[i].Cells[7].Controls[0];
            TextBox txtdstock = (TextBox)GridView1.Rows[i].Cells[8].Controls[0];
            string strup = "update Product_table_1 set Pdt_desc='" + txtdsec.Text + "',Pdt_price='" + txtdprice.Text + "',Pdt_status='" + txtstatus.Text + "',Pdt_stock='" + txtdstock.Text + "' where Pdt_id=" + Pdt_id + "";
            int s = obj.Fun_exenonquery(strup);
            GridView1.EditIndex = -1;
            Bind_Grid();


        }
    }
    }
