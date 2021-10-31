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
    public class LuuTruMatHang
    {
        public static string filePath = HttpContext.Current.Server.MapPath("~\\Data\\MatHang.json");

        public static List<MatHang> docMatHang()
        {
            StreamReader reader = new StreamReader(File.Open(filePath, FileMode.OpenOrCreate));
            List<MatHang> dsMatHang = new List<MatHang>();
            string json = reader.ReadLine();
            if (!String.IsNullOrEmpty(json))
            {
                dsMatHang = JsonConvert.DeserializeObject<List<MatHang>>(json);
            }
            reader.Close();
            return dsMatHang;
        }

        public static void luuMatHang(MatHang matHang)
        {
            List<MatHang> dsMatHang = docMatHang();
            dsMatHang.Add(matHang);
            luuDanhSachMatHang(dsMatHang);
        }

        public static void luuDanhSachMatHang(List<MatHang> dsMatHang)
        {
            StreamWriter writer = new StreamWriter(filePath);
            string json = JsonConvert.SerializeObject(dsMatHang);
            writer.Write(json);
            writer.Close();
        }
    }
}