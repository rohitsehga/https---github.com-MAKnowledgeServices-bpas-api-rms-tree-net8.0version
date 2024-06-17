using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExClientWorkDemand
    {
        public int CuIden { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Projectname { get; set; }
        public string ComplexityOfFinancialModelingClntDem { get; set; }
        public string KnowledgeOfValuationTechniquesClntDem { get; set; }
        public string InvestmentIdeasAndIndependentThinkingClntDem { get; set; }
        public string StandardOfWrittenEnglishAndReportWritingClntDem { get; set; }
        public string KnowledgeOfIndustryFundamentalsClntDem { get; set; }
        public string KnowledgeOfMarketsMarketdriversNewsClntDem { get; set; }
        public string ClarityOfCommunicationWithClientClntDem { get; set; }
        public string ClientSupportClntDem { get; set; }
        public string QuickTurnaroundDeadlinePressureClntDem { get; set; }
        public string LongWorkingHoursClntDem { get; set; }
        public string Status { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
    }
}
