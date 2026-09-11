using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarnShop
{
    public class Event
    {
        // Attributes
        private int ID { get; set; }
        private string Name { get; set; }
        private DateTime Date { get; set; }
        private DateTime StartTime { get; set; }
        private DateTime EndTime { get; set; }
        private string Host { get; set; }
        private float Price { get; set; }
        private int NumAttendees { get; set; }
        private int Capacity { get; set; }
        private int MaxGuests { get; set; }
        private string SkillLevel { get; set; }
        private string EventNotes { get; set; }
        private bool Cancelled { get; set; }

        public Event(int id, string name, DateTime date, DateTime startTime, DateTime endTime, string host, float price, int capacity, int maxGuests, string skillLevel, string eventNotes, bool cancelled) // Constructor
        {
            ID = id;
            Name = name;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            Host = host;
            Price = price;
            Capacity = capacity;
            MaxGuests = maxGuests;
            SkillLevel = skillLevel;
            EventNotes = eventNotes;
            Cancelled = cancelled;

            NumAttendees = GetNumAttending;
        }

        // Getters
        public int id
        {
            get { return ID; }
        }
        public string name
        {
            get { return Name; }
        }
        public DateTime date
        {
            get { return Date; }
        }
        public DateTime startTime
        {
            get { return StartTime; }
        }
        public DateTime endTime
        {
            get { return EndTime; }
        }
        public string host
        {
            get { return Host; }
        }
        public float price
        {
            get { return Price; }
        }
        public int numAttendees
        {
            get { return NumAttendees; }
        }
        public int capacity
        {
            get { return Capacity; }
        }
        public int maxGuests
        {
            get { return MaxGuests; }
        }
        public string skillLevel
        {
            get { return SkillLevel; }
        }
        public string eventNotes
        {
            get { return EventNotes; }
        }
        public bool cancelled
        {
            get { return Cancelled; }
        }
        public string eventInfo
        {
            get
            {
                return StartTime.ToShortTimeString() + " " + Name;
            }
        }
        public string eventDateTime
        {
            get
            {
                return Date.ToShortDateString()+" "+StartTime.ToShortTimeString()+" - "+EndTime.ToShortTimeString();
            }
        }

        // Get totals
        public int GetNumAttending // Gets the number of customers that are attending the event i.e. are not on the waiting list.
        {
            get
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "SELECT SUM (TableEventAttendees.NoOfAttendees) FROM (TableEventAttendees LEFT JOIN TableEvents ON TableEventAttendees.EventID  = TableEvents.EventID) WHERE TableEventAttendees.WaitingList = False AND TableEvents.EventID = TableEvents.@eid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@eid", ID);
                cmd.Connection = con;
                int sum = 0;
                try
                {
                    sum = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch
                {
                    sum = 0;
                }
                con.Close();
                return sum;
            }

        }
        public int GetTotalAttendees // Gets the number of attendees on the event attendees list inc waiting list
        {
            get
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "SELECT SUM (TableEventAttendees.NoOfAttendees) FROM (TableEventAttendees LEFT JOIN TableEvents ON TableEventAttendees.EventID  = TableEvents.EventID) WHERE TableEvents.EventID = TableEvents.@eid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@eid", ID);
                cmd.Connection = con;
                int sum = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return sum;
            }
        }
        public int GetTotalAttendingCustomers // Gets the number of customers on the event attendees list excluding waiting list
        {
            get
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "SELECT COUNT(*) FROM (TableEventAttendees LEFT JOIN TableEvents ON TableEventAttendees.EventID  = TableEvents.EventID) WHERE TableEvents.EventID = TableEvents.@eid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@eid", ID);
                cmd.Connection = con;
                int sum = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return sum;
            }
        }

        // Get lists of attendees
        public List<EventAttendee> GetEventAttendees // Gets the list of all attendees for the event
        {
            get
            {
                List<EventAttendee> attendees = new List<EventAttendee>();
                bool error = false;
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
                OleDbCommand cmd = con.CreateCommand();
                OleDbDataReader reader;
                con.Open();
                cmd.CommandText = "SELECT DISTINCT TableCustomers.*, TableEventAttendees.NoOfAttendees, TableEventAttendees.Paid, TableEventAttendees.WaitingList FROM (TableCustomers INNER JOIN TableEventAttendees ON TableCustomers.CustID = TableEventAttendees.CustID) INNER JOIN TableEvents ON TableEventAttendees.EventID = TableEvents.@eid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@eid", ID);
                cmd.Connection = con;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        attendees.Add(new EventAttendee(new Customer(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToString(reader[3]), Convert.ToString(reader[4]), Convert.ToString(reader[5]), Convert.ToInt32(reader[6]), Convert.ToInt32(reader[7])), id, Convert.ToInt32(reader[8]), Convert.ToBoolean(reader[9]), Convert.ToBoolean(reader[10])));
                    }
                    catch
                    {
                        if (!error)
                        {
                            MessageBox.Show("Event attendee data is missing.", "Missing Data");
                            error = true;
                        }

                    }
                }
                con.Close();
                return attendees;
            }
            
        }
        public List<EventAttendee> GetCustomersUnpaid // Gets the list of all attendees for the event that have not paid
        {
            get
            {
                List<EventAttendee> attendees = GetEventAttendees;
                List<EventAttendee> unpaidAttendees = new List<EventAttendee>();
                // Gets the list of customers that have not paid for an event.
                foreach (EventAttendee a in attendees)
                {
                    if (!a.paid) // if the attendee has not paid
                    {
                        unpaidAttendees.Add(a);
                    }
                }
                return unpaidAttendees;
            }
            

        }
        public List<EventAttendee> GetAttendingCustomersPaid // Gets the list of all attending customers that have paid and are not on the waiting list
        {
            get
            {
                List<EventAttendee> attendees = GetEventAttendees;
                List<EventAttendee> paidAttendees = new List<EventAttendee>();
                // Gets the list of attending customers that have paid for an event.
                foreach (EventAttendee a in attendees)
                {
                    if (a.paid && !a.waitingList) // if the attendee has paid and is not on the waiting list
                    {
                        paidAttendees.Add(a);
                    }
                }
                return paidAttendees;
            }
        }
        public List<EventAttendee> GetAttendingCustomers // Get all attendees that are not on the waiting list
        {
            get
            {
                List<EventAttendee> attendees = GetEventAttendees;
                List<EventAttendee> mainList = new List<EventAttendee>();
                foreach (EventAttendee a in attendees)
                {
                    if (!a.waitingList) // if the attendee is not on the waiting list
                    {
                        mainList.Add(a);
                    }
                }
                return mainList;

            }
        }
        public List<EventAttendee> GetWaitingListAttendees // Get all attendees that are on the waiting list
        {
            get
            {
                List<EventAttendee> attendees = GetEventAttendees;
                List<EventAttendee> waitingListAttendees = new List<EventAttendee>();
                // Gets the list of customers that have paid for an event.
                foreach (EventAttendee a in attendees)
                {
                    if (a.waitingList) // if the attendee has paid
                    {
                        waitingListAttendees.Add(a);
                    }
                }
                return waitingListAttendees;

            }
        }
        public List<EventAttendee> GetOrderedAttendeesList // Get all attendees and return them in order of paid status
        {
            get
            {
                List<EventAttendee> attendees = new List<EventAttendee>();
                attendees.AddRange(GetAttendingCustomers);
                attendees.AddRange(GetPaidWaitingListQueue.getList()); // Adds the waiting list of paid attendees onto the end of the list of those not on the waiting list
                attendees.AddRange(GetUnpaidWaitingListQueue.getList()); // Adds the waiting list of attendees that have not paid last
                return attendees;
            }        
        }

        // Get queues of attendees
        public WaitingListQueue GetPaidWaitingListQueue // Get the queue of all attendees on the waiting list that have paid
        {
            get
            {
                List<EventAttendee> attendees = GetEventAttendees;
                WaitingListQueue paidWaitingList = new WaitingListQueue();
                foreach (EventAttendee a in attendees)
                {
                    if (a.waitingList && a.paid) // if the attendee is on the waiting list and has paid
                    {
                        paidWaitingList.Enqueue(a, attendees.IndexOf(a));
                    }
                }
                return paidWaitingList;
            }
        }
        public WaitingListQueue GetUnpaidWaitingListQueue // Get the queue of all attendees on the waiting list that have not paid
        {
            get
            {
                List<EventAttendee> attendees = GetEventAttendees;
                WaitingListQueue unpaidWaitingList = new WaitingListQueue();
                foreach (EventAttendee a in attendees)
                {
                    if (a.waitingList && !a.paid) // if the attendee is on the waiting list and has not paid
                    {
                        unpaidWaitingList.Enqueue(a, attendees.IndexOf(a));
                    }
                }
                return unpaidWaitingList;

            }
        }
    }
}
