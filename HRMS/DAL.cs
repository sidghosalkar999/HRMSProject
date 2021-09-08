using System;
using HRMS;
using Model;

namespace HRMS
{
    class DAL
    {
        static void Main(string[] args)
        {
            Class1 C = new Class1();
            C.DisplayHRMS();

            C.AddHRMS();
            C.DisplayHRMS();

            C.EditHRMS();
            C.DisplayHRMS();

            C.DeleteHRMS();
            C.DisplayHRMS();
        }
    }
}
