using GroceryManagement.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace GroceryManagement.DAL
{
    public class LuuTruHoaDonBan
    {
        public static string filePath = HttpContext.Current.Server.MapPath("~\\Data\\HoaDonBan.json");

        public static List<HoaDonBan> docHoaDonBan()
        {
            StreamReader reader = new StreamReader(File.Open(filePath, FileMode.OpenOrCreate));
            List<HoaDonBan> dsHoaDonBan = new List<HoaDonBan>();
            string json = reader.ReadLine();
            if (!String.IsNullOrEmpty(json))
            {
                dsHoaDonBan = JsonConvert.DeserializeObject<List<HoaDonBan>>(json);
            }
            reader.Close();
            return dsHoaDonBan;
        }

        public static void luuHoaDonBan(HoaDonBan hoaDonBan)
        {
            List<HoaDonBan> dsHoaDonBan = docHoaDonBan();
            dsHoaDonBan.Add(hoaDonBan);
            luuDanhSachHoaDonBan(dsHoaDonBan);
        }

        public static void luuDanhSachHoaDonBan(List<HoaDonBan> dsHoaDonBan)
        {
            StreamWriter writer = new StreamWriter(filePath);
            string json = JsonConvert.SerializeObject(dsHoaDonBan);
            writer.Write(json);
            writer.Close();
        }
    }
}