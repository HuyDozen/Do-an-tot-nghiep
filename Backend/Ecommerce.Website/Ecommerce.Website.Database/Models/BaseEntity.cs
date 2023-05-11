﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string? ModifiedBy
        {
            get;set;
        } 
        public DateTime? ModifiedDate
        {
            get; set;
        }
        public string? CreatedBy
        {
            get; set;
        } 
        public DateTime? CreatedDate
        {
            get; set;
        }
        public bool? IsDeleted
        {
            get; set;
        } 
    }
}
