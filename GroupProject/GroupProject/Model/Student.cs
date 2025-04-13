using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Model
{
    class Student
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public Student(string code, string name, string surname, int age)
        {
            Code = code;
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}
