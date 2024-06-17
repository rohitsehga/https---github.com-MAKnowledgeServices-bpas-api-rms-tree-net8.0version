using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourceskilltraining
    {
        public int? Id { get; set; }
        public string PeLogn { get; set; }
        public DateTime? TrainingStartdate { get; set; }
        public DateTime? TrainingEnddate { get; set; }
        public int? TrainingSl { get; set; }
        public DateTime? TrainingActualenddate { get; set; }
        public string TrainingSkilltype { get; set; }
        public string ElCode { get; set; }
        public string CaCode { get; set; }
        public string SkillGrade { get; set; }
        public string PassTraining { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public string Status { get; set; }
        public string EvaluationMethod { get; set; }
        public string Datasource { get; set; }
    }
}
