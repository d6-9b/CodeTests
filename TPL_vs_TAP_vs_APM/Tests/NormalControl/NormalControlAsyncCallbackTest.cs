using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookugA.Tests
{
    public class NormalControlAsyncCallbackTest : TestClass
    {
        public override void Test()
        {
            for (var i = 0; i <= 255; i++)
            {
                Items.TryAdd(i, ConnectAPM(Ip + i, 80));

            }
        }
    }
}
