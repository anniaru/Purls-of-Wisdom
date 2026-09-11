using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarnShop
{
    public partial class NewProduct : Form
    {

        List<Supplier> suppliers = new List<Supplier>();
        List<string> YarnWeightList = new List<string>();
        List<string> CategoryList = new List<string>();
        List<string> FibreList = new List<string>();
        List<string> MaterialList = new List<string>();
        List<string> ColourList = new List<string>();

        OpenFileDialog dialog;
        FileInfo path = null;
        string tempProductType;

        // Make form draggable
        bool drag = false;
        Point dragCursor;
        Point dragForm;
        private void pbxBar_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            dragCursor = Cursor.Position;
            dragForm = Location;
        }
        private void pbxBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point difference = Point.Subtract(Cursor.Position, new Size(dragCursor));
                Location = Point.Add(dragForm, new Size(difference));
            }
        }
        private void pbxBar_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
        public NewProduct(bool newSupplier, int selectedSupplierID)
        {
            InitializeComponent();

            //loads suppliers into the combo box
            //should be done in refresh so it can update anything changed
            OleDbConnection conSuppliers = new OleDbConnection();
            conSuppliers.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmdSuppliers = conSuppliers.CreateCommand();
            OleDbDataReader readerSuppliers;
            conSuppliers.Open();
            cmdSuppliers.CommandText = "SELECT * FROM TableSuppliers WHERE SupplierName <> 'Deleted'";
            cmdSuppliers.Connection = conSuppliers;
            readerSuppliers = cmdSuppliers.ExecuteReader();
            while (readerSuppliers.Read())
            {
                //instantiates new supplier every time the loop iterates
                suppliers.Add(new Supplier(Convert.ToInt32(readerSuppliers[0]), Convert.ToString(readerSuppliers[1]), Convert.ToString(readerSuppliers[2]), Convert.ToString(readerSuppliers[3]), Convert.ToString(readerSuppliers[4]), Convert.ToString(readerSuppliers[5]), Convert.ToString(readerSuppliers[6])));
            }
            cbxSuppliers.DataSource = suppliers;
            cbxSuppliers.DisplayMember = "Suppliers";
            cbxSuppliers.ValueMember = "supplierName";
            conSuppliers.Close();

            newSupplierProduct(newSupplier,selectedSupplierID);
        }

        private void newSupplierProduct(bool newSupplier, int selectedSupplierID)
        {
            if (newSupplier)
            {
                foreach (Supplier supplier in suppliers)
                {
                    if (selectedSupplierID == supplier.id)
                    {
                        cbxSuppliers.SelectedIndex = suppliers.IndexOf(supplier);
                        cbxSuppliers.Enabled = false;
                    }
                }
            }
        }
        private void FormNewProduct_Load(object sender, EventArgs e)
        {
            //load all yarn weights into a list
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            OleDbDataReader reader;

            connection.Open();
            cmd.CommandText = "SELECT DISTINCT Category FROM TableProducts WHERE ProductType = 'y'";
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if ((reader[0] != null) || (Convert.ToString(reader[0]) != ""))
                {
                    YarnWeightList.Add(Convert.ToString(reader[0]));
                }
                else
                {
                    continue;
                }
            }
            connection.Close();

            //load all accessory categories into a list
            connection.Open();
            cmd.CommandText = "SELECT DISTINCT Category FROM TableProducts WHERE ProductType = 'a'";
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if ((reader[0] != null) || (Convert.ToString(reader[0]) != ""))
                {
                    CategoryList.Add(Convert.ToString(reader[0]));
                }
                else
                {
                    continue;
                }
            }
            connection.Close();

            //load all yarn fibres into a list
            connection.Open();
            cmd.CommandText = "SELECT DISTINCT FibreMaterial FROM TableProducts WHERE ProductType = 'y'";
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if ((reader[0] != null) || (Convert.ToString(reader[0]) != ""))
                {
                    FibreList.Add(Convert.ToString(reader[0]));
                }
                else
                {
                    continue;
                }
            }
            connection.Close();

            //load all accessory materials into a list
            connection.Open();
            cmd.CommandText = "SELECT DISTINCT FibreMaterial FROM TableProducts WHERE ProductType = 'a'";
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if ((reader[0] != null) || (Convert.ToString(reader[0]) != ""))
                {

                    MaterialList.Add(Convert.ToString(reader[0]));
                }
                else
                {
                    continue;
                }
            }
            connection.Close();

            //load all colours into a list
            connection.Open();
            cmd.CommandText = "SELECT DISTINCT Colour FROM TableProducts";
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if ((reader[0] != null) || (Convert.ToString(reader[0]) != ""))
                {

                    ColourList.Add(Convert.ToString(reader[0]));
                }
                else
                {
                    continue;
                }
            }
            connection.Close();

            rbtnYarn.Checked = true;
        }
        public bool ValidCost(string cost)
        {
            // Checks if the cost entered can be converted to a double, which can then be rounded to 2 decimal places if required.
            TypeConverter conv = TypeDescriptor.GetConverter(typeof(double));
            return conv.IsValid(cost);
        }
        private bool validString(string text) // Checks if the string is valid i.e. only contains valid alphanumerical characters and certain special characters
        {

            string allowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -_.,&/():'";

            // Check each character
            foreach (char c in text)
            {
                bool found = false;
                for (int i = 0; i < allowedCharacters.Length; i++)
                {
                    if(c == allowedCharacters[i])
                    {
                        found = true;
                    }
                }
                if (!found)
                {
                    return found;
                }
            }

            return true;

        }
        private bool supplierExists(string text)
        {
            foreach (Supplier sup in suppliers)
            {
                if (text == sup.supplierName)
                {
                    return true;
                }
            }
            return false;

        }
        private void btnAddSave_Click(object sender, EventArgs e) // Adds the product
        {
            // Ensures there are valid inputs in all required fields
            if(string.IsNullOrWhiteSpace(tbxProductName.Text) || string.IsNullOrWhiteSpace(tbxCost.Text) || string.IsNullOrWhiteSpace(cbxSuppliers.Text))
            {
                MessageBox.Show("Enter values in all required fields.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!supplierExists(cbxSuppliers.Text))
            {
                MessageBox.Show("Select an existing supplier.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (!ValidCost(tbxCost.Text))
            {
                MessageBox.Show("Enter a valid cost.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!validString(tbxType.Text) || !validString(cbxCategory.Text) || !validString(cbxColour.Text) || !validString(cbxFibre.Text) || !validString(tbxProductName.Text))
            {
                MessageBox.Show("Enter valid inputs in all fields.","Invalid Input",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(tbxType.Text))
                {
                    tbxType.Text = "N/A";
                }
                if (string.IsNullOrWhiteSpace(cbxCategory.Text))
                {
                    cbxCategory.Text = "N/A";
                }
                if (string.IsNullOrWhiteSpace(cbxColour.Text))
                {
                    cbxColour.Text = "N/A";
                }
                if (string.IsNullOrWhiteSpace(cbxFibre.Text))
                {
                    cbxFibre.Text = "N/A";
                }
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                OleDbCommand cmd = connection.CreateCommand();
                connection.Open();
                cmd.CommandText = "INSERT INTO TableProducts(ProductName, Cost, Stock, SupplierID, BallWeightSize, Category, Colour, FibreMaterial, ProductType, FileName,LowStock,FullStock) VALUES(@pn,@cos,@sto,@sup,@typ,@cat,@col,@fib,@pty,@fn,@ls,@fs)";
                cmd.Parameters.AddWithValue("@pn", tbxProductName.Text);
                cmd.Parameters.AddWithValue("@cos", Math.Round(Convert.ToDouble(tbxCost.Text), 2));
                cmd.Parameters.AddWithValue("@sto", numStock.Value);
                cmd.Parameters.AddWithValue("@sup", ((Supplier)cbxSuppliers.SelectedItem).id);
                cmd.Parameters.AddWithValue("@typ", tbxType.Text);
                cmd.Parameters.AddWithValue("@cat", cbxCategory.Text);
                cmd.Parameters.AddWithValue("@col", cbxColour.Text);
                cmd.Parameters.AddWithValue("@fib", cbxFibre.Text);
                cmd.Parameters.AddWithValue("@pty", tempProductType);
                if (path != null)
                {
                    cmd.Parameters.AddWithValue("@fn", tbxFileName.Text + ".jpg");
                    byte[] data = File.ReadAllBytes(path.FullName);

                    using (Stream str = new MemoryStream(data))
                    {
                        Bitmap image = new Bitmap(str);
                        image.Save(@"productImages\" + tbxFileName.Text + ".jpg");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@fn", "N/A");
                }
                cmd.Parameters.AddWithValue("@ls", numLowStock.Value);
                cmd.Parameters.AddWithValue("@fs", numFullStock.Value);
                cmd.Connection = connection;
                int status = cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("New product added successfully.", "Product Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
        private void btnClear_Click(object sender, EventArgs e) // Clears all fields
        {
            tbxProductName.Text = "";
            tbxCost.Text = "";
            cbxSuppliers.SelectedIndex = 0;
            pbxImage.Image = null;
            tbxFileName.Text = "";
            tbxType.Text = "";
            cbxCategory.SelectedIndex = 0;
            cbxColour.SelectedIndex = 0;
            cbxFibre.SelectedIndex = 0;
            numStock.Value = 0;
            numLowStock.Value = 0;
            numFullStock.Value = 0;
        }
        private void rbtnYarn_CheckedChanged(object sender, EventArgs e) // Changes all fields to yarn related fields
        {
            if (rbtnYarn.Checked)
            {
                tempProductType = "y";
                lblType.Text = "Ball Weight";
                lblCategory.Text = "Yarn Weight";
                lblFibre.Text = "Fibre";

                cbxCategory.DataSource = YarnWeightList;
                cbxFibre.DataSource = FibreList;
                cbxColour.DataSource = ColourList;
            }
        }
        private void rbtnAccessory_CheckedChanged(object sender, EventArgs e) // Changes all fields to accessory related fields
        {
            if (rbtnAccessory.Checked)
            {
                tempProductType = "a";
                lblType.Text = "Size";
                lblCategory.Text = "Category";
                lblFibre.Text = "Material";

                cbxCategory.DataSource = CategoryList;
                cbxFibre.DataSource = MaterialList;
                cbxColour.DataSource = ColourList;
            }
        }
        private void btnUpload_Click(object sender, EventArgs e) // Upload an image
        {
            string imageLocation = "";
            try
            {
                dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = new FileInfo(dialog.FileName);
                    imageLocation = dialog.FileName;
                    tbxFileName.Text = path.Name; // To be saved in the database
                    pbxImage.ImageLocation = imageLocation;
                }
            }
            catch 
            {
                MessageBox.Show("Upload error occurred. Please try again.", "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnRemove_Click(object sender, EventArgs e) // Remove any image uploaded
        {
            pbxImage.ImageLocation = null;
            tbxFileName.Text = "";
        }
        private void btnClose_Click(object sender, EventArgs e) // Close the form
        {
            Close();
        }
        private void numLowStock_ValueChanged(object sender, EventArgs e) // Low stock cannot be less than full stock
        {
            if (numLowStock.Value > numFullStock.Value)
            {
                numLowStock.Value = numFullStock.Value;
            }
        }
        private void numFullStock_ValueChanged(object sender, EventArgs e) // Full stock cannot be more than low stock
        {
            if (numLowStock.Value > numFullStock.Value)
            {
                numFullStock.Value = numLowStock.Value;
            }
        }
    }
}
