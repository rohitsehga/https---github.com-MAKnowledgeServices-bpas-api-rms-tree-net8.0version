using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExEffortsummary
    {
        public int? PrIden { get; set; }
        public int? AcIden { get; set; }
        public string PeLogn { get; set; }
        public DateTime? DeDate { get; set; }
        public int? DeEffo { get; set; }
        public string PhCode { get; set; }
        public string TtCode { get; set; }
        public int? AmbBillable { get; set; }
        public string Projtype { get; set; }
        public string NpRole { get; set; }
        public string Group { get; set; }
        public string Clientanalyst { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string PrCust { get; set; }
        public int? CuIden { get; set; }
        public string AcName { get; set; }
    }
}
