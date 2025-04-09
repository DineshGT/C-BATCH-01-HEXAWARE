using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Exception_Handling
{
    public class ExceptionHandling
    {
        //Handles the exception when patient number is not there..
        public class PatientNumberNotFoundException : Exception
        {
            public PatientNumberNotFoundException(string message) : base(message) { }
        }
    }
}
