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
            if (dummy.next != null)
            {
                if (Object.ReferenceEquals(B, dummy))
                {
                    return false;
                }
                else if (Object.ReferenceEquals(F, dummy))
                {
                    F = F.next;
                    dummy.next = F.next;
                    return false;
                }
                else if (Object.ReferenceEquals(F, dummy.next))
                {
                    out_value = F.data;
                    dummy.next = F.next;
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
            else
            {
                if (Object.ReferenceEquals(F, dummy))
                {
                    return false;
                }
                else if(F.next != null)
                {
                    out_value = F.data;
                    F = F.next;
                    return true;
                }
                else if (F != null)
                {
                    out_value = F.data;
                    F = dummy;
                    return true;
                }
                else
                {
                    F = dummy;
                    return false;
                }
            }
            
        }

        

        public void Enqueue(int dataValue)
        {
            if (dummy.next == null)
            {
                B = dummy;
            }
            B.next = new Node(dataValue);
            B = B.next;


        }
    }
}
