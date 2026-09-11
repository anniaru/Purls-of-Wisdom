using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarnShop
{
    public class CustOrder : Order
    {
        // Attributes (rest are inherited)
        private DateTime ColDateEnd { get; set; }
        private string PaymentStatus { get; set; }
        private int StarsEarned { get; set; }
        private string Voucher { get; set; }

        public CustOrder(int orderID, int id, DateTime orderDate, DateTime deliveryDate, string deliveryStatus, double subtotal, double total, string orderNotes, DateTime colDateEnd, string paymentStatus, int starsEarned, string voucher) : base(orderID, id, orderDate, deliveryDate, deliveryStatus, subtotal, total, orderNotes) // Constructor
        {
            this.ColDateEnd = colDateEnd;
            this.PaymentStatus = paymentStatus;
            this.StarsEarned = starsEarned;
            this.Voucher = voucher;
        }

        // RETRIEVING DATA
        public DateTime colDateEnd
        {
            get { return ColDateEnd; }
        }
        public string paymentStatus
        {
            get { return PaymentStatus; }
        }
        public int starsEarned
        {
            get { return StarsEarned; }
        }
        public string voucher
        {
            get { return Voucher; }
        }
        public Customer GetCustomerDetails // Loads customer details of the order into a Customer object.
        {
            get
            {
                bool error = false;
                Customer cust = null;
                OleDbConnection conCustomers = new OleDbConnection();
                conCustomers.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmdCustomers = conCustomers.CreateCommand();
                OleDbDataReader readerCustomers;
                conCustomers.Open();
                cmdCustomers.CommandText = "SELECT * FROM TableCustomers WHERE CustID = @cid";
                cmdCustomers.Parameters.Clear();
                cmdCustomers.Parameters.AddWithValue("@cid", id);
                cmdCustomers.Connection = conCustomers;
                readerCustomers = cmdCustomers.ExecuteReader();
                while (readerCustomers.Read())
                {
                    try
                    {
                        cust = new Customer(Convert.ToInt32(readerCustomers[0]), Convert.ToString(readerCustomers[1]), Convert.ToString(readerCustomers[2]), Convert.ToString(readerCustomers[3]), Convert.ToString(readerCustomers[4]), Convert.ToString(readerCustomers[5]), Convert.ToInt32(readerCustomers[6]), Convert.ToInt32(readerCustomers[7]));
                    }
                    catch
                    {
                        if (!error)
                        {
                            MessageBox.Show("Customer data is missing.", "Missing Data");
                            error = true;
                        }
                    }
                }
                conCustomers.Close();
                return cust;

            }
            
        }
        public string CustAbbName // Returns an abbreviated version of the customer's name e.g. John Smith -> J SMITH
        {
            get
            {
                Customer cust = GetCustomerDetails;
                if (cust.lastName.Length <= 5)
                {
                    return Convert.ToString((cust.firstName[0] + " " + cust.lastName).ToUpper());
                }
                else
                {
                    return Convert.ToString((cust.firstName[0]) + " " + cust.lastName.Substring(0, 5).ToUpper());
                }
            }
        }
        public string VoucherString // Voucher information to be printed
        {
            get
            {
                if (voucher == "GOLD")
                {
                    return "(-15% GOLD)";
                }
                else if (voucher == "SILVER")
                {
                    return "(-10% SILV)";
                }
                else if (voucher == "BRONZE")
                {
                    return "(-5% BRON)";
                }
                else
                {
                    return "";
                }

            }
        }

        // CALCULATIONS
        public double ApplyVoucher(double amount)
        {
            if (amount < 0)
            {
                return 0;
            }
            else
            {
                //reapplying the vouchers
                if (voucher == "GOLD")
                {
                    return Math.Round(amount * 0.85, 2);
                }
                if (voucher == "SILVER")
                {
                    return Math.Round(amount * 0.9, 2);
                }
                if (voucher == "BRONZE")
                {
                    return Math.Round(amount * 0.95, 2);
                }
                else
                {
                    return amount;
                }
            }
        }
        public string CustTotalSaved() // Calculates the total amount of money the customer has saved so far as a member.
        {
            double totalSaved = 0;
            bool error = false;

            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = con.CreateCommand();
            OleDbDataReader reader;
            con.Open();
            cmd.CommandText = "SELECT CustOrderID, Subtotal, Total, Voucher FROM TableCustOrders WHERE CustID = @cid";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@cid", id);
            cmd.Connection = con;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                double voidedTotal = 0;
                double returnedTotal = 0;
                try
                {
                    OleDbConnection conItems = new OleDbConnection();
                    conItems.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmdItems = conItems.CreateCommand();
                    OleDbDataReader readerItems;
                    conItems.Open();
                    cmdItems.CommandText = "SELECT DISTINCT TableProducts.Cost, TableCustOrderItems.QuantityVoided,TableCustOrderItems.QuantityReturned FROM (TableProducts INNER JOIN TableCustOrderItems ON TableProducts.ProductID = TableCustOrderItems.ProductID) INNER JOIN TableCustOrders ON TableCustOrderItems.OrderID = TableCustOrders.@oid";
                    cmdItems.Parameters.Clear();
                    cmdItems.Parameters.AddWithValue("@oid", Convert.ToInt32(reader[0]));
                    cmdItems.Connection = conItems;
                    readerItems = cmdItems.ExecuteReader();
                    while (readerItems.Read())
                    {
                        try
                        {
                            double multiplier = 1;
                            if (reader[3].ToString() == "GOLD")
                            {
                                multiplier = 0.85;
                            }
                            if (reader[3].ToString() == "SILVER")
                            {
                                multiplier = 0.9;
                            }
                            if (reader[3].ToString() == "BRONZE")
                            {
                                multiplier = 0.95;
                            }
                            voidedTotal += multiplier * Convert.ToDouble(readerItems[0]) * Convert.ToDouble(readerItems[1]);
                            returnedTotal += multiplier * Convert.ToDouble(readerItems[0]) * Convert.ToDouble(readerItems[2]);
                        }
                        catch
                        {
                            if (!error)
                            {
                                MessageBox.Show("Invoice creation error: customer order data is missing.", "Order Data Error");
                                error = true;
                            }
                        }
                    }
                    conItems.Close();
                    totalSaved += Convert.ToDouble(reader[1]) - voidedTotal - returnedTotal - Convert.ToDouble(reader[2]);
                }
                catch
                {
                    if (!error)
                    {
                        MessageBox.Show("Invoice creation error: customer order data is missing.", "Order Data Error");
                        error = true;
                    }
                }
            }
            //MessageBox.Show(Convert.ToString(totalSaved));
            con.Close();
            return "You have saved £" + Math.Round(totalSaved, 2) + " with us so far!";

        }
        public string NextVoucherCost() // Returns the amount of money the customer of this order needs to spend to earn the next voucher
        {
            // This is run when the customer hasn't used a voucher in their order.
            // It will result in either the amount that needs to be spent to obtain the next voucher, or achieve the next membership status.
            double amount = 0;
            double numOfStars = 0;
            Customer cust = GetCustomerDetails;
            double currentStars = cust.totalStars;
            if (cust.memType == "Bronze")
            {
                if ((currentStars / 150) == 2)
                {
                    numOfStars = 450 - currentStars;
                    amount = Math.Round(numOfStars / 3, 2);
                    return "Spend £" + amount + " total in your next orders to achieve Silver status!";
                }
                else
                {
                    numOfStars = ((Math.Truncate(currentStars / 150) + 1) * 150) - currentStars;
                    amount = Math.Round(numOfStars / 3, 2);
                    return "Spend £" + amount + " total in your next orders to earn a 5% discount voucher!";
                }
            }
            else if (cust.memType == "Silver")
            {
                if ((currentStars / 150) == 5)
                {
                    numOfStars = 900 - currentStars;
                    amount = Math.Round(numOfStars / 3, 2);
                    return "Spend £" + amount + " total in your next orders to achieve Gold status!";
                }
                else
                {
                    numOfStars = ((Math.Truncate(currentStars / 150) + 1) * 150) - currentStars;
                    amount = Math.Round(numOfStars / 3, 2);
                    return "Spend £" + amount + " total in your next orders to earn a 10% discount voucher!";
                }
            }
            else if (cust.memType == "Gold")
            {

                numOfStars = (((Math.Truncate(currentStars / 150)) + 1) * 150) - currentStars;
                amount = Math.Round(numOfStars / 3, 2);
                return "Spend £" + amount + " total in your next orders to earn a 15% discount voucher!";
            }
            return "";
        }
        public double VoidedTotal(List<OrderItem> list) // Returns the total amount that has been voided
        {
            double total = 0;
            foreach (OrderItem item in list)
            {
                total += item.product.cost * item.quantityVoided;
            }
            return Math.Round(total,2);
        }
        public double ReturnedTotal(List<OrderItem> list) // Returns the total amount that has been returned
        {
            double total = 0;
            foreach (OrderItem item in list)
            {
                total += item.product.cost * item.quantityReturned;
            }
            return Math.Round(total,2);
        }
        public override List<OrderItem> OrderItemList() // Returns a list of all order items in this customer order. Overrides the method in the parent class. 
        {
            // Loads all products of the order into a list of CustOrderItem objects.
            bool error = false;
            List<OrderItem> orderItemList = new List<OrderItem>();
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            OleDbDataReader reader;
            connection.Open();
            cmd.CommandText = "SELECT DISTINCT TableProducts.ProductID, TableProducts.ProductName, TableProducts.Cost, TableProducts.Stock, TableProducts.FileName, TableProducts.SupplierID, TableProducts.Discontinued, TableProducts.LowStock,TableProducts.FullStock, TableCustOrderItems.Quantity, TableCustOrderItems.QuantityVoided, TableCustOrderItems.QuantityReturned FROM (TableProducts INNER JOIN TableCustOrderItems ON TableProducts.ProductID = TableCustOrderItems.ProductID) INNER JOIN TableCustOrders ON TableCustOrderItems.OrderID = TableCustOrders.@oid";
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
        public double Savings(List<OrderItem> list)
        {
            return Math.Round(subtotal - VoidedTotal(list)-ReturnedTotal(list) -total, 2);
        }

        // BIG ALGORITHM: Generates invoice to be printed as a pdf or a receipt
        public void GenerateInvoice(PrintPageEventArgs e, bool pdf,List<InvoiceLine>lines)
        {
            Customer cust = GetCustomerDetails;
            List<OrderItem> orderItemList = OrderItemList();
            bool voidedItems = false;
            bool returnedItems = false;

            // fonts
            Font titleFont = new Font("Consolas", 13, FontStyle.Bold);
            Font title2Font = new Font("Consolas", 13, FontStyle.Bold | FontStyle.Italic);
            Font boldFont = new Font("Consolas", 9, FontStyle.Bold);
            Font regularFont = new Font("Consolas", 9, FontStyle.Regular);
            Font italicFont = new Font("Consolas", 9, FontStyle.Italic);

            // brush
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // formats
            StringFormat drawFormatCenter = new StringFormat();
            drawFormatCenter.Alignment = StringAlignment.Center;

            StringFormat drawFormatLeft = new StringFormat();

            StringFormat drawFormatRight = new StringFormat();
            drawFormatRight.Alignment = StringAlignment.Far;

            // pens
            Pen blackDashedPen = new Pen(Color.Black);
            blackDashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            int widthBound = 220;

            if ((cust == null) || (orderItemList == null))
            {
                MessageBox.Show("Invoice creation error: data is missing.", "Invoice Error");
            }
            else
            {
                if (Orders.pageNum == 1) // Initialise the list of lines to be drawn on the receipt.
                {
                    if(lines != null)
                    {
                        lines.Clear();
                    }
                    Orders.startIndex = 0;
                    e.HasMorePages = false;

                    // HEADER INFORMATION
                    lines.Add(new InvoiceLine("PURLS OF WISDOM", titleFont, (widthBound / 2), drawFormatCenter, 30));
                    lines.Add(new InvoiceLine("3 Main Street", regularFont, (widthBound / 2), drawFormatCenter, 20));
                    lines.Add(new InvoiceLine("Birmingham", regularFont, (widthBound / 2), drawFormatCenter, 20));
                    lines.Add(new InvoiceLine("B5 3AL", regularFont, (widthBound / 2), drawFormatCenter, 20));
                    lines.Add(new InvoiceLine("01902 330033", regularFont, (widthBound / 2), drawFormatCenter, 30));

                    lines.Add(new InvoiceLine("----------------------------", regularFont, 10, drawFormatLeft, 20));

                    // ORDER INFORMATION

                    lines.Add(new InvoiceLine("Invoice", boldFont, (widthBound / 2), drawFormatCenter, 30));
                    lines.Add(new InvoiceLine("Order Date:", boldFont, 10, drawFormatLeft, 0));
                    lines.Add(new InvoiceLine(orderDate.ToString("dd/MM/yyyy"), regularFont, widthBound - 10, drawFormatRight, 20));
                    lines.Add(new InvoiceLine("Order No:", boldFont, 10, drawFormatLeft, 0));
                    lines.Add(new InvoiceLine(orderID.ToString(), regularFont, widthBound - 10, drawFormatRight, 20));
                    lines.Add(new InvoiceLine("Date Printed:", boldFont, 10, drawFormatLeft, 0));
                    lines.Add(new InvoiceLine(DateTime.Now.ToString("dd/MM/yyyy"), regularFont, widthBound - 10, drawFormatRight, 20));
                    lines.Add(new InvoiceLine("Time Printed:", boldFont, 10, drawFormatLeft, 0));
                    lines.Add(new InvoiceLine(DateTime.Now.ToString("HH:mm:ss"), regularFont, widthBound - 10, drawFormatRight, 30));

                    lines.Add(new InvoiceLine("----------------------------", regularFont, 10, drawFormatLeft, 20));

                    // ORDER ITEM HEADERS

                    lines.Add(new InvoiceLine("Product", boldFont, 10, drawFormatLeft, 0));
                    lines.Add(new InvoiceLine("Price", boldFont, widthBound - 10, drawFormatRight, 20));

                    lines.Add(new InvoiceLine("----------------------------", regularFont, 10, drawFormatLeft, 20));

                    // PRODUCTS IN THE ORDER
                    for (int i = 0; i < orderItemList.Count; i++) // Loops through each order item in the order
                    {
                        lines.Add(new InvoiceLine(orderItemList[i].product.CostString, regularFont, widthBound - 10, drawFormatRight, 0));
                        lines.Add(new InvoiceLine(orderItemList[i].quantity + "x", regularFont, 10, drawFormatLeft, 0));

                        string currentProductLine = orderItemList[i].product.name;
                        // Wraps text if the product name is too long to fit in one line on the invoice
                        if (currentProductLine.Length > 18)
                        {
                            while (currentProductLine.Length > 18)
                            {
                                int space = currentProductLine.LastIndexOf(' ', 18); // finds the last space before character 70
                                if (space != -1)
                                {
                                    // if at least one space is found
                                    lines.Add(new InvoiceLine(currentProductLine.Substring(0, space), regularFont, 30, drawFormatLeft, 20));
                                    currentProductLine = currentProductLine.Substring(space + 1); // sets the line to the remaining string to be printed
                                }
                                else
                                {
                                    // if no spaces are found
                                    lines.Add(new InvoiceLine(currentProductLine.Substring(0, 18), regularFont, 30, drawFormatLeft, 20));
                                    currentProductLine = currentProductLine.Substring(18);
                                }
                            }
                            lines.Add(new InvoiceLine(currentProductLine, regularFont, 30, drawFormatLeft, 20)); // prints the remaining string
                        }
                        else
                        {
                            lines.Add(new InvoiceLine(currentProductLine, regularFont, 30, drawFormatLeft, 20)); // prints the remaining string
                        }

                        // IF ANY PRODUCTS WERE VOIDED
                        if(deliveryStatus != "Voided")
                        {
                            if (orderItemList[i].quantityVoided != 0)
                            {
                                lines.Add(new InvoiceLine("- £" + Math.Round(orderItemList[i].quantityVoided * orderItemList[i].product.cost,2).ToString("0.00"), italicFont, widthBound - 10, drawFormatRight, 0));
                                lines.Add(new InvoiceLine("- " + orderItemList[i].quantityVoided + "x" + " VOIDED", italicFont, 30, drawFormatLeft, 20));
                                voidedItems = true;
                            }
                        }

                        // IF ANY PRODUCTS WERE RETURNED
                        if(deliveryStatus != "Returned")
                        {
                            if (orderItemList[i].quantityReturned != 0)
                            {
                                lines.Add(new InvoiceLine("- £" + Math.Round(orderItemList[i].quantityReturned * orderItemList[i].product.cost,2).ToString("0.00"), italicFont, widthBound - 10, drawFormatRight, 0));
                                lines.Add(new InvoiceLine("- " + orderItemList[i].quantityReturned + "x" + " RETURNED", italicFont, 30, drawFormatLeft, 20));
                                returnedItems = true;
                            }
                        }
                    }

                    lines.Add(new InvoiceLine("----------------------------", regularFont, 10, drawFormatLeft, 20));

                    // SUBTOTAL, TOTAL, VOIDS AND RETURNS

                    lines.Add(new InvoiceLine("Subtotal:", boldFont, 10, drawFormatLeft, 0));
                    lines.Add(new InvoiceLine("£" + subtotal, regularFont, widthBound - 10, drawFormatRight, 20));


                    if (deliveryStatus == "Voided" || deliveryStatus == "Returned")
                    {
                        if (deliveryStatus == "Voided") //if order is voided
                        {
                            lines.Add(new InvoiceLine("Voided Order", italicFont, 10, drawFormatLeft, 0));
                            lines.Add(new InvoiceLine("- " + subtotalString(), regularFont, widthBound - 10, drawFormatRight, 20));
                        }
                        if (deliveryStatus == "Returned") //if order is returned
                        {
                            lines.Add(new InvoiceLine("Returned Order", italicFont, 10, drawFormatLeft, 0));
                            lines.Add(new InvoiceLine("- " + subtotalString(), regularFont, widthBound - 10, drawFormatRight, 20));
                        }
                    }
                    else
                    {
                        // If the order is not voided or returned and a voucher is used
                        // Display the savings from using a voucher
                        // Display the amount deducted by voided or returned items
                        if (voucher != "N/A")
                        {
                            lines.Add(new InvoiceLine("Savings " + VoucherString, boldFont, 10, drawFormatLeft, 0));
                            lines.Add(new InvoiceLine("- £" + Savings(orderItemList).ToString("0.00"), regularFont, widthBound - 10, drawFormatRight, 20));
                        }
                        if (voidedItems)
                        {
                            lines.Add(new InvoiceLine("Voided Items ", italicFont, 10, drawFormatLeft, 0));
                            lines.Add(new InvoiceLine("- £" + ApplyVoucher(VoidedTotal(orderItemList)).ToString("0.00"), regularFont, widthBound - 10, drawFormatRight, 20));
                        }
                        if (returnedItems)
                        {
                            lines.Add(new InvoiceLine("Returned Items ", italicFont, 10, drawFormatLeft, 0));
                            lines.Add(new InvoiceLine("- £" + ApplyVoucher(ReturnedTotal(orderItemList)).ToString("0.00"), regularFont, widthBound - 10, drawFormatRight, 20));

                        }
                    }

                    lines.Add(new InvoiceLine("----------------------------", regularFont, 10, drawFormatLeft, 20));

                    lines.Add(new InvoiceLine("TOTAL:", boldFont, 10, drawFormatLeft, 0));
                    lines.Add(new InvoiceLine("£" + Math.Round(total, 2), boldFont, widthBound - 10, drawFormatRight, 20));

                    lines.Add(new InvoiceLine("----------------------------", regularFont, 10, drawFormatLeft, 20));

                    // CUSTOMER MEMBER INFORMATION

                    // Customer information and membership insights are only displayed for members.
                    if (cust.memType!= "Deleted" && cust.memType != "Guest")
                    {

                        lines.Add(new InvoiceLine("Customer ID:", boldFont, 10, drawFormatLeft, 0));
                        lines.Add(new InvoiceLine(cust.id.ToString(), regularFont, widthBound - 10, drawFormatRight, 20));

                        lines.Add(new InvoiceLine("Customer Name:", boldFont, 10, drawFormatLeft, 0));
                        lines.Add(new InvoiceLine(CustAbbName, regularFont, widthBound - 10, drawFormatRight, 20));

                        lines.Add(new InvoiceLine("Member Status:", boldFont, 10, drawFormatLeft, 0));
                        lines.Add(new InvoiceLine(cust.memType, regularFont, widthBound - 10, drawFormatRight, 20));

                        lines.Add(new InvoiceLine("Stars Earned:", boldFont, 10, drawFormatLeft, 0));
                        lines.Add(new InvoiceLine(starsEarned.ToString(), regularFont, widthBound - 10, drawFormatRight, 20));

                        lines.Add(new InvoiceLine("Stars Balance:", boldFont, 10, drawFormatLeft, 0));
                        lines.Add(new InvoiceLine(cust.totalStars.ToString(), regularFont, widthBound - 10, drawFormatRight, 20));

                        // Displays membership insights for the customer.
                        // If the customer used a voucher in their order, display the total amount saved as a member with the shop.
                        // If the customer did not use a voucher in their order, display the total amount the customer needs to spend to earn the next voucher.
                        lines.Add(new InvoiceLine("****************************", regularFont, (widthBound / 2), drawFormatCenter, 20));
                        string currentLine;
                        if (voucher == "N/A")
                        {
                            currentLine = NextVoucherCost();
                        }
                        else
                        {
                            currentLine = CustTotalSaved();
                        }

                        // Wraps text if the message is too long to fit in one line on the receipt
                        if (currentLine.Length > 20)
                        {
                            while (currentLine.Length > 20)
                            {
                                int space = currentLine.LastIndexOf(' ', 20); // finds the last space before character 70
                                if (space != -1)
                                {
                                    // if at least one space is found
                                    lines.Add(new InvoiceLine(currentLine.Substring(0, space), italicFont, (widthBound / 2), drawFormatCenter, 20));
                                    currentLine = currentLine.Substring(space + 1); // sets the line to the remaining string to be printed
                                }
                                else
                                {
                                    // if no spaces are found
                                    lines.Add(new InvoiceLine(currentLine.Substring(0, 20), italicFont, (widthBound / 2), drawFormatCenter, 20));
                                    currentLine = currentLine.Substring(20);
                                }
                            }
                            lines.Add(new InvoiceLine(currentLine, italicFont, (widthBound / 2), drawFormatCenter, 20)); // prints the remaining string
                        }
                        else
                        {
                            lines.Add(new InvoiceLine(currentLine, italicFont, (widthBound / 2), drawFormatCenter, 20)); // prints the whole string
                        }

                        lines.Add(new InvoiceLine("****************************", regularFont, (widthBound / 2), drawFormatCenter, 20));

                    }
                    
                    // THANK YOU MESSAGE
                    lines.Add(new InvoiceLine("THANK YOU FOR", title2Font, widthBound / 2, drawFormatCenter, 20));
                    lines.Add(new InvoiceLine("SHOPPING WITH US", title2Font, widthBound / 2, drawFormatCenter, 20));

                }
                else
                {
                    e.HasMorePages = false;
                }


                // Loops through each line to be printed in the list of lines.
                // Each line to be printed is in a list so that if the invoice is to be saved as a pdf, the invoice will be printed along multiple pages instead of cut off at the end of one page.

                if (pdf) // If the invoice is to be saved as a pdf
                {
                    // Loops through each line from the start index specified by the public variable on the orders form. This variable is public so it can be accessed in this class.
                    // startIndex is used to determine which index in the list to start printing lines from, so lines can be printed along multiple pages seamlessly.
                    for (int i = Orders.startIndex; i < lines.Count; i++)
                    {
                        if (Orders.height < 1160)
                        {
                            e.Graphics.DrawString(lines[i].text, lines[i].font, drawBrush, lines[i].width, Orders.height, lines[i].format);
                            Orders.height += lines[i].heightInc;
                        }
                        else
                        {
                            e.HasMorePages = true;
                            Orders.pageNum++;
                            Orders.startIndex = i;
                            break;
                        }
                    }
                }
                else // If the invoice is to be printed directly as a receipt, there is no need for considering page breaks
                {
                    for (int i = 0; i < lines.Count; i++)
                    {
                        e.Graphics.DrawString(lines[i].text, lines[i].font, drawBrush, lines[i].width, Orders.height, lines[i].format);
                        Orders.height += lines[i].heightInc;
                    }
                }
            }
        }
    }
}
