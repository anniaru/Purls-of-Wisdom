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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YarnShop
{
    public partial class NewSupplierOrder : Form
    {

        int index;
        double subtotal;
        double total;
        bool addingProduct;
        Supplier currentSupplier = null;
        Product currentProduct = null;
        Product resolveProduct = null;
        string tempProductType;
        List<Supplier> supplierList = new List<Supplier>();
        List<OrderItem> orderList = new List<OrderItem>();
        
        // These lists are used for the filter system.
        List<string> filterList = new List<string>();
        List<string> YarnWeightList = new List<string>();
        List<string> CategoryList = new List<string>();
        List<string> FibreList = new List<string>();
        List<string> MaterialList = new List<string>();
        List<string> ColourList = new List<string>();
        List<string> supplierDelStatus = new List<string>();
        bool filtersApplied; // True if filters have been applied, used in searches
        string currentCommand; // Stores the command used to retrieve the data currently shown in the dgv

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
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        public NewSupplierOrder(Product product)
        {
            InitializeComponent();
            resolveProduct = product;
        }
        private void FormMakeSupplierOrder_Load(object sender, EventArgs e)
        {
              //loading all attributes into lists

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

            refresh();
            cbxDelStatus.Text = "Order Made";
            tbxStatus.Text = "Open";

        }

        // REFRESHING INFORMATION SHOWN
        private void refresh()
        {
            lsbShoppingList.Refresh();
            lsbCostList.Refresh();
            lsbQuantityList.Refresh();

            cbxSuppliers.DataSource = null;
            cbxSuppliers.DisplayMember = null;
            cbxSuppliers.ValueMember = null;

            clearChecked(clsbCategory);
            clearChecked(clsbFibreMaterial);
            clearChecked(clsbColour);
            clearChecked(clsbStock);
            pnlFilters.AutoScroll = false;
            clsbCategory.Visible = false;
            clsbFibreMaterial.Visible = false;
            clsbColour.Visible = false;
            lblCategoryFilter.Visible = false;
            lblFibreMaterialFilter.Visible = false;
            lblColourFilter.Visible = false;

            //loads suppliers into a list
            supplierList.Clear();
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
            conSuppliers.Close();
            cbxSuppliers.DataSource = supplierList;
            cbxSuppliers.DisplayMember = "SupplierInfo";
            cbxSuppliers.ValueMember = "idName";

            if (resolveProduct != null) // When resolving a stock notice, the product that requires stock will be added and the supplier for that product will be selected.
            {
                foreach (Supplier sup in supplierList) // Set current supplier
                {
                    if (sup.id == resolveProduct.supplierID) 
                    {
                        currentSupplier = sup;
                        showSupplierInfo(supplierList.IndexOf(sup));
                    }
                    refreshProductDGV();

                }
                foreach (DataGridViewRow row in dgvProducts.Rows) // Select the product in the dgv
                {
                    if (Convert.ToInt32(row.Cells[0].Value) == resolveProduct.id)
                    {
                        dgvProducts.ClearSelection();
                        dgvProducts.CurrentCell = dgvProducts.Rows[row.Index].Cells[0];
                        dgvProducts[0, row.Index].Selected = true;
                        index = row.Index;
                        refreshProductInfo(0);
                    }
                }
                // Adds the minimum quantity that needs to be added for no stock and low stock products. This can be changed by the user.
                OrderItem orderItem = new OrderItem(resolveProduct, resolveProduct.lowStock, 0,0);
                numQuantity.Value = orderItem.quantityRemaining;
                orderList.Add(orderItem);
                subtotal += orderItem.product.cost * orderItem.product.lowStock;
                updateOrderTotals(subtotal);
                lsbQuantityList.DataSource = null;
                lsbQuantityList.DisplayMember = "QuantityString";
                lsbQuantityList.DataSource = orderList;
                lsbQuantityList.Refresh();
                lsbCostList.DataSource = null;
                lsbCostList.DisplayMember = "CostString";
                lsbCostList.DataSource = orderList;
                lsbCostList.Refresh();
                lsbShoppingList.DataSource = null;
                lsbShoppingList.DisplayMember = "name";
                lsbShoppingList.DataSource = orderList;
                lsbShoppingList.Refresh();
                lsbShoppingList.SelectedIndex = lsbShoppingList.Items.Count - 1;
                lsbQuantityList.SelectedIndex = lsbShoppingList.SelectedIndex;
                lsbCostList.SelectedIndex = lsbShoppingList.SelectedIndex;
            }
            else if (currentSupplier == null)
            {
                currentSupplier = supplierList[0];
                tbxSupplier.Text = currentSupplier.supplierName;
                showSupplierInfo(0);
                index = 0;
            }
            refreshProductDGV();
            refreshProductInfo(0);
            rbtnAll.Checked = true;
        }
        private void tbxSearch_TextChanged(object sender, EventArgs e) // As the user types in the search bar, products are searched for according to the input.
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
                        cmd.CommandText = "SELECT * FROM TableProducts WHERE ProductName LIKE @pn AND Discontinued = False AND SupplierID = @ssid";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@pn", "%" + tbxSearch.Text + "%");
                        cmd.Parameters.AddWithValue("@ssid", currentSupplier.id);
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
                        cmd.CommandText = "SELECT * FROM TableProducts WHERE ProductType = @ya AND ProductName LIKE @pn AND Discontinued = False AND SupplierID = @ssid";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ya", tempProductType);
                        cmd.Parameters.AddWithValue("@pn", "%" + tbxSearch.Text + "%");
                        cmd.Parameters.AddWithValue("@ssid", currentSupplier.id);
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
                        cmd.CommandText = "SELECT * FROM TableProducts WHERE Discontinued = False AND SupplierID = @ssid";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ssid", currentSupplier.id);
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
                        cmd.CommandText = "SELECT * FROM TableProducts WHERE ProductType = @ya AND Discontinued = False AND SupplierID = @ssid";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ya", tempProductType);
                        cmd.Parameters.AddWithValue("@ssid", currentSupplier.id);
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
                        cmd.Parameters.AddWithValue("@ssid", currentSupplier.id);
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
                        cmd.Parameters.AddWithValue("@ssid", currentSupplier.id);
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
                    cmd.Parameters.AddWithValue("@ssid", currentSupplier.id);
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
        private void btnSearch_Click(object sender, EventArgs e)
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
                        cmd.CommandText = "SELECT * FROM TableProducts WHERE ProductName LIKE @pn AND Discontinued = False AND SupplierID = @ssid";
                        MessageBox.Show(cmd.CommandText);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@pn", "%" + tbxSearch.Text + "%");
                        cmd.Parameters.AddWithValue("@ssid", currentSupplier.id);

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
                        cmd.CommandText = "SELECT * FROM TableProducts WHERE ProductType = @ya AND ProductName LIKE @pn AND Discontinued = False AND SupplierID = @ssid";
                        MessageBox.Show(cmd.CommandText);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ya", tempProductType);
                        cmd.Parameters.AddWithValue("@pn", "%" + tbxSearch.Text + "%");
                        cmd.Parameters.AddWithValue("@ssid", currentSupplier.id);
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
                        cmd.CommandText = "SELECT * FROM TableProducts AND Discontinued = False AND SupplierID = @ssid";
                        MessageBox.Show(cmd.CommandText);
                        cmd.Parameters.AddWithValue("@ssid", currentSupplier.id);
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
                        cmd.CommandText = "SELECT * FROM TableProducts WHERE ProductType = @ya AND Discontinued = False AND SupplierID = @ssid";
                        MessageBox.Show(cmd.CommandText);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ya", tempProductType);
                        cmd.Parameters.AddWithValue("@ssid", currentSupplier.id);
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
                        cmd.Parameters.AddWithValue("@ssid", currentSupplier.id);
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
                        cmd.Parameters.AddWithValue("@ssid", currentSupplier.id);
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
                    cmd.Parameters.AddWithValue("@ssid", currentSupplier.id);
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
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            int orderItemsIndex = 0;
            refreshProductInfo(index); 

            if (lsbShoppingList.Items.Count != 0) // Highlights the product selected in the shopping list, if the product is in the shopping list
            {
                OrderItem orderItem = new OrderItem(currentProduct, Convert.ToInt32(numQuantity.Value), 0, 0);
                bool found = false;
                for (int i = 0; i < lsbShoppingList.Items.Count; i++)
                {
                    if (((OrderItem)lsbShoppingList.Items[i]).product.id == orderItem.product.id)
                    {
                        orderItemsIndex = i;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    lsbShoppingList.SelectedItem = null;
                    lsbQuantityList.SelectedItem = null;
                    lsbCostList.SelectedItem = null;
                    numQuantity.Value = 0;
                }
                else
                {
                    numQuantity.Value = Convert.ToInt32(((OrderItem)lsbQuantityList.Items[orderItemsIndex]).quantity);
                    lsbShoppingList.SelectedIndex = orderItemsIndex;
                    lsbQuantityList.SelectedIndex = orderItemsIndex;
                    lsbCostList.SelectedIndex = orderItemsIndex;
                }
            }

        }
        private void refreshProductInfo(int index)
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
            pbxImage.Refresh();
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
        private bool refreshProductDGV()
        {
            //this is a separate subroutine because while making an order, new products may be added, so this subroutine is required to update the
            //  dgv of products each time a new product is added
            //loads up all the data into the dgv
            tbxSearch.Text = "";
            string type = "";
            bool changed = false;
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
                cmd.CommandText = "SELECT * FROM TableProducts WHERE Discontinued = False AND SupplierID = @ssid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ssid", supplierList[cbxSuppliers.SelectedIndex].id);
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                if (reader.HasRows)
                {
                    bindingSource.DataSource = reader;
                    dgvProducts.DataSource = bindingSource;
                    refreshProductInfo(0);
                    changed = true;
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
                cmd.CommandText = "SELECT * FROM TableProducts WHERE ProductType = @ya AND Discontinued = False AND SupplierID = @ssid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ya", type);
                cmd.Parameters.AddWithValue("@ssid", supplierList[cbxSuppliers.SelectedIndex].id);
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                if (reader.HasRows)
                {
                    bindingSource.DataSource = reader;
                    dgvProducts.DataSource = bindingSource;
                    refreshProductInfo(0);
                    changed = true;
                }
                else
                {
                    MessageBox.Show("No results found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rbtnAll.Checked = true;
                    rbtnYarn.Checked = false;
                    rbtnAcc.Checked = false;
                    refresh();
                }
                connection.Close();
            }
            highlightProductsStock();
            return changed;

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
        }
        private void showSupplierInfo(int index)
        {
            tbxSupplierID.Text = supplierList[index].id.ToString();
            tbxSupplierName.Text = supplierList[index].supplierName.ToString();
            tbxEmailAdd.Text = supplierList[index].emailAddress.ToString();
            tbxPhoneNum.Text = supplierList[index].phoneNum.ToString();
            tbxAddress.Text = supplierList[index].address.ToString();
            tbxPostcode.Text = supplierList[index].postcode.ToString();
            tbxURL.Text = supplierList[index].url.ToString();
            int tempSupplierID = Convert.ToInt32(tbxSupplierID.Text);
            foreach (Supplier selectSup in supplierList)
            {
                if (selectSup.id == tempSupplierID)
                {
                    currentSupplier = selectSup;
                }
            }
        }
        // FILTERS
        private void showYarnFields(bool filter)
        {
            if (filter)// If there are other filters in place
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

                clsbCategory.ClearSelected();
                clsbFibreMaterial.ClearSelected();
                clsbColour.ClearSelected();
                clearChecked(clsbCategory);
                clearChecked(clsbFibreMaterial);
                clearChecked(clsbColour);
                clearChecked(clsbStock);

                lblCategoryFilter.Visible = true;
                lblFibreMaterialFilter.Visible = true;
                lblColourFilter.Visible = true;
            }
            lblType.Text = "Ball Weight";
            lblCategory.Text = "Yarn Weight";
            lblFibre.Text = "Fibre";
        }
        private void showAccFields(bool filter)
        {
            if (filter)// If there are other filters in place
            {
                clsbCategory.Visible = true;
                clsbFibreMaterial.Visible = true;
                clsbColour.Visible = true;

                clsbCategory.DataSource = CategoryList;
                clsbFibreMaterial.DataSource = MaterialList;
                clsbColour.DataSource = ColourList;

                lblCategoryFilter.Text = "CATEGORY";
                lblFibreMaterialFilter.Text = "MATERIAL";
                lblCategoryFilter.Visible = true;
                lblFibreMaterialFilter.Visible = true;
                lblColourFilter.Visible = true;

                clearChecked(clsbCategory);
                clearChecked(clsbFibreMaterial);
                clearChecked(clsbColour);
                clearChecked(clsbStock);

                lblCategoryFilter.Visible = true;
                lblFibreMaterialFilter.Visible = true;
                lblColourFilter.Visible = true;
            }

            lblType.Text = "Size";
            lblCategory.Text = "Category";
            lblFibre.Text = "Material";

        }
        private void clearChecked(CheckedListBox clsbToClear)
        {
            for (int i = 0; i < clsbToClear.Items.Count; i++)
            {
                clsbToClear.SetSelected(i, false);
                clsbToClear.SetItemChecked(i, false);
            }
            clsbToClear.ClearSelected();
        }
        private void rbtnYarn_CheckedChanged(object sender, EventArgs e) // Shows all yarn related fields
        {
            if (rbtnYarn.Checked == true)
            {
                showYarnFields(true);
                refreshProductDGV();
                refreshProductInfo(0);
            }
        }
        private void rbtnAcc_CheckedChanged(object sender, EventArgs e) // Shows all accessory related fields
        {
            if (rbtnAcc.Checked == true)
            {
                if (rbtnAcc.Checked == true)
                {
                    showAccFields(true);
                    refreshProductDGV();
                    refreshProductInfo(0);
                }
            }
        }
        private void rbtnAll_Click(object sender, EventArgs e) // Shows general fields for all products and clears filters
        {
            DialogResult result = MessageBox.Show("This will clear all filters. Proceed?", "Clear Filters", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            tbxSearch.Text = "";
            if (result == DialogResult.Yes)
            {
                currentProduct = null;
                refresh();
            }
            else
            {
                MessageBox.Show("Filters not cleared.");
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = connection.CreateCommand();
                OleDbDataReader reader;
                connection.Open();
                cmd.CommandText = "SELECT * FROM TableProducts WHERE ProductType = @ya AND Discontinued = False AND SupplierID = @ssid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ya", tempProductType);
                cmd.Parameters.AddWithValue("@ssid",currentSupplier.id);
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
        private void btnApplyFilters_Click(object sender, EventArgs e)
        {
            filtersApplied = false;
            string baseCommandText = "SELECT * FROM TableProducts WHERE Discontinued = False AND SupplierID = @ssid";
            string categoryFilterCommand = "AND Category IN (";
            string fibreFilterCommand = "AND FibreMaterial IN (";
            string colourFilterCommand = "AND Colour IN (";

            // Need these lists to store the selected items for each checked list box.
            // Since a new list is created each time the user clicks the apply button, the list will be cleared each time.
            // Load all the checked filters into their corresponding lists.
            List<string> selectedCategoryFilters = clsbCategory.CheckedItems.Cast<string>().ToList();
            List<string> selectedFibreFilters = clsbFibreMaterial.CheckedItems.Cast<string>().ToList();
            List<string> selectedColourFilters = clsbColour.CheckedItems.Cast<string>().ToList();
            List<string> selectedStockFilters = clsbStock.CheckedItems.Cast<string>().ToList();

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
                    if (baseCommandText.EndsWith("d"))
                    {
                        baseCommandText += " AND (" + condition;
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
                baseCommandText += " AND Stock >= 0 "; // If no specific stock filters are selected, results will only include products in stock.
            }
            if (!rbtnAll.Checked)
            {
                baseCommandText += " AND ProductType = @ya ";
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
            cmd.Parameters.AddWithValue("@ssid", currentSupplier.id);
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
                refreshProductInfo(0);
            }
            else
            {
                MessageBox.Show("No products found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            connection.Close();
            highlightProductsStock();


        }
        private void btnClearFilters_Click(object sender, EventArgs e) // Clears all filters
        {
            DialogResult result = MessageBox.Show("This will clear all filters. Proceed?", "Clear All Filters", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                clearChecked(clsbCategory);
                clearChecked(clsbFibreMaterial);
                clearChecked(clsbColour);
                clearChecked(clsbStock);

                if (rbtnAll.Checked)
                {
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    cmd.CommandText = "SELECT * FROM TableProducts WHERE Discontinued = False AND SupplierID = @ssid";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ssid", currentSupplier.id);
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
                    cmd.CommandText = "SELECT * FROM TableProducts WHERE ProductType = @ya AND Discontinued = False AND SupplierID = @ssid";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ya", tempProductType);
                    cmd.Parameters.AddWithValue("@ssid", currentSupplier.id);

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

        // SUPPLIER INFORMATION
        private void cbxSuppliers_SelectionChangeCommitted(object sender, EventArgs e) // When the supplier is changed, all order information entered is cleared and a new order must be created
        {
            if (cbxSuppliers.SelectedIndex < 0)
            {
                cbxSuppliers.SelectedIndex = 0;
            }
            if (lsbShoppingList.Items.Count != 0)
            {
                DialogResult result = MessageBox.Show("This will create a new order and delete all information entered prior. Proceed?", "New Supplier Order", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    currentSupplier = supplierList[cbxSuppliers.SelectedIndex];
                    showSupplierInfo(cbxSuppliers.SelectedIndex);
                    orderList.Clear();
                    lsbShoppingList.DataSource = null;
                    lsbShoppingList.Items.Clear();
                    lsbCostList.DataSource = null;
                    lsbCostList.Items.Clear();
                    lsbQuantityList.DataSource = null;
                    lsbQuantityList.Items.Clear();
                    subtotal = 0;
                    updateOrderTotals(subtotal);
                    refreshProductDGV();
                    refreshProductInfo(0);
                }
                else
                {
                    MessageBox.Show("No information has been deleted.", "New Supplier Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                bool changed = refreshProductDGV();
                if (changed) // If there are no products for the supplier that was selected, then the current supplier won't be changed. 
                {
                    showSupplierInfo(cbxSuppliers.SelectedIndex);
                }
                else
                {
                    refreshProductInfo(0);
                    foreach(Supplier s in cbxSuppliers.Items)
                    {
                        if(s.id == currentSupplier.id)
                        {
                            cbxSuppliers.SelectedIndex = cbxSuppliers.Items.IndexOf(s);
                        }
                    }
                    cbxSuppliers.Text = supplierList[cbxSuppliers.SelectedIndex].idName; // Sets the currently selected item in the list to the supplier selected before
                }
            }

        }
        private void updateOrderTotals(double subtotal)
        {
            tbxSubtotal.Text = "£" + Math.Round(subtotal, 2).ToString("0.00");
            total = Math.Round(subtotal, 2);
            tbxTotal.Text = "£" + Math.Round(subtotal, 2).ToString("0.00");

        }

        // ORDER DATE INFORMATION
        private void dtpOrderDate_ValueChanged(object sender, EventArgs e) // Automatically sets the expected delivery date to 3 days following the order date.
        {
            dtpExpDeliveryDate.Value = dtpOrderDate.Value.AddDays(3);
        }

        // ADDING ITEMS TO ORDER AND PLACING ORDER
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            bool productInOrder = false;
            int initialQuantity = Convert.ToInt32(numQuantity.Value);
            int finalIndex = 0; 
            if (orderList.Count == 0) // If there are no products in the order, create an order item, set the quantity to 1 and add it to the order list. Add the cost of one product to the subtotal.
            {
                OrderItem orderItem = new OrderItem(currentProduct, 1, 0, 0);
                numQuantity.Value = 1;
                orderList.Add(orderItem);
                subtotal += orderItem.product.cost;
                updateOrderTotals(subtotal);
                lsbShoppingList.SelectedIndex = lsbShoppingList.Items.Count - 1;
                lsbQuantityList.SelectedIndex = lsbShoppingList.SelectedIndex;
                lsbCostList.SelectedIndex = lsbShoppingList.SelectedIndex;
            }
            else
            {

                if (initialQuantity == 0)
                {
                    initialQuantity = 1;
                }
                else
                {
                    initialQuantity = Convert.ToInt32(numQuantity.Value);
                }
                foreach (OrderItem item in orderList) // Loops through each item in the order to find the product that has been selected by the user.
                {
                    if (item.product.id == currentProduct.id) // If the product selected by the user is already in the order, the order item quantity is increased by 1 and the search for the product selected is broken.
                    {
                        // There is a maximum value set to the numeric up down button.
                        // If incrementing the quantity results in numQuantity storing a value larger than its maximum,
                        // it will notify that there is no stock left for that product and set the item quantity to its maximum.
                        productInOrder = true;
                        initialQuantity++;
                        numQuantity.Value = initialQuantity;

                        item.SetQuantity(initialQuantity);
                        subtotal += item.product.cost;
                        updateOrderTotals(subtotal);
                        int orderItemsIndex = 0;
                        for (int i = 0; i < lsbShoppingList.Items.Count; i++)
                        {
                            if (((OrderItem)lsbShoppingList.Items[i]).product.id == item.product.id)
                            {
                                orderItemsIndex = i;
                                break;
                            }
                        }
                        finalIndex = orderItemsIndex;
                        break;
                    }
                }
                if (!productInOrder) // If the product selected by the user is not in the order
                {
                    OrderItem orderItem = new OrderItem(currentProduct, initialQuantity, 0, 0);
                    numQuantity.Value = initialQuantity;
                    orderList.Add(orderItem);
                    subtotal += orderItem.product.cost * Convert.ToDouble(initialQuantity);
                    updateOrderTotals(subtotal);
                    addingProduct = true;
                    lsbQuantityList.DataSource = null;
                    lsbQuantityList.DisplayMember = "QuantityString";
                    lsbQuantityList.DataSource = orderList;
                    lsbQuantityList.Refresh();
                    lsbCostList.DataSource = null;
                    lsbCostList.DisplayMember = "CostString";
                    lsbCostList.DataSource = orderList;
                    lsbCostList.Refresh();
                    lsbShoppingList.DataSource = null;
                    lsbShoppingList.DisplayMember = "name";
                    lsbShoppingList.DataSource = orderList;
                    lsbShoppingList.Refresh();
                    finalIndex = lsbShoppingList.Items.Count - 1;
                }
            }
            
            lsbQuantityList.DataSource = null;
            lsbQuantityList.DisplayMember = "QuantityString";
            lsbQuantityList.DataSource = orderList;
            lsbQuantityList.Refresh();
            lsbCostList.DataSource = null;
            lsbCostList.DisplayMember = "CostString";
            lsbCostList.DataSource = orderList;
            lsbCostList.Refresh();
            lsbShoppingList.DataSource = null;
            lsbShoppingList.DisplayMember = "name";
            lsbShoppingList.DataSource = orderList;
            lsbShoppingList.Refresh();
            lsbShoppingList.SelectedIndex = finalIndex;
            lsbQuantityList.SelectedIndex = lsbShoppingList.SelectedIndex;
            lsbCostList.SelectedIndex = lsbShoppingList.SelectedIndex;
            updateOrderTotals(subtotal);
        }
        private void btnApply_Click(object sender, EventArgs e) // Applies the quantity of the product that the user has set
        {
            int index = lsbShoppingList.SelectedIndex;
            if (index > -1 && lsbShoppingList.Items.Count > 0)
            {                
                // Adjusts the total of the order accordingly
                int originalQuantity = ((OrderItem)lsbShoppingList.Items[lsbShoppingList.SelectedIndex]).quantity;
                if (numQuantity.Value == 0)
                {
                    DialogResult result = MessageBox.Show("Remove product?", "Remove Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        index = 0;
                        subtotal += -originalQuantity * ((OrderItem)lsbShoppingList.Items[lsbShoppingList.SelectedIndex]).product.cost;
                        orderList.Remove((OrderItem)lsbShoppingList.Items[lsbShoppingList.SelectedIndex]);
                        numQuantity.Enabled = false;
                    }
                }
                else
                {
                    if (lsbShoppingList.SelectedItem != null)
                    {
                        subtotal += ((float)numQuantity.Value - originalQuantity) * ((OrderItem)lsbShoppingList.Items[lsbShoppingList.SelectedIndex]).product.cost;
                        orderList[lsbShoppingList.SelectedIndex].SetQuantity(Convert.ToInt32(numQuantity.Value));

                    }
                }
                lsbQuantityList.DataSource = null;
                lsbQuantityList.DisplayMember = "QuantityString";
                lsbQuantityList.DataSource = orderList;
                lsbQuantityList.Refresh();
                lsbCostList.DataSource = null;
                lsbCostList.DisplayMember = "CostString";
                lsbCostList.DataSource = orderList;
                lsbCostList.Refresh();
                lsbShoppingList.DataSource = null;
                lsbShoppingList.DisplayMember = "name";
                lsbShoppingList.DataSource = orderList;
                lsbShoppingList.Refresh();
                if (lsbShoppingList.Items.Count > 0)
                {
                    lsbShoppingList.SelectedIndex = index;
                    lsbQuantityList.SelectedIndex = lsbShoppingList.SelectedIndex;
                    lsbCostList.SelectedIndex = lsbShoppingList.SelectedIndex;
                    numQuantity.Enabled = false;
                }
                updateOrderTotals(subtotal);
            }
        }
        private void btnNewProduct_Click(object sender, EventArgs e) // Allows the user to create a new product for the current supplier selected
        {
            NewProduct formNewProduct = new NewProduct(false, currentSupplier.id);
            formNewProduct.ShowDialog();
            refreshProductDGV();
        }
        public bool ValidCost(string cost)
        {
            // Checks if the cost entered can be converted to a double, which can then be rounded to 2 decimal places if required.
            TypeConverter conv = TypeDescriptor.GetConverter(typeof(double));
            return conv.IsValid(cost);
        }
        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            //These conditions will mainly come in place when the user changes the expected delivery date themselves, and the date is invalid.

            if (lsbShoppingList.Items.Count == 0)
            {
                MessageBox.Show("There are no products added to the order.", "No Products", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if (dtpExpDeliveryDate.Value < dtpOrderDate.Value)
            {
                MessageBox.Show("You cannot enter an expected delivery date that falls before the order date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpExpDeliveryDate.Value = dtpOrderDate.Value.AddDays(3);
            }
            else if (string.IsNullOrWhiteSpace(tbxTotal.Text) || string.IsNullOrWhiteSpace(cbxDelStatus.Text))
            {
                MessageBox.Show("Enter values in all required fields.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!ValidCost(tbxTotal.Text))
            {
                MessageBox.Show("Enter a valid total.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (rtbxOrderNotes.Text == "")
                {
                    rtbxOrderNotes.Text = " ";
                }
                List<Product> savedProducts = new List<Product>(); // this is to keep track of which products have been saved in the shopping list

                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                OleDbCommand cmd = connection.CreateCommand();
                connection.Open();
                cmd.CommandText = "INSERT INTO TableSupplierOrders(SupplierID, OrderDate, DeliveryDate, DeliveryStatus, Subtotal, Total, OrderNotes) VALUES(@sid,@ord,@exd,@dsa,@sub,@tot,@orn)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@sid", currentSupplier.id);
                cmd.Parameters.AddWithValue("@ord", dtpOrderDate.Value.ToString("dd/MM/yyyy"));
                cmd.Parameters.AddWithValue("@exd", dtpExpDeliveryDate.Value.ToString("dd/MM/yyyy"));
                cmd.Parameters.AddWithValue("@dsa", cbxDelStatus.Text);
                cmd.Parameters.AddWithValue("@tot", Math.Round(subtotal, 2));
                cmd.Parameters.AddWithValue("@cos", Math.Round(total, 2));
                cmd.Parameters.AddWithValue("@orn", rtbxOrderNotes.Text);
                cmd.Connection = connection;
                int status = cmd.ExecuteNonQuery();


                cmd.CommandText = "SELECT SupplierOrderID FROM TableSupplierOrders ORDER BY SupplierOrderID DESC";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@sid", currentSupplier.id);
                cmd.Parameters.AddWithValue("@od", dtpOrderDate.Value);
                cmd.Parameters.AddWithValue("@dd", dtpExpDeliveryDate.Value);
                int tempOrderID = Convert.ToInt32(cmd.ExecuteScalar());

                List<int> savedProductsID = new List<int>(); // this is to keep track of which products have been saved in the shopping list
                foreach (OrderItem shoppingListItem in orderList)
                {
                    if (savedProductsID.Contains(shoppingListItem.product.id)) // if the product has not already been searched for and recorded
                    {
                        continue;
                    }
                    else
                    {
                        MessageBox.Show(shoppingListItem.product.productInfo, Convert.ToString(shoppingListItem.quantity));
                        savedProductsID.Add(shoppingListItem.product.id);
                        cmd.CommandText = "INSERT INTO TableSupplierOrderItems(ProductID,OrderID,Quantity) VALUES(@pid,@oid,@q)";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@pid", ((OrderItem)shoppingListItem).product.id);
                        cmd.Parameters.AddWithValue("@oid", tempOrderID);
                        cmd.Parameters.AddWithValue("@q", shoppingListItem.quantity);
                        int status2 = cmd.ExecuteNonQuery();

                        if(cbxDelStatus.Text == "Delivered") // If the order has already been delivered, then stock can be updated.
                        {
                            cmd.CommandText = "UPDATE TableProducts SET Stock = Stock + @q WHERE ProductID = @pid";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@q", shoppingListItem.quantity);
                            cmd.Parameters.AddWithValue("@pid", ((OrderItem)shoppingListItem).product.id);
                            int statusStock = cmd.ExecuteNonQuery();
                        }
                    }
                }
                connection.Close();
                MessageBox.Show("Order placed successfully.", "Order Placed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderItem orderItem = (OrderItem)lsbShoppingList.SelectedItem;
            if (orderItem != null)
            {
                // removes the product and adjusts the total shown
                orderList.Remove(orderItem);
                lsbShoppingList.DataSource = null;
                lsbShoppingList.DisplayMember = "name";
                lsbShoppingList.DataSource = orderList;
                lsbShoppingList.Refresh();
                lsbQuantityList.DataSource = null;
                lsbQuantityList.DisplayMember = "QuantityString";
                lsbQuantityList.DataSource = orderList;
                lsbQuantityList.Refresh();
                lsbCostList.DataSource = null;
                lsbCostList.DisplayMember = "CostString";
                lsbCostList.DataSource = orderList;
                lsbCostList.Refresh();
                subtotal -= orderItem.product.cost * orderItem.quantity;
                updateOrderTotals(subtotal);
                numQuantity.Value = 0;

            }
        }
        private void lsbShoppingList_SelectedIndexChanged(object sender, EventArgs e)
        {            
            // When the user clicks on another item in the list, the item is highlighted in the dgv and all information for that product is shown
            if (lsbShoppingList.Items.Count > 0)
            {
                btnApply.Visible = true;
                numQuantity.Enabled = true;
                bool productInDGV = false;
                lsbQuantityList.SelectedIndex = lsbShoppingList.SelectedIndex;
                lsbCostList.SelectedIndex = lsbShoppingList.SelectedIndex;
                if (lsbShoppingList.SelectedItem != null)
                {
                    foreach (DataGridViewRow row in dgvProducts.Rows)
                    {
                        if (addingProduct)
                        {
                            if (row.Cells[0].Value.ToString() == tbxProductID.Text)
                            {
                                dgvProducts.ClearSelection();
                                dgvProducts.CurrentCell = dgvProducts.Rows[row.Index].Cells[0];
                                dgvProducts[0, row.Index].Selected = true;
                                productInDGV = true;
                            }
                        }
                        else
                        {
                            if (row.Cells[0].Value.ToString() == ((OrderItem)lsbShoppingList.SelectedItem).product.id.ToString())
                            {
                                dgvProducts.ClearSelection();
                                dgvProducts.CurrentCell = dgvProducts.Rows[row.Index].Cells[0];
                                dgvProducts[0, row.Index].Selected = true;
                                productInDGV = true;
                            }
                        }
                    }
                    if (!productInDGV)
                    {
                        if (rbtnYarn.Checked)
                        {
                            rbtnAcc.Checked = true;
                            foreach (DataGridViewRow row in dgvProducts.Rows)
                            {
                                if (row.Cells[0].Value.ToString() == ((OrderItem)lsbShoppingList.SelectedItem).product.id.ToString())
                                {
                                    dgvProducts.ClearSelection();
                                    dgvProducts.CurrentCell = dgvProducts.Rows[row.Index].Cells[0];
                                    dgvProducts[0, row.Index].Selected = true;
                                }
                            }
                        }
                        else if (rbtnAcc.Checked)
                        {
                            rbtnYarn.Checked = true;
                            foreach (DataGridViewRow row in dgvProducts.Rows)
                            {
                                if (row.Cells[0].Value.ToString() == ((OrderItem)lsbShoppingList.SelectedItem).product.id.ToString())
                                {
                                    dgvProducts.ClearSelection();
                                    dgvProducts.CurrentCell = dgvProducts.Rows[row.Index].Cells[0];
                                    dgvProducts[0, row.Index].Selected = true;
                                }
                            }
                        }
                    }
                    numQuantity.Value = Convert.ToInt32(((OrderItem)lsbQuantityList.Items[((int)lsbShoppingList.SelectedIndex)]).quantity);
                    refreshProductInfo(dgvProducts.CurrentRow.Index);
                    addingProduct = false;
                }
            }
            else
            {
                btnApply.Visible = false;
                numQuantity.Enabled = false;
            }
        }
        private void cbxDelStatus_SelectionChangeCommitted(object sender, EventArgs e) // Automatically sets the order status according to the delivery status
        {
            if (cbxDelStatus.SelectedItem.ToString() == "Delivered")
            {
                tbxStatus.Text = "Archived";
            }
            else
            {
                tbxStatus.Text = "Open";
            }
        }
        private void pbxImage_Paint(object sender, PaintEventArgs e) // Paints the image of the product currently shown
        {
            bool imageError = false;
            try
            {
                if (currentProduct.filename != null)
                {
                    try
                    {
                        Image image = Image.FromFile("productImages/" + currentProduct.filename);
                        e.Graphics.DrawImage(image, 0, 0, 217, 300);
                    }
                    catch
                    {
                        Image image = Image.FromFile("productImages/noImage.png");
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
        private void rtbxOrderNotes_TextChanged(object sender, EventArgs e)
        {
            // Implements character length limit on order notes. It will show the user when the order notes' text length is reaching the limit of 255.
            if (rtbxOrderNotes.TextLength > 244)
            {
                lblCharLimit.Visible = true;
                lblCharLimit.Text = rtbxOrderNotes.TextLength + "/255";
            }
            else
            {
                lblCharLimit.Visible = false;
            }
        }

    }
}
