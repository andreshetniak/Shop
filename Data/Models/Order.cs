﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public DateTime orderTime { get; set; }
        public List<OrderDetail> OrderDitails { get; set; }
    }
}