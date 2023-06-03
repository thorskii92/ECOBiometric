using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO
{

    public class StoreData
    {
        
        public static int loggedID { get; set; }
        public static string HoldID {get; set;}
      
        public static string User {get; set;}
      
        public static string EmpID {get; set;}
    
        public static string HoldUserType {get; set;}

        public static int HoldIntID {get; set;}

        public static int HoldEmpID { get; set; }
        //public static int[] arrHoldEmpID = new int[]
        public static List<int> HoldEmpIDArr { get; set; }

        public static List<int> HoldUserIDArr { get; set; }

        public static int TotalEmpID { get; set; }
        public static int EmpSelectedIndex { get; set; }
        public static int HoldUpdateEmpID { get; set; }

        public static int WhatToOpenIndex { get; set; }

        public static string HoldName { get; set; }

        public static int SelectedUserID { get; set; }

        public static int selectedHolID { get; set; }

        public static int selectBioHold { get; set; }

        public static int selectBioEmpID { get; set; }

        public static string FingerPart { get; set; }
        public static int SelectedPayrollID { get; set; }

        public static string PayrollQuery { get; set; }

        public static string MultiPayrollQuery { get; set; }
    }
}
