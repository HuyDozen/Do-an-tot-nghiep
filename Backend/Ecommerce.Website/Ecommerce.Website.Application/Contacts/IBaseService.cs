using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Application.Contacts
{
    public interface IBaseService<T>
    {
        IEnumerable<T> GetAllRecords();
        T GetRecordById(int id);
        void InsertRecord(T entity);
        void UpdateRecord(T entity);
        void DeleteRecord(int id);
    }
}
