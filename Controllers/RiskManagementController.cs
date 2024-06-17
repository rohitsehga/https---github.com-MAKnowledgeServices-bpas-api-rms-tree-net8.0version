using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ResourceRequestService.Data;
using ResourceRequestService.Helpers;
using ResourceRequestService.Models.Repository;
using ResourceRequestService.Models.CustomerFeedback;
//using Rest;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;

namespace ResourceRequestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiskManagementController : Controller
    {
        private readonly RepositoryDbContext _repositorycontext;
        private readonly EDMDbContext _edmdbcontext;
        private readonly CustomerFeedbackDbContext _customerfeedbackdbcontext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public RiskManagementController(IHttpContextAccessor httpContextAccessor, IMapper mapper, RepositoryDbContext repositorycontext, EDMDbContext edmrepositorycontext, CustomerFeedbackDbContext customerfeedbackrepositorycontext)
        {
            _httpContextAccessor = httpContextAccessor;

            _mapper = mapper;
            _repositorycontext = repositorycontext;
            _edmdbcontext = edmrepositorycontext;
            _customerfeedbackdbcontext = customerfeedbackrepositorycontext;
        }

        [HttpGet("GetMaster")]
        public IActionResult AdminPageMaster()
        {
            Response response = new();
            try
            {
                 
                var RiskCategoryMaster = (from p in _repositorycontext.ExRiskcatMasters
                                          where p.Status == "A"
                                          select new
                                          {
                                              value = p.RcatId,
                                              label = p.RiskName
                                          }).ToList();

                var RiskScaleMaster = (from p in _repositorycontext.ExRiskscaleMasters
                                         where p.Status == "A"
                                         select new
                                         {
                                             value = p.RscaleId,
                                             label = p.RiskScale
                                         }).ToList();


                var ClientMaster = (from p in _repositorycontext.ExIpcustomers
                                     select new
                                     {
                                         value = p.CuIden,
                                         label = p.CuCode,
                                         CuName = p.CuName,
                                         Status = p.Status
                                     }).Distinct().ToList();

                var RiskCategoryMasterCompliance = (from p in _repositorycontext.ExRiskcatMasters
                                          where p.Status == "D"
                                          select new
                                          {
                                              value = p.RcatId,
                                              label = p.RiskName
                                          }).ToList();



                Dictionary<string, object> dList = new Dictionary<string, object>();
                dList.Add("RiskCategoryMaster", RiskCategoryMaster);
                dList.Add("RiskScaleMaster", RiskScaleMaster); 
                dList.Add("ClientMaster", ClientMaster); 
                dList.Add("RiskCategoryMasterCompliance", RiskCategoryMasterCompliance); 

                response.Data = dList;
                response.Status = true;
                response.Message = "Success";
                response.Error = "";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Something went wrong. Please try after some time"; ;
                response.Error = ex.ToString();
                return Ok(response);
            }
        }

        [HttpGet("GetRiskSymptom/{riskcatid}")]
        public IActionResult GetRiskSymptom(string riskcatid)
        {
            //USP_Get_List_Clients_For_MSA_SOW '26663'
            Response response = new();
            try
            {
                string message = string.Empty;
                if (String.IsNullOrEmpty(riskcatid))
                {
                    response.Status = false;
                    response.Message = "riskcatid required";
                    response.Data = "";
                    response.Error = "riskcatid required";
                    return Ok(response);
                }
                else
                {
                    

                    var RiskSymptomMasters = (from a in _repositorycontext.ExRiskSymptomMasters 
                                        where a.RcatId.ToString() == riskcatid
                                        orderby a.Rsname
                                        select new
                                        {
                                            label=a.Rsname,
                                            value=a.Rsid
                                        }).Distinct().ToList();

                    response.Data = RiskSymptomMasters;
                    response.Status = true;
                    response.Message = "Success";
                    response.Error = "";
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                response.Error = ex.ToString();
                return Ok(response);
            }
        }

        [HttpPost("SaveRisk")]
        public IActionResult SaveFeedbackSurvey(SaveRisk model)
        {
            Response response = new();
            try
            {
                string message = string.Empty;
                if (model is null)
                {
                    response.Status = false;
                    response.Message = "model is required";
                    response.Data = "";
                    response.Error = "model is required";
                    return Ok(response);
                }
                else
                {

                    KickOffStatus kickmodel = new KickOffStatus();
                    ResultTemp resultModel = new ResultTemp();


                    ExRiskIden exRiskIden = new ExRiskIden();
                    exRiskIden.Riskdate = model.Riskdate;
                    exRiskIden.CuIden = model.cuiden;
                    exRiskIden.PeLognIden = model.pelogniden;
                    exRiskIden.RcatId = model.RCatID;
                    exRiskIden.Pid = model.PID;
                    exRiskIden.RiskSymptom = model.RiskSymptom;
                    exRiskIden.Roc = model.ROC;
                    exRiskIden.IdentifiedDate = model.IdentifiedDate;
                    exRiskIden.ClosingDate = model.ClosingDate;
                    exRiskIden.RiskDesc=model.RiskDesc;
                    exRiskIden.MngrComments = model.mngrcomments;
                    exRiskIden.Createdby = model.createdby;
                    exRiskIden.Entrystamp = DateTime.Now;
                    exRiskIden.Status = "A";
                    _repositorycontext.ExRiskIdens.Add(exRiskIden);
                    _repositorycontext.SaveChanges();


                    int maxid = 0;

                    maxid = (from a in _repositorycontext.ExRiskIdens
                             select a).Max(a => a.Rid);
                     

                    List<ExRiskMitPlan> exRiskMitPlans = new List<ExRiskMitPlan>();
                    //if (model.contributor > 0)
                    //{
                    for (int i = 0; i < model.mitigationPlans.Length; i++)
                    {
                        ExRiskMitPlan exRiskMitPlan = new ExRiskMitPlan();
                        exRiskMitPlan.Rid = maxid;
                        exRiskMitPlan.MitPlan = model.mitigationPlans[i].mitidationplantext;
                        exRiskMitPlan.AssignPeLogn = model.mitigationPlans[i].assignedto;
                        exRiskMitPlan.MitigationClosingDate = model.mitigationPlans[i].closingdate;
                        exRiskMitPlan.Createdby = model.createdby;
                        exRiskMitPlan.Entrystamp = DateTime.Now;
                        exRiskMitPlan.Status = "A";
                        exRiskMitPlans.Add(exRiskMitPlan);

                    }
                    _repositorycontext.ExRiskMitPlans.AddRange(exRiskMitPlans);
                    //}

                    _repositorycontext.SaveChanges();

                    kickmodel.nstatus = "Saved Sucessfully";



                    response.Status = true;
                    response.Message = kickmodel.nstatus;
                    response.Data = kickmodel;
                    response.Error = "";
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Something went wrong. Please contact Administrator !!";
                response.Error = ex.ToString();
                return Ok(response);

            }
        }

        [HttpGet("GetClientPeopleList/{pelogin}/{cuiden}")]
        public IActionResult GetClientPeopleList(string pelogin, string cuiden)
        {
            Dictionary<string, object> dList = new Dictionary<string, object>();
            Response response = new();
            try
            {
                string role = string.Empty;
                Core core = new(_repositorycontext, _edmdbcontext);
                role = core.uFn_LoginCheck(pelogin);
                string dept = string.Empty;
                var deptvar = (from a in _edmdbcontext.IpPeople
                               where a.PeLogn == pelogin && a.PeQuit == null
                               select new
                               {
                                   pe_dept = a.PeDept

                               }).ToList();
                if (deptvar.Count > 0)
                {
                    dept = deptvar[0].pe_dept;
                }
                string[] reasonlist = { "BNA", "NBST5", "BILLING" };
                //string[] roleList = { "ADMIN", "EMGR", "CDH" };
                var ExResourceassignmentstatuses = (from a in _repositorycontext.ExResourceassignmentstatuses select a).ToList();
                var IpPeople = (from a in _edmdbcontext.IpPeople select a).ToList();
                var ExReportingmanagers = (from a in _edmdbcontext.ExReportingmanagers select a).ToList();
                var ExIppeople = (from a in _edmdbcontext.ExIppeople select a).ToList();

                if (role == "DM")
                {
                    int?[] TypeList = { 1, 2 };

                    var exreportingmanager = (from a in ExResourceassignmentstatuses
                                              join b in ExReportingmanagers on
                                              new
                                              //{ X1 = a.CuIden ?? default(int), X3 = a.KickOff ?? default(DateTime) }
                                              { X1 = a.CuIden, X3 = a.KickOff }
                                                    equals new { X1 = b.CuIden ?? default(int), X3 = b.KickOff ?? default(DateTime) }
                                              where b.Mngrlognid == pelogin && b.Enddate is null
                                              && TypeList.Contains(b.Type) && b.CuIden != 85 && a.Enddate == null && a.CuIden.ToString() == cuiden /*&& reasonlist.Contains(a.Reason)*/
                                              select a).Distinct().ToList();

                    string[] VaLognIdList = new string[exreportingmanager.Count];

                    if (exreportingmanager.Count > 0)
                    {
                        for (int i = 0; i < exreportingmanager.Count; i++)
                        {
                            VaLognIdList[i] = exreportingmanager[i].PeLogn;
                        }
                    }

                    var result = (from a in ExResourceassignmentstatuses
                                  join b in IpPeople on a.PeLogn equals b.PeLogn into sb
                                  from b in sb.DefaultIfEmpty()
                                  join c in _edmdbcontext.ExIppeople on a.PeLogn equals c.PeLogn into sc
                                  from c in sc.DefaultIfEmpty()
                                  where a.Enddate == null && a.CuIden != 85 && a.OffboardStatus == null && a.CuIden.ToString() == cuiden
                                  && a.ApproveStatus == "A" && VaLognIdList.Contains(a.PeLogn) /*&& reasonlist.Contains(a.Reason)*/
                                  orderby b != null ? b.PeName : ""
                                  select new
                                  {
                                      value = a.PeLogn,
                                      label = (b != null ? b.PeName + " (" + (c != null ? c.WwPersonId : "") + ")" : "")
                                  }).Distinct().ToList();

                    dList.Add("Table", result);

                }
                else if (role == "PMO")
                {
                    var subquery = (from a in _repositorycontext.ExAccessMasters where a.PeLogn == pelogin && a.Enddate == null && a.Status == "A" select a).ToList();
                    string[] serviceLine = new string[subquery.Count + 1];
                    if (subquery.Count > 0)
                    {
                        for (int i = 0; i < subquery.Count; i++)
                        {
                            serviceLine[i] = subquery[i].ServiceLine;
                        }

                    }

                    var result = (from a in ExResourceassignmentstatuses
                                  join b in IpPeople on a.PeLogn equals b.PeLogn into sb
                                  from b in sb.DefaultIfEmpty()
                                  join c in _edmdbcontext.ExIppeople on a.PeLogn equals c.PeLogn into sc
                                  from c in sc.DefaultIfEmpty()
                                  where a.Enddate == null && a.CuIden != 85 && a.OffboardStatus == null && a.CuIden.ToString() == cuiden
                                  && a.ApproveStatus == "A" && serviceLine.Contains(b != null ? b.PeDept : "") /*&& reasonlist.Contains(a.Reason)*/
                                  orderby b != null ? b.PeName : ""
                                  select new
                                  {
                                      value = a.PeLogn,
                                      label = (b != null ? b.PeName + " (" + (c != null ? c.WwPersonId : "") + ")" : "")
                                  }).Distinct().ToList();

                    dList.Add("Table", result);

                }
                else if (role == "PL")
                {
                    var subquery = (from a in _repositorycontext.ExClientPlOwners where a.PeLogn == pelogin && a.Enddate == null && a.Status == "A" select a).ToList();
                    string[] serviceLine = new string[subquery.Count + 1];
                    if (subquery.Count > 0)
                    {
                        for (int i = 0; i < subquery.Count; i++)
                        {
                            serviceLine[i] = subquery[i].ServiceLine;
                        }

                    }

                    var result = (from a in ExResourceassignmentstatuses
                                  join b in IpPeople on a.PeLogn equals b.PeLogn into sb
                                  from b in sb.DefaultIfEmpty()
                                  join c in ExIppeople on a.PeLogn equals c.PeLogn into sc
                                  from c in sc.DefaultIfEmpty()
                                  where a.Enddate == null && a.CuIden != 85 && a.OffboardStatus == null && a.CuIden.ToString() == cuiden
                                  && a.ApproveStatus == "A" && serviceLine.Contains(b != null ? b.PeDept : "")/* && reasonlist.Contains(a.Reason)*/
                                  orderby b != null ? b.PeName : ""
                                  select new
                                  {
                                      value = a.PeLogn,
                                      label = (b != null ? b.PeName + " (" + (c != null ? c.WwPersonId : "") + ")" : "")
                                  }).Distinct().ToList();

                    dList.Add("Table", result);
                }
                else if (role == "EMGR")
                {
                    var subquery = (from a in _repositorycontext.ExIpcustomerOthers where a.PeLogn == pelogin && a.Enddate == null && a.Status == "A" && a.Role == "EMGR" select a).ToList();
                    int?[] CuIden = new int?[subquery.Count + 1];
                    if (subquery.Count > 0)
                    {
                        for (int i = 0; i < subquery.Count; i++)
                        {
                            CuIden[i] = subquery[i].CuIden;
                        }

                    }

                    var result = (from a in ExResourceassignmentstatuses
                                  join b in IpPeople on a.PeLogn equals b.PeLogn into sb
                                  from b in sb.DefaultIfEmpty()
                                  join c in ExIppeople on a.PeLogn equals c.PeLogn into sc
                                  from c in sc.DefaultIfEmpty()
                                  where a.Enddate == null && a.CuIden != 85 && a.OffboardStatus == null && a.CuIden.ToString() == cuiden
                                  && a.ApproveStatus == "A" && CuIden.Contains(a.CuIden) /*&& reasonlist.Contains(a.Reason)*/
                                  orderby b != null ? b.PeName : ""
                                  select new
                                  {
                                      value = a.PeLogn,
                                      label = (b != null ? b.PeName + " (" + (c != null ? c.WwPersonId : "") + ")" : "")
                                  }).Distinct().ToList();

                    dList.Add("Table", result);
                }
                else
                {
                    var result = (from a in ExResourceassignmentstatuses
                                  join b in IpPeople on a.PeLogn equals b.PeLogn into sb
                                  from b in sb.DefaultIfEmpty()
                                  join c in ExIppeople on a.PeLogn equals c.PeLogn into sc
                                  from c in sc.DefaultIfEmpty()
                                  where a.Enddate == null && a.CuIden != 85 && a.OffboardStatus == null && a.CuIden.ToString() == cuiden
                                  && a.ApproveStatus == "A" && b != null /*&& reasonlist.Contains(a.Reason)*/
                                  orderby b != null ? b.PeName : ""
                                  select new
                                  {
                                      value = a.PeLogn,
                                      label = (b != null ? b.PeName + " (" + (c != null ? c.WwPersonId : "") + ")" : "")
                                  }).Distinct().ToList();

                    dList.Add("Table", result);

                }
                response.Data = dList;
                response.Status = true;
                response.Message = "Success";
                response.Error = "";
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                response.Error = ex.ToString();
                return Ok(response);
            }
        }

        [HttpGet("GetRiskData/{pelogn}")]
        public IActionResult GetRiskData(string pelogn)
        {
            //USP_Get_List_Clients_For_MSA_SOW '26663'
            Response response = new();
            try
            {
                string message = string.Empty;
                if (String.IsNullOrEmpty(pelogn))
                {
                    response.Status = false;
                    response.Message = "pelogn required";
                    response.Data = "";
                    response.Error = "pelogn required";
                    return Ok(response);
                }
                else
                {
                    var ExRiskIdens = (from ipex in _repositorycontext.ExRiskIdens select ipex).ToList();
                    var ExQuestionBanks = (from ipex in _customerfeedbackdbcontext.ExQuestionBanks select ipex).ToList();
                    var ExUserResponses = (from ipex in _customerfeedbackdbcontext.ExUserResponses select ipex).ToList();
                    var ExResponseTypeMasters = (from ipex in _customerfeedbackdbcontext.ExResponseTypeMasters select ipex).ToList();

                    //Dictionary<string, object> dList = new Dictionary<string, object>();

                    var questionbank = (from a in ExRiskIdens
                                        //join b in ExQuestionBanks on a.AssessmentQbId equals b.AssessmentQbId into sc
                                        //from b in sc.DefaultIfEmpty() 
                                        where a.Createdby.ToLower() == pelogn.ToLower()  
                                        orderby a.Rid
                                        select new
                                        {
                                            Rid = a.Rid,
                                            Riskdate = a.Riskdate.Value.ToString("yyyy-MM-dd"),
                                            CuIden = a.CuIden,
                                            PeLognIden = a.PeLognIden,
                                            RcatId = a.RcatId,
                                            Pid = a.Pid,
                                            RiskSymptom = a.RiskSymptom,
                                            IdentifiedDate = a.IdentifiedDate.Value.ToString("yyyy-MM-dd"),
                                            ClosingDate = a.ClosingDate.Value.ToString("yyyy-MM-dd"),
                                            RiskDesc =  a.RiskDesc,
                                            MngrComments =  a.MngrComments,
                                            Entrystamp =  a.Entrystamp.Value.ToString("yyyy-MM-dd")
                                        }).ToList();

                    response.Data = questionbank;
                    response.Status = true;
                    response.Message = "Success";
                    response.Error = "";
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                response.Error = ex.ToString();
                return Ok(response);
            }
        }

        [HttpGet("GetMitigationPeople/{RID}")]
        public IActionResult GetMitigationPeople(string RID)
        {
            //USP_Get_List_Clients_For_MSA_SOW '26663'
            Response response = new();
            try
            {
                string message = string.Empty;
                if (String.IsNullOrEmpty(RID))
                {
                    response.Status = false;
                    response.Message = "RID required";
                    response.Data = "";
                    response.Error = "RID required";
                    return Ok(response);
                }
                else
                {
                    var ExRiskIdens = (from ipex in _repositorycontext.ExRiskIdens select ipex).ToList();
                    var ExRiskMitPlans = (from ipex in _repositorycontext.ExRiskMitPlans select ipex).ToList();
                    var ExQuestionBanks = (from ipex in _customerfeedbackdbcontext.ExQuestionBanks select ipex).ToList();
                    var ExUserResponses = (from ipex in _customerfeedbackdbcontext.ExUserResponses select ipex).ToList();
                    var ExResponseTypeMasters = (from ipex in _customerfeedbackdbcontext.ExResponseTypeMasters select ipex).ToList();

                    //Dictionary<string, object> dList = new Dictionary<string, object>();

                    var questionbank = (from a in ExRiskMitPlans
                                            //join b in ExQuestionBanks on a.AssessmentQbId equals b.AssessmentQbId into sc
                                            //from b in sc.DefaultIfEmpty() 
                                        where a.Rid.ToString() == RID
                                        orderby a.Rid
                                        select new
                                        {
                                            MitPlan = a.MitPlan,
                                            Assignedperson = a.AssignPeLogn,
                                            MitigationClosingDate = a.MitigationClosingDate.Value.ToString("yyyy-MM-dd")
                                        }).ToList();

                    response.Data = questionbank;
                    response.Status = true;
                    response.Message = "Success";
                    response.Error = "";
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                response.Error = ex.ToString();
                return Ok(response);
            }
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
