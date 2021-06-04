using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WcfTest : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var client = new CustomerService.Service1Client();
            CustomersGridView.DataSource = client.GetCustomers();
            CustomersGridView.DataBind();
        }
    }
}