using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarnShop
{
    // Used to record the paid status, waiting list status and number of guests the customer has in an event.
    public class EventAttendee
    {
        // Attributes
        private Customer Customer { get; set; }
        private int EventID { get; set; }
        private int NoOfAttendees { get; set; }
        private bool Paid { get; set; }
        private bool WaitingList { get; set; }

        public EventAttendee(Customer cust, int eventID, int noOfAttendees, bool paid, bool waitingList) // Constructor
        {
            this.EventID = eventID;
            this.NoOfAttendees = noOfAttendees;
            this.Paid = paid;
            this.WaitingList = waitingList;
            Customer = cust;
        }
        
        // Getters
        public int eventID
        {
            get { return EventID; }
        }
        public int noOfAttendees
        {
            get { return NoOfAttendees; }
        }
        public bool paid
        {
            get { return Paid; }
        }
        public bool waitingList
        {
            get { return WaitingList; }
        }
        public Customer customer
        {
            get { return Customer; }
        }

        // Setters
        public void setWaitingList(bool newWaitingList)
        {
            WaitingList = newWaitingList;
        }
        public void setPaid(bool newPaid)
        {
            Paid = newPaid;
        }
        public void setNoOfAttendees(int newNum)
        {
            NoOfAttendees = newNum;
        }
    }
}
