using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace YarnShop
{
    
    public partial class NewEvent : Form
    {
        int index;
        int capacity = 5;
        List<string> skillLevel = new List<string>();

        List<EventAttendee> attendeeList = new List<EventAttendee>();
        List<EventAttendee> mainList = new List<EventAttendee>();
        WaitingListQueue paidWaitingList = new WaitingListQueue();
        WaitingListQueue unpaidWaitingList = new WaitingListQueue();
        List<EventAttendee> removedAttendees = new List<EventAttendee>(); // Used to keep track of attendees that have been removed from an existing event that is being edited, so records can be updated.
        List<EventAttendee> addedAttendees = new List<EventAttendee>(); // Used to keep track of attendees that are newly added to an existing event that is being edited
        List<EventAttendee> attendeesOffWaitingList = new List<EventAttendee>(); // Used to keep track of attendees that have been moved off the waiting list when editing an existing event
        EventAttendee selectedAttendee = null;
        AttendeeBox selectedBox;
        Customer currentCust = null;

        // Avoid recursive triggers of the value changed event
        bool updatingEndTime = false;
        bool updatingStartTime = false;

        bool waitinglist = false;
        bool selectingCust = false;
        bool paidStatusChanged = false;
        bool numGuestsChanged = false;
        private AttendeeBox attendeeBox;
        Event editEvent {  get; set; }

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
            Close();
        }
        public NewEvent(Event editEvent)
        {
            InitializeComponent();
            this.editEvent = editEvent;
        }
        private void FormNewEvent_Load(object sender, EventArgs e)
        {
            if (editEvent != null)
            {
                lblMakeEvent.Text = "EVENT EDITOR";
                btnAddSave.Text = "Save";
            }
            else
            {
                lblMakeEvent.Text = "EVENT CREATOR";
                btnAddSave.Text = "Add";
            }

            lblWaitingList.Visible = false;
            dtpStartTime.Format = DateTimePickerFormat.Time;
            dtpStartTime.ShowUpDown = true;
            dtpEndTime.Format = DateTimePickerFormat.Time;
            dtpEndTime.ShowUpDown = true;

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            OleDbDataReader reader;

            connection.Open();
            cmd.CommandText = "SELECT DISTINCT SkillLevel FROM TableEvents";
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if ((reader[0] != null) || (Convert.ToString(reader[0]) != ""))
                {
                    skillLevel.Add(Convert.ToString(reader[0]));
                }
                else
                {
                    continue;
                }
            }
            connection.Close();
            cbxSkillLevel.DataSource = null;
            cbxSkillLevel.DataSource = skillLevel;

            refresh();
        }

        private void refreshAttendees() // Shows all attendees in the list
        {
            flpAttendees.Controls.Clear();
            foreach (EventAttendee a in attendeeList)
            {
                attendeeBox = new AttendeeBox(a);
                flpAttendees.Controls.Add(attendeeBox);
                attendeeBox.AttendeeSelected += attendeeBox_AttendeeSelected;

            }
            refreshEventTbxs();
            highlightCustomersAdded();
        }
        private void refresh()
        {

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            OleDbDataReader reader;
            connection.Open();
            cmd.CommandText = "SELECT * FROM TableCustomers WHERE MemType <> 'Deleted' OR MemType <> 'Guest'";
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = reader;
            dgvCustomers.DataSource = bindingSource;
            connection.Close();

            if (editEvent != null) // Shows all event details if editing an event
            {
                attendeeList = editEvent.GetOrderedAttendeesList;
                mainList = editEvent.GetAttendingCustomers;
                paidWaitingList = editEvent.GetPaidWaitingListQueue;
                unpaidWaitingList = editEvent.GetUnpaidWaitingListQueue;
                tbxName.Text = editEvent.name;
                tbxHost.Text = editEvent.host;
                tbxNoOfAttendees.Text = editEvent.numAttendees.ToString();
                numCapacity.Value = editEvent.capacity;
                dtpEventDate.Value = editEvent.date;
                dtpStartTime.Value = editEvent.date + editEvent.startTime.TimeOfDay;
                dtpEndTime.Value = editEvent.date + editEvent.endTime.TimeOfDay;
                numMaxGuests.Text = editEvent.maxGuests.ToString();
                cbxSkillLevel.Text = editEvent.skillLevel.ToString();
                tbxPrice.Text = editEvent.price.ToString();
                tbxNoPaid.Text = editEvent.GetAttendingCustomersPaid.Count.ToString() + " / "+ CountAttendingCustomers(attendeeList);
                rtbxNotes.Text = editEvent.eventNotes;
                refreshAttendees();

                if (attendeeList.Count > 0)
                {
                    currentCust = attendeeList[0].customer;
                }
            }
            else
            {
                //Default
                tbxName.Text = string.Empty;
                tbxHost.Text = "Purls Of Wisdom";
                tbxPrice.Text = string.Empty;
                rtbxNotes.Text = string.Empty;
                tbxNoOfAttendees.Text = string.Empty;
                numCapacity.Value = 10;
                numMaxGuests.Value = 0;
                cbxSkillLevel.Text = string.Empty;

                index = 0;
                refreshCustomerInfo(0);
                refreshAttendees();

                dtpStartTime.Value.Subtract(dtpStartTime.Value);
                dtpStartTime.Value = DateTime.Today.Date.AddHours(9);
                dtpEndTime.Value.Subtract(dtpEndTime.Value);
                dtpEndTime.Value = DateTime.Today.Date.AddHours(10);
            }
            
        }
        private bool CustomerAdded(int id, List<EventAttendee> list)  // Checks the list of attendees to see if a customer has been added or not.
        {
            foreach (EventAttendee a in list)
            {
                if(a.customer.id == id)
                {
                    return true;
                }
            }
            return false;
        }
        private int CountAttendees(List<EventAttendee> attendees)
        {
            // Returns the total number of people in the list.

            int i = 0;
            foreach (EventAttendee attendee in attendees)
            {
                i += attendee.noOfAttendees;
            }
            return i;

        }

        private int CountAttendingCustomers(List<EventAttendee> attendees)
        {
            // Returns the total number of people in the list.

            int i = 0;
            foreach (EventAttendee attendee in attendees)
            {
                if (!attendee.waitingList)
                {
                    i += attendee.noOfAttendees;
                }
            }
            return i;
        }
        private void highlightCustomersAdded()// Searches through each customer in the dgv and highlights the customers that have already been added to the event attendees list.
        {
            foreach (DataGridViewRow row in dgvCustomers.Rows)
            {
                if (CustomerAdded(Convert.ToInt32(row.Cells[0].Value),attendeeList))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(50, 105, 50);
                    row.DefaultCellStyle.ForeColor = SystemColors.ControlLightLight;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = SystemColors.ControlLightLight;
                    row.DefaultCellStyle.ForeColor = SystemColors.ControlText;
                }
            }
        }
        private void refreshEventTbxs()// Updates the textboxes showing how many attendees are in the event and how many have paid.
        {
            tbxNoOfAttendees.Text = CountAttendees(mainList).ToString();
            int numPaid = 0;
            foreach(EventAttendee a in mainList)
            {
                if (a.paid)
                {
                    numPaid ++;
                }
            }
            tbxNoPaid.Text = numPaid.ToString() + "/"+ mainList.Count; // Sets label colour to red if the number of customers that have paid is less than the number of customers in the list
            if (editEvent != null)
            {
                if (editEvent.GetAttendingCustomersPaid.Count < editEvent.GetAttendingCustomers.Count)
                {
                    lblAttendeesPaid.ForeColor = Color.DarkRed;
                }
                else
                {
                    lblAttendeesPaid.ForeColor = SystemColors.ControlText;
                }
            }
        }
        private void updateWaitingListLabel() // Indicates when a customer will be added to the waiting list depending on the number of attendees currently, the capacity and the number of guests of the customer to be added
        {
            // Determines whether to show that the next customer to be added will be on the waiting list.

            if (CountAttendees(mainList) < numCapacity.Value)
            {
                lblWaitingList.Visible = false;
                waitinglist = false;
            }
            else
            {
                lblWaitingList.Visible = true;
                waitinglist = true;
            }
        }
        public bool ValidCost(string cost) // Checks if the cost entered can be converted to a double, which can then be rounded to 2 decimal places if required.
        {
            TypeConverter conv = TypeDescriptor.GetConverter(typeof(double));
            return conv.IsValid(cost);
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
        private void btnAddSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxName.Text) || string.IsNullOrWhiteSpace(tbxHost.Text) || string.IsNullOrWhiteSpace(cbxSkillLevel.Text))
            {
                MessageBox.Show("Enter values in all required fields.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!ValidCost(tbxPrice.Text))
            {
                MessageBox.Show("Enter a valid cost.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!validString(tbxName.Text)|| !validString(tbxHost.Text))
            {

            }
            else
            {
                if (string.IsNullOrEmpty(rtbxNotes.Text))
                {
                    rtbxNotes.Text = " ";
                }
                DateTime eventStartTime = dtpEventDate.Value.Date + dtpStartTime.Value.TimeOfDay;
                DateTime eventEndTime = dtpEventDate.Value.Date + dtpEndTime.Value.TimeOfDay;
                DialogResult result = MessageBox.Show("Save all changes?", "Save Event", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (editEvent != null)
                {
                        OleDbConnection connection = new OleDbConnection();
                        connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                        OleDbCommand cmd = connection.CreateCommand();
                        connection.Open();
                        cmd.CommandText = "UPDATE TableEvents SET EventName = @en, EventDate = @ed, EventStartTime = @est, EventEndTime = @eet, Host = @ho, Price = @pa, Capacity = @cap, MaxGuests = @max, SkillLevel = @ski, EventNotes = @evn WHERE EventID = @eid";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@en", tbxName.Text);
                        cmd.Parameters.AddWithValue("@ed", DateTime.Parse(dtpEventDate.Value.ToShortDateString()));
                        cmd.Parameters.AddWithValue("@est", DateTime.Parse(eventStartTime.ToShortTimeString()));
                        cmd.Parameters.AddWithValue("@eet", DateTime.Parse(eventEndTime.ToShortTimeString()));
                        cmd.Parameters.AddWithValue("@ho", tbxHost.Text);
                        cmd.Parameters.AddWithValue("@pr", tbxPrice.Text);
                        cmd.Parameters.AddWithValue("@cap", numCapacity.Value.ToString());
                        cmd.Parameters.AddWithValue("@max", numMaxGuests.Value.ToString());
                        cmd.Parameters.AddWithValue("@ski", cbxSkillLevel.Text);
                        cmd.Parameters.AddWithValue("@evn", rtbxNotes.Text);
                        cmd.Parameters.AddWithValue("@eid", editEvent.id);
                        cmd.Connection = connection;
                        int status = cmd.ExecuteNonQuery();

                        // If attendees have been removed off the waiting list, change their waiting list status.
                        if(attendeesOffWaitingList.Count != 0)
                        {
                            foreach(EventAttendee offWaitingList in attendeesOffWaitingList)
                            {
                                cmd.CommandText = "UPDATE TableEventAttendees SET WaitingList = False WHERE CustID = @cid AND EventID = @eid";
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@cid", offWaitingList.customer.id);
                                cmd.Parameters.AddWithValue("@eid", editEvent.id);
                                int status3 = cmd.ExecuteNonQuery();

                            }
                        }
                        // If attendees have been removed, delete them from the attendees records.
                        if (removedAttendees.Count != 0)
                        {
                            foreach (EventAttendee removedAttendee in removedAttendees)
                            {
                                cmd.CommandText = "DELETE FROM TableEventAttendees WHERE CustID = @cid AND EventID = @eid";
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@cid", removedAttendee.customer.id);
                                cmd.Parameters.AddWithValue("@eid", editEvent.id);
                                int status1 = cmd.ExecuteNonQuery();
                            }
                        }

                        // If attendees have been added, insert new attendee records.
                        if (addedAttendees.Count != 0)
                        {
                            foreach (EventAttendee addedAttendee in addedAttendees)
                            {
                                cmd.CommandText = "INSERT INTO TableEventAttendees(CustID,EventID,NoOfAttendees,Paid,WaitingList) VALUES(@cid,@eid,@nat,@pai,@wal)";
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@cid", addedAttendee.customer.id);
                                cmd.Parameters.AddWithValue("@eid", editEvent.id);
                                cmd.Parameters.AddWithValue("@nat", addedAttendee.noOfAttendees);
                                cmd.Parameters.AddWithValue("@pai", addedAttendee.paid);
                                cmd.Parameters.AddWithValue("@wal", addedAttendee.waitingList);
                                int status2 = cmd.ExecuteNonQuery();
                            }
                        }
                        connection.Close();
                        MessageBox.Show("Order edited successfully.", "Edit Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                }
                    else
                    {
                        if(dtpEventDate.Value < DateTime.Today)
                        {
                            MessageBox.Show("Event must be in the future.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // Adds the event record to the database.
                            OleDbConnection connection = new OleDbConnection();
                            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                            OleDbCommand cmd = connection.CreateCommand();
                            connection.Open();
                            cmd.CommandText = "INSERT INTO TableEvents(EventName, EventDate, EventStartTime, EventEndTime, Host, Price,Capacity,MaxGuests,SkillLevel,EventNotes) VALUES(@en,@ed,@est,@eet,@ho,@pr,@cap,@max,@ski,@evn)";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@en", tbxName.Text);
                            cmd.Parameters.AddWithValue("@ed", DateTime.Parse(dtpEventDate.Value.ToShortDateString()));
                            cmd.Parameters.AddWithValue("@est", DateTime.Parse(eventStartTime.ToShortTimeString()));
                            cmd.Parameters.AddWithValue("@eet", DateTime.Parse(eventEndTime.ToShortTimeString()));
                            cmd.Parameters.AddWithValue("@ho", tbxHost.Text);
                            cmd.Parameters.AddWithValue("@pr", tbxPrice.Text);
                            cmd.Parameters.AddWithValue("@cap", numCapacity.Value.ToString());
                            cmd.Parameters.AddWithValue("@max", numMaxGuests.Value.ToString());
                            cmd.Parameters.AddWithValue("@ski", cbxSkillLevel.Text);
                            cmd.Parameters.AddWithValue("@evn", rtbxNotes.Text);
                            cmd.Connection = connection;
                            int status = cmd.ExecuteNonQuery();

                            // Gets the ID of the event that has just been created.
                            cmd.CommandText = "SELECT EventID FROM TableEvents ORDER BY EventID DESC";
                            cmd.Parameters.Clear();
                            int tempEventID = Convert.ToInt32(cmd.ExecuteScalar());

                            // If there are attendees, add each attendee and link them to the event in the database.
                            if (attendeeList.Count != 0)
                            {
                                foreach (EventAttendee attendee in attendeeList)
                                {
                                    cmd.CommandText = "INSERT INTO TableEventAttendees(CustID,EventID,NoOfAttendees,Paid,WaitingList) VALUES(@cid,@eid,@nat,@pai,@wal)";
                                    cmd.Parameters.Clear();
                                    cmd.Parameters.AddWithValue("@cid", attendee.customer.id);
                                    cmd.Parameters.AddWithValue("@eid", tempEventID);
                                    cmd.Parameters.AddWithValue("@nat", attendee.noOfAttendees);
                                    cmd.Parameters.AddWithValue("@pai", attendee.paid);
                                    cmd.Parameters.AddWithValue("@wal", attendee.waitingList);
                                    int status1 = cmd.ExecuteNonQuery();
                                }
                            }
                            connection.Close();
                            MessageBox.Show("New event added successfully.", "New Event", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        
                    }
                }
            }


        }
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e) // Show customer details
        {
            updateWaitingListLabel();
            index = e.RowIndex;
            refreshCustomerInfo(index);
            selectedAttendee = null;
        }
        private void attendeeBox_AttendeeSelected(object sender, EventArgs e) // If an attendee has been clicked on in the list
        {
            if (sender is AttendeeBox attendeeBox)
            {
                selectedBox = attendeeBox;
                selectedAttendee = attendeeBox.attendee;
                refreshAttendeeInfo(selectedAttendee);
                selectingCust = true;
                foreach (DataGridViewRow row in dgvCustomers.Rows)
                {
                    if (selectedAttendee.customer.id == Convert.ToInt32(row.Cells[0].Value))
                    {
                        dgvCustomers.ClearSelection();
                        row.Selected = true;
                        dgvCustomers.FirstDisplayedScrollingRowIndex = row.Index;
                        dgvCustomers.Focus();
                        btnAddCustomer.Visible = false;
                    }
                }
            }
        }
        private void refreshAttendeeInfo(EventAttendee attendee) // Show customer details
        {
            tbxCustID.Text = attendee.customer.id.ToString();
            tbxFullName.Text = attendee.customer.fullName;
            tbxPhoneNum.Text = attendee.customer.phoneNum;
            tbxEmailAdd.Text = attendee.customer.emailAddress;
            if (CustomerAdded(attendee.customer.id,attendeeList))
            {
                numGuests.Value = attendee.noOfAttendees - 1;
            }
            else
            {
                numGuests.Value = 0;
            }
            chbxPaid.Checked = attendee.paid;
            if (attendee.waitingList) { lblWaitingList.Visible = true; }
            else { lblWaitingList.Visible = false; }
            btnAddCustomer.Visible = false;

        }
        private void refreshCustomerInfo(int index)
        {
            // Sets the current customer to the customer selected and displays the information of the customer in the customer panel.
            if (index < 0) // Index cannot be negative.
            {
                index = 0;
            }
            DataGridViewRow selectedRow = dgvCustomers.Rows[index];
            currentCust = new Customer(Convert.ToInt32(selectedRow.Cells[0].Value), selectedRow.Cells[1].Value.ToString(), selectedRow.Cells[2].Value.ToString(), selectedRow.Cells[3].Value.ToString(), selectedRow.Cells[4].Value.ToString(), selectedRow.Cells[5].Value.ToString(), Convert.ToInt32(selectedRow.Cells[6].Value), Convert.ToInt32(selectedRow.Cells[7].Value));
            if (CustomerAdded(currentCust.id,attendeeList)) // If the selected customer in the dgv has been added to the attendees list already, then their event attendee details must be displayed instead.
            {
                foreach(EventAttendee a in attendeeList)
                {
                    if(a.customer.id == currentCust.id)
                    {
                        refreshAttendeeInfo(a);
                    }
                }
            }
            else
            {
                tbxCustID.Text = currentCust.id.ToString();
                tbxFullName.Text = currentCust.fullName;
                tbxPhoneNum.Text = currentCust.phoneNum;
                tbxEmailAdd.Text = currentCust.emailAddress;
                numGuests.Value = 0;
                chbxPaid.Checked = true;
                btnAddCustomer.Visible = true;
            }
        }
        private void btnClear_Click(object sender, EventArgs e) // Clears all fields
        {
            DialogResult clearAll = MessageBox.Show("Are you sure you want to discard all changes?", "Clear", MessageBoxButtons.YesNo,MessageBoxIcon.Question); // Ensures the user definitely wishes to clear all data.
            if(clearAll == DialogResult.Yes)
            {
                attendeeList.Clear();
                paidWaitingList.Clear();
                unpaidWaitingList.Clear();
                mainList.Clear();
                tbxName.Text = string.Empty;
                tbxHost.Text = "Purls Of Wisdom";
                tbxPrice.Text = string.Empty;
                rtbxNotes.Text = string.Empty;
                tbxNoOfAttendees.Text = string.Empty;
                numCapacity.Value = 10;
                numMaxGuests.Value = 0;
                cbxSkillLevel.Text = string.Empty;
                flpAttendees.Controls.Clear();
            }
            waitinglist = false;
            lblWaitingList.Visible = false;
            refreshAttendees();
        }
        private void btnCancel_Click(object sender, EventArgs e) // Closes the form
        {
            DialogResult result = MessageBox.Show("Are you sure you want to discard all changes?","Discard All Changes",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Close();
            }
        }
        private void chbxAllDay_CheckedChanged(object sender, EventArgs e) // Sets the start and end time to opening hours
        {
            if (chbxAllDay.Checked)
            {
                dtpStartTime.Enabled = false;
                dtpEndTime.Enabled = false;
                dtpStartTime.Value = dtpEventDate.Value.Date.AddHours(9);
                dtpEndTime.Value = dtpEventDate.Value.Date.AddHours(20);

            }
            if (!chbxAllDay.Checked)
            {
                dtpStartTime.Enabled = true;
                dtpEndTime.Enabled = true;

            }
        }
        private void dtpStartTime_ValueChanged(object sender, EventArgs e) // Ensures the start time is not after the end time and is within opening hours
        {
            if (updatingStartTime) // Avoids recursively triggering the value changed event
                return;

            try
            {
                updatingStartTime = true;

                if (dtpEndTime.Value < dtpStartTime.Value)
                {
                    dtpEndTime.Value = dtpStartTime.Value;
                }
                if (dtpStartTime.Value < dtpEventDate.Value.Date.AddHours(9))
                {
                    dtpStartTime.Value = dtpEventDate.Value.Date.AddHours(20);
                }
                if (dtpStartTime.Value > dtpEventDate.Value.Date.AddHours(20))
                {
                    dtpStartTime.Value = dtpEventDate.Value.Date.AddHours(9);
                }
            }
            finally
            {
                updatingStartTime = false;
            }

        }
        private void dtpEndTime_ValueChanged(object sender, EventArgs e) // Ensures the start time is not after the end time and is within opening hours
        {
            if (updatingEndTime) // Avoids recursively triggering the value changed event
                return;

            try
            {
                updatingEndTime = true;

                if (dtpEndTime.Value < dtpStartTime.Value)
                {
                    dtpEndTime.Value = dtpStartTime.Value;
                }
                if (dtpEndTime.Value < dtpEventDate.Value.Date.AddHours(9))
                {
                    dtpEndTime.Value = dtpEventDate.Value.Date.AddHours(20);
                }
                if (dtpEndTime.Value > dtpEventDate.Value.Date.AddHours(20))
                {
                    dtpEndTime.Value = dtpEventDate.Value.Date.AddHours(9);
                }
            }
            finally
            {
                updatingEndTime = false;
            }

        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            selectedAttendee = new EventAttendee(currentCust, 0, Convert.ToInt32(numGuests.Value+1), chbxPaid.Checked, waitinglist); // Set the currently selected attendee to a new instance of attendee with the current customer

            if (!CustomerAdded(selectedAttendee.customer.id,attendeeList)) // if the attendee isn't in the list, add them to the list
            {
                attendeeList.Add(selectedAttendee); // add the attendee to the list

                if (editEvent != null) // If editing an event and the attendee hasn't been removed so far
                {
                    if (CustomerAdded(selectedAttendee.customer.id, removedAttendees))
                    {
                        removedAttendees.Remove(selectedAttendee);
                    }
                    addedAttendees.Add(selectedAttendee);
                }
                int pos = attendeeList.IndexOf(selectedAttendee); // get the position of the attendee in the list
                if (CountAttendees(mainList)+selectedAttendee.noOfAttendees <= numCapacity.Value) // if there are spaces available for the attendee and their guests
                {
                    mainList.Add(selectedAttendee);
                }
                else // if there are not enough spaces add the attendee to the waiting list
                {
                    if (!selectedAttendee.waitingList) // sets the attendee's waiting list status to true incase previously it was false
                    {
                        selectedAttendee.setWaitingList(true);
                    }
                    if (selectedAttendee.paid) // enqueues them in the paid waiting list if they have paid
                    {
                        paidWaitingList.Enqueue(selectedAttendee,pos);
                    }
                    else // enqueues them in the unpaid waiting list if they have not paid
                    {
                        unpaidWaitingList.Enqueue(selectedAttendee,pos);
                    }
                }

                // Creates new list box item and adds it to the panel of customers in the event
                attendeeBox = new AttendeeBox(selectedAttendee);
                flpAttendees.Controls.Add(attendeeBox);
                attendeeBox.AttendeeSelected += attendeeBox_AttendeeSelected; // Subscribes to attendeeBox's AttendeeSelected event
            }
            refreshAttendees();
        }
        private void removeCustomerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (editEvent != null) // when editing an event's attendees, if a customer that was just added is then removed
            {
                if (CustomerAdded(selectedAttendee.customer.id,addedAttendees)|| CustomerAdded(selectedAttendee.customer.id, attendeesOffWaitingList))
                {
                    if (CustomerAdded(selectedAttendee.customer.id, addedAttendees))
                    {
                        addedAttendees.Remove(selectedAttendee);
                    }
                    if (CustomerAdded(selectedAttendee.customer.id, attendeesOffWaitingList))
                    {
                        attendeesOffWaitingList.Remove(selectedAttendee);
                    }
                }
                else // If a customer was added while editing and then removed, they are not added to the list of removed customers as there would be no need to remove their record in the database.
                {
                    // When editing an event and removing customers, customers that have been removed need to be kept track of so records can be deleted.
                    removedAttendees.Add(selectedAttendee);
                }

                if (CustomerAdded(selectedAttendee.customer.id, attendeesOffWaitingList))
                {
                    attendeesOffWaitingList.Remove(selectedAttendee);
                }
            }

            if (CustomerAdded(selectedAttendee.customer.id,mainList)) // If the customer to be removed is in the main list, they will be removed from the main list.
            {
                mainList.Remove(selectedAttendee);
            }
            else if (CustomerAdded(selectedAttendee.customer.id, paidWaitingList.getList())) // If the customer to be removed is in the paid waiting list, they will be removed from the paid waiting list and it will be reordered automatically.
            {
                paidWaitingList.Remove(selectedAttendee, attendeeList);
            }
            else if (CustomerAdded(selectedAttendee.customer.id, unpaidWaitingList.getList())) // If the customer to be removed is in the unpaid waiting list, they will be removed from the unpaid waiting list and it will be reordered automatically.
            {
                unpaidWaitingList.Remove(selectedAttendee, attendeeList);
            }

            attendeeList.Remove(selectedAttendee);
            updateWaitingList();
            refreshAttendees();
        }
        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            updateWaitingList();
            refreshAttendees();
        }
        private void updateWaitingList()
        {
            // If there is space on the main list of attendees, this will search through the waiting list to allocate attendees to the main list.
            // Priority is given to attendees that have paid, then by their position in the full list of attendees (order they were added in).
            // Search through those that have paid first
            while (paidWaitingList.CountAttendees() > 0 && CountAttendees(mainList) + paidWaitingList.GetFront().GetAttendee().noOfAttendees <= numCapacity.Value) // While there are customers on the waiting list that have paid and the main list of attendees will not exceed the event capacity
            {
                checkWaitingList(paidWaitingList.Dequeue());
            }
            // Search through those that have not paid if there is still space in the main list and all paid customers have been allocated a space
            while(unpaidWaitingList.CountAttendees()>0 && CountAttendees(mainList) + unpaidWaitingList.GetFront().GetAttendee().noOfAttendees <= numCapacity.Value)
            {
                checkWaitingList(unpaidWaitingList.Dequeue());
            }
            updateWaitingListLabel();
        }
        private void checkWaitingList(EventAttendee waitingListCust) // Refreshes the list and automatically allocates spaces to any customers on the waiting list
        {
            foreach (EventAttendee a in attendeeList) // removes the customer from the attendee list
            {
                if (a.customer.id == waitingListCust.customer.id)
                {
                    attendeeList.RemoveAt(attendeeList.IndexOf(a));
                    break;
                }
            }
            waitingListCust.setWaitingList(false); // Sets the customer's waiting list status to false
            mainList.Add(waitingListCust); // Adds the customer to the main list
            if (editEvent!=null)
            {
                attendeesOffWaitingList.Add(waitingListCust);
            }

            bool waitingListExists = false; // used to check if there are any customers left on the waiting list

            foreach (EventAttendee a in attendeeList) // Insert the customer back into the whole list at the end of the main list before the start of the waiting list
            {
                if (a.waitingList) // Gets the index of where to insert the customer before the waiting list customers
                {
                    attendeeList.Insert(attendeeList.IndexOf(a), waitingListCust); // Inserts the customer
                    waitingListExists = true; //
                    break;
                }
            }

            if (!waitingListExists)
            {
                attendeeList.Add(waitingListCust);
            }
        }
        private void numCapacity_ValueChanged(object sender, EventArgs e)
        {
            updateWaitingListLabel();
            if(flpAttendees.Controls.Count>0) // ensures this event only occurs when there are customers added to the list
            {
                if(capacity > numCapacity.Value) // If the capacity has been decreased
                {
                    if (CountAttendingCustomers(attendeeList) > numCapacity.Value) // Capacity cannot be less than the number of attendees in the list currently
                    {
                        MessageBox.Show("Remove customers before changing the capacity.", "Remove Customers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        numCapacity.Value = CountAttendingCustomers(attendeeList);
                    }
                    else
                    {
                        updateWaitingList();
                        refreshAttendees();
                        capacity = (int)numCapacity.Value;
                    }
                }
                else
                {
                    capacity = (int)numCapacity.Value;
                }
                
            }
        }
        private void chbxPaid_CheckedChanged(object sender, EventArgs e)
        {
            paidStatusChanged = true;
            btnApplyAttendeeChanges.Visible = true;
        }
        private void numGuests_ValueChanged(object sender, EventArgs e)
        {
            if(numGuests.Value > numMaxGuests.Value)
            {
                MessageBox.Show("Number of guests cannot be more than the maximum number of guests for this event.", "Maximum Guests", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numGuests.Value = numMaxGuests.Value;
            }
            else
            {
                numGuestsChanged = true;
                btnApplyAttendeeChanges.Visible = true;
            }
           
        }
        private void rtbxNotes_TextChanged(object sender, EventArgs e)
        {
            // Implements character length limit on order notes. It will show the user when the order notes' text length is reaching the limit of 255.
            if (rtbxNotes.TextLength > 244)
            {
                lblCharLimit.Visible = true;
                lblCharLimit.Text = rtbxNotes.TextLength + "/255";
            }
            else
            {
                lblCharLimit.Visible = false;
            }
        }
        private void tbxSearch_TextChanged(object sender, EventArgs e) // Search for the customer by name or email address
        {
            if (!string.IsNullOrWhiteSpace(tbxSearch.Text))
            {
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = connection.CreateCommand();
                OleDbDataReader reader;
                connection.Open();
                cmd.CommandText = "SELECT * FROM TableCustomers WHERE (FirstName LIKE @qu OR Surname LIKE @qu OR EmailAddress LIKE @qu) AND (MemType <> 'Guest' OR MemType <> 'Deleted')";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@qu", "%" + tbxSearch.Text + "%");
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = reader;
                    dgvCustomers.DataSource = bindingSource;
                    refreshCustomerInfo(0);
                }
                connection.Close();
            }
            else
            {
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = connection.CreateCommand();
                OleDbDataReader reader;
                connection.Open();
                cmd.CommandText = "SELECT * FROM TableCustomers WHERE MemType <> 'Guest' OR MemType <> 'Deleted'";
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = reader;
                dgvCustomers.DataSource = bindingSource;
                connection.Close();
                refreshCustomerInfo(0);
            }
            highlightCustomersAdded();
        }
        private void btnSearch_Click(object sender, EventArgs e) // Search for the customer by name or email address
        {
            if (!string.IsNullOrWhiteSpace(tbxSearch.Text))
            {
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = connection.CreateCommand();
                OleDbDataReader reader;
                connection.Open();
                cmd.CommandText = "SELECT * FROM TableCustomers WHERE (FirstName LIKE @qu OR Surname LIKE @qu OR EmailAddress LIKE @qu) AND (MemType <> 'Guest' OR MemType <> 'Deleted')";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@qu", "%" + tbxSearch.Text + "%");
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = reader;
                    dgvCustomers.DataSource = bindingSource;
                    refreshCustomerInfo(0);
                }
                else
                {
                    MessageBox.Show("No customers found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                connection.Close();
            }
            else
            {
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = connection.CreateCommand();
                OleDbDataReader reader;
                connection.Open();
                cmd.CommandText = "SELECT * FROM TableCustomers WHERE MemType <> 'Guest' OR MemType <> 'Deleted'";
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = reader;
                dgvCustomers.DataSource = bindingSource;
                connection.Close();
                refreshCustomerInfo(0);
            }
            highlightCustomersAdded();
        }
        private void btnApplyAttendeeChanges_Click(object sender, EventArgs e) // Applies changes made to the number of guests or paid status of a customer
        {
            if (!selectingCust)
            {
                if (numGuestsChanged)
                {
                    bool numGuestsDesc = false;
                    int numGuestsCurrent = 0;
                    foreach (EventAttendee a in attendeeList)
                    {
                        if (a.noOfAttendees - 1 > numGuests.Value && a.customer == currentCust)
                        {
                            numGuestsDesc = true;
                            numGuestsCurrent = a.noOfAttendees - 1;
                        }
                    }
                    if (numGuestsDesc)
                    {
                        MessageBox.Show("Remove customers with guests before decreasing the maximum number of guests.");
                        numGuests.Value = numGuestsCurrent;
                    }
                    else
                    {
                        if (numGuests.Value > numMaxGuests.Value) // If the user tries to add more guests for a customer than the maximum number of guests they have set
                        {
                            MessageBox.Show("This exceeds the maximum number of guests allowed per customer for this event.");
                            numGuests.Value = numMaxGuests.Value;
                        }
                        else if (selectedAttendee != null)
                        {
                            if (CountAttendees(mainList) + 1 > numCapacity.Value) // Won't allow the user to add guests to a customer if at capacity
                            {
                                MessageBox.Show("Guest could not be added to customer as event at capacity.");
                            }
                            else
                            {
                                selectedAttendee.setNoOfAttendees(Convert.ToInt32(numGuests.Value + 1));
                            }
                            refreshAttendees();
                            updateWaitingListLabel();
                        }
                    }
                    numGuestsChanged = false;
                    btnApplyAttendeeChanges.Visible = false;
                }
                if (selectedAttendee != null && paidStatusChanged)
                {
                    // Updates every list

                    if (CustomerAdded(selectedAttendee.customer.id, attendeeList))
                    {
                        foreach (EventAttendee attendee in attendeeList)
                        {
                            if (attendee.customer.id == selectedAttendee.customer.id)
                            {
                                attendee.setPaid(chbxPaid.Checked);
                                break;
                            }
                        }
                        selectedAttendee.setPaid(chbxPaid.Checked);

                    }
                    if (CustomerAdded(selectedAttendee.customer.id, mainList))
                    {
                        foreach (EventAttendee attendee in mainList)
                        {
                            if (attendee.customer.id == selectedAttendee.customer.id)
                            {
                                attendee.setPaid(chbxPaid.Checked);
                                break;
                            }
                        }
                        selectedAttendee.setPaid(chbxPaid.Checked);
                    }
                    if (chbxPaid.Checked)
                    {
                        if (CustomerAdded(selectedAttendee.customer.id, unpaidWaitingList.getList()))
                        {
                            unpaidWaitingList.Remove(selectedAttendee, attendeeList);
                            paidWaitingList.Enqueue(selectedAttendee, attendeeList.IndexOf(selectedAttendee));
                        }
                    }
                    else
                    {
                        if (CustomerAdded(selectedAttendee.customer.id, paidWaitingList.getList()))
                        {
                            paidWaitingList.Remove(selectedAttendee, attendeeList);
                            unpaidWaitingList.Enqueue(selectedAttendee, attendeeList.IndexOf(selectedAttendee));
                        }
                    }
                    refreshAttendees();
                    paidStatusChanged = false;
                    btnApplyAttendeeChanges.Visible = false;
                }

            }
            selectingCust = false;
        }
    }
}
