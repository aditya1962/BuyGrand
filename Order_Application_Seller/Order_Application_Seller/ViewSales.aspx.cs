using Microsoft.Reporting.WebForms;
using System;
using System.Data;

namespace Order_Application_Seller
{
    public partial class ViewSales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void View_Click(object sender, EventArgs e)
        {
            string startDateText = startdate.Text;
            string endDateText = enddate.Text;
            DateTime a = Convert.ToDateTime(startDateText);
            DateTime b = Convert.ToDateTime(endDateText);

            if(startDateText.Equals(""))
            {
                DateNull.Text = "Start date cannot be null";
                DateNull.Visible = true;
            }
            else if (endDateText.Equals(""))
            {
                DateNull.Text = "End date cannot be null";
                DateNull.Visible = true;
            }
            else if(a.CompareTo(b) > 0)
            {
                DateNull.Text = "Start date cannot be earlier than the end date";
                DateNull.Visible = true;
            }
            else
            {
                DataTable sales = GetSales(startDateText, endDateText);
                SalesReport.LocalReport.ReportPath = Server.MapPath("~/Reports/Sales.rdlc");
                ReportDataSource reportDataSource = new ReportDataSource("SalesData", sales);
                SalesReport.LocalReport.DataSources.Clear();
                SalesReport.LocalReport.DataSources.Add(reportDataSource);
                ReportParameter[] parameters = new ReportParameter[2];
                parameters[0] = new ReportParameter("StartDate", startDateText);
                parameters[1] = new ReportParameter("EndDate", endDateText);
                SalesReport.LocalReport.SetParameters(parameters);
                SalesReport.LocalReport.Refresh();
            }
        }

        public DataTable GetSales(string startDate, string endDate)
        {
            
        }
    }
}