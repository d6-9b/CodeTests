using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace LookugA.Tests
{
    public class TAPSimpleTest : TestClass
    {
        public override void Test()
        {
            for (var i = 0; i <= 255; i++)
            {
                int i1 = i;

                Items.TryAdd(i1, ConnectTAP(Ip + i1, 80));
            }

        }
    }
}
