using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookugA.Tests
{
    public class ParallelMaxAwaitableTest : TestClass
    {
        public override void Test()
        {
            Parallel.For(0, 255, 
                new ParallelOptions { MaxDegreeOfParallelism = 999 },
                (i) => Items.TryAdd(i, ConnectTAP(Ip + i, 80)));
        }
    }
}
