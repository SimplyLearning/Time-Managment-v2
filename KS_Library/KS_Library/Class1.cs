using System;
using System.Collections.Generic;

namespace KS_Library
{
    public class modulesLibrary
    {
        public string code { get; set; }
        public string modules { get; set; }
        public string name { get; set; }
        public int numCredit { get; set; }
        public int hoursWeek { get; set; }
        public int numWeeks { get; set; }
        public DateTime startDate { get; set; }
        public double ssHours { get; set; }
        public int numHours { get; set; }

        //storing num of hours on certain date 
        public double hourSpent { get; set; }
        public DateTime certainDate { get; set; }
        public String moduleStudied { get; set; }

        //this list is to store the module info 

        // public List<modulesLibrary> modList = new List<modulesLibrary>();
       public  Dictionary<String, double> modHours = new Dictionary<string, double>();


        //creating a list  to store the Self-Study Hours 
        //public List<double> hoursList = new List<double>();
            

        public double Calculation(int Credits, int hourw, int numw)
        {
            // calculation for self study hours
            return ssHours = ((Credits * 10) / numw) - hourw;
        }

    }
    
}
