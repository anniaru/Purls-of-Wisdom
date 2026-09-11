using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Deployment.Internal;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace YarnShop
{
    public class Order
    {

        // Attributes
        private int OrderID { get; set; }
        private int ID { get; set; }
        private DateTime OrderDate { get; set; }
        private DateTime DeliveryDate { get; set; }
        private string DeliveryStatus { get; set; }
        private double Subtotal { get; set; }
        private double Total { get; set; }
        private string OrderNotes { get; set; }

        public Order(int orderID, int id, DateTime orderDate, DateTime deliveryDate, string deliveryStatus, double subtotal, double total, string orderNotes) // Constructor
        {
            this.OrderID = orderID;
            this.ID = id;
            this.OrderDate = orderDate;
            this.DeliveryDate = deliveryDate;
            this.DeliveryStatus = deliveryStatus;
            this.Subtotal = Math.Round(subtotal, 2);
            this.Total = Math.Round(total,2);
            this.OrderNotes = orderNotes;
        }

        // Getters
        public int orderID
        {
            get { return OrderID; }
        }
        public int id
        {
            get { return ID; }
        }
        public DateTime orderDate
        {
            get { return OrderDate; }
        }
        public DateTime deliveryDate
        {
            get { return DeliveryDate; }
        }
        public string deliveryStatus
        {
            get { return DeliveryStatus; }
        }
        public double subtotal
        {
            get { return Subtotal; }
        }
        public double total
        {
            get { return Total; }
        }
        public string orderNotes
        {
            get { return OrderNotes; }
        }
        public string status
        {
            get
            {
                if (deliveryStatus == "Order Made" || deliveryStatus == "Ready To Collect")
                {
                    return "Open";
                }
                else
                {
                    return "Archived";
                }
            }
        }
        public Supplier GetSupplierDetails() // Gets the supplier details if this order is a supplier order
        {
            bool error = false;
            Supplier supplier = null;
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = con.CreateCommand();
            OleDbDataReader reader;
            con.Open();
            cmd.CommandText = "SELECT * FROM TableSuppliers WHERE SupplierID = @sid";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@sid", id);
            cmd.Connection = con;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    supplier = new Supplier(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToString(reader[3]), Convert.ToString(reader[4]), Convert.ToString(reader[5]), Convert.ToString(reader[6]));
                }
                catch
                {
                    if (!error)
                    {
                        MessageBox.Show("Supplier data is missing.", "Missing Data");
                    }
                }
            }
            return supplier;
        }
        public string subtotalString()
        {
            return "£" + subtotal.ToString("0.00");
        }
        public string totalString()
        {
            return "£" + total.ToString("0.00");
        }
        public virtual List<OrderItem> OrderItemList() // Overridden by OrderItemList() in CustOrder
        {
            // Loads all products of the order into a list of OrderItem objects.
            bool error = false;
            List<OrderItem> orderItemList = new List<OrderItem>();
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            OleDbDataReader reader;
            connection.Open();
            cmd.CommandText = "SELECT DISTINCT TableProducts.ProductID, TableProducts.ProductName, TableProducts.Cost, TableProducts.Stock, TableProducts.FileName, TableProducts.SupplierID, TableProducts.Discontinued, TableProducts.LowStock,TableProducts.FullStock, TableSupplierOrderItems.Quantity, TableSupplierOrderItems.QuantityVoided, TableSupplierOrderItems.QuantityReturned FROM (TableProducts INNER JOIN TableSupplierOrderItems ON TableProducts.ProductID = TableSupplierOrderItems.ProductID) INNER JOIN TableSupplierOrders ON TableSupplierOrderItems.OrderID = TableSupplierOrders.@oid";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@oid", orderID);
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    orderItemList.Add(new OrderItem(new Product(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), (float)Math.Round(Convert.ToDouble(reader[2]), 2), Convert.ToInt32(reader[3]), Convert.ToString(reader[4]), Convert.ToInt32(reader[5]), Convert.ToBoolean(reader[6]), Convert.ToInt32(reader[7]), Convert.ToInt32(reader[8])), Convert.ToInt32(reader[9]), Convert.ToInt32(reader[10]), Convert.ToInt32(reader[11])));
                }
                catch
                {
                    if (!error)
                    {
                        MessageBox.Show("Order item data is missing.", "Missing Data");
                        error = true;
                    }
                }
            }
            connection.Close();
            return orderItemList;
        }

    }
}
