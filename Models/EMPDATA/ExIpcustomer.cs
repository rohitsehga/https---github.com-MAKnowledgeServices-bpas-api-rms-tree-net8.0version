using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExIpcustomer
    {
        public int CuIden { get; set; }
        public int CuSl { get; set; }
        public string CuCode { get; set; }
        public string CuName { get; set; }
        public string CuAddr1 { get; set; }
        public string CuAddr2 { get; set; }
        public string CuAddr3 { get; set; }
        public string CuAddr4 { get; set; }
        public string CuLocn { get; set; }
        public string CuEmailto { get; set; }
        public string CuEmailcc { get; set; }
        public short? CuTypeid { get; set; }
        public short? CuBillingfrequency { get; set; }
        public short? CuModeofbillid { get; set; }
        public short? CuCurrencytypeid { get; set; }
        public string CuAccountmanager { get; set; }
        public DateTime Entrystamp { get; set; }
        public string Status { get; set; }
        public string WinLoginid { get; set; }
    }
}
