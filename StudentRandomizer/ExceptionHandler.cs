using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRandomizer
{
    public class ExceptionHandler
    {
        public static bool VitalHandle(string str)
        {
            ErrorMsgBox.Show(str);
            return false;
        }

        public static int NonVitalIntHandle(int integer)
        { 
            return integer;
        }

    }
}
