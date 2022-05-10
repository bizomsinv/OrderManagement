using Entity.Entities;
using Model.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly DBContext _dbContext;
        public SupplierRepository(DBContext dBContext)
        {
            _dbContext = dBContext;
        }

        #region DB Operations
        public async Task<Entity.Entities.Supplier> Add(Entity.Entities.Supplier supplier)
        {
            await _dbContext.Suppliers.AddAsync(supplier);
            await _dbContext.SaveChangesAsync();
            return await Task.FromResult(supplier);
        }

        public async Task<bool> CheckDuplicate(Entity.Entities.Supplier supplier)
        {
            if (_dbContext.Suppliers.Where(x => x.Name.Trim().ToLower().Equals(supplier.Name)).FirstOrDefault() != null)
            {
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<string> DeleteById(int id)
        {
            var record = _dbContext.Suppliers.Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (record != null)
            {
                record.IsActive = false;
                _dbContext.Suppliers.Update(record);
                await _dbContext.SaveChangesAsync();
            }
            return await Task.FromResult(SupplierMessages.Success);
        }

        public async Task<List<Entity.Entities.Supplier>> GetAll()
        {
            return await Task.FromResult(_dbContext.Suppliers.Where(x => x.IsActive).ToList());
        }

        public async Task<Entity.Entities.Supplier> GetById(int id)
        {
            return await Task.FromResult(_dbContext.Suppliers.Where(x => x.Id.Equals(id)).FirstOrDefault());
        }

        public async Task<Entity.Entities.Supplier> Update(Entity.Entities.Supplier supplier)
        {
            _dbContext.Suppliers.Update(supplier);
            await _dbContext.SaveChangesAsync();
            return await Task.FromResult(supplier);
        }
        #endregion
    }
}
