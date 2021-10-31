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
    public class LuuTruLoaiHang
    {
        public static string filePath = HttpContext.Current.Server.MapPath("~\\Data\\LoaiHang.json");

        public static List<LoaiHang> docLoaiHang()
        {
            StreamReader reader = new StreamReader(File.Open(filePath, FileMode.OpenOrCreate));
            List<LoaiHang> dsLoaiHang = new List<LoaiHang>();
            string json = reader.ReadLine();
            if (!String.IsNullOrEmpty(json))
            {
                dsLoaiHang = JsonConvert.DeserializeObject<List<LoaiHang>>(json);
            }
            reader.Close();
            return dsLoaiHang;
        }

        public static void luuLoaiHang(LoaiHang loaiHang)
        {
            List<LoaiHang> dsLoaiHang = docLoaiHang();
            if(dsLoaiHang.Count == 0)
            {
                loaiHang.id = 1;
            }
            else
            {
                loaiHang.id = dsLoaiHang.Max(lh => lh.id) + 1;
            }
            dsLoaiHang.Add(loaiHang);
            luuDanhSachLoaiHang(dsLoaiHang);
        }

        public static void luuDanhSachLoaiHang(List<LoaiHang> dsLoaiHang)
        {
            StreamWriter writer = new StreamWriter(filePath);
            string json = JsonConvert.SerializeObject(dsLoaiHang);
            writer.Write(json);
            writer.Close();
        }
    }
}