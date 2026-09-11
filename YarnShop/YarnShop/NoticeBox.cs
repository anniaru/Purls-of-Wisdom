using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarnShop
{
    // This is used in Notices.
    // Displays the title, description, priority, time since the review date and whether it's been archived or dismissed.
    // Allows the user to access the forms relevant to the notice.
    public partial class NoticeBox : UserControl
    {
        // Attributes
        public Notice notice { get; private set; }

        // to pass the Event object to the parent form
        public delegate void NoticeUpdatedHandler(object sender, EventArgs e);
        public event NoticeUpdatedHandler NoticeUpdated;

        public NoticeBox(Notice notice, float height) // Constructor
        {
            this.notice = notice;
            InitializeComponent();
        }

        private void NoticeBox1_Load(object sender, EventArgs e)
        {
            titleLabel.Text = notice.title;
            descLabel.Text = notice.description;

            if (notice.dismissed) // Shows if the notice has been dismissed
            {
                timeLabel.Text = "DISMISSED UNTIL: " + notice.NoticeTime();
            }
            else
            {
                timeLabel.Text = notice.NoticeTime();
            }

            if (notice.archived) // Shows if the notice has been archived
            {
                pbxArchived.Visible = true;
            }
            else
            {
                pbxArchived.Visible = false;
            }

            priorityLabel.Text = notice.PriorityText(); // Shows the priority of the notice

            switch (notice.type) // Depending on the type of notice, the user can access different forms directly from the notice.
            {
                case "Stock":
                    if (notice.type.Contains("Sales"))
                    {
                        GoToFormToolStripMenuItem.Visible = false;
                    }
                    else
                    {
                        GoToFormToolStripMenuItem.Text = "Create New Supplier Order";
                    }
                    break;
                case "Order Collection":
                    GoToFormToolStripMenuItem.Text = "Customer Orders";
                    break;
                case "Order Processing":
                    GoToFormToolStripMenuItem.Text = "Customer Orders";
                    break;
                case "Supply Delivery":
                    GoToFormToolStripMenuItem.Text = "Supplier Orders";
                    break;
                case "Event Payments":
                    GoToFormToolStripMenuItem.Text = "Events";
                    break;
                case "Event Spaces Available":
                    GoToFormToolStripMenuItem.Text = "Events";
                    break;
            }
        }
        private void GoToFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (notice.type) // Depending on the type of notice, the user can access different forms directly from the notice.
            {
                case "Stock":
                    if (!notice.type.Contains("Sales")) // Create a new supplier order and automatically add the minimum amount of that product required to clear the notice
                    {
                        Product product = notice.GetProductDetails();
                        NewSupplierOrder newSupOrder = new NewSupplierOrder(product);
                        newSupOrder.ShowDialog();
                        Homepage.refreshOrderNotices();
                    }
                    Homepage.refreshStockNotices();
                    break;
                case "Order Collection": // Access the relevant order
                    CustOrder custOrder = notice.GetCustOrderDetails();
                    Orders newFormOrders = new Orders(custOrder, null);
                    newFormOrders.ShowDialog();
                    Homepage.refreshOrderNotices();
                    Homepage.refreshStockNotices();
                    break;
                case "Order Processing": // Access the relevant order
                    custOrder = notice.GetCustOrderDetails();
                    Orders nformOrders = new Orders(custOrder, null);
                    nformOrders.ShowDialog();
                    Homepage.refreshOrderNotices();
                    Homepage.refreshStockNotices();
                    break;
                case "Supply Delivery": // Access the relevant order
                    Order order = notice.GetSupplierOrderDetails();
                    Orders formOrders = new Orders(null, order);
                    formOrders.ShowDialog();
                    Homepage.refreshOrderNotices();
                    Homepage.refreshStockNotices();
                    break;
                case "Event Payments": // Access the relevant event
                    Event @event = notice.GetEventDetails();
                    Events newFormEvents = new Events(@event);
                    newFormEvents.ShowDialog();
                    Homepage.refreshEventNotices();
                    break;
                case "Event Spaces Available": // Access the relevant event
                    @event = notice.GetEventDetails();
                    Events formEvents = new Events(@event);
                    formEvents.ShowDialog();
                    Homepage.refreshEventNotices();
                    break;
            }

        }

        // Dismissing notices
        private void dayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Dismisses the notice for 1 day
            updateNotice(1);
        }
        private void daysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Dismisses the notice for 3 days
            updateNotice(3);
        }
        private void weekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Dismisses the notice for 1 week
            updateNotice(7);
        }
        private void updateNotice(int days)
        {
            // Dismisses the notice and sets the review date to the number of days specified by which tool strip menu item the user clicked.

            string command = "UPDATE ";
            switch (notice.type)
            {
                case "Stock":
                    command += "TableStockNotices";
                    break;
                case "Order Collection":
                    command += "TableCustOrderNotices";
                    break;
                case "Order Processing":
                    command += "TableCustOrderNotices";
                    break;
                case "Supply Delivery":
                    command += "TableSupplierOrderNotices";
                    break;
                case "Event Payments":
                    command += "TableEventNotices";
                    break;
                case "Event Spaces Available":
                    command += "TableEventNotices";
                    break;
            }


            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = command + " SET Dismissed = True, DateToReview = DateAdd('d'," + days + ",DateToReview) WHERE NoticeID = @nid";
            MessageBox.Show(cmd.CommandText);
            cmd.Parameters.AddWithValue("@nid", notice.noticeID);
            cmd.Connection = con;
            int status = cmd.ExecuteNonQuery();
            con.Close();
            
            // When a notice has been dismissed, the notices shown on the parent form must update so that this dismissed notice will not be shown.
            // This will trigger an event on the parent form to refresh the notice panel.
            OnNoticeUpdated(EventArgs.Empty);
        }
        private void OnNoticeUpdated(EventArgs e)
        {
            NoticeUpdated?.Invoke(this, e);
        }
        private void titleLabel_MouseEnter(object sender, EventArgs e) // Indicates when the mouse is hovering over the notice
        {
            titleLabel.BackColor = Color.FromArgb(153, 72, 93);
        }
        private void titleLabel_MouseLeave(object sender, EventArgs e) // Indicates when the mouse is hovering over the notice
        {
            titleLabel.BackColor = Color.FromArgb(139, 65, 85);

        }
    }
}
