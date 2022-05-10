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
    public class AddSupplierCommand : IRequest<(Entity.Entities.Supplier, string)>
    {
        public string SupplierName { get; set; } = null!;
        public string AddressLine1 { get; set; } = null!;
        public string AddressLine2 { get; set; } = null!;
        public string PostalCodel { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;

        public AddSupplierCommand(string supplierName,
            string addressLine1,
            string addressLine2,
            string postalCode,
            string city,
            string state
            )
        {
            SupplierName = supplierName;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            PostalCodel = postalCode;
            City = city;
            State = state;
        }
    }

    public class AddSupplierCommandHandler : IRequestHandler<AddSupplierCommand, (Entity.Entities.Supplier, string)>
    {
        private readonly ISupplierRepository _supplierRepository;
        public AddSupplierCommandHandler(ISupplierRepository supplierRepository)
        {
            this._supplierRepository = supplierRepository;
        }
        public async Task<(Entity.Entities.Supplier, string)> Handle(AddSupplierCommand request, CancellationToken cancellationToken)
        {
            Entity.Entities.Supplier newRecord = new Entity.Entities.Supplier
            {
                Address1 = request.AddressLine1,
                Address2 = request.AddressLine2,
                City = request.City,
                State = request.State,
                IsActive = true,
                Name = request.SupplierName,
                PostalCode = request.PostalCodel
            };
            if (_supplierRepository.CheckDuplicate(newRecord).Result)
            {
                return (newRecord, SupplierMessages.Duplicate);
            }
            return await Task.FromResult((await _supplierRepository.Add(newRecord), SupplierMessages.Success));
        }
    }
}
