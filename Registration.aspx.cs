using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

public partial class Registration : System.Web.UI.Page
{
    string xmlFilePath = ConfigurationManager.AppSettings["PathFolder"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int CustomerID = RandomNumber(1, 10000);
        XDocument doc = new XDocument(
                new XDeclaration("1.0", "gb2312", string.Empty),

                new XElement("Orders",
                    new XElement("Customer",                        
                         new XElement("FirstName", first_name.Text),
                         new XElement("LastName", last_name.Text),
                         new XElement("UserName", UserName.Text),
                         new XElement("Password", password.Text),
                         new XElement("Email", email.Text),
                         new XElement("Phone", PhoneNumber.Text),
                         new XElement("BillingAddress", BillingAddress.Text),
                         new XElement("DeliveryAddress", DeliveryAddress.Text)),

                    new XElement("OrderLines",           
                     new XElement("OrderLine",
                        new XElement("ItemId", RandomNumber(1,100)),
                        new XElement("ItemName", lblitem1.Text),
                        new XElement("ItemQuantity", txtqty1.Text),
                        new XElement("ItemPrice", lblPrice1.Text),
                        new XElement("Status", "Submitted"),
                         new XElement("CustomerID", 0)
                        ),

                     new XElement("OrderLine",
                        new XElement("ItemId", RandomNumber(1, 100)),
                        new XElement("ItemName", lblitem2.Text),
                        new XElement("ItemQuantity", txtQty2.Text),
                        new XElement("ItemPrice", lblPrice2.Text),
                        new XElement("Status", "Submitted"),
                         new XElement("CustomerID", 0)
                        )

                     )
                    
                    )
                );


        string fileName = first_name.Text + "-" + last_name.Text + ".xml";

        doc.Save(xmlFilePath + fileName);


        string message = "Customer have been saved successfully.";
        string script = "window.onload = function(){ alert('";
        script += message;
        script += "')};";

        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);


    }
    private readonly Random _random = new Random();
    public int RandomNumber(int min, int max)
    {
        return _random.Next(min, max);
    }
}