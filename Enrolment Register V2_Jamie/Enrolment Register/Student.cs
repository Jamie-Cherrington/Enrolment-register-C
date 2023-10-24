using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolment_Register
{
    class Student
    {
        // backing field
        private string _name, _DOB, _gender, _mode, _year, _numModules, _totalFee;

        public Student()
        {
            _name = "";
            _DOB = "";
            _gender = "";
            _mode = "";
            _year = "";
            _numModules = "";
            _totalFee = "";

        }

        public string name { get; set; }
        public string DOB { get; set; }
        public string gender { get; set; }
   
        public string mode { get; set; }
        public string year { get; set; }
        public string numModules { get; set; }
        public string totalFee { get; set; }

        // ...

    }
}
