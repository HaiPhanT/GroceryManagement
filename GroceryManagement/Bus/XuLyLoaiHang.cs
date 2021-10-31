using GroceryManagement.DAL;
using GroceryManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GroceryManagement.Bus
{
    public class XuLyLoaiHang
    {
        public static List<LoaiHang> docLoaiHang()
        {
            List<LoaiHang> dsLoaiHang = LuuTruLoaiHang.docLoaiHang();
            return dsLoaiHang;
        }

        public static void luuLoaiHang(LoaiHang loaiHang)
        {
            LuuTruLoaiHang.luuLoaiHang(loaiHang);
        }

        public static void xoaLoaiHang(LoaiHang loaiHang)
        {
            List<LoaiHang> dsLoaiHang = docLoaiHang();
            for(int i=0; i< dsLoaiHang.Count; i++)
            {
                if(dsLoaiHang[i].id == loaiHang.id)
                {
                    dsLoaiHang.RemoveAt(i);
                }
            }
            LuuTruLoaiHang.luuDanhSachLoaiHang(dsLoaiHang);
        }

        public static void suaLoaiHang(LoaiHang m)
        {
            List<LoaiHang> dsLoaiHang = docLoaiHang();
            for (int i = 0; i < dsLoaiHang.Count; i++)
            {
                if (dsLoaiHang[i].id == m.id)
                {
                    dsLoaiHang[i] = m;
                }
            }
            LuuTruLoaiHang.luuDanhSachLoaiHang(dsLoaiHang);
        }

        public static List<LoaiHang> timKiemLoaiHang(string searchWord)
        {
            List<LoaiHang> dsLoaiHang = docLoaiHang();
            List<LoaiHang> result = new List<LoaiHang>();
            foreach(LoaiHang lh in dsLoaiHang)
            {
                if (lh.loaiHang.Contains(searchWord))
                {
                    result.Add(lh);
                }
            }
            return result;
        }
    }
}