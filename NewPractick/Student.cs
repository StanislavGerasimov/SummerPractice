using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPractick;

 public enum nam //імена студентів
{
    John = 1,
    Jane = 2,
    Terry = 3,
    Maria = 4,
    Marshall = 5,
    Kate = 6,
    Mark = 7,
    Steph = 8,
    Michael = 9,
    Leonardo = 10


};
public class Student //тип даних, що зберігається у вузлі
{
     public nam Name { get; set; }        
    public int BDay { get; set; }
    public int BMonth { get; set; }
      public Student() // Конструктор без параметрів
      {
         Name = (nam)1;         
          BDay = 9;
          BMonth = 10;
      }
    public Student(int name, int BDay, int Bmonth) //конструктор з параметрами
    {
        this.Name = (nam)name;
        this.BDay = BDay;
        this.BMonth = Bmonth;
    }
}

