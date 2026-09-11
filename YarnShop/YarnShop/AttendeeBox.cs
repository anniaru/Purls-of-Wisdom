using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarnShop
{
    // This is used in Events and NewEvent.
    // Used in the list of attendees.
    // Displays the full name of the customer and the number of guests that customer has.
    public partial class AttendeeBox : UserControl
    {
        public EventAttendee attendee {  get; private set; }

        // to pass the Attendee object to the form
        public delegate void AttendeeSelectedHandler(object sender, EventArgs e);
        public event AttendeeSelectedHandler AttendeeSelected;
        public AttendeeBox(EventAttendee attendee)
        {
            InitializeComponent();
            this.attendee = attendee;
        }
        private void AttendeeBox_Load(object sender, EventArgs e)
        {
            text();
            setColor();
        }
        public void text() // Displays the customer's name and number of guests (if any)
        {
            if (attendee.noOfAttendees > 1)
            {
                lblAttendee.Text = attendee.customer.idName + " + " + (attendee.noOfAttendees - 1);
            }
            else
            {
                lblAttendee.Text = attendee.customer.idName;
            }
        }
        public void setColor() // Highlights the customer's name in red if the customer hasn't paid, or in blue if the customer is on the waiting list.
        {
            if (attendee != null)
            {
                if (!attendee.paid)
                {
                    lblAttendee.ForeColor = Color.DarkRed;
                }
                if (attendee.waitingList)
                {
                    lblAttendee.ForeColor = Color.DarkBlue;
                }
            }
        }
        private void OnAttendeeClicked(EventArgs e) // When an attendee is clicked on in the parent forms, this object is passed to the parent form so the attendee information can be accessed.
        {
            // checks if the attendee is null before invoking
            AttendeeSelected?.Invoke(this, e);
        }
        private void lblAttendee_Click(object sender, EventArgs e) // When an attendee is clicked, the OnAttendeeClicked event is triggered so the information of the attendee can be passed to the parent form.
        {
            if (attendee != null)
            {
                OnAttendeeClicked(EventArgs.Empty);
            }
        }
        private void lblAttendee_MouseLeave(object sender, EventArgs e) // Indicates when the mouse isn't hovering over the attendee
        {
            lblAttendee.BackColor = SystemColors.ControlLightLight;
        }
        private void lblAttendee_MouseEnter(object sender, EventArgs e) // Indicates when the mouse is hovering over the attendee
        {
            lblAttendee.BackColor = SystemColors.Control;
        }
    }
}
