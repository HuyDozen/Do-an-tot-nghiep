﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<OrderDetail>? orderDetails { get; set; }
    }
}
