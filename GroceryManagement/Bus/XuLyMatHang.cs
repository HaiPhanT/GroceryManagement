using GroceryManagement.DAL;
using GroceryManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GroceryManagement.Bus
{
    public class XuLyMatHang
    {
        public static List<MatHang> docMatHang()
        {
            List<MatHang> dsMatHang = LuuTruMatHang.docMatHang();
            return dsMatHang;
        }

        public static void luuMatHang(MatHang matHang)
        {
            LuuTruMatHang.luuMatHang(matHang);
        }

        public static void xoaMatHang(string id)
        {
            List<MatHang> dsMatHang = docMatHang();
            for(int i=0; i<dsMatHang.Count; i++)
            {
                if(string.Equals(dsMatHang[i].id, id))
                {
                    dsMatHang.RemoveAt(i);
                }
            }
            LuuTruMatHang.luuDanhSachMatHang(dsMatHang);
        }

        public static void suaMatHang(MatHang m)
        {
            List<MatHang> dsMatHang = docMatHang();
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (string.Equals(dsMatHang[i].id, m.id))
                {
                    dsMatHang[i] = m;
                }
            }
            LuuTruMatHang.luuDanhSachMatHang(dsMatHang);
        }

        public static List<MatHang> timKiemMatHang(string searchType, string searchWord)
        {
            List<MatHang> dsMatHang = docMatHang();
            List<MatHang> result = new List<MatHang>();
            switch (searchType)
            {
                case "id":
                    foreach(MatHang m in dsMatHang)
                    {
                        if (m.id.ToLower().Contains(searchWord.ToLower()))
                        {
                            result.Add(m);
                        }
                    }
                    break;
                case "ten":
                    foreach (MatHang m in dsMatHang)
                    {
                        if (m.ten.ToLower().Contains(searchWord.ToLower()))
                        {
                            result.Add(m);
                        }
                    }
                    break;
                case "hsd":
                    foreach (MatHang m in dsMatHang)
                    {
                        if (m.hsd.Contains(searchWord))
                        {
                            result.Add(m);
                        }
                    }
                    break;
                case "cty":
                    foreach (MatHang m in dsMatHang)
                    {
                        if (m.cty.ToLower().Contains(searchWord.ToLower()))
                        {
                            result.Add(m);
                        }
                    }
                    break;
                case "nsx":
                    foreach (MatHang m in dsMatHang)
                    {
                        if (m.nsx.ToString().Contains(searchWord))
                        {
                            result.Add(m);
                        }
                    }
                    break;
                case "loai":
                    foreach (MatHang m in dsMatHang)
                    {
                        if (m.loai.ToLower().Contains(searchWord.ToLower()))
                        {
                            result.Add(m);
                        }
                    }
                    break;
                default:
                    result = docMatHang();
                    break;
            }
            return result;
        }
    }
}