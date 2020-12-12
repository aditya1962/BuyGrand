using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Order_Application_Seller
{
    public partial class Index : System.Web.UI.Page
    {
        public string items;
        public string categories;
        public string subcategories; 
        public string orders;
        public string sales;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"]==null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                DashboardReference.DashboardSoapClient dashboard = new DashboardReference.DashboardSoapClient();
                DataTable data = dashboard.GetDashboard();
                DataRow row = data.Rows[0];
                items = row["items"].ToString();
                categories = row["categories"].ToString();
                subcategories = row["subcategories"].ToString();
                orders = row["orders"].ToString();
                sales = row["sales"].ToString();

                DataTable chartData = dashboard.GetChart();
                SalesChart.Series["SalesSeries"].IsValueShownAsLabel = true;
                SalesChart.Series["SalesSeries"].XValueMember = "SubmittedDate";
                SalesChart.Series["SalesSeries"].YValueMembers = "TotalPrice";
                SalesChart.ChartAreas["ChartArea1"].AxisX.Title = "Month";
                SalesChart.ChartAreas["ChartArea1"].AxisY.Title = "Total Sales ($)";
                SalesChart.DataSource = chartData;
                SalesChart.DataBind();
            }
        }

        
    }
}