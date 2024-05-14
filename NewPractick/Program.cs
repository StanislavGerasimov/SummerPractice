using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewPractick;

internal class Program
{       public static void Help()
    {
        Console.WriteLine("Команди, які ви можете використати:");
        Console.WriteLine(" /help   - виводить команди, які можуть використовуватися у програмі;");
        Console.WriteLine(" /add    - додати новий елемент у список;\n /addtoindex - додати по індексу;");
        Console.WriteLine(" /delete - видалити елемент зі списку;\n /show   - вивести список у вигляді таблиці;");
        Console.WriteLine(" /search - вивести студента по індексу;\n /summersort    - вивести студентів, які народилися влітку");
        Console.WriteLine(" /length - отримати довжину списка;\n /end    - закінчити роботу зі списком.");
    }
        public static void Main(string[] args)
        {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Help();   
        
        Student stone = new Student(1, 5, 6);
            Student sttwo = new Student(2, 1, 7);
            Student stthree = new Student(3, 13, 4);
            Student stfour = new Student(4, 27, 2);
            Student stfive = new Student(5, 8, 12);
            TwoList<Student> list = new TwoList<Student>();
            list.Add(stone);
            list.Add(sttwo);
            list.Add(stthree);
            list.Add(stfour);
            list.Add(stfive);
        Console.WriteLine("Список студентів: ");
        Console.WriteLine("Номер \t Ім`я \t День народження \t Місяць народження");
        printout();
        void printout()
        {
            Console.WriteLine("--------------------------------------------------");
            for (int i = 0; i < list.Length; i++)
            {
                ListNode<Student> node = list[i];
                Console.WriteLine($"{i + 1})  {list[i].Data.Name},  {list[i].Data.BDay}, {list[i].Data.BMonth}");
            }
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }
            
            Console.WriteLine("Що ви хочете зробити?");
            
        int k = 0;
        while (k == 0) {
            string input;
            input = Console.ReadLine().ToLower();
            Regex.Replace(input, @"\s+", "");
            switch (input)
            {
                case "/end": Console.WriteLine(); k = 1; break;
                case "/addtoindex":
                    Console.WriteLine("Виберіть ім'я персонажа: ");
                    for (int i = 1; i < 11; i++)
                    {
                        Console.WriteLine(i + ")" + (nam)i);
                    }
                    int numname = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введіть день народження студента:");
                    int DB = Convert.ToInt32(Console.ReadLine());
                    if (DB > 31 || DB < 1)
                    {
                        throw new IndexOutOfRangeException("Exception: Incorrect value!");
                    }
                    Console.WriteLine("Введіть місяць народження студента:");
                    int MB = Convert.ToInt32(Console.ReadLine());
                    if (MB > 12 || MB < 1)
                    {
                        throw new IndexOutOfRangeException("Exception: Incorrect value!");
                    }
                    Student student = new Student(numname, DB, MB);
                    Console.WriteLine("На яке місце вставити студента?");
                    int ind = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    list.addbyindex(ind - 1, student);
                    printout();
                    break;
                case "/add":
                    Console.WriteLine("Виберіть ім'я персонажа: ");
                    for (int i = 1; i < 11; i++)
                    {
                        Console.WriteLine(i + ")" + (nam)i);
                    }
                    numname = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введіть день народження студента:");
                    DB = Convert.ToInt32(Console.ReadLine());
                    if (DB > 31 || DB < 1)
                    {
                        throw new IndexOutOfRangeException("Exception: Incorrect value!");
                    }
                    Console.WriteLine("Введіть місяць народження студента:");
                    MB = Convert.ToInt32(Console.ReadLine());
                    if (MB > 12 || MB < 1)
                    {
                        throw new IndexOutOfRangeException("Exception: Incorrect value!");
                    }
                    Student student1 = new Student(numname, DB, MB);
                    list.Add(student1);
                    printout();
                    break;
                case "/delete":
                    Console.WriteLine("Введіть індекс студента, якого хочете видалити: ");
                    ind = Convert.ToInt32(Console.ReadLine());
                    list.deletebyindex(ind - 1);
                    printout();
                    break;
                case "/help":
                    Help();
                    break;
                case "/show": printout(); break;
                case "/search":
                    Console.WriteLine("Введіть індекс студента, інформацію яцого треба вивести: ");
                    ind = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Ім'я: {list[ind - 1].Data.Name}, День народження: {list[ind - 1].Data.BDay}, Місяць народження: {list[ind - 1].Data.BMonth} ");

                    Console.WriteLine();
                    Console.WriteLine();

                    break;
                case "/summersort":
                    list.summerborn();
                    Console.WriteLine();
                    break;
                case "/length":
                    Console.WriteLine("Довжина списку: " + list.Length);
                    Console.WriteLine();
                    break;
                default: Console.WriteLine(); break;

            }
            }
        }
        
            
    
}

