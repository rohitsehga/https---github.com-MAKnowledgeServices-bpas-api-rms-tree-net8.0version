using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceRequestService.Data;
using ResourceRequestService.Helpers;
using ResourceRequestService.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceRequestService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectManagementController : Controller
    {
        private readonly RepositoryDbContext _repositorycontext;
        private readonly EDMDbContext _edmdbcontext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public ProjectManagementController(IHttpContextAccessor httpContextAccessor, IMapper mapper, RepositoryDbContext repositorycontext, EDMDbContext edmrepositorycontext)
        {
            _httpContextAccessor = httpContextAccessor;

            _mapper = mapper;
            _repositorycontext = repositorycontext;
            _edmdbcontext = edmrepositorycontext;
        }

        [HttpGet("GetProjectList/{pelogn}")]
        public IActionResult GetProjectList(string pelogn)
        {
            Dictionary<string, object> dList = new Dictionary<string, object>();
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
                    //var resourceassignemntstatus = (from El in _repositorycontext.ExResourceassignmentstatuses select El).ToList();
                    //var ExResourceallocations = (from El in _repositorycontext.ExResourceallocations select El).ToList();
                    //var ExResourcebillpercents = (from El in _repositorycontext.ExResourcebillpercents select El).ToList();
                    //var IpCustomers = (from El in _repositorycontext.IpCustomers select El).ToList();

                    //var IpElements = (from El in _edmdbcontext.IpElements select El).ToList();
                    //var IpCategories = (from El in _edmdbcontext.IpCategories select El).ToList();
                    //var ExStatusdescs = (from El in _repositorycontext.ExStatusdescs select El).ToList();
                    //var IpPeople = (from El in _repositorycontext.IpPeople select El).ToList();
                    //var ExIppeople = (from El in _repositorycontext.ExIppeople select El).ToList();

                    string LognType = string.Empty;
                    Core core = new(_repositorycontext, _edmdbcontext);
                    LognType = core.uFn_LoginCheck(pelogn);

                    if (LognType == "ADMIN")
                    {
                        var ProjectDetails = (from a in _repositorycontext.IpNewprojs
                                              join b in _repositorycontext.IpProjects on a.PrIden equals b.PrIden into sc1
                                              from b in sc1.DefaultIfEmpty()
                                              //join c in _repositorycontext.IpActivities on a.PrIden equals c.PrIden into sc2
                                              //from c in sc2.DefaultIfEmpty()
                                              //join d in _repositorycontext.IpTasktypes on c.AcUtyp equals d.TtCode into sc3
                                              //from d in sc3.DefaultIfEmpty()
                                              //join e in _repositorycontext.IpPhases on c.AcPhse equals e.PhCode into sc4
                                              //from e in sc4.DefaultIfEmpty()
                                              where a.PrIden != '0' && a.NpSbdt != null && b.PrName !=null  /* && c.AcStat == "S"*/ /*&& b.PrPlst >= Convert.ToDateTime("1 Jan 2022") */
                                              orderby b.PrName ascending
                                              select new
                                              {
                                                  ProjectName = b.PrName,
                                                  //AcName = c.AcName,
                                                  //PhName = e.PhName,
                                                  //TtName = d.TtName,
                                                  //AcPlst = c.AcPlst,
                                                  //Status = c.AcStat == "P" ? "Planned" : "Finish",
                                                  PrIden = a.PrIden,
                                                  Client = b.PrCust,
                                                  StartDate = b.PrPlst.Value.ToString("yyyy-MM-dd")
                                                  //ProjectName = b.PrName,
                                                  //AcName = c.AcName,
                                                  //PhName = e.PhName,
                                                  //TtName = d.TtName,
                                                  //AcPlst = c.AcPlst.Value.ToString("yyyy-MMM-ddd"),
                                                  //Status = c.AcStat == "P" ? "Planned" : "Finish",
                                                  //PrIden = a.PrIden,
                                                  //Client = b.PrCust

                                              }).Distinct().ToList();



                        dList.Add("ProjectDetails", ProjectDetails);

                    }
                    else
                    {

                        var ProjectDetails = (from a in _repositorycontext.IpNewprojs
                                              join b in _repositorycontext.IpProjects on a.PrIden equals b.PrIden into sc1
                                              from b in sc1.DefaultIfEmpty()
                                              //join c in _repositorycontext.IpActivities on a.PrIden equals c.PrIden into sc2
                                              //from c in sc2.DefaultIfEmpty()
                                              //join d in _repositorycontext.IpTasktypes on c.AcUtyp equals d.TtCode into sc3
                                              //from d in sc3.DefaultIfEmpty()
                                              //join e in _repositorycontext.IpPhases on c.AcPhse equals e.PhCode into sc4
                                              //from e in sc4.DefaultIfEmpty()
                                              where a.PrIden != '0' && a.NpSbdt != null && a.PeLogn == pelogn /*&& c.AcStat == "S"*/

                                              select new
                                              {
                                                  ProjectName = b.PrName,
                                                  //AcName = c.AcName,
                                                  //PhName = e.PhName,
                                                  //TtName = d.TtName,
                                                  //AcPlst = c.AcPlst,
                                                  //Status = c.AcStat == "P" ? "Planned" : "Finish",
                                                  PrIden = a.PrIden,
                                                  Client = b.PrCust,
                                                StartDate =  b.PrPlst.Value.ToString("yyyy-MM-dd")

                                              }).Distinct().ToList();

                        dList.Add("ProjectDetails", ProjectDetails);
                    }

                    response.Data = dList;
                    response.Status = true;
                    response.Message = "Success";
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

        [HttpGet("GetProjectDetail/{priden}/{pelogn}")]
        public IActionResult GetProjectDetail(string priden,string pelogn)
        {
            Dictionary<string, object> dList = new Dictionary<string, object>();
            Response response = new();
            try
            {
                string message = string.Empty;
                if (String.IsNullOrEmpty(priden))
                {
                    response.Status = false;
                    response.Message = "priden required";
                    response.Data = "";
                    response.Error = "priden required";
                    return Ok(response);
                }
                else
                {
                    List<ProjectDetail> projectdetails = new List<ProjectDetail>();

                    decimal? effortsum = 0;
                    decimal? billedeffortsum = 0;
                    decimal? nonbilledeffortsum = 0;
                    var TotalEffort = (from p in _repositorycontext.IpDailyeffs
                                      where p.PeLogn == pelogn  && p.DeDate.Year == 2022 && p.DeDate.Month==9 && p.PrIden.ToString()==priden
                                      select new
                                      {
                                          DeEffo = p.DeEffo

                                      }).ToList();

                    //var TotalBilledEffort = (from p in _repositorycontext.IpDailyeffs
                    //                         where p.PeLogn == pelogn && p.DeDate.Year == 2022 && p.DeDate.Month == 11 && p.PrIden.ToString() == priden
                    //                         && p.AmbBillable.ToString() == "1"
                    //                         select new
                    //                         {
                    //                             DeEffo = p.DeEffo

                    //                         }).ToList();

                    //var TotalNonBilledEffort = (from p in _repositorycontext.IpDailyeffs
                    //                         where p.PeLogn == pelogn && p.DeDate.Year == 2022 && p.DeDate.Month == 11 && p.PrIden.ToString() == priden
                    //                          && p.AmbBillable.ToString() == "0"
                    //                            select new
                    //                         {
                    //                             DeEffo = p.DeEffo

                    //                         }).ToList();

                    if (TotalEffort.Count > 0)
                    {
                        effortsum = TotalEffort.Sum(t => t.DeEffo);
                    }

                    //if (TotalBilledEffort.Count > 0)
                    //{
                    //    billedeffortsum = TotalBilledEffort.Sum(t => t.DeEffo);
                    //}

                    //if (TotalNonBilledEffort.Count > 0)
                    //{
                    //    nonbilledeffortsum = TotalNonBilledEffort.Sum(t => t.DeEffo);
                    //}


                    projectdetails.Add(new ProjectDetail("Total Effort", effortsum/60));
                    projectdetails.Add(new ProjectDetail("Total Billed Effort", effortsum/60));
                     projectdetails.Add(new ProjectDetail("Total Non Billed Effort", nonbilledeffortsum));

                    response.Data = projectdetails;
                    response.Status = true;
                    response.Message = "Success";
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

        [HttpGet("GetProjectTaskBoard/{priden}")]
        public IActionResult GetProjectTaskBoard(string priden)
        {
            Dictionary<string, object> dList = new Dictionary<string, object>();
            Response response = new();
            try
            {
                string message = string.Empty;
                if (String.IsNullOrEmpty(priden))
                {
                    response.Status = false;
                    response.Message = "priden required";
                    response.Data = "";
                    response.Error = "priden required";
                    return Ok(response);
                }
                else
                { 

                    var PendingActivity = (from a in _repositorycontext.IpActivities 
                                          where a.PrIden.ToString() == priden && a.AcStat=="p"

                                          select new
                                          {
                                              ProjectName = a.AcName   
                                          }).Distinct().ToList();


                    var StartedActivity = (from a in _repositorycontext.IpActivities
                                           where a.PrIden.ToString() == priden && a.AcStat == "S"

                                           select new
                                           {
                                               ProjectName = a.AcName
                                           }).Distinct().ToList();


                    var FinishActivity = (from a in _repositorycontext.IpActivities
                                           where a.PrIden.ToString() == priden && a.AcStat == "F"

                                           select new
                                           {
                                               ProjectName = a.AcName
                                           }).Distinct().ToList();

                    var IpPeople = (from El in _edmdbcontext.IpPeople select El).ToList();
                    var ExIppeople = (from El in _edmdbcontext.ExIppeople select El).ToList();
                    var IpElements = (from El in _edmdbcontext.IpElements select El).ToList();
                    var IpCategories = (from El in _edmdbcontext.IpCategories select El).ToList();

                    var IpNewprojs = (from El in _repositorycontext.IpNewprojs select El).ToList();
                    var ExIpprojectTeamAllocations = (from El in _repositorycontext.ExIpprojectTeamAllocations select El).ToList();

                    var ProjectPeople = (from a in IpNewprojs
                                         join b in IpPeople on a.PeLogn equals b.PeLogn into sc1
                                         from b in sc1.DefaultIfEmpty()
                                         join b2 in IpElements on new
                                         { User = b != null ? b.PeDept : "" }
                  equals new { User = b2 != null ? b2.ElCode : "" }

                              into cp1
                                         from b2 in cp1.DefaultIfEmpty()
                                         join b3 in ExIppeople on new
                                         { User = b != null ? b.PeLogn : "" }
                 equals new { User = b3 != null ? b3.PeLogn : "" }

                             into cp2
                                         from b3 in cp2.DefaultIfEmpty()
                                         join c in ExIpprojectTeamAllocations on a.PeLogn equals c.PeLogn into sc3
                                         from c in sc3.DefaultIfEmpty()
                                             //join c in IpElements on b.PeDept equals c.ElCode into sc2
                                             //from c in sc2.DefaultIfEmpty()
                                         where a.PrIden.ToString() == priden && a.NpSbdt !=null

                                          select new
                                          {
                                              Pelogn = a.PeLogn,
                                              PeName = b!=null ? b.PeName :"",
                                             Dept = b2 != null ? b2.ElName : "",
                                              AllocPercentage= c!=null ? c.AllocPercentage :0,
                                             startdate = c != null ?  c.ProjStartdate.Value.ToString("yyy-MM-dd") : "",
                                              WwPersonId = b3 != null ?  b3.WwPersonId : ""

                                          }).Distinct().ToList();



                    dList.Add("PendingActivity", PendingActivity);
                    dList.Add("StartedActivity", StartedActivity);
                    dList.Add("FinishActivity", FinishActivity);
                    dList.Add("ProjectPeople", ProjectPeople);


                    response.Data = dList;
                    response.Status = true;
                    response.Message = "Success";
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
