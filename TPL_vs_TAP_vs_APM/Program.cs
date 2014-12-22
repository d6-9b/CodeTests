using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
/* 
    Copyright (C) 2014 LookugA

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
namespace LookugA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "LookugA - https://looku.ga";
            Console.WriteLine("Copyright (C) 2014 LookugA - https://looku.ga");
            Console.WriteLine();
Console.WriteLine(@"This program comes with ABSOLUTELY NO WARRANTY;
This is free software,and you are welcome to
redistribute it under certain conditions;
See accompanying LICENSE file for more information.");
            Console.WriteLine();

            Console.WriteLine("Running Tests...");
            Console.WriteLine();
            var tests = typeof(TestClass).Assembly.GetTypes()
                .Where(o => o.IsSubclassOf(typeof(TestClass)) && !o.IsAbstract)
                .Select(o => (TestClass)Activator.CreateInstance(o))
                .OrderBy(o => o.GetType().Name);

            foreach(var test in tests)
            {
                test.Run();
            }

            Console.WriteLine();
            Console.WriteLine("Tests Finished..");
            Console.ReadLine();
            //91 no collection no para
            //92 with collection no para
            //11 with collection task run + ordering
            //11 with collection and 4 pre task runners and sub task run + ordering
            //9  with Parallel For @ Degree of 256 /999 + ordering
            //15 with Parallel For @ Degree of 8 + ordering

        }   
    }
}
