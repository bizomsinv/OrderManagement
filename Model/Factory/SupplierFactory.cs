using Entity.Entities;
using Model.Request;
using Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Factory
{
    public class SupplierFactory : ISupplierFactory
    {
        public Entity.Entities.Supplier ToSupplierFromSupplierRequest(SupplierRequest request)
        {
            return new Entity.Entities.Supplier
            {
                Id = request.SupplierId,
                Address1 = request.AddressLine1,
                Address2 = request.AddressLine2,
                City = request.City,
                IsActive = request.IsActive,
                Name = request.SupplierName,
                PostalCode = request.PostalCodel,
                State = request.State
            };
        }

        public List<Entity.Entities.Supplier> ToSupplierFromSupplierRequestList(List<SupplierRequest> request)
        {
            return request.Select(x => ToSupplierFromSupplierRequest(x)).ToList();
        }

        public List<SupplierResponse> ToSupplierResponseFromSupplierRequestList(List<Entity.Entities.Supplier> request)
        {
            return request.Select(x => ToSupplierVMFromSupplier(x)).ToList();
        }

        public SupplierResponse ToSupplierVMFromSupplier(Entity.Entities.Supplier request)
        {
            return new SupplierResponse
            {
                SupplierId = request.Id,
                AddressLine1 = request.Address1,
                AddressLine2 = request.Address2,
                City = request.City,
                PostalCode = request.PostalCode,
                IsActive = request.IsActive,
                State = request.State,
                SupplierName = request.Name
            };
        }
    }
}
