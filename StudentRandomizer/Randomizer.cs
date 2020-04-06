using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRandomizer
{
    class Randomizer
    {
        Random rnd = new Random();
        public void SetPriority(List<Student> students)
        {
            foreach (var item in students)
            {
                item.CheckPriority(rnd);
            }
        }
        public void ChooseStudentFromList(List<Student> students)
        {
            int maxPriority = 0;
            foreach (var item in students)
            {
                item.waitingVar++;
                if (item.priority > maxPriority)
                {
                    maxPriority = item.priority;
                    GChosenStudent.getChosenStudent = item;
                }
                else if (item.priority == maxPriority)
                {
                    if (rnd.Next(0, 2) == 0)
                    {
                        GChosenStudent.getChosenStudent = item;
                    }
                }
            }
        }
    }
}
