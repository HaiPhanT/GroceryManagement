using GroceryManagement.DAL;
using GroceryManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GroceryManagement.Bus
{
    public class XuLyHoaDonBan
    {
        public static List<HoaDonBan> docHoaDonBan()
        {
            List<HoaDonBan> dsHoaDonBan = LuuTruHoaDonBan.docHoaDonBan();
            return dsHoaDonBan;
        }

        public static void luuHoaDonBan(HoaDonBan hoaDonBan)
        {
            LuuTruHoaDonBan.luuHoaDonBan(hoaDonBan);
        }

        public static void xoaHoaDonBan(string id)
        {
            List<HoaDonBan> dsHoaDonBan = docHoaDonBan();
            for(int i=0; i< dsHoaDonBan.Count; i++)
            {
                if(string.Equals(dsHoaDonBan[i].id, id))
                {
                    dsHoaDonBan.RemoveAt(i);
                }
            }
            LuuTruHoaDonBan.luuDanhSachHoaDonBan(dsHoaDonBan);
        }

        public static void suaHoaDonBan(HoaDonBan h)
        {
            List<HoaDonBan> dsHoaDonBan = docHoaDonBan();
            for (int i = 0; i < dsHoaDonBan.Count; i++)
            {
                if (string.Equals(dsHoaDonBan[i].id, h.id))
                {
                    dsHoaDonBan[i] = h;
                }
            }
            LuuTruHoaDonBan.luuDanhSachHoaDonBan(dsHoaDonBan);
        }

        public static List<HoaDonBan> timKiemHoaDonBan(string searchType, string searchWord)
        {
            List<HoaDonBan> dsHoaDonBan = docHoaDonBan();
            List<HoaDonBan> result = new List<HoaDonBan>();
            switch (searchType)
            {
                case "id":
                    foreach(HoaDonBan h in dsHoaDonBan)
                    {
                        if (h.id.ToLower().Contains(searchWord.ToLower()))
                        {
                            result.Add(h);
                        }
                    }
                    break;
                case "tenMH":
                    foreach (HoaDonBan h in dsHoaDonBan)
                    {
                        if (h.tenMH.ToLower().Contains(searchWord.ToLower()))
                        {
                            result.Add(h);
                        }
                    }
                    break;
                case "ngayBan":
                    foreach (HoaDonBan h in dsHoaDonBan)
                    {
                        if (h.ngayBan.Contains(searchWord))
                        {
                            result.Add(h);
                        }
                    }
                    break;
                case "soLuong":
                    foreach (HoaDonBan h in dsHoaDonBan)
                    {
                        if (h.soLuong == int.Parse(searchWord))
                        {
                            result.Add(h);
                        }
                    }
                    break;
                case "loai":
                    foreach (HoaDonBan h in dsHoaDonBan)
                    {
                        if (h.loai.ToLower().Contains(searchWord.ToLower()))
                        {
                            result.Add(h);
                        }
                    }
                    break;
                default:
                    result = docHoaDonBan();
                    break;
            }
            return result;
        }
    }
}