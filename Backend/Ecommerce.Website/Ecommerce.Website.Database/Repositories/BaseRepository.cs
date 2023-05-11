using Ecommerce.Website.Database.Contacts;
using Ecommerce.Website.Database.Data;
using Ecommerce.Website.Database.Models;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.Website.Database.Repositories
{
    public class BaseRepository <T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly EcommerceContext context;
        private DbSet<T> entities;
        //string errorMessage = string.Empty;
        public BaseRepository(EcommerceContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAllRecords()
        {
            return entities.AsEnumerable();
        }
        public T GetRecordById(int id)
        {
            var recordById = entities.Where(s => s.Id == id).Select(s => s).FirstOrDefault();
                    
            return recordById;
           
            
            //return entities.FirstOrDefault(s => s.Id == id);
        }
        
        public void InsertRecord(T entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }
        public void UpdateRecord(T entity)
        {
            // Xử lý thêm việc nhập id không trùng
             
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                entities.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
                
        }
        public void DeleteRecord(int id)
        {
            var record = entities.SingleOrDefault(s => s.Id.Equals(id)); // Lấy thông tin record theo id truyền vào
            if (record == null)
            {
                throw new ArgumentNullException("entity");
            }
            else {
                entities.Remove(record);
                context.SaveChanges();
            }
            
        }

    }
}
