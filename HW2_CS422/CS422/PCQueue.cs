using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS422
{
    public class Node
    {
        public int data;
        public Node next;

        public Node( int value)
        {
            data = value;
            next = null;
        }
    }

    public class PCQueue
    {
        Node dummy;
        Node F;
        Node B;

        public PCQueue()
        {
            dummy = new Node(0);
            F = B = dummy;
        }

        public bool Dequeue(ref int out_value)
        {
            if(dummy.next == null)
            {
                return false;
            }
            else
            {
                out_value = dummy.next.data;
                dummy.next = dummy.next.next;
                return true;
            }
        }

        public void Enqueue(int dataValue)
        {
            B.next = new Node(dataValue);
            B = B.next;
            if (dummy.next == null)
            {
                dummy.next = B;
            }
            
        }
    }
}
