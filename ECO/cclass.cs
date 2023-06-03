using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data.Sql;
using System.Data;


namespace ECO
{
    class cclass
    {
    }

    public class msqlcon
    {
        public static MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password='rootpass123';persistsecurityinfo=True;database=ecosoldb");
    }

    public class CheckOpen
    {
        public static void cons()
        {
            if (msqlcon.con.State != ConnectionState.Open)
            {
                msqlcon.con.Open();
            }
           
        }

        public static void conx()
        {
            if (msqlcon.con.State != ConnectionState.Closed)
            {
                msqlcon.con.Close();
            }
        }
    }

   public class GetFormula
    {
        public static Double Ans(string strFormula)
        {
            string formula = strFormula; //or get it from DB
           
            StringToFormula stf = new StringToFormula();
            double result = stf.Eval(formula);
            return result;
        }
    }

    static class MySQLConnect
    {

        

        //public static MySqlConnection Connection
        //{
        //    get
        //    {
        //        if (_Connection == null)
        //        {
        //            //string cs = "server=127.0.0.1; user id=root; password='root'; database=ecosoldb";
        //            string constring = "SERVER=localhost;DATABASE=ecosoldb;UID='root';PASSWORD='root'";
        //            _Connection = new MySqlConnection(constring);
        //        }

        //        if (_Connection.State == ConnectionState.Closed) 
        //            try
        //            {
        //                _Connection.Open();
        //            }
        //            catch (Exception ex)
        //            {

        //                //handle your exception here
        //            }
        //        return _Connection;
        //    }
        //}
    }
    public class mSQLCon
    {
   
    }
}
