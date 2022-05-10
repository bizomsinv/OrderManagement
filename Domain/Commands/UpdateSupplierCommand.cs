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
    public class UpdateSupplierCommand : IRequest<(Entity.Entities.Supplier, string)>
    {
        public string SupplierName { get; set; } = null!;
        public string AddressLine1 { get; set; } = null!;
        public string AddressLine2 { get; set; } = null!;
        public string PostalCodel { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public int SupplierId { get; set; }

        public UpdateSupplierCommand(string supplierName,
            string addressLine1,
            string addressLine2,
            string postalCode,
            string city,
            string state,
            int supplierId
            )
        {
            SupplierName = supplierName;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            PostalCodel = postalCode;
            City = city;
            State = state;
            SupplierId = supplierId;
        }
    }

    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, (Entity.Entities.Supplier, string)>
    {
        private readonly ISupplierRepository _supplierRepository;
        public UpdateSupplierCommandHandler(ISupplierRepository supplierRepository)
        {
            this._supplierRepository = supplierRepository;
        }
        public async Task<(Entity.Entities.Supplier, string)> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            Entity.Entities.Supplier updateRecord = await _supplierRepository.GetById(request.SupplierId);

            if (updateRecord == null)
            {
                return await Task.FromResult((updateRecord, SupplierMessages.NoRecordFound));
            }

            updateRecord.State = request.State;
            updateRecord.Address2 = request.AddressLine2;
            updateRecord.Address1 = request.AddressLine1;
            updateRecord.State = request.State;
            updateRecord.City = request.City;
            updateRecord.Id = request.SupplierId;
            updateRecord.Name = request.SupplierName;
            return (await _supplierRepository.Update(updateRecord), SupplierMessages.Success);
        }
    }
}
