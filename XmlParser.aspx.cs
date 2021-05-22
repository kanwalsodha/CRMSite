using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

public partial class XmlParser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void UploadButton_Click(object sender, EventArgs e)
    {
        try
        {
            

            CRMMethods crmMethods = new CRMMethods();

            Customer customer = new Customer();
            BillingAddress bAddress = new BillingAddress();
            DeliveryAddress dAddress = new DeliveryAddress();
            List<OrderLines> orderLines = new List<OrderLines>();

            XmlDocument document = new XmlDocument();
            string fileName = Path.GetFileName(FileUploadControl.PostedFile.FileName);

            string filePath = Server.MapPath("~/XmlFiles/") + fileName;
            FileUploadControl.SaveAs(filePath);

            string xml = File.ReadAllText(filePath);
            document.LoadXml(xml);
            
            XmlNodeList xnOrders = document.SelectNodes("/Orders");

            foreach (XmlNode xn in xnOrders)
            {
                customer.FirstName = xn["FirstName"].InnerText;
                customer.LastName = xn["LastName"].InnerText;
                customer.UserName = xn["UserName"].InnerText;
                customer.Password = xn["Password"].InnerText;
                customer.Email = xn["Email"].InnerText;
                customer.Phone = xn["Phone"].InnerText;
            }
            XmlNodeList xnDeliveryAddress = document.SelectNodes("Orders/DeliveryAddress");

            foreach (XmlNode xn in xnDeliveryAddress)
            {
                bAddress.AddressLine1 = xn["AddressLine1"].InnerText;
                bAddress.AddressLine2 = xn["AddressLine2"].InnerText;
                bAddress.City = xn["City"].InnerText;
                bAddress.State = xn["State"].InnerText;
                bAddress.ZipCode = xn["ZipCode"].InnerText;
                bAddress.Phone = xn["Phone"].InnerText;
                bAddress.Country = xn["Country"].InnerText;
            }

            XmlNodeList xnBillingAddress = document.SelectNodes("Orders/BillingAddress");

            foreach (XmlNode xn in xnBillingAddress)
            {
                dAddress.AddressLine1 = xn["AddressLine1"].InnerText;
                dAddress.AddressLine2 = xn["AddressLine2"].InnerText;
                dAddress.City = xn["City"].InnerText;
                dAddress.State = xn["State"].InnerText;
                dAddress.ZipCode = xn["ZipCode"].InnerText;
                dAddress.Phone = xn["Phone"].InnerText;
                dAddress.Country = xn["Country"].InnerText;
            }

            XmlNodeList xnOrderLines = document.SelectNodes("Orders/OrderLines/OrderLine");

            foreach (XmlNode xn in xnOrderLines)
            {
                OrderLines ol = new OrderLines();

                ol.ItemId = Convert.ToInt64(xn["ItemId"].InnerText);
                ol.ItemQuantity = Convert.ToInt16(xn["ItemQuantity"].InnerText);
                orderLines.Add(ol);
            }

            crmMethods.EntriesIntoDatabase(customer, bAddress, dAddress, orderLines);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

}