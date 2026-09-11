namespace YarnShop
{
    partial class NoticeBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoticeBox));
            this.titleLabel = new System.Windows.Forms.Label();
            this.descLabel = new System.Windows.Forms.Label();
            this.priorityLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.pbxArchived = new System.Windows.Forms.PictureBox();
            this.NoticeOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GoToFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DismissToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.daysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArchived)).BeginInit();
            this.NoticeOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.titleLabel.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(492, 32);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "TITLE";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.titleLabel.MouseEnter += new System.EventHandler(this.titleLabel_MouseEnter);
            this.titleLabel.MouseLeave += new System.EventHandler(this.titleLabel_MouseLeave);
            // 
            // descLabel
            // 
            this.descLabel.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descLabel.Location = new System.Drawing.Point(36, 39);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(330, 64);
            this.descLabel.TabIndex = 1;
            this.descLabel.Text = "DESCRIPTION";
            // 
            // priorityLabel
            // 
            this.priorityLabel.AutoSize = true;
            this.priorityLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.priorityLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priorityLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(116)))), ((int)(((byte)(137)))));
            this.priorityLabel.Location = new System.Drawing.Point(3, 35);
            this.priorityLabel.Name = "priorityLabel";
            this.priorityLabel.Size = new System.Drawing.Size(36, 28);
            this.priorityLabel.TabIndex = 2;
            this.priorityLabel.Text = "!!!";
            this.priorityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timeLabel
            // 
            this.timeLabel.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(372, 39);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(116, 64);
            this.timeLabel.TabIndex = 3;
            this.timeLabel.Text = "1hr";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pbxArchived
            // 
            this.pbxArchived.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pbxArchived.Image = ((System.Drawing.Image)(resources.GetObject("pbxArchived.Image")));
            this.pbxArchived.Location = new System.Drawing.Point(464, 79);
            this.pbxArchived.Name = "pbxArchived";
            this.pbxArchived.Size = new System.Drawing.Size(24, 24);
            this.pbxArchived.TabIndex = 171;
            this.pbxArchived.TabStop = false;
            // 
            // NoticeOptions
            // 
            this.NoticeOptions.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.NoticeOptions.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoticeOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GoToFormToolStripMenuItem,
            this.DismissToolStripMenuItem});
            this.NoticeOptions.Name = "NoticeOptions";
            this.NoticeOptions.Size = new System.Drawing.Size(170, 48);
            // 
            // GoToFormToolStripMenuItem
            // 
            this.GoToFormToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.GoToFormToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("GoToFormToolStripMenuItem.Image")));
            this.GoToFormToolStripMenuItem.Name = "GoToFormToolStripMenuItem";
            this.GoToFormToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.GoToFormToolStripMenuItem.Text = "Go To Products";
            this.GoToFormToolStripMenuItem.Click += new System.EventHandler(this.GoToFormToolStripMenuItem_Click);
            // 
            // DismissToolStripMenuItem
            // 
            this.DismissToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dayToolStripMenuItem,
            this.daysToolStripMenuItem,
            this.weekToolStripMenuItem});
            this.DismissToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DismissToolStripMenuItem.Image")));
            this.DismissToolStripMenuItem.Name = "DismissToolStripMenuItem";
            this.DismissToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.DismissToolStripMenuItem.Text = "Dismiss";
            // 
            // dayToolStripMenuItem
            // 
            this.dayToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dayToolStripMenuItem.Name = "dayToolStripMenuItem";
            this.dayToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.dayToolStripMenuItem.Text = "1 day";
            this.dayToolStripMenuItem.Click += new System.EventHandler(this.dayToolStripMenuItem_Click);
            // 
            // daysToolStripMenuItem
            // 
            this.daysToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.daysToolStripMenuItem.Name = "daysToolStripMenuItem";
            this.daysToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.daysToolStripMenuItem.Text = "3 days";
            this.daysToolStripMenuItem.Click += new System.EventHandler(this.daysToolStripMenuItem_Click);
            // 
            // weekToolStripMenuItem
            // 
            this.weekToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.weekToolStripMenuItem.Name = "weekToolStripMenuItem";
            this.weekToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.weekToolStripMenuItem.Text = "1 week";
            this.weekToolStripMenuItem.Click += new System.EventHandler(this.weekToolStripMenuItem_Click);
            // 
            // NoticeBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ContextMenuStrip = this.NoticeOptions;
            this.Controls.Add(this.pbxArchived);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.priorityLabel);
            this.Controls.Add(this.descLabel);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "NoticeBox";
            this.Size = new System.Drawing.Size(492, 106);
            this.Load += new System.EventHandler(this.NoticeBox1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxArchived)).EndInit();
            this.NoticeOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.Label priorityLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.PictureBox pbxArchived;
        private System.Windows.Forms.ContextMenuStrip NoticeOptions;
        private System.Windows.Forms.ToolStripMenuItem GoToFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DismissToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem daysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weekToolStripMenuItem;
    }
}
