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
    public class CustomerFeedbackController : Controller
    {
        private readonly RepositoryDbContext _repositorycontext;
        private readonly EDMDbContext _edmdbcontext;
        private readonly CustomerFeedbackDbContext _customerfeedbackdbcontext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public CustomerFeedbackController(IHttpContextAccessor httpContextAccessor, IMapper mapper, RepositoryDbContext repositorycontext, EDMDbContext edmrepositorycontext, CustomerFeedbackDbContext customerfeedbackrepositorycontext)
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
                //List<AdminGetRole> listAdminGetRole = new List<AdminGetRole>();

                var questionaremaster = (from p in _customerfeedbackdbcontext.ExQuestionBankSetups
                                  where p.Status=="A"
                                  select new
                                  {
                                      value = p.AssessmentQbId,
                                      label = p.QuestionBankName
                                  }).ToList();

                var ippersonlist1 = (from ipex in _edmdbcontext.IpPeople where ipex.PeQuit == null select ipex).ToList();
                var emplist = (from ipex in _edmdbcontext.ExIppeople where ipex.QuitDateTemp == null select ipex).ToList();

                var employeemaster = (from p in ippersonlist1
                                      join b1 in emplist on new
                                      { User = p != null ? p.PeLogn : "" }
                                                 equals new { User = b1 != null ? b1.PeLogn : "" }
                                                             into cp
                                      from b1 in cp.DefaultIfEmpty()
                                      where p.PeQuit == null
                                      orderby p.PeName
                                         select new
                                         {
                                             value = p.PeLogn,
                                             label =b1 !=null ? p.PeName + " (" + b1.WwPersonId +")" : "",
                                             PeName =  p.PeName,
                                             PeMail =  p.PeMail,

                                         }).ToList();

                var frequencymaster = (from p in _customerfeedbackdbcontext.ExFrequencyMasters
                                         where p.Status == "A"
                                         select new
                                         {
                                             value = p.FrequencyId,
                                             label = p.FrequencyName
                                         }).ToList();

                var ResponseTypeMasters = (from p in _customerfeedbackdbcontext.ExResponseTypeMasters
                                       where p.Status == "A"
                                       select new
                                       {
                                           value = p.ResponseType,
                                           label = p.ResponseName
                                       }).ToList();

                Dictionary<string, object> dList = new Dictionary<string, object>();
                dList.Add("questionaremaster", questionaremaster); 
                dList.Add("employeemaster", employeemaster); 
                dList.Add("frequencymaster", frequencymaster); 
                dList.Add("responserypemasters", ResponseTypeMasters); 

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

        [HttpPost("SaveFeedbackSurvey")]
        public IActionResult SaveFeedbackSurvey(SaveFeedbackSurvey model)
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


                  ExAssesmentSetup exAssesmentSetup = new ExAssesmentSetup();
                    exAssesmentSetup.AssessmentName=model.AssessmentName;
                    exAssesmentSetup.CuIden = model.cuiden;
                    exAssesmentSetup.ProjectName=model.ProjectName;
                    exAssesmentSetup.AssessmentQbId = model.AssessmentQBID;
                    exAssesmentSetup.AssessmentOwner=model.AssessmentOwner;
                    exAssesmentSetup.AssessmentPurpose=model.AssessmentPurpose;
                    exAssesmentSetup.AssessmentType=model.AssessmentType;
                    exAssesmentSetup.AssessmentStartDate    = model.AssessmentStartDate;
                    exAssesmentSetup.AssessmentEndDate = model.AssessmentEndDate;
                    exAssesmentSetup.AssessmentComments = model.Assessmentcomments;
                    exAssesmentSetup.AssessmentStatus = "A";
                    exAssesmentSetup.Createdby = model.createdby;
                    exAssesmentSetup.CreatedOn = DateTime.Now;
                    exAssesmentSetup.AssessmentFrequency = model.AssessmentFrequency;
                    _customerfeedbackdbcontext.ExAssesmentSetups.Add(exAssesmentSetup);
                    _customerfeedbackdbcontext.SaveChanges();


                    int maxid = 0; 

                    maxid = (from a in _customerfeedbackdbcontext.ExAssesmentSetups 
                                 select a).Max(a => a.AssessmentId);



                    List<ExContributor> exContributors = new List<ExContributor>();
                    //if (model.contributor > 0)
                    //{
                        for (int i = 0; i < model.contributor.Length; i++)
                        {
                            ExContributor exContributor1 = new ExContributor();
                        exContributor1.AssesmentId = maxid;
                        exContributor1.Contributorcategory = model.contributor[i].contributorcategory;
                        exContributor1.PersonName = model.contributor[i].contributorname;
                        exContributor1.MailId = model.contributor[i].contributoremailid;
                        exContributor1.EnteredBy = model.createdby;
                        exContributor1.EntryStamp = DateTime.Now;
                        exContributor1.Status = "A";
                        exContributor1.AssessmentStatus = "Not Started";
                        exContributors.Add(exContributor1);

                        }
                        _customerfeedbackdbcontext.ExContributors.AddRange(exContributors);
                    //}

                    _customerfeedbackdbcontext.SaveChanges(); 

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


        [HttpGet("GetActiveSurvey/{cuiden}")]
        public IActionResult GetActiveSurvey(string cuiden)
        {
            Response response = new();
            try
            {
                string message = string.Empty;
                if (String.IsNullOrEmpty(cuiden))
                {
                    response.Status = false;
                    response.Message = "questionbankid required";
                    response.Data = "";
                    response.Error = "questionbankid required";
                    return Ok(response);
                }
                else
                {

                    var ExAssesmentSetups = (from ipex in _customerfeedbackdbcontext.ExAssesmentSetups select ipex).ToList();
                    var IpCustomers = (from ipex in _repositorycontext.IpCustomers select ipex).ToList();
                    var ExQuestionBankSetups = (from ipex in _customerfeedbackdbcontext.ExQuestionBankSetups select ipex).ToList();
                    var ExFrequencyMasters = (from ipex in _customerfeedbackdbcontext.ExFrequencyMasters select ipex).ToList();

                    var IpPeople = (from ipex in _edmdbcontext.IpPeople select ipex).ToList();

                    var assessmentmaster = (from p in ExAssesmentSetups
                                            join a in IpCustomers on p.CuIden equals a.CuIden into sc
                                            from a in sc.DefaultIfEmpty()
                                            join b in ExQuestionBankSetups on p.AssessmentQbId equals b.AssessmentQbId into sc1
                                            from b in sc1.DefaultIfEmpty()
                                            join c in IpPeople on p.AssessmentOwner equals c.PeLogn into sc2
                                            from c in sc2.DefaultIfEmpty()
                                            join d in ExFrequencyMasters on p.AssessmentFrequency equals d.FrequencyId.ToString() into sc3
                                            from d in sc3.DefaultIfEmpty()
                                            where p.AssessmentStatus == "A" && p.CuIden.ToString()==cuiden
                                            orderby p.AssessmentId
                                            select new
                                            {
                                                AssessmentId = p.AssessmentId,
                                                AssessmentName = p.AssessmentName,
                                                clientname = a != null ? a.CuComp : "",
                                                QuestionBankName = b != null ? b.QuestionBankName : "",
                                                Owner = c != null ? c.PeName : "",
                                                AssessmentPurpose = p.AssessmentPurpose,
                                                AssessmentStartDate = p.AssessmentStartDate.Value.ToString("yyyy-MM-dd"),
                                                AssessmentEndDate = p.AssessmentEndDate.Value.ToString("yyyy-MM-dd"),
                                                AssessmentFrequency = d != null ? d.FrequencyName : "",
                                                AssessmentComments = p.AssessmentComments
                                            }).ToList();

                    //Dictionary<string, object> dList = new Dictionary<string, object>();
                    //dList.Add("questionaremaster", questionaremaster);
                    //dList.Add("employeemaster", employeemaster);

                    response.Data = assessmentmaster;
                    response.Status = true;
                    response.Message = "Success";
                    response.Error = "";
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Something went wrong. Please try after some time"; ;
                response.Error = ex.ToString();
                return Ok(response);
            }
        }

        [HttpGet("GetQuestionBank/{questionbankid}")]
        public IActionResult GetQuestionBank(string questionbankid)
        {
            //USP_Get_List_Clients_For_MSA_SOW '26663'
            Response response = new();
            try
            {
                string message = string.Empty;
                if (String.IsNullOrEmpty(questionbankid))
                {
                    response.Status = false;
                    response.Message = "questionbankid required";
                    response.Data = "";
                    response.Error = "questionbankid required";
                    return Ok(response);
                }
                else
                {
                    var ExQuestionBanks = (from ipex in _customerfeedbackdbcontext.ExQuestionBanks select ipex).ToList(); 
                    var ExResponseTypeMasters = (from ipex in _customerfeedbackdbcontext.ExResponseTypeMasters select ipex).ToList(); 
 
                    //Dictionary<string, object> dList = new Dictionary<string, object>();

                    var questionbank = (from a in ExQuestionBanks
                                        join b in ExResponseTypeMasters on a.ResponseType equals b.ResponseType.ToString() into sc
                                        from b in sc.DefaultIfEmpty()
                                        where a.AssessmentQbId.ToString() == questionbankid && a.IsDeleted == false
                                        orderby a.QuestionId  
                                        select new
                                        {
                                            QuestionId = a.QuestionId,
                                            Question = a.Question,
                                            ResponseType = b!=null? b.ResponseName :"NA",
                                            Option1 =  a.Option1,
                                            Option2 = a.Option2,
                                            Option3 = a.Option3,
                                            Option4 = a.Option4,
                                            Option5 =  a.Option5,
                                            Option6 = a.Option6,
                                            ResponseTypeid = a.ResponseType
                                        }).Distinct().ToList();

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

        [HttpGet("GetContributor/{assesmentid}")]
        public IActionResult GetContributor(string assesmentid)
        {
            Response response = new();
            try
            {
                string message = string.Empty;
                if (String.IsNullOrEmpty(assesmentid))
                {
                    response.Status = false;
                    response.Message = "assesmentid required";
                    response.Data = "";
                    response.Error = "assesmentid required";
                    return Ok(response);
                }
                else
                {
 

                    var contributormaster = (from p in _customerfeedbackdbcontext.ExContributors
                                             where p.Status=="A" && p.AssesmentId.ToString() == assesmentid
                                            orderby p.PersonName
                                            select new
                                            {
                                                Contributorcategory = p.Contributorcategory,
                                                PersonName = p.PersonName,
                                                MailId = p.MailId 
                                            }).ToList(); 

                    response.Data = contributormaster;
                    response.Status = true;
                    response.Message = "Success";
                    response.Error = "";
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Something went wrong. Please try after some time"; ;
                response.Error = ex.ToString();
                return Ok(response);
            }
        }

        [HttpGet("GetTotalAssesment/{personmailid}")]
        public IActionResult GetTotalAssesment(string personmailid)
        {
            Response response = new();
            try
            {
                string message = string.Empty;
                if (String.IsNullOrEmpty(personmailid))
                {
                    response.Status = false;
                    response.Message = "personmailid required";
                    response.Data = "";
                    response.Error = "personmailid required";
                    return Ok(response);
                }
                else
                { 

                    var totalassesment = (from p in _customerfeedbackdbcontext.ExContributors
                                          join b in _customerfeedbackdbcontext.ExAssesmentSetups on p.AssesmentId equals b.AssessmentId into sc
                                          from b in sc.DefaultIfEmpty()
                                          where p.MailId== personmailid && p.Status=="A"
                                             orderby p.PersonName
                                             select new
                                             {
                                                 AssesmentId = p.AssesmentId,
                                                 AssessmentName = b.AssessmentName,
                                                 AssessmentPurpose = b.AssessmentPurpose,
                                                 AssessmentStartDate = b.AssessmentStartDate.Value.ToString("yyyy-MM-dd"),
                                                 AssessmentEndDate = b.AssessmentEndDate.Value.ToString("yyyy-MM-dd"),
                                                 questionbankid = b.AssessmentQbId,
                                                 AssessmentStatus = p.AssessmentStatus
                                             }).ToList();

                    response.Data = totalassesment;
                    response.Status = true; 
                    response.Message = "Success";
                    response.Error = "";
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Something went wrong. Please try after some time"; ;
                response.Error = ex.ToString();
                return Ok(response);
            }
        }

        [HttpPost("SaveUserResponse")]
        public IActionResult SaveUserResponse(SaveUserResponse model)
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


                    var finddata = (from p in _customerfeedbackdbcontext.ExUserResponses
                                    where p.Assesmentid == model.assessmentid && p.QuestionId==model.questionid && p.Usermailid == model.usermailid
                                    orderby p.Id descending
                                    select new
                                    {
                                        Id = p.Id  
                                    }).ToList(); 

                    if (finddata.Count > 0)
                    {
                        ExUserResponse exUserResponse1 = _customerfeedbackdbcontext.ExUserResponses.Where(x => x.Assesmentid == model.assessmentid && x.QuestionId==model.questionid && x.Usermailid==model.usermailid).FirstOrDefault();
                        _customerfeedbackdbcontext.ExUserResponses.Remove(exUserResponse1);
                        _customerfeedbackdbcontext.SaveChanges();
                    }


                    ExUserResponse exUserResponse = new ExUserResponse();
                    exUserResponse.Usermailid = model.usermailid;
                    exUserResponse.Assesmentid = model.assessmentid;
                    exUserResponse.QuestionId = model.questionid;
                    exUserResponse.Answer1 = model.ans1;
                    exUserResponse.Answer2 = model.ans2;
                    exUserResponse.Answer3 = model.ans3;
                    exUserResponse.Answer4 = model.ans4;
                    exUserResponse.Answer5 = model.ans5;
                    exUserResponse.Answer6 = model.ans6;
                    exUserResponse.CreatedBy = model.enteredby;
                    exUserResponse.CreatedOn = DateTime.Now;  
                    _customerfeedbackdbcontext.ExUserResponses.Add(exUserResponse);

                    ExContributor exContributor = _customerfeedbackdbcontext.ExContributors.Where(x => x.MailId == model.usermailid
                    && x.AssesmentId == model.assessmentid).FirstOrDefault();
                    exContributor.AssessmentStatus = "In Progress";
                    _customerfeedbackdbcontext.ExContributors.Update(exContributor);

                    _customerfeedbackdbcontext.SaveChanges();  
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

        [HttpGet("GetAssesmentquestion/{assessmentid}/{usermailid}")]
        public IActionResult GetAssesmentquestion(string assessmentid, string usermailid)
        {
            //USP_Get_List_Clients_For_MSA_SOW '26663'
            Response response = new();
            try
            {
                string message = string.Empty;
                if (String.IsNullOrEmpty(assessmentid))
                {
                    response.Status = false;
                    response.Message = "assessmentid required";
                    response.Data = "";
                    response.Error = "assessmentid required";
                    return Ok(response);
                }
                else
                {
                    var ExAssesmentSetups = (from ipex in _customerfeedbackdbcontext.ExAssesmentSetups select ipex).ToList();
                    var ExQuestionBanks = (from ipex in _customerfeedbackdbcontext.ExQuestionBanks select ipex).ToList();
                    var ExUserResponses = (from ipex in _customerfeedbackdbcontext.ExUserResponses select ipex).ToList();
                    var ExResponseTypeMasters = (from ipex in _customerfeedbackdbcontext.ExResponseTypeMasters select ipex).ToList();

                    //Dictionary<string, object> dList = new Dictionary<string, object>();

                    var questionbank = (from a in ExAssesmentSetups
                                        join b in ExQuestionBanks on a.AssessmentQbId equals b.AssessmentQbId into sc
                                        from b in sc.DefaultIfEmpty()
                                        join c in ExUserResponses on b.QuestionId equals c.QuestionId  into sc1
                                        from c in sc1.DefaultIfEmpty()
                                        join d in ExUserResponses on usermailid equals d.Usermailid into sc2
                                        from d in sc2.DefaultIfEmpty()
                                        where a.AssessmentId.ToString() == assessmentid && b.IsDeleted == false
                                        orderby b.QuestionId
                                        select new
                                        {
                                            QuestionId = b.QuestionId,
                                            Question = b.Question,
                                            //ResponseType = b != null ? b.ResponseName : "NA",
                                            Option1 = b != null ? b.Option1 :"",
                                            Option2 = b != null ? b.Option2 : "",
                                            Option3 = b != null ? b.Option3 : "",
                                            Option4 = b != null ? b.Option4 : "",
                                            Option5 = b != null ? b.Option5 : "",
                                            Option6 = b != null ? b.Option6 : "",
                                            ResponseTypeid = b != null ?  b.ResponseType :"",
                                            Answer1 =c!=null? c.Answer1 :"",
                                            Answer2 = c!=null? c.Answer2 : "",
                                            Answer3 = c!=null? c.Answer3 : "",
                                            Answer4 = c!=null? c.Answer4 : "",
                                            Answer5 = c != null ? c.Answer5 : "",
                                            Answer6 = c != null ? c.Answer6 : "",
                                            isanswer = c != null ? "YES" : "NO"
                                        }).Distinct().ToList();

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

        [HttpPost("SubmitAssessment")]
        public IActionResult SubmitAssessment(SubmitAssessment model)
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
                   

                    ExContributor exContributor = _customerfeedbackdbcontext.ExContributors.Where(x => x.MailId == model.usermailid
                    && x.AssesmentId == model.assessmentid).FirstOrDefault();
                    exContributor.AssessmentStatus = "Completed";
                    exContributor.UpdatedBy = model.enteredby;
                    exContributor.Updatedon = DateTime.Now;
                    _customerfeedbackdbcontext.ExContributors.Update(exContributor);

                    _customerfeedbackdbcontext.SaveChanges();
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


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
