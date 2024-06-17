using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExQueryBuilderColumn
    {
        public string Sqlcolumn { get; set; }
        public string ReportColumn { get; set; }
        public string ColumnDatatype { get; set; }
        public string Status { get; set; }
    }
}
