namespace YarnShop
{
    partial class NewCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCustomer));
            this.lblSupplierInfo = new System.Windows.Forms.Label();
            this.pbxBar = new System.Windows.Forms.PictureBox();
            this.cbxMemType = new System.Windows.Forms.ComboBox();
            this.lblTotalStars = new System.Windows.Forms.Label();
            this.tbxSurname = new System.Windows.Forms.TextBox();
            this.lblSurname = new System.Windows.Forms.Label();
            this.tbxTotalStars = new System.Windows.Forms.TextBox();
            this.tbxEmailAdd = new System.Windows.Forms.TextBox();
            this.tbxVouchers = new System.Windows.Forms.TextBox();
            this.tbxMemType = new System.Windows.Forms.TextBox();
            this.tbxPhoneNum = new System.Windows.Forms.TextBox();
            this.tbxForename = new System.Windows.Forms.TextBox();
            this.lblVouchers = new System.Windows.Forms.Label();
            this.lblMember = new System.Windows.Forms.Label();
            this.lblEmailAdd = new System.Windows.Forms.Label();
            this.lblPhoneNum = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.lblExisting = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSupplierInfo
            // 
            this.lblSupplierInfo.AutoSize = true;
            this.lblSupplierInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblSupplierInfo.Font = new System.Drawing.Font("Yu Gothic UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierInfo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSupplierInfo.Location = new System.Drawing.Point(2, 2);
            this.lblSupplierInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSupplierInfo.Name = "lblSupplierInfo";
            this.lblSupplierInfo.Size = new System.Drawing.Size(227, 37);
            this.lblSupplierInfo.TabIndex = 60;
            this.lblSupplierInfo.Text = "NEW CUSTOMER";
            // 
            // pbxBar
            // 
            this.pbxBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.pbxBar.Location = new System.Drawing.Point(0, 0);
            this.pbxBar.Margin = new System.Windows.Forms.Padding(4);
            this.pbxBar.Name = "pbxBar";
            this.pbxBar.Size = new System.Drawing.Size(474, 45);
            this.pbxBar.TabIndex = 59;
            this.pbxBar.TabStop = false;
            this.pbxBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxBar_MouseDown);
            this.pbxBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbxBar_MouseMove);
            this.pbxBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxBar_MouseUp);
            // 
            // cbxMemType
            // 
            this.cbxMemType.BackColor = System.Drawing.SystemColors.Window;
            this.cbxMemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMemType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxMemType.FormattingEnabled = true;
            this.cbxMemType.Items.AddRange(new object[] {
            "Bronze",
            "Silver",
            "Gold"});
            this.cbxMemType.Location = new System.Drawing.Point(289, 84);
            this.cbxMemType.Margin = new System.Windows.Forms.Padding(4);
            this.cbxMemType.Name = "cbxMemType";
            this.cbxMemType.Size = new System.Drawing.Size(167, 25);
            this.cbxMemType.TabIndex = 33;
            // 
            // lblTotalStars
            // 
            this.lblTotalStars.AutoSize = true;
            this.lblTotalStars.Location = new System.Drawing.Point(285, 121);
            this.lblTotalStars.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalStars.Name = "lblTotalStars";
            this.lblTotalStars.Size = new System.Drawing.Size(69, 17);
            this.lblTotalStars.TabIndex = 25;
            this.lblTotalStars.Text = "Total Stars";
            // 
            // tbxSurname
            // 
            this.tbxSurname.BackColor = System.Drawing.SystemColors.Window;
            this.tbxSurname.Location = new System.Drawing.Point(18, 131);
            this.tbxSurname.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSurname.Name = "tbxSurname";
            this.tbxSurname.Size = new System.Drawing.Size(218, 25);
            this.tbxSurname.TabIndex = 20;
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(15, 113);
            this.lblSurname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(59, 17);
            this.lblSurname.TabIndex = 23;
            this.lblSurname.Text = "Surname";
            // 
            // tbxTotalStars
            // 
            this.tbxTotalStars.Location = new System.Drawing.Point(289, 138);
            this.tbxTotalStars.Margin = new System.Windows.Forms.Padding(4);
            this.tbxTotalStars.Name = "tbxTotalStars";
            this.tbxTotalStars.Size = new System.Drawing.Size(167, 25);
            this.tbxTotalStars.TabIndex = 24;
            // 
            // tbxEmailAdd
            // 
            this.tbxEmailAdd.BackColor = System.Drawing.SystemColors.Window;
            this.tbxEmailAdd.Location = new System.Drawing.Point(18, 187);
            this.tbxEmailAdd.Margin = new System.Windows.Forms.Padding(4);
            this.tbxEmailAdd.Name = "tbxEmailAdd";
            this.tbxEmailAdd.Size = new System.Drawing.Size(218, 25);
            this.tbxEmailAdd.TabIndex = 21;
            this.tbxEmailAdd.TextChanged += new System.EventHandler(this.tbxEmailAdd_TextChanged);
            // 
            // tbxVouchers
            // 
            this.tbxVouchers.Location = new System.Drawing.Point(289, 195);
            this.tbxVouchers.Margin = new System.Windows.Forms.Padding(4);
            this.tbxVouchers.Name = "tbxVouchers";
            this.tbxVouchers.Size = new System.Drawing.Size(167, 25);
            this.tbxVouchers.TabIndex = 25;
            // 
            // tbxMemType
            // 
            this.tbxMemType.Location = new System.Drawing.Point(289, 84);
            this.tbxMemType.Margin = new System.Windows.Forms.Padding(4);
            this.tbxMemType.Name = "tbxMemType";
            this.tbxMemType.Size = new System.Drawing.Size(167, 25);
            this.tbxMemType.TabIndex = 23;
            // 
            // tbxPhoneNum
            // 
            this.tbxPhoneNum.BackColor = System.Drawing.SystemColors.Window;
            this.tbxPhoneNum.Location = new System.Drawing.Point(18, 245);
            this.tbxPhoneNum.Margin = new System.Windows.Forms.Padding(4);
            this.tbxPhoneNum.Name = "tbxPhoneNum";
            this.tbxPhoneNum.Size = new System.Drawing.Size(218, 25);
            this.tbxPhoneNum.TabIndex = 22;
            this.tbxPhoneNum.TextChanged += new System.EventHandler(this.tbxPhoneNum_TextChanged);
            // 
            // tbxForename
            // 
            this.tbxForename.BackColor = System.Drawing.SystemColors.Window;
            this.tbxForename.Location = new System.Drawing.Point(18, 75);
            this.tbxForename.Margin = new System.Windows.Forms.Padding(4);
            this.tbxForename.Name = "tbxForename";
            this.tbxForename.Size = new System.Drawing.Size(218, 25);
            this.tbxForename.TabIndex = 19;
            // 
            // lblVouchers
            // 
            this.lblVouchers.AutoSize = true;
            this.lblVouchers.Location = new System.Drawing.Point(285, 176);
            this.lblVouchers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVouchers.Name = "lblVouchers";
            this.lblVouchers.Size = new System.Drawing.Size(117, 17);
            this.lblVouchers.TabIndex = 11;
            this.lblVouchers.Text = "Vouchers Available";
            // 
            // lblMember
            // 
            this.lblMember.AutoSize = true;
            this.lblMember.Location = new System.Drawing.Point(285, 63);
            this.lblMember.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMember.Name = "lblMember";
            this.lblMember.Size = new System.Drawing.Size(113, 17);
            this.lblMember.TabIndex = 10;
            this.lblMember.Text = "Membership Type";
            // 
            // lblEmailAdd
            // 
            this.lblEmailAdd.AutoSize = true;
            this.lblEmailAdd.Location = new System.Drawing.Point(13, 170);
            this.lblEmailAdd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmailAdd.Name = "lblEmailAdd";
            this.lblEmailAdd.Size = new System.Drawing.Size(91, 17);
            this.lblEmailAdd.TabIndex = 8;
            this.lblEmailAdd.Text = "Email Address";
            // 
            // lblPhoneNum
            // 
            this.lblPhoneNum.AutoSize = true;
            this.lblPhoneNum.Location = new System.Drawing.Point(15, 225);
            this.lblPhoneNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhoneNum.Name = "lblPhoneNum";
            this.lblPhoneNum.Size = new System.Drawing.Size(96, 17);
            this.lblPhoneNum.TabIndex = 7;
            this.lblPhoneNum.Text = "Phone Number";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(13, 58);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(65, 17);
            this.lblFirstName.TabIndex = 6;
            this.lblFirstName.Text = "Forename";
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
            this.btnClear.Location = new System.Drawing.Point(264, 279);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 31);
            this.btnClear.TabIndex = 117;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            this.btnAdd.Location = new System.Drawing.Point(363, 279);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 31);
            this.btnAdd.TabIndex = 118;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAddSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(437, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 24);
            this.btnClose.TabIndex = 202;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblExisting
            // 
            this.lblExisting.ForeColor = System.Drawing.Color.DarkRed;
            this.lblExisting.Location = new System.Drawing.Point(15, 274);
            this.lblExisting.Name = "lblExisting";
            this.lblExisting.Size = new System.Drawing.Size(131, 36);
            this.lblExisting.TabIndex = 203;
            this.lblExisting.Text = "Customer exists with these contact details";
            this.lblExisting.Visible = false;
            // 
            // NewCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(473, 323);
            this.Controls.Add(this.lblExisting);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cbxMemType);
            this.Controls.Add(this.lblTotalStars);
            this.Controls.Add(this.tbxSurname);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.tbxTotalStars);
            this.Controls.Add(this.lblSupplierInfo);
            this.Controls.Add(this.tbxEmailAdd);
            this.Controls.Add(this.pbxBar);
            this.Controls.Add(this.tbxVouchers);
            this.Controls.Add(this.tbxMemType);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.tbxPhoneNum);
            this.Controls.Add(this.lblPhoneNum);
            this.Controls.Add(this.tbxForename);
            this.Controls.Add(this.lblEmailAdd);
            this.Controls.Add(this.lblVouchers);
            this.Controls.Add(this.lblMember);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "NewCustomer";
            this.ShowIcon = false;
            this.Text = "FormNewCustomer";
            this.Load += new System.EventHandler(this.FormNewCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSupplierInfo;
        private System.Windows.Forms.PictureBox pbxBar;
        private System.Windows.Forms.ComboBox cbxMemType;
        private System.Windows.Forms.Label lblTotalStars;
        private System.Windows.Forms.TextBox tbxSurname;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.TextBox tbxTotalStars;
        private System.Windows.Forms.TextBox tbxEmailAdd;
        private System.Windows.Forms.TextBox tbxVouchers;
        private System.Windows.Forms.TextBox tbxMemType;
        private System.Windows.Forms.TextBox tbxPhoneNum;
        private System.Windows.Forms.TextBox tbxForename;
        private System.Windows.Forms.Label lblVouchers;
        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.Label lblEmailAdd;
        private System.Windows.Forms.Label lblPhoneNum;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Label lblExisting;
    }
}