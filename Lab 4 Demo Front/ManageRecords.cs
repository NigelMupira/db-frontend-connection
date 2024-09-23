using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_4_Demo_Front
{

    public partial class ManageRecords : Form
    {
        // Connection string to connect to your SQL Server
        private readonly string connectionString = "Data Source=BEASTPC;Initial Catalog=Lab4DemoDB;Integrated Security=True;"; // Trust Server Certificate=True
        public static int selectedStudentID { get; private set; }

        public ManageRecords()
        {
            InitializeComponent();
        }

        private void ManageRecords_Load(object sender, EventArgs e)
        {
        }

        public void DisplayStudentRecords(string department)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL query to display the StudentRecords table
                string query = $"SELECT * FROM {department}";

                SqlCommand command = new SqlCommand(query, connection);

                // Create a data adapter with the query
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                // Create a new DataTable to hold the data
                DataTable dataTable = new DataTable();

                try
                {
                    // Fill the DataTable with data from the database
                    adapter.Fill(dataTable);

                    // Set the DataGridView's DataSource to the DataTable
                    dgvStudentRecords.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Catch any exception when trying display the data in the DataGridView
                    MessageBox.Show("Error displaying records: " + ex.Message, "Data Collection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                if (department == "StudentRecords")
                {
                    // Resize the columns of the data grid view
                    dgvStudentRecords.Columns["StudentID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    dgvStudentRecords.Columns["Gender"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    dgvStudentRecords.Columns["School"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    dgvStudentRecords.Columns["Course"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                    // Align the headers of the following columns to the mid center
                    dgvStudentRecords.Columns["StudentID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvStudentRecords.Columns["Gender"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvStudentRecords.Columns["School"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvStudentRecords.Columns["Course"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    // Align the content under those columns to the mid center of their cells too
                    dgvStudentRecords.Columns["StudentID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvStudentRecords.Columns["Gender"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvStudentRecords.Columns["School"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvStudentRecords.Columns["Course"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    // Rename the hearders of the table displayed
                    dgvStudentRecords.Columns["StudentID"].HeaderText = "ENTRY #";
                    dgvStudentRecords.Columns["LastName"].HeaderText = "LAST NAME";
                    dgvStudentRecords.Columns["FirstName"].HeaderText = "FIRST NAME";
                    dgvStudentRecords.Columns["DateOfBirth"].HeaderText = "D.O.B.";
                    dgvStudentRecords.Columns["Gender"].HeaderText = "GENDER";
                    dgvStudentRecords.Columns["NationalID"].HeaderText = "NATIONAL ID";
                    dgvStudentRecords.Columns["RegNumber"].HeaderText = "REG NUMBER";
                    dgvStudentRecords.Columns["School"].HeaderText = "SCHOOL";
                    dgvStudentRecords.Columns["Course"].HeaderText = "COURSE";
                    dgvStudentRecords.Columns["Phone"].HeaderText = "PHONE";
                    dgvStudentRecords.Columns["Email"].HeaderText = "EMAIL";
                    dgvStudentRecords.Columns["HITmail"].HeaderText = "HITMAIL";
                }
                else
                {
                    btnEdit.Enabled = false;
                }
            }
        }

        private void dgvStudentRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check for valid row index
            {
                dgvStudentRecords.ClearSelection(); // Clear the current selection
                dgvStudentRecords.Rows[e.RowIndex].Selected = true; // Select the clicked row

                // Check if the current cell is not null
                if (dgvStudentRecords.CurrentCell.OwningRow == null)
                {
                    // If the current cell is null, deselect the current cell
                    dgvStudentRecords.CurrentCell.Selected = false;
                }
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            var addRecord = new AddRecord(this.ActiveMdiChild);
            addRecord.MdiParent = this.MdiParent; // Set the parent form to be the main window
            addRecord.Show(); // Show the add record form in the main window
            addRecord.Dock = DockStyle.Fill; // Dock the form to fill the parent form
            this.Close();
        }

        private void dgvStudentRecords_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudentRecords.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvStudentRecords.SelectedRows[0];
                selectedStudentID = Convert.ToInt32(selectedRow.Cells["StudentID"].Value);
            }
            else
            {
                selectedStudentID = -1; // Reset the selectedStudentID if no row is selected
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (dgvStudentRecords.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvStudentRecords.SelectedRows[0];

                // Retrieve data from the selected row
                string lastName = selectedRow.Cells["LastName"].Value.ToString();
                string firstName = selectedRow.Cells["FirstName"].Value.ToString();
                DateTime dateOfBirth = (DateTime)selectedRow.Cells["DateOfBirth"].Value;
                string gender = selectedRow.Cells["Gender"].Value.ToString();
                string nationalID = selectedRow.Cells["NationalID"].Value.ToString();
                string regNumber = selectedRow.Cells["RegNumber"].Value.ToString();
                string school = selectedRow.Cells["School"].Value.ToString();
                string course = selectedRow.Cells["Course"].Value.ToString();
                string phone = selectedRow.Cells["Phone"].Value.ToString();
                string email = selectedRow.Cells["Email"].Value.ToString();
                string hitmail = selectedRow.Cells["HITmail"].Value.ToString();

                // Open the AddRecord form with data filled
                AddRecord addRecord = new AddRecord(this.ActiveMdiChild);
                addRecord.SetEditState(true);
                addRecord.FillDataForEdit(lastName, firstName, dateOfBirth, gender, nationalID, regNumber, school, course, phone, email, hitmail);
                addRecord.MdiParent = this.MdiParent; // Assuming this form is a child of MainWindow
                addRecord.Show();
                addRecord.Dock = DockStyle.Fill; // Dock the form to fill the parent form
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a record to edit.", "Record Select", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                if (dgvStudentRecords.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvStudentRecords.SelectedRows[0];
                    int studentID = Convert.ToInt32(selectedRow.Cells["StudentID"].Value);

                    // Delete record from dgvStudentRecords
                    dgvStudentRecords.Rows.Remove(selectedRow);

                    // Delete corresponding entries from other tables in the database
                    DeleteFromDatabase(studentID);
                }
                else
                {
                    // If no record is selected to delete raise an error
                    MessageBox.Show("Please select a record to delete.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void DeleteFromDatabase(int studentID)
        {
            // Execute SQL DELETE commands to delete corresponding entries from all tables
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Delete corresponding entries from PersonalDetails table
                    using (SqlCommand command = new SqlCommand("DELETE FROM PersonalDetails WHERE StudentID = @StudentID", connection, transaction))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentID);
                        command.ExecuteNonQuery();
                    }

                    // Delete corresponding entries from SIETdepartment table
                    using (SqlCommand command = new SqlCommand("DELETE FROM SIETdepartment WHERE StudentID = @StudentID", connection, transaction))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentID);
                        command.ExecuteNonQuery();
                    }

                    // Delete corresponding entries from SISTdepartment table
                    using (SqlCommand command = new SqlCommand("DELETE FROM SISTdepartment WHERE StudentID = @StudentID", connection, transaction))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentID);
                        command.ExecuteNonQuery();
                    }

                    // Delete corresponding entries from SAHSdepartment table
                    using (SqlCommand command = new SqlCommand("DELETE FROM SAHSdepartment WHERE StudentID = @StudentID", connection, transaction))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentID);
                        command.ExecuteNonQuery();
                    }

                    // Delete corresponding entries from SBMSdepartment table
                    using (SqlCommand command = new SqlCommand("DELETE FROM SBMSdepartment WHERE StudentID = @StudentID", connection, transaction))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentID);
                        command.ExecuteNonQuery();
                    }

                    // Delete corresponding entries from SIITdepartment table
                    using (SqlCommand command = new SqlCommand("DELETE FROM SIITdepartment WHERE StudentID = @StudentID", connection, transaction))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentID);
                        command.ExecuteNonQuery();
                    }

                    // Finally, delete the record from StudentRecords table
                    using (SqlCommand command = new SqlCommand("DELETE FROM StudentRecords WHERE StudentID = @StudentID", connection, transaction))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentID);
                        command.ExecuteNonQuery();
                    }

                    // Commit the transaction
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error deleting records: " + ex.Message, "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
