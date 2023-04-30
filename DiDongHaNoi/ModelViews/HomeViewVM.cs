using System;
using System.Collections.Generic;
using DiDongHaNoi.Models;

namespace DiDongHaNoi.ModelViews
{
    public class HomeViewVM
    {
        public List<Post> TinTucs { get; set; }
        public List<ProductHomeVM> Products { get; set; }
    }
}
