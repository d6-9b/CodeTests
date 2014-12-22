using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookugA.Tests
{
    public class ParallelDefaultAwaitableTest : TestClass
    {
        public override void Test()
        {
            Parallel.For(0, 255, (i) => Items.TryAdd(i, ConnectTAP(Ip + i, 80)));
        }
    }
}
