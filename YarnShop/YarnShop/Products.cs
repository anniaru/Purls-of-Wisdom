using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace YarnShop
{
    public partial class Products : Form
    {
        // Filter lists
        List<Supplier> supplierList = new List<Supplier>();
        List<string> YarnWeightList = new List<string>();
        List<string> CategoryList = new List<string>();
        List<string> FibreList = new List<string>();
        List<string> MaterialList = new List<string>();
        List<string> ColourList = new List<string>();
        bool filtersApplied; // True if filters have been applied, used in searches
        string currentCommand; // Stores the command used to retrieve the data currently shown in the dgv

        
        int index; //index used for finding row of information about a product
        Product currentProduct = null; // Stores the currently selected product
        Supplier currentSupplier = null; // Stores the supplier of the currently selected product
        string tempProductType; // Stores the type of product that is currently selected or is to be shown
        bool editMode = false; // True when editing a product

        // Used to upload, view, edit and remove the image of the product being edited
        OpenFileDialog dialog;
        FileInfo path = null;
        System.Drawing.Image currentImage = null;
        string currentProductImagePath;

        // Make form draggable
        bool drag = false;
        Point dragCursor;
        Point dragForm;

        public Products(Product noticeProduct)
        {
            InitializeComponent();
            currentProduct = noticeProduct;
        }

        // CUSTOM DRAGGABLE FORM BORDER
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (editMode)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to discard all changes?", "Discard Edits", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

        // VIEW ALL PRODUCTS
        private void FormProducts_Load(object sender, EventArgs e)
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
                supplierList.Add(new Supplier(Convert.ToInt32(readerSuppliers[0]), Convert.ToString(readerSuppliers[1]), Convert.ToString(readerSuppliers[2]), Convert.ToString(readerSuppliers[3]), Convert.ToString(readerSuppliers[4]), Convert.ToString(readerSuppliers[5]), Convert.ToString(readerSuppliers[6])));
            }
            cbxSuppliers.DataSource = supplierList;
            cbxSuppliers.DisplayMember = "Suppliers";
            cbxSuppliers.ValueMember = "supplierName";
            tbxSupplier.Text = "supplierName";
            conSuppliers.Close();

            refresh();
        }
        private void refresh()
        {
            disableEditing();
            filtersApplied = false;
            rbtnAll.Checked = true;
            // Cannot filter products until either yarn or accessories is selected
            // This is because the filters for yarn and accessories are different

            clearChecked(clsbCategory);
            clearChecked(clsbFibreMaterial);
            clearChecked(clsbColour);
            clearChecked(clsbSuppliers); 
            clearChecked(clsbStock);

            chbxDiscontinuedFilter.Checked = false;
            pnlFilters.AutoScroll = false;
            clsbCategory.Visible = false;
            clsbFibreMaterial.Visible = false;
            clsbColour.Visible = false;

            clsbSuppliers.DataSource = supplierList;
            clsbSuppliers.DisplayMember = "Suppliers";
            clsbSuppliers.ValueMember = "supplierName";

            refreshProductDGV();
            if (currentProduct != null) // displays the product passed into this form by notices
            {
                foreach (DataGridViewRow row in dgvProducts.Rows)
                {
                    if (row.Cells[0].Value.ToString() == currentProduct.id.ToString())
                    {
                        dgvProducts.ClearSelection();
                        dgvProducts.CurrentCell = dgvProducts.Rows[row.Index].Cells[0];
                        dgvProducts[0, row.Index].Selected = true;
                    }
                }
                refreshProductInfo(dgvProducts.CurrentRow.Index);
            }
            else
            {
                //ensures there is always something in the textboxes so null values don't appear when you edit another customer straight after
                refreshProductInfo(0);
            }
        }
        private void tbxSearch_TextChanged(object sender, EventArgs e) // As the user types in the search bar, products are searched for according to the input
        {
            // Search applies to all currently shown products, even if filters are applied
            if (!filtersApplied)
            {
                if (!string.IsNullOrWhiteSpace(tbxSearch.Text))
                {
                    if (rbtnAll.Checked)
                    {
                        OleDbConnection connection = new OleDbConnection();
                        connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmd = connection.CreateCommand();
                        OleDbDataReader reader;
                        connection.Open();
                        cmd.CommandText = "SELECT * FROM TableProducts WHERE ProductName LIKE @pn AND Discontinued = False";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@pn", "%" + tbxSearch.Text + "%");
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = reader;
                            dgvProducts.DataSource = bindingSource;
                        }
                        connection.Close();
                    }
                    else
                    {
                        if (rbtnYarn.Checked)
                        {
                            tempProductType = "y";
                        }
                        if (rbtnAcc.Checked)
                        {
                            tempProductType = "a";
                        }
                        OleDbConnection connection = new OleDbConnection();
                        connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmd = connection.CreateCommand();
                        OleDbDataReader reader;
                        connection.Open();
                        cmd.CommandText = "SELECT * FROM TableProducts WHERE ProductType = @ya AND ProductName LIKE @pn AND Discontinued = False";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ya", tempProductType);
                        cmd.Parameters.AddWithValue("@pn", "%" + tbxSearch.Text + "%");
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = reader;
                            dgvProducts.DataSource = bindingSource;
                        }
                        connection.Close();
                    }
                }
                else
                {
                    if (rbtnAll.Checked)
                    {

                        OleDbConnection connection = new OleDbConnection();
                        connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmd = connection.CreateCommand();
                        OleDbDataReader reader;
                        connection.Open();
                        cmd.CommandText = "SELECT * FROM TableProducts WHERE Discontinued = False";
                        cmd.Parameters.Clear();
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = reader;
                            dgvProducts.DataSource = bindingSource;
                        }
                        connection.Close();
                    }
                    else
                    {
                        if (rbtnYarn.Checked)
                        {
                            tempProductType = "y";
                        }
                        if (rbtnAcc.Checked)
                        {
                            tempProductType = "a";
                        }

                        OleDbConnection connection = new OleDbConnection();
                        connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmd = connection.CreateCommand();
                        OleDbDataReader reader;
                        connection.Open();
                        cmd.CommandText = "SELECT * FROM TableProducts WHERE ProductType = @ya AND Discontinued = False";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ya", tempProductType);
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = reader;
                            dgvProducts.DataSource = bindingSource;
                        }
                        connection.Close();
                    }
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(tbxSearch.Text))
                {
                    if (rbtnAll.Checked)
                    {
                        OleDbConnection connection = new OleDbConnection();
                        connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmd = connection.CreateCommand();
                        OleDbDataReader reader;
                        connection.Open();
                        cmd.CommandText = currentCommand + " AND ProductName LIKE @pn";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@pn", "%" + tbxSearch.Text + "%");
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = reader;
                            dgvProducts.DataSource = bindingSource;
                        }
                        connection.Close();
                    }
                    else
                    {
                        if (rbtnYarn.Checked)
                        {
                            tempProductType = "y";
                        }
                        if (rbtnAcc.Checked)
                        {
                            tempProductType = "a";
                        }
                        OleDbConnection connection = new OleDbConnection();
                        connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmd = connection.CreateCommand();
                        OleDbDataReader reader;
                        connection.Open();
                        cmd.CommandText = currentCommand + " AND ProductName LIKE @pn";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ya", tempProductType);
                        cmd.Parameters.AddWithValue("@pn", "%" + tbxSearch.Text + "%");
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = reader;
                            dgvProducts.DataSource = bindingSource;
                        }
                        connection.Close();
                    }
                }
                else
                {
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    cmd.CommandText = currentCommand;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ya", tempProductType);
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    if (reader.HasRows)
                    {
                        bindingSource.DataSource = reader;
                        dgvProducts.DataSource = bindingSource;
                    }
                    connection.Close();
                }
            }
            highlightProductsStock();

        }
        private void btnSearch_Click(object sender, EventArgs e) // Searches for products when the user clicks the button
        {
            if (!filtersApplied)
            {
                if (!string.IsNullOrWhiteSpace(tbxSearch.Text))
                {
                    if (rbtnAll.Checked)
                    {
                        OleDbConnection connection = new OleDbConnection();
                        connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmd = connection.CreateCommand();
                        OleDbDataReader reader;
                        connection.Open();
                        cmd.CommandText = "SELECT * FROM TableProducts WHERE ProductName LIKE @pn AND Discontinued = False";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@pn", "%" + tbxSearch.Text + "%");
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = reader;
                            dgvProducts.DataSource = bindingSource;
                        }
                        else
                        {
                            MessageBox.Show("No products found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        connection.Close();
                    }
                    else
                    {
                        if (rbtnYarn.Checked)
                        {
                            tempProductType = "y";
                        }
                        if (rbtnAcc.Checked)
                        {
                            tempProductType = "a";
                        }
                        OleDbConnection connection = new OleDbConnection();
                        connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmd = connection.CreateCommand();
                        OleDbDataReader reader;
                        connection.Open();
                        cmd.CommandText = "SELECT * FROM TableProducts WHERE ProductType = @ya AND ProductName LIKE @pn AND Discontinued = False";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ya", tempProductType);
                        cmd.Parameters.AddWithValue("@pn", "%" + tbxSearch.Text + "%");
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = reader;
                            dgvProducts.DataSource = bindingSource;
                        }
                        else
                        {
                            MessageBox.Show("No products found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        connection.Close();
                    }
                }
                else
                {
                    if (rbtnAll.Checked)
                    {
                        OleDbConnection connection = new OleDbConnection();
                        connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmd = connection.CreateCommand();
                        OleDbDataReader reader;
                        connection.Open();
                        cmd.CommandText = "SELECT * FROM TableProducts WHERE Discontinued = False";
                        cmd.Parameters.Clear();
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = reader;
                            dgvProducts.DataSource = bindingSource;
                        }
                        else
                        {
                            MessageBox.Show("No products found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        connection.Close();
                    }
                    else
                    {
                        if (rbtnYarn.Checked)
                        {
                            tempProductType = "y";
                        }
                        if (rbtnAcc.Checked)
                        {
                            tempProductType = "a";
                        }
                        OleDbConnection connection = new OleDbConnection();
                        connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmd = connection.CreateCommand();
                        OleDbDataReader reader;
                        connection.Open();
                        cmd.CommandText = "SELECT * FROM TableProducts WHERE ProductType = @ya AND Discontinued = False";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ya", tempProductType);
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = reader;
                            dgvProducts.DataSource = bindingSource;
                        }
                        else
                        {
                            MessageBox.Show("No products found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        connection.Close();
                    }
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(tbxSearch.Text))
                {
                    if (rbtnAll.Checked)
                    {
                        OleDbConnection connection = new OleDbConnection();
                        connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmd = connection.CreateCommand();
                        OleDbDataReader reader;
                        connection.Open();
                        cmd.CommandText = currentCommand + " AND ProductName LIKE @pn";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@pn", "%" + tbxSearch.Text + "%");
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = reader;
                            dgvProducts.DataSource = bindingSource;
                        }
                        else
                        {
                            MessageBox.Show("No products found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        connection.Close();
                    }
                    else
                    {
                        if (rbtnYarn.Checked)
                        {
                            tempProductType = "y";
                        }
                        if (rbtnAcc.Checked)
                        {
                            tempProductType = "a";
                        }
                        OleDbConnection connection = new OleDbConnection();
                        connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmd = connection.CreateCommand();
                        OleDbDataReader reader;
                        connection.Open();
                        cmd.CommandText = currentCommand + " AND ProductName LIKE @pn";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ya", tempProductType);
                        cmd.Parameters.AddWithValue("@pn", "%" + tbxSearch.Text + "%");
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = reader;
                            dgvProducts.DataSource = bindingSource;
                        }
                        else
                        {
                            MessageBox.Show("No products found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        connection.Close();
                    }
                }
                else
                {
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    cmd.CommandText = currentCommand;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ya", tempProductType);
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    if (reader.HasRows)
                    {
                        bindingSource.DataSource = reader;
                        dgvProducts.DataSource = bindingSource;
                    }
                    else
                    {
                        MessageBox.Show("No products found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connection.Close();
                }
            }
            highlightProductsStock();
        }
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e) // Allows the user to click on a product and view all product details for that product
        {
            disableEditing();
            editMode = false;
            index = e.RowIndex;
            if (index < 0)
            {
                index = 0;
            }
            refreshProductInfo(index);
        }
        private void refreshProductInfo(int index) // Show all product details
        {
            if (index < 0)
            {
                index = 0;
            }
            DataGridViewRow selectedRow = dgvProducts.Rows[index];
            currentProduct = new Product(Convert.ToInt32(selectedRow.Cells[0].Value), selectedRow.Cells[1].Value.ToString(), Convert.ToSingle(selectedRow.Cells[2].Value), Convert.ToInt32(selectedRow.Cells[3].Value), selectedRow.Cells[10].Value.ToString(), Convert.ToInt32(selectedRow.Cells[4].Value), Convert.ToBoolean(selectedRow.Cells[11].Value), Convert.ToInt32(selectedRow.Cells[12].Value), Convert.ToInt32(selectedRow.Cells[13].Value));
            currentSupplier = currentProduct.Supplier;
            tbxProductID.Text = currentProduct.id.ToString();
            tbxProductName.Text = currentProduct.name;
            tbxCost.Text = currentProduct.CostString;
            tbxStock.Text = currentProduct.stock.ToString();
            tbxSupplier.Text = currentSupplier.supplierName;
            tbxType.Text = selectedRow.Cells[5].Value.ToString();
            tbxCategory.Text = selectedRow.Cells[6].Value.ToString();
            tbxColour.Text = selectedRow.Cells[7].Value.ToString();
            tbxFibre.Text = selectedRow.Cells[8].Value.ToString();
            tempProductType = selectedRow.Cells[9].Value.ToString();
            currentProductImagePath = Path.GetFullPath("productImages/" + currentProduct.filename);
            tbxFileName.Text = currentProduct.filename;
            numStock.Value = currentProduct.stock;
            numFullStock.Value = currentProduct.fullStock;
            numLowStock.Value = currentProduct.lowStock;
            pbxImage.Refresh();
            if (currentProduct.discontinued)
            {
                lblDiscontinued.Visible = true;
                editToolStripMenuItem.Visible = false;
                discontinueToolStripMenuItem.Visible = false;
            }
            else
            {
                lblDiscontinued.Visible = false;
                editToolStripMenuItem.Visible = true;
                discontinueToolStripMenuItem.Visible = true;
            }

            if (currentProduct.OutOfStock)
            {
                lblStockLevel.Visible = true;
                lblStockLevel.Text = "Out Of Stock";
            }
            else if (currentProduct.IsLowStock)
            {
                lblStockLevel.Visible = true;
                lblStockLevel.Text = "Low Stock";
            }
            else
            {
                lblStockLevel.Visible = false;
            }

            if (tempProductType == "y")
            {
                showYarnFields(false);
            }
            if (tempProductType == "a")
            {
                showAccFields(false);
            }


        }
        private void refreshProductDGV() // Refresh all products
        {
            //this is a separate subroutine because while making an order, new products may be added, so this subroutine is required to update the
            //  dgv of products each time a new product is added
            //loads up all the data into the dgv
            tbxSearch.Text = "";
            string type = "";
            if (rbtnAcc.Checked)
            {
                type = "a";
            }
            if (rbtnYarn.Checked)
            {
                type = "y";
            }
            if (rbtnAll.Checked)
            {

                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = connection.CreateCommand();
                OleDbDataReader reader;
                connection.Open();
                cmd.CommandText = "SELECT * FROM TableProducts WHERE Discontinued = False";
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                if (reader.HasRows)
                {
                    bindingSource.DataSource = reader;
                    dgvProducts.DataSource = bindingSource;
                }
                else
                {
                    MessageBox.Show("No results found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                connection.Close();
            }
            else
            {
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = connection.CreateCommand();
                OleDbDataReader reader;
                connection.Open();
                cmd.CommandText = "SELECT * FROM TableProducts WHERE ProductType = @ya AND Discontinued = False";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ya", type);
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                if (reader.HasRows)
                {
                    bindingSource.DataSource = reader;
                    dgvProducts.DataSource = bindingSource;
                }
                else
                {
                    MessageBox.Show("No results found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                connection.Close();
            }
            highlightProductsStock();
        }
        private void highlightProductsStock() // Highlights which products are out of stock or low on stock in the dgv
        {
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (Convert.ToInt32(row.Cells[3].Value) == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.DarkRed;
                    row.DefaultCellStyle.ForeColor = SystemColors.ControlLightLight;
                }
                else if (Convert.ToInt32(row.Cells[3].Value) < Convert.ToInt32(row.Cells[12].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(199, 110, 0);
                    row.DefaultCellStyle.ForeColor = SystemColors.ControlLightLight;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = SystemColors.ControlLightLight;
                    row.DefaultCellStyle.ForeColor = SystemColors.ControlText;
                }
            }
            // Highlights products in the dgv that have low stock or no stock.
        }

        // FILTERS
        private void showYarnFields(bool filter) // Changes fields shown to suit yarn products.
        {
            if (filter)
            {
                clsbCategory.Visible = true;
                clsbFibreMaterial.Visible = true;
                clsbColour.Visible = true;

                clsbCategory.DataSource = YarnWeightList;
                clsbFibreMaterial.DataSource = FibreList;
                clsbColour.DataSource = ColourList;

                lblCategoryFilter.Text = "YARN WEIGHT";
                lblFibreMaterialFilter.Text = "FIBRE";
                lblCategoryFilter.Visible = true;
                lblFibreMaterialFilter.Visible = true;
                lblColourFilter.Visible = true;

                clearChecked(clsbCategory);
                clearChecked(clsbFibreMaterial);
                clearChecked(clsbColour);
                clearChecked(clsbSuppliers);

                chbxDiscontinuedFilter.Checked = false;

                pnlFilters.AutoScroll = true;
            }

            lblType.Text = "Ball Weight";
            lblCategory.Text = "Yarn Weight";
            lblFibre.Text = "Fibre";

            cbxCategory.DataSource = YarnWeightList;
            cbxFibre.DataSource = FibreList;
            cbxColour.DataSource = ColourList;


        }
        private void showAccFields(bool filter) // Changes fields shown to suit accessory products.
        {
            if (filter)
            {
                clsbCategory.Visible = true;
                clsbFibreMaterial.Visible = true;
                clsbColour.Visible = true;

                lblCategoryFilter.Text = "CATEGORY";
                lblFibreMaterialFilter.Text = "MATERIAL";
                lblCategoryFilter.Visible = true;
                lblFibreMaterialFilter.Visible = true;
                lblColourFilter.Visible = true;

                clsbCategory.DataSource = CategoryList;
                clsbFibreMaterial.DataSource = MaterialList;
                clsbColour.DataSource = ColourList;

                clearChecked(clsbCategory);
                clearChecked(clsbFibreMaterial);
                clearChecked(clsbColour);
                clearChecked(clsbSuppliers);

                chbxDiscontinuedFilter.Checked = false;

                pnlFilters.AutoScroll = true;
            }

            lblType.Text = "Size";
            lblCategory.Text = "Category";
            lblFibre.Text = "Material";

            cbxCategory.DataSource = CategoryList;
            cbxFibre.DataSource = MaterialList;
            cbxColour.DataSource = ColourList;

        }
        private void clearChecked(CheckedListBox clsbToClear) // Clears all checked items in the checked list box.
        {
            for (int i = 0; i < clsbToClear.Items.Count; i++)
            {
                clsbToClear.SetSelected(i, false);
                clsbToClear.SetItemChecked(i, false);
            }
            clsbToClear.ClearSelected();
        }
        private void rbtnYarn_CheckedChanged(object sender, EventArgs e) // Shows all yarn products
        {
            if (rbtnYarn.Checked == true)
            {   
                showYarnFields(true);
                disableEditing();
                refreshProductDGV();
                refreshProductInfo(0);
            }
        }
        private void rbtnAcc_CheckedChanged(object sender, EventArgs e) // Shows all accessory products
        {
            if (rbtnAcc.Checked == true)
            {
                showAccFields(true);
                disableEditing();
                refreshProductDGV();
                refreshProductInfo(0);
            }

        }
        private void rbtnAll_Click(object sender, EventArgs e) // Shows all products and clears all filters
        {
            // If there are any other filters selected, clicking the all radio button will clear all filters selected.
            // A message box will be shown if any filters apart from Yarn and Accessories are selected.
            DialogResult result = MessageBox.Show("This will clear all filters. Proceed?", "Clear Filters", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            tbxSearch.Text = "";
            if (result == DialogResult.Yes)
            {
                refresh();
            }
            else
            {
                MessageBox.Show("No filters were cleared.","Clear Filters",MessageBoxButtons.OK,MessageBoxIcon.Information);
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = connection.CreateCommand();
                OleDbDataReader reader;
                connection.Open();
                cmd.CommandText = "SELECT * FROM TableProducts WHERE ProductType = @ya AND Discontinued = False";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ya", tempProductType);
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();
                if (reader.HasRows) //in case all accessories or yarn products have been deleted
                {
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = reader;
                    dgvProducts.DataSource = bindingSource;
                    if (tempProductType == "y")
                    {
                        rbtnYarn.Checked = true;
                        showYarnFields(false);
                    }
                    if (tempProductType == "a")
                    {
                        rbtnAcc.Checked = true;
                        showAccFields(false);
                    }
                }
                else
                {
                    MessageBox.Show("No results found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rbtnAll.Checked = true;
                    rbtnYarn.Checked = false;
                }
                connection.Close();
            }
            highlightProductsStock();
        }
        private void btnApplyFilters_Click(object sender, EventArgs e) // Apply filters selected
        {
            filtersApplied = false;
            string baseCommandText = "SELECT * FROM TableProducts WHERE";
            string categoryFilterCommand = " AND Category IN (";
            string fibreFilterCommand = " AND FibreMaterial IN (";
            string colourFilterCommand = " AND Colour IN (";
            string supplierFilterCommand = " AND SupplierID IN (";

            // Need these lists to store the selected items for each checked list box.
            // Since a new list is created each time the user clicks the apply button, the list will be cleared each time.

            List<string> selectedCategoryFilters = new List<string>();
            List<string> selectedFibreFilters = new List<string>();
            List<string> selectedColourFilters = new List<string>();
            List<string> selectedStockFilters = new List<string>();

            // Load all the checked filters into their corresponding lists.

            selectedCategoryFilters = clsbCategory.CheckedItems.Cast<string>().ToList();
            selectedFibreFilters = clsbFibreMaterial.CheckedItems.Cast<string>().ToList();
            selectedColourFilters = clsbColour.CheckedItems.Cast<string>().ToList();
            selectedStockFilters = clsbStock.CheckedItems.Cast<string>().ToList();
            List<Supplier> selectedSupplierFilters = clsbSuppliers.CheckedItems.Cast<Supplier>().ToList();
            if (selectedStockFilters.Count != 0)
            {
                filtersApplied = true;
                foreach (string stockFilter in selectedStockFilters)
                {
                    string condition = "";
                    switch (stockFilter)
                    {
                        case "In Stock":
                            condition = " Stock > 0";
                            break;
                        case "No Stock":
                            condition = " Stock = 0";
                            break;
                        case "Low Stock":
                            condition = " Stock < LowStock";
                            break;
                    }
                    if (baseCommandText.EndsWith("E"))
                    {
                        baseCommandText += " (" + condition;
                    }
                    else
                    {
                        baseCommandText += " OR" + condition;
                    }
                }
                baseCommandText += ")";
            }
            else
            {
                baseCommandText += " Stock >= 0"; // If no specific stock filters are selected, results will only include products in stock.
            }
            if (!rbtnAll.Checked)
            {
                baseCommandText += " AND ProductType = @ya";
            }
            // Building the command string

            if (selectedCategoryFilters.Count != 0)
            {
                filtersApplied = true;
                foreach (string categoryFilter in selectedCategoryFilters)
                {
                    // If there isn't anything in the string so far, don't want it to start with a comma.
                    if (categoryFilterCommand.EndsWith("("))
                    {
                        categoryFilterCommand += "'" + categoryFilter + "'";
                    }
                    // Add the checked filter to the command string.
                    else
                    {
                        categoryFilterCommand += "," + "'" + categoryFilter + "'";
                    }
                }
                baseCommandText += categoryFilterCommand + ")";
            }
            if (selectedFibreFilters.Count != 0)
            {
                filtersApplied = true;
                foreach (string fibreFilter in selectedFibreFilters)
                {
                    // If there isn't anything in the string so far, don't want it to start with a comma.
                    if (fibreFilterCommand.EndsWith("("))
                    {
                        fibreFilterCommand += "'" + fibreFilter + "'";
                    }
                    // Add the checked filter to the command string.
                    else
                    {
                        fibreFilterCommand += "," + "'" + fibreFilter + "'";
                    }
                }
                baseCommandText += fibreFilterCommand + ")";
            }
            if (selectedColourFilters.Count != 0)
            {
                filtersApplied = true;
                foreach (string colourFilter in selectedColourFilters)
                {
                    // If there isn't anything in the string so far, don't want it to start with a comma.
                    if (colourFilterCommand.EndsWith("("))
                    {
                        colourFilterCommand += "'" + colourFilter + "'";
                    }
                    // Add the checked filter to the command string.
                    else
                    {
                        colourFilterCommand += "," + "'" + colourFilter + "'";
                    }
                }
                baseCommandText += colourFilterCommand + ")";
            }
            if (selectedSupplierFilters.Count != 0)
            {
                filtersApplied = true;
                foreach (Supplier supplierFilter in selectedSupplierFilters)
                {
                    // If there isn't anything in the string so far, don't want it to start with a comma.
                    if (supplierFilterCommand.EndsWith("("))
                    {
                        supplierFilterCommand += supplierFilter.id;
                    }
                    // Add the checked filter to the command string.
                    else
                    {
                        supplierFilterCommand += "," + supplierFilter.id;
                    }
                }
                baseCommandText += supplierFilterCommand + ")";
            }
            if (chbxDiscontinuedFilter.Checked)
            {
                filtersApplied = true;
                baseCommandText = baseCommandText + " AND Discontinued = True";
            }
            else
            {
                baseCommandText = baseCommandText + " AND Discontinued = False";
            }

            // Running the queries
            if (rbtnYarn.Checked)
            {
                tempProductType = "y";
            }
            if (rbtnAcc.Checked)
            {
                tempProductType = "a";
            }

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            OleDbDataReader reader;
            connection.Open();
            cmd.CommandText = baseCommandText;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ya", tempProductType);
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            BindingSource bindingSource = new BindingSource();
            if (reader.HasRows)
            {
                bindingSource.DataSource = reader;
                dgvProducts.DataSource = bindingSource;
                currentCommand = baseCommandText;
                tbxSearch.Text = "";
            }
            else
            {
                MessageBox.Show("No products found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            connection.Close();
            highlightProductsStock();
        }
        private void btnClearFilters_Click(object sender, EventArgs e) // Clears all filters selected
        {
            DialogResult result = MessageBox.Show("This will clear all filters. Proceed?", "Clear All Filters", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                clearChecked(clsbCategory);
                clearChecked(clsbFibreMaterial);
                clearChecked(clsbColour);
                clearChecked(clsbSuppliers);
                clearChecked(clsbStock);
                chbxDiscontinuedFilter.Checked = false;

                if (rbtnAll.Checked)
                {
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    cmd.CommandText = "SELECT * FROM TableProducts WHERE Discontinued = False";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ya", "y");
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = reader;
                    dgvProducts.DataSource = bindingSource;
                    connection.Close();
                }
                else
                {
                    if (rbtnYarn.Checked)
                    {
                        tempProductType = "y";
                    }
                    if (rbtnAcc.Checked)
                    {
                        tempProductType = "a";
                    }
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    cmd.CommandText = "SELECT * FROM TableProducts WHERE Discontinued = False AND ProductType = @ya";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ya", tempProductType);
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = reader;
                    dgvProducts.DataSource = bindingSource;
                    connection.Close();
                }
                filtersApplied = false;
                currentCommand = "";
            }
            else
            {
                MessageBox.Show("No filters were deleted.", "Clear All Filters", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            highlightProductsStock();
        }

        // ADDING, EDITING AND DISCONTINUING PRODUCTS
        private void disableEditing() // Disables editing of all fields
        {
            editMode = false;
            btnAddSave.Text = "Add New Product";

            //text boxes are all read only when not in edit mode

            lblLowStock.Visible = false;
            lblFullStock.Visible = false;
            numFullStock.Visible = false;
            numLowStock.Visible = false;
            numStock.Visible = false;
            tbxStock.Visible = true;

            tbxProductID.ReadOnly = true;
            tbxProductName.ReadOnly = true;
            tbxCost.ReadOnly = true;
            tbxStock.ReadOnly = true;
            tbxSupplier.ReadOnly = true;

            tbxType.ReadOnly = true;
            tbxCategory.ReadOnly = true;
            tbxColour.ReadOnly = true;
            tbxFibre.ReadOnly = true;

            tbxSupplier.Visible = true;
            tbxCategory.Visible = true;
            tbxColour.Visible = true;
            tbxFibre.Visible = true;

            cbxSuppliers.Visible = false;
            cbxCategory.Visible = false;
            cbxColour.Visible = false;
            cbxFibre.Visible = false;

            btnApplyFilters.Visible = true;
            btnClearFilters.Visible = true;
            btnCancel.Visible = false;
            btnUpload.Visible = false;
            btnRemove.Visible = false;
            btnReset.Visible = false;
            tbxFileName.Visible = false;
            lblSaveAs.Visible = false;

            pbxHideFilter.Visible = false;

            //change design to make it clear it is not editable
            tbxProductID.BackColor = SystemColors.ControlLightLight;
            tbxProductName.BackColor = SystemColors.ControlLightLight;
            tbxCost.BackColor = SystemColors.ControlLightLight;
            tbxStock.BackColor = SystemColors.ControlLightLight;
            tbxSupplier.BackColor = SystemColors.ControlLightLight;
            tbxType.BackColor = SystemColors.ControlLightLight;
            cbxSuppliers.BackColor = SystemColors.ControlLightLight;
            cbxCategory.BackColor = SystemColors.ControlLightLight;
            cbxColour.BackColor = SystemColors.ControlLightLight;
            cbxFibre.BackColor = SystemColors.ControlLightLight;

            tbxProductID.BorderStyle = BorderStyle.None;
            tbxProductName.BorderStyle = BorderStyle.None;
            tbxCost.BorderStyle = BorderStyle.None;
            tbxStock.BorderStyle = BorderStyle.None;
            tbxSupplier.BorderStyle = BorderStyle.None;
            tbxType.BorderStyle = BorderStyle.None;
        }
        private void enableEditing() // Makes fields editable
        {
            //changes design to make it clear to type in tbxs
            tbxProductName.BackColor = Color.White;
            tbxCost.BackColor = Color.White;
            tbxStock.BackColor = Color.White;
            tbxSupplier.BackColor = Color.White;
            tbxType.BackColor = Color.White;
            cbxSuppliers.BackColor = Color.White;
            cbxCategory.BackColor = Color.White;
            cbxColour.BackColor = Color.White;
            cbxFibre.BackColor = Color.White;

            tbxProductName.BorderStyle = BorderStyle.Fixed3D;
            tbxCost.BorderStyle = BorderStyle.Fixed3D;
            tbxStock.BorderStyle = BorderStyle.Fixed3D;
            tbxSupplier.BorderStyle = BorderStyle.Fixed3D;
            tbxType.BorderStyle = BorderStyle.Fixed3D;

            //allows user to edit/add
            lblLowStock.Visible = true;
            lblFullStock.Visible = true;
            numFullStock.Visible = true;
            numLowStock.Visible = true;
            numStock.Visible = true;
            tbxStock.Visible = false;

            tbxProductName.ReadOnly = false;
            tbxCost.ReadOnly = false;
            tbxStock.ReadOnly = false;
            tbxSupplier.ReadOnly = false;
            tbxType.ReadOnly = false;

            tbxSupplier.Visible = false;
            tbxCategory.Visible = false;
            tbxColour.Visible = false;
            tbxFibre.Visible = false;

            cbxSuppliers.Visible = true;
            cbxCategory.Visible = true;
            cbxColour.Visible = true;
            cbxFibre.Visible = true;

            cbxSuppliers.Text = tbxSupplier.Text;
            cbxCategory.Text = tbxCategory.Text;
            cbxColour.Text = tbxColour.Text;
            cbxFibre.Text = tbxFibre.Text;

            btnApplyFilters.Visible = false;
            btnClearFilters.Visible = false;
            btnCancel.Visible = true;
            btnUpload.Visible = true;
            btnRemove.Visible = true;
            btnReset.Visible = true;
            tbxFileName.Visible = true;
            lblSaveAs.Visible = true;

            pbxHideFilter.Visible = true;

        }
        private void numLowStock_ValueChanged(object sender, EventArgs e) // Ensures low stock levels cannot be bigger than full stock levels
        {
            if (numLowStock.Value > numFullStock.Value)
            {
                numLowStock.Value = numFullStock.Value;
            }
        }
        private void numFullStock_ValueChanged(object sender, EventArgs e) // Ensures low stock levels cannot be bigger than full stock levels
        {
            if (numLowStock.Value > numFullStock.Value)
            {
                numFullStock.Value = numLowStock.Value;
            }
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e) // Enables the user to edit a product
        {
            editMode = true;
            enableEditing();
            cbxSuppliers.Text = currentSupplier.supplierName;
            cbxCategory.Text = tbxCategory.Text;
            cbxColour.Text = tbxColour.Text;
            cbxFibre.Text = tbxFibre.Text;
            btnAddSave.Text = "Save";
        }
        private void discontinueToolStripMenuItem_Click(object sender, EventArgs e) // Discontinue a product
        {
            // Products are discontinued rather than deleted to maintain referential integrity.
            if (dgvProducts.SelectedRows != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to discontinue this product?", "Discontinue Product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    connection.Open();
                    cmd.CommandText = "UPDATE TableProducts SET Discontinued = True WHERE ProductID = @pid";
                    cmd.Parameters.AddWithValue("@pid", currentProduct.id);
                    cmd.Connection = connection;
                    int status = cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Product discontinued.", "Discontinue Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
                else
                {
                    MessageBox.Show("No changes were made.", "Discontinue Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Select a product to discontinue.", "Product Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e) // Cancel editing a product and discard all changes
        {
            if (editMode)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to discard all changes?", "Discard Edits", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    refreshProductInfo(index);
                    disableEditing();
                    pbxImage.ImageLocation = currentProduct.filename;
                }
            }
            else
            {
                refresh();
            }
        }

        private bool supplierExists(string text)
        {
            foreach(Supplier sup in supplierList)
            {
                if(text == sup.supplierName)
                {
                    return true;
                }
            }
            return false;

        }
        private void btnAddSave_Click(object sender, EventArgs e) // Add a new product, or save changes made if editing
        {
            //editMode is set to true when the user uses the context menu strip and clicks edit
            //editMode is set to false whenever the form refreshes (after deleting, adding or editing a record) or when the user clicks on another customer
            if (!editMode)
            {
                NewProduct formNewProduct = new NewProduct(false, currentSupplier.id);
                formNewProduct.ShowDialog();
                refresh();
            }
            if (editMode)
            {
                if (string.IsNullOrWhiteSpace(tbxProductName.Text) || string.IsNullOrWhiteSpace(tbxCost.Text) || string.IsNullOrWhiteSpace(cbxSuppliers.Text))
                {
                    MessageBox.Show("Enter values in all required fields.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!supplierExists(cbxSuppliers.Text))
                {
                    MessageBox.Show("Select an existing supplier.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (invalidFileName(tbxFileName.Text))
                {
                    MessageBox.Show("Enter a valid filename.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!ValidCost(tbxCost.Text))
                {
                    MessageBox.Show("Enter a valid cost.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    cmd.CommandText = "UPDATE TableProducts SET ProductName = @pn, Cost = @cos, Stock = @sto, SupplierID = @sup, BallWeightSize = @typ, Category = @cat, Colour = @col, FibreMaterial = @fib, FileName = @fn, LowStock = @ls, FullStock = @fs WHERE ProductID = @prid";
                    cmd.Parameters.AddWithValue("@pn", tbxProductName.Text); 
                    if (tbxCost.Text.StartsWith("£"))
                    {
                        // If the user enters a £ sign in
                        tbxCost.Text = tbxCost.Text.Remove(0, 1);
                    }
                    cmd.Parameters.AddWithValue("@cos", Math.Round(Convert.ToDouble(tbxCost.Text), 2));
                    cmd.Parameters.AddWithValue("@sto", numStock.Value);
                    cmd.Parameters.AddWithValue("@sup", currentSupplier.id);
                    cmd.Parameters.AddWithValue("@typ", tbxType.Text);
                    cmd.Parameters.AddWithValue("@cat", cbxCategory.Text);
                    cmd.Parameters.AddWithValue("@col", cbxColour.Text);
                    cmd.Parameters.AddWithValue("@fib", cbxFibre.Text);
                    if (path != null && tbxFileName.Text != "N/A")
                    {
                        if (tbxFileName.Text.Contains(".jpg") || tbxFileName.Text.Contains(".png"))
                        {
                            cmd.Parameters.AddWithValue("@fn", tbxFileName.Text);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@fn", tbxFileName.Text + ".jpg");
                        }

                        byte[] data = File.ReadAllBytes(path.FullName);

                        if (tbxFileName.Text != currentProduct.filename) // if a different image was uploaded or if the name of the image was changed
                        {
                            using (Stream str = new MemoryStream(data))
                            {
                                Bitmap image = new Bitmap(str);
                                image.Save(@"productImages\" + tbxFileName.Text + ".jpg");
                            }
                        }
                    }
                    else if(currentProduct.filename == null)
                    {
                        cmd.Parameters.AddWithValue("@fn", "N/A");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@fn", currentProduct.filename);
                    }
                    cmd.Parameters.AddWithValue("@ls", numLowStock.Value);
                    cmd.Parameters.AddWithValue("@fs", numFullStock.Value);
                    cmd.Parameters.AddWithValue("@prid", currentProduct.id);
                    cmd.Connection = connection;
                    int status = cmd.ExecuteNonQuery();
                    connection.Close();
                    editMode = false;
                    MessageBox.Show("Product edited successfully.", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                    refreshProductInfo(index);
                    dgvProducts.ClearSelection();
                    dgvProducts.CurrentCell = dgvProducts.Rows[index].Cells[0];
                    dgvProducts.Rows[index].Selected = true;
                }
            }
        }
        private bool invalidFileName(string filename) // Checks if a filename is valid or not
        {
            string invalidChars = "!@%^*~|#";
            bool invalid = false;
            for(int i = 0; i < invalidChars.Length; i++)
            {
                if (filename.Contains(invalidChars[i]))
                {
                    invalid = true;
                    break;
                }
            }
            return invalid;
        }
        public bool ValidCost(string cost)
        {
            // Checks if the cost entered can be converted to a double, which can then be rounded to 2 decimal places if required.
            if (cost.StartsWith("£"))
            {
                // If the user enters a £ sign in
                cost = cost.Remove(0, 1);
            }
            TypeConverter conv = TypeDescriptor.GetConverter(typeof(double));
            return conv.IsValid(cost);
        }
        private void pbxImage_Paint(object sender, PaintEventArgs e) // Loads image into the picture box
        {
            if (!editMode)
            {
                bool imageError = false;
                try
                {
                    if (currentProduct.filename != null)
                    {
                        try
                        {
                            System.Drawing.Image image = System.Drawing.Image.FromFile("productImages/" + currentProduct.filename);
                            e.Graphics.DrawImage(image, 0, 0, 217, 300);
                        }
                        catch
                        {
                            System.Drawing.Image image = System.Drawing.Image.FromFile("productImages/noImage.png");
                            e.Graphics.DrawImage(image, 0, 0, 217, 300);
                        }
                    }
                    imageError = false;
                }
                catch
                {
                    if (!imageError)
                    {
                        MessageBox.Show("Product image could not be loaded.", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        imageError = true;
                    }
                }
            }
            else
            {
                bool imageError = false;
                try
                {
                    if (currentProduct.filename != null)
                    {
                        try
                        {
                            if(path != null)
                            {
                                System.Drawing.Image image = System.Drawing.Image.FromFile(path.FullName);
                                e.Graphics.DrawImage(image, 0, 0, 217, 300);
                            }
                            else
                            {
                                System.Drawing.Image image = System.Drawing.Image.FromFile("productImages/noImage.png");
                                e.Graphics.DrawImage(image, 0, 0, 217, 300);

                            }
                        }
                        catch
                        {
                            System.Drawing.Image image = System.Drawing.Image.FromFile("productImages/noImage.png");
                            e.Graphics.DrawImage(image, 0, 0, 217, 300);
                        }
                    }
                    imageError = false;
                }
                catch
                {
                    if (!imageError)
                    {
                        MessageBox.Show("Product image could not be loaded.", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        imageError = true;
                    }
                }
            }
        }
        private void btnUpload_Click(object sender, EventArgs e) // Allows the user to upload a new image to replace the current one
        {
            try
            {
                dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = new FileInfo(dialog.FileName);
                    tbxFileName.Text = path.Name;
                    pbxImage.Refresh();
                }
            }
            catch
            {
                MessageBox.Show("Upload error occurred. Please try again.", "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRemove_Click(object sender, EventArgs e) // Removes any image from the product selected
        {
            tbxFileName.Text = "";
            path = null;
            pbxImage.Refresh();
        }
        private void btnReset_Click(object sender, EventArgs e) // Displays the original image of the product selected
        {
            tbxFileName.Text = currentProduct.filename;
            path = new FileInfo(currentProductImagePath);
            pbxImage.Refresh();
        }


    }
}
