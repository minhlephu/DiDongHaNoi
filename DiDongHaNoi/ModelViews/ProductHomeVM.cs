﻿using System;
using System.Collections.Generic;
using DiDongHaNoi.Models;

namespace DiDongHaNoi.ModelViews
{
    public class ProductHomeVM
    {
        public Category category { get; set; }
        public List<Product> lsProducts { get; set; }
    }
}
