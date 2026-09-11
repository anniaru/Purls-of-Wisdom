using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarnShop
{
    public partial class Homepage : Form
    {
        static string connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
        static int month, year;
        public Homepage()
        {
            InitializeComponent();
        }
        // Make form draggable
        bool drag = false;
        Point dragCursor;
        Point dragForm;
        private void pbxBar_MouseDown(object sender, MouseEventArgs e) // Detects when the mouse is down and allows the user to drag
        {
            drag = true;
            dragCursor = Cursor.Position;
            dragForm = Location;
        }
        private void pbxBar_MouseMove(object sender, MouseEventArgs e) // Detects when the mouse is down and moving
        {
            if (drag)
            {
                Point difference = Point.Subtract(Cursor.Position, new Size(dragCursor));
                Location = Point.Add(dragForm, new Size(difference));
            }
        }
        private void pbxBar_MouseUp(object sender, MouseEventArgs e) // Detects when the mouse is not dragging the form
        {
            drag = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FormShopfront_Load(object sender, EventArgs e) // Displays all events and deliveries/collections for the current month and issues/updates all notices automatically
        {
            refreshCurrentMonth();
            refreshStockNotices();
            refreshOrderNotices();
            refreshEventNotices();
            checkDismissedNotices();

        }

        // Issuing and updating all notices
        public static void refreshOrderNotices() // Issues and updates all order notices
        {
            generateCustOrderNotices();
            generateSupplyDeliveryNotices();
        }
        public static void refreshEventNotices() // Issues and updates all event notices
        {
            processEventPayments();
            processEventSpaces();
        }
        public static void refreshStockNotices() // Issues and updates all stock notices
        {
            List<int> noStockProductIDs = new List<int>();
            List<int> lowStockProductIDs = new List<int>();
            List<int> lowStockSellingFastProductIDs = new List<int>();
            List<int> productsSellingFast = new List<int>();
            List<int> productsSalesLow = new List<int>();
            bool updateNotice = false;

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            OleDbDataReader reader;

            // Retrieve all products that have low stock but are NOT out of stock
            connection.Open();
            cmd.CommandText = "SELECT ProductID FROM TableProducts WHERE Stock <= LowStock AND Stock <> 0 AND Discontinued = False";
            cmd.Parameters.Clear();
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lowStockProductIDs.Add(Convert.ToInt32(reader[0])); // Add the product ID to the list for products on low stock
            }
            connection.Close();

            connection.Open();
            // Retrieve all products that have no stock.
            cmd.CommandText = "SELECT ProductID FROM TableProducts WHERE Stock = 0 AND Discontinued = False";
            cmd.Parameters.Clear();
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                noStockProductIDs.Add(Convert.ToInt32(reader[0])); // Add the product ID to the list for products on no stock.
            }
            connection.Close();

            // Retrieve all products that are considered to be selling fast.
            connection.Open();
            cmd.CommandText = "SELECT TableProducts.ProductID, SUM(TableCustOrderItems.Quantity - TableCustOrderItems.QuantityVoided - TableCustOrderItems.QuantityReturned) FROM (TableProducts INNER JOIN TableCustOrderItems ON TableCustOrderItems.ProductID = TableProducts.ProductID) INNER JOIN TableCustOrders ON TableCustOrderItems.OrderID = TableCustOrders.CustOrderID WHERE TableCustOrders.DeliveryDate >= DateAdd('d', -7, Date()) AND TableProducts.Discontinued = False GROUP BY TableProducts.ProductID;";
            // Gets the total number of each product sold in the past week
            cmd.Parameters.Clear();
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // Get the original amount of stock of the current product since its last order
                // If more than half of the original amount of stock has been sold in the past week, the product is considered as 'selling fast'
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd1 = con.CreateCommand();
                OleDbDataReader reader1;
                con.Open();
                cmd1.CommandText = "SELECT SUM(TableProducts.Stock+TableSupplierOrderItems.Quantity-TableSupplierOrderItems.QuantityVoided-TableSupplierOrderItems.QuantityReturned) FROM (TableProducts INNER JOIN TableSupplierOrderItems ON TableSupplierOrderItems.ProductID = TableProducts.ProductID) INNER JOIN TableSupplierOrders ON TableSupplierOrderItems.OrderID = TableSupplierOrders.SupplierOrderID WHERE TableSupplierOrders.DeliveryDate > (SELECT MAX(OrderDate) FROM TableSupplierOrders INNER JOIN TableSupplierOrderItems  ON TableSupplierOrders.SupplierOrderID = TableSupplierOrderItems.OrderID WHERE TableSupplierOrderItems.ProductID = TableProducts.ProductID) AND TableProducts.ProductID = @pid AND TableProducts.Discontinued = False GROUP BY TableProducts.ProductID;";
                // Gets the original amount of stock of the current product since its last order
                cmd1.Parameters.Clear();
                cmd1.Parameters.AddWithValue("@pid", Convert.ToInt32(reader[0]));
                cmd1.Connection = con;
                reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    double soldPastWeek = Convert.ToDouble(reader[1]); // Amount sold in the past week
                    double ogStock = Convert.ToDouble(reader1[0]); // Original amount of stock of that product since its last order
                    if (soldPastWeek > 0.5 * ogStock)
                    {
                        productsSellingFast.Add(Convert.ToInt32(reader[0])); // Add the product ID to the list for products selling fast
                    }
                }
            }
            connection.Close();

            // Retrieve all products that are considered to have a low number of sales.
            connection.Open();
            cmd.CommandText = "SELECT TableProducts.ProductID, TableProducts.FullStock, SUM(TableCustOrderItems.Quantity - TableCustOrderItems.QuantityVoided - TableCustOrderItems.QuantityReturned) FROM (TableProducts INNER JOIN TableCustOrderItems ON TableCustOrderItems.ProductID = TableProducts.ProductID) INNER JOIN TableCustOrders ON TableCustOrderItems.OrderID = TableCustOrders.CustOrderID WHERE TableCustOrders.DeliveryDate >= DateAdd('m', -1, Date()) GROUP BY TableProducts.ProductID, TableProducts.FullStock;";
            // Gets the total number of each product sold in the past month
            cmd.Parameters.Clear();
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // If the amount sold for each product is less than 20% of the stock level considered to be full stock, the product is considered as having 'low sales'
                int soldPastMonth = Convert.ToInt32(reader[2]); // Amount sold in the past month.
                int fullStock = Convert.ToInt32(reader[1]); // Full stock level
                if (soldPastMonth < 0.20 * fullStock)
                {
                    productsSalesLow.Add(Convert.ToInt32(reader[0])); // Add the product ID to the list for products with low sales
                }
                else
                {
                    archiveStockNotices("Low Sales", Convert.ToInt32(reader[0])); // Archives any existing notices for low sales
                }
            }
            connection.Close();

            // Retrieve all products in supplier orders that have yet to be delivered.
            // All products that are yet to have arrived but have had an order placed are removed from all of the lists, so duplicate notices are not generated. Instead, the notice will be dismissed until the product's delivery date
            connection.Open();
            cmd.CommandText = "SELECT DISTINCT TableProducts.ProductID,TableSupplierOrders.DeliveryDate FROM (TableProducts INNER JOIN TableSupplierOrderItems ON TableProducts.ProductID = TableSupplierOrderItems.ProductID) INNER JOIN TableSupplierOrders ON TableSupplierOrderItems.OrderID = TableSupplierOrders.SupplierOrderID WHERE TableSupplierOrderItems.QuantityVoided = 0 AND TableSupplierOrderItems.QuantityReturned = 0 AND (TableSupplierOrders.DeliveryStatus = 'Order Made' OR TableSupplierOrders.DeliveryStatus = 'Out For Delivery')";
            cmd.Parameters.Clear();
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                updateNotice = false;
                if (noStockProductIDs.Contains(Convert.ToInt32(reader[0])))
                {
                    noStockProductIDs.Remove(Convert.ToInt32(reader[0]));
                    updateNotice = true;
                }
                else if (lowStockProductIDs.Contains(Convert.ToInt32(reader[0])))
                {
                    lowStockProductIDs.Remove(Convert.ToInt32(reader[0]));
                    updateNotice = true;
                }
                else if (productsSellingFast.Contains(Convert.ToInt32(reader[0])))
                {
                    productsSellingFast.Remove(Convert.ToInt32(reader[0]));
                    updateNotice = true;
                }
                if (updateNotice) // Dismisses notices for products that are yet to be delivered until the order's delivery date.
                {
                    OleDbConnection con = new OleDbConnection();
                    con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd1 = con.CreateCommand();
                    con.Open();
                    cmd1.CommandText = "UPDATE TableStockNotices SET Title = Title + ': Order Placed', DateToReview = @del, Dismissed = True WHERE ProductID = @pid AND Archived = False AND Title <> 'Low Sales'";
                    cmd1.Parameters.Clear();
                    cmd1.Parameters.AddWithValue("@del", DateTime.Parse(Convert.ToDateTime(reader[1]).ToShortDateString()));
                    cmd1.Parameters.AddWithValue("@pid", Convert.ToInt32(reader[0]));
                    cmd1.Connection = con;
                    int status = cmd1.ExecuteNonQuery();
                    con.Close();
                }
            }
            connection.Close();

            // Retrieve all active notices for low stock.
            // If an active notice is found for the product out of stock and it's a low stock notice, this notice needs to be archived
            // If an active notice is found for the product on low stock and it's found to be selling fast, archive the current low stock notice and create a new notice for low stock and selling fast
            // Otherwise, if an active notice is found for the product low on stock, a new notice doesn't need to be created
            connection.Open();
            cmd.CommandText = "SELECT ProductID FROM TableStockNotices WHERE Archived = False AND Title = 'Low Stock' OR Title = 'Low Stock & Selling Fast'";
            cmd.Parameters.Clear();
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (noStockProductIDs.Contains(Convert.ToInt32(reader[0])) || productsSellingFast.Contains(Convert.ToInt32(reader[0])))
                {
                    archiveStockNotices("Low Stock", Convert.ToInt32(reader[0]));
                }
                if (productsSellingFast.Contains(Convert.ToInt32(reader[0])))
                {
                    lowStockSellingFastProductIDs.Add(Convert.ToInt32(reader[0]));
                    productsSellingFast.Remove(Convert.ToInt32(reader[0]));
                }
                if (lowStockProductIDs.Contains(Convert.ToInt32(reader[0])))
                {
                    lowStockProductIDs.Remove(Convert.ToInt32(reader[0]));
                }
            }
            connection.Close();

            // Retrieve all active out of stock notices.
            // Remove products from the list of product IDs if there are active notices found.
            connection.Open();
            cmd.CommandText = "SELECT ProductID FROM TableStockNotices WHERE Archived = False AND Dismissed = False AND Title = 'No Stock'";
            cmd.Parameters.Clear();
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int productID = Convert.ToInt32(reader[0]);
                if (noStockProductIDs.Contains(productID)) // if an active notice is found for the product, a new notice doesn't need to be created
                {
                    noStockProductIDs.Remove(productID);
                }
                else // if an active notice is found for a product that is no longer out of stock, the notice needs to be archived
                {
                    archiveStockNotices("No Stock", productID);
                }
            }
            connection.Close();

            // Retrieve all active selling fast notices.
            // Remove products from the list of product IDs if there are active notices found.
            connection.Open();
            cmd.CommandText = "SELECT ProductID FROM TableStockNotices WHERE Archived = False AND Dismissed = False AND Title = 'Selling Fast'";
            cmd.Parameters.Clear();
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (productsSellingFast.Contains(Convert.ToInt32(reader[0]))) // if an active notice is found for the product, a new notice doesn't need to be created
                {
                    productsSellingFast.Remove(Convert.ToInt32(reader[0]));
                }
                else
                {
                    archiveStockNotices("Selling Fast", Convert.ToInt32(reader[0]));

                }
            }
            connection.Close();

            // Retrieve all active low sales notices.
            // Remove products from the list of product IDs if there are active notices found.
            connection.Open();
            cmd.CommandText = "SELECT ProductID FROM TableStockNotices WHERE Archived = False AND Dismissed = False AND Title = 'Low Sales'"; // Retrieve all active low sales notices.
            cmd.Parameters.Clear();
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (productsSalesLow.Contains(Convert.ToInt32(reader[0]))) // if an active notice is found for the product, a new notice doesn't need to be created
                {
                    productsSalesLow.Remove(Convert.ToInt32(reader[0]));
                }
                else
                {
                    archiveStockNotices("Low Sales", Convert.ToInt32(reader[0])); // If products with low sales have active notices and the list of products doesn't contain that product any longer, the notice can be archived
                }
            }
            connection.Close();

            foreach (int id in lowStockProductIDs) // Finds all products that are low on stock and selling fast
            {
                if (productsSellingFast.Contains(id))
                {
                    productsSellingFast.Remove(id);
                    lowStockSellingFastProductIDs.Add(id);
                }
            }
            foreach (int id in lowStockSellingFastProductIDs) // Removes all product ids of products that are low on stock and selling fast from the low stock list
            {
                if (lowStockProductIDs.Contains(id))
                {
                    lowStockProductIDs.Remove(id);
                }
            }
            createStockNotices("Low Stock & Selling Fast", 2, lowStockSellingFastProductIDs);
            createStockNotices("Low Stock", 1, lowStockProductIDs);
            createStockNotices("No Stock", 3, noStockProductIDs);
            createStockNotices("Selling Fast", 3, productsSellingFast);
            createStockNotices("Low Sales", 1, productsSalesLow);

        }
        private static void processEventSpaces() // Issues and updates all 'event spaces available' notices
        {
            using(OleDbConnection con = new OleDbConnection(connectionString))
            {
                con.Open();

                // Get all future events that haven't been cancelled
                OleDbCommand eventCmd = new OleDbCommand("SELECT * FROM TableEvents WHERE Cancelled <> True AND EventDate >= @tod", con);
                eventCmd.Parameters.AddWithValue("@tod", DateTime.Parse(DateTime.Today.ToShortDateString()));
                OleDbDataReader eventReader = eventCmd.ExecuteReader();

                // Get all active notices related to event spaces
                OleDbCommand noticeCmd = new OleDbCommand("SELECT * FROM TableEventNotices WHERE Title = 'Event Spaces Available' AND Archived <> True AND Dismissed <> True", con);

                // Store all notices in a dictionary, boolean set to true if active
                Dictionary<int, bool> activeNotices = new Dictionary<int, bool>();
                using (OleDbDataReader noticeReader = noticeCmd.ExecuteReader())
                {
                    while (noticeReader.Read())
                    {
                        int eventID = Convert.ToInt32(noticeReader[1]);
                        activeNotices[eventID] = true;
                    }
                }
                
                // Lists to bulk update and insert notices later
                List<int> noticesToArchive = new List<int>();
                List<int> noticesToInsert = new List<int>();

                while (eventReader.Read())
                {
                    Event e = new Event(Convert.ToInt32(eventReader[0]), Convert.ToString(eventReader[1]), Convert.ToDateTime(eventReader[2]), Convert.ToDateTime(eventReader[3]), Convert.ToDateTime(eventReader[4]), Convert.ToString(eventReader[5]), Convert.ToSingle(eventReader[6]), Convert.ToInt32(eventReader[7]), Convert.ToInt32(eventReader[8]), Convert.ToString(eventReader[9]), Convert.ToString(eventReader[10]), Convert.ToBoolean(eventReader[11]));
                    int eventID = e.id;
                    int numattendees = e.numAttendees;
                    int capacity = e.capacity;

                    bool hasWaitingList = e.GetWaitingListAttendees.Count > 0;

                    // Archive all notices for cancelled events
                    if (e.cancelled)
                    {
                        noticesToArchive.Add(eventID);
                        continue;
                    }

                    // Archive all notices for events where there is no longer a waiting list
                    // Create new notices for events that have a waiting list but there is no active notice
                    if(numattendees < capacity)
                    {
                        if (!hasWaitingList && activeNotices.ContainsKey(eventID))
                        {
                            noticesToArchive.Add(eventID);
                        }
                        else if (hasWaitingList && !activeNotices.ContainsKey(eventID))
                        {
                            noticesToInsert.Add(eventID);
                        }
                    }
                    else
                    {
                        // If the event is at capacity, archive any active notices
                        if (activeNotices.ContainsKey(eventID))
                        {
                            noticesToArchive.Add(eventID);
                        }
                    }
                }

                // Bulk archive notices
                if (noticesToArchive.Count > 0)
                {
                    OleDbCommand archiveCmd = new OleDbCommand("UPDATE TableEventNotices SET Archived = True WHERE Title = 'Event Spaces Available' AND EventID IN (" + string.Join(",", noticesToArchive) + ")", con);
                    // Uses IN to archive all event payment notices in one command
                    archiveCmd.ExecuteNonQuery();
                }

                // Bulk insert notices
                if (noticesToInsert.Count > 0)
                {
                    foreach (int id in noticesToInsert)
                    {
                        OleDbCommand insertCmd = new OleDbCommand("INSERT INTO TableEventNotices(EventID,Title,Priority,DateIssued,DateToReview,Dismissed,Archived) VALUES(@eid, 'Event Spaces Available',2,@tod,@tod,false,false)", con);
                        insertCmd.Parameters.AddWithValue("@eid", id);
                        insertCmd.Parameters.AddWithValue("@tod", DateTime.Today);
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
           
            
        }
        private static void processEventPayments() // Issues and updates all 'Event Payments' notices
        {
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                con.Open();

                // Get all events that aren't cancelled

                OleDbCommand eventCmd = new OleDbCommand("SELECT * FROM TableEvents WHERE Cancelled <> True", con); 
                OleDbDataReader eventReader = eventCmd.ExecuteReader(); // Create new reader and execute reader

                // Get all active notices related to events

                OleDbCommand noticeCmd = new OleDbCommand("SELECT * FROM TableEventNotices WHERE Title = 'Event Payments' AND Archived <> True", con);

                // Store all notices in a dictionary, boolean set to true if active
                Dictionary<int, bool> activeNotices = new Dictionary<int, bool>();
                using (OleDbDataReader noticeReader = noticeCmd.ExecuteReader())
                {
                    while (noticeReader.Read())
                    {
                        int eventID = Convert.ToInt32(noticeReader[1]);
                        activeNotices[eventID] = true;
                    }
                }

                // Lists to bulk update and insert notices later
                List<int> noticesToArchive = new List<int>();
                List<int> noticesToInsert = new List<int>();

                while (eventReader.Read())
                {
                    Event e = new Event(Convert.ToInt32(eventReader[0]), Convert.ToString(eventReader[1]), Convert.ToDateTime(eventReader[2]), Convert.ToDateTime(eventReader[3]), Convert.ToDateTime(eventReader[4]), Convert.ToString(eventReader[5]), Convert.ToSingle(eventReader[6]), Convert.ToInt32(eventReader[7]), Convert.ToInt32(eventReader[8]), Convert.ToString(eventReader[9]), Convert.ToString(eventReader[10]), Convert.ToBoolean(eventReader[11]));
                    int eventID = e.id;

                    // Get number of unpaid customers

                    int numUnpaid = e.GetCustomersUnpaid.Count;
                    if(numUnpaid == 0 && activeNotices.ContainsKey(eventID)) // If all customers in the event have paid and the dictionary of active notices contains the event ID, the notice needs to be archived
                    {
                        noticesToArchive.Add(eventID);
                    }
                    else if(numUnpaid>0 && !activeNotices.ContainsKey(eventID))
                    {
                        noticesToInsert.Add(eventID);
                    }

                }

                // Bulk archive notices
                if(noticesToArchive.Count > 0)
                {
                    OleDbCommand archiveCmd = new OleDbCommand("UPDATE TableEventNotices SET Archived = True WHERE Title = 'Event Payments' AND EventID IN ("+string.Join(",", noticesToArchive) + ")",con);
                    // Uses IN to archive all event payment notices in one command
                    archiveCmd.ExecuteNonQuery();
                }

                // Bulk insert notices
                if(noticesToInsert.Count > 0)
                {
                    foreach(int id in noticesToInsert)
                    {
                        OleDbCommand insertCmd = new OleDbCommand("INSERT INTO TableEventNotices(EventID,Title,Priority,DateIssued,DateToReview,Dismissed,Archived) VALUES(@eid, 'Event Payments',2,@tod,@tod,false,false)", con);
                        insertCmd.Parameters.AddWithValue("@eid", id);
                        insertCmd.Parameters.AddWithValue("@tod", DateTime.Today);
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
            
        }
        private static void checkDismissedNotices() // Reactivates notices that have been dismissed and the review date has passed
        {
            // Checks all dismissed notices and reactives them when the notice's review date has passed.
            List<string> tablesToUpdate = new List<string>();
            tablesToUpdate.Add("TableStockNotices");
            tablesToUpdate.Add("TableCustOrderNotices");
            tablesToUpdate.Add("TableSupplierOrderNotices");
            tablesToUpdate.Add("TableEventNotices");
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                con.Open();

                foreach(string table in tablesToUpdate)
                {
                    OleDbCommand dismissCmd = new OleDbCommand("UPDATE " + table + " SET Dismissed = False WHERE DateToReview <= @tod AND Archived = False AND Dismissed = True",con);
                    dismissCmd.Parameters.AddWithValue("@tod", DateTime.Today);
                    dismissCmd.ExecuteNonQuery();
                }

            }
        }
        private static void createStockNotices(string title, int priority, List<int>products) // Creates a new notice for each of the products passed in
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            foreach (int id in products)
            {
                connection.Open();
                cmd.CommandText = "INSERT INTO TableStockNotices(ProductID, Title, Priority, DateIssued, DateToReview, Dismissed, Archived) VALUES(@pid,@title,@p,@tod,@tod,false,false)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@pid", id);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@p", priority);
                cmd.Parameters.AddWithValue("@tod", DateTime.Parse(DateTime.Today.ToShortDateString()));
                cmd.Connection = connection;
                int status = cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        private static void archiveStockNotices(string title, int productID) // Archive stock notice
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = "UPDATE TableStockNotices SET Archived = True WHERE ProductID = @pid AND Archived = False AND Title = @title";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@pid", productID);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Connection = con;
            int status1 = cmd.ExecuteNonQuery();
            con.Close();
        }
        private static void generateCustOrderNotices() // Issues and updates all customer order related notices
        {
            
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            OleDbDataReader reader;
            connection.Open();
            cmd.CommandText = "SELECT CustOrderID, DeliveryDate, DeliveryStatus, CollectionDateEnd FROM TableCustOrders"; // Retrieve all customer orders
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@tod", DateTime.Parse(DateTime.Today.ToShortDateString()));
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime deliveryDate = Convert.ToDateTime(reader[1]);
                string deliveryStatus = Convert.ToString(reader[2]);
                int orderID = Convert.ToInt32(reader[0]);
                DateTime collectionDate = Convert.ToDateTime(reader[3]);

                if(deliveryStatus == "Order Made") // If the order hasn't been processed yet
                {
                    if (deliveryDate < DateTime.Today) // If the delivery date has passed
                    {
                        processOverdueOrder(orderID, deliveryDate, "Processing"); // Check for any active notices, and create any notices if required
                    }
                    else
                    {
                        //Dismisses any active order notices for the current order until its delivery date
                        updateActiveOrderNotices(orderID, deliveryDate, "Processing");
                    }
                }
                else if(deliveryStatus == "Ready To Collect") // If the order hasn't been collected yet
                {
                    if (collectionDate < DateTime.Today) // If the collection window end date has passed
                    {
                        processOverdueOrder(orderID, collectionDate, "Collection"); // Check for any active notices, and create any notices if required
                    }
                    else
                    {
                        // Dismisses any active order notices for the current order until its collection date
                        updateActiveOrderNotices(orderID, collectionDate, "Collection");
                    }
                }
                else // If the delivery status is voided, returned, or collected, then any notices for the order must be archived
                {
                    archiveOrderNotices(orderID, true);
                }
                

            }
            connection.Close();
        }
        private static void generateSupplyDeliveryNotices() // Issues and updates all supply delivery related notices
        {
            // Issues and updates all supplier order related notices.
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            OleDbDataReader reader;
            connection.Open();
            cmd.CommandText = "SELECT SupplierOrderID, DeliveryDate, DeliveryStatus FROM TableSupplierOrders"; // Retrieve all orders where the collection date has passed.
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@tod", DateTime.Parse(DateTime.Today.ToShortDateString()));
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int orderID = Convert.ToInt32(reader[0]);
                DateTime deliveryDate = Convert.ToDateTime(reader[1]);
                string deliveryStatus = Convert.ToString(reader[2]);
                if(deliveryStatus == "Order Made"|| deliveryStatus == "Out For Delivery") // If the order hasn't been delivered yet
                {
                    if (deliveryDate < DateTime.Today) // If the delivery has passed
                    {
                        processOverdueOrder(orderID, deliveryDate, "Supply"); // Check for any active notices, and create any notices if required
                    }
                    else
                    {
                        // Dismisses any active order notices for the current order until its delivery date
                        updateActiveOrderNotices(orderID, deliveryDate, "Supply");
                    }
                }
                else // If the delivery status is voided, returned, or delivered, then any notices for the order must be archived
                {
                    archiveOrderNotices(orderID, false);
                }


            }
            connection.Close();
        }
        private static void archiveOrderNotices(int orderID, bool customerOrder) // Archive order notice
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            if (customerOrder)
            {
                cmd.CommandText = "UPDATE TableCustOrderNotices SET Archived = True WHERE OrderID = @oid AND Archived <> True";
            }
            else
            {
                cmd.CommandText = "UPDATE TableSupplierOrderNotices SET Archived = True WHERE OrderID = @oid AND Archived <> True";
            }
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@oid", orderID);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private static void processOverdueOrder(int orderID, DateTime date, string type) // Creates the title based on the type of notice, assigns a priority
        {

            // Creates the title based on the type of notice
            string title = "";
            switch (type)
            {
                case "Collection":
                    title = "Order Collection Overdue: ";
                    break;
                case "Processing":
                    title = "Order Processing Overdue: ";
                    break;
                case "Supply":
                    title = "Supply Delivery Overdue: ";
                    break;
            }
            // Assigns a priority and sets the title
            if (date < DateTime.Today.AddDays(-5))
            {
                processOrderNotice(orderID, title + ">5 days", 3);
            }
            else if (date < DateTime.Today.AddDays(-3))
            {
                processOrderNotice(orderID, title + "3 days", 2);
            }
            else if (date < DateTime.Today.AddDays(-1))
            {
                processOrderNotice(orderID, title + "1 day", 1);
            }
        }
        private static void processOrderNotice(int orderID, string title, int priority)
        {
            // If there are existing notices for all the other overdue periods other than the overdue period of the notice to be processed, all those notices should be archived.
            // If there is not an existing notice for the overdue period of the notice to be processed, then a new notice should be created.
            if (!existingOrderNotice(orderID, title, false)) // If there is an existing notice for the current overdue period
            {
                createOrderNotice(orderID, title, priority); // Create new notice if there is no existing notice for that overdue period
            }
            if (existingOrderNotice(orderID, title, true)) // If there are existing notices for other overdue periods
            {
                archiveOtherNotices(orderID, title); // Archive all other notices relating to a different overdue period
            }
        }
        private static void archiveOtherNotices(int orderID, string title) // Archives all notices that are of the same type but are referencing the wrong overdue period.

        {
            // This is used so that only one notice of one type is active.
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            if (title.Contains("Collection"))
            {
                cmd.CommandText = "UPDATE TableCustOrderNotices SET Archived = True WHERE OrderID = @oid AND Title <> @title AND Title LIKE '%Collection%' AND Archived <> True";
            }
            if (title.Contains("Processing"))
            {
                cmd.CommandText = "UPDATE TableCustOrderNotices SET Archived = True WHERE OrderID = @oid AND Title <> @title AND Title LIKE '%Processing%' AND Archived <> True";
            }
            if (title.Contains("Supply"))
            {
                cmd.CommandText = "UPDATE TableSupplierOrderNotices SET Archived = True WHERE OrderID = @oid AND Title <> @title AND Title LIKE '%Supply%' AND Archived <> True";
            }
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@oid", orderID);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private static bool existingOrderNotice(int orderID, string title, bool other) // Checks if an order notice exists 
        {
            if (other) // If looking for other overdue notices
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = con.CreateCommand();
                OleDbDataReader reader;
                con.Open();
                if (title.Contains("Collection"))
                {
                    cmd.CommandText = "SELECT OrderID FROM TableCustOrderNotices WHERE OrderID = @oid AND Title <> @title AND Title LIKE '%Collection%' AND Archived <> True";
                }
                if (title.Contains("Processing"))
                {
                    cmd.CommandText = "SELECT OrderID FROM TableCustOrderNotices WHERE OrderID = @oid AND Title <> @title AND Title LIKE '%Processing%' AND Archived <> True";
                }
                if (title.Contains("Supply"))
                {
                    cmd.CommandText = "SELECT OrderID FROM TableSupplierOrderNotices WHERE OrderID = @oid AND Title <> @title AND Title LIKE '%Supply%' AND Archived <> True";
                }
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@oid", orderID);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Connection = con;
                reader = cmd.ExecuteReader();
                bool noticeExists = reader.Read();
                con.Close();
                return noticeExists;
            }
            else // Finding if the notice passed in exists itself
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = con.CreateCommand();
                OleDbDataReader reader;
                con.Open();
                cmd.CommandText = "SELECT OrderID FROM TableCustOrderNotices WHERE OrderID = @oid AND Title = @title AND Archived <> True";
                if (title.Contains("Collection")|| title.Contains("Processing"))
                {
                    cmd.CommandText = "SELECT OrderID FROM TableCustOrderNotices WHERE OrderID = @oid AND Title = @title AND Archived <> True";
                }
                if (title.Contains("Supply"))
                {
                    cmd.CommandText = "SELECT OrderID FROM TableSupplierOrderNotices WHERE OrderID = @oid AND Title = @title AND Archived <> True";
                }
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@oid", orderID);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Connection = con;
                reader = cmd.ExecuteReader();
                bool noticeExists = reader.Read();
                con.Close();
                return noticeExists;
            }
        }
        private static void createOrderNotice(int orderID, string title, int priority) // Creates a new order notice
        {
            // Creates a new notice with the parameters passed in
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = con.CreateCommand();
            con.Open(); 
            if (title.Contains("Collection") || title.Contains("Processing"))
            {
                cmd.CommandText = "INSERT INTO TableCustOrderNotices(OrderID, Title, Priority, DateIssued, DateToReview, Dismissed, Archived) VALUES(@oid, @title, @priority, @tod, @tod, false, false)";
            }
            if (title.Contains("Supply"))
            {
                cmd.CommandText = "INSERT INTO TableSupplierOrderNotices(OrderID, Title, Priority, DateIssued, DateToReview, Dismissed, Archived) VALUES(@oid, @title, @priority, @tod, @tod, false, false)";
            }
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@oid", orderID);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@priority", priority);
            cmd.Parameters.AddWithValue("@tod", DateTime.Today);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private static void updateActiveOrderNotices(int orderID, DateTime date, string title)// Updates all active order notices where the collection/delivery date has been changed. Dismisses the notice until that date.
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = con.CreateCommand();
            con.Open(); 
            if (title.Contains("Collection") || title.Contains("Processing"))
            {
                cmd.CommandText = "UPDATE TableCustOrderNotices SET DateToReview = @del, Dismissed = True WHERE OrderID = @oid AND Dismissed <> True AND Archived <> True";
            }
            if (title.Contains("Supply"))
            {
                cmd.CommandText = "UPDATE TableSupplierOrderNotices SET DateToReview = @del, Dismissed = True WHERE OrderID = @oid AND Dismissed <> True AND Archived <> True";
            }
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@del", DateTime.Parse(date.ToShortDateString()));
            cmd.Parameters.AddWithValue("@oid", orderID);
            cmd.Connection = con;
            int status = cmd.ExecuteNonQuery();
            con.Close();
        }

        // Displaying the calendar
        public List<Event> loadEventsMonthList(int monthNum, int year) // Loads all events for the month
        {
            //loads all events for the month displayed
            List<Event> eventsMonthList = new List<Event>();
            //load all yarn weights into a list
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            OleDbDataReader reader;

            connection.Open();
            cmd.CommandText = "SELECT * FROM TableEvents WHERE Month(EventDate) = @mo AND Year(EventDate) = @ye AND Cancelled = False";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@mo", monthNum);
            cmd.Parameters.AddWithValue("@ye", year);
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                bool cancelled = false;
                if (Convert.ToInt32(reader[11]) == -1 || Convert.ToBoolean(reader[11]))
                {
                    cancelled = true;
                }
                if ((reader[0] != null) || (Convert.ToString(reader[0]) != ""))
                {
                    eventsMonthList.Add(new Event(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToDateTime(reader[2]), Convert.ToDateTime(reader[3]), Convert.ToDateTime(reader[4]), Convert.ToString(reader[5]), Convert.ToSingle(reader[6]), Convert.ToInt32(reader[7]), Convert.ToInt32(reader[8]), Convert.ToString(reader[9]), Convert.ToString(reader[10]), cancelled));
                }
                else
                {
                    continue;
                }
            }
            connection.Close();
            return eventsMonthList;
        }
        public List<Event> loadEventsDayList(int dayNum, List<Event>eventsOfMonth) // Loads all events for the day
        {
            List<Event> eventsOfDay = new List<Event>();
            foreach (Event e in eventsOfMonth)
            {
                if (dayNum == e.date.Day)
                {
                    eventsOfDay.Add(e);
                }
            }
            return eventsOfDay;
        }
        private void refreshCurrentMonth() // Loads all events for the current month
        {
            month = DateTime.Now.Month;
            year = DateTime.Now.Year;
            refreshCalendar();
        }
        private void refreshCalendar()
        {
            flpMonday.Controls.Clear();
            flpTuesday.Controls.Clear();
            flpWednesday.Controls.Clear();
            flpThursday.Controls.Clear();
            flpFriday.Controls.Clear();
            flpSaturday.Controls.Clear();
            flpSunday.Controls.Clear();

            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lblDate.Text = monthName + " " + year;

            // first day of month
            DateTime startOfMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month); // number of days in the month
            int daysOfWeek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d")); // gets the start day of the month
            if(daysOfWeek == 0)
            {
                daysOfWeek = 7;
            }
            for (int i = 1; i < daysOfWeek; i++) // Loops through each day of the week and adds the event/notice to the correct day
            {
                string dayName = Enum.GetName(typeof(DayOfWeek), i);
                UserControlBlank ucblank = new UserControlBlank();
                switch (dayName)
                {
                    case "Monday":
                        flpMonday.Controls.Add(ucblank);
                        break;
                    case "Tuesday":
                        flpTuesday.Controls.Add(ucblank);
                        break;
                    case "Wednesday":
                        flpWednesday.Controls.Add(ucblank);
                        break;
                    case "Thursday":
                        flpThursday.Controls.Add(ucblank);
                        break;
                    case "Friday":
                        flpFriday.Controls.Add(ucblank);
                        break;
                    case "Saturday":
                        flpSaturday.Controls.Add(ucblank);
                        break;
                    case "Sunday":
                        flpSunday.Controls.Add(ucblank);
                        break;
                }
            }
            for (int i = 1; i <= daysInMonth; i++)
            {
                string dateString = startOfMonth.ToString("MM/yyyy");
                if (i < 10)
                {
                    dateString = "0" + i.ToString() + "/" + dateString;
                } //gets date in dd/MM/yyyy format
                else
                {
                    dateString = i.ToString() + "/" + dateString;
                }
                DateTime date = Convert.ToDateTime(dateString);
                //displays each of the dates
                CalendarDay ucdays = new CalendarDay(true);
                ucdays.days(i, month, year);
                ucdays.displayEvents(loadEventsDayList(i, loadEventsMonthList(month, year)));
                ucdays.displayNumDueDeliveries(i, month, year);
                ucdays.displayNumCollections(i, month, year);
                switch (date.ToString("dddd"))
                {
                    case "Monday":
                        flpMonday.Controls.Add(ucdays);
                        break;
                    case "Tuesday":
                        flpTuesday.Controls.Add(ucdays);
                        break;
                    case "Wednesday":
                        flpWednesday.Controls.Add(ucdays);
                        break;
                    case "Thursday":
                        flpThursday.Controls.Add(ucdays);
                        break;
                    case "Friday":
                        flpFriday.Controls.Add(ucdays);
                        break;
                    case "Saturday":
                        flpSaturday.Controls.Add(ucdays);
                        break;
                    case "Sunday":
                        flpSunday.Controls.Add(ucdays);
                        break;
                }
            }
        }
        private void pbxNextMonth_Click(object sender, EventArgs e) // View the next month
        {
            if (month == 12)
            {
                month = 1;
                year++;
            }
            else
            {
                month++;
            }
            refreshCalendar();
        }
        private void pbxPrevMonth_Click(object sender, EventArgs e) // View the previous m onth
        {
            if (month == 1)
            {
                month = 12;
                year--;
            }
            else
            {
                month--;
            }
            refreshCalendar();
        }
        private void btnToday_Click(object sender, EventArgs e) // View this month
        {
            refreshCurrentMonth();
        }

        // Accessing forms
        private void btnOrders_Click(object sender, EventArgs e)
        {
            Orders newFormOrders = new Orders(null,null);
            newFormOrders.ShowDialog();

            // Issue and update all order notices and stock notices
            refreshOrderNotices();
            refreshStockNotices();
        }
        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            Suppliers newFormSuppliers = new Suppliers();
            newFormSuppliers.ShowDialog();
            refreshStockNotices();
        }
        private void btnCustomers_Click(object sender, EventArgs e)
        {
            Customers newFormCustomers = new Customers();
            newFormCustomers.ShowDialog();
            refreshEventNotices();
        }
        private void btnProducts_Click(object sender, EventArgs e)
        {
            Products newFormProducts = new Products(null);
            newFormProducts.ShowDialog();

            // Issue and update all stock notices
            refreshStockNotices();
        }
        private void btnNotices_Click(object sender, EventArgs e)
        {
            Notices newFormNotices = new Notices();
            newFormNotices.ShowDialog();
        }
        private void btnEvents_Click(object sender, EventArgs e)
        {
            Events newFormEvents = new Events(null);
            newFormEvents.ShowDialog();

            // Issue and update all event notices
            refreshEventNotices();
        }
        
    }
}
