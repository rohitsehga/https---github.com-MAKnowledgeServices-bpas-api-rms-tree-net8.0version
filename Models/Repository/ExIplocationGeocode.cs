using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIplocationGeocode
    {
        public int? IpLocn { get; set; }
        public string GeoCode { get; set; }
        public string Status { get; set; }
    }
}
