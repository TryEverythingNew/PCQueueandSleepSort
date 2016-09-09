using CS422;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW2_CS422
{
    class Program
    {
        static void Main(string[] args)
        {






            ThreadPoolSleepSorter sort = new ThreadPoolSleepSorter(Console.Out, 10);
            
            byte[] arr = new byte[] { 9,8,7,6,5,4,3,2,1};
            sort.Sort(arr);

            byte[] arr1 = new byte[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            sort.Sort(arr1);

            test testing = new test();

            Thread t1 = new Thread(new ThreadStart(testing.enqueue));
            Thread t2 = new Thread(new ThreadStart(testing.dequeue));
            //Thread t = new Thread(new ThreadStart());
            t1.Start();

            t2.Start();


        }

    }
    
    public class test
    {
        PCQueue queue1;

        public test()
        {
            queue1 = new PCQueue();
        }

        public void enqueue()
        {
            for (long i = 1; i < 100000000; i++)
            {
                queue1.Enqueue((int) (i%100));
                //Console.WriteLine(i);
                
            }
            
        }

        public void dequeue()
        {
            int j = 0;
            for (long i = 1; i < 100000000; i++)
            {
                while (queue1.Dequeue(ref j) == false)
                {
                }
                if (j == (int)(i % 100))
                {
                    
                }
                else
                {
                    Console.WriteLine("False");
                }
                //Console.WriteLine(j);
            }
        }
    }
}
