//------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft.  All rights reserved.
// </copyright>
//------------------------------------------------------------------
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //set Processing Mode of Report as Local  
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            //set path of the Local report  
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/CustomerReport.rdlc");
            //creating object of DataSet dsEmployee and filling the DataSet using SQLDataAdapter  
            dsCustomers dsemp = new dsCustomers();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-UIUBBVK;Initial Catalog=CRM;Integrated Security=True");
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Customers", con);
            adapt.Fill(dsemp, "Customers");
            con.Close();
            //Providing DataSource for the Report  
            ReportDataSource rds = new ReportDataSource("dsCustomers", dsemp.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            //Add ReportDataSource  
            ReportViewer1.LocalReport.DataSources.Add(rds);
        }
    }
}
