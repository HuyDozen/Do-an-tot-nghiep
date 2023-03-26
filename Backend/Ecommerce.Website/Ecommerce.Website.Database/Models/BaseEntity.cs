using System;
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
        } = "Huy";
        public DateTime? ModifiedDate
        {
            get; set;
        } = DateTime.Now;
        public string? CreatedBy
        {
            get; set;
        } = "Huy";
        public DateTime? CreatedDate
        {
            get; set;
        } = DateTime.Now; //Khi tạo mặc định sẽ lấy time hiện tại
        public bool? IsDeleted
        {
            get; set;
        } = false; //Khi tạo giá trị mặc định sẽ là fall}
    }
}
