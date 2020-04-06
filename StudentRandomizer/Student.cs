using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRandomizer
{
    public class Student
    {
        public string albumNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int correctAnswers { get; set; }
        public int wrongAnswers { get; set; }
        public int notAnswered { get; set; }
        public int priority { get; set; }
        public int waitingVar { get; set; }

        public Student()
        {
            albumNumber = "";
            firstName = "";
            lastName = "";
            correctAnswers = 0;
            wrongAnswers = 0;
            notAnswered = 0;
            waitingVar = 0;
        }
        //Set choosing priority for students
        public void CheckPriority(Random rnd)
        {
            priority = rnd.Next(100, 200) - correctAnswers * 2 - wrongAnswers * 1 + notAnswered * 2 + waitingVar * 2;
            if(priority < 50)
            {
                priority = 50;
            }
        }

        //Get name, surname and album number
        public string GetText()
        {
            StringBuilder strBuild = new StringBuilder();
            strBuild.AppendFormat("{0} {1} {2}",firstName, lastName, albumNumber);
            string str = strBuild.ToString();
            return str;
        }

        //Get every prop of student
        public string GetStudent()
        {
            StringBuilder strBuild = new StringBuilder();
            strBuild.AppendFormat("{0} {1} {2} {3} {4} {5} {6}", 
                firstName, lastName, albumNumber, correctAnswers, wrongAnswers, notAnswered, waitingVar);
            string str = strBuild.ToString();
            return str;
        }

        //Use string to set student's props
        public bool CopyFromString(string str)
        {
            string[] studentAdding = new string[7];
            studentAdding = str.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            bool result = true;

            try
            {
                this.firstName = studentAdding[0];
            }
            catch (IndexOutOfRangeException e)
            {
                result = ExceptionHandler.VitalHandle("First name cannot be found.");
            }
            if (result == false)
            {
                return false;
            }

            try
            {
                this.lastName = studentAdding[1];
            }
            catch (IndexOutOfRangeException e)
            {
                result = ExceptionHandler.VitalHandle("Last name cannot be found.");
            }
            if (result == false)
            {
                return false;
            }

            try
            {
                this.albumNumber = studentAdding[2];
            }
            catch (IndexOutOfRangeException e)
            {
                result = ExceptionHandler.VitalHandle("Album Number name cannot be found.");
            }
            if (result == false)
            {
                return false;
            }

            try
            {
                this.correctAnswers = Convert.ToInt32(studentAdding[3]);
            }
            catch(IndexOutOfRangeException e)
            {
                this.correctAnswers = ExceptionHandler.NonVitalIntHandle(0);
            }

            try
            {
                this.wrongAnswers = Convert.ToInt32(studentAdding[4]);
            }
            catch (IndexOutOfRangeException e)
            {
                this.wrongAnswers = ExceptionHandler.NonVitalIntHandle(0);
            }

            try
            {
                this.notAnswered = Convert.ToInt32(studentAdding[5]);
            }
            catch (IndexOutOfRangeException e)
            {
                this.notAnswered = ExceptionHandler.NonVitalIntHandle(0);
            }

            try
            {
                this.waitingVar = Convert.ToInt32(studentAdding[6]);
            }
            catch (IndexOutOfRangeException e)
            {
                this.waitingVar = ExceptionHandler.NonVitalIntHandle(0);
            }
            if(result == false)
            {
                return false;
            }
            return true;
        }

    }
}
