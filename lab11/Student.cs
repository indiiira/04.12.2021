using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab11
{
   public  class Student
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int Group { get; private set; }
        private bool isWinner { get; set; }

        public Student(string name, string surname, int group)
        {
            Name = name;
            Surname = surname;
            Group = group;
            isWinner = false;
        }
        public static void ShowInfo(List<Student> students)
        {
            for (int i = 1; i <= students.Count; i++)
            {
                Console.WriteLine($"{i} {students[i - 1].ShowInfo()}");
            }
        }
        public string ShowInfo()
        {
            return $"{Name} {Surname} {Group}";
        }

        internal bool IsWon()
        {
            string str = "";
            using (StreamReader checker = new StreamReader("результаты.txt"))
            {
                while (!string.IsNullOrEmpty(str = checker.ReadLine()))
                {
                    if (ShowInfo() == str)
                    {
                        return true;
                    }
                }
            }
            return false;

        }
    }
}

