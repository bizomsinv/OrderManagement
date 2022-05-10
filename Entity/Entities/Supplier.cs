using System;
using System.Collections.Generic;

namespace Entity.Entities
{
    public partial class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address1 { get; set; } = null!;
        public string Address2 { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string State { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
