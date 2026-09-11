using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarnShop
{
    public class Product
    {
        // Attributes
        private int ID { get; set; }
        private string Name { get; set; }
        private float Cost { get; set; }
        private int Stock { get; set; }
        private string FileName { get; set; }
        private int SupplierID { get; set; }
        private bool Discontinued { get; set; }
        private int LowStock { get; set; }
        private int FullStock { get; set; }
        public Product(int newID, string newName, Single newCost, int newStock, string newFileName, int newSupplierID, bool discontinued, int lowStock, int fullStock) // Constructor
        {
            ID = newID;
            Name = newName;
            Cost = newCost;
            Stock = newStock;
            FileName = newFileName;
            SupplierID = newSupplierID;
            this.Discontinued = discontinued;
            this.LowStock = lowStock;
            this.FullStock = fullStock;
        }

        // Getters
        public int id
        {
            get { return ID; }
        }
        public string name
        {
            get { return Name; }
        }
        public float cost
        {
            get { return Cost; }
        }
        public int stock
        {
            get { return Stock; }
        }
        public string filename
        {
            get { return FileName; }
        }
        public int supplierID
        {
            get { return SupplierID; }
        }
        public bool discontinued
        {
            get { return Discontinued; }
        }
        public int lowStock
        {
            get { return LowStock; }
        }
        public int fullStock
        {
            get { return FullStock; }
        }
        public string productInfo
        {
            get
            {
                return (name + " £" + cost.ToString("0.00"));
            }
        }
        public string CostString
        {
            // Returns the total cost of this specific order item in the order.
            get
            {
                return "£" + cost.ToString("0.00");
            }
        }
        public Supplier Supplier
        {
            get
            {
                Supplier supplier = null;
                bool error = false;
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                OleDbCommand cmd = con.CreateCommand();
                OleDbDataReader reader;
                con.Open();
                cmd.CommandText = "SELECT * FROM TableSuppliers WHERE SupplierID = @ssid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ssid", supplierID);
                cmd.Connection = con;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        supplier = new Supplier(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString());
                    }
                    catch
                    {
                        if (!error)
                        {
                            MessageBox.Show("Supplier data is missing.", "Missing Data");
                            error = true;
                        }
                    }
                }
                con.Close();
                return supplier;
            }
        }

        // Check stock levels
        public bool IsLowStock
        {
            get
            {
                if (stock < lowStock)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool OutOfStock
        {
            get
            {
                if (stock == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
