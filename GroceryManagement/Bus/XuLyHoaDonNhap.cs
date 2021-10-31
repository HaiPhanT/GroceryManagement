using GroceryManagement.DAL;
using GroceryManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GroceryManagement.Bus
{
    public class XuLyHoaDonNhap
    {
        public static List<HoaDonNhap> docHoaDonNhap()
        {
            List<HoaDonNhap> dsHoaDonNhap = LuuTruHoaDonNhap.docHoaDonNhap();
            return dsHoaDonNhap;
        }

        public static void luuHoaDonNhap(HoaDonNhap hoaDonNhap)
        {
            LuuTruHoaDonNhap.luuHoaDonNhap(hoaDonNhap);
        }

        public static void xoaHoaDonNhap(string id)
        {
            List<HoaDonNhap> dsHoaDonNhap = docHoaDonNhap();
            for(int i=0; i< dsHoaDonNhap.Count; i++)
            {
                if(string.Equals(dsHoaDonNhap[i].id, id))
                {
                    dsHoaDonNhap.RemoveAt(i);
                }
            }
            LuuTruHoaDonNhap.luuDanhSachHoaDonNhap(dsHoaDonNhap);
        }

        public static void suaHoaDonNhap(HoaDonNhap h)
        {
            List<HoaDonNhap> dsHoaDonNhap = docHoaDonNhap();
            for (int i = 0; i < dsHoaDonNhap.Count; i++)
            {
                if (string.Equals(dsHoaDonNhap[i].id, h.id))
                {
                    dsHoaDonNhap[i] = h;
                }
            }
            LuuTruHoaDonNhap.luuDanhSachHoaDonNhap(dsHoaDonNhap);
        }

        public static List<HoaDonNhap> timKiemHoaDonNhap(string searchType, string searchWord)
        {
            List<HoaDonNhap> dsHoaDonNhap = docHoaDonNhap();
            List<HoaDonNhap> result = new List<HoaDonNhap>();
            switch (searchType)
            {
                case "id":
                    foreach(HoaDonNhap h in dsHoaDonNhap)
                    {
                        if (h.id.ToLower().Contains(searchWord.ToLower()))
                        {
                            result.Add(h);
                        }
                    }
                    break;
                case "tenMH":
                    foreach (HoaDonNhap h in dsHoaDonNhap)
                    {
                        if (h.tenMH.ToLower().Contains(searchWord.ToLower()))
                        {
                            result.Add(h);
                        }
                    }
                    break;
                case "ngayNhap":
                    foreach (HoaDonNhap h in dsHoaDonNhap)
                    {
                        if (h.ngayNhap.Contains(searchWord))
                        {
                            result.Add(h);
                        }
                    }
                    break;
                case "soLuong":
                    foreach (HoaDonNhap h in dsHoaDonNhap)
                    {
                        if (h.soLuong == int.Parse(searchWord))
                        {
                            result.Add(h);
                        }
                    }
                    break;
                case "loai":
                    foreach (HoaDonNhap h in dsHoaDonNhap)
                    {
                        if (h.loai.ToLower().Contains(searchWord.ToLower()))
                        {
                            result.Add(h);
                        }
                    }
                    break;
                default:
                    result = docHoaDonNhap();
                    break;
            }
            return result;
        }
    }
}