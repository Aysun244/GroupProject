using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupProject.Model;

namespace GroupProject.json
{
    class json
    {
        private List<Student> students;
        readonly string _path = " ";

        public json()
        {
            string filename = typeof(Student).Name.ToLower() + "s.json";
            string currentDirectory = Directory.GetCurrentDirectory();
            _path = Path.Combine(currentDirectory, "..", "..", "..", "json", filename);
            if (!File.Exists(_path))
                File.Create(_path).Close();
        }
    }
}
