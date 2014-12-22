using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace LookugA.Tests
{
    public class TAPMixAndMatchTest : TestClass
    {
        public override void Test()
        {
            var tasks = new ConcurrentBag<Task>();
            var tasks2 = new ConcurrentBag<Task>();
            //divide by 4 = 64
            for (var x = 0; x < 4; x++)
            {
                int x1 = x;
                tasks.Add(
                    Task.Run(() =>
                    {
                        for (var i = (x1 * 64); i <= ((x1 * 64) + 64); i++)
                        {
                            int i1 = i;
                            tasks2.Add(
                            Task.Run(() =>
                            {
                                Items.TryAdd((i1), ConnectTAP(Ip + (i1), 80));
                            }));
                        }
                    }));
            }


            Task.WaitAll(tasks.ToArray());
            Task.WaitAll(tasks2.ToArray());

        }
    }
}
