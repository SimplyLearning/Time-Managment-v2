using System;
using System.Collections.Generic;
using System.Text;

namespace ST10090436KSimpsonPart2PROG
{
    class UserData : IComparable
    {
        public string Username = "";
        public string ModuleName = "";
        public string ModuleCode = "";
        public int NumOfCredits = 0;
        public int HoursPerWeek = 0;
        public string StartDate = "";
        public int NumOfWeeks = 0;

        public string moduleName { get => ModuleName; set => ModuleName = value; }
        public string moduleCode { get => ModuleCode; set => ModuleCode = value; }
        public int numOfCredits { get => NumOfCredits; set => NumOfCredits = value; }
        public int hoursPerWeek { get => HoursPerWeek; set => HoursPerWeek = value; }
        public string startDate { get => StartDate; set => StartDate = value; }
        public int numOfWeeks { get => NumOfWeeks; set => NumOfWeeks = value; }

        public UserData()
        {
        }

        public UserData (string Username, string ModuleName, string ModuleCode, int NumOfCredits, int HoursPerWeek, string StartDate, int NumOfWeeks)
        {
            this.Username = Username;
            ModuleName = moduleName;
            ModuleCode = moduleCode;
            NumOfCredits = numOfCredits;
            HoursPerWeek = hoursPerWeek;
            StartDate = startDate;
            NumOfWeeks = numOfWeeks;

        }
        public int CompareTo(object obj)
        {
            return ModuleCode.CompareTo(obj.ToString());
        }
        public override string ToString()
        {
            return ModuleCode;
        }
    }
}
