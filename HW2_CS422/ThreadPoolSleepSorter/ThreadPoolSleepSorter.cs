using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CS422
{
    public class ThreadPoolSleepSorter
    {
        TextWriter tw;
        BlockingCollection<Task> coll;

        public ThreadPoolSleepSorter(TextWriter output, ushort threadCount)
        {
            tw = output;
            if( threadCount == 0)
            {
                for(int i = 0; i < 64; i++)
                {
                    var t = new Thread(ThreadWorkFunc);
                    t.Start();
                }
            }
            else
            {
                for (int i = 0; i < threadCount; i++)
                {
                    var t = new Thread(ThreadWorkFunc);
                    t.Start();
                }
            }
        }

        public void Sort(byte[] values)
        {
            Action<object> action = (object obj) =>
            {
                Thread.Sleep(((int) obj) * 1000);
                Console.WriteLine((int)obj);
            };
            for(int i = 0; i < values.Length; i++)
            {
                Task t = new Task(action, (int) values[i]);
                coll.Add(t);
            }
            
        }

        public void ThreadWorkFunc()
        {
            while (true)
            {
                coll.Take().Start();
            }
        }
    }
}
