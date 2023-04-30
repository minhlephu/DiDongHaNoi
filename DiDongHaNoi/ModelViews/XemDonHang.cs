using System;
using System.Collections.Generic;
using DiDongHaNoi.Models;

namespace DiDongHaNoi.ModelViews
{
    public class XemDonHang
    {
        public Order DonHang { get; set; }
        public List<OrderDetail> ChiTietDonHang { get; set; }
    }
}
