using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRandomizer
{
    // global student list
    class GStudentList
    {
        public static List<Student> getStudents { get; } = new List<Student>();
        private GStudentList()
        {
        }

    }
}
