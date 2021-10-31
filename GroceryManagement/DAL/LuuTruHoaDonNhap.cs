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
    public class LuuTruHoaDonNhap
    {
        public static string filePath = HttpContext.Current.Server.MapPath("~\\Data\\HoaDonNhap.json");

        public static List<HoaDonNhap> docHoaDonNhap()
        {
            StreamReader reader = new StreamReader(File.Open(filePath, FileMode.OpenOrCreate));
            List<HoaDonNhap> dsHoaDonNhap = new List<HoaDonNhap>();
            string json = reader.ReadLine();
            if (!String.IsNullOrEmpty(json))
            {
                dsHoaDonNhap = JsonConvert.DeserializeObject<List<HoaDonNhap>>(json);
            }
            reader.Close();
            return dsHoaDonNhap;
        }

        public static void luuHoaDonNhap(HoaDonNhap hoaDonNhap)
        {
            List<HoaDonNhap> dsHoaDonNhap = docHoaDonNhap();
            dsHoaDonNhap.Add(hoaDonNhap);
            luuDanhSachHoaDonNhap(dsHoaDonNhap);
        }

        public static void luuDanhSachHoaDonNhap(List<HoaDonNhap> dsHoaDonNhap)
        {
            StreamWriter writer = new StreamWriter(filePath);
            string json = JsonConvert.SerializeObject(dsHoaDonNhap);
            writer.Write(json);
            writer.Close();
        }
    }
}