using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

namespace ECO
{
   
    public class queryClass
    {
        public static DataTable PubDT = new DataTable();
        public static void dataquery(string strq)
            {
            CheckOpen.cons();
            //DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(strq, msqlcon.con);
            da.Fill(PubDT);
            }
    }

    public class querySelect
    {
        public static void loadposition()
        {
            
        }
    }

    public class EmployeeQuery
    {
        public static DataTable EmpdetailsDT = new DataTable();
        public static void EmpDataQuery(int empIndex)
        {
            CheckOpen.cons();
            //StoreData.EmpSelectedIndex = empIndex;
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT E.empID, E.LastName, E.FirstName, E.MiddleInitial, E.HouseNo, E.StreetName, E.Barangay, E.City, E.NickName, E.EmailAdd, E.MobileNo, E.Birthday, E.Birthplace, E.Gender, E.CivilStat, E.Citizenship, E.Religion, E.Height, E.Weight, E.BloodType, E.DateHired, E.TIN, E.PhilHealth, E.SSSID, E.PAGIBIGID, E.ConPerLast, E.ConPerFirst, E.ConPersMI, E.ConPerMobNo, E.ConPersRelationship, E.ConPersHouseNo, E.ConPersStreetName, E.ConPersBarangay, E.ConPersCity, E.empStat, E.ResignationDate, P.PositionName, E.IDPic FROM emp AS E LEFT JOIN empposition AS P ON E.positionID=P.positionID WHERE empID=" + StoreData.HoldEmpIDArr[empIndex], msqlcon.con);
            EmpdetailsDT.Clear();
            da.Fill(EmpdetailsDT);
        }
    }

    public class UserLogger
    {
        public static void LogUser(int uID, string logType)
        {
            CheckOpen.cons();
            MySqlCommand cmd = new MySqlCommand ("INSERT INTO userLog(uID, logDate, logTime, logType) VALUES(" + uID + ",'" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + logType + "')", msqlcon.con);
            cmd.ExecuteNonQuery();
        }
    }
}
