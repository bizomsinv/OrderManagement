namespace Model.Request
{
    public class SupplierRequest
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = null!;
        public string AddressLine1 { get; set; } = null!;
        public string AddressLine2 { get; set; } = null!;
        public string PostalCodel { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public bool IsActive { get; set; }

    }
}