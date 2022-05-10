using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Response
{
    public class SupplierResponse
    {
        [JsonProperty("SupplierId")]
        public int SupplierId { get; set; }
        [JsonProperty("SupplierName")]
        public string SupplierName { get; set; } = null!;
        [JsonProperty("AddressLine1")]
        public string AddressLine1 { get; set; } = null!;
        [JsonProperty("AddressLine2")]
        public string AddressLine2 { get; set; } = null!;
        [JsonProperty("City")]
        public string City { get; set; } = null!;
        [JsonProperty("PostalCode")]
        public string PostalCode { get; set; } = null!;
        [JsonProperty("State")]
        public string State { get; set; } = null!;
        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }
    }
}
