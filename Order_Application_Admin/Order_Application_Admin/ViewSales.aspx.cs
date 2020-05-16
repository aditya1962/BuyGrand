using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Windows;
using Order_Application_Admin.Data;

namespace Order_Application_Admin
{
    public partial class ViewSales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void View_Click(object sender, EventArgs e)
        {
            string startDate = startdate.Text.ToString();
            string endDate = enddate.Text.ToString();
            try
            {
                DataTable dt = GetSales(startDate, endDate);
                if(dt!=null && dt.Rows.Count > 0)
                {
                    dateErrorLabel.Visible = false;
                    ReportDataNull.Visible = false;

                    SalesReport.LocalReport.ReportPath = Server.MapPath("~/Reports/SalesReport.rdlc");
                    ReportDataSource source = new ReportDataSource("SalesReportDataSet", dt);
                    SalesReport.LocalReport.DataSources.Clear();
                    SalesReport.LocalReport.DataSources.Add(source);
                    ReportParameter[] parameters = new ReportParameter[2];
                    parameters[0] = new ReportParameter("StartDate", startDate);
                    parameters[1] = new ReportParameter("EndDate", endDate);
                    SalesReport.LocalReport.SetParameters(parameters);
                    SalesReport.LocalReport.Refresh();
                }
                else
                {
                    ReportDataNull.Text = "No data to generate report";
                    ReportDataNull.Visible = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable GetSales(string startDate, string endDate)
        {
            DataTable sales;
            if(startDate=="")
            {
                dateErrorLabel.Text = "Start Date cannot be empty";
                dateErrorLabel.Visible = true;
                return null;
            }
            if(endDate=="")
            {
                dateErrorLabel.Text = "End Date cannot be empty";
                dateErrorLabel.Visible = true;
                return null;
            }
            if(Convert.ToDateTime(startDate) > Convert.ToDateTime(endDate))
            {
                dateErrorLabel.Visible = true;
                return null;
            }
            else
            {
                DataAccess da = new DataAccess();
                sales = da.getSalesData(startDate,endDate);
                return sales;
            }
        }
    }
}