using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    class Program
    {
        static void Main(string[] args)
        {

            Account bankAccount1 = new Account(100);
            bankAccount1.PutInBalance(100);
            Console.WriteLine(bankAccount1[0]);

            BuildArray buildings = new BuildArray();
            buildings[0] = new Build(21,22,2,4);
            buildings[1] = new Build(21, 22, 2, 4);
            buildings[1] = 1;
            Console.ReadLine();
        }
    }
}
