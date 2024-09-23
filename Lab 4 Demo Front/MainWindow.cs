using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_4_Demo_Front
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            OpenHomeWindow();
        }

        private void OpenHomeWindow()
        {
            CloseActiveChildForm(); // Close any active child form
            var homeWindow = new HomeWindow();
            homeWindow.MdiParent = this;
            homeWindow.Dock = DockStyle.Fill;
            homeWindow.Show();
        }

        private void CloseActiveChildForm()
        {
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseActiveChildForm(); // Close any active child form
            var homeWindow = new HomeWindow();
            homeWindow.MdiParent = this; // Sets the parent form of the child form
            homeWindow.Show(); // Shows the form as a child form
            homeWindow.Dock = DockStyle.Fill; // Dock the form to fill the parent form
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseActiveChildForm(); // Close any active child form
            var addRecord = new AddRecord(this.ActiveMdiChild); // Pass reference to the active child form
            addRecord.SetEditState(false);
            addRecord.MdiParent = this; // Sets the parent form of the child form
            addRecord.Show(); // Shows the form as a child form
            addRecord.Dock = DockStyle.Fill; // Dock the form to fill the parent form
        }

        private void manageRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseActiveChildForm(); // Close any active child form
            var manageRecords = new ManageRecords(); // Creates an instance of the ManageRecords form
            manageRecords.DisplayStudentRecords("StudentRecords"); // Display all student records when the form is loaded
            manageRecords.MdiParent = this; // Sets the parent form of the child form
            manageRecords.Show(); // Shows the form as a child form
            manageRecords.Dock = DockStyle.Fill; // Dock the form to fill the parent form
        }

        private void CreateManageRecordsForm(string department)
        {
            CloseActiveChildForm(); // Close any active child form
            var manageRecords = new ManageRecords(); // Create a new instance of the ManageRecords form

            // Set the department to display based on the ToolStripMenuItem clicked
            switch (department)
            {
                case "School of IET":
                    manageRecords.DisplayStudentRecords("SIETdepartment");
                    break;
                case "School of IST":
                    manageRecords.DisplayStudentRecords("SISTdepartment");
                    break;
                case "School of AHS":
                    manageRecords.DisplayStudentRecords("SAHSdepartment");
                    break;
                case "School of BMS":
                    manageRecords.DisplayStudentRecords("SBMSdepartment");
                    break;
                case "School of IIT":
                    manageRecords.DisplayStudentRecords("SIITdepartment");
                    break;
                default:
                    MessageBox.Show("Department not supported.");
                    return;
            }

            manageRecords.MdiParent = this; // Sets the parent form of the child form
            manageRecords.Show(); // Shows the form as a child form
            manageRecords.Dock = DockStyle.Fill; // Dock the form to fill the parent form
        }

        private void schoolOfIETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateManageRecordsForm("School of IET");
            MessageBox.Show("Change 'MANAGE STUDENT RECORDS' to the appropriate table being viewed, e.g., 'SCHOOL OF IST'", "Change Label Text", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void schoolOfISTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateManageRecordsForm("School of IST");
            MessageBox.Show("Change 'MANAGE STUDENT RECORDS' to the appropriate table being viewed, e.g., 'SCHOOL OF IST'", "Change Label Text", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void schoolOfAHSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateManageRecordsForm("School of AHS");
            MessageBox.Show("Change 'MANAGE STUDENT RECORDS' to the appropriate table being viewed, e.g., 'SCHOOL OF IST'", "Change Label Text", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void schoolOfBMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateManageRecordsForm("School of BMS");
            MessageBox.Show("Change 'MANAGE STUDENT RECORDS' to the appropriate table being viewed, e.g., 'SCHOOL OF IST'", "Change Label Text", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void schoolOfIITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateManageRecordsForm("School of IIT");
            MessageBox.Show("Change 'MANAGE STUDENT RECORDS' to the appropriate table being viewed, e.g., 'SCHOOL OF IST'", "Change Label Text", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
