namespace YarnShop
{
    partial class Products
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Products));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlProductInfo = new System.Windows.Forms.Panel();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.lblFullStock = new System.Windows.Forms.Label();
            this.lblLowStock = new System.Windows.Forms.Label();
            this.numFullStock = new System.Windows.Forms.NumericUpDown();
            this.numLowStock = new System.Windows.Forms.NumericUpDown();
            this.lblStockLevel = new System.Windows.Forms.Label();
            this.lblColour = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.tbxProductID = new System.Windows.Forms.TextBox();
            this.tbxCost = new System.Windows.Forms.TextBox();
            this.tbxSupplier = new System.Windows.Forms.TextBox();
            this.tbxStock = new System.Windows.Forms.TextBox();
            this.tbxProductName = new System.Windows.Forms.TextBox();
            this.lblFibre = new System.Windows.Forms.Label();
            this.lblProductID = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.cbxColour = new System.Windows.Forms.ComboBox();
            this.cbxFibre = new System.Windows.Forms.ComboBox();
            this.tbxColour = new System.Windows.Forms.TextBox();
            this.tbxType = new System.Windows.Forms.TextBox();
            this.tbxFibre = new System.Windows.Forms.TextBox();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.tbxCategory = new System.Windows.Forms.TextBox();
            this.cbxSuppliers = new System.Windows.Forms.ComboBox();
            this.ProductInfo = new System.Windows.Forms.Label();
            this.pbxImage = new System.Windows.Forms.PictureBox();
            this.lblProductImg = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discontinueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.lblProductInfo = new System.Windows.Forms.Label();
            this.pbxBar = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSuppliers = new System.Windows.Forms.Label();
            this.lblProductType = new System.Windows.Forms.Label();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.clsbSuppliers = new System.Windows.Forms.CheckedListBox();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.lblFibreMaterialFilter = new System.Windows.Forms.Label();
            this.lblColourFilter = new System.Windows.Forms.Label();
            this.lblCategoryFilter = new System.Windows.Forms.Label();
            this.rbtnYarn = new System.Windows.Forms.RadioButton();
            this.rbtnAcc = new System.Windows.Forms.RadioButton();
            this.clsbCategory = new System.Windows.Forms.CheckedListBox();
            this.clsbFibreMaterial = new System.Windows.Forms.CheckedListBox();
            this.clsbColour = new System.Windows.Forms.CheckedListBox();
            this.pbxFilterBar = new System.Windows.Forms.PictureBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.btnAddSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.chbxDiscontinuedFilter = new System.Windows.Forms.CheckBox();
            this.clsbStock = new System.Windows.Forms.CheckedListBox();
            this.lblStockFilter = new System.Windows.Forms.Label();
            this.lblDiscontinued = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.tbxFileName = new System.Windows.Forms.TextBox();
            this.lblSaveAs = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.pbxHideFilter = new System.Windows.Forms.PictureBox();
            this.pnlProductInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFullStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFilterBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHideFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlProductInfo
            // 
            this.pnlProductInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProductInfo.Controls.Add(this.numStock);
            this.pnlProductInfo.Controls.Add(this.lblFullStock);
            this.pnlProductInfo.Controls.Add(this.lblLowStock);
            this.pnlProductInfo.Controls.Add(this.numFullStock);
            this.pnlProductInfo.Controls.Add(this.numLowStock);
            this.pnlProductInfo.Controls.Add(this.lblStockLevel);
            this.pnlProductInfo.Controls.Add(this.lblColour);
            this.pnlProductInfo.Controls.Add(this.lblSupplier);
            this.pnlProductInfo.Controls.Add(this.lblType);
            this.pnlProductInfo.Controls.Add(this.tbxProductID);
            this.pnlProductInfo.Controls.Add(this.tbxCost);
            this.pnlProductInfo.Controls.Add(this.tbxSupplier);
            this.pnlProductInfo.Controls.Add(this.tbxStock);
            this.pnlProductInfo.Controls.Add(this.tbxProductName);
            this.pnlProductInfo.Controls.Add(this.lblFibre);
            this.pnlProductInfo.Controls.Add(this.lblProductID);
            this.pnlProductInfo.Controls.Add(this.lblCategory);
            this.pnlProductInfo.Controls.Add(this.lblCost);
            this.pnlProductInfo.Controls.Add(this.lblStock);
            this.pnlProductInfo.Controls.Add(this.lblProductName);
            this.pnlProductInfo.Controls.Add(this.cbxColour);
            this.pnlProductInfo.Controls.Add(this.cbxFibre);
            this.pnlProductInfo.Controls.Add(this.tbxColour);
            this.pnlProductInfo.Controls.Add(this.tbxType);
            this.pnlProductInfo.Controls.Add(this.tbxFibre);
            this.pnlProductInfo.Controls.Add(this.cbxCategory);
            this.pnlProductInfo.Controls.Add(this.tbxCategory);
            this.pnlProductInfo.Controls.Add(this.cbxSuppliers);
            this.pnlProductInfo.Location = new System.Drawing.Point(879, 153);
            this.pnlProductInfo.Margin = new System.Windows.Forms.Padding(4);
            this.pnlProductInfo.Name = "pnlProductInfo";
            this.pnlProductInfo.Size = new System.Drawing.Size(424, 300);
            this.pnlProductInfo.TabIndex = 40;
            // 
            // numStock
            // 
            this.numStock.Location = new System.Drawing.Point(12, 197);
            this.numStock.Name = "numStock";
            this.numStock.Size = new System.Drawing.Size(40, 25);
            this.numStock.TabIndex = 254;
            // 
            // lblFullStock
            // 
            this.lblFullStock.AutoSize = true;
            this.lblFullStock.Location = new System.Drawing.Point(322, 9);
            this.lblFullStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFullStock.Name = "lblFullStock";
            this.lblFullStock.Size = new System.Drawing.Size(61, 17);
            this.lblFullStock.TabIndex = 252;
            this.lblFullStock.Text = "Full Stock";
            // 
            // lblLowStock
            // 
            this.lblLowStock.AutoSize = true;
            this.lblLowStock.Location = new System.Drawing.Point(233, 9);
            this.lblLowStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Size = new System.Drawing.Size(66, 17);
            this.lblLowStock.TabIndex = 253;
            this.lblLowStock.Text = "Low Stock";
            // 
            // numFullStock
            // 
            this.numFullStock.Location = new System.Drawing.Point(325, 33);
            this.numFullStock.Name = "numFullStock";
            this.numFullStock.Size = new System.Drawing.Size(40, 25);
            this.numFullStock.TabIndex = 253;
            this.numFullStock.ValueChanged += new System.EventHandler(this.numFullStock_ValueChanged);
            // 
            // numLowStock
            // 
            this.numLowStock.Location = new System.Drawing.Point(237, 33);
            this.numLowStock.Name = "numLowStock";
            this.numLowStock.Size = new System.Drawing.Size(40, 25);
            this.numLowStock.TabIndex = 252;
            this.numLowStock.ValueChanged += new System.EventHandler(this.numLowStock_ValueChanged);
            // 
            // lblStockLevel
            // 
            this.lblStockLevel.AutoSize = true;
            this.lblStockLevel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblStockLevel.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockLevel.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStockLevel.Location = new System.Drawing.Point(84, 6);
            this.lblStockLevel.Name = "lblStockLevel";
            this.lblStockLevel.Size = new System.Drawing.Size(104, 21);
            this.lblStockLevel.TabIndex = 246;
            this.lblStockLevel.Text = "Out Of Stock";
            // 
            // lblColour
            // 
            this.lblColour.AutoSize = true;
            this.lblColour.Location = new System.Drawing.Point(233, 180);
            this.lblColour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColour.Name = "lblColour";
            this.lblColour.Size = new System.Drawing.Size(47, 17);
            this.lblColour.TabIndex = 45;
            this.lblColour.Text = "Colour";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(8, 239);
            this.lblSupplier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(56, 17);
            this.lblSupplier.TabIndex = 25;
            this.lblSupplier.Text = "Supplier";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(233, 68);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(35, 17);
            this.lblType.TabIndex = 23;
            this.lblType.Text = "Type";
            // 
            // tbxProductID
            // 
            this.tbxProductID.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxProductID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxProductID.Location = new System.Drawing.Point(12, 29);
            this.tbxProductID.Margin = new System.Windows.Forms.Padding(4);
            this.tbxProductID.Name = "tbxProductID";
            this.tbxProductID.ReadOnly = true;
            this.tbxProductID.Size = new System.Drawing.Size(218, 18);
            this.tbxProductID.TabIndex = 18;
            // 
            // tbxCost
            // 
            this.tbxCost.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxCost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxCost.Location = new System.Drawing.Point(10, 141);
            this.tbxCost.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCost.Name = "tbxCost";
            this.tbxCost.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbxCost.Size = new System.Drawing.Size(218, 18);
            this.tbxCost.TabIndex = 21;
            // 
            // tbxSupplier
            // 
            this.tbxSupplier.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxSupplier.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxSupplier.Location = new System.Drawing.Point(12, 259);
            this.tbxSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSupplier.Name = "tbxSupplier";
            this.tbxSupplier.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbxSupplier.Size = new System.Drawing.Size(168, 18);
            this.tbxSupplier.TabIndex = 24;
            // 
            // tbxStock
            // 
            this.tbxStock.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxStock.Location = new System.Drawing.Point(12, 196);
            this.tbxStock.Margin = new System.Windows.Forms.Padding(4);
            this.tbxStock.Name = "tbxStock";
            this.tbxStock.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbxStock.Size = new System.Drawing.Size(65, 18);
            this.tbxStock.TabIndex = 22;
            // 
            // tbxProductName
            // 
            this.tbxProductName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxProductName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxProductName.Location = new System.Drawing.Point(12, 84);
            this.tbxProductName.Margin = new System.Windows.Forms.Padding(4);
            this.tbxProductName.Multiline = true;
            this.tbxProductName.Name = "tbxProductName";
            this.tbxProductName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbxProductName.Size = new System.Drawing.Size(213, 34);
            this.tbxProductName.TabIndex = 19;
            // 
            // lblFibre
            // 
            this.lblFibre.AutoSize = true;
            this.lblFibre.Location = new System.Drawing.Point(233, 239);
            this.lblFibre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFibre.Name = "lblFibre";
            this.lblFibre.Size = new System.Drawing.Size(37, 17);
            this.lblFibre.TabIndex = 10;
            this.lblFibre.Text = "Fibre";
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Location = new System.Drawing.Point(8, 9);
            this.lblProductID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(69, 17);
            this.lblProductID.TabIndex = 9;
            this.lblProductID.Text = "Product ID";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(233, 122);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(61, 17);
            this.lblCategory.TabIndex = 11;
            this.lblCategory.Text = "Category";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(7, 122);
            this.lblCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(34, 17);
            this.lblCost.TabIndex = 8;
            this.lblCost.Text = "Cost";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(8, 179);
            this.lblStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(39, 17);
            this.lblStock.TabIndex = 7;
            this.lblStock.Text = "Stock";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(7, 67);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(92, 17);
            this.lblProductName.TabIndex = 6;
            this.lblProductName.Text = "Product Name";
            // 
            // cbxColour
            // 
            this.cbxColour.BackColor = System.Drawing.SystemColors.Window;
            this.cbxColour.FormattingEnabled = true;
            this.cbxColour.Items.AddRange(new object[] {
            "Red",
            "Orange",
            "Yellow",
            "Green",
            "Blue",
            "Purple",
            "Pink",
            "Cream",
            "Gold",
            "Silver",
            "Bronze",
            "Brown",
            "White",
            "Black",
            "Mixed"});
            this.cbxColour.Location = new System.Drawing.Point(236, 197);
            this.cbxColour.Margin = new System.Windows.Forms.Padding(4);
            this.cbxColour.Name = "cbxColour";
            this.cbxColour.Size = new System.Drawing.Size(167, 25);
            this.cbxColour.TabIndex = 43;
            // 
            // cbxFibre
            // 
            this.cbxFibre.BackColor = System.Drawing.SystemColors.Window;
            this.cbxFibre.FormattingEnabled = true;
            this.cbxFibre.Location = new System.Drawing.Point(236, 259);
            this.cbxFibre.Margin = new System.Windows.Forms.Padding(4);
            this.cbxFibre.Name = "cbxFibre";
            this.cbxFibre.Size = new System.Drawing.Size(167, 25);
            this.cbxFibre.TabIndex = 33;
            // 
            // tbxColour
            // 
            this.tbxColour.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxColour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxColour.Location = new System.Drawing.Point(236, 197);
            this.tbxColour.Margin = new System.Windows.Forms.Padding(4);
            this.tbxColour.Name = "tbxColour";
            this.tbxColour.Size = new System.Drawing.Size(168, 18);
            this.tbxColour.TabIndex = 63;
            // 
            // tbxType
            // 
            this.tbxType.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxType.Location = new System.Drawing.Point(236, 85);
            this.tbxType.Margin = new System.Windows.Forms.Padding(4);
            this.tbxType.Name = "tbxType";
            this.tbxType.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbxType.Size = new System.Drawing.Size(168, 18);
            this.tbxType.TabIndex = 20;
            // 
            // tbxFibre
            // 
            this.tbxFibre.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxFibre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxFibre.Location = new System.Drawing.Point(236, 259);
            this.tbxFibre.Margin = new System.Windows.Forms.Padding(4);
            this.tbxFibre.Name = "tbxFibre";
            this.tbxFibre.Size = new System.Drawing.Size(168, 18);
            this.tbxFibre.TabIndex = 23;
            // 
            // cbxCategory
            // 
            this.cbxCategory.BackColor = System.Drawing.SystemColors.Window;
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(236, 139);
            this.cbxCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(167, 25);
            this.cbxCategory.TabIndex = 43;
            // 
            // tbxCategory
            // 
            this.tbxCategory.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxCategory.Location = new System.Drawing.Point(236, 143);
            this.tbxCategory.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCategory.Name = "tbxCategory";
            this.tbxCategory.Size = new System.Drawing.Size(168, 18);
            this.tbxCategory.TabIndex = 25;
            // 
            // cbxSuppliers
            // 
            this.cbxSuppliers.BackColor = System.Drawing.SystemColors.Window;
            this.cbxSuppliers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSuppliers.FormattingEnabled = true;
            this.cbxSuppliers.Location = new System.Drawing.Point(12, 259);
            this.cbxSuppliers.Margin = new System.Windows.Forms.Padding(4);
            this.cbxSuppliers.Name = "cbxSuppliers";
            this.cbxSuppliers.Size = new System.Drawing.Size(167, 25);
            this.cbxSuppliers.TabIndex = 81;
            // 
            // ProductInfo
            // 
            this.ProductInfo.AutoSize = true;
            this.ProductInfo.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.ProductInfo.Location = new System.Drawing.Point(873, 119);
            this.ProductInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ProductInfo.Name = "ProductInfo";
            this.ProductInfo.Size = new System.Drawing.Size(138, 30);
            this.ProductInfo.TabIndex = 33;
            this.ProductInfo.Text = "Product Info:";
            // 
            // pbxImage
            // 
            this.pbxImage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pbxImage.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbxImage.ErrorImage")));
            this.pbxImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbxImage.InitialImage")));
            this.pbxImage.Location = new System.Drawing.Point(651, 153);
            this.pbxImage.Margin = new System.Windows.Forms.Padding(4);
            this.pbxImage.Name = "pbxImage";
            this.pbxImage.Size = new System.Drawing.Size(217, 300);
            this.pbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImage.TabIndex = 44;
            this.pbxImage.TabStop = false;
            this.pbxImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxImage_Paint);
            // 
            // lblProductImg
            // 
            this.lblProductImg.AutoSize = true;
            this.lblProductImg.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductImg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblProductImg.Location = new System.Drawing.Point(646, 122);
            this.lblProductImg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductImg.Name = "lblProductImg";
            this.lblProductImg.Size = new System.Drawing.Size(160, 30);
            this.lblProductImg.TabIndex = 45;
            this.lblProductImg.Text = "Product Image:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.contextMenuStrip1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.discontinueToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // discontinueToolStripMenuItem
            // 
            this.discontinueToolStripMenuItem.Name = "discontinueToolStripMenuItem";
            this.discontinueToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.discontinueToolStripMenuItem.Text = "Discontinue";
            this.discontinueToolStripMenuItem.Click += new System.EventHandler(this.discontinueToolStripMenuItem_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 18);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(49, 17);
            this.radioButton1.TabIndex = 60;
            this.radioButton1.Text = "Yarn";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 46);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(91, 17);
            this.radioButton2.TabIndex = 61;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Accessories";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1255, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 48);
            this.btnClose.TabIndex = 222;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblProductInfo
            // 
            this.lblProductInfo.AutoSize = true;
            this.lblProductInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblProductInfo.Font = new System.Drawing.Font("Yu Gothic UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductInfo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblProductInfo.Location = new System.Drawing.Point(13, 9);
            this.lblProductInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductInfo.Name = "lblProductInfo";
            this.lblProductInfo.Size = new System.Drawing.Size(198, 47);
            this.lblProductInfo.TabIndex = 221;
            this.lblProductInfo.Text = "PRODUCTS";
            // 
            // pbxBar
            // 
            this.pbxBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.pbxBar.Location = new System.Drawing.Point(0, 0);
            this.pbxBar.Margin = new System.Windows.Forms.Padding(4);
            this.pbxBar.Name = "pbxBar";
            this.pbxBar.Size = new System.Drawing.Size(1446, 65);
            this.pbxBar.TabIndex = 220;
            this.pbxBar.TabStop = false;
            this.pbxBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxBar_MouseDown);
            this.pbxBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbxBar_MouseMove);
            this.pbxBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxBar_MouseUp);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(24, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 33);
            this.label2.TabIndex = 239;
            this.label2.Text = "FILTER:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSuppliers
            // 
            this.lblSuppliers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.lblSuppliers.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuppliers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSuppliers.Location = new System.Drawing.Point(0, 206);
            this.lblSuppliers.Name = "lblSuppliers";
            this.lblSuppliers.Size = new System.Drawing.Size(170, 25);
            this.lblSuppliers.TabIndex = 238;
            this.lblSuppliers.Text = "SUPPLIER";
            this.lblSuppliers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProductType
            // 
            this.lblProductType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.lblProductType.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductType.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblProductType.Location = new System.Drawing.Point(0, 0);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(170, 25);
            this.lblProductType.TabIndex = 237;
            this.lblProductType.Text = "TYPE";
            this.lblProductType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbtnAll
            // 
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.rbtnAll.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAll.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbtnAll.Location = new System.Drawing.Point(1, 27);
            this.rbtnAll.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(45, 24);
            this.rbtnAll.TabIndex = 236;
            this.rbtnAll.Text = "All";
            this.rbtnAll.UseVisualStyleBackColor = false;
            this.rbtnAll.Click += new System.EventHandler(this.rbtnAll_Click);
            // 
            // clsbSuppliers
            // 
            this.clsbSuppliers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.clsbSuppliers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clsbSuppliers.CheckOnClick = true;
            this.clsbSuppliers.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsbSuppliers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clsbSuppliers.FormattingEnabled = true;
            this.clsbSuppliers.HorizontalScrollbar = true;
            this.clsbSuppliers.Location = new System.Drawing.Point(0, 227);
            this.clsbSuppliers.Name = "clsbSuppliers";
            this.clsbSuppliers.Size = new System.Drawing.Size(170, 132);
            this.clsbSuppliers.TabIndex = 235;
            // 
            // btnApplyFilters
            // 
            this.btnApplyFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnApplyFilters.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApplyFilters.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnApplyFilters.FlatAppearance.BorderSize = 0;
            this.btnApplyFilters.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnApplyFilters.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnApplyFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyFilters.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyFilters.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnApplyFilters.Location = new System.Drawing.Point(0, 468);
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.Size = new System.Drawing.Size(200, 37);
            this.btnApplyFilters.TabIndex = 234;
            this.btnApplyFilters.Text = "APPLY";
            this.btnApplyFilters.UseVisualStyleBackColor = false;
            this.btnApplyFilters.Click += new System.EventHandler(this.btnApplyFilters_Click);
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnClearFilters.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearFilters.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnClearFilters.FlatAppearance.BorderSize = 0;
            this.btnClearFilters.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnClearFilters.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilters.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFilters.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClearFilters.Location = new System.Drawing.Point(0, 508);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(200, 35);
            this.btnClearFilters.TabIndex = 233;
            this.btnClearFilters.Text = "CLEAR";
            this.btnClearFilters.UseVisualStyleBackColor = false;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // lblFibreMaterialFilter
            // 
            this.lblFibreMaterialFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.lblFibreMaterialFilter.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFibreMaterialFilter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblFibreMaterialFilter.Location = new System.Drawing.Point(0, 492);
            this.lblFibreMaterialFilter.Name = "lblFibreMaterialFilter";
            this.lblFibreMaterialFilter.Size = new System.Drawing.Size(170, 25);
            this.lblFibreMaterialFilter.TabIndex = 232;
            this.lblFibreMaterialFilter.Text = "FIBRE";
            this.lblFibreMaterialFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFibreMaterialFilter.Visible = false;
            // 
            // lblColourFilter
            // 
            this.lblColourFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.lblColourFilter.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColourFilter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblColourFilter.Location = new System.Drawing.Point(0, 627);
            this.lblColourFilter.Name = "lblColourFilter";
            this.lblColourFilter.Size = new System.Drawing.Size(170, 25);
            this.lblColourFilter.TabIndex = 231;
            this.lblColourFilter.Text = "COLOUR";
            this.lblColourFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblColourFilter.Visible = false;
            // 
            // lblCategoryFilter
            // 
            this.lblCategoryFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.lblCategoryFilter.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryFilter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCategoryFilter.Location = new System.Drawing.Point(0, 360);
            this.lblCategoryFilter.Name = "lblCategoryFilter";
            this.lblCategoryFilter.Size = new System.Drawing.Size(170, 25);
            this.lblCategoryFilter.TabIndex = 230;
            this.lblCategoryFilter.Text = "CATEGORY";
            this.lblCategoryFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCategoryFilter.Visible = false;
            // 
            // rbtnYarn
            // 
            this.rbtnYarn.AutoSize = true;
            this.rbtnYarn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.rbtnYarn.Checked = true;
            this.rbtnYarn.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnYarn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbtnYarn.Location = new System.Drawing.Point(1, 50);
            this.rbtnYarn.Name = "rbtnYarn";
            this.rbtnYarn.Size = new System.Drawing.Size(55, 24);
            this.rbtnYarn.TabIndex = 225;
            this.rbtnYarn.TabStop = true;
            this.rbtnYarn.Text = "Yarn";
            this.rbtnYarn.UseVisualStyleBackColor = false;
            this.rbtnYarn.Click += new System.EventHandler(this.rbtnYarn_CheckedChanged);
            // 
            // rbtnAcc
            // 
            this.rbtnAcc.AutoSize = true;
            this.rbtnAcc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.rbtnAcc.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAcc.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbtnAcc.Location = new System.Drawing.Point(1, 71);
            this.rbtnAcc.Name = "rbtnAcc";
            this.rbtnAcc.Size = new System.Drawing.Size(103, 24);
            this.rbtnAcc.TabIndex = 224;
            this.rbtnAcc.Text = "Accessories";
            this.rbtnAcc.UseVisualStyleBackColor = false;
            this.rbtnAcc.CheckedChanged += new System.EventHandler(this.rbtnAcc_CheckedChanged);
            // 
            // clsbCategory
            // 
            this.clsbCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.clsbCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clsbCategory.CheckOnClick = true;
            this.clsbCategory.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsbCategory.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clsbCategory.FormattingEnabled = true;
            this.clsbCategory.Location = new System.Drawing.Point(0, 385);
            this.clsbCategory.Name = "clsbCategory";
            this.clsbCategory.Size = new System.Drawing.Size(170, 110);
            this.clsbCategory.TabIndex = 226;
            // 
            // clsbFibreMaterial
            // 
            this.clsbFibreMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.clsbFibreMaterial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clsbFibreMaterial.CheckOnClick = true;
            this.clsbFibreMaterial.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsbFibreMaterial.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clsbFibreMaterial.FormattingEnabled = true;
            this.clsbFibreMaterial.Location = new System.Drawing.Point(0, 517);
            this.clsbFibreMaterial.Name = "clsbFibreMaterial";
            this.clsbFibreMaterial.Size = new System.Drawing.Size(170, 110);
            this.clsbFibreMaterial.TabIndex = 228;
            // 
            // clsbColour
            // 
            this.clsbColour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.clsbColour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clsbColour.CheckOnClick = true;
            this.clsbColour.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsbColour.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clsbColour.FormattingEnabled = true;
            this.clsbColour.HorizontalScrollbar = true;
            this.clsbColour.Location = new System.Drawing.Point(0, 652);
            this.clsbColour.Name = "clsbColour";
            this.clsbColour.Size = new System.Drawing.Size(170, 110);
            this.clsbColour.TabIndex = 227;
            // 
            // pbxFilterBar
            // 
            this.pbxFilterBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.pbxFilterBar.Location = new System.Drawing.Point(0, 65);
            this.pbxFilterBar.Name = "pbxFilterBar";
            this.pbxFilterBar.Size = new System.Drawing.Size(200, 674);
            this.pbxFilterBar.TabIndex = 223;
            this.pbxFilterBar.TabStop = false;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AllowUserToResizeColumns = false;
            this.dgvProducts.AllowUserToResizeRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvProducts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(164)))), ((int)(((byte)(180)))));
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProducts.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvProducts.Location = new System.Drawing.Point(217, 122);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(422, 411);
            this.dgvProducts.TabIndex = 242;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(607, 76);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(32, 32);
            this.btnSearch.TabIndex = 241;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(217, 80);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(386, 25);
            this.tbxSearch.TabIndex = 240;
            this.tbxSearch.TextChanged += new System.EventHandler(this.tbxSearch_TextChanged);
            // 
            // btnAddSave
            // 
            this.btnAddSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnAddSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnAddSave.FlatAppearance.BorderSize = 0;
            this.btnAddSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnAddSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnAddSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSave.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddSave.Location = new System.Drawing.Point(1205, 468);
            this.btnAddSave.Name = "btnAddSave";
            this.btnAddSave.Size = new System.Drawing.Size(98, 35);
            this.btnAddSave.TabIndex = 244;
            this.btnAddSave.Text = "NEW";
            this.btnAddSave.UseVisualStyleBackColor = false;
            this.btnAddSave.Click += new System.EventHandler(this.btnAddSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.Location = new System.Drawing.Point(1101, 468);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 35);
            this.btnCancel.TabIndex = 243;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlFilters
            // 
            this.pnlFilters.AutoScroll = true;
            this.pnlFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.pnlFilters.Controls.Add(this.clsbSuppliers);
            this.pnlFilters.Controls.Add(this.chbxDiscontinuedFilter);
            this.pnlFilters.Controls.Add(this.clsbStock);
            this.pnlFilters.Controls.Add(this.lblProductType);
            this.pnlFilters.Controls.Add(this.rbtnAcc);
            this.pnlFilters.Controls.Add(this.clsbColour);
            this.pnlFilters.Controls.Add(this.rbtnYarn);
            this.pnlFilters.Controls.Add(this.lblStockFilter);
            this.pnlFilters.Controls.Add(this.rbtnAll);
            this.pnlFilters.Controls.Add(this.clsbFibreMaterial);
            this.pnlFilters.Controls.Add(this.lblFibreMaterialFilter);
            this.pnlFilters.Controls.Add(this.lblColourFilter);
            this.pnlFilters.Controls.Add(this.clsbCategory);
            this.pnlFilters.Controls.Add(this.lblCategoryFilter);
            this.pnlFilters.Controls.Add(this.lblSuppliers);
            this.pnlFilters.Location = new System.Drawing.Point(12, 105);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(188, 360);
            this.pnlFilters.TabIndex = 245;
            // 
            // chbxDiscontinuedFilter
            // 
            this.chbxDiscontinuedFilter.AutoSize = true;
            this.chbxDiscontinuedFilter.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxDiscontinuedFilter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chbxDiscontinuedFilter.Location = new System.Drawing.Point(1, 95);
            this.chbxDiscontinuedFilter.Name = "chbxDiscontinuedFilter";
            this.chbxDiscontinuedFilter.Size = new System.Drawing.Size(115, 24);
            this.chbxDiscontinuedFilter.TabIndex = 248;
            this.chbxDiscontinuedFilter.Text = "Discontinued";
            this.chbxDiscontinuedFilter.UseVisualStyleBackColor = true;
            // 
            // clsbStock
            // 
            this.clsbStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.clsbStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clsbStock.CheckOnClick = true;
            this.clsbStock.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsbStock.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clsbStock.FormattingEnabled = true;
            this.clsbStock.HorizontalScrollbar = true;
            this.clsbStock.Items.AddRange(new object[] {
            "In Stock",
            "No Stock",
            "Low Stock"});
            this.clsbStock.Location = new System.Drawing.Point(0, 141);
            this.clsbStock.Name = "clsbStock";
            this.clsbStock.Size = new System.Drawing.Size(170, 66);
            this.clsbStock.TabIndex = 246;
            // 
            // lblStockFilter
            // 
            this.lblStockFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.lblStockFilter.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockFilter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblStockFilter.Location = new System.Drawing.Point(0, 118);
            this.lblStockFilter.Name = "lblStockFilter";
            this.lblStockFilter.Size = new System.Drawing.Size(170, 25);
            this.lblStockFilter.TabIndex = 247;
            this.lblStockFilter.Text = "STOCK";
            this.lblStockFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDiscontinued
            // 
            this.lblDiscontinued.AutoSize = true;
            this.lblDiscontinued.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDiscontinued.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscontinued.ForeColor = System.Drawing.Color.DarkRed;
            this.lblDiscontinued.Location = new System.Drawing.Point(1199, 126);
            this.lblDiscontinued.Name = "lblDiscontinued";
            this.lblDiscontinued.Size = new System.Drawing.Size(106, 21);
            this.lblDiscontinued.TabIndex = 247;
            this.lblDiscontinued.Text = "Discontinued";
            this.lblDiscontinued.Visible = false;
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnUpload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnUpload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnUpload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpload.Location = new System.Drawing.Point(651, 507);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(71, 26);
            this.btnUpload.TabIndex = 248;
            this.btnUpload.Text = "UPLOAD";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Visible = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // tbxFileName
            // 
            this.tbxFileName.Location = new System.Drawing.Point(651, 475);
            this.tbxFileName.Margin = new System.Windows.Forms.Padding(4);
            this.tbxFileName.Name = "tbxFileName";
            this.tbxFileName.Size = new System.Drawing.Size(135, 25);
            this.tbxFileName.TabIndex = 250;
            this.tbxFileName.Visible = false;
            // 
            // lblSaveAs
            // 
            this.lblSaveAs.AutoSize = true;
            this.lblSaveAs.Location = new System.Drawing.Point(649, 458);
            this.lblSaveAs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSaveAs.Name = "lblSaveAs";
            this.lblSaveAs.Size = new System.Drawing.Size(56, 17);
            this.lblSaveAs.TabIndex = 249;
            this.lblSaveAs.Text = "Save As:";
            this.lblSaveAs.Visible = false;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRemove.Location = new System.Drawing.Point(724, 507);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(71, 26);
            this.btnRemove.TabIndex = 251;
            this.btnRemove.Text = "REMOVE";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Visible = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReset.Location = new System.Drawing.Point(797, 507);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(71, 26);
            this.btnReset.TabIndex = 252;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pbxHideFilter
            // 
            this.pbxHideFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.pbxHideFilter.Location = new System.Drawing.Point(0, 99);
            this.pbxHideFilter.Name = "pbxHideFilter";
            this.pbxHideFilter.Size = new System.Drawing.Size(200, 453);
            this.pbxHideFilter.TabIndex = 253;
            this.pbxHideFilter.TabStop = false;
            this.pbxHideFilter.Visible = false;
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1314, 545);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.tbxFileName);
            this.Controls.Add(this.lblSaveAs);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.lblDiscontinued);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.btnAddSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnApplyFilters);
            this.Controls.Add(this.btnClearFilters);
            this.Controls.Add(this.pbxFilterBar);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblProductInfo);
            this.Controls.Add(this.lblProductImg);
            this.Controls.Add(this.pnlProductInfo);
            this.Controls.Add(this.ProductInfo);
            this.Controls.Add(this.pbxImage);
            this.Controls.Add(this.pbxBar);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.pbxHideFilter);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Products";
            this.Text = "FormProducts";
            this.Load += new System.EventHandler(this.FormProducts_Load);
            this.pnlProductInfo.ResumeLayout(false);
            this.pnlProductInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFullStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFilterBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHideFilter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlProductInfo;
        private System.Windows.Forms.ComboBox cbxFibre;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.TextBox tbxType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox tbxProductID;
        private System.Windows.Forms.TextBox tbxSupplier;
        private System.Windows.Forms.TextBox tbxCost;
        private System.Windows.Forms.TextBox tbxCategory;
        private System.Windows.Forms.TextBox tbxFibre;
        private System.Windows.Forms.TextBox tbxStock;
        private System.Windows.Forms.TextBox tbxProductName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblFibre;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label ProductInfo;
        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.Label lblColour;
        private System.Windows.Forms.ComboBox cbxColour;
        private System.Windows.Forms.PictureBox pbxImage;
        private System.Windows.Forms.Label lblProductImg;
        private System.Windows.Forms.TextBox tbxColour;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discontinueToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbxSuppliers;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Label lblProductInfo;
        private System.Windows.Forms.PictureBox pbxBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSuppliers;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.RadioButton rbtnAll;
        private System.Windows.Forms.CheckedListBox clsbSuppliers;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Label lblFibreMaterialFilter;
        private System.Windows.Forms.Label lblColourFilter;
        private System.Windows.Forms.Label lblCategoryFilter;
        private System.Windows.Forms.RadioButton rbtnYarn;
        private System.Windows.Forms.RadioButton rbtnAcc;
        private System.Windows.Forms.CheckedListBox clsbCategory;
        private System.Windows.Forms.CheckedListBox clsbFibreMaterial;
        private System.Windows.Forms.CheckedListBox clsbColour;
        private System.Windows.Forms.PictureBox pbxFilterBar;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Button btnAddSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.CheckedListBox clsbStock;
        private System.Windows.Forms.Label lblStockFilter;
        private System.Windows.Forms.CheckBox chbxDiscontinuedFilter;
        private System.Windows.Forms.Label lblStockLevel;
        private System.Windows.Forms.Label lblDiscontinued;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox tbxFileName;
        private System.Windows.Forms.Label lblSaveAs;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.NumericUpDown numFullStock;
        private System.Windows.Forms.NumericUpDown numLowStock;
        private System.Windows.Forms.Label lblFullStock;
        private System.Windows.Forms.Label lblLowStock;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.PictureBox pbxHideFilter;
        private System.Windows.Forms.NumericUpDown numStock;
    }
}