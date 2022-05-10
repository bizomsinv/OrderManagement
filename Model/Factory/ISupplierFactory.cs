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
    public interface ISupplierFactory
    {
        public Entity.Entities.Supplier ToSupplierFromSupplierRequest(SupplierRequest request);
        public List<Entity.Entities.Supplier> ToSupplierFromSupplierRequestList(List<SupplierRequest> request);
        public SupplierResponse ToSupplierVMFromSupplier(Entity.Entities.Supplier request);
        public List<SupplierResponse> ToSupplierResponseFromSupplierRequestList(List<Entity.Entities.Supplier> request);
    }
}
