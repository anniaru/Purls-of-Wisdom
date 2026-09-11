using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarnShop
{
    public class Node
    {
        // Attributes
        private EventAttendee attendeeData;
        private int waitingListPosition;
        private Node nextNode;

        public Node(EventAttendee attendeeData, int waitingListPosition) // Constructor
        {
            this.attendeeData = attendeeData;
            this.waitingListPosition = waitingListPosition;
        }
        public EventAttendee GetAttendee()
        {
            return attendeeData;
        }
        public int GetWaitingListPosition()
        {
            return waitingListPosition;
        }
        public Node GetNext()
        {
            return nextNode;
        }
        public void SetNext(Node next)
        {
            nextNode = next;
        }
    }
}
