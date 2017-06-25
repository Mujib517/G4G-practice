using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4G
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Arrays.Seggregate(new[] { 1, 0, 1, 1, 0, 0, 1, 0, 1 });
            foreach (var item in arr) Console.Write(item + " ");
        }
    }
}
