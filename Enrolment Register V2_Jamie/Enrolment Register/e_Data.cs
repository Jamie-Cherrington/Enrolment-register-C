using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolment_Register
{
    static class e_Data
    { 
        // List structure for storing list (array) or Students
        public static List<Student> s_List = new List<Student>();

        // Global variables for storing course details
        public static string courseName, courseLecturer;
        public static double coursePCF, coursePCM, coursePCO;

        //Global variables for stroing student details
        public static string studentName, DOB, gender, mode, year, numModules, totalFee;
    }
}
