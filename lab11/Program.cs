using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using ClosedXML;
using Microsoft.Office.Interop.Excel;
namespace lab11

{
    class Program
    {
   
        [STAThread]
        private static void Main(string[] args)

        {
            var wbook = new XLWorkbook("Ill.xlsx");

            var ws1 = wbook.Worksheet(1);
            string[,] nums = new string[10, 10];
            int i = 0;
            int l = 2;
            int k = 2;
            int h = 2;
            var ill = new List<string>();
            for (i = 0; i < 10; i++)
            {

                ill.Add(ws1.Cell($"A{k}").GetValue<string>());
                k++;


            }
            var recovery = new List<string>();
            for (i = 0; i < 10; i++)
            {

                recovery.Add(ws1.Cell($"B{l}").GetValue<string>());
                l++;


            }
          
            foreach (var p in ill)
            {
                Console.WriteLine(p);
            }
            foreach (var p in recovery)
            {
                Console.WriteLine(p);
            }

            var list = new List<int>();
            var qbook = new XLWorkbook("Recover.xlsx");

            var ws2 = qbook.Worksheet(1);
            var hospital = new List<string>();
            int f = 0;

    
            string a = "";
            for (i = 0; i < 34; i++)
            {


                int index = ill.BinarySearch(ws2.Cell($"G{h}").GetValue<string>());
                a = ws2.Cell($"G{h}").GetValue<string>();
                if (index != -1)
                {
                    Console.WriteLine($" {a} found at {index}");
                    ws2.Cell($"H{h}").Value = $"{ill}";
                }
                else
                    Console.WriteLine("");

                h++;


            }
            qbook.SaveAs("styled.xlsx");
            foreach (var p in hospital)
            {
                Console.WriteLine(p);
            }
            foreach (var p in list)
            {
                Console.WriteLine(p);
            }

            Console.ReadKey();
        }
    }

}

