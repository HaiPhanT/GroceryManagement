using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryManagement.Entity
{
    public class Helper
    {
        public static string getFormattedDate(string dateTime)
        {
            string[] m = dateTime.Split(' ');
            string[] yyyymmdd = m[0].Split('-');
            string[] ddmmyyyy = new string[3];
            if (yyyymmdd.Length < 3)
            {
                return dateTime;
            }
            ddmmyyyy[0] = yyyymmdd[2];
            ddmmyyyy[1] = yyyymmdd[1];
            ddmmyyyy[2] = yyyymmdd[0];
            string formatedDate = String.Join("/", ddmmyyyy);
            return formatedDate;
        }
    }
}