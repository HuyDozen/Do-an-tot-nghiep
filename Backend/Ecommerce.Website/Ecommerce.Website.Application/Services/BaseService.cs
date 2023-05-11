using Ecommerce.Website.Application.Contacts;

using Ecommerce.Website.Database.Contacts;
using Ecommerce.Website.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Application.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _baseRepository;
        
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public IEnumerable<T> GetAllRecords()
        {
            try
            {

                var records = _baseRepository.GetAllRecords();
                
                return records;

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
           
        }

        public T GetRecordById(int id)
        {
            try
            {
                return _baseRepository.GetRecordById(id);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
          
        }

        public void InsertRecord(T entity)
        {
            try
            {
                if (entity == null)
                {

                    throw new ArgumentNullException("entity");
                }
                _baseRepository.InsertRecord(entity);

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
          
        }

        public void UpdateRecord(T entity)
        {
            try
            {
                _baseRepository.UpdateRecord(entity);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            
        }

        public void DeleteRecord(int id)
        {
            try
            {
                _baseRepository.DeleteRecord(id);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            
        }

        
    }
}
