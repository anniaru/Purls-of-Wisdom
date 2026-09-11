using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarnShop
{
    // This user control displays all events for its day and the number of collections/deliveries due (if any and this control is shown on the homepage)
    public partial class CalendarBox : UserControl
    {
        // Attributes
        public Event @event {  get; private set; }
        public string messageType { get; private set; }
        private bool homepageCalendar { get; set; } // If this object is created on the homepage, a context strip menu must be visible for the user. If it's created on the homepage, a context strip menu is not needed.

        // to pass the Event object to the parent form
        public delegate void EventSelectedHandler(object sender, EventArgs e);
        public event EventSelectedHandler EventSelected; 

        
        public CalendarBox(Event @event, bool mainCalendar) // Constructor
        {
            InitializeComponent();
            this.@event = @event;
            homepageCalendar = mainCalendar;
            textLabel.MaximumSize = new Size(Width - 10, 0); // Allows height to grow but not the width
        }
        public Event getEvent
        {
            get
            {
                return @event;
            }
        }
        private void CalendarBox_Load(object sender, EventArgs e)
        {
            // If this control shown on the homepage, the user needs to be able to right click this control and access the event information directly
            if (homepageCalendar && @event != null)
            {
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                contextMenuStrip.Font = new Font("Yu Gothic UI", (float)9.75, FontStyle.Bold);
                contextMenuStrip.Items.Add("Open Event Information", Image.FromFile("goToFormToolStripMenuItem.png"), GoToEvent);
                this.ContextMenuStrip = contextMenuStrip;
            }
        }
        private void GoToEvent(object sender, EventArgs e) // Right clicking on an event in this box allows the user to directly access the event in the events form
        {
            Events newFormEvents = new Events(@event);
            newFormEvents.ShowDialog();
        }
        public void ShowEvent() // Shows events in a different style
        {
            if (@event != null)
            {
                textLabel.Text = @event.eventInfo; 
                UpdateSize();
                textLabel.BackColor = Color.FromArgb(189, 116, 137);
                textLabel.ForeColor = SystemColors.ControlLightLight;
                textLabel.Font = new Font("Yu Gothic UI", (float)9.75, FontStyle.Bold);
            }

        }
        private void UpdateSize() // If the event name is too long to fit in the original box size, this will dynamically increase the size of the control so the full name of the event can be shown

        {
            using (Graphics g = this.CreateGraphics())
            {
                SizeF textSize = g.MeasureString(textLabel.Text, textLabel.Font, textLabel.MaximumSize.Width); // Measures the width of the event name
                textLabel.Height = Convert.ToInt32(Math.Ceiling(textSize.Height));
                Height = textLabel.Bottom; // Sets the height of the whole control to the height of the event name label
            }
        }
        public void ShowDeliveryDue(int num) // Shows the number of deliveries due for the day
        {
            messageType = "Delivery Due";
            textLabel.Text = num + " deliveries due"; 
            UpdateSize();

        }
        public void ShowCollectionDue(int num) // Shows the number of collections due for the day
        {
            messageType = "Collection Ends";
            textLabel.Text = num + " collections due";
            textLabel.ForeColor = SystemColors.ControlText; 
            UpdateSize();

        }
        private void textLabel_MouseEnter(object sender, EventArgs e) // Indicates when the mouse is hovering over an event/notice
        {
            if (@event != null) // If to display an event
            {
                textLabel.BackColor = Color.FromArgb(184, 112, 133);
                textLabel.ForeColor = SystemColors.ControlLight;
            }
            else
            {
                textLabel.BackColor = SystemColors.ControlLight;
            }
        } 
        private void textLabel_MouseLeave(object sender, EventArgs e) // Indicates when the mouse is hovering over an event/notice
        {

            if (@event != null) // If to display an event
            {
                textLabel.BackColor = Color.FromArgb(189, 116, 137);
                textLabel.ForeColor = SystemColors.ControlLightLight;
            }
            else
            {
                textLabel.BackColor = SystemColors.ControlLightLight;
            }
        }
        private void textLabel_Click(object sender, EventArgs e)// When an attendee is clicked, the OnAttendeeClicked event is triggered so the information of the attendee can be passed to the parent form.
        {
            // If on the events form and the user has clicked an event, this will pass the event object to the form
            if (@event != null) // Passes through parent control UserControlDays then to FormEvents
            {
                OnEventClicked(EventArgs.Empty);
            }
        }
        private void OnEventClicked(EventArgs e) // Invokes the EventSelected event
        {
            // checks if the event is null before invoking
            EventSelected?.Invoke(this, e);
        }
    }
}
