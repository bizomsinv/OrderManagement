using Entity.Entities;
using MediatR;
using Model.Constant;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class DeleteSupplierCommand : IRequest<string>
    {
        public int SupplierId { get; set; }

        public DeleteSupplierCommand(int supplierId)
        {
            SupplierId = supplierId;
        }
    }

    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, string>
    {
        private readonly ISupplierRepository _supplierRepository;
        public DeleteSupplierCommandHandler(ISupplierRepository supplierRepository)
        {
            this._supplierRepository = supplierRepository;
        }
        public async Task<string> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {

            if (_supplierRepository.GetById(request.SupplierId).Result == null)
            {
                return await Task.FromResult(SupplierMessages.NoRecordFound);
            }

            await _supplierRepository.DeleteById(request.SupplierId);

            return await Task.FromResult(SupplierMessages.Success);
        }
    }
}
