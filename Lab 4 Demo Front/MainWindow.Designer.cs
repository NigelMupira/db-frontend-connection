namespace Lab_4_Demo_Front
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schoolOfIETToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schoolOfISTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schoolOfAHSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schoolOfBMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schoolOfIITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.studentRecordsToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // studentRecordsToolStripMenuItem
            // 
            this.studentRecordsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStudentToolStripMenuItem,
            this.manageRecordsToolStripMenuItem});
            this.studentRecordsToolStripMenuItem.Name = "studentRecordsToolStripMenuItem";
            this.studentRecordsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.studentRecordsToolStripMenuItem.Text = "Registry";
            // 
            // addStudentToolStripMenuItem
            // 
            this.addStudentToolStripMenuItem.Name = "addStudentToolStripMenuItem";
            this.addStudentToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.addStudentToolStripMenuItem.Text = "Add Student";
            this.addStudentToolStripMenuItem.Click += new System.EventHandler(this.addStudentToolStripMenuItem_Click);
            // 
            // manageRecordsToolStripMenuItem
            // 
            this.manageRecordsToolStripMenuItem.Name = "manageRecordsToolStripMenuItem";
            this.manageRecordsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.manageRecordsToolStripMenuItem.Text = "Manage Records";
            this.manageRecordsToolStripMenuItem.Click += new System.EventHandler(this.manageRecordsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schoolOfIETToolStripMenuItem,
            this.schoolOfISTToolStripMenuItem,
            this.schoolOfAHSToolStripMenuItem,
            this.schoolOfBMSToolStripMenuItem,
            this.schoolOfIITToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(133, 20);
            this.viewToolStripMenuItem.Text = "View Student Records";
            // 
            // schoolOfIETToolStripMenuItem
            // 
            this.schoolOfIETToolStripMenuItem.Name = "schoolOfIETToolStripMenuItem";
            this.schoolOfIETToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.schoolOfIETToolStripMenuItem.Text = "School of IET";
            this.schoolOfIETToolStripMenuItem.Click += new System.EventHandler(this.schoolOfIETToolStripMenuItem_Click);
            // 
            // schoolOfISTToolStripMenuItem
            // 
            this.schoolOfISTToolStripMenuItem.Name = "schoolOfISTToolStripMenuItem";
            this.schoolOfISTToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.schoolOfISTToolStripMenuItem.Text = "School of IST";
            this.schoolOfISTToolStripMenuItem.Click += new System.EventHandler(this.schoolOfISTToolStripMenuItem_Click);
            // 
            // schoolOfAHSToolStripMenuItem
            // 
            this.schoolOfAHSToolStripMenuItem.Name = "schoolOfAHSToolStripMenuItem";
            this.schoolOfAHSToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.schoolOfAHSToolStripMenuItem.Text = "School of AHS";
            this.schoolOfAHSToolStripMenuItem.Click += new System.EventHandler(this.schoolOfAHSToolStripMenuItem_Click);
            // 
            // schoolOfBMSToolStripMenuItem
            // 
            this.schoolOfBMSToolStripMenuItem.Name = "schoolOfBMSToolStripMenuItem";
            this.schoolOfBMSToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.schoolOfBMSToolStripMenuItem.Text = "School of BMS";
            this.schoolOfBMSToolStripMenuItem.Click += new System.EventHandler(this.schoolOfBMSToolStripMenuItem_Click);
            // 
            // schoolOfIITToolStripMenuItem
            // 
            this.schoolOfIITToolStripMenuItem.Name = "schoolOfIITToolStripMenuItem";
            this.schoolOfIITToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.schoolOfIITToolStripMenuItem.Text = "School of IIT";
            this.schoolOfIITToolStripMenuItem.Click += new System.EventHandler(this.schoolOfIITToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Window";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem studentRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schoolOfIETToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schoolOfISTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schoolOfAHSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schoolOfBMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schoolOfIITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
    }
}

