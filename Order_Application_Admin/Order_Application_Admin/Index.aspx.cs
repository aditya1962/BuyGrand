using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Order_Application_Admin
{
    public partial class Index : System.Web.UI.Page
    {
        public string users = "N/A", sellers = "N/A", items = "N/A", categories = "N/A",
                      subcategories = "N/A", orders = "N/A", sales = "N/A";
        Logging logging;
        protected void Page_Load(object sender, EventArgs e)
        {
                
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            DashboardReference.DashboardValuesSoapClient dashboard = new DashboardReference.DashboardValuesSoapClient();
            DataTable dashboardData = dashboard.GetDashboardData();
            if(dashboardData.Rows.Count > 0)
            {
                DataRow row = dashboardData.Rows[0];
                users = row["users"].ToString();
                sellers = row["sellers"].ToString();
                items = row["items"].ToString();
                categories = row["categories"].ToString();
                subcategories = row["subcategories"].ToString();
                orders = row["orders"].ToString();
                sales = row["sales"].ToString();
            }

            int months = 6; //currently set months to display as 6
            DataTable chartData = dashboard.GetChartDetails(months);
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