using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Model.Factory;
using Model.Response;
using Repository.Repository;

namespace Domain.Queries
{
    public class GetAllSuppliersQuery : IRequest<List<SupplierResponse>>
    {
    }

    public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, List<SupplierResponse>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly ISupplierFactory _supplierFactory;
        public GetAllSuppliersQueryHandler(ISupplierRepository supplierRepository, ISupplierFactory supplierFactory)
        {
            _supplierRepository = supplierRepository;
            _supplierFactory = supplierFactory;
        }
        public async Task<List<SupplierResponse>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            var result = await _supplierRepository.GetAll();
            var response = _supplierFactory.ToSupplierResponseFromSupplierRequestList(result);

            return await Task.FromResult(response);
        }
    }
}
