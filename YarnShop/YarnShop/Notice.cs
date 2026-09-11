using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarnShop
{
    public class Notice
    {
        // Attributes
        private int NoticeID { get; set; }
        private int ID { get; set; }
        private string Title { get; set; }
        private int Priority { get; set; }
        private DateTime DateIssued { get; set; }
        private DateTime DateToReview { get; set; }
        private bool Dismissed { get; set; }
        private bool Archived { get; set; }
        private string Type { get; set; }
        private string DescriptionText;
        public Notice(int newNoticeID, int newID, string newTitle, int newPriority, DateTime newDateIssued,  DateTime newDateToReview, bool newDismissed, bool newArchived, string newType) // Constructor
        {
            NoticeID = newNoticeID;
            ID = newID;
            Title = newTitle;
            Priority = newPriority;
            DateIssued = newDateIssued;
            DateToReview = newDateToReview;
            Dismissed = newDismissed;
            Archived = newArchived;
            Type = newType;
            DescriptionText = SetDescription();
        }

        // Getters
        public int noticeID
        {
            get { return NoticeID; }
        }
        public int id
        {
            get { return ID; }
        }
        public string title
        {
            get { return Title; }
        }
        public int priority
        {
            get { return Priority; }
        }
        public DateTime dateIssued
        {
            get { return DateIssued; }
        }
        public DateTime dateToReview
        {
            get { return DateToReview; }
        }
        public bool dismissed
        {
            get { return Dismissed; }
        }
        public bool archived
        {
            get { return Archived; }
        }
        public string type
        {
            get { return Type; }
        }
        public string description
        {
            get { return DescriptionText; }
        }
        public string NoticeTime() // Gets the string that informs how long ago the notice's review date was
        {
            string time = "";
            if (dateToReview < DateTime.Now) // If the review date is before today's date.
            {
                TimeSpan ts = DateTime.Now - dateToReview;
                if (ts.TotalHours < 1) // If the review datetime was less than 24 hours ago
                {
                    time = Math.Round(ts.TotalMinutes).ToString() + " m";
                }
                else if (ts.TotalHours < 24) // If the review datetime was less than 24 hours ago
                {
                    time = Math.Round(ts.TotalHours).ToString() + " hr";
                }
                else if (ts.TotalDays < 3)
                {
                    time = Math.Round(ts.TotalDays).ToString() + " days";
                }
                else
                {
                    time = dateToReview.ToShortDateString();
                }
            }
            else
            {
                time = dateToReview.ToShortDateString();
            }
            return time;
        }
        public string PriorityText() // Show on the notice box the priority of the notice
        {
            switch (priority)
            {
                case 1:
                    return "!";
                case 2:
                    return "!!";
                case 3:
                    return "!!!";
                default:
                    return "";
            }
        }
        public Product GetProductDetails() // Get the details of the product related to this notice
        {
            bool error = false;
            Product product = null;
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = con.CreateCommand();
            OleDbDataReader reader;
            con.Open();
            cmd.CommandText = "SELECT * FROM TableProducts WHERE ProductID = @pid";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@pid", id);
            cmd.Connection = con;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    product = new Product(Convert.ToInt32(reader[0]), reader[1].ToString(), Convert.ToSingle(reader[2]), Convert.ToInt32(reader[3]), reader[10].ToString(), Convert.ToInt32(reader[4]), Convert.ToBoolean(reader[11]), Convert.ToInt32(reader[12]), Convert.ToInt32(reader[13]));

                }
                catch
                {
                    if (!error)
                    {
                        MessageBox.Show("Product data is missing.", "Missing Data");
                        error = true;
                    }

                }
            }
            con.Close();
            return product;
        }
        public CustOrder GetCustOrderDetails() // Get the details of the customer order related to this notice
        {
            bool error = false;
            CustOrder custOrder = null;
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = con.CreateCommand();
            OleDbDataReader reader;
            con.Open();
            cmd.CommandText = "SELECT * FROM TableCustOrders WHERE CustOrderID = @oid";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@oid", id);
            cmd.Connection = con;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    custOrder = new CustOrder(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), Convert.ToDateTime(reader[2]), Convert.ToDateTime(reader[3]), reader[4].ToString(), Convert.ToDouble(reader[8]), Convert.ToDouble(reader[9]), Convert.ToString(reader[11]), Convert.ToDateTime(reader[6]), reader[5].ToString(), Convert.ToInt32(reader[7]), reader[10].ToString());

                }
                catch
                {
                    if (!error)
                    {
                        MessageBox.Show("Customer order data is missing.", "Missing Data");
                        error = true;
                    }

                }
            }
            con.Close();
            return custOrder;
        }
        public Order GetSupplierOrderDetails() // Get the details of the supplier order related to this notice
        {
            bool error = false;
            Order supplierOrder = null;
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = con.CreateCommand();
            OleDbDataReader reader;
            con.Open();
            cmd.CommandText = "SELECT * FROM TableSupplierOrders WHERE SupplierOrderID = @oid";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@oid", id);
            cmd.Connection = con;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    supplierOrder = new Order(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), Convert.ToDateTime(reader[2]), Convert.ToDateTime(reader[3]), reader[4].ToString(), Convert.ToDouble(reader[5]), Convert.ToDouble(reader[6]), Convert.ToString(reader[7]));

                }
                catch
                {
                    if (!error)
                    {
                        MessageBox.Show("Supplier order data is missing.", "Missing Data");
                        error = true;
                    }

                }
            }
            con.Close();
            return supplierOrder;
        }
        public Event GetEventDetails() // Get the details of the event related to this notice
        {
            bool error = false;
            Event shopEvent = null;
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = con.CreateCommand();
            OleDbDataReader reader;
            con.Open();
            cmd.CommandText = "SELECT * FROM TableEvents WHERE EventID = @oid";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@oid", id);
            cmd.Connection = con;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                bool cancelled = false;
                if (Convert.ToInt32(reader[11]) == -1 || Convert.ToBoolean(reader[11]))
                {
                    cancelled = true;
                }
                try
                {
                    shopEvent = new Event(Convert.ToInt32(reader[0]), reader[1].ToString(), Convert.ToDateTime(reader[2]), Convert.ToDateTime(reader[3]), Convert.ToDateTime(reader[4]), reader[5].ToString(), Convert.ToSingle(reader[6]), Convert.ToInt32(reader[7]), Convert.ToInt32(reader[8]), reader[9].ToString(), reader[10].ToString(), cancelled);
                }
                catch
                {
                    if (!error)
                    {
                        MessageBox.Show("Event data is missing.", "Missing Data");
                        error = true;
                    }

                }
            }
            con.Close();
            return shopEvent;
        }
        public string SetDescription() // Depending on the priority and the type of the notice, the description is generated
        {
            string description = "";
            switch (type)
            {
                case "Stock":
                    Product product = GetProductDetails();
                    description += "(" + product.id.ToString() + ") " + product.name;
                    switch (title)
                    {
                        case "Low Stock":
                            description += " stock levels are low.";
                            break;
                        case "No Stock":
                            description += " is out of stock.";
                            break;
                        case "Low Stock & Selling Fast":
                            description += "  is selling fast and stock levels are low.";
                            break;
                        case "Selling Fast":
                            description += "  is selling fast.";
                            break;
                        case "Low Sales":
                            description += " has had a low amount of sales in the past month.";
                            break;
                    }
                    break;
                case "Order Collection":
                    CustOrder custOrderNotCollected = GetCustOrderDetails();
                    description += "Order #" + custOrderNotCollected.orderID.ToString() + " has not been collected by Customer #" + custOrderNotCollected.id.ToString();
                    switch (title)
                    {
                        case "Order Collection Overdue: 1 day":
                            description += " 1 day past the collection window.";
                            break;
                        case "Order Collection Overdue: 3 days":
                            description += " 3 days past the collection window.";
                            break;
                        case "Order Collection Overdue: >5 days":
                            description += " >5 days past the collection window.";
                            break;
                    }
                    break;
                case "Order Processing":
                    CustOrder custOrderNotProcessed = GetCustOrderDetails(); 
                    description += "Order #" + custOrderNotProcessed.orderID.ToString() + " has not been processed for" ;
                    switch (title)
                    {
                        case "Order Processing Overdue: 1 day":
                            description += " 1 day past the delivery date.";
                            break;
                        case "Order Processing Overdue: 3 days":
                            description += " 3 days past the delivery date.";
                            break;
                        case "Order Processing Overdue: >5 days":
                            description += " >5 days past the delivery date.";
                            break;
                    }
                    break;
                case "Supply Delivery":
                    Order delayedOrder = GetSupplierOrderDetails();
                    description += "Order #" + delayedOrder.orderID.ToString() + "is overdue for delivery";
                    switch (title)
                    {
                        case "Supply Delivery Overdue: 1 day":
                            description += " 1 day past the expected delivery date.";
                            break;
                        case "Supply Delivery Overdue: 3 days":
                            description += " 3 days past the expected delivery date.";
                            break;
                        case "Supply Delivery Overdue: >5 days":
                            description += " >5 days past the expected delivery date.";
                            break;
                    }
                    break;
                case "Event Payments":
                    Event shopEvent = GetEventDetails();
                    List<EventAttendee> unpaidCustomers = shopEvent.GetCustomersUnpaid;
                    if (unpaidCustomers.Count > 1)
                    {
                        description += unpaidCustomers.Count.ToString() + " customers have not paid for the event " + shopEvent.name + ".";
                    }
                    else if(unpaidCustomers.Count == 1)
                    {
                        description += unpaidCustomers[0].customer.idName + " has not paid for the event " + shopEvent.name + ".";
                    }
                    else
                    {
                        description += "Resolved for " + shopEvent.name;
                    }
                    break;
                case "Event Spaces Available":
                    Event @event = GetEventDetails();
                    List<EventAttendee> waitingListCustomers = @event.GetWaitingListAttendees; 
                    if (waitingListCustomers.Count > 1)
                    {
                        description += "There are spaces available in the event " + @event.name + " for customers on the waiting list.";
                    }
                    else if (waitingListCustomers.Count == 1)
                    {
                        description += "There is a space available in the event " + @event.name +".";
                    }
                    else
                    {
                        description += "Resolved for " + @event.name;
                    }
                    break;

            }
            return description;
        }
    }
}
