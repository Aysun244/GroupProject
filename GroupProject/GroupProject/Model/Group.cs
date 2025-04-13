using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Model
{
    class Group
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}


