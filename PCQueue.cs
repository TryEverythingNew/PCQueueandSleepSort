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
            B = dummy;
            F = B;
        }

        public bool Dequeue(ref int out_value)
        {
            if (Object.ReferenceEquals(B, dummy))
            {
                return false;
            }
            else if (Object.ReferenceEquals(dummy.next, B))
            {
                F = F.next;
                return false;
            }
            else if (Object.ReferenceEquals(F, dummy))
            {
                F = F.next;
                return false;
            }
            else if(Object.ReferenceEquals(F, B))
            {
                out_value = F.data;
                B = dummy;
                F = dummy;
                return true;
            }
            else
            {
                out_value = F.data;
                F = F.next;
                return true;
            }
        }

        public void Enqueue(int dataValue)
        {
            //if (Object.ReferenceEquals(B, dummy))
            //{
            //    dummy.next = B;
            //}

            B.next = new Node(dataValue);
            B = B.next;
            
            
        }
    }
}
