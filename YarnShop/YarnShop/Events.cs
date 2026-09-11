using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarnShop
{
    public partial class Events : Form
    {
        int index; // Keeps track of the index of the event in the dgv
        DateTime weekStartDate; // The start date of the week currently being viewed
        int month, year; // Month and year of the week currently being viewed

        Event selectedEvent = null;
        EventAttendee selectedAttendee = null;
        List<EventAttendee> attendeesList = new List<EventAttendee>(); // List of attendees for the currently selected event
        List<EventAttendee> waitingList = new List<EventAttendee>(); // List of attendees on the waiting list for the currently selected event

        bool filtersApplied = false; // Determines if filters are applied so searches can be applied to the results of the filter
        string currentCommand;

        private CalendarDay ucdays; // Calendar box containing the events for one day
        private AttendeeBox attendeeBox; // Object displaying attendee names

        bool viewWaitingList = false; // Used to determine if the waiting list is currently being viewed or not

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
        public Events(Event @event)
        {
            selectedEvent = @event;
            InitializeComponent();
        }

        
        // VIEW ALL EVENTS
        private void FormEvents_Load(object sender, EventArgs e)
        {
            if(selectedEvent != null) // If directed to this form from the main calendar or a notice
            {
                // Hide the weekly view, show all events
                btnWeeklyView.BackColor = Color.FromArgb(189, 116, 137);
                btnAllEvents.BackColor = Color.FromArgb(224, 164, 180);
                pnlFilters.Visible = true;
                pnlEvents.Location = new Point(206, 64);
                this.Size = new Size(1554, 687);
                pnlWeeklyView.Visible = false;
                filtersApplied = true;
                currentCommand = "SELECT * FROM TableEvents WHERE Cancelled = False";
                Event tempEvent = selectedEvent;
                loadEventsDGV();
                selectedEvent = tempEvent;
                foreach (DataGridViewRow row in dgvEvents.Rows)
                {
                    if (Convert.ToInt32(row.Cells[0].Value) == selectedEvent.id)
                    {
                        dgvEvents.ClearSelection();
                        dgvEvents.CurrentCell = dgvEvents.Rows[row.Index].Cells[0];
                        dgvEvents[0, row.Index].Selected = true;
                        dgvEvents.FirstDisplayedScrollingRowIndex = row.Index;
                        dgvEvents.Focus();
                    }
                }
                displayEventInfo(selectedEvent);
            }
            else // If this form was opened by clicking the Events button on the homepage, show all events for the current week by default
            {
                refreshCurrentWeek();
            }
        }
        private void loadEventsDGV() // Refreshes the events dgv according to the current query for events
        {
            if (!filtersApplied)
            {
                if (!pnlWeeklyView.Visible)
                {
                    currentCommand = "SELECT * FROM TableEvents WHERE Cancelled = False AND EventDate > @tod";
                }
                else
                {
                    currentCommand = "SELECT * FROM TableEvents WHERE EventDate >= @ed AND EventDate < @end AND Cancelled = False";
                }
            }
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            OleDbDataReader reader;
            connection.Open();
            cmd.CommandText = currentCommand; // Shows all active events by default.
            cmd.Parameters.Clear();
            if (!pnlWeeklyView.Visible)
            {
                cmd.Parameters.AddWithValue("@tod", DateTime.Parse(DateTime.Today.ToShortDateString()));
            }
            cmd.Parameters.AddWithValue("@ed", DateTime.Parse(weekStartDate.ToShortDateString()));
            cmd.Parameters.AddWithValue("@end", DateTime.Parse(weekStartDate.AddDays(7).ToShortDateString()));
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                btnEdit.Visible = true;
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = reader;
                dgvEvents.DataSource = bindingSource;
                // Format the columns and cells
                dgvEvents.Columns[1].HeaderText = "Name";
                dgvEvents.Columns[2].HeaderText = "Date";
                dgvEvents.Columns[3].DefaultCellStyle.Format = "HH:mm:ss";
                dgvEvents.Columns[3].HeaderText = "Start Time";
                dgvEvents.Columns[4].DefaultCellStyle.Format = "HH:mm:ss";
                dgvEvents.Columns[4].HeaderText = "End Time";
                pbxNoEvents.Visible = false;
                lblNoEvents.Visible = false; 
                DataGridViewRow selectedRow = dgvEvents.Rows[0];
                selectedEvent = new Event(Convert.ToInt32(selectedRow.Cells[0].Value), selectedRow.Cells[1].Value.ToString(), Convert.ToDateTime(selectedRow.Cells[2].Value), Convert.ToDateTime(selectedRow.Cells[3].Value), Convert.ToDateTime(selectedRow.Cells[4].Value), selectedRow.Cells[5].Value.ToString(), Convert.ToSingle(selectedRow.Cells[6].Value), Convert.ToInt32(selectedRow.Cells[7].Value), Convert.ToInt32(selectedRow.Cells[8].Value), selectedRow.Cells[9].Value.ToString(), selectedRow.Cells[10].Value.ToString(), Convert.ToBoolean(selectedRow.Cells[11].Value));
                displayEventInfo(selectedEvent);

            }
            else
            {
                // If no results are shown i.e. there are no future events that have not been cancelled or no results for filters
                btnEdit.Visible = false;
                dgvEvents.DataSource = null;
                pbxNoEvents.Visible = true;
                lblNoEvents.Visible = true;
            }
            connection.Close();
        }
        private void pbxNextWeek_Click(object sender, EventArgs e) // Show all events for the next week
        {
            weekStartDate = weekStartDate.AddDays(7);
            month = weekStartDate.Month;
            year = weekStartDate.Year;
            refreshCalendar(weekStartDate);
        }
        private void pbxPrevWeek_Click(object sender, EventArgs e) // Show all events for the previous week
        {
            weekStartDate = weekStartDate.AddDays(-7);
            month = weekStartDate.Month;
            year = weekStartDate.Year;
            refreshCalendar(weekStartDate);
        }
        private void btnToday_Click(object sender, EventArgs e) // Show all events for the current week
        {
            refreshCurrentWeek();
        }
        private void refreshCurrentWeek() // Show all events for the current week
        {
            // Shows all the events for the current week
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
            DayOfWeek currentDay = DateTime.Now.DayOfWeek; // gets current day
            int daysTillCurrentDay = currentDay - DayOfWeek.Monday; // gets the number of days since monday
            weekStartDate = DateTime.Now.AddDays(-daysTillCurrentDay); //gets the date of the start of this week
            refreshCalendar(weekStartDate);
        }
        private void refreshCalendar(DateTime currentWeekStartDate) // Refresh the calendar
        {
            flpMonday.Controls.Clear();
            flpTuesday.Controls.Clear();
            flpWednesday.Controls.Clear();
            flpThursday.Controls.Clear();
            flpFriday.Controls.Clear();
            flpSaturday.Controls.Clear();
            flpSunday.Controls.Clear();

            // Display the date range for the week currently shown
            lblDate.Text = "WEEK " + currentWeekStartDate.ToShortDateString() + " - " + currentWeekStartDate.AddDays(6).ToShortDateString();

            // Load all events for the week currently shown
            List<Event> eventsWeekList = loadEventsWeekList(currentWeekStartDate);

            if (eventsWeekList.Count > 0) // Show the information for the first event in the list
            {
                displayEventInfo(eventsWeekList[0]);
            }

            for (int i = 0; i < 7; i++) // Loop through each of the days of the week and fill in the calendar with the correct events for that day
            {
                string dayName = currentWeekStartDate.DayOfWeek.ToString();
                ucdays = new CalendarDay(false);
                ucdays.days(currentWeekStartDate.Day, month, year);
                ucdays.displayEvents(loadEventsDayList(currentWeekStartDate.Day, eventsWeekList));
                switch (dayName)
                {
                    case "Monday":
                        flpMonday.Controls.Add(ucdays);
                        break;
                    case "Tuesday":
                        flpTuesday.Controls.Add(ucdays);
                        break;
                    case "Wednesday":
                        flpWednesday.Controls.Add(ucdays);
                        break;
                    case "Thursday":
                        flpThursday.Controls.Add(ucdays);
                        break;
                    case "Friday":
                        flpFriday.Controls.Add(ucdays);
                        break;
                    case "Saturday":
                        flpSaturday.Controls.Add(ucdays);
                        break;
                    case "Sunday":
                        flpSunday.Controls.Add(ucdays);
                        break;
                }
                ucdays.EventSelected += ucdays_EventSelected;
                currentWeekStartDate = currentWeekStartDate.AddDays(1);
            }
            disableHorizontalScroll();
            loadEventsDGV(); // Refresh the dgv for the week
        }
        private void disableHorizontalScroll()
        {
            flpMonday.HorizontalScroll.Visible = false;
            flpMonday.HorizontalScroll.Enabled = false;
            flpTuesday.HorizontalScroll.Visible = false;
            flpTuesday.HorizontalScroll.Enabled = false;
            flpWednesday.HorizontalScroll.Visible = false;
            flpWednesday.HorizontalScroll.Enabled = false;
            flpThursday.HorizontalScroll.Visible = false;
            flpThursday.HorizontalScroll.Enabled = false;
            flpFriday.HorizontalScroll.Visible = false;
            flpFriday.HorizontalScroll.Enabled = false;
            flpSaturday.HorizontalScroll.Visible = false;
            flpSaturday.HorizontalScroll.Enabled = false;
            flpSunday.HorizontalScroll.Visible = false;
            flpSunday.HorizontalScroll.Enabled = false;

        }
        private void ucdays_EventSelected(object sender, EventArgs e) // If an event has been clicked on in the calendar
        {
            if(sender is CalendarBox cbx)
            {
                selectedEvent = cbx.getEvent;
                displayEventInfo(selectedEvent); 
                foreach (DataGridViewRow row in dgvEvents.Rows)
                {
                    if (Convert.ToInt32(row.Cells[0].Value) == selectedEvent.id)
                    {
                        dgvEvents.ClearSelection();
                        dgvEvents.CurrentCell = dgvEvents.Rows[row.Index].Cells[0];
                        dgvEvents[0, row.Index].Selected = true; // Highlight the event that has been selected in the dgv
                    }
                }
            }
        }
        private void attendeeBox_AttendeeSelected(object sender, EventArgs e) // If an attendee has been clicked on in the list
        {
            if (sender is AttendeeBox attendeeBox)
            {
                selectedAttendee = attendeeBox.attendee;
                displayAttendeeInfo(selectedAttendee);
            }
        }
        public void displayEventInfo(Event @event)
        {
            if (@event != null)
            {
                viewWaitingList = false;
                tbxEventID.Text = @event.id.ToString();
                tbxName.Text = @event.name;
                tbxHost.Text = @event.host.ToString();
                tbxNoOfAttendees.Text = @event.numAttendees.ToString();
                tbxCapacity.Text = @event.capacity.ToString();
                tbxDate.Text = @event.eventDateTime;
                tbxMaxGuests.Text = @event.maxGuests.ToString();
                tbxSkillLevel.Text = @event.skillLevel.ToString();
                tbxPrice.Text = @event.price.ToString();
                tbxNumPaid.Text = @event.GetAttendingCustomersPaid.Count.ToString() + "/"+ @event.GetTotalAttendingCustomers;
                rtbxNotes.Text = @event.eventNotes;
                attendeesList = @event.GetAttendingCustomers;
                if (@event.GetWaitingListAttendees.Count > 0) // If there are attendees on the waiting list
                {
                    waitingList = @event.GetWaitingListAttendees;
                    btnViewWaitingList.Visible = true;
                }
                else
                {
                    waitingList.Clear();
                    btnViewWaitingList.Visible = false;
                }
                if (@event.GetAttendingCustomersPaid.Count < @event.GetAttendingCustomers.Count) //
                {
                    lblNumPaid.ForeColor = Color.DarkRed;
                }
                else
                {
                    lblNumPaid.ForeColor = SystemColors.ControlText;
                }
                loadAttendees();
            }
        }
        private void loadAttendees() // By default will show all attendees that are not on the waiting list. If the 'view waiting list' button has been clicked, then all attendees on the waiting list will be shown instead.
        {
            List<EventAttendee> list = new List<EventAttendee>();

            if (viewWaitingList) // If the waiting list is to be shown
            {
                list = waitingList;
            }
            else
            {
                list = attendeesList;
            }

            flpAttendees.Controls.Clear();
            foreach (EventAttendee a in list)
            {
                attendeeBox = new AttendeeBox(a);
                flpAttendees.Controls.Add(attendeeBox);
                attendeeBox.AttendeeSelected += attendeeBox_AttendeeSelected;

            }
            if (list.Count > 0)
            {
                displayAttendeeInfo(attendeesList[0]);
            }
        }
        private void btnViewWaitingList_Click(object sender, EventArgs e) // Allows the user to switch between viewing all attending customers and the waiting list
        {
            if (viewWaitingList)
            {
                viewWaitingList = false;
                btnViewWaitingList.Text = "View Waiting List";
                // switch back to main list of attendees
            }
            else
            {
                viewWaitingList = true;
                btnViewWaitingList.Text = "View Attendees";
                // switch to waiting list
            }
            loadAttendees();
        }
        private void displayAttendeeInfo(EventAttendee attendee)
        {
            tbxFullName.Text = attendee.customer.fullName;
            tbxID.Text = attendee.customer.id.ToString();
            tbxPhoneNum.Text = attendee.customer.phoneNum.ToString();
            tbxEmailAdd.Text = attendee.customer.emailAddress.ToString();
            chbxPaid.Checked = attendee.paid;
            lblOnWaitingList.Visible = attendee.waitingList;

            if (!attendee.paid)
            {
                lblNumPaid.ForeColor = Color.DarkRed;
            }
            else
            {
                lblNumPaid.ForeColor = SystemColors.ControlText;
            }
            btnApplyPaid.Visible = false;
        }
        private void btnWeeklyView_Click(object sender, EventArgs e) // Switch between the weekly view and the view of all events
        {
            if (!pnlWeeklyView.Visible)
            {
                // If the weekly view is not visible, shows the weekly view and the events for that week only
                btnWeeklyView.BackColor = Color.FromArgb(224, 164, 180);
                btnAllEvents.BackColor = Color.FromArgb(189, 116, 137);
                pnlFilters.Visible = false;
                clearFilters();
                pnlEvents.Location = new Point(206, 272);
                this.Size = new Size(1554, 903);
                pnlWeeklyView.Visible = true;
                refreshCurrentWeek();
                loadEventsDGV();
            }
        }
        private void btnAllEvents_Click(object sender, EventArgs e) // Switch between the weekly view and the view of all events
        {
            if (pnlWeeklyView.Visible)
            {
                // If the weekly view is visible, hide it and show all events
                btnWeeklyView.BackColor = Color.FromArgb(189, 116, 137);
                btnAllEvents.BackColor = Color.FromArgb(224, 164, 180);
                pnlFilters.Visible = true;
                pnlEvents.Location = new Point(206, 64);
                this.Size = new Size(1554, 687);
                pnlWeeklyView.Visible = false;
                loadEventsDGV();
            }
        }
        public List<Event> loadEventsWeekList(DateTime weekStartDate) // Returns a list of all events for the week displayed
        {
            //loads all events for the week displayed
            List<Event> eventsWeekList = new List<Event>();
            for (int i = 0; i < 7; i++)
            {
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = connection.CreateCommand();
                OleDbDataReader reader;
                connection.Open();
                cmd.CommandText = "SELECT * FROM TableEvents WHERE EventDate = @ed AND Cancelled = False";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ed", DateTime.Parse(weekStartDate.ToShortDateString()));
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bool cancelled = false;
                    if (Convert.ToInt32(reader[11]) == -1 || Convert.ToBoolean(reader[11]))
                    {
                        cancelled = true;
                    }
                    if ((reader[0] != null) || (Convert.ToString(reader[0]) != ""))
                    {
                        eventsWeekList.Add(new Event(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToDateTime(reader[2]), Convert.ToDateTime(reader[3]), Convert.ToDateTime(reader[4]), Convert.ToString(reader[5]), Convert.ToSingle(reader[6]), Convert.ToInt32(reader[7]), Convert.ToInt32(reader[8]), Convert.ToString(reader[9]), Convert.ToString(reader[10]), cancelled));
                    }
                    else
                    {
                        continue;
                    }
                }
                connection.Close();
                weekStartDate = weekStartDate.AddDays(1);
            }
            return eventsWeekList;
        }
        public List<Event> loadEventsDayList(int dayNum, List<Event> eventsOfMonth) // Returns a list of all events for one day
        {
            List<Event> eventsOfDay = new List<Event>();
            foreach (Event e in eventsOfMonth)
            {
                if (dayNum == e.date.Day)
                {
                    eventsOfDay.Add(e);
                }
            }
            return eventsOfDay;
        }
        private void btnNewEvent_Click(object sender, EventArgs e) // Allows user to create a new event
        {
            NewEvent newFormNewEvent = new NewEvent(null);
            newFormNewEvent.ShowDialog();
            refreshCurrentWeek();
        }
        private void dgvEvents_CellClick(object sender, DataGridViewCellEventArgs e) // Allows the user to click on an event in the dgv and view all the information for that event
        {
            index = e.RowIndex;
            if (index < 0)
            {
                index = 0;
            }
            DataGridViewRow selectedRow = dgvEvents.Rows[index];
            selectedEvent = new Event(Convert.ToInt32(selectedRow.Cells[0].Value), selectedRow.Cells[1].Value.ToString(), Convert.ToDateTime(selectedRow.Cells[2].Value), Convert.ToDateTime(selectedRow.Cells[3].Value), Convert.ToDateTime(selectedRow.Cells[4].Value), selectedRow.Cells[5].Value.ToString(), Convert.ToSingle(selectedRow.Cells[6].Value), Convert.ToInt32(selectedRow.Cells[7].Value), Convert.ToInt32(selectedRow.Cells[8].Value), selectedRow.Cells[9].Value.ToString(), selectedRow.Cells[10].Value.ToString(), Convert.ToBoolean(selectedRow.Cells[11].Value));
            displayEventInfo(selectedEvent);
        }

        // FILTERS
        private void tbxSearch_TextChanged(object sender, EventArgs e) // As the user types in the search bar, events are searched for according to the input.
        {
            if (!filtersApplied)
            {
                if (!string.IsNullOrWhiteSpace(tbxSearch.Text))
                {
                    if (!pnlWeeklyView.Visible)
                    {
                        OleDbConnection connection = new OleDbConnection();
                        connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmd = connection.CreateCommand();
                        OleDbDataReader reader;
                        connection.Open();
                        cmd.CommandText = "SELECT * FROM TableEvents WHERE EventName LIKE @en AND Cancelled = False AND EventDate > @tod";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@en", "%" + tbxSearch.Text + "%");
                        cmd.Parameters.AddWithValue("@tod", DateTime.Parse(DateTime.Today.ToShortDateString()));
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = reader;
                            dgvEvents.DataSource = bindingSource;
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
                        cmd.CommandText = "SELECT * FROM TableEvents WHERE EventName LIKE @en AND EventDate >= @ed AND EventDate < @end AND Cancelled = False";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@en", "%" + tbxSearch.Text + "%");
                        cmd.Parameters.AddWithValue("@ed", DateTime.Parse(weekStartDate.ToShortDateString()));
                        cmd.Parameters.AddWithValue("@end", DateTime.Parse(weekStartDate.AddDays(7).ToShortDateString()));
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = reader;
                            dgvEvents.DataSource = bindingSource;
                        }
                        connection.Close();
                    }
                }
                else
                {
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    if (!pnlWeeklyView.Visible)
                    {
                        cmd.CommandText = "SELECT * FROM TableEvents WHERE Cancelled = False AND EventDate > @tod";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@tod", DateTime.Parse(DateTime.Today.ToShortDateString()));
                    }
                    else
                    {
                        cmd.CommandText = "SELECT * FROM TableEvents WHERE EventDate >= @ed AND EventDate < @end AND Cancelled = False";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ed", DateTime.Parse(weekStartDate.ToShortDateString()));
                        cmd.Parameters.AddWithValue("@end", DateTime.Parse(weekStartDate.AddDays(7).ToShortDateString()));
                    }
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        BindingSource bindingSource = new BindingSource();
                        bindingSource.DataSource = reader;
                        dgvEvents.DataSource = bindingSource;
                    }
                    connection.Close();
                }
            } // If no filters have been applied, then all events will be shown and results found with the input will be shown
            else // If filters have been applied, then the search will apply to the events currently being shown
            {
                if (!string.IsNullOrWhiteSpace(tbxSearch.Text))
                {
                    if (!pnlWeeklyView.Visible)
                    {
                        OleDbConnection connection = new OleDbConnection();
                        connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmd = connection.CreateCommand();
                        OleDbDataReader reader;
                        connection.Open();
                        cmd.CommandText = currentCommand + " AND EventName LIKE @en";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@tod", DateTime.Parse(DateTime.Today.ToShortDateString()));
                        cmd.Parameters.AddWithValue("@en", "%" + tbxSearch.Text + "%");
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = reader;
                            dgvEvents.DataSource = bindingSource;
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
                        cmd.CommandText = currentCommand + " AND EventName LIKE @en";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ed", DateTime.Parse(weekStartDate.ToShortDateString()));
                        cmd.Parameters.AddWithValue("@end", DateTime.Parse(weekStartDate.AddDays(7).ToShortDateString()));
                        cmd.Parameters.AddWithValue("@en", "%" + tbxSearch.Text + "%");
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = reader;
                            dgvEvents.DataSource = bindingSource;
                        }
                        connection.Close();
                    }

                }
                else
                {
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    cmd.CommandText = currentCommand;
                    cmd.Parameters.AddWithValue("@tod", DateTime.Parse(DateTime.Today.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@ed", DateTime.Parse(weekStartDate.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@end", DateTime.Parse(weekStartDate.AddDays(7).ToShortDateString()));
                    cmd.Parameters.Clear();
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        BindingSource bindingSource = new BindingSource();
                        bindingSource.DataSource = reader;
                        dgvEvents.DataSource = bindingSource;
                    }
                    connection.Close();
                }
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!filtersApplied)
            {
                if (!string.IsNullOrWhiteSpace(tbxSearch.Text))
                {
                    if (!pnlWeeklyView.Visible)
                    {
                        OleDbConnection connection = new OleDbConnection();
                        connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmd = connection.CreateCommand();
                        OleDbDataReader reader;
                        connection.Open();
                        cmd.CommandText = "SELECT * FROM TableEvents WHERE EventName LIKE @en AND Cancelled = False AND EventDate > @tod";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@en", "%" + tbxSearch.Text + "%");
                        cmd.Parameters.AddWithValue("@tod", DateTime.Parse(DateTime.Today.ToShortDateString()));
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = reader;
                            dgvEvents.DataSource = bindingSource;
                        }
                        else
                        {
                            MessageBox.Show("No events found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        cmd.CommandText = "SELECT * FROM TableEvents WHERE EventName LIKE @en AND EventDate >= @ed AND EventDate < @end AND Cancelled = False";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@en", "%" + tbxSearch.Text + "%");
                        cmd.Parameters.AddWithValue("@ed", DateTime.Parse(weekStartDate.ToShortDateString()));
                        cmd.Parameters.AddWithValue("@end", DateTime.Parse(weekStartDate.AddDays(7).ToShortDateString()));
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = reader;
                            dgvEvents.DataSource = bindingSource;
                        }
                        else
                        {
                            MessageBox.Show("No events found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        connection.Close();
                    }
                }
                else
                {
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    if (!pnlWeeklyView.Visible)
                    {
                        cmd.CommandText = "SELECT * FROM TableEvents WHERE Cancelled = False AND EventDate > @tod";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@tod", DateTime.Parse(DateTime.Today.ToShortDateString()));
                    }
                    else
                    {
                        cmd.CommandText = "SELECT * FROM TableEvents WHERE EventDate >= @ed AND EventDate < @end AND Cancelled = False";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ed", DateTime.Parse(weekStartDate.ToShortDateString()));
                        cmd.Parameters.AddWithValue("@end", DateTime.Parse(weekStartDate.AddDays(7).ToShortDateString()));
                    }
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        BindingSource bindingSource = new BindingSource();
                        bindingSource.DataSource = reader;
                        dgvEvents.DataSource = bindingSource;
                    }
                    else
                    {
                        MessageBox.Show("No events found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connection.Close();
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(tbxSearch.Text))
                {
                    if (!pnlWeeklyView.Visible)
                    {
                        OleDbConnection connection = new OleDbConnection();
                        connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmd = connection.CreateCommand();
                        OleDbDataReader reader;
                        connection.Open();
                        cmd.CommandText = currentCommand + " AND EventName LIKE @en";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@tod", DateTime.Parse(DateTime.Today.ToShortDateString()));
                        cmd.Parameters.AddWithValue("@en", "%" + tbxSearch.Text + "%");
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = reader;
                            dgvEvents.DataSource = bindingSource;
                        }
                        else
                        {
                            MessageBox.Show("No events found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        cmd.CommandText = currentCommand + " AND EventName LIKE @en";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ed", DateTime.Parse(weekStartDate.ToShortDateString()));
                        cmd.Parameters.AddWithValue("@end", DateTime.Parse(weekStartDate.AddDays(7).ToShortDateString()));
                        cmd.Parameters.AddWithValue("@en", "%" + tbxSearch.Text + "%");
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = reader;
                            dgvEvents.DataSource = bindingSource;
                        }
                        else
                        {
                            MessageBox.Show("No events found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        connection.Close();
                    }

                }
                else
                {
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    OleDbDataReader reader;
                    connection.Open();
                    cmd.CommandText = currentCommand;
                    cmd.Parameters.AddWithValue("@tod", DateTime.Parse(DateTime.Today.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@ed", DateTime.Parse(weekStartDate.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@end", DateTime.Parse(weekStartDate.AddDays(7).ToShortDateString()));
                    cmd.Parameters.Clear();
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    BindingSource bindingSource = new BindingSource();
                    if (reader.HasRows)
                    {
                        bindingSource.DataSource = reader;
                        dgvEvents.DataSource = bindingSource;
                    }
                    else
                    {
                        MessageBox.Show("No events found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connection.Close();
                }
            }
        }
        private void clearChecked(CheckedListBox clsbToClear) // Clears all checked items in the checked list box.
        {
            for (int i = 0; i < clsbToClear.Items.Count; i++)
            {
                clsbToClear.SetSelected(i, false);
                clsbToClear.SetItemChecked(i, false);
            }
            clsbToClear.ClearSelected();
        }
        private void clearFilters()
        {
            filtersApplied = false;
            clearChecked(clsbStatus);
            clearChecked(clsbSpaces);
            clearChecked(clsbPayments);
            loadEventsDGV();
        }
        private void btnApplyFilters_Click(object sender, EventArgs e)
        {
            filtersApplied = false;
            string baseCommandText = "SELECT TableEvents.* FROM TableEvents WHERE";
            List<string> selectedStatusFilters = clsbStatus.CheckedItems.Cast<string>().ToList();
            List<string> selectedSpacesFilters = clsbSpaces.CheckedItems.Cast<string>().ToList();
            List<string> selectedPaymentFilters = clsbPayments.CheckedItems.Cast<string>().ToList();
            List<int> eventIDsSpacesAvailable = new List<int>();
            List<int> eventIDsAtCapacity = new List<int>();
            List<int> eventIDsWaitingList = new List<int>();
            List<int> eventIDs = new List<int>();

            // If filters for spaces have been selected
            if (selectedSpacesFilters.Count != 0)
            {
                filtersApplied = true;
                
                foreach (string spaceFilter in selectedSpacesFilters)
                {
                    switch (spaceFilter)
                    {
                        case "Spaces Available":
                            // Finds all events that have available spaces
                            OleDbConnection con = new OleDbConnection();
                            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                            OleDbCommand cmd1 = con.CreateCommand();
                            OleDbDataReader reader1;
                            con.Open();
                            cmd1.CommandText = "SELECT TableEvents.EventID, TableEvents.Capacity, SUM (TableEventAttendees.NoOfAttendees) FROM TableEventAttendees LEFT JOIN TableEvents ON TableEventAttendees.EventID  = TableEvents.EventID WHERE TableEventAttendees.WaitingList = False GROUP BY TableEvents.EventID, TableEvents.Capacity;";
                            cmd1.Parameters.Clear();
                            cmd1.Connection = con;
                            reader1 = cmd1.ExecuteReader();
                            while (reader1.Read())
                            {
                                if (Convert.ToInt32(reader1[2]) < Convert.ToInt32(reader1[1])) // If the number of attendees is less than the capacity, they will be added to the list of event IDs
                                {
                                    eventIDsSpacesAvailable.Add(Convert.ToInt32(reader1[0]));
                                }
                            }
                            con.Close();
                            break;
                        case "At Capacity":
                            // Find all events that are oversubscribed or at capacity
                            OleDbConnection con1 = new OleDbConnection();
                            con1.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                            OleDbCommand cmd2 = con1.CreateCommand();
                            OleDbDataReader reader2;
                            con1.Open();
                            cmd2.CommandText = "SELECT TableEvents.EventID, TableEvents.Capacity, SUM (TableEventAttendees.NoOfAttendees) FROM TableEventAttendees LEFT JOIN TableEvents ON TableEventAttendees.EventID  = TableEvents.EventID WHERE TableEventAttendees.WaitingList = False GROUP BY TableEvents.EventID, TableEvents.Capacity;";
                            cmd2.Parameters.Clear();
                            cmd2.Connection = con1;
                            reader2 = cmd2.ExecuteReader();
                            while (reader2.Read())
                            {
                                if (Convert.ToInt32(reader2[2]) >= Convert.ToInt32(reader2[1])) // If the number of attendees is equal to or more than the capacity, the event ID will be added to the list of event IDs
                                {
                                    eventIDsAtCapacity.Add(Convert.ToInt32(reader2[0]));
                                }
                            }
                            con1.Close();
                            break;
                        case "Waiting List":
                            // Find all events that have a waiting list
                            OleDbConnection con2 = new OleDbConnection();
                            con2.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                            OleDbCommand cmd3 = con2.CreateCommand();
                            OleDbDataReader reader3;
                            con2.Open();
                            cmd3.CommandText = "SELECT DISTINCT TableEvents.EventID FROM TableEvents INNER JOIN TableEventAttendees ON TableEvents.EventID = TableEventAttendees.EventID WHERE TableEventAttendees.WaitingList = True;";
                            cmd3.Parameters.Clear();
                            cmd3.Connection = con2;
                            reader3 = cmd3.ExecuteReader();
                            while (reader3.Read())
                            {
                                eventIDsWaitingList.Add(Convert.ToInt32(reader3[0]));
                            }
                            con2.Close();
                            break;
                    }
                }

                // Sets the list of event IDs to all ids that satisfy all conditions selected by the user
                // If both 'at capacity' and 'spaces available' have been selected, then no specific filter is applied
                // If both 'at capacity' and 'waiting list' have been selected, then the intersection of the lists of event IDs is used
                // Same applies to 'spaces available' and 'waiting list'
                if((eventIDsAtCapacity.Count !=0 && eventIDsWaitingList.Count != 0 && eventIDsSpacesAvailable.Count != 0) || (eventIDsAtCapacity.Count == 0 && eventIDsSpacesAvailable.Count == 0 && eventIDsWaitingList.Count != 0))
                {
                    eventIDs = eventIDsWaitingList;
                }
                else if (eventIDsAtCapacity.Count != 0 && eventIDsWaitingList.Count!=0)
                {
                    eventIDs = eventIDsAtCapacity.Intersect(eventIDsWaitingList).ToList();
                }
                else if(eventIDsSpacesAvailable.Count != 0 && eventIDsWaitingList.Count != 0) 
                {
                    eventIDs = eventIDsSpacesAvailable.Intersect(eventIDsWaitingList).ToList();
                }
                else if(eventIDsAtCapacity.Count != 0 && eventIDsSpacesAvailable.Count == 0)
                {
                    eventIDs = eventIDsAtCapacity;
                }
                else if(eventIDsSpacesAvailable.Count !=0)
                {
                    eventIDs = eventIDsSpacesAvailable;
                }
            }

            List<int> eventIDsPayments = new List<int>();
            if(selectedPaymentFilters.Count != 0)
            {
                if(selectedPaymentFilters.Count != 2) // if both filters are selected then there is no need for a filter
                {
                    filtersApplied = true;
                    foreach(string paymentFilter in selectedPaymentFilters)
                    {
                        OleDbConnection con = new OleDbConnection();
                        con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                        OleDbCommand cmd1 = con.CreateCommand();
                        OleDbDataReader reader1;
                        con.Open();
                        if (paymentFilter == "Unpaid")
                        {
                            // Gets the IDs of all events where there are customers that haven't paid.
                            cmd1.CommandText = "SELECT DISTINCT TableEvents.EventID FROM (TableCustomers INNER JOIN TableEventAttendees ON TableCustomers.CustID = TableEventAttendees.CustID) INNER JOIN TableEvents ON TableEventAttendees.EventID = TableEvents.EventID WHERE TableEventAttendees.Paid = False ORDER BY TableEvents.EventID;";
                            
                        }
                        else
                        {
                            // Gets the IDs of all events where all customers have paid by checking the count of attendees that have not paid
                            cmd1.CommandText = "SELECT DISTINCT TableEvents.EventID FROM TableEvents LEFT JOIN TableEventAttendees ON TableEvents.EventID = TableEventAttendees.EventID GROUP BY TableEvents.EventID HAVING SUM(IIf(TableEventAttendees.Paid = False, 1, 0)) = 0";
                        }
                        cmd1.Parameters.Clear();
                        cmd1.Connection = con;
                        reader1 = cmd1.ExecuteReader();
                        while (reader1.Read())
                        {
                            eventIDsPayments.Add(Convert.ToInt32(reader1[0]));
                        }
                        con.Close();
                    }
                }
            }
            
            if(eventIDsPayments.Count != 0 && eventIDs.Count !=0) // If there are event ids from other filters, intersect both lists
            {
                eventIDs = eventIDs.Intersect(eventIDsPayments).ToList();
            }
            else if(eventIDs.Count==0) // If there are no event ids from other filters, set the list equal to the ids from payment filters
            {
                eventIDs = eventIDsPayments;
            }

            if(eventIDs.Count > 0)
            {
                baseCommandText += " TableEvents.EventID IN (";
                foreach(int id in eventIDs)
                {
                    if(eventIDs.IndexOf(id) == eventIDs.Count - 1)
                    {
                        baseCommandText += id;
                        break; // so an extra comma is not included
                    }
                    else
                    {
                        // if the id to be added is the first id in the list, there should be no preceding comma
                        baseCommandText += id;
                    }
                    baseCommandText += ",";
                }
                baseCommandText += ")";
            }

            string statusCondition = "";
            if (selectedStatusFilters.Count != 0)
            {
                filtersApplied = true;
                foreach (string statusFilter in selectedStatusFilters)
                {
                    switch (statusFilter)
                    {
                        case "Upcoming":
                            statusCondition = " TableEvents.EventDate >= @tod";
                            break;
                        case "Past":
                            statusCondition = " TableEvents.EventDate < @tod";
                            break;
                        case "Active":
                            statusCondition = " TableEvents.Cancelled = False";
                            break;
                        case "Cancelled":
                            statusCondition = " TableEvents.Cancelled = True";
                            break;
                    }
                    if (baseCommandText.EndsWith("E"))
                    {
                        if (selectedStatusFilters.Count > 1)
                        {
                            baseCommandText += " (" + statusCondition;
                        }
                        else
                        {
                            baseCommandText += " " + statusCondition;
                        }
                    }
                    else if (baseCommandText.EndsWith(")"))
                    {
                        if(selectedStatusFilters.Count > 1)
                        {
                            baseCommandText += " AND (" + statusCondition;
                        }
                        else
                        {
                            baseCommandText += " AND " + statusCondition;

                        }
                    }
                    else
                    {
                        baseCommandText += " OR" + statusCondition;
                    }
                }
                if (selectedStatusFilters.Count > 1)
                {
                    baseCommandText += ")";
                }
            }
            else // If no filters are selected, upcoming events are shown by default
            {
                if (baseCommandText.EndsWith(")"))
                {
                    baseCommandText += " AND TableEvents.EventDate >= @tod AND TableEvents.Cancelled = False";
                }
                else if(baseCommandText.EndsWith("E"))
                {
                    baseCommandText += " TableEvents.EventDate >= @tod AND TableEvents.Cancelled = False";
                }
            }
            MessageBox.Show(baseCommandText);
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            OleDbDataReader reader;
            connection.Open();
            cmd.CommandText = baseCommandText;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@tod", DateTime.Parse(DateTime.Today.ToShortDateString()));
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            BindingSource bindingSource = new BindingSource();
            if (reader.HasRows)
            {
                bindingSource.DataSource = reader;
                dgvEvents.DataSource = bindingSource;
                currentCommand = baseCommandText;
                tbxSearch.Text = "";
            }
            else
            {
                MessageBox.Show("No events found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            connection.Close();
        }
        private void btnClearFilters_Click(object sender, EventArgs e) // Clears all filters
        {
            DialogResult result = MessageBox.Show("This will clear all filters. Proceed?", "Clear All Filters", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                clearFilters();
            }
        }

        // EDITING
        private void chbxPaid_CheckedChanged(object sender, EventArgs e)
        {
            if(selectedAttendee != null)
            {
                if (chbxPaid.Checked != selectedAttendee.paid)
                {
                    // If the user has unchecked/checked the paid checkbox, show the apply button to allow the user to change the paid status of the attendee
                    btnApplyPaid.Visible = true;

                }
                else
                {
                    btnApplyPaid.Visible = false;

                }

            }
        }
        private void btnApplyPaid_Click(object sender, EventArgs e) // Applies the changes made to the customer's paid status
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            connection.Open();
            cmd.CommandText = "UPDATE TableEventAttendees SET Paid = True WHERE CustID = @cid AND EventID = @eid";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@cid", selectedAttendee.customer.id);
            cmd.Parameters.AddWithValue("@eid", selectedEvent.id);
            int status = cmd.ExecuteNonQuery();
            connection.Close();
            Event tempEvent = selectedEvent;
            loadEventsDGV();
            selectedEvent = tempEvent;
            DataGridViewRow selectedRow = dgvEvents.Rows[0];
            foreach (DataGridViewRow row in dgvEvents.Rows)
            {
                if (Convert.ToInt32(row.Cells[0].Value) == selectedEvent.id)
                {
                    dgvEvents.ClearSelection();
                    dgvEvents.CurrentCell = dgvEvents.Rows[row.Index].Cells[0];
                    dgvEvents[0, row.Index].Selected = true;
                    selectedRow = dgvEvents.Rows[row.Index];
                    dgvEvents.FirstDisplayedScrollingRowIndex = row.Index;
                    dgvEvents.Focus();
                }
            }
            selectedEvent = new Event(Convert.ToInt32(selectedRow.Cells[0].Value), selectedRow.Cells[1].Value.ToString(), Convert.ToDateTime(selectedRow.Cells[2].Value), Convert.ToDateTime(selectedRow.Cells[3].Value), Convert.ToDateTime(selectedRow.Cells[4].Value), selectedRow.Cells[5].Value.ToString(), Convert.ToSingle(selectedRow.Cells[6].Value), Convert.ToInt32(selectedRow.Cells[7].Value), Convert.ToInt32(selectedRow.Cells[8].Value), selectedRow.Cells[9].Value.ToString(), selectedRow.Cells[10].Value.ToString(), Convert.ToBoolean(selectedRow.Cells[11].Value));
            displayEventInfo(selectedEvent);
        }
        private void rtbxNotes_TextChanged(object sender, EventArgs e)
        {
            if (selectedEvent != null)
            {
                if (rtbxNotes.Text != selectedEvent.eventNotes) // If the notes have been changed, show the apply button
                {
                    btnApplyNotes.Visible = true;

                }
                else
                {
                    btnApplyNotes.Visible = false;
                }

            }
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
        private void btnApplyNotes_Click(object sender, EventArgs e) // Applies the changes made to the order notes
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            connection.Open();
            cmd.CommandText = "UPDATE TableEvents SET EventNotes = @en WHERE EventID = @eid";
            cmd.Parameters.Clear();
            if (string.IsNullOrEmpty(rtbxNotes.Text))
            {
                rtbxNotes.Text = " ";
            }
            cmd.Parameters.AddWithValue("@en", rtbxNotes.Text);
            cmd.Parameters.AddWithValue("@eid", selectedEvent.id);
            int status = cmd.ExecuteNonQuery();
            connection.Close();
            Event tempEvent = selectedEvent;
            loadEventsDGV();
            selectedEvent = tempEvent;
            DataGridViewRow selectedRow = dgvEvents.Rows[0];
            foreach (DataGridViewRow row in dgvEvents.Rows)
            {
                if (Convert.ToInt32(row.Cells[0].Value) == selectedEvent.id)
                {
                    dgvEvents.ClearSelection();
                    dgvEvents.CurrentCell = dgvEvents.Rows[row.Index].Cells[0];
                    dgvEvents[0, row.Index].Selected = true;
                    selectedRow = dgvEvents.Rows[row.Index];
                    dgvEvents.FirstDisplayedScrollingRowIndex = row.Index;
                    dgvEvents.Focus();
                }
            }
            selectedEvent = new Event(Convert.ToInt32(selectedRow.Cells[0].Value), selectedRow.Cells[1].Value.ToString(), Convert.ToDateTime(selectedRow.Cells[2].Value), Convert.ToDateTime(selectedRow.Cells[3].Value), Convert.ToDateTime(selectedRow.Cells[4].Value), selectedRow.Cells[5].Value.ToString(), Convert.ToSingle(selectedRow.Cells[6].Value), Convert.ToInt32(selectedRow.Cells[7].Value), Convert.ToInt32(selectedRow.Cells[8].Value), selectedRow.Cells[9].Value.ToString(), selectedRow.Cells[10].Value.ToString(), Convert.ToBoolean(selectedRow.Cells[11].Value));
            displayEventInfo(selectedEvent);
        }

        private void cancelEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(selectedEvent.date < DateTime.Today)
            {
                MessageBox.Show("Cannot cancel a past event.", "Cancel Event", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                DialogResult result = MessageBox.Show("Cancel event?", "Cancel Event", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =shopDB.mdb";
                    OleDbCommand cmd = connection.CreateCommand();
                    connection.Open();
                    cmd.CommandText = "UPDATE TableEvents SET Cancelled = True WHERE EventID = @eid";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@eid", selectedEvent.id);
                    int status = cmd.ExecuteNonQuery();
                    connection.Close();
                    loadEventsDGV();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e) // Allows the user to edit the event
        {
            NewEvent newFormNewEvent = new NewEvent(selectedEvent);
            newFormNewEvent.ShowDialog();
            refreshCurrentWeek();
        }


    }
}
