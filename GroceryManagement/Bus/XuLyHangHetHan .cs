using GroceryManagement.DAL;
using GroceryManagement.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GroceryManagement.Bus
{
    public class XuLyHangHetHang
    {
        public static bool isExpired(string date)
        {
            bool isExpired = false;
            DateTime expiredDate = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if(expiredDate < DateTime.Now.Date) {
                isExpired = true;
            }
            return isExpired;
        }

        public static List<KiemTraMatHang> capNhatSoLuongMatHangConlai(List<HoaDonNhap> dsHoaDonNhap, List<HoaDonBan> dsHoaDonBan)
        {
            List<KiemTraMatHang> dsKiemTraMatHang = new List<KiemTraMatHang>();
            for (int i = 0; i < dsHoaDonNhap.Count; i++)
            {
                KiemTraMatHang kt = new KiemTraMatHang();
                kt.id = "";
                kt.matHang = dsHoaDonNhap[i].tenMH;
                kt.soLuong = dsHoaDonNhap[i].soLuong;
                kt.expiredDate = "";
                kt.isExpired = false;
                dsKiemTraMatHang.Add(kt);
            }
            for (int i = 0; i < dsKiemTraMatHang.Count; i++)
            {
                for (int j = 0; j < dsHoaDonBan.Count; j++)
                {
                    if (string.Equals(dsKiemTraMatHang[i].matHang, dsHoaDonBan[j].tenMH))
                    {
                        KiemTraMatHang kt = new KiemTraMatHang();
                        kt.id = dsKiemTraMatHang[i].id;
                        kt.matHang = dsKiemTraMatHang[i].matHang;
                        kt.soLuong = dsKiemTraMatHang[i].soLuong - dsHoaDonBan[j].soLuong;
                        kt.expiredDate = dsKiemTraMatHang[i].expiredDate;
                        kt.isExpired = dsKiemTraMatHang[i].isExpired;
                        dsKiemTraMatHang[i] = kt;
                        break;
                    }
                }
            }

            return dsKiemTraMatHang;
        }

        public static List<KiemTraMatHang> capNhatThongTinMatHangHetHan(List<KiemTraMatHang> dsKiemTraMatHang, List<MatHang> dsMatHang)
        {
            for(int i=0; i<dsKiemTraMatHang.Count; i++)
            {
                for (int j = 0; j < dsMatHang.Count; j++)
                {
                    if (string.Equals(dsKiemTraMatHang[i].matHang, dsMatHang[j].ten))
                    {
                        KiemTraMatHang kt = new KiemTraMatHang();
                        kt.id = dsMatHang[j].id;
                        kt.matHang = dsKiemTraMatHang[i].matHang;
                        kt.soLuong = dsKiemTraMatHang[i].soLuong;
                        kt.expiredDate = dsMatHang[j].hsd;
                        kt.isExpired = isExpired(kt.expiredDate);
                        dsKiemTraMatHang[i] = kt;
                        break;
                    }
                }
            }
            return dsKiemTraMatHang;
        }
    }
}