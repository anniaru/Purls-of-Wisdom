namespace YarnShop
{
    partial class AttendeeBox
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
            this.lblAttendee = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAttendee
            // 
            this.lblAttendee.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttendee.Location = new System.Drawing.Point(0, 0);
            this.lblAttendee.Name = "lblAttendee";
            this.lblAttendee.Size = new System.Drawing.Size(255, 20);
            this.lblAttendee.TabIndex = 0;
            this.lblAttendee.Text = "label1";
            this.lblAttendee.Click += new System.EventHandler(this.lblAttendee_Click);
            this.lblAttendee.MouseEnter += new System.EventHandler(this.lblAttendee_MouseEnter);
            this.lblAttendee.MouseLeave += new System.EventHandler(this.lblAttendee_MouseLeave);
            // 
            // AttendeeBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAttendee);
            this.Name = "AttendeeBox";
            this.Size = new System.Drawing.Size(255, 20);
            this.Load += new System.EventHandler(this.AttendeeBox_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAttendee;
    }
}
