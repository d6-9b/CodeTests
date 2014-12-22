using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Net.Sockets;

namespace LookugA
{
    public abstract class TestClass
    {
        public TestClass()
        {
            TestName = this.GetType().Name;
        }

        public abstract void Test();
        private string TestName { get; set; }

        public string Ip = "192.168.2.";
        public ConcurrentDictionary<int, bool> Items = new ConcurrentDictionary<int, bool>();

        public void Run()
        {
            var starttime = DateTime.Now;
            Test();
            Console.WriteLine(TestName + ": Seconds Taken: " + (DateTime.Now - starttime).TotalSeconds);

            //foreach (var i in Items.Where(fn => fn.Value).OrderBy(fn => fn.Key))
            //{
            //    Console.WriteLine(i.Key + ": " + i.Value);
            //}
        }

        //public bool ConnectLocking(string host, int port)
        //{
        //    using (var tcp = new TcpClient())
        //    {
        //        //add time out here?
        //        tcp.Connect(host, port);

        //        return tcp.Connected;
        //    }

        //}

        public bool ConnectAPM(string host, int port)
        {
            using (var tcp = new TcpClient())
            {
                var ar = tcp.BeginConnect(host, port, null, null);
                using (ar.AsyncWaitHandle)
                {
                    //Wait 2 seconds for connection.
                    if (ar.AsyncWaitHandle.WaitOne(500, false))
                    {
                        tcp.EndConnect(ar);
                        return true;
                        //Connect was successful.

                    }
                }
            }
            return false;
        }

        //public bool ConnectEAP(string host, int port)
        //{

        //}

        public bool ConnectTAP(string host, int port)
        {
            using (var tcp = new TcpClient())
            {
                try
                {
                    tcp.ConnectAsync(host, port).Wait(500);
                }
                catch
                {
                }
                return tcp.Connected;
            }
        }


    }
}
