using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpbgcVendormaster
    {
        public int? VendorId { get; set; }
        public string VendorName { get; set; }
        public string VendorAddress1 { get; set; }
        public string VendorAddress2 { get; set; }
        public string VendorAddress3 { get; set; }
        public string VendorCountry { get; set; }
        public string VendorCity { get; set; }
        public string VendorPinCode { get; set; }
        public string VendorMobile { get; set; }
        public string VendorLandline { get; set; }
        public string Status { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastupdatedOn { get; set; }
    }
}
