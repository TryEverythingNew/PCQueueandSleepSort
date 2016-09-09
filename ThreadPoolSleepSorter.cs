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
    public class ThreadPoolSleepSorter : IDisposable
    {
        TextWriter tw;
        BlockingCollection<Task> coll;
        bool running, isReady;
        Thread[] threads;

        public ThreadPoolSleepSorter(TextWriter output, ushort threadCount)
        {
            coll = new BlockingCollection<Task>();
            running = true;
            isReady = false;

            tw = output;
            if (threadCount == 0)
            {
                threads = new Thread[64];
                for (int i = 0; i < 64; i++)
                {
                    threads[i] = new Thread(ThreadWorkFunc);
                    threads[i].Start();
                    while (!threads[i].IsAlive)
                    {
                    }
                }
            }
            else
            {
                threads = new Thread[threadCount];
                for (int i = 0; i < threadCount; i++)
                {
                    threads[i] = new Thread(ThreadWorkFunc);
                    threads[i].Start();
                    while (!threads[i].IsAlive)
                    {
                    }
                }
            }

            
        }

        public void Sort(byte[] values)
        {
            isReady = false;
            Action<object> action = (object obj) =>
            {
                //Console.WriteLine(1000*(int)obj);
                Thread.Sleep(1000*(int)obj );
                ////////// no sleep at all.
                tw.WriteLine((int)obj);
            };
            for(int i = 0; i < values.Length; i++)
            {
                coll.Add(new Task(action, (int)values[i]));
            }

            isReady = true;
        }

        public void ThreadWorkFunc()
        {
            while (running)
            {
                if (isReady)
                {
                    Task t = null;
                    while (!coll.TryTake(out t))
                    {

                    }
                    t.Start();
                }
            }
        }

        public void Dispose()
        {
            running = false;
            isReady = false;
        }
    }
}
