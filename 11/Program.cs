using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            Console.WriteLine("Упражнение 12.1");
            Bank a = new Bank(Bank.Type.Current, 1000);
            Bank b = new Bank(Bank.Type.Saving, 1000);
            Console.WriteLine(a != b);
            Console.WriteLine(a.Equals(b));


            Racionalization f = new Racionalization(3, 4);
            Console.WriteLine("f = {0};\n", f);
            Racionalization r1 = new Racionalization(4, 8);
            Console.WriteLine(r1.Equals(0.5));
            Console.WriteLine(++r1);
            Console.WriteLine($"({17.0 / 21} < {15.0 / 19})? {new Racionalization(17, 21) < new Racionalization(15, 19)}");
            Console.WriteLine((Racionalization)0.125);
            Console.WriteLine(r1 % new Racionalization(5, 4));

            Console.WriteLine("Task 1");
            Complex z = new Complex(1, 1);
            Complex z1;
            Complex c1 = new Complex(20, -7);
            Complex c2 = new Complex(1, 1);
            Console.WriteLine(c1 * c2);
            //z1 = z - (z * z * z - 1) / (3 * z * z);
            //Console.WriteLine("z1 =  {0}", z1);
            Array<Book> library = new Array<Book>();
            library.Add(new Book("Лучшее в нас", "Стивен Пинкер", "Альпина Нон Фикшен"));
            library.Add(new Book("Биология добра и зла", "Роберт Сапольски", "Альпина Нон Фикшен"));
            library.Sort(Array<Book>.byName);
            Console.ReadKey();
        }

    }
    }

    

    
