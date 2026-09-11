using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarnShop
{
    // Used in the calendars on the homepage and events forms.
    public partial class CalendarDay : UserControl
    {
        // Attributes
        int day, month, year;
        private bool homepageCalendar {  get; set; } // If this object is created on the homepage, a context strip menu must be visible for the user. If it's created on the homepage, a context strip menu is not needed.
        // to pass the Event object to the form
        public delegate void EventSelectedHandler(object sender, EventArgs e);
        public event EventSelectedHandler EventSelected;
        private CalendarBox cbx;
        public CalendarDay(bool mainCalendar) // Constructor
        {
            InitializeComponent();
            homepageCalendar = mainCalendar;
        }
        private void UserControlDays_Load(object sender, EventArgs e)
        {
            HorizontalScroll.Visible = false;
            HorizontalScroll.Enabled = false;
        }
        public void days(int numDays,int currentMonth, int currentYear) // Displays the specific date in the calendar
        {
            lblDays.Visible = true;
            int today = DateTime.Now.Day;
            year = currentYear;
            month = currentMonth;
            day = numDays; //for panel
            // date label is the parameter
            if (numDays < 10)
            {
                lblDays.Text = "0"+numDays;
            }
            else
            {

                lblDays.Text = numDays + "";
            }
        }
        public void displayEvents(List<Event> events) // Displays all the events for this day
        {
            foreach(Event ev in events)
            {
                cbx = new CalendarBox(ev, homepageCalendar);
                cbx.ShowEvent();
                flpDay.Controls.Add(cbx);
                cbx.EventSelected += cbx_EventSelected; // subscribe to calendar box's event
            }
        }
        private void cbx_EventSelected(object sender, EventArgs e) // Invokes the event selected event on this control, allows the user to access the event shown and go to the events form directly
        {
            EventSelected?.Invoke(sender,e);
        }
        public void displayNumDueDeliveries(int numDays, int currentMonth, int currentYear) // Gets the number of due deliveries for this specific date and displays a message
        {
            // Get the specific date
            DateTime date = new DateTime(currentYear, currentMonth, numDays);
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            connection.Open();
            cmd.CommandText = "SELECT COUNT(*) FROM TableSupplierOrders WHERE DeliveryDate = @dat";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@dat", DateTime.Parse(date.ToShortDateString()));
            cmd.Connection = connection;
            int num = Convert.ToInt32(cmd.ExecuteScalar());
            if (num != 0)
            {
                cbx = new CalendarBox(null, homepageCalendar);
                cbx.ShowDeliveryDue(num);
                flpDay.Controls.Add(cbx);
                cbx.EventSelected += cbx_EventSelected; // subscribe to calendar box's event
            }
            connection.Close();
        }
        public void displayNumCollections(int numDays, int currentMonth, int currentYear) // Gets the number of due collections for this specific date and displays a message
        {
            // Get the specific date
            DateTime date = new DateTime(currentYear, currentMonth, numDays);
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = connection.CreateCommand();
            connection.Open();
            cmd.CommandText = "SELECT COUNT(*) FROM TableCustOrders WHERE CollectionDateEnd = @dat AND DeliveryStatus = 'Ready To Collect'";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@dat", DateTime.Parse(date.ToShortDateString()));
            cmd.Connection = connection;
            int num = Convert.ToInt32(cmd.ExecuteScalar());
            if (num != 0)
            {
                cbx = new CalendarBox(null, homepageCalendar);
                cbx.ShowCollectionDue(num);
                flpDay.Controls.Add(cbx);
                cbx.EventSelected += cbx_EventSelected; // subscribe to calendar box's event
            }
            connection.Close();
        }
        private void panel1_Paint(object sender, PaintEventArgs e) // Highlights today's date
        {
            if (day == DateTime.Now.Day && month == DateTime.Now.Month && year == DateTime.Now.Year)
            {
                lblDays.Visible = false;
                Graphics g = this.panel1.CreateGraphics();
                Brush b = new SolidBrush(Color.FromArgb(139, 65, 85));
                g.FillEllipse(b, 0, 0, 26, 26);
                b = new SolidBrush(Color.White);
                g.DrawString(lblDays.Text, lblDays.Font, b, 1, 0);
            }
        }
    }
}
