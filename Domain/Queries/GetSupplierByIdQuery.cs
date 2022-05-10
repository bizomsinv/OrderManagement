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
    public class GetSupplierByIdQuery : IRequest<SupplierResponse>
    {
        public int Id { get; set; }
        public GetSupplierByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, SupplierResponse>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly ISupplierFactory _supplierFactory;
        public GetSupplierByIdQueryHandler(ISupplierRepository supplierRepository, ISupplierFactory supplierFactory)
        {
            _supplierRepository = supplierRepository;
            _supplierFactory = supplierFactory;
        }
        public async Task<SupplierResponse> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _supplierRepository.GetById(request.Id);
            var response = _supplierFactory.ToSupplierVMFromSupplier(result);

            return await Task.FromResult(response);
        }
    }
}
