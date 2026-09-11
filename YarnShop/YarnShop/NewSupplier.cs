using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarnShop
{
    public partial class NewSupplier : Form
    {
        // Make form draggable
        bool drag = false;
        Point dragCursor;
        Point dragForm;

        // CUSTOM DRAGGABLE FORM BORDER
        private void pbxBar_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            dragCursor = Cursor.Position;
            dragForm = Location;
        }
        private void pbxBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point difference = Point.Subtract(Cursor.Position, new Size(dragCursor));
                Location = Point.Add(dragForm, new Size(difference));
            }
        }
        private void pbxBar_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to discard all changes?", "Discard Creator", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
        public NewSupplier()
        {
            Visible = false;
            InitializeComponent();
        }

        // CREATE SUPPLIER
        private void FormNewSupplier_Load(object sender, EventArgs e)
        {
            Visible = true;
        }
        private bool validString(string text) // Checks if the string is valid i.e. only contains valid alphanumerical characters and certain special characters
        {

            string allowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -_.,&/():'";

            // Check each character
            foreach (char c in text)
            {
                bool found = false;
                for (int i = 0; i < allowedCharacters.Length; i++)
                {
                    if (c == allowedCharacters[i])
                    {
                        found = true;
                    }
                }
                if (!found)
                {
                    MessageBox.Show("Input valid details in all fields.", "Invalid Inputs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return found;
                }
            }

            return true;

        }
        private bool validContactInfo()
        {
            // Checks if there is at least a phone number or email address entered.
            // Checks that any inputs are valid.
            if (!string.IsNullOrWhiteSpace(tbxEmailAdd.Text) && !string.IsNullOrWhiteSpace(tbxPhoneNum.Text)) // If both fields have inputs in, both need to be validated
            {
                if (!validEmailAddress(tbxEmailAdd.Text))
                {
                    return false;
                }
                if (!validPhoneNumber(tbxPhoneNum.Text))
                {
                    return false;
                }
                return true;
            }
            else if (!string.IsNullOrWhiteSpace(tbxEmailAdd.Text))
            {
                if (!validEmailAddress(tbxEmailAdd.Text))
                {
                    return false;
                }
                return true;
            }
            else if (!string.IsNullOrWhiteSpace(tbxPhoneNum.Text))
            {
                if (!validPhoneNumber(tbxPhoneNum.Text))
                {
                    return false;
                }
                return true;
            }
            else
            {
                // No inputs for both fields
                return false;
            }
        }
        private bool validEmailAddress(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch
            {
                MessageBox.Show("Enter a valid email address.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool validPhoneNumber(string phoneNumber)
        {
            // Checks that the phone number entered is of a valid length i.e. longer than 7
            // Checks that the phone number entered does not consist of any letters
            string validCharacters = @"^[0-9+\s\-\(\)]+$";
            if (phoneNumber.Length > 7)
            {
                // Allows digits, plus signs, spaces, dashes, opening and closing parentheses
                if (Regex.Match(phoneNumber, validCharacters).Success)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Enter a valid phone number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                // Suppliers are often international, so validating all phone numbers for all international phone numbers would require the use of an external API

            }
            else
            {
                MessageBox.Show("Phone number must be longer than 7 characters.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void btnAddSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxSupplierName.Text) || (string.IsNullOrWhiteSpace(tbxEmailAdd.Text) && string.IsNullOrWhiteSpace(tbxPhoneNum.Text))) // Checks that name fields are filled in and one of phone number or email address is filled in
            {
                MessageBox.Show("Enter values in all required fields.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!validContactInfo() || !validString(tbxSupplierName.Text) || !validString(tbxAddress.Text) || !validString(tbxPostcode.Text))
            {

            }
            else
            {
                if (string.IsNullOrWhiteSpace(tbxEmailAdd.Text))
                {
                    tbxEmailAdd.Text = "N/A";
                }
                if (string.IsNullOrWhiteSpace(tbxPhoneNum.Text))
                {
                    tbxPhoneNum.Text = "N/A";
                }
                if (string.IsNullOrWhiteSpace(tbxAddress.Text))
                {
                    tbxAddress.Text = "N/A";
                }
                if (string.IsNullOrWhiteSpace(tbxPostcode.Text))
                {
                    tbxPostcode.Text = "N/A"; 
                }
                if (string.IsNullOrWhiteSpace(tbxURL.Text))
                {
                    tbxURL.Text = "N/A";
                }
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                OleDbCommand cmd = connection.CreateCommand();
                connection.Open();
                cmd.CommandText = "INSERT INTO TableSuppliers(SupplierName, PhoneNum, EmailAddress, Address, Postcode, URL) VALUES(@sn,@pn,@ea,@ad,@pc,@url)";
                cmd.Parameters.AddWithValue("@sn", tbxSupplierName.Text);
                cmd.Parameters.AddWithValue("@pn", tbxPhoneNum.Text);
                cmd.Parameters.AddWithValue("@ea", tbxEmailAdd.Text);
                cmd.Parameters.AddWithValue("@ad", tbxAddress.Text);
                cmd.Parameters.AddWithValue("@pc", tbxPostcode.Text);
                cmd.Parameters.AddWithValue("@url", tbxURL.Text);
                cmd.Connection = connection;
                int status = cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("New supplier added successfully.", "New Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
                
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxAddress.Text = "";
            tbxEmailAdd.Text = "";
            tbxPhoneNum.Text = "";
            tbxPostcode.Text = "";
            tbxSupplierName.Text = "";
            tbxURL.Text = "";
        }
    }
}
