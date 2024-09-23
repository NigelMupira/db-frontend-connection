using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Lab_4_Demo_Front
{

    public partial class AddRecord : Form
    {
        // Connection string to connect to your SQL Server
        // Because I have one SQL Server instance on my machine, MSSQLSERVER, I can use the following connection string
        private readonly string connectionString = "Data Source=BEASTPC;Initial Catalog=Lab4DemoDB;Integrated Security=True;"; // Trust Server Certificate=True
        // If you have a named instance; i.e., there are multiple server instances, e.g., MSSQLSERVER, SQLEXPRESS, etc.; you need to specify the server name
        // private readonly string connectionString = "Data Source=BEASTPC\\MSSQLSERVER;...";
        private readonly Form previousForm;

        public AddRecord(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
        }

        private void AddRecord_Load(object sender, EventArgs e)
        {
            LoadSchools(); // Call a method to populate the school combobox
        }

        public void SetEditState(bool isEditing)
        {
            btnSave.Visible = !isEditing;
            btnUpdate.Visible = isEditing;
        }

        private void LoadSchools()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT School FROM Schools WHERE School <> ''";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string school = reader["School"].ToString();
                            cbSchool.Items.Add(school);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading schools: " + ex.Message, "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cbSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSchool = cbSchool.SelectedItem != null ? cbSchool.SelectedItem.ToString() : string.Empty;
            string courseColumn = "";

            switch (selectedSchool)
            {
                case "SIET":
                    courseColumn = "SchoolSIET";
                    break;
                case "SIST":
                    courseColumn = "SchoolSIST";
                    break;
                case "SAHS":
                    courseColumn = "SchoolSAHS";
                    break;
                case "SBMS":
                    courseColumn = "SchoolSBMS";
                    break;
                case "SIIT":
                    courseColumn = "SchoolSIIT";
                    break;
                default:
                    courseColumn = "";
                    break;
            }

            LoadCourses(courseColumn);
        }

        private void LoadCourses(string courseColumn)
        {
            cbCourse.Items.Clear();

            if (string.IsNullOrEmpty(courseColumn))
                return;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT {courseColumn} FROM Schools WHERE {courseColumn} <> ''";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string course = reader[courseColumn].ToString();
                            cbCourse.Items.Add(course);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading courses: " + ex.Message, "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close(); // Close the current form
            // Show the previously active child form if it's not null
            if (previousForm != null && previousForm.MdiParent != null)
            {
                previousForm.Show(); // Show the previously active child form
            }
            MessageBox.Show("The form that was active before AddRecord.cs should now be displayed as the MdiChild but i can't figure out how.\n\n" +
                "This message is to remind me to fix this functionality", "Under construction!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Reset the form for more input
            tbName.Clear(); // Clear the first name input field
            tbSurname.Clear(); // Clear the last name input field
            dtDOB.Value = DateTime.Now; // Reset the date of birth input field
            // Uncheck the radio buttons
            rbMale.Checked = false;
            rbFemale.Checked = false;
            tbNatID.Clear(); // Clear the national ID input field
            tbRegNum.Clear(); // Clear the registration number input field
            // Empty the dropdown lists' text fields
            cbSchool.SelectedIndex = -1;
            cbCourse.SelectedIndex = -1;
            tbPhone.Clear(); // Clear the phone number input field
            tbEmail.Clear(); // Clear the email input field
            tbHITmail.Clear(); // Clear the HITmail input field
        }

        private string GetDepartment(string school)
        {
            switch (school)
            {
                case "SIET":
                    return "SIETdepartment";
                case "SIST":
                    return "SISTdepartment";
                case "SAHS":
                    return "SAHSdepartment";
                case "SBMS":
                    return "SBMSdepartment";
                case "SIIT":
                    return "SIITdepartment";
                default:
                    return string.Empty;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try  // Try to save the data to the database
            {
                string firstName = tbName.Text; // Get the first name from the input field
                string lastName = tbSurname.Text; // Get the last name from the input field
                DateTime dateOfBirth = dtDOB.Value.Date; // Get the date of birth from the input field
                // If rbMale is checked then gender = male, else gender = female
                string gender = rbMale.Checked ? "M" : "F";
                string nationalID = tbNatID.Text; // Get the national ID from the input field
                string regNumber = tbRegNum.Text; // Get the registration number from the input field
                // If cbSchool.SelectedItem is not null then school = selected option, else school = empty string
                string school = cbSchool.SelectedItem != null ? cbSchool.SelectedItem.ToString() : string.Empty;
                // If cbCourse.SelectedItem is not null then course = selected option, else course = empty string
                string course = cbCourse.SelectedItem != null ? cbCourse.SelectedItem.ToString() : string.Empty;
                string phone = tbPhone.Text; // Get the phone number from the input field
                string email = tbEmail.Text; // Get the email from the input field
                string hitmail = tbHITmail.Text; // Get the HITmail from the input field

                var isValid = true; // Flag to check if the input data is valid
                // Flag to check if any of the input fields are empty
                var emptyFields = string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(nationalID)
                    || string.IsNullOrWhiteSpace(regNumber) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(hitmail);

                var errorMessage = string.Empty; // Error message to display if the input data is invalid

                if (emptyFields == true)
                {
                    // If any of the input fields are empty then
                    isValid = false; // raise the flag to false
                    errorMessage += "EHIT001: Please fill in all fields!\n"; // and display an error message
                }
                else
                {
                    // Else if specific fields are empty then display the corresponding error message
                    if ((rbMale.Checked || rbFemale.Checked) == false)
                    {
                        // If no gender is selected then
                        isValid = false; // raise the flag to false
                        errorMessage += "EHIT002: Please select a gender.\n"; // and display an error message
                    }

                    if (string.IsNullOrEmpty(school) || string.IsNullOrEmpty(course))
                    {
                        // If no school or course is selected then
                        isValid = false; // raise the flag to false
                        errorMessage += "EHIT004: Please select your school and program.\n"; // and display an error message
                    }
                }

                if (dateOfBirth > DateTime.Now.Date)
                {
                    // If the date of birth is greater than the current date then
                    isValid = false; // raise the flag to false
                    errorMessage += "EHIT003: Invalid date of birth!\n"; // and display an error message
                }

                try // Try to parse the phone number to an integer
                {
                    long.Parse(phone);
                }
                catch (FormatException) // Catch the exception if the phone number is not an integer
                {
                    isValid = false; // Raise the isValid flag to false
                    errorMessage += "EHIT005: Invalid phone number! Must only contain digits.\n"; // Display an error message
                }

                if (phone.Length != 12)
                {
                    // If the phone number is not 12 digits long then
                    isValid = false; // raise the flag to false
                    errorMessage += "EHIT006: Invalid phone number!\n"; // and display an error message
                }

                if ((!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(hitmail)) == true && (email.Contains("@") == false || hitmail.Contains("@hit.ac.zw") == false))
                {
                    // If email or hitmail is not empty but invalid then
                    isValid = false; // raise the flag to false
                    errorMessage += "EHIT007: Invalid Email or HITmail!\n"; // and display an error message
                }

                if (isValid)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlTransaction transaction = connection.BeginTransaction();

                        try
                        {
                            // Insert data into StudentRecords table
                            int studentID;
                            using (SqlCommand command = new SqlCommand("INSERT INTO StudentRecords (LastName, FirstName, DateOfBirth, Gender, NationalID, RegNumber, School, Course, Phone, Email, HITmail) OUTPUT INSERTED.StudentID VALUES (@LastName, @FirstName, @DateOfBirth, @Gender, @NationalID, @RegNumber, @School, @Course, @Phone, @Email, @HITmail)", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@LastName", lastName);
                                command.Parameters.AddWithValue("@FirstName", firstName);
                                command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                                command.Parameters.AddWithValue("@Gender", gender);
                                command.Parameters.AddWithValue("@NationalID", nationalID);
                                command.Parameters.AddWithValue("@RegNumber", regNumber);
                                command.Parameters.AddWithValue("@School", school);
                                command.Parameters.AddWithValue("@Course", course);
                                command.Parameters.AddWithValue("@Phone", phone);
                                command.Parameters.AddWithValue("@Email", email);
                                command.Parameters.AddWithValue("@HITmail", hitmail);

                                studentID = (int)command.ExecuteScalar();
                            }

                            // Insert data into PersonalDetails table
                            using (SqlCommand command = new SqlCommand("INSERT INTO PersonalDetails (StudentID, LastName, FirstName, DateOfBirth, Gender, NationalID, Phone, Email) VALUES (@StudentID, @LastName, @FirstName, @DateOfBirth, @Gender, @NationalID, @Phone, @Email)", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@StudentID", studentID);
                                command.Parameters.AddWithValue("@LastName", lastName);
                                command.Parameters.AddWithValue("@FirstName", firstName);
                                command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                                command.Parameters.AddWithValue("@Gender", gender);
                                command.Parameters.AddWithValue("@NationalID", nationalID);
                                command.Parameters.AddWithValue("@Phone", phone);
                                command.Parameters.AddWithValue("@Email", email);

                                command.ExecuteNonQuery();
                            }

                            // Insert data into respective departmental table
                            if (!string.IsNullOrEmpty(school) && !string.IsNullOrEmpty(course))
                            {
                                string departmentTable = GetDepartment(school);
                                if (!string.IsNullOrEmpty(departmentTable))
                                {
                                    using (SqlCommand command = new SqlCommand($"INSERT INTO {departmentTable} (StudentID, LastName, RegNumber, Course, Email, HITmail) VALUES (@StudentID, @LastName, @RegNumber, @Course, @Email, @HITmail)", connection, transaction))
                                    {
                                        command.Parameters.AddWithValue("@StudentID", studentID);
                                        command.Parameters.AddWithValue("@LastName", lastName);
                                        command.Parameters.AddWithValue("@RegNumber", regNumber);
                                        command.Parameters.AddWithValue("@Course", course);
                                        command.Parameters.AddWithValue("@Email", email);
                                        command.Parameters.AddWithValue("@HITmail", hitmail);

                                        command.ExecuteNonQuery();
                                    }
                                }
                            }

                            // Commit the transaction
                            transaction.Commit();

                            // Display a success message once the data is saved to the database
                            MessageBox.Show("Data saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear the input fields once the data is saved
                            btnReset_Click(sender, e);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error saving input: " + ex.Message, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    // If the input data is invalid then display the corresponding error message
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Catch any exception that occurs during the saving the input data and display an error
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FillDataForEdit(string lastName, string firstName, DateTime dateOfBirth, string gender, string nationalID, string regNumber, string school, string course, string phone, string email, string hitmail)
        {
            tbSurname.Text = lastName;
            tbName.Text = firstName;
            dtDOB.Value = dateOfBirth;
            if (gender == "M")
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
            tbNatID.Text = nationalID;
            tbRegNum.Text = regNumber;
            cbSchool.SelectedItem = school;
            cbCourse.SelectedItem = course;
            tbPhone.Text = phone;
            tbEmail.Text = email;
            tbHITmail.Text = hitmail;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Retrieve the StudentID of the edited record
            int studentID = ManageRecords.selectedStudentID;

            if (studentID != -1)
            {
                // Update the record in StudentRecords table
                UpdateStudentRecord(studentID);

                // Update the record in PersonalDetails table
                UpdatePersonalDetails(studentID);

                // Update the record in other department tables if necessary
                UpdateDepartmentTable("SIETdepartment", studentID);
                UpdateDepartmentTable("SISTdepartment", studentID);
                UpdateDepartmentTable("SAHSdepartment", studentID);
                UpdateDepartmentTable("SBMSdepartment", studentID);
                UpdateDepartmentTable("SIITdepartment", studentID);


                // Inform the user that changes have been saved
                DialogResult click = MessageBox.Show("Changes saved successfully.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (click == DialogResult.OK)
                {
                    // Close the current form
                    this.Close();
                    // Show the manage records form
                    ManageRecords manageRecords = new ManageRecords();
                    manageRecords.DisplayStudentRecords("StudentRecords");
                    manageRecords.MdiParent = this.MdiParent;
                    manageRecords.Show();
                    manageRecords.Dock = DockStyle.Fill;
                }
            }
            else
            {
                MessageBox.Show("StudentID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStudentRecord(int studentID)
        {
            // Execute SQL UPDATE command to update the record in StudentRecords table
            string query = "UPDATE StudentRecords SET LastName = @LastName, FirstName = @FirstName, DateOfBirth = @DateOfBirth, Gender = @Gender, NationalID = @NationalID, RegNumber = @RegNumber, School = @School, Course = @Course, Phone = @Phone, Email = @Email, HITmail = @HITmail WHERE StudentID = @StudentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LastName", tbSurname.Text);
                    command.Parameters.AddWithValue("@FirstName", tbName.Text);
                    command.Parameters.AddWithValue("@DateOfBirth", dtDOB.Value);
                    command.Parameters.AddWithValue("@Gender", rbMale.Checked ? "M" : "F");
                    command.Parameters.AddWithValue("@NationalID", tbNatID.Text);
                    command.Parameters.AddWithValue("@RegNumber", tbRegNum.Text);
                    command.Parameters.AddWithValue("@School", cbSchool.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@Course", cbCourse.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@Phone", tbPhone.Text);
                    command.Parameters.AddWithValue("@Email", tbEmail.Text);
                    command.Parameters.AddWithValue("@HITmail", tbHITmail.Text);
                    command.Parameters.AddWithValue("@StudentID", studentID);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void UpdatePersonalDetails(int studentID)
        {
            // Execute SQL UPDATE command to update the record in PersonalDetails table
            string query = "UPDATE PersonalDetails SET LastName = @LastName, FirstName = @FirstName, DateOfBirth = @DateOfBirth, Gender = @Gender, NationalID = @NationalID, Phone = @Phone, Email = @Email WHERE StudentID = @StudentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LastName", tbSurname.Text);
                    command.Parameters.AddWithValue("@FirstName", tbName.Text);
                    command.Parameters.AddWithValue("@DateOfBirth", dtDOB.Value);
                    command.Parameters.AddWithValue("@Gender", rbMale.Checked ? "M" : "F");
                    command.Parameters.AddWithValue("@NationalID", tbNatID.Text);
                    command.Parameters.AddWithValue("@Phone", tbPhone.Text);
                    command.Parameters.AddWithValue("@Email", tbEmail.Text);
                    command.Parameters.AddWithValue("@StudentID", studentID);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void UpdateDepartmentTable(string tableName, int studentID)
        {
            // Execute SQL UPDATE command to update the record in the specified department table
            string query = $"UPDATE {tableName} SET LastName = @LastName, RegNumber = @RegNumber, Course = @Course, Email = @Email, HITmail = @HITmail WHERE StudentID = @StudentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LastName", tbSurname.Text);
                    command.Parameters.AddWithValue("@RegNumber", tbRegNum.Text);
                    command.Parameters.AddWithValue("@Course", cbCourse.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@Email", tbEmail.Text);
                    command.Parameters.AddWithValue("@HITmail", tbHITmail.Text);
                    command.Parameters.AddWithValue("@StudentID", studentID);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
