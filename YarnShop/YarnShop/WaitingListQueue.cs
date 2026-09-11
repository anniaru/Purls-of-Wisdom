using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarnShop
{
    public class WaitingListQueue
    {
        private Node frontPointer;
        private Node rearPointer;
        private List<EventAttendee> list = new List<EventAttendee>();

        public Node GetFront()
        {
            return frontPointer;
        }

        public void SetFront(Node newFront)
        {
            frontPointer = newFront;
        }

        public Node GetRear()
        {
            return rearPointer;
        }

        public void SetRear(Node newRear)
        {
            rearPointer = newRear;
        }

        public bool QueueEmpty()
        {
            if (frontPointer == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Contains(EventAttendee attendee)
        {
            foreach (EventAttendee a in list)
            {
                if (a.customer.id == attendee.customer.id)
                {
                    return true;
                }
            }
            return false;
        }

        public int Count()
        {
            if (list != null)
            {
                return list.Count;
            }
            else
            {
                return 0;
            }
        }

        public int CountAttendees()
        {
            int i = 0;
            foreach (EventAttendee a in list)
            {
                i += a.noOfAttendees;
            }
            return i;
        }
        public void Enqueue(EventAttendee attendee, int position) // Order by paid status first, then by position in waiting list.
        {
            Node newNode = new Node(attendee, position);
            if (frontPointer == null) // If the queue is empty
            {
                frontPointer = newNode;
                rearPointer = newNode;
            }
            else
            {
                if (newNode.GetWaitingListPosition() < rearPointer.GetWaitingListPosition()) // If the new node needs to be the front of the queue
                {
                    newNode.SetNext(frontPointer);
                    frontPointer = newNode; // front is now the new node
                }
                else if (newNode.GetWaitingListPosition() >= rearPointer.GetWaitingListPosition()) // if the new node needs to be at the end of the queue
                {
                    rearPointer.SetNext(newNode);
                    rearPointer = newNode;
                }
                else // Finds where to insert the node
                {
                    Node current = frontPointer;
                    Node prev = null;
                    while (current.GetWaitingListPosition() <= newNode.GetWaitingListPosition())
                    {
                        prev = current;
                        current = current.GetNext();
                    }
                    newNode.SetNext(current);
                    prev.SetNext(current);
                }
            }
            list.Add(attendee);
        }

        public EventAttendee Dequeue()
        {
            EventAttendee dequeuedAttendee;
            if (frontPointer == null)
            {
                MessageBox.Show("Waiting list is empty.");
                dequeuedAttendee = null;
            }
            else
            {
                dequeuedAttendee = frontPointer.GetAttendee();
                frontPointer = frontPointer.GetNext();
                // Gets the attendee at the top of the waiting list and changes the pointer to the next attendee
            }
            list.Remove(dequeuedAttendee);
            return dequeuedAttendee;
        }

        public void Clear()
        {
            while (frontPointer != null)
            {
                Dequeue();
            }
        }

        public Node DequeueNodes()
        {
            Node dequeuedNode;
            if (frontPointer == null)
            {
                MessageBox.Show("Waiting list is empty.");
                dequeuedNode = null;
            }
            else
            {
                dequeuedNode = frontPointer;
                frontPointer = frontPointer.GetNext();
                // Gets the attendee at the top of the waiting list and changes the pointer to the next attendee
            }
            list.Remove(dequeuedNode.GetAttendee());
            return dequeuedNode;
        }
        public void Remove(EventAttendee attendee, List<EventAttendee> attendeeList)
        {
            // Full list of attendees must be passed in as the indexes of each customer in the list may have changed.

            List<EventAttendee> tempList = new List<EventAttendee>();
            if (frontPointer.GetAttendee() == attendee)
            {
                DequeueNodes();
            }
            else
            {
                while (!tempList.Contains(attendee)) //While the attendee has not been retrieved from the priority queue
                {
                    if (frontPointer != null) // while the queue isn't empty
                    {
                        tempList.Add(Dequeue()); //dequeues the queue and saves what has been dequeued in the temporary list
                    }
                    else
                    {
                        // if the queue is empty and the list doesn't contain the attendee that was to be removed, then the attendee wasn't in the queue in the first place
                        break;
                    }
                }
                for (int i = 0; i < tempList.Count; i++)
                {
                    if (tempList[i].customer.id == attendee.customer.id)
                    {
                        tempList.RemoveAt(i);
                        break; // Exit the loop after removing the item
                    }
                }
                foreach (EventAttendee a in tempList)
                {
                    Enqueue(a, attendeeList.IndexOf(a));
                }

            }
        }
        public List<EventAttendee> getList()
        {
            return list;
        }
    }
}
