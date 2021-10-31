using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryManagement.Entity
{
    public struct KiemTraMatHang
    {
        public string id;
        public string matHang;
        public int soLuong;
        public string expiredDate;
        public bool isExpired;
    }
}