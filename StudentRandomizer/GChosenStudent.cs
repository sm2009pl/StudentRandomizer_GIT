using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRandomizer
{
    //student chosen to answer
    class GChosenStudent
    {
        public static Student getChosenStudent { get; set; } = new Student();
        private GChosenStudent()
        {
        }
    }
}
