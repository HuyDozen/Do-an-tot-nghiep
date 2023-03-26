using Ecommerce.Website.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Contacts
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAllRecords();
        T GetRecordById(int id);
        void InsertRecord(T entity);
        void UpdateRecord(T entity);
        void DeleteRecord(int id);
    }
}
