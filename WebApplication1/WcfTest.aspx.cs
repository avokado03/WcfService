using System;
using System.Web.UI;

namespace WebApplication1
{
    public partial class WcfTest : Page
    {
        private CustomerService.Service1Client _client;

        public WcfTest()
        {
            _client = new CustomerService.Service1Client();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CustomersGridView.DataSource = _client.GetCustomers();
            CustomersGridView.DataBind();
        }

        protected void CustomersGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = Convert.ToInt32(CustomersGridView.SelectedDataKey.Value);
            OrdersGridView.DataSource = _client.GetOrders(selected);
            OrdersGridView.DataBind();
            Order_Pnl.Visible = true;
        }

        protected void Order_Ok_Btn_Click(object sender, EventArgs e)
        {
            OrdersGridView.DataSource = null;
            Order_Pnl.Visible = false;
        }
    }
}