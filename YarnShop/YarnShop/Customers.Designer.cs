namespace YarnShop
{
    partial class Customers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Customers));
            this.lblCustID = new System.Windows.Forms.Label();
            this.lblEmailAdd = new System.Windows.Forms.Label();
            this.lblPhoneNum = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblMember = new System.Windows.Forms.Label();
            this.lblVouchers = new System.Windows.Forms.Label();
            this.CustomerInfo = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbxForename = new System.Windows.Forms.TextBox();
            this.tbxPhoneNum = new System.Windows.Forms.TextBox();
            this.tbxEmailAdd = new System.Windows.Forms.TextBox();
            this.tbxCustID = new System.Windows.Forms.TextBox();
            this.tbxMemType = new System.Windows.Forms.TextBox();
            this.tbxVouchers = new System.Windows.Forms.TextBox();
            this.tbxSurname = new System.Windows.Forms.TextBox();
            this.lblSurname = new System.Windows.Forms.Label();
            this.tbxTotalStars = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCustInfo = new System.Windows.Forms.Panel();
            this.cbxMemType = new System.Windows.Forms.ComboBox();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.lblCustInfo = new System.Windows.Forms.Label();
            this.pbxBar = new System.Windows.Forms.PictureBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.btnAddSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            this.pnlCustInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCustID
            // 
            this.lblCustID.AutoSize = true;
            this.lblCustID.Location = new System.Drawing.Point(8, 9);
            this.lblCustID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustID.Name = "lblCustID";
            this.lblCustID.Size = new System.Drawing.Size(80, 17);
            this.lblCustID.TabIndex = 9;
            this.lblCustID.Text = "Customer ID";
            // 
            // lblEmailAdd
            // 
            this.lblEmailAdd.AutoSize = true;
            this.lblEmailAdd.Location = new System.Drawing.Point(7, 179);
            this.lblEmailAdd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmailAdd.Name = "lblEmailAdd";
            this.lblEmailAdd.Size = new System.Drawing.Size(91, 17);
            this.lblEmailAdd.TabIndex = 8;
            this.lblEmailAdd.Text = "Email Address";
            // 
            // lblPhoneNum
            // 
            this.lblPhoneNum.AutoSize = true;
            this.lblPhoneNum.Location = new System.Drawing.Point(8, 234);
            this.lblPhoneNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhoneNum.Name = "lblPhoneNum";
            this.lblPhoneNum.Size = new System.Drawing.Size(96, 17);
            this.lblPhoneNum.TabIndex = 7;
            this.lblPhoneNum.Text = "Phone Number";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(7, 67);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(65, 17);
            this.lblFirstName.TabIndex = 6;
            this.lblFirstName.Text = "Forename";
            // 
            // lblMember
            // 
            this.lblMember.AutoSize = true;
            this.lblMember.Location = new System.Drawing.Point(282, 64);
            this.lblMember.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMember.Name = "lblMember";
            this.lblMember.Size = new System.Drawing.Size(113, 17);
            this.lblMember.TabIndex = 10;
            this.lblMember.Text = "Membership Type";
            // 
            // lblVouchers
            // 
            this.lblVouchers.AutoSize = true;
            this.lblVouchers.Location = new System.Drawing.Point(282, 177);
            this.lblVouchers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVouchers.Name = "lblVouchers";
            this.lblVouchers.Size = new System.Drawing.Size(117, 17);
            this.lblVouchers.TabIndex = 11;
            this.lblVouchers.Text = "Vouchers Available";
            // 
            // CustomerInfo
            // 
            this.CustomerInfo.AutoSize = true;
            this.CustomerInfo.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.CustomerInfo.Location = new System.Drawing.Point(432, 106);
            this.CustomerInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CustomerInfo.Name = "CustomerInfo";
            this.CustomerInfo.Size = new System.Drawing.Size(155, 30);
            this.CustomerInfo.TabIndex = 12;
            this.CustomerInfo.Text = "Customer Info:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(115, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // tbxForename
            // 
            this.tbxForename.BackColor = System.Drawing.SystemColors.Window;
            this.tbxForename.Location = new System.Drawing.Point(12, 84);
            this.tbxForename.Margin = new System.Windows.Forms.Padding(4);
            this.tbxForename.Name = "tbxForename";
            this.tbxForename.Size = new System.Drawing.Size(218, 25);
            this.tbxForename.TabIndex = 19;
            // 
            // tbxPhoneNum
            // 
            this.tbxPhoneNum.BackColor = System.Drawing.SystemColors.Window;
            this.tbxPhoneNum.Location = new System.Drawing.Point(12, 254);
            this.tbxPhoneNum.Margin = new System.Windows.Forms.Padding(4);
            this.tbxPhoneNum.Name = "tbxPhoneNum";
            this.tbxPhoneNum.Size = new System.Drawing.Size(218, 25);
            this.tbxPhoneNum.TabIndex = 22;
            // 
            // tbxEmailAdd
            // 
            this.tbxEmailAdd.BackColor = System.Drawing.SystemColors.Window;
            this.tbxEmailAdd.Location = new System.Drawing.Point(12, 196);
            this.tbxEmailAdd.Margin = new System.Windows.Forms.Padding(4);
            this.tbxEmailAdd.Name = "tbxEmailAdd";
            this.tbxEmailAdd.Size = new System.Drawing.Size(218, 25);
            this.tbxEmailAdd.TabIndex = 21;
            // 
            // tbxCustID
            // 
            this.tbxCustID.BackColor = System.Drawing.SystemColors.Window;
            this.tbxCustID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxCustID.Location = new System.Drawing.Point(12, 29);
            this.tbxCustID.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCustID.Name = "tbxCustID";
            this.tbxCustID.ReadOnly = true;
            this.tbxCustID.Size = new System.Drawing.Size(218, 18);
            this.tbxCustID.TabIndex = 18;
            // 
            // tbxMemType
            // 
            this.tbxMemType.Location = new System.Drawing.Point(286, 85);
            this.tbxMemType.Margin = new System.Windows.Forms.Padding(4);
            this.tbxMemType.Name = "tbxMemType";
            this.tbxMemType.Size = new System.Drawing.Size(167, 25);
            this.tbxMemType.TabIndex = 23;
            // 
            // tbxVouchers
            // 
            this.tbxVouchers.Location = new System.Drawing.Point(286, 196);
            this.tbxVouchers.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVouchers.Name = "tbxVouchers";
            this.tbxVouchers.Size = new System.Drawing.Size(167, 25);
            this.tbxVouchers.TabIndex = 25;
            // 
            // tbxSurname
            // 
            this.tbxSurname.BackColor = System.Drawing.SystemColors.Window;
            this.tbxSurname.Location = new System.Drawing.Point(12, 140);
            this.tbxSurname.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSurname.Name = "tbxSurname";
            this.tbxSurname.Size = new System.Drawing.Size(218, 25);
            this.tbxSurname.TabIndex = 20;
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(8, 122);
            this.lblSurname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(59, 17);
            this.lblSurname.TabIndex = 23;
            this.lblSurname.Text = "Surname";
            // 
            // tbxTotalStars
            // 
            this.tbxTotalStars.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxTotalStars.Location = new System.Drawing.Point(286, 139);
            this.tbxTotalStars.Margin = new System.Windows.Forms.Padding(4);
            this.tbxTotalStars.Name = "tbxTotalStars";
            this.tbxTotalStars.Size = new System.Drawing.Size(167, 18);
            this.tbxTotalStars.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 122);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Total Stars";
            // 
            // pnlCustInfo
            // 
            this.pnlCustInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCustInfo.Controls.Add(this.cbxMemType);
            this.pnlCustInfo.Controls.Add(this.label1);
            this.pnlCustInfo.Controls.Add(this.tbxSurname);
            this.pnlCustInfo.Controls.Add(this.lblSurname);
            this.pnlCustInfo.Controls.Add(this.tbxCustID);
            this.pnlCustInfo.Controls.Add(this.tbxTotalStars);
            this.pnlCustInfo.Controls.Add(this.tbxEmailAdd);
            this.pnlCustInfo.Controls.Add(this.tbxVouchers);
            this.pnlCustInfo.Controls.Add(this.tbxMemType);
            this.pnlCustInfo.Controls.Add(this.tbxPhoneNum);
            this.pnlCustInfo.Controls.Add(this.tbxForename);
            this.pnlCustInfo.Controls.Add(this.lblVouchers);
            this.pnlCustInfo.Controls.Add(this.lblMember);
            this.pnlCustInfo.Controls.Add(this.lblCustID);
            this.pnlCustInfo.Controls.Add(this.lblEmailAdd);
            this.pnlCustInfo.Controls.Add(this.lblPhoneNum);
            this.pnlCustInfo.Controls.Add(this.lblFirstName);
            this.pnlCustInfo.Location = new System.Drawing.Point(437, 140);
            this.pnlCustInfo.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCustInfo.Name = "pnlCustInfo";
            this.pnlCustInfo.Size = new System.Drawing.Size(467, 292);
            this.pnlCustInfo.TabIndex = 30;
            // 
            // cbxMemType
            // 
            this.cbxMemType.BackColor = System.Drawing.SystemColors.Window;
            this.cbxMemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMemType.Enabled = false;
            this.cbxMemType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxMemType.FormattingEnabled = true;
            this.cbxMemType.Items.AddRange(new object[] {
            "Bronze",
            "Silver",
            "Gold"});
            this.cbxMemType.Location = new System.Drawing.Point(286, 85);
            this.cbxMemType.Margin = new System.Windows.Forms.Padding(4);
            this.cbxMemType.Name = "cbxMemType";
            this.cbxMemType.Size = new System.Drawing.Size(167, 25);
            this.cbxMemType.TabIndex = 33;
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AllowUserToResizeColumns = false;
            this.dgvCustomers.AllowUserToResizeRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCustomers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(164)))), ((int)(((byte)(180)))));
            this.dgvCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomers.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCustomers.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvCustomers.Location = new System.Drawing.Point(12, 106);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(410, 367);
            this.dgvCustomers.TabIndex = 54;
            this.dgvCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);
            // 
            // lblCustInfo
            // 
            this.lblCustInfo.AutoSize = true;
            this.lblCustInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblCustInfo.Font = new System.Drawing.Font("Yu Gothic UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustInfo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCustInfo.Location = new System.Drawing.Point(10, 10);
            this.lblCustInfo.Name = "lblCustInfo";
            this.lblCustInfo.Size = new System.Drawing.Size(222, 47);
            this.lblCustInfo.TabIndex = 185;
            this.lblCustInfo.Text = "CUSTOMERS";
            // 
            // pbxBar
            // 
            this.pbxBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.pbxBar.Location = new System.Drawing.Point(-3, 0);
            this.pbxBar.Name = "pbxBar";
            this.pbxBar.Size = new System.Drawing.Size(937, 65);
            this.pbxBar.TabIndex = 184;
            this.pbxBar.TabStop = false;
            this.pbxBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxBar_MouseDown);
            this.pbxBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbxBar_MouseMove);
            this.pbxBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxBar_MouseUp);
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
            this.btnSearch.Location = new System.Drawing.Point(390, 69);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(32, 32);
            this.btnSearch.TabIndex = 197;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(12, 74);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(376, 25);
            this.tbxSearch.TabIndex = 196;
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
            this.btnAddSave.Location = new System.Drawing.Point(816, 439);
            this.btnAddSave.Name = "btnAddSave";
            this.btnAddSave.Size = new System.Drawing.Size(88, 34);
            this.btnAddSave.TabIndex = 199;
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
            this.btnCancel.Location = new System.Drawing.Point(713, 439);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 35);
            this.btnCancel.TabIndex = 198;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(856, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 48);
            this.btnClose.TabIndex = 200;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(921, 486);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.lblCustInfo);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.pbxBar);
            this.Controls.Add(this.pnlCustInfo);
            this.Controls.Add(this.CustomerInfo);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Customers";
            this.Text = "FormCustomers";
            this.Load += new System.EventHandler(this.FormCustomers_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlCustInfo.ResumeLayout(false);
            this.pnlCustInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCustID;
        private System.Windows.Forms.Label lblEmailAdd;
        private System.Windows.Forms.Label lblPhoneNum;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.Label lblVouchers;
        private System.Windows.Forms.Label CustomerInfo;
        private System.Windows.Forms.TextBox tbxForename;
        private System.Windows.Forms.TextBox tbxPhoneNum;
        private System.Windows.Forms.TextBox tbxEmailAdd;
        private System.Windows.Forms.TextBox tbxCustID;
        private System.Windows.Forms.TextBox tbxMemType;
        private System.Windows.Forms.TextBox tbxVouchers;
        private System.Windows.Forms.TextBox tbxSurname;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.TextBox tbxTotalStars;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Panel pnlCustInfo;
        private System.Windows.Forms.ComboBox cbxMemType;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Label lblCustInfo;
        private System.Windows.Forms.PictureBox pbxBar;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Button btnAddSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox btnClose;
    }
}