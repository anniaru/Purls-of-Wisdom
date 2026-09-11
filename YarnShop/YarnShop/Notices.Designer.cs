namespace YarnShop
{
    partial class Notices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notices));
            this.lblProductInfo = new System.Windows.Forms.Label();
            this.pbxBar = new System.Windows.Forms.PictureBox();
            this.flpNotices = new System.Windows.Forms.FlowLayoutPanel();
            this.clsbPriority = new System.Windows.Forms.CheckedListBox();
            this.clsbStock = new System.Windows.Forms.CheckedListBox();
            this.rbtn1weekReview = new System.Windows.Forms.RadioButton();
            this.rbtn1dayReview = new System.Windows.Forms.RadioButton();
            this.rbtnOlderReview = new System.Windows.Forms.RadioButton();
            this.rbtn3daysReview = new System.Windows.Forms.RadioButton();
            this.clsbOrders = new System.Windows.Forms.CheckedListBox();
            this.btnDateIssued = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.clsbEvents = new System.Windows.Forms.CheckedListBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.pbxNoNotices = new System.Windows.Forms.PictureBox();
            this.lblNoNotices = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnPriorityOrder = new System.Windows.Forms.Button();
            this.btnReviewOrder = new System.Windows.Forms.Button();
            this.chbxDismissed = new System.Windows.Forms.CheckBox();
            this.chbxArchived = new System.Windows.Forms.CheckBox();
            this.chbxActive = new System.Windows.Forms.CheckBox();
            this.rbtn3days = new System.Windows.Forms.RadioButton();
            this.rbtnOlder = new System.Windows.Forms.RadioButton();
            this.rbtnDay = new System.Windows.Forms.RadioButton();
            this.rbtn1week = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.btnArchived = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnDismissed = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.PictureBox();
            this.pnlReviewDateFilter = new System.Windows.Forms.Panel();
            this.pnlIssueDateFilter = new System.Windows.Forms.Panel();
            this.lblEvents = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblOrders = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.lblReview = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNoNotices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            this.pnlReviewDateFilter.SuspendLayout();
            this.pnlIssueDateFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProductInfo
            // 
            this.lblProductInfo.AutoSize = true;
            this.lblProductInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblProductInfo.Font = new System.Drawing.Font("Yu Gothic UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductInfo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblProductInfo.Location = new System.Drawing.Point(12, 9);
            this.lblProductInfo.Name = "lblProductInfo";
            this.lblProductInfo.Size = new System.Drawing.Size(161, 47);
            this.lblProductInfo.TabIndex = 126;
            this.lblProductInfo.Text = "NOTICES";
            // 
            // pbxBar
            // 
            this.pbxBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.pbxBar.Location = new System.Drawing.Point(0, 0);
            this.pbxBar.Name = "pbxBar";
            this.pbxBar.Size = new System.Drawing.Size(700, 65);
            this.pbxBar.TabIndex = 129;
            this.pbxBar.TabStop = false;
            this.pbxBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxBar_MouseDown);
            this.pbxBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbxBar_MouseMove);
            this.pbxBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxBar_MouseUp);
            // 
            // flpNotices
            // 
            this.flpNotices.AutoScroll = true;
            this.flpNotices.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.flpNotices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.flpNotices.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpNotices.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpNotices.Location = new System.Drawing.Point(159, 113);
            this.flpNotices.Name = "flpNotices";
            this.flpNotices.Size = new System.Drawing.Size(528, 728);
            this.flpNotices.TabIndex = 130;
            this.flpNotices.WrapContents = false;
            // 
            // clsbPriority
            // 
            this.clsbPriority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.clsbPriority.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clsbPriority.CheckOnClick = true;
            this.clsbPriority.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clsbPriority.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsbPriority.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clsbPriority.FormattingEnabled = true;
            this.clsbPriority.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low"});
            this.clsbPriority.Location = new System.Drawing.Point(19, 214);
            this.clsbPriority.Name = "clsbPriority";
            this.clsbPriority.Size = new System.Drawing.Size(88, 88);
            this.clsbPriority.TabIndex = 74;
            // 
            // clsbStock
            // 
            this.clsbStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.clsbStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clsbStock.CheckOnClick = true;
            this.clsbStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clsbStock.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsbStock.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clsbStock.FormattingEnabled = true;
            this.clsbStock.Items.AddRange(new object[] {
            "Low Stock",
            "No Stock",
            "Selling Fast"});
            this.clsbStock.Location = new System.Drawing.Point(19, 302);
            this.clsbStock.Name = "clsbStock";
            this.clsbStock.Size = new System.Drawing.Size(95, 66);
            this.clsbStock.TabIndex = 134;
            // 
            // rbtn1weekReview
            // 
            this.rbtn1weekReview.AutoSize = true;
            this.rbtn1weekReview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.rbtn1weekReview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtn1weekReview.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn1weekReview.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbtn1weekReview.Location = new System.Drawing.Point(6, 41);
            this.rbtn1weekReview.Name = "rbtn1weekReview";
            this.rbtn1weekReview.Size = new System.Drawing.Size(73, 24);
            this.rbtn1weekReview.TabIndex = 145;
            this.rbtn1weekReview.Text = "1 week";
            this.rbtn1weekReview.UseVisualStyleBackColor = false;
            // 
            // rbtn1dayReview
            // 
            this.rbtn1dayReview.AutoSize = true;
            this.rbtn1dayReview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.rbtn1dayReview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtn1dayReview.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn1dayReview.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbtn1dayReview.Location = new System.Drawing.Point(6, 0);
            this.rbtn1dayReview.Name = "rbtn1dayReview";
            this.rbtn1dayReview.Size = new System.Drawing.Size(63, 24);
            this.rbtn1dayReview.TabIndex = 142;
            this.rbtn1dayReview.Text = "1 day";
            this.rbtn1dayReview.UseVisualStyleBackColor = false;
            // 
            // rbtnOlderReview
            // 
            this.rbtnOlderReview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.rbtnOlderReview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnOlderReview.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnOlderReview.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbtnOlderReview.Location = new System.Drawing.Point(6, 64);
            this.rbtnOlderReview.Name = "rbtnOlderReview";
            this.rbtnOlderReview.Size = new System.Drawing.Size(87, 24);
            this.rbtnOlderReview.TabIndex = 144;
            this.rbtnOlderReview.Text = "Older";
            this.rbtnOlderReview.UseVisualStyleBackColor = false;
            // 
            // rbtn3daysReview
            // 
            this.rbtn3daysReview.AutoSize = true;
            this.rbtn3daysReview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.rbtn3daysReview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtn3daysReview.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn3daysReview.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbtn3daysReview.Location = new System.Drawing.Point(6, 20);
            this.rbtn3daysReview.Name = "rbtn3daysReview";
            this.rbtn3daysReview.Size = new System.Drawing.Size(69, 24);
            this.rbtn3daysReview.TabIndex = 143;
            this.rbtn3daysReview.Text = "3 days";
            this.rbtn3daysReview.UseVisualStyleBackColor = false;
            // 
            // clsbOrders
            // 
            this.clsbOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.clsbOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clsbOrders.CheckOnClick = true;
            this.clsbOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clsbOrders.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsbOrders.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clsbOrders.FormattingEnabled = true;
            this.clsbOrders.Items.AddRange(new object[] {
            "Collection",
            "Processing",
            "Supply"});
            this.clsbOrders.Location = new System.Drawing.Point(19, 477);
            this.clsbOrders.Name = "clsbOrders";
            this.clsbOrders.Size = new System.Drawing.Size(95, 66);
            this.clsbOrders.TabIndex = 143;
            // 
            // btnDateIssued
            // 
            this.btnDateIssued.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnDateIssued.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnDateIssued.FlatAppearance.BorderSize = 0;
            this.btnDateIssued.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnDateIssued.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnDateIssued.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDateIssued.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDateIssued.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDateIssued.Location = new System.Drawing.Point(24, 542);
            this.btnDateIssued.Name = "btnDateIssued";
            this.btnDateIssued.Size = new System.Drawing.Size(88, 32);
            this.btnDateIssued.TabIndex = 156;
            this.btnDateIssued.Text = "Issue Date";
            this.btnDateIssued.UseVisualStyleBackColor = false;
            // 
            // btnOrders
            // 
            this.btnOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnOrders.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnOrders.FlatAppearance.BorderSize = 0;
            this.btnOrders.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnOrders.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrders.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrders.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOrders.Location = new System.Drawing.Point(24, 442);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(88, 35);
            this.btnOrders.TabIndex = 159;
            this.btnOrders.Text = "Orders";
            this.btnOrders.UseVisualStyleBackColor = false;
            // 
            // clsbEvents
            // 
            this.clsbEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.clsbEvents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clsbEvents.CheckOnClick = true;
            this.clsbEvents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clsbEvents.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsbEvents.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clsbEvents.FormattingEnabled = true;
            this.clsbEvents.Items.AddRange(new object[] {
            "Payments",
            "Spaces"});
            this.clsbEvents.Location = new System.Drawing.Point(19, 401);
            this.clsbEvents.Name = "clsbEvents";
            this.clsbEvents.Size = new System.Drawing.Size(88, 44);
            this.clsbEvents.TabIndex = 163;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClear.Location = new System.Drawing.Point(23, 806);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 35);
            this.btnClear.TabIndex = 164;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApply.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnApply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnApply.Location = new System.Drawing.Point(23, 774);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(88, 34);
            this.btnApply.TabIndex = 165;
            this.btnApply.Text = "APPLY";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // pbxNoNotices
            // 
            this.pbxNoNotices.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pbxNoNotices.Image = ((System.Drawing.Image)(resources.GetObject("pbxNoNotices.Image")));
            this.pbxNoNotices.Location = new System.Drawing.Point(376, 251);
            this.pbxNoNotices.Name = "pbxNoNotices";
            this.pbxNoNotices.Size = new System.Drawing.Size(96, 96);
            this.pbxNoNotices.TabIndex = 166;
            this.pbxNoNotices.TabStop = false;
            this.pbxNoNotices.Visible = false;
            // 
            // lblNoNotices
            // 
            this.lblNoNotices.AutoSize = true;
            this.lblNoNotices.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNoNotices.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoNotices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.lblNoNotices.Location = new System.Drawing.Point(323, 342);
            this.lblNoNotices.Name = "lblNoNotices";
            this.lblNoNotices.Size = new System.Drawing.Size(204, 30);
            this.lblNoNotices.TabIndex = 167;
            this.lblNoNotices.Text = "You have no notices";
            this.lblNoNotices.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.pictureBox2.Location = new System.Drawing.Point(0, 61);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(141, 790);
            this.pictureBox2.TabIndex = 169;
            this.pictureBox2.TabStop = false;
            // 
            // btnPriorityOrder
            // 
            this.btnPriorityOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnPriorityOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnPriorityOrder.FlatAppearance.BorderSize = 0;
            this.btnPriorityOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnPriorityOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnPriorityOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPriorityOrder.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPriorityOrder.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPriorityOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnPriorityOrder.Image")));
            this.btnPriorityOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPriorityOrder.Location = new System.Drawing.Point(159, 75);
            this.btnPriorityOrder.Name = "btnPriorityOrder";
            this.btnPriorityOrder.Size = new System.Drawing.Size(121, 32);
            this.btnPriorityOrder.TabIndex = 173;
            this.btnPriorityOrder.Text = "PRIORITY";
            this.btnPriorityOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPriorityOrder.UseVisualStyleBackColor = false;
            this.btnPriorityOrder.Visible = false;
            this.btnPriorityOrder.Click += new System.EventHandler(this.btnPriorityOrder_Click);
            // 
            // btnReviewOrder
            // 
            this.btnReviewOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnReviewOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnReviewOrder.FlatAppearance.BorderSize = 0;
            this.btnReviewOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnReviewOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnReviewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReviewOrder.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReviewOrder.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReviewOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnReviewOrder.Image")));
            this.btnReviewOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReviewOrder.Location = new System.Drawing.Point(287, 75);
            this.btnReviewOrder.Name = "btnReviewOrder";
            this.btnReviewOrder.Size = new System.Drawing.Size(160, 32);
            this.btnReviewOrder.TabIndex = 174;
            this.btnReviewOrder.Text = "REVIEW DATE";
            this.btnReviewOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReviewOrder.UseVisualStyleBackColor = false;
            this.btnReviewOrder.Visible = false;
            this.btnReviewOrder.Click += new System.EventHandler(this.btnReviewOrder_Click);
            // 
            // chbxDismissed
            // 
            this.chbxDismissed.AutoSize = true;
            this.chbxDismissed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.chbxDismissed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbxDismissed.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxDismissed.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chbxDismissed.Location = new System.Drawing.Point(19, 141);
            this.chbxDismissed.Name = "chbxDismissed";
            this.chbxDismissed.Size = new System.Drawing.Size(95, 24);
            this.chbxDismissed.TabIndex = 175;
            this.chbxDismissed.Text = "Dismissed";
            this.chbxDismissed.UseVisualStyleBackColor = false;
            // 
            // chbxArchived
            // 
            this.chbxArchived.AutoSize = true;
            this.chbxArchived.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.chbxArchived.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbxArchived.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxArchived.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chbxArchived.Location = new System.Drawing.Point(19, 162);
            this.chbxArchived.Name = "chbxArchived";
            this.chbxArchived.Size = new System.Drawing.Size(89, 24);
            this.chbxArchived.TabIndex = 176;
            this.chbxArchived.Text = "Archived";
            this.chbxArchived.UseVisualStyleBackColor = false;
            // 
            // chbxActive
            // 
            this.chbxActive.AutoSize = true;
            this.chbxActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.chbxActive.Checked = true;
            this.chbxActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxActive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbxActive.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxActive.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chbxActive.Location = new System.Drawing.Point(19, 120);
            this.chbxActive.Name = "chbxActive";
            this.chbxActive.Size = new System.Drawing.Size(70, 24);
            this.chbxActive.TabIndex = 177;
            this.chbxActive.Text = "Active";
            this.chbxActive.UseVisualStyleBackColor = false;
            // 
            // rbtn3days
            // 
            this.rbtn3days.AutoSize = true;
            this.rbtn3days.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.rbtn3days.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtn3days.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn3days.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbtn3days.Location = new System.Drawing.Point(7, 22);
            this.rbtn3days.Name = "rbtn3days";
            this.rbtn3days.Size = new System.Drawing.Size(69, 24);
            this.rbtn3days.TabIndex = 139;
            this.rbtn3days.Text = "3 days";
            this.rbtn3days.UseVisualStyleBackColor = false;
            // 
            // rbtnOlder
            // 
            this.rbtnOlder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.rbtnOlder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnOlder.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnOlder.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbtnOlder.Location = new System.Drawing.Point(7, 64);
            this.rbtnOlder.Name = "rbtnOlder";
            this.rbtnOlder.Size = new System.Drawing.Size(87, 27);
            this.rbtnOlder.TabIndex = 140;
            this.rbtnOlder.Text = "Older";
            this.rbtnOlder.UseVisualStyleBackColor = false;
            // 
            // rbtnDay
            // 
            this.rbtnDay.AutoSize = true;
            this.rbtnDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.rbtnDay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnDay.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDay.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbtnDay.Location = new System.Drawing.Point(7, 3);
            this.rbtnDay.Name = "rbtnDay";
            this.rbtnDay.Size = new System.Drawing.Size(63, 24);
            this.rbtnDay.TabIndex = 138;
            this.rbtnDay.Text = "1 day";
            this.rbtnDay.UseVisualStyleBackColor = false;
            // 
            // rbtn1week
            // 
            this.rbtn1week.AutoSize = true;
            this.rbtn1week.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.rbtn1week.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtn1week.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn1week.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbtn1week.Location = new System.Drawing.Point(7, 43);
            this.rbtn1week.Name = "rbtn1week";
            this.rbtn1week.Size = new System.Drawing.Size(73, 24);
            this.rbtn1week.TabIndex = 141;
            this.rbtn1week.Text = "1 week";
            this.rbtn1week.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(639, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 48);
            this.btnClose.TabIndex = 178;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnArchived
            // 
            this.btnArchived.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnArchived.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnArchived.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnArchived.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnArchived.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchived.Image = ((System.Drawing.Image)(resources.GetObject("btnArchived.Image")));
            this.btnArchived.Location = new System.Drawing.Point(12, 75);
            this.btnArchived.Name = "btnArchived";
            this.btnArchived.Size = new System.Drawing.Size(36, 36);
            this.btnArchived.TabIndex = 179;
            this.btnArchived.UseVisualStyleBackColor = false;
            this.btnArchived.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnFilter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.Image")));
            this.btnFilter.Location = new System.Drawing.Point(93, 75);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(36, 36);
            this.btnFilter.TabIndex = 180;
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnDismissed
            // 
            this.btnDismissed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnDismissed.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.btnDismissed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnDismissed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(102)))), ((int)(((byte)(125)))));
            this.btnDismissed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDismissed.Image = ((System.Drawing.Image)(resources.GetObject("btnDismissed.Image")));
            this.btnDismissed.Location = new System.Drawing.Point(52, 75);
            this.btnDismissed.Name = "btnDismissed";
            this.btnDismissed.Size = new System.Drawing.Size(36, 36);
            this.btnDismissed.TabIndex = 181;
            this.btnDismissed.UseVisualStyleBackColor = false;
            this.btnDismissed.Click += new System.EventHandler(this.btnDismissed_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(585, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(48, 48);
            this.btnRefresh.TabIndex = 182;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlReviewDateFilter
            // 
            this.pnlReviewDateFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.pnlReviewDateFilter.Controls.Add(this.rbtn1dayReview);
            this.pnlReviewDateFilter.Controls.Add(this.rbtn3daysReview);
            this.pnlReviewDateFilter.Controls.Add(this.rbtnOlderReview);
            this.pnlReviewDateFilter.Controls.Add(this.rbtn1weekReview);
            this.pnlReviewDateFilter.Location = new System.Drawing.Point(13, 680);
            this.pnlReviewDateFilter.Name = "pnlReviewDateFilter";
            this.pnlReviewDateFilter.Size = new System.Drawing.Size(117, 88);
            this.pnlReviewDateFilter.TabIndex = 183;
            // 
            // pnlIssueDateFilter
            // 
            this.pnlIssueDateFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.pnlIssueDateFilter.Controls.Add(this.rbtn1week);
            this.pnlIssueDateFilter.Controls.Add(this.rbtnDay);
            this.pnlIssueDateFilter.Controls.Add(this.rbtnOlder);
            this.pnlIssueDateFilter.Controls.Add(this.rbtn3days);
            this.pnlIssueDateFilter.Location = new System.Drawing.Point(12, 568);
            this.pnlIssueDateFilter.Name = "pnlIssueDateFilter";
            this.pnlIssueDateFilter.Size = new System.Drawing.Size(118, 94);
            this.pnlIssueDateFilter.TabIndex = 184;
            // 
            // lblEvents
            // 
            this.lblEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.lblEvents.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvents.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblEvents.Location = new System.Drawing.Point(0, 373);
            this.lblEvents.Name = "lblEvents";
            this.lblEvents.Size = new System.Drawing.Size(141, 25);
            this.lblEvents.TabIndex = 248;
            this.lblEvents.Text = "EVENTS";
            this.lblEvents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStock
            // 
            this.lblStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.lblStock.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblStock.Location = new System.Drawing.Point(0, 280);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(141, 25);
            this.lblStock.TabIndex = 249;
            this.lblStock.Text = "STOCK";
            this.lblStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPriority
            // 
            this.lblPriority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.lblPriority.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriority.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPriority.Location = new System.Drawing.Point(0, 188);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(141, 25);
            this.lblPriority.TabIndex = 250;
            this.lblPriority.Text = "PRIORITY";
            this.lblPriority.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrders
            // 
            this.lblOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.lblOrders.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrders.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblOrders.Location = new System.Drawing.Point(0, 447);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(141, 25);
            this.lblOrders.TabIndex = 251;
            this.lblOrders.Text = "ORDERS";
            this.lblOrders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.lblIssueDate.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueDate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblIssueDate.Location = new System.Drawing.Point(0, 547);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(141, 25);
            this.lblIssueDate.TabIndex = 252;
            this.lblIssueDate.Text = "ISSUE";
            this.lblIssueDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReview
            // 
            this.lblReview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.lblReview.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReview.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblReview.Location = new System.Drawing.Point(0, 657);
            this.lblReview.Name = "lblReview";
            this.lblReview.Size = new System.Drawing.Size(141, 25);
            this.lblReview.TabIndex = 253;
            this.lblReview.Text = "REVIEW";
            this.lblReview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Notices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(697, 851);
            this.Controls.Add(this.lblReview);
            this.Controls.Add(this.lblIssueDate);
            this.Controls.Add(this.lblOrders);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblEvents);
            this.Controls.Add(this.pnlIssueDateFilter);
            this.Controls.Add(this.pnlReviewDateFilter);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDismissed);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnArchived);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.chbxActive);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.chbxDismissed);
            this.Controls.Add(this.chbxArchived);
            this.Controls.Add(this.btnReviewOrder);
            this.Controls.Add(this.btnPriorityOrder);
            this.Controls.Add(this.btnDateIssued);
            this.Controls.Add(this.lblNoNotices);
            this.Controls.Add(this.pbxNoNotices);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.flpNotices);
            this.Controls.Add(this.lblProductInfo);
            this.Controls.Add(this.clsbEvents);
            this.Controls.Add(this.clsbPriority);
            this.Controls.Add(this.clsbStock);
            this.Controls.Add(this.pbxBar);
            this.Controls.Add(this.clsbOrders);
            this.Controls.Add(this.pictureBox2);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Notices";
            this.Text = "FormNotices";
            this.Load += new System.EventHandler(this.FormNotices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNoNotices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            this.pnlReviewDateFilter.ResumeLayout(false);
            this.pnlReviewDateFilter.PerformLayout();
            this.pnlIssueDateFilter.ResumeLayout(false);
            this.pnlIssueDateFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblProductInfo;
        private System.Windows.Forms.PictureBox pbxBar;
        private System.Windows.Forms.FlowLayoutPanel flpNotices;
        private System.Windows.Forms.CheckedListBox clsbPriority;
        private System.Windows.Forms.CheckedListBox clsbStock;
        private System.Windows.Forms.CheckedListBox clsbOrders;
        private System.Windows.Forms.Button btnDateIssued;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.CheckedListBox clsbEvents;
        private System.Windows.Forms.RadioButton rbtn1weekReview;
        private System.Windows.Forms.RadioButton rbtn1dayReview;
        private System.Windows.Forms.RadioButton rbtnOlderReview;
        private System.Windows.Forms.RadioButton rbtn3daysReview;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.PictureBox pbxNoNotices;
        private System.Windows.Forms.Label lblNoNotices;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnReviewOrder;
        private System.Windows.Forms.CheckBox chbxArchived;
        private System.Windows.Forms.CheckBox chbxDismissed;
        private System.Windows.Forms.CheckBox chbxActive;
        private System.Windows.Forms.RadioButton rbtn3days;
        private System.Windows.Forms.RadioButton rbtnOlder;
        private System.Windows.Forms.RadioButton rbtnDay;
        private System.Windows.Forms.RadioButton rbtn1week;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Button btnPriorityOrder;
        private System.Windows.Forms.Button btnArchived;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnDismissed;
        private System.Windows.Forms.PictureBox btnRefresh;
        private System.Windows.Forms.Panel pnlReviewDateFilter;
        private System.Windows.Forms.Panel pnlIssueDateFilter;
        private System.Windows.Forms.Label lblEvents;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label lblReview;
    }
}