using GroceryManagement.DAL;
using GroceryManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GroceryManagement.Bus
{
    public class XuLySoLuongHang
    {
        public static List<SoLuongHang> capNhatSoLuong(List<HoaDonNhap> dsHoaDonNhap, List<HoaDonBan> dsHoaDonBan)
        {
            List<SoLuongHang> dsSoLuongHang = new List<SoLuongHang>();
            for (int i = 0; i < dsHoaDonNhap.Count; i++)
            {
                SoLuongHang sl = new SoLuongHang();
                sl.soLuong = dsHoaDonNhap[i].soLuong;
                sl.loaiHang = dsHoaDonNhap[i].loai;
                for (int j = i+1; j < dsHoaDonNhap.Count;)
                {
                    if (string.Equals(sl.loaiHang, dsHoaDonNhap[j].loai))
                    {
                        sl.soLuong += dsHoaDonNhap[j].soLuong;
                        dsHoaDonNhap.RemoveAt(j);
                    }
                    else
                    {
                        j++;
                    }
                }
                dsSoLuongHang.Add(sl);
            }
            for (int i = 0; i < dsSoLuongHang.Count; i++)
            {
                for (int j = 0; j < dsHoaDonBan.Count; j++)
                {
                    if (string.Equals(dsSoLuongHang[i].loaiHang, dsHoaDonBan[j].loai))
                    {
                        SoLuongHang sl = new SoLuongHang();
                        sl.loaiHang = dsSoLuongHang[i].loaiHang;
                        sl.soLuong = dsSoLuongHang[i].soLuong;

                        sl.soLuong -= dsHoaDonBan[j].soLuong;
                        dsSoLuongHang[i] = sl;
                    }
                }
            }

            return dsSoLuongHang;
        }
    }
}