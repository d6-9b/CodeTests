using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace LookugA.Tests
{
    public class TAPAwaitableTest : TestClass
    {
        public override void Test()
        {
            var tasks = new ConcurrentBag<Task>();
            for (var i = 0; i <= 255; i++)
            {
                int i1 = i;

                tasks.Add(
                Task.Run(() =>
                {
                    Items.TryAdd(i1, ConnectTAP(Ip + i1, 80));
                }));
            }

            Task.WaitAll(tasks.ToArray());

        }
    }
}
