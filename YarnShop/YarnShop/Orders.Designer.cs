namespace YarnShop
{
    partial class Orders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Orders));
            this.tbxExpectedDelivery = new System.Windows.Forms.TextBox();
            this.tbxOrderDate = new System.Windows.Forms.TextBox();
            this.tbxID = new System.Windows.Forms.TextBox();
            this.tbxOrderID = new System.Windows.Forms.TextBox();
            this.CustomerInfo = new System.Windows.Forms.Label();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblStarsEarned = new System.Windows.Forms.Label();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.tbxDelStatus = new System.Windows.Forms.TextBox();
            this.lblDelStatus = new System.Windows.Forms.Label();
            this.tbxColDate = new System.Windows.Forms.TextBox();
            this.lblCollectionDate = new System.Windows.Forms.Label();
            this.tbxFullName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tbxEmailAdd = new System.Windows.Forms.TextBox();
            this.lblEmailAdd = new System.Windows.Forms.Label();
            this.tbxPhoneNum = new System.Windows.Forms.TextBox();
            this.lblPhoneNum = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlOrderInfo = new System.Windows.Forms.Panel();
            this.lblCharLimit = new System.Windows.Forms.Label();
            this.pnlPaymentInfo = new System.Windows.Forms.Panel();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.tbxSubtotal = new System.Windows.Forms.TextBox();
            this.lblVoucherUsed = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.tbxTotal = new System.Windows.Forms.TextBox();
            this.tbxStarsEarned = new System.Windows.Forms.TextBox();
            this.tbxVoucher = new System.Windows.Forms.TextBox();
            this.cbxDelStatus = new System.Windows.Forms.ComboBox();
            this.dtpColDate = new System.Windows.Forms.DateTimePicker();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.dtpExpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPayStatus = new System.Windows.Forms.Label();
            this.rtbxOrderNotes = new System.Windows.Forms.RichTextBox();
            this.lblOrderNotes = new System.Windows.Forms.Label();
            this.tbxPayStatus = new System.Windows.Forms.TextBox();
            this.tbxStatus = new System.Windows.Forms.TextBox();
            this.lblOrderInfo = new System.Windows.Forms.Label();
            this.btnAddSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtpExpDateFilter = new System.Windows.Forms.DateTimePicker();
            this.rbtnCust = new System.Windows.Forms.RadioButton();
            this.rbtnSuppliers = new System.Windows.Forms.RadioButton();
            this.clsbStatus = new System.Windows.Forms.CheckedListBox();
            this.pnlContactInfo = new System.Windows.Forms.Panel();
            this.lblURL = new System.Windows.Forms.Label();
            this.tbxURL = new System.Windows.Forms.TextBox();
            this.lblContactInfo = new System.Windows.Forms.Label();
            this.clsbDelStatus = new System.Windows.Forms.CheckedListBox();
            this.dtpColDateFilter = new System.Windows.Forms.DateTimePicker();
            this.clsbPayStatus_Supplier = new System.Windows.Forms.CheckedListBox();
            this.dtpOrderDateFilter = new System.Windows.Forms.DateTimePicker();
            this.chbxOrderNotes = new System.Windows.Forms.CheckBox();
            this.btnViewOrderItems = new System.Windows.Forms.Button();
            this.pnlProductInfo = new System.Windows.Forms.Panel();
            this.tbxQuantityVoided = new System.Windows.Forms.TextBox();
            this.tbxQuantityReturned = new System.Windows.Forms.TextBox();
            this.lblQuantityReturned = new System.Windows.Forms.Label();
            this.lblQuantityVoided = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblColour = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.tbxProductID = new System.Windows.Forms.TextBox();
            this.tbxProductCost = new System.Windows.Forms.TextBox();
            this.tbxSupplier = new System.Windows.Forms.TextBox();
            this.tbxStock = new System.Windows.Forms.TextBox();
            this.tbxProductName = new System.Windows.Forms.TextBox();
            this.lblFibre = new System.Windows.Forms.Label();
            this.lblProductID = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblProductCost = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.tbxColour = new System.Windows.Forms.TextBox();
            this.tbxType = new System.Windows.Forms.TextBox();
            this.tbxFibre = new System.Windows.Forms.TextBox();
            this.tbxCategory = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.printInvoice = new System.Drawing.Printing.PrintDocument();
            this.invoicePreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.pbxBar = new System.Windows.Forms.PictureBox();
            this.lblOrders = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPayStatus_Supplier = new System.Windows.Forms.Label();
            this.lblDelStatusFilter = new System.Windows.Forms.Label();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblColDateFilter = new System.Windows.Forms.Label();
            this.lblExpDateFilter = new System.Windows.Forms.Label();
            this.lblOrderDateFilter = new System.Windows.Forms.Label();
            this.pnlFilters = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.pnlOrderInfo.SuspendLayout();
            this.pnlPaymentInfo.SuspendLayout();
            this.pnlContactInfo.SuspendLayout();
            this.pnlProductInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxExpectedDelivery
            // 
            this.tbxExpectedDelivery.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxExpectedDelivery.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxExpectedDelivery.Location = new System.Drawing.Point(12, 122);
            this.tbxExpectedDelivery.Name = "tbxExpectedDelivery";
            this.tbxExpectedDelivery.ReadOnly = true;
            this.tbxExpectedDelivery.Size = new System.Drawing.Size(142, 18);
            this.tbxExpectedDelivery.TabIndex = 35;
            // 
            // tbxOrderDate
            // 
            this.tbxOrderDate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxOrderDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxOrderDate.Location = new System.Drawing.Point(11, 72);
            this.tbxOrderDate.Name = "tbxOrderDate";
            this.tbxOrderDate.ReadOnly = true;
            this.tbxOrderDate.Size = new System.Drawing.Size(143, 18);
            this.tbxOrderDate.TabIndex = 34;
            // 
            // tbxID
            // 
            this.tbxID.BackColor = System.Drawing.SystemColors.Window;
            this.tbxID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxID.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxID.Location = new System.Drawing.Point(12, 25);
            this.tbxID.Name = "tbxID";
            this.tbxID.ReadOnly = true;
            this.tbxID.Size = new System.Drawing.Size(144, 18);
            this.tbxID.TabIndex = 33;
            // 
            // tbxOrderID
            // 
            this.tbxOrderID.BackColor = System.Drawing.SystemColors.Window;
            this.tbxOrderID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxOrderID.Location = new System.Drawing.Point(12, 30);
            this.tbxOrderID.Name = "tbxOrderID";
            this.tbxOrderID.ReadOnly = true;
            this.tbxOrderID.Size = new System.Drawing.Size(144, 18);
            this.tbxOrderID.TabIndex = 30;
            // 
            // CustomerInfo
            // 
            this.CustomerInfo.AutoSize = true;
            this.CustomerInfo.Location = new System.Drawing.Point(716, 240);
            this.CustomerInfo.Name = "CustomerInfo";
            this.CustomerInfo.Size = new System.Drawing.Size(0, 13);
            this.CustomerInfo.TabIndex = 28;
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.Location = new System.Drawing.Point(9, 101);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(142, 17);
            this.lblDeliveryDate.TabIndex = 27;
            this.lblDeliveryDate.Text = "Expected Delivery Date";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(9, 53);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(74, 17);
            this.lblOrderDate.TabIndex = 26;
            this.lblOrderDate.Text = "Order Date";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(9, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(80, 17);
            this.lblID.TabIndex = 25;
            this.lblID.Text = "Customer ID";
            // 
            // lblStarsEarned
            // 
            this.lblStarsEarned.AutoSize = true;
            this.lblStarsEarned.Location = new System.Drawing.Point(6, 82);
            this.lblStarsEarned.Name = "lblStarsEarned";
            this.lblStarsEarned.Size = new System.Drawing.Size(82, 17);
            this.lblStarsEarned.TabIndex = 24;
            this.lblStarsEarned.Text = "Stars Earned";
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.Location = new System.Drawing.Point(9, 12);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(59, 17);
            this.lblOrderID.TabIndex = 22;
            this.lblOrderID.Text = "Order ID";
            // 
            // tbxDelStatus
            // 
            this.tbxDelStatus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxDelStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxDelStatus.Location = new System.Drawing.Point(187, 69);
            this.tbxDelStatus.Name = "tbxDelStatus";
            this.tbxDelStatus.ReadOnly = true;
            this.tbxDelStatus.Size = new System.Drawing.Size(144, 18);
            this.tbxDelStatus.TabIndex = 37;
            // 
            // lblDelStatus
            // 
            this.lblDelStatus.AutoSize = true;
            this.lblDelStatus.Location = new System.Drawing.Point(184, 55);
            this.lblDelStatus.Name = "lblDelStatus";
            this.lblDelStatus.Size = new System.Drawing.Size(93, 17);
            this.lblDelStatus.TabIndex = 36;
            this.lblDelStatus.Text = "Delivery Status";
            // 
            // tbxColDate
            // 
            this.tbxColDate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxColDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxColDate.Location = new System.Drawing.Point(12, 168);
            this.tbxColDate.Name = "tbxColDate";
            this.tbxColDate.ReadOnly = true;
            this.tbxColDate.Size = new System.Drawing.Size(141, 18);
            this.tbxColDate.TabIndex = 39;
            // 
            // lblCollectionDate
            // 
            this.lblCollectionDate.AutoSize = true;
            this.lblCollectionDate.Location = new System.Drawing.Point(9, 149);
            this.lblCollectionDate.Name = "lblCollectionDate";
            this.lblCollectionDate.Size = new System.Drawing.Size(122, 17);
            this.lblCollectionDate.TabIndex = 38;
            this.lblCollectionDate.Text = "Collection Date End";
            // 
            // tbxFullName
            // 
            this.tbxFullName.BackColor = System.Drawing.SystemColors.Window;
            this.tbxFullName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxFullName.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxFullName.Location = new System.Drawing.Point(12, 69);
            this.tbxFullName.Name = "tbxFullName";
            this.tbxFullName.ReadOnly = true;
            this.tbxFullName.Size = new System.Drawing.Size(144, 18);
            this.tbxFullName.TabIndex = 41;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(9, 53);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 17);
            this.lblName.TabIndex = 40;
            this.lblName.Text = "Full Name";
            // 
            // tbxEmailAdd
            // 
            this.tbxEmailAdd.BackColor = System.Drawing.SystemColors.Window;
            this.tbxEmailAdd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxEmailAdd.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxEmailAdd.Location = new System.Drawing.Point(187, 69);
            this.tbxEmailAdd.Multiline = true;
            this.tbxEmailAdd.Name = "tbxEmailAdd";
            this.tbxEmailAdd.ReadOnly = true;
            this.tbxEmailAdd.Size = new System.Drawing.Size(213, 29);
            this.tbxEmailAdd.TabIndex = 43;
            // 
            // lblEmailAdd
            // 
            this.lblEmailAdd.AutoSize = true;
            this.lblEmailAdd.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailAdd.Location = new System.Drawing.Point(185, 53);
            this.lblEmailAdd.Name = "lblEmailAdd";
            this.lblEmailAdd.Size = new System.Drawing.Size(91, 17);
            this.lblEmailAdd.TabIndex = 42;
            this.lblEmailAdd.Text = "Email Address";
            // 
            // tbxPhoneNum
            // 
            this.tbxPhoneNum.BackColor = System.Drawing.SystemColors.Window;
            this.tbxPhoneNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxPhoneNum.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPhoneNum.Location = new System.Drawing.Point(187, 25);
            this.tbxPhoneNum.Name = "tbxPhoneNum";
            this.tbxPhoneNum.ReadOnly = true;
            this.tbxPhoneNum.Size = new System.Drawing.Size(144, 18);
            this.tbxPhoneNum.TabIndex = 45;
            // 
            // lblPhoneNum
            // 
            this.lblPhoneNum.AutoSize = true;
            this.lblPhoneNum.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNum.Location = new System.Drawing.Point(184, 9);
            this.lblPhoneNum.Name = "lblPhoneNum";
            this.lblPhoneNum.Size = new System.Drawing.Size(96, 17);
            this.lblPhoneNum.TabIndex = 44;
            this.lblPhoneNum.Text = "Phone Number";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToResizeColumns = false;
            this.dgvOrders.AllowUserToResizeRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvOrders.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(164)))), ((int)(((byte)(180)))));
            this.dgvOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrders.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrders.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvOrders.Location = new System.Drawing.Point(231, 110);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(410, 600);
            this.dgvOrders.TabIndex = 53;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.printInvoiceToolStripMenuItem,
            this.returnOrderToolStripMenuItem,
            this.voidToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 114);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // printInvoiceToolStripMenuItem
            // 
            this.printInvoiceToolStripMenuItem.Name = "printInvoiceToolStripMenuItem";
            this.printInvoiceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.printInvoiceToolStripMenuItem.Text = "Print Invoice";
            this.printInvoiceToolStripMenuItem.Click += new System.EventHandler(this.printInvoiceToolStripMenuItem_Click);
            // 
            // returnOrderToolStripMenuItem
            // 
            this.returnOrderToolStripMenuItem.Name = "returnOrderToolStripMenuItem";
            this.returnOrderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.returnOrderToolStripMenuItem.Text = "Return";
            this.returnOrderToolStripMenuItem.Click += new System.EventHandler(this.returnOrderToolStripMenuItem_Click);
            // 
            // voidToolStripMenuItem
            // 
            this.voidToolStripMenuItem.Name = "voidToolStripMenuItem";
            this.voidToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.voidToolStripMenuItem.Text = "Void";
            this.voidToolStripMenuItem.Click += new System.EventHandler(this.voidToolStripMenuItem_Click);
            // 
            // pnlOrderInfo
            // 
            this.pnlOrderInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOrderInfo.Controls.Add(this.lblCharLimit);
            this.pnlOrderInfo.Controls.Add(this.pnlPaymentInfo);
            this.pnlOrderInfo.Controls.Add(this.cbxDelStatus);
            this.pnlOrderInfo.Controls.Add(this.dtpColDate);
            this.pnlOrderInfo.Controls.Add(this.dtpOrderDate);
            this.pnlOrderInfo.Controls.Add(this.dtpExpDeliveryDate);
            this.pnlOrderInfo.Controls.Add(this.lblStatus);
            this.pnlOrderInfo.Controls.Add(this.lblPayStatus);
            this.pnlOrderInfo.Controls.Add(this.rtbxOrderNotes);
            this.pnlOrderInfo.Controls.Add(this.tbxOrderID);
            this.pnlOrderInfo.Controls.Add(this.lblOrderID);
            this.pnlOrderInfo.Controls.Add(this.lblOrderNotes);
            this.pnlOrderInfo.Controls.Add(this.lblOrderDate);
            this.pnlOrderInfo.Controls.Add(this.lblDeliveryDate);
            this.pnlOrderInfo.Controls.Add(this.tbxOrderDate);
            this.pnlOrderInfo.Controls.Add(this.tbxExpectedDelivery);
            this.pnlOrderInfo.Controls.Add(this.lblDelStatus);
            this.pnlOrderInfo.Controls.Add(this.lblCollectionDate);
            this.pnlOrderInfo.Controls.Add(this.tbxColDate);
            this.pnlOrderInfo.Controls.Add(this.tbxPayStatus);
            this.pnlOrderInfo.Controls.Add(this.tbxStatus);
            this.pnlOrderInfo.Controls.Add(this.tbxDelStatus);
            this.pnlOrderInfo.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlOrderInfo.Location = new System.Drawing.Point(652, 143);
            this.pnlOrderInfo.Name = "pnlOrderInfo";
            this.pnlOrderInfo.Size = new System.Drawing.Size(415, 324);
            this.pnlOrderInfo.TabIndex = 58;
            // 
            // lblCharLimit
            // 
            this.lblCharLimit.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharLimit.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCharLimit.Location = new System.Drawing.Point(102, 202);
            this.lblCharLimit.Name = "lblCharLimit";
            this.lblCharLimit.Size = new System.Drawing.Size(67, 15);
            this.lblCharLimit.TabIndex = 102;
            this.lblCharLimit.Text = "255";
            this.lblCharLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCharLimit.Visible = false;
            // 
            // pnlPaymentInfo
            // 
            this.pnlPaymentInfo.Controls.Add(this.lblSubtotal);
            this.pnlPaymentInfo.Controls.Add(this.tbxSubtotal);
            this.pnlPaymentInfo.Controls.Add(this.lblVoucherUsed);
            this.pnlPaymentInfo.Controls.Add(this.lblTotal);
            this.pnlPaymentInfo.Controls.Add(this.tbxTotal);
            this.pnlPaymentInfo.Controls.Add(this.lblStarsEarned);
            this.pnlPaymentInfo.Controls.Add(this.tbxStarsEarned);
            this.pnlPaymentInfo.Controls.Add(this.tbxVoucher);
            this.pnlPaymentInfo.Location = new System.Drawing.Point(180, 147);
            this.pnlPaymentInfo.Name = "pnlPaymentInfo";
            this.pnlPaymentInfo.Size = new System.Drawing.Size(202, 172);
            this.pnlPaymentInfo.TabIndex = 101;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(5, 2);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(56, 17);
            this.lblSubtotal.TabIndex = 99;
            this.lblSubtotal.Text = "Subtotal";
            // 
            // tbxSubtotal
            // 
            this.tbxSubtotal.BackColor = System.Drawing.SystemColors.Window;
            this.tbxSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxSubtotal.Location = new System.Drawing.Point(9, 22);
            this.tbxSubtotal.Name = "tbxSubtotal";
            this.tbxSubtotal.ReadOnly = true;
            this.tbxSubtotal.Size = new System.Drawing.Size(144, 18);
            this.tbxSubtotal.TabIndex = 100;
            // 
            // lblVoucherUsed
            // 
            this.lblVoucherUsed.AutoSize = true;
            this.lblVoucherUsed.Location = new System.Drawing.Point(6, 122);
            this.lblVoucherUsed.Name = "lblVoucherUsed";
            this.lblVoucherUsed.Size = new System.Drawing.Size(55, 17);
            this.lblVoucherUsed.TabIndex = 97;
            this.lblVoucherUsed.Text = "Voucher";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(6, 42);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(36, 17);
            this.lblTotal.TabIndex = 42;
            this.lblTotal.Text = "Total";
            // 
            // tbxTotal
            // 
            this.tbxTotal.BackColor = System.Drawing.SystemColors.Window;
            this.tbxTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxTotal.Location = new System.Drawing.Point(9, 62);
            this.tbxTotal.Name = "tbxTotal";
            this.tbxTotal.ReadOnly = true;
            this.tbxTotal.Size = new System.Drawing.Size(144, 18);
            this.tbxTotal.TabIndex = 43;
            // 
            // tbxStarsEarned
            // 
            this.tbxStarsEarned.BackColor = System.Drawing.SystemColors.Window;
            this.tbxStarsEarned.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxStarsEarned.Location = new System.Drawing.Point(9, 102);
            this.tbxStarsEarned.Name = "tbxStarsEarned";
            this.tbxStarsEarned.ReadOnly = true;
            this.tbxStarsEarned.Size = new System.Drawing.Size(144, 18);
            this.tbxStarsEarned.TabIndex = 32;
            // 
            // tbxVoucher
            // 
            this.tbxVoucher.BackColor = System.Drawing.SystemColors.Window;
            this.tbxVoucher.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxVoucher.Location = new System.Drawing.Point(9, 142);
            this.tbxVoucher.Name = "tbxVoucher";
            this.tbxVoucher.ReadOnly = true;
            this.tbxVoucher.Size = new System.Drawing.Size(144, 18);
            this.tbxVoucher.TabIndex = 98;
            // 
            // cbxDelStatus
            // 
            this.cbxDelStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDelStatus.FormattingEnabled = true;
            this.cbxDelStatus.Location = new System.Drawing.Point(187, 72);
            this.cbxDelStatus.Name = "cbxDelStatus";
            this.cbxDelStatus.Size = new System.Drawing.Size(144, 25);
            this.cbxDelStatus.TabIndex = 44;
            this.cbxDelStatus.SelectionChangeCommitted += new System.EventHandler(this.cbxDelStatus_SelectionChangeCommitted);
            // 
            // dtpColDate
            // 
            this.dtpColDate.Location = new System.Drawing.Point(12, 168);
            this.dtpColDate.MaxDate = new System.DateTime(2050, 1, 1, 0, 0, 0, 0);
            this.dtpColDate.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dtpColDate.Name = "dtpColDate";
            this.dtpColDate.Size = new System.Drawing.Size(144, 25);
            this.dtpColDate.TabIndex = 89;
            this.dtpColDate.Visible = false;
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Location = new System.Drawing.Point(12, 72);
            this.dtpOrderDate.MaxDate = new System.DateTime(2050, 1, 1, 0, 0, 0, 0);
            this.dtpOrderDate.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(144, 25);
            this.dtpOrderDate.TabIndex = 88;
            this.dtpOrderDate.Visible = false;
            this.dtpOrderDate.ValueChanged += new System.EventHandler(this.dtpOrderDate_ValueChanged);
            // 
            // dtpExpDeliveryDate
            // 
            this.dtpExpDeliveryDate.Location = new System.Drawing.Point(12, 120);
            this.dtpExpDeliveryDate.MaxDate = new System.DateTime(2050, 1, 1, 0, 0, 0, 0);
            this.dtpExpDeliveryDate.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dtpExpDeliveryDate.Name = "dtpExpDeliveryDate";
            this.dtpExpDeliveryDate.Size = new System.Drawing.Size(144, 25);
            this.dtpExpDeliveryDate.TabIndex = 90;
            this.dtpExpDeliveryDate.Visible = false;
            this.dtpExpDeliveryDate.ValueChanged += new System.EventHandler(this.dtpExpDeliveryDate_ValueChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(184, 12);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 17);
            this.lblStatus.TabIndex = 94;
            this.lblStatus.Text = "Status";
            // 
            // lblPayStatus
            // 
            this.lblPayStatus.AutoSize = true;
            this.lblPayStatus.Location = new System.Drawing.Point(185, 102);
            this.lblPayStatus.Name = "lblPayStatus";
            this.lblPayStatus.Size = new System.Drawing.Size(96, 17);
            this.lblPayStatus.TabIndex = 91;
            this.lblPayStatus.Text = "Payment Status";
            // 
            // rtbxOrderNotes
            // 
            this.rtbxOrderNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbxOrderNotes.Location = new System.Drawing.Point(11, 221);
            this.rtbxOrderNotes.MaxLength = 255;
            this.rtbxOrderNotes.Name = "rtbxOrderNotes";
            this.rtbxOrderNotes.Size = new System.Drawing.Size(158, 86);
            this.rtbxOrderNotes.TabIndex = 41;
            this.rtbxOrderNotes.Text = "";
            this.rtbxOrderNotes.TextChanged += new System.EventHandler(this.rtbxOrderNotes_TextChanged);
            // 
            // lblOrderNotes
            // 
            this.lblOrderNotes.AutoSize = true;
            this.lblOrderNotes.Location = new System.Drawing.Point(9, 200);
            this.lblOrderNotes.Name = "lblOrderNotes";
            this.lblOrderNotes.Size = new System.Drawing.Size(82, 17);
            this.lblOrderNotes.TabIndex = 40;
            this.lblOrderNotes.Text = "Order Notes";
            // 
            // tbxPayStatus
            // 
            this.tbxPayStatus.BackColor = System.Drawing.SystemColors.Window;
            this.tbxPayStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxPayStatus.Location = new System.Drawing.Point(187, 122);
            this.tbxPayStatus.Name = "tbxPayStatus";
            this.tbxPayStatus.ReadOnly = true;
            this.tbxPayStatus.Size = new System.Drawing.Size(144, 18);
            this.tbxPayStatus.TabIndex = 92;
            // 
            // tbxStatus
            // 
            this.tbxStatus.BackColor = System.Drawing.SystemColors.Window;
            this.tbxStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxStatus.Location = new System.Drawing.Point(187, 27);
            this.tbxStatus.Name = "tbxStatus";
            this.tbxStatus.ReadOnly = true;
            this.tbxStatus.Size = new System.Drawing.Size(144, 18);
            this.tbxStatus.TabIndex = 95;
            // 
            // lblOrderInfo
            // 
            this.lblOrderInfo.AutoSize = true;
            this.lblOrderInfo.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblOrderInfo.Location = new System.Drawing.Point(647, 110);
            this.lblOrderInfo.Name = "lblOrderInfo";
            this.lblOrderInfo.Size = new System.Drawing.Size(118, 30);
            this.lblOrderInfo.TabIndex = 59;
            this.lblOrderInfo.Text = "Order Info:";
            // 
            // btnAddSave
            // 
            this.btnAddSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnAddSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnAddSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnAddSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnAddSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSave.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddSave.Location = new System.Drawing.Point(939, 664);
            this.btnAddSave.Name = "btnAddSave";
            this.btnAddSave.Size = new System.Drawing.Size(128, 46);
            this.btnAddSave.TabIndex = 37;
            this.btnAddSave.Text = "New Order";
            this.btnAddSave.UseVisualStyleBackColor = false;
            this.btnAddSave.Click += new System.EventHandler(this.btnAddSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.Location = new System.Drawing.Point(843, 664);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 46);
            this.btnCancel.TabIndex = 59;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtpExpDateFilter
            // 
            this.dtpExpDateFilter.Checked = false;
            this.dtpExpDateFilter.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpDateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpDateFilter.Location = new System.Drawing.Point(19, 401);
            this.dtpExpDateFilter.Name = "dtpExpDateFilter";
            this.dtpExpDateFilter.ShowCheckBox = true;
            this.dtpExpDateFilter.Size = new System.Drawing.Size(160, 25);
            this.dtpExpDateFilter.TabIndex = 0;
            // 
            // rbtnCust
            // 
            this.rbtnCust.AutoSize = true;
            this.rbtnCust.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.rbtnCust.Checked = true;
            this.rbtnCust.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnCust.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbtnCust.Location = new System.Drawing.Point(8, 98);
            this.rbtnCust.Name = "rbtnCust";
            this.rbtnCust.Size = new System.Drawing.Size(138, 24);
            this.rbtnCust.TabIndex = 60;
            this.rbtnCust.TabStop = true;
            this.rbtnCust.Text = "Customer Orders";
            this.rbtnCust.UseVisualStyleBackColor = false;
            this.rbtnCust.CheckedChanged += new System.EventHandler(this.rbtnCust_CheckedChanged);
            // 
            // rbtnSuppliers
            // 
            this.rbtnSuppliers.AutoSize = true;
            this.rbtnSuppliers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.rbtnSuppliers.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSuppliers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbtnSuppliers.Location = new System.Drawing.Point(8, 125);
            this.rbtnSuppliers.Name = "rbtnSuppliers";
            this.rbtnSuppliers.Size = new System.Drawing.Size(130, 24);
            this.rbtnSuppliers.TabIndex = 61;
            this.rbtnSuppliers.Text = "Supplier Orders";
            this.rbtnSuppliers.UseVisualStyleBackColor = false;
            this.rbtnSuppliers.CheckedChanged += new System.EventHandler(this.rbtnSuppliers_CheckedChanged);
            // 
            // clsbStatus
            // 
            this.clsbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.clsbStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clsbStatus.CheckOnClick = true;
            this.clsbStatus.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsbStatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clsbStatus.FormattingEnabled = true;
            this.clsbStatus.Items.AddRange(new object[] {
            "Archived",
            "Open"});
            this.clsbStatus.Location = new System.Drawing.Point(7, 58);
            this.clsbStatus.Name = "clsbStatus";
            this.clsbStatus.Size = new System.Drawing.Size(178, 44);
            this.clsbStatus.TabIndex = 71;
            // 
            // pnlContactInfo
            // 
            this.pnlContactInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContactInfo.Controls.Add(this.lblURL);
            this.pnlContactInfo.Controls.Add(this.tbxPhoneNum);
            this.pnlContactInfo.Controls.Add(this.tbxURL);
            this.pnlContactInfo.Controls.Add(this.lblName);
            this.pnlContactInfo.Controls.Add(this.lblEmailAdd);
            this.pnlContactInfo.Controls.Add(this.tbxEmailAdd);
            this.pnlContactInfo.Controls.Add(this.tbxFullName);
            this.pnlContactInfo.Controls.Add(this.tbxID);
            this.pnlContactInfo.Controls.Add(this.lblID);
            this.pnlContactInfo.Controls.Add(this.lblPhoneNum);
            this.pnlContactInfo.Location = new System.Drawing.Point(652, 504);
            this.pnlContactInfo.Name = "pnlContactInfo";
            this.pnlContactInfo.Size = new System.Drawing.Size(415, 150);
            this.pnlContactInfo.TabIndex = 86;
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblURL.Location = new System.Drawing.Point(9, 97);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(31, 17);
            this.lblURL.TabIndex = 88;
            this.lblURL.Text = "URL";
            // 
            // tbxURL
            // 
            this.tbxURL.BackColor = System.Drawing.SystemColors.Window;
            this.tbxURL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxURL.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxURL.Location = new System.Drawing.Point(12, 112);
            this.tbxURL.Name = "tbxURL";
            this.tbxURL.ReadOnly = true;
            this.tbxURL.Size = new System.Drawing.Size(194, 18);
            this.tbxURL.TabIndex = 89;
            // 
            // lblContactInfo
            // 
            this.lblContactInfo.AutoSize = true;
            this.lblContactInfo.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblContactInfo.Location = new System.Drawing.Point(647, 471);
            this.lblContactInfo.Name = "lblContactInfo";
            this.lblContactInfo.Size = new System.Drawing.Size(137, 30);
            this.lblContactInfo.TabIndex = 87;
            this.lblContactInfo.Text = "Contact Info:";
            // 
            // clsbDelStatus
            // 
            this.clsbDelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.clsbDelStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clsbDelStatus.CheckOnClick = true;
            this.clsbDelStatus.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsbDelStatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clsbDelStatus.FormattingEnabled = true;
            this.clsbDelStatus.Location = new System.Drawing.Point(7, 130);
            this.clsbDelStatus.Name = "clsbDelStatus";
            this.clsbDelStatus.Size = new System.Drawing.Size(178, 88);
            this.clsbDelStatus.TabIndex = 93;
            // 
            // dtpColDateFilter
            // 
            this.dtpColDateFilter.Checked = false;
            this.dtpColDateFilter.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpColDateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpColDateFilter.Location = new System.Drawing.Point(19, 457);
            this.dtpColDateFilter.Name = "dtpColDateFilter";
            this.dtpColDateFilter.ShowCheckBox = true;
            this.dtpColDateFilter.Size = new System.Drawing.Size(160, 25);
            this.dtpColDateFilter.TabIndex = 0;
            // 
            // clsbPayStatus_Supplier
            // 
            this.clsbPayStatus_Supplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.clsbPayStatus_Supplier.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clsbPayStatus_Supplier.CheckOnClick = true;
            this.clsbPayStatus_Supplier.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsbPayStatus_Supplier.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clsbPayStatus_Supplier.FormattingEnabled = true;
            this.clsbPayStatus_Supplier.HorizontalScrollbar = true;
            this.clsbPayStatus_Supplier.Location = new System.Drawing.Point(7, 242);
            this.clsbPayStatus_Supplier.Name = "clsbPayStatus_Supplier";
            this.clsbPayStatus_Supplier.Size = new System.Drawing.Size(178, 88);
            this.clsbPayStatus_Supplier.TabIndex = 91;
            // 
            // dtpOrderDateFilter
            // 
            this.dtpOrderDateFilter.Checked = false;
            this.dtpOrderDateFilter.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOrderDateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDateFilter.Location = new System.Drawing.Point(19, 352);
            this.dtpOrderDateFilter.Name = "dtpOrderDateFilter";
            this.dtpOrderDateFilter.ShowCheckBox = true;
            this.dtpOrderDateFilter.Size = new System.Drawing.Size(159, 25);
            this.dtpOrderDateFilter.TabIndex = 0;
            // 
            // chbxOrderNotes
            // 
            this.chbxOrderNotes.AutoSize = true;
            this.chbxOrderNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.chbxOrderNotes.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxOrderNotes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chbxOrderNotes.Location = new System.Drawing.Point(9, 5);
            this.chbxOrderNotes.Name = "chbxOrderNotes";
            this.chbxOrderNotes.Size = new System.Drawing.Size(109, 24);
            this.chbxOrderNotes.TabIndex = 93;
            this.chbxOrderNotes.Text = "Order Notes";
            this.chbxOrderNotes.UseVisualStyleBackColor = false;
            // 
            // btnViewOrderItems
            // 
            this.btnViewOrderItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnViewOrderItems.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnViewOrderItems.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnViewOrderItems.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnViewOrderItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewOrderItems.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewOrderItems.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnViewOrderItems.Location = new System.Drawing.Point(937, 107);
            this.btnViewOrderItems.Name = "btnViewOrderItems";
            this.btnViewOrderItems.Size = new System.Drawing.Size(130, 30);
            this.btnViewOrderItems.TabIndex = 94;
            this.btnViewOrderItems.Text = "View Order Items";
            this.btnViewOrderItems.UseVisualStyleBackColor = false;
            this.btnViewOrderItems.Click += new System.EventHandler(this.btnViewOrderItems_Click);
            // 
            // pnlProductInfo
            // 
            this.pnlProductInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProductInfo.Controls.Add(this.tbxQuantityVoided);
            this.pnlProductInfo.Controls.Add(this.tbxQuantityReturned);
            this.pnlProductInfo.Controls.Add(this.lblQuantityReturned);
            this.pnlProductInfo.Controls.Add(this.lblQuantityVoided);
            this.pnlProductInfo.Controls.Add(this.numQuantity);
            this.pnlProductInfo.Controls.Add(this.lblQuantity);
            this.pnlProductInfo.Controls.Add(this.lblColour);
            this.pnlProductInfo.Controls.Add(this.lblSupplier);
            this.pnlProductInfo.Controls.Add(this.lblType);
            this.pnlProductInfo.Controls.Add(this.tbxProductID);
            this.pnlProductInfo.Controls.Add(this.tbxProductCost);
            this.pnlProductInfo.Controls.Add(this.tbxSupplier);
            this.pnlProductInfo.Controls.Add(this.tbxStock);
            this.pnlProductInfo.Controls.Add(this.tbxProductName);
            this.pnlProductInfo.Controls.Add(this.lblFibre);
            this.pnlProductInfo.Controls.Add(this.lblProductID);
            this.pnlProductInfo.Controls.Add(this.lblCategory);
            this.pnlProductInfo.Controls.Add(this.lblProductCost);
            this.pnlProductInfo.Controls.Add(this.lblStock);
            this.pnlProductInfo.Controls.Add(this.lblProductName);
            this.pnlProductInfo.Controls.Add(this.tbxColour);
            this.pnlProductInfo.Controls.Add(this.tbxType);
            this.pnlProductInfo.Controls.Add(this.tbxFibre);
            this.pnlProductInfo.Controls.Add(this.tbxCategory);
            this.pnlProductInfo.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlProductInfo.Location = new System.Drawing.Point(652, 143);
            this.pnlProductInfo.Name = "pnlProductInfo";
            this.pnlProductInfo.Size = new System.Drawing.Size(415, 324);
            this.pnlProductInfo.TabIndex = 95;
            // 
            // tbxQuantityVoided
            // 
            this.tbxQuantityVoided.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxQuantityVoided.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxQuantityVoided.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxQuantityVoided.Location = new System.Drawing.Point(117, 274);
            this.tbxQuantityVoided.Name = "tbxQuantityVoided";
            this.tbxQuantityVoided.Size = new System.Drawing.Size(51, 18);
            this.tbxQuantityVoided.TabIndex = 69;
            // 
            // tbxQuantityReturned
            // 
            this.tbxQuantityReturned.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxQuantityReturned.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxQuantityReturned.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxQuantityReturned.Location = new System.Drawing.Point(261, 274);
            this.tbxQuantityReturned.Name = "tbxQuantityReturned";
            this.tbxQuantityReturned.Size = new System.Drawing.Size(41, 18);
            this.tbxQuantityReturned.TabIndex = 68;
            // 
            // lblQuantityReturned
            // 
            this.lblQuantityReturned.AutoSize = true;
            this.lblQuantityReturned.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantityReturned.Location = new System.Drawing.Point(258, 254);
            this.lblQuantityReturned.Name = "lblQuantityReturned";
            this.lblQuantityReturned.Size = new System.Drawing.Size(113, 17);
            this.lblQuantityReturned.TabIndex = 67;
            this.lblQuantityReturned.Text = "Quantity Returned";
            // 
            // lblQuantityVoided
            // 
            this.lblQuantityVoided.AutoSize = true;
            this.lblQuantityVoided.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantityVoided.Location = new System.Drawing.Point(114, 254);
            this.lblQuantityVoided.Name = "lblQuantityVoided";
            this.lblQuantityVoided.Size = new System.Drawing.Size(101, 17);
            this.lblQuantityVoided.TabIndex = 66;
            this.lblQuantityVoided.Text = "Quantity Voided";
            // 
            // numQuantity
            // 
            this.numQuantity.Enabled = false;
            this.numQuantity.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numQuantity.Location = new System.Drawing.Point(11, 271);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(52, 25);
            this.numQuantity.TabIndex = 65;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(9, 254);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(56, 17);
            this.lblQuantity.TabIndex = 64;
            this.lblQuantity.Text = "Quantity";
            // 
            // lblColour
            // 
            this.lblColour.AutoSize = true;
            this.lblColour.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColour.Location = new System.Drawing.Point(184, 155);
            this.lblColour.Name = "lblColour";
            this.lblColour.Size = new System.Drawing.Size(47, 17);
            this.lblColour.TabIndex = 45;
            this.lblColour.Text = "Colour";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.Location = new System.Drawing.Point(9, 207);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(56, 17);
            this.lblSupplier.TabIndex = 25;
            this.lblSupplier.Text = "Supplier";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(184, 53);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(35, 17);
            this.lblType.TabIndex = 23;
            this.lblType.Text = "Type";
            // 
            // tbxProductID
            // 
            this.tbxProductID.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxProductID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxProductID.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxProductID.Location = new System.Drawing.Point(9, 25);
            this.tbxProductID.Name = "tbxProductID";
            this.tbxProductID.ReadOnly = true;
            this.tbxProductID.Size = new System.Drawing.Size(157, 18);
            this.tbxProductID.TabIndex = 18;
            // 
            // tbxProductCost
            // 
            this.tbxProductCost.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxProductCost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxProductCost.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxProductCost.Location = new System.Drawing.Point(11, 122);
            this.tbxProductCost.Name = "tbxProductCost";
            this.tbxProductCost.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbxProductCost.Size = new System.Drawing.Size(157, 18);
            this.tbxProductCost.TabIndex = 21;
            // 
            // tbxSupplier
            // 
            this.tbxSupplier.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxSupplier.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxSupplier.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSupplier.Location = new System.Drawing.Point(12, 223);
            this.tbxSupplier.Name = "tbxSupplier";
            this.tbxSupplier.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbxSupplier.Size = new System.Drawing.Size(139, 18);
            this.tbxSupplier.TabIndex = 24;
            // 
            // tbxStock
            // 
            this.tbxStock.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxStock.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxStock.Location = new System.Drawing.Point(12, 171);
            this.tbxStock.Name = "tbxStock";
            this.tbxStock.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbxStock.Size = new System.Drawing.Size(157, 18);
            this.tbxStock.TabIndex = 22;
            // 
            // tbxProductName
            // 
            this.tbxProductName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxProductName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxProductName.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxProductName.Location = new System.Drawing.Point(11, 78);
            this.tbxProductName.Name = "tbxProductName";
            this.tbxProductName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbxProductName.Size = new System.Drawing.Size(157, 18);
            this.tbxProductName.TabIndex = 19;
            // 
            // lblFibre
            // 
            this.lblFibre.AutoSize = true;
            this.lblFibre.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFibre.Location = new System.Drawing.Point(185, 207);
            this.lblFibre.Name = "lblFibre";
            this.lblFibre.Size = new System.Drawing.Size(37, 17);
            this.lblFibre.TabIndex = 10;
            this.lblFibre.Text = "Fibre";
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductID.Location = new System.Drawing.Point(7, 10);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(69, 17);
            this.lblProductID.TabIndex = 9;
            this.lblProductID.Text = "Product ID";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(184, 107);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(61, 17);
            this.lblCategory.TabIndex = 11;
            this.lblCategory.Text = "Category";
            // 
            // lblProductCost
            // 
            this.lblProductCost.AutoSize = true;
            this.lblProductCost.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductCost.Location = new System.Drawing.Point(9, 107);
            this.lblProductCost.Name = "lblProductCost";
            this.lblProductCost.Size = new System.Drawing.Size(34, 17);
            this.lblProductCost.TabIndex = 8;
            this.lblProductCost.Text = "Cost";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(9, 155);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(39, 17);
            this.lblStock.TabIndex = 7;
            this.lblStock.Text = "Stock";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(8, 55);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(92, 17);
            this.lblProductName.TabIndex = 6;
            this.lblProductName.Text = "Product Name";
            // 
            // tbxColour
            // 
            this.tbxColour.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxColour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxColour.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxColour.Location = new System.Drawing.Point(187, 171);
            this.tbxColour.Name = "tbxColour";
            this.tbxColour.Size = new System.Drawing.Size(167, 18);
            this.tbxColour.TabIndex = 63;
            // 
            // tbxType
            // 
            this.tbxType.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxType.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxType.Location = new System.Drawing.Point(187, 72);
            this.tbxType.Name = "tbxType";
            this.tbxType.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbxType.Size = new System.Drawing.Size(167, 18);
            this.tbxType.TabIndex = 20;
            // 
            // tbxFibre
            // 
            this.tbxFibre.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxFibre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxFibre.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxFibre.Location = new System.Drawing.Point(188, 221);
            this.tbxFibre.Name = "tbxFibre";
            this.tbxFibre.Size = new System.Drawing.Size(135, 18);
            this.tbxFibre.TabIndex = 23;
            // 
            // tbxCategory
            // 
            this.tbxCategory.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxCategory.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCategory.Location = new System.Drawing.Point(187, 119);
            this.tbxCategory.Name = "tbxCategory";
            this.tbxCategory.Size = new System.Drawing.Size(167, 18);
            this.tbxCategory.TabIndex = 25;
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnApply.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnApply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnApply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnApply.Location = new System.Drawing.Point(876, 107);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(54, 30);
            this.btnApply.TabIndex = 96;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Visible = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // printInvoice
            // 
            this.printInvoice.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printInvoice_PrintPage);
            // 
            // invoicePreviewDialog
            // 
            this.invoicePreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.invoicePreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.invoicePreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.invoicePreviewDialog.Enabled = true;
            this.invoicePreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("invoicePreviewDialog.Icon")));
            this.invoicePreviewDialog.Name = "invoicePreviewDialog";
            this.invoicePreviewDialog.Visible = false;
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1019, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 48);
            this.btnClose.TabIndex = 181;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbxBar
            // 
            this.pbxBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.pbxBar.Location = new System.Drawing.Point(-1, 0);
            this.pbxBar.Name = "pbxBar";
            this.pbxBar.Size = new System.Drawing.Size(1264, 65);
            this.pbxBar.TabIndex = 182;
            this.pbxBar.TabStop = false;
            this.pbxBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxBar_MouseDown);
            this.pbxBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbxBar_MouseMove);
            this.pbxBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxBar_MouseUp);
            // 
            // lblOrders
            // 
            this.lblOrders.AutoSize = true;
            this.lblOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblOrders.Font = new System.Drawing.Font("Yu Gothic UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrders.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblOrders.Location = new System.Drawing.Point(12, 10);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(152, 47);
            this.lblOrders.TabIndex = 183;
            this.lblOrders.Text = "ORDERS";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.pictureBox2.Location = new System.Drawing.Point(-1, 60);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(205, 684);
            this.pictureBox2.TabIndex = 184;
            this.pictureBox2.TabStop = false;
            // 
            // lblStatusFilter
            // 
            this.lblStatusFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.lblStatusFilter.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusFilter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblStatusFilter.Location = new System.Drawing.Point(0, 33);
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Size = new System.Drawing.Size(205, 25);
            this.lblStatusFilter.TabIndex = 185;
            this.lblStatusFilter.Text = "STATUS";
            this.lblStatusFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(642, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 186;
            // 
            // lblPayStatus_Supplier
            // 
            this.lblPayStatus_Supplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.lblPayStatus_Supplier.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayStatus_Supplier.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPayStatus_Supplier.Location = new System.Drawing.Point(2, 215);
            this.lblPayStatus_Supplier.Name = "lblPayStatus_Supplier";
            this.lblPayStatus_Supplier.Size = new System.Drawing.Size(203, 25);
            this.lblPayStatus_Supplier.TabIndex = 187;
            this.lblPayStatus_Supplier.Text = "PAYMENT STATUS";
            this.lblPayStatus_Supplier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDelStatusFilter
            // 
            this.lblDelStatusFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.lblDelStatusFilter.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelStatusFilter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDelStatusFilter.Location = new System.Drawing.Point(0, 103);
            this.lblDelStatusFilter.Name = "lblDelStatusFilter";
            this.lblDelStatusFilter.Size = new System.Drawing.Size(205, 25);
            this.lblDelStatusFilter.TabIndex = 188;
            this.lblDelStatusFilter.Text = "DELIVERY STATUS";
            this.lblDelStatusFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnApplyFilters.Location = new System.Drawing.Point(-2, 492);
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.Size = new System.Drawing.Size(205, 40);
            this.btnApplyFilters.TabIndex = 190;
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
            this.btnClearFilters.Location = new System.Drawing.Point(-2, 532);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(205, 40);
            this.btnClearFilters.TabIndex = 189;
            this.btnClearFilters.Text = "CLEAR";
            this.btnClearFilters.UseVisualStyleBackColor = false;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(28, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 39);
            this.label2.TabIndex = 191;
            this.label2.Text = "FILTER:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(232, 78);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(376, 22);
            this.tbxSearch.TabIndex = 192;
            this.tbxSearch.TextChanged += new System.EventHandler(this.tbxSearch_TextChanged);
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
            this.btnSearch.Location = new System.Drawing.Point(610, 72);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(32, 32);
            this.btnSearch.TabIndex = 195;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblColDateFilter
            // 
            this.lblColDateFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.lblColDateFilter.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColDateFilter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblColDateFilter.Location = new System.Drawing.Point(0, 429);
            this.lblColDateFilter.Name = "lblColDateFilter";
            this.lblColDateFilter.Size = new System.Drawing.Size(205, 25);
            this.lblColDateFilter.TabIndex = 196;
            this.lblColDateFilter.Text = "COLLECTION";
            this.lblColDateFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExpDateFilter
            // 
            this.lblExpDateFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.lblExpDateFilter.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpDateFilter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblExpDateFilter.Location = new System.Drawing.Point(0, 375);
            this.lblExpDateFilter.Name = "lblExpDateFilter";
            this.lblExpDateFilter.Size = new System.Drawing.Size(205, 25);
            this.lblExpDateFilter.TabIndex = 197;
            this.lblExpDateFilter.Text = "EXP DATE";
            this.lblExpDateFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrderDateFilter
            // 
            this.lblOrderDateFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.lblOrderDateFilter.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDateFilter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblOrderDateFilter.Location = new System.Drawing.Point(0, 327);
            this.lblOrderDateFilter.Name = "lblOrderDateFilter";
            this.lblOrderDateFilter.Size = new System.Drawing.Size(205, 25);
            this.lblOrderDateFilter.TabIndex = 198;
            this.lblOrderDateFilter.Text = "ORDER DATE";
            this.lblOrderDateFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFilters
            // 
            this.pnlFilters.AutoScroll = true;
            this.pnlFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.pnlFilters.Controls.Add(this.chbxOrderNotes);
            this.pnlFilters.Controls.Add(this.lblOrderDateFilter);
            this.pnlFilters.Controls.Add(this.clsbPayStatus_Supplier);
            this.pnlFilters.Controls.Add(this.lblExpDateFilter);
            this.pnlFilters.Controls.Add(this.btnApplyFilters);
            this.pnlFilters.Controls.Add(this.btnClearFilters);
            this.pnlFilters.Controls.Add(this.clsbDelStatus);
            this.pnlFilters.Controls.Add(this.lblColDateFilter);
            this.pnlFilters.Controls.Add(this.dtpOrderDateFilter);
            this.pnlFilters.Controls.Add(this.dtpExpDateFilter);
            this.pnlFilters.Controls.Add(this.dtpColDateFilter);
            this.pnlFilters.Controls.Add(this.lblPayStatus_Supplier);
            this.pnlFilters.Controls.Add(this.lblStatusFilter);
            this.pnlFilters.Controls.Add(this.lblDelStatusFilter);
            this.pnlFilters.Controls.Add(this.clsbStatus);
            this.pnlFilters.Location = new System.Drawing.Point(-1, 151);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(205, 576);
            this.pnlFilters.TabIndex = 199;
            // 
            // Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1082, 727);
            this.Controls.Add(this.rbtnCust);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblOrders);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.rbtnSuppliers);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnViewOrderItems);
            this.Controls.Add(this.lblContactInfo);
            this.Controls.Add(this.lblOrderInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddSave);
            this.Controls.Add(this.CustomerInfo);
            this.Controls.Add(this.pnlContactInfo);
            this.Controls.Add(this.pnlOrderInfo);
            this.Controls.Add(this.pbxBar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pnlProductInfo);
            this.Controls.Add(this.dgvOrders);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Orders";
            this.Text = "FormOrders";
            this.Load += new System.EventHandler(this.FormOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlOrderInfo.ResumeLayout(false);
            this.pnlOrderInfo.PerformLayout();
            this.pnlPaymentInfo.ResumeLayout(false);
            this.pnlPaymentInfo.PerformLayout();
            this.pnlContactInfo.ResumeLayout(false);
            this.pnlContactInfo.PerformLayout();
            this.pnlProductInfo.ResumeLayout(false);
            this.pnlProductInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbxExpectedDelivery;
        private System.Windows.Forms.TextBox tbxOrderDate;
        private System.Windows.Forms.TextBox tbxID;
        private System.Windows.Forms.TextBox tbxOrderID;
        private System.Windows.Forms.Label CustomerInfo;
        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblStarsEarned;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.TextBox tbxDelStatus;
        private System.Windows.Forms.Label lblDelStatus;
        private System.Windows.Forms.TextBox tbxColDate;
        private System.Windows.Forms.Label lblCollectionDate;
        private System.Windows.Forms.TextBox tbxFullName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbxEmailAdd;
        private System.Windows.Forms.Label lblEmailAdd;
        private System.Windows.Forms.TextBox tbxPhoneNum;
        private System.Windows.Forms.Label lblPhoneNum;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Panel pnlOrderInfo;
        private System.Windows.Forms.Label lblOrderInfo;
        private System.Windows.Forms.Button btnAddSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rbtnCust;
        private System.Windows.Forms.RadioButton rbtnSuppliers;
        private System.Windows.Forms.CheckedListBox clsbStatus;
        private System.Windows.Forms.Panel pnlContactInfo;
        private System.Windows.Forms.Label lblContactInfo;
        private System.Windows.Forms.RichTextBox rtbxOrderNotes;
        private System.Windows.Forms.Label lblOrderNotes;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox tbxTotal;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.TextBox tbxURL;
        private System.Windows.Forms.ComboBox cbxDelStatus;
        private System.Windows.Forms.DateTimePicker dtpColDate;
        private System.Windows.Forms.DateTimePicker dtpExpDeliveryDate;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.DateTimePicker dtpExpDateFilter;
        private System.Windows.Forms.DateTimePicker dtpColDateFilter;
        private System.Windows.Forms.DateTimePicker dtpOrderDateFilter;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPayStatus;
        private System.Windows.Forms.TextBox tbxPayStatus;
        private System.Windows.Forms.TextBox tbxStatus;
        private System.Windows.Forms.CheckedListBox clsbPayStatus_Supplier;
        private System.Windows.Forms.CheckedListBox clsbDelStatus;
        private System.Windows.Forms.CheckBox chbxOrderNotes;
        private System.Windows.Forms.Button btnViewOrderItems;
        private System.Windows.Forms.Panel pnlProductInfo;
        private System.Windows.Forms.Label lblColour;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox tbxProductID;
        private System.Windows.Forms.TextBox tbxProductCost;
        private System.Windows.Forms.TextBox tbxSupplier;
        private System.Windows.Forms.TextBox tbxStock;
        private System.Windows.Forms.TextBox tbxProductName;
        private System.Windows.Forms.Label lblFibre;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblProductCost;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox tbxColour;
        private System.Windows.Forms.TextBox tbxType;
        private System.Windows.Forms.TextBox tbxFibre;
        private System.Windows.Forms.TextBox tbxCategory;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ToolStripMenuItem voidToolStripMenuItem;
        private System.Windows.Forms.TextBox tbxVoucher;
        private System.Windows.Forms.Label lblVoucherUsed;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.TextBox tbxSubtotal;
        private System.Windows.Forms.TextBox tbxStarsEarned;
        private System.Windows.Forms.ToolStripMenuItem printInvoiceToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printInvoice;
        private System.Windows.Forms.PrintPreviewDialog invoicePreviewDialog;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.ToolStripMenuItem returnOrderToolStripMenuItem;
        private System.Windows.Forms.Label lblQuantityReturned;
        private System.Windows.Forms.Label lblQuantityVoided;
        private System.Windows.Forms.TextBox tbxQuantityVoided;
        private System.Windows.Forms.TextBox tbxQuantityReturned;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.PictureBox pbxBar;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPayStatus_Supplier;
        private System.Windows.Forms.Label lblDelStatusFilter;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblColDateFilter;
        private System.Windows.Forms.Label lblExpDateFilter;
        private System.Windows.Forms.Label lblOrderDateFilter;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Panel pnlPaymentInfo;
        private System.Windows.Forms.Label lblCharLimit;
    }
}