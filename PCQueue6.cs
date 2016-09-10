using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS422
{
    public class Node   // Node definition
    {
        public int data;    //  integer value data
        public Node next;

        public Node( int value)
        {
            data = value;
            next = null;
        }
    }

    public class PCQueue
    {
        // 3 member variables, dummy, Front, and Back
        Node dummy;
        Node F;
        Node B;

        // initialize dummy, and make B, F refer to dummy
        public PCQueue()
        {
            dummy = new Node(0);
            B = dummy;
            F = B;
        }

        
        // no lock thread-safe dequeue method
        // dummy works as a station for front, which works like
        // if dummy.next not null, then front moves toward dummy
        // It's like dummy always lead the way for front when dummy.next not null
        public bool Dequeue(ref int out_value)
        {
            if (F.next != null) // dummy not null, so dummy can lead the way for front
            {
                if (Object.ReferenceEquals(F, dummy))
                {
                    F = F.next;
                    out_value = F.data;
                    dummy.next = null;
                    return true;
                }
                else
                {
                    F = F.next;
                    out_value = F.data;
                    return true;
                }
            }
            else
            {
                F = dummy;
                return false;
            }
            
        }

        

        public void Enqueue(int dataValue)
        {
            if (dummy.next == null)
            {
                B = dummy;
                B.next = new Node(dataValue);
                B = B.next;
            }
            else
            {
                B.next = new Node(dataValue);
                B = B.next;
            }
            


        }
    }
}
