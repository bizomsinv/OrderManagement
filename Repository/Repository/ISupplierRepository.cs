using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface ISupplierRepository
    {
        Task<List<Entity.Entities.Supplier>> GetAll();
        Task<Entity.Entities.Supplier> GetById(int id);
        Task<Entity.Entities.Supplier> Add(Entity.Entities.Supplier supplier);
        Task<Entity.Entities.Supplier> Update(Entity.Entities.Supplier supplier);
        Task<string> DeleteById(int id);
        Task<bool> CheckDuplicate(Entity.Entities.Supplier supplier);
    }
}
