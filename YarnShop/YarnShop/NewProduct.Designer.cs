namespace YarnShop
{
    partial class NewProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProduct));
            this.tbxFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.pbxImage = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.tbxType = new System.Windows.Forms.TextBox();
            this.lblColour = new System.Windows.Forms.Label();
            this.gbxProductType = new System.Windows.Forms.GroupBox();
            this.rbtnAccessory = new System.Windows.Forms.RadioButton();
            this.rbtnYarn = new System.Windows.Forms.RadioButton();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.tbxCost = new System.Windows.Forms.TextBox();
            this.tbxProductName = new System.Windows.Forms.TextBox();
            this.lblFibre = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.cbxColour = new System.Windows.Forms.ComboBox();
            this.cbxFibre = new System.Windows.Forms.ComboBox();
            this.cbxSuppliers = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.lblNewProduct = new System.Windows.Forms.Label();
            this.pbxBar = new System.Windows.Forms.PictureBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.numFullStock = new System.Windows.Forms.NumericUpDown();
            this.lblFullStock = new System.Windows.Forms.Label();
            this.numLowStock = new System.Windows.Forms.NumericUpDown();
            this.lblLowStock = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            this.gbxProductType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFullStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowStock)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxFileName
            // 
            this.tbxFileName.Location = new System.Drawing.Point(21, 370);
            this.tbxFileName.Margin = new System.Windows.Forms.Padding(4);
            this.tbxFileName.Name = "tbxFileName";
            this.tbxFileName.Size = new System.Drawing.Size(116, 25);
            this.tbxFileName.TabIndex = 86;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(18, 362);
            this.lblFileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(0, 17);
            this.lblFileName.TabIndex = 85;
            // 
            // pbxImage
            // 
            this.pbxImage.Location = new System.Drawing.Point(156, 294);
            this.pbxImage.Margin = new System.Windows.Forms.Padding(4);
            this.pbxImage.Name = "pbxImage";
            this.pbxImage.Size = new System.Drawing.Size(77, 101);
            this.pbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImage.TabIndex = 84;
            this.pbxImage.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 353);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 83;
            this.label2.Text = "Save As:";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(19, 300);
            this.lblImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(44, 17);
            this.lblImage.TabIndex = 72;
            this.lblImage.Text = "Image";
            // 
            // tbxType
            // 
            this.tbxType.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxType.Location = new System.Drawing.Point(249, 78);
            this.tbxType.Margin = new System.Windows.Forms.Padding(4);
            this.tbxType.Name = "tbxType";
            this.tbxType.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbxType.Size = new System.Drawing.Size(168, 25);
            this.tbxType.TabIndex = 82;
            // 
            // lblColour
            // 
            this.lblColour.AutoSize = true;
            this.lblColour.Location = new System.Drawing.Point(247, 175);
            this.lblColour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColour.Name = "lblColour";
            this.lblColour.Size = new System.Drawing.Size(47, 17);
            this.lblColour.TabIndex = 45;
            this.lblColour.Text = "Colour";
            // 
            // gbxProductType
            // 
            this.gbxProductType.Controls.Add(this.rbtnAccessory);
            this.gbxProductType.Controls.Add(this.rbtnYarn);
            this.gbxProductType.Location = new System.Drawing.Point(250, 295);
            this.gbxProductType.Margin = new System.Windows.Forms.Padding(4);
            this.gbxProductType.Name = "gbxProductType";
            this.gbxProductType.Padding = new System.Windows.Forms.Padding(4);
            this.gbxProductType.Size = new System.Drawing.Size(167, 75);
            this.gbxProductType.TabIndex = 70;
            this.gbxProductType.TabStop = false;
            this.gbxProductType.Text = "Product Type";
            // 
            // rbtnAccessory
            // 
            this.rbtnAccessory.AutoSize = true;
            this.rbtnAccessory.Location = new System.Drawing.Point(7, 44);
            this.rbtnAccessory.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnAccessory.Name = "rbtnAccessory";
            this.rbtnAccessory.Size = new System.Drawing.Size(84, 21);
            this.rbtnAccessory.TabIndex = 69;
            this.rbtnAccessory.TabStop = true;
            this.rbtnAccessory.Text = "Accessory";
            this.rbtnAccessory.UseVisualStyleBackColor = true;
            this.rbtnAccessory.CheckedChanged += new System.EventHandler(this.rbtnAccessory_CheckedChanged);
            // 
            // rbtnYarn
            // 
            this.rbtnYarn.AutoSize = true;
            this.rbtnYarn.Location = new System.Drawing.Point(7, 18);
            this.rbtnYarn.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnYarn.Name = "rbtnYarn";
            this.rbtnYarn.Size = new System.Drawing.Size(51, 21);
            this.rbtnYarn.TabIndex = 68;
            this.rbtnYarn.TabStop = true;
            this.rbtnYarn.Text = "Yarn";
            this.rbtnYarn.UseVisualStyleBackColor = true;
            this.rbtnYarn.CheckedChanged += new System.EventHandler(this.rbtnYarn_CheckedChanged);
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(18, 233);
            this.lblSupplier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(56, 17);
            this.lblSupplier.TabIndex = 25;
            this.lblSupplier.Text = "Supplier";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(247, 62);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(35, 17);
            this.lblType.TabIndex = 23;
            this.lblType.Text = "Type";
            // 
            // tbxCost
            // 
            this.tbxCost.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxCost.Location = new System.Drawing.Point(20, 135);
            this.tbxCost.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCost.Name = "tbxCost";
            this.tbxCost.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbxCost.Size = new System.Drawing.Size(168, 25);
            this.tbxCost.TabIndex = 21;
            // 
            // tbxProductName
            // 
            this.tbxProductName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxProductName.Location = new System.Drawing.Point(22, 78);
            this.tbxProductName.Margin = new System.Windows.Forms.Padding(4);
            this.tbxProductName.Name = "tbxProductName";
            this.tbxProductName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbxProductName.Size = new System.Drawing.Size(201, 25);
            this.tbxProductName.TabIndex = 19;
            // 
            // lblFibre
            // 
            this.lblFibre.AutoSize = true;
            this.lblFibre.Location = new System.Drawing.Point(247, 233);
            this.lblFibre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFibre.Name = "lblFibre";
            this.lblFibre.Size = new System.Drawing.Size(90, 17);
            this.lblFibre.TabIndex = 10;
            this.lblFibre.Text = "Fibre/Material";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(247, 116);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(61, 17);
            this.lblCategory.TabIndex = 11;
            this.lblCategory.Text = "Category";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(17, 116);
            this.lblCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(34, 17);
            this.lblCost.TabIndex = 8;
            this.lblCost.Text = "Cost";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(18, 173);
            this.lblStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(39, 17);
            this.lblStock.TabIndex = 7;
            this.lblStock.Text = "Stock";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(17, 61);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(92, 17);
            this.lblProductName.TabIndex = 6;
            this.lblProductName.Text = "Product Name";
            // 
            // cbxCategory
            // 
            this.cbxCategory.BackColor = System.Drawing.SystemColors.Window;
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(250, 135);
            this.cbxCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(167, 25);
            this.cbxCategory.TabIndex = 43;
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
            this.cbxColour.Location = new System.Drawing.Point(250, 192);
            this.cbxColour.Margin = new System.Windows.Forms.Padding(4);
            this.cbxColour.Name = "cbxColour";
            this.cbxColour.Size = new System.Drawing.Size(167, 25);
            this.cbxColour.TabIndex = 43;
            // 
            // cbxFibre
            // 
            this.cbxFibre.BackColor = System.Drawing.SystemColors.Window;
            this.cbxFibre.FormattingEnabled = true;
            this.cbxFibre.Location = new System.Drawing.Point(250, 253);
            this.cbxFibre.Margin = new System.Windows.Forms.Padding(4);
            this.cbxFibre.Name = "cbxFibre";
            this.cbxFibre.Size = new System.Drawing.Size(167, 25);
            this.cbxFibre.TabIndex = 33;
            // 
            // cbxSuppliers
            // 
            this.cbxSuppliers.BackColor = System.Drawing.SystemColors.Window;
            this.cbxSuppliers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSuppliers.FormattingEnabled = true;
            this.cbxSuppliers.Location = new System.Drawing.Point(22, 253);
            this.cbxSuppliers.Margin = new System.Windows.Forms.Padding(4);
            this.cbxSuppliers.Name = "cbxSuppliers";
            this.cbxSuppliers.Size = new System.Drawing.Size(167, 25);
            this.cbxSuppliers.TabIndex = 81;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAdd.Location = new System.Drawing.Point(325, 412);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 31);
            this.btnAdd.TabIndex = 121;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAddSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClear.Location = new System.Drawing.Point(226, 412);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 31);
            this.btnClear.TabIndex = 120;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(393, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 24);
            this.btnClose.TabIndex = 205;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblNewProduct
            // 
            this.lblNewProduct.AutoSize = true;
            this.lblNewProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblNewProduct.Font = new System.Drawing.Font("Yu Gothic UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewProduct.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNewProduct.Location = new System.Drawing.Point(2, 2);
            this.lblNewProduct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewProduct.Name = "lblNewProduct";
            this.lblNewProduct.Size = new System.Drawing.Size(208, 37);
            this.lblNewProduct.TabIndex = 204;
            this.lblNewProduct.Text = "NEW PRODUCT";
            // 
            // pbxBar
            // 
            this.pbxBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.pbxBar.Location = new System.Drawing.Point(0, 0);
            this.pbxBar.Margin = new System.Windows.Forms.Padding(4);
            this.pbxBar.Name = "pbxBar";
            this.pbxBar.Size = new System.Drawing.Size(431, 45);
            this.pbxBar.TabIndex = 203;
            this.pbxBar.TabStop = false;
            this.pbxBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxBar_MouseDown);
            this.pbxBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbxBar_MouseMove);
            this.pbxBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxBar_MouseUp);
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
            this.btnUpload.Location = new System.Drawing.Point(78, 294);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(71, 26);
            this.btnUpload.TabIndex = 206;
            this.btnUpload.Text = "UPLOAD";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
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
            this.btnRemove.Location = new System.Drawing.Point(78, 326);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(71, 26);
            this.btnRemove.TabIndex = 207;
            this.btnRemove.Text = "REMOVE";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // numStock
            // 
            this.numStock.Location = new System.Drawing.Point(21, 192);
            this.numStock.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numStock.Name = "numStock";
            this.numStock.Size = new System.Drawing.Size(31, 25);
            this.numStock.TabIndex = 208;
            // 
            // numFullStock
            // 
            this.numFullStock.Location = new System.Drawing.Point(179, 192);
            this.numFullStock.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numFullStock.Name = "numFullStock";
            this.numFullStock.Size = new System.Drawing.Size(31, 25);
            this.numFullStock.TabIndex = 210;
            this.numFullStock.ValueChanged += new System.EventHandler(this.numFullStock_ValueChanged);
            // 
            // lblFullStock
            // 
            this.lblFullStock.AutoSize = true;
            this.lblFullStock.Location = new System.Drawing.Point(165, 172);
            this.lblFullStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFullStock.Name = "lblFullStock";
            this.lblFullStock.Size = new System.Drawing.Size(61, 17);
            this.lblFullStock.TabIndex = 209;
            this.lblFullStock.Text = "Full Stock";
            // 
            // numLowStock
            // 
            this.numLowStock.Location = new System.Drawing.Point(101, 192);
            this.numLowStock.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numLowStock.Name = "numLowStock";
            this.numLowStock.Size = new System.Drawing.Size(31, 25);
            this.numLowStock.TabIndex = 212;
            this.numLowStock.ValueChanged += new System.EventHandler(this.numLowStock_ValueChanged);
            // 
            // lblLowStock
            // 
            this.lblLowStock.AutoSize = true;
            this.lblLowStock.Location = new System.Drawing.Point(83, 172);
            this.lblLowStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Size = new System.Drawing.Size(66, 17);
            this.lblLowStock.TabIndex = 211;
            this.lblLowStock.Text = "Low Stock";
            // 
            // NewProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(430, 454);
            this.Controls.Add(this.numLowStock);
            this.Controls.Add(this.lblLowStock);
            this.Controls.Add(this.numFullStock);
            this.Controls.Add(this.lblFullStock);
            this.Controls.Add(this.numStock);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblNewProduct);
            this.Controls.Add(this.pbxBar);
            this.Controls.Add(this.tbxFileName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.pbxImage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.tbxType);
            this.Controls.Add(this.gbxProductType);
            this.Controls.Add(this.lblColour);
            this.Controls.Add(this.cbxSuppliers);
            this.Controls.Add(this.cbxFibre);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.cbxColour);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cbxCategory);
            this.Controls.Add(this.tbxCost);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.tbxProductName);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblFibre);
            this.Controls.Add(this.lblCategory);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NewProduct";
            this.Text = "FormNewProduct";
            this.Load += new System.EventHandler(this.FormNewProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
            this.gbxProductType.ResumeLayout(false);
            this.gbxProductType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFullStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblColour;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox tbxCost;
        private System.Windows.Forms.TextBox tbxProductName;
        private System.Windows.Forms.Label lblFibre;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.ComboBox cbxColour;
        private System.Windows.Forms.ComboBox cbxFibre;
        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.ComboBox cbxSuppliers;
        private System.Windows.Forms.TextBox tbxType;
        private System.Windows.Forms.RadioButton rbtnYarn;
        private System.Windows.Forms.RadioButton rbtnAccessory;
        private System.Windows.Forms.GroupBox gbxProductType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.PictureBox pbxImage;
        private System.Windows.Forms.TextBox tbxFileName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Label lblNewProduct;
        private System.Windows.Forms.PictureBox pbxBar;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.NumericUpDown numFullStock;
        private System.Windows.Forms.Label lblFullStock;
        private System.Windows.Forms.NumericUpDown numLowStock;
        private System.Windows.Forms.Label lblLowStock;
    }
}