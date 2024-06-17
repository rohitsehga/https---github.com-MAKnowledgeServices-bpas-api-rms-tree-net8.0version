using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ResourceRequestService.Data;
using ResourceRequestService.Helpers;
using ResourceRequestService.Models.Repository;
using ResourceRequestService.Models.EMPDATA;
//using Rest;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace ResourceRequestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly RepositoryDbContext _repositorycontext;
        private readonly EDMDbContext _edmdbcontext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        //public IConfiguration Configuration { get; }
        public ClientController(IHttpContextAccessor httpContextAccessor, IMapper mapper, RepositoryDbContext repositorycontext, EDMDbContext edmrepositorycontext)
        {
            _httpContextAccessor = httpContextAccessor;

            _mapper = mapper;
            _repositorycontext = repositorycontext;
            _edmdbcontext = edmrepositorycontext;
        }

       

        [HttpGet("GetClientMaster")]
        public IActionResult AdminPageMaster()
        {
            Response response = new();
            try
            {
                //List<AdminGetRole> listAdminGetRole = new List<AdminGetRole>();

                var rolemaster = (from p in _edmdbcontext.IpCategories
                            where p.CaValu == "1" && (p.CaOrdr >= 20 && p.CaOrdr <= 80) && p.CaCode != "TL"
                            select new
                            {
                                value = p.CaCode,
                                label = p.CaName
                            }).ToList();


                var industoryclassification = (from p in _repositorycontext.ExIndustoryClassificationMasters
                                  where p.Status=="A"
                                  select new
                                  {
                                      value = p.ClassificationId,
                                      label = p.Classification
                                  }).ToList();

                var companyentitymaster = (from p in _edmdbcontext.ExCompanyEntities
                                               where p.Status == "A"
                                               select new
                                               {
                                                   value = p.CntrlEntityId,
                                                   label = p.CcName
                                               }).ToList();

                var replacementreasonmaster = (from p in _repositorycontext.ExReplacementReasonMasters
                                           where p.EndDate == null
                                           orderby p.Id
                                           select new
                                           {
                                               value = p.Id,
                                               label = p.ShortDescription
                                           }).ToList();


               var myInClause = new string[] { "Costa Rica", "Colombo", "Bengaluru", "Gurgaon", "Beijing", "Pune" };

                var locationlist = (from p in _edmdbcontext.IpLocations
                                    where myInClause.Contains(p.LnName)
                                    orderby p.IpLocn
                                    select new
                                    {
                                        value = p.IpLocn,
                                        label = p.LnName
                                    }).ToList();

                var usageclauses = (from p in _repositorycontext.ExUsageClauseMasters
                                               where p.Status=="A"
                                               orderby p.Cid
                                               select new
                                               {
                                                   value = p.Cid,
                                                   label = p.Clause
                                               }).ToList();

                var BillEntityMaster = (from p in _repositorycontext.BillEntityMasters
                                     where p.Status == "A" 
                                    select new
                                    {
                                        value = p.EntityName,
                                        label = p.EntityName
                                    }).ToList();


                var LOBmaster = (from p in _edmdbcontext.IpPeople
                                  join a in _edmdbcontext.IpElements on p.PeDept equals a.ElCode into sc
                                  from a in sc.DefaultIfEmpty()
                                  where p.PeQuit == null && a.CaCode=="LOB" && a.ElArch=="0"
                                  orderby a.ElName
                                  select new
                                  {
                                      value = p.PeDept,
                                      label = a.ElName
                                  }).Distinct().ToList();


                var ClientTypemaster = (from p in _edmdbcontext.IpElements 
                                 where p.CaCode == "Clnt"
                                        orderby p.ElName
                                 select new
                                 {
                                     value = p.ElCode,
                                     label = p.ElName
                                 }).Distinct().ToList();

                var Servicemaster = (from p in _repositorycontext.ExGroupMainservices 
                                        orderby p.Maingroupdesc
                                        select new
                                        {
                                            value = p.Maingroupid,
                                            label = p.Maingroupdesc
                                        }).Distinct().ToList();

                var ClientLocationmaster = (from p in _edmdbcontext.IpElements
                                        where p.CaCode == "Geo"
                                            orderby p.ElName
                                        select new
                                        {
                                            value = p.ElCode,
                                            label = p.ElName
                                        }).Distinct().ToList();

                var ACCMGRmaster = (from p in _edmdbcontext.IpPeople
                                            where p.PeQuit==null && p.PeDept=="10017"
                                            orderby p.PeName
                                            select new
                                            {
                                                value = p.PeLogn,
                                                label = p.PeName.ToUpper()
                                            }).Distinct().ToList();

                var EMGRmaster = (from p in _edmdbcontext.IpPeople
                                    where p.PeQuit == null  
                                    orderby p.PeName
                                    select new
                                    {
                                        value = p.PeLogn,
                                        label = p.PeName.ToUpper()
                                    }).Distinct().ToList();


                var UnbilledReasonmaster = (from p in _repositorycontext.ExUnbilledMasters 
                                  orderby p.SubreasonSl
                                  select new
                                  {
                                      value = p.SubreasonSl,
                                      label = p.SubreasonDesc
                                  }).Distinct().ToList();

                var EngagementTypesmaster = (from p in _repositorycontext.ExEngagementTypes
                                            orderby p.Engagement
                                            select new
                                            {
                                                value = p.Id,
                                                label = p.Engagement
                                            }).Distinct().ToList();

                var ExIpcustomers = (from p in _repositorycontext.ExIpcustomers 
                                     orderby p.CuCode
                                             select new
                                             {
                                                 CuIden = p.CuIden,
                                                 CuCode = p.CuCode,
                                                 CuName = p.CuName,
                                                 Status = p.Status
                                             }).Distinct().ToList();

                var ActiveEmployeeMaster = (from p in _edmdbcontext.IpPeople
                                            join b in _edmdbcontext.ExIppeople on p.PeLogn equals b.PeLogn into sb
                                            from b in sb.DefaultIfEmpty()
                                            where p.PeQuit == null
                                  orderby p.PeName
                                  select new
                                  {
                                      value = p.PeLogn,
                                      label = p.PeName.ToUpper() +" ("+ b.WwPersonId+")"
                                  }).Distinct().ToList();


                Dictionary<string, object> dList = new Dictionary<string, object>();
                dList.Add("rolemaster", rolemaster); 
                dList.Add("industoryclassification", industoryclassification); 
                dList.Add("companyentitymaster", companyentitymaster); 
                dList.Add("replacementreasonmaster", replacementreasonmaster); 
                dList.Add("locationlist", locationlist); 
                dList.Add("usageclauses", usageclauses); 
                dList.Add("BillEntityMaster", BillEntityMaster); 
                dList.Add("LOBmaster", LOBmaster); 
                dList.Add("ClientTypemaster", ClientTypemaster); 
                dList.Add("Servicemaster", Servicemaster); 
                dList.Add("ClientLocationmaster", ClientLocationmaster); 
                dList.Add("ACCMGRmaster", ACCMGRmaster); 
                dList.Add("EMGRmaster", EMGRmaster);
                dList.Add("UnbilledReasonmaster", UnbilledReasonmaster);
                dList.Add("EngagementTypesmaster", EngagementTypesmaster);
                dList.Add("ExIpcustomers", ExIpcustomers);
                dList.Add("ActiveEmployeeMaster", ActiveEmployeeMaster);
                

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

        [HttpGet("GetActiveClientListRoleWise/{pelogin}")] 
        public IActionResult GetActiveClientListRoleWise(string pelogin)
        {
            //USP_Get_List_Clients_For_MSA_SOW '26663'
            Response response = new();
            try
            {
                string message = string.Empty;
                if (String.IsNullOrEmpty(pelogin))
                {
                    response.Status = false;
                    response.Message = "pelogin required";
                    response.Data = "";
                    response.Error = "pelogin required";
                    return Ok(response);
                }
                else
                {
                    var ippersonlist = (from ipex in _edmdbcontext.IpPeople select ipex).ToList();

                    //var persondept = (from aa in ippersonlist where aa.PeLogn == pelogin).ToList();

                    //var persondept = (from a in ippersonlist
                    //                  where a.PeLogn == pelogin 
                    //                     select new
                    //                     {
                    //                         a.PeDept

                    //                     } ).ToList();

                    
                    Core core = new(_repositorycontext, _edmdbcontext);
                    string role = core.uFn_LoginCheck(pelogin);  

                    string dept = core.getdepartment(pelogin);

                    //var activeclient;
                    //var deactiveclient;

                    Dictionary<string, object> dList = new Dictionary<string, object>();

                    if (role == "ADMIN")
                    {
                        var activeclient = (from p in _repositorycontext.ExResourceassignmentstatuses
                                            join a in _repositorycontext.ExIpcustomers on p.CuIden equals a.CuIden
                                            where p.Enddate == null && p.CuIden.ToString() != "85" && a.CuCode != null
                                            orderby a.CuCode
                                            select new
                                            {
                                                CuIden = a.CuIden,
                                                CUCODE = a.CuCode.ToUpper(),
                                                LegalName = a.CuName,
                                                value = a.CuIden,
                                                label = a.CuCode
                                                //TOtalHC =g.ToList().Count 
                                            }).Distinct().ToList(); 

                        //var myInClause = new string[] { "Costa Rica", "Colombo", "Bengaluru", "Gurgaon", "Beijing" };

                        //var deactiveclient = (from p in _repositorycontext.ExIpcustomers 
                        //                      select new
                        //                      {
                        //                          CuIden = p.CuIden

                        //                      }).Except(activeclientlist).ToList();

                        dList.Add("activeclient", activeclient);
                       // dList.Add("deactiveclient", deactiveclient);
                    }
                    else if (role == "PL")
                    {
                        var activeclient = (from a in _repositorycontext.ExClientPlOwners
                                        join b in _repositorycontext.ExClientServicelines on a.ServiceLine equals b.ServiceLine 
                                        join d in _repositorycontext.ExIpcustomers on b.CuIden equals d.CuIden 
                                        where a.PeLogn == pelogin && a.Enddate == null && a.Status == "A"  && b.Enddate == null && d.CuIden.ToString() !="85"
                                        orderby d.CuCode  
                                        select new
                                        {
                                            CuIden = d.CuIden,
                                            CUCODE = d.CuCode.ToUpper(),
                                            LegalName = d.CuName,
                                            value = d.CuIden,
                                            label = d.CuCode
                                        }).Distinct().ToList();

                        //var deactiveclient = (from p in _repositorycontext.ExResourceassignmentstatuses
                        //                  join a in _repositorycontext.ExIpcustomers on p.CuIden equals a.CuIden
                        //                  where p.Enddate != null && p.CuIden.ToString() != "85" && a.CuCode != null
                        //                  orderby a.CuCode

                        //                  select new
                        //                  {
                        //                      CuIden = a.CuIden,
                        //                      CUCODE = a.CuCode.ToUpper(),
                        //                      LegalName = a.CuName,
                        //                      value = a.CuIden,
                        //                      label = a.CuCode
                        //                      //TOtalHC =g.ToList().Count 
                        //                  }).Distinct().ToList();

                        dList.Add("activeclient", activeclient);
                        //dList.Add("deactiveclient", deactiveclient);
                    }
                    else if (role == "PMO")
                    {
                        var activeclient = (from a in _repositorycontext.ExAccessMasters
                                        join b in _repositorycontext.ExClientServicelines on a.ServiceLine equals b.ServiceLine 
                                        join d in _repositorycontext.ExIpcustomers on b.CuIden equals d.CuIden 
                                        where a.PeLogn == pelogin && a.Enddate == null && a.Status =="A" && a.Role.ToLower() =="pmo"  && b.Enddate == null && d.CuIden.ToString() != "85" 
                                        orderby d.CuCode 

                                        select new
                                {
                                    CuIden = d.CuIden,
                                    CUCODE = d.CuCode.ToUpper(),
                                    LegalName = d.CuName,
                                    value = d.CuIden,
                                    label =d.CuCode
                                }).Distinct().ToList();

                        //var deactiveclient = (from p in _repositorycontext.ExResourceassignmentstatuses
                        //                  join a in _repositorycontext.ExIpcustomers on p.CuIden equals a.CuIden
                        //                  where p.Enddate != null && p.CuIden.ToString() != "85" && a.CuCode != null
                        //                  orderby a.CuCode

                        //                  select new
                        //                  {
                        //                      CuIden = a.CuIden,
                        //                      CUCODE = a.CuCode.ToUpper(),
                        //                      LegalName = a.CuName,
                        //                      value = a.CuIden,
                        //                      label = a.CuCode
                        //                      //TOtalHC =g.ToList().Count 
                        //                  }).Distinct().ToList();

                        dList.Add("activeclient", activeclient);
                        //dList.Add("deactiveclient", deactiveclient);
                    }
                    else if (role == "DM" )
                    {
                        var activeclient = (from a in _repositorycontext.ExResourceassignmentstatuses
                                            join b in _repositorycontext.ExIpcustomers on a.CuIden equals b.CuIden
                                            //join c in ippersonlist on a.PeLogn equals c.PeLogn
                                            where a.Enddate == null && a.CuIden.ToString() != "85" && b.CuCode != null
                                             && a.PeLogn == pelogin && a.Role.ToLower() == "dm"
                                            //join c in ippersonlist on p.PeLogn equals c.PeLogn
                                            orderby b.CuCode
                                            //group a by a.CuIden.ToString() into g

                                            select new
                                            {
                                                CuIden = b.CuIden,
                                                CUCODE = b.CuCode.ToUpper(),
                                                LegalName = b.CuName,
                                                value = b.CuIden,
                                                label = b.CuCode
                                            }).Distinct().ToList();
                                //.Union(from p in _repositorycontext.ExIpcustomers
                                //         where p.Entrystamp > DateTime.Now.AddDays(-30)
                                //         select new
                                //         {
                                //             CuIden = p.CuIden,
                                //             CUCODE = p.CuCode.ToUpper(),
                                //             LegalName = p.CuName,
                                //             value = p.CuIden,
                                //             label = p.CuCode
                                //         }).Distinct().ToString();

                        //var deactiveclient = (from p in _repositorycontext.ExResourceassignmentstatuses
                        //                  join a in _repositorycontext.ExIpcustomers on p.CuIden equals a.CuIden
                        //                  where p.Enddate != null && p.CuIden.ToString() != "85" && a.CuCode != null
                        //                  orderby a.CuCode

                        //                  select new
                        //                  {
                        //                      CuIden = a.CuIden,
                        //                      CUCODE = a.CuCode.ToUpper(),
                        //                      LegalName = a.CuName,
                        //                      value = a.CuIden,
                        //                      label = a.CuCode
                        //                      //TOtalHC =g.ToList().Count 
                        //                  }).Distinct().ToList();

                        dList.Add("activeclient", activeclient);
                       // dList.Add("deactiveclient", deactiveclient);
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
                response.Message = ex.Message;
                response.Error = ex.ToString();
                return Ok(response);
            }
        }

        [HttpGet("GetClientDetail/{cuiden}")]
        public IActionResult GetActiveClicntListRoleWise(string cuiden)
        {
            //USP_Get_List_Clients_For_MSA_SOW '26663'
            Response response = new();
            try
            {
                string message = string.Empty;
                if (String.IsNullOrEmpty(cuiden))
                {
                    response.Status = false;
                    response.Message = "cuiden required";
                    response.Data = "";
                    response.Error = "cuiden required";
                    return Ok(response);
                }
                else
                {

                    Dictionary<string, object> dList = new Dictionary<string, object>();

                    var ippersonlist = (from ipex in _edmdbcontext.IpElements select ipex).ToList();
                    var sowlist = (from ipex in _repositorycontext.ExSownumbers select ipex).ToList();
                    var clientpeople = (from ipex in _repositorycontext.ExResourceassignmentstatuses where ipex.CuIden.ToString()==cuiden && ipex.Enddate==null select ipex).ToList();
                    var peoplelist = (from ipex in _edmdbcontext.IpPeople select ipex).ToList();


                    var totalHC = (from p in _repositorycontext.ExResourceassignmentstatuses
                                   where p.Enddate==null && p.CuIden.ToString() == cuiden
                                   group p by p.CuIden.ToString() into g
                                   select new
                                        { 
                                       CuIden=g.Key,
                                            TotalHC =g.ToList().Count 
                                        }).Distinct().ToList();

                    var billedHC = (from p in _repositorycontext.ExResourceassignmentstatuses
                                   where p.Enddate == null && ( p.Reason.ToLower() == "billing" || p.Reason.ToLower() == "bna" ||  p.Reason.ToLower() == "nbst5") && p.CuIden.ToString() == cuiden
                                   group p by p.CuIden.ToString() into g
                                   select new
                                   {
                                       CuIden = g.Key,
                                       BilledHC = g.ToList().Count
                                   }).Distinct().ToList();

                    var nonbilledHC = (from p in _repositorycontext.ExResourceassignmentstatuses
                                    where p.Enddate == null && (p.Reason == "AB" || p.Reason.ToLower() == "nbst1" || p.Reason.ToLower() == "nbst2" || p.Reason.ToLower() == "nbst3" || p.Reason.ToLower() == "nbst4"
                                    || p.Reason.ToLower() == "nba" || p.Reason.ToLower() == "notbilling") && p.CuIden.ToString() == cuiden
                                       group p by p.CuIden.ToString() into g
                                    select new
                                    {
                                        CuIden = g.Key,
                                        NonBilledHC = g.ToList().Count
                                    }).Distinct().ToList();

                    var listofsow = (from a in sowlist
                                     join b in ippersonlist on a.ElCode equals b.ElCode
                                     where a.CuIden.ToString() == cuiden
                                     select new
                                     {
                                         SowNumber = a.SowNumber,
                                         SowDate = a.Sowdate.Value.ToString("yyyy-MM-dd"),
                                         ElName = b.ElName,
                                         FileName =a.FileName,
                                          MSANumber = a.Msanumber  != null ? a.Msanumber : "",
                                        MSADate = a.Msadate != null ?  a.Msadate.Value.ToString("yyyy-MM-dd") : "",
                                         MSAFilename = a.MsafileName != null ?  a.MsafileName : "",
                                        ElCode =  a.ElCode != null ?  a.ElCode : "",
                                         TotalResource = a.TotalResource.ToString() !=null ? a.TotalResource.ToString() : "",
                                         TotalBilledResource = a.TotalBilledResource.ToString() != null ? a.TotalBilledResource.ToString() : "",
                                         Bgccheck = a.Bgccheck.ToString() != null ? a.Bgccheck.ToString() : "",
                                         DrugTestCheck = a.DrugTestCheck.ToString() != null ? a.DrugTestCheck.ToString() : "",
                                         IdentityCheck = a.IdentityCheck.ToString() != null ? a.IdentityCheck.ToString() : ""
                                     }).Distinct().ToList();

                    var activepeopleonclient= (from a in clientpeople
                                     join b in peoplelist on a.PeLogn equals b.PeLogn
                                     where a.CuIden.ToString() == cuiden
                                     select new
                                     {
                                         PeLogn= a.PeLogn,
                                         PeMail = b.PeMail,
                                         PeName = b.PeName,
                                         value= a.PeLogn,
                                         label=b.PeName

                                     }).Distinct().ToList();

                    dList.Add("totalHC", totalHC); 
                    dList.Add("billedHC", billedHC); 
                    dList.Add("nonbilledHC", nonbilledHC); 
                    dList.Add("listofsow", listofsow);  
                    dList.Add("activepeopleonclient", activepeopleonclient); 

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
                response.Message = ex.Message;
                response.Error = ex.ToString();
                return Ok(response);
            }
        }

        [HttpGet("GetPersonRole/{pelogn}")]
        public IActionResult GetPersonRole(string pelogn)
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
                    List<GetRole> getRoles = new List<GetRole>();

                    string role = string.Empty;
                    Core core = new(_repositorycontext, _edmdbcontext);
                    role = core.uFn_LoginCheck(pelogn);


                    getRoles.Add(new GetRole("Role", role));

                    response.Data = getRoles;
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

        [HttpGet("GetPersonDept/{pelogn}")]
        public IActionResult GetPersonDept(string pelogn)
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
                    List<GetRole> getRoles = new List<GetRole>();

                    string role = string.Empty;
                    Core core = new(_repositorycontext, _edmdbcontext);
                    role = core.getdepartment(pelogn); 

                    getRoles.Add(new GetRole("Dept", role));

                    response.Data = getRoles;
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

        [HttpGet("GetDepartmentRoleRole/{pelogn}")]
        public IActionResult GetDepartmentRoleRole(string pelogn)
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
                    List<GetRole> getRoles = new List<GetRole>();

                    string role = string.Empty;
                    string dept = string.Empty;
                    Core core = new(_repositorycontext, _edmdbcontext);
                    dept = core.getdepartment(pelogn); 

                    if(dept.ToUpper()== "CMPL")
                    {
                        role = "ComplianceTeam";
                    }
                    else if (dept.ToUpper() == "FIN.")
                    {
                        role = "FinanceTeam";
                    }
                    else if (dept.ToUpper() == "IT1")
                    {
                        role = "ITTeam";
                    }
                    else if (dept.ToUpper() == "10016")
                    {
                        role = "AdminTeam";
                    }
                    else  
                    {
                        role = "None";
                    }

                    getRoles.Add(new GetRole("Role", role));

                    response.Data = getRoles;
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

        [HttpPost("InsertClientContact")]
        public IActionResult InsertClientContact(InsertClientContact model)
        {
            Response response = new();
            KickOffStatus kickmodel = new KickOffStatus();
            ResultTemp resultModel = new ResultTemp();
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
                    ExClientcontact exClientcontact = new ExClientcontact();
                    exClientcontact.CuIden = model.cuiden;
                    exClientcontact.Name = model.Name;
                    exClientcontact.Emailid = model.emailid;
                    exClientcontact.PhoneNumber = model.phoneno;
                    exClientcontact.Role=model.role;
                    exClientcontact.Status = "A";
                    exClientcontact.EnteredBy = model.enteredby;
                    exClientcontact.EnteredOn = DateTime.Now;
                    _repositorycontext.ExClientcontacts.Add(exClientcontact);

                    _repositorycontext.SaveChanges();
                    kickmodel.nstatus = "Insert Sucessfully";

                }

                response.Status = true;
                response.Message = kickmodel.nstatus;
                response.Data = kickmodel.nstatus;
                response.Error = "";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Something went wrong. Please contact Administrator !!";
                response.Error = ex.ToString();
                return Ok(response);

            }
        }

        [HttpGet("GetClientContact/{cuiden}")]
        public IActionResult GetClientContact(string cuiden)
        {
            Response response = new Response();
            try
            {
                string message = string.Empty;
                if (String.IsNullOrEmpty(cuiden))
                {
                    response.Status = false;
                    response.Message = "cuiden required";
                    response.Data = "";
                    response.Error = "cuiden required";
                    return Ok(response);
                }
                else
                {
                 
                    var Clientcontacts = (from ipex in _repositorycontext.ExClientcontacts select ipex).ToList(); 
                    var ippersonlist = (from ipex in _edmdbcontext.IpPeople select ipex).ToList();

                    var Clientcontactsmatter = (from p in Clientcontacts
                                    join a in ippersonlist on p.EnteredBy equals a.PeLogn into sc
                                    from a in sc.DefaultIfEmpty()
where p.CuIden.ToString()==cuiden
                                    orderby p.EnteredOn descending
                                    select new
                                    {
                                       ID =  p.Id,
                                        Name = p.Name,
                                        PhoneNumber =  p.PhoneNumber,
                                        Role = p.Role,
                                        Emailid =  p.Emailid, 
                                        EnteredBy = a.PeName,
                                        EnteredOn = p.EnteredOn == null ? " " : p.EnteredOn.Value.ToString("yyyy-MM-dd") 
                                    }).ToList();
                     
                   
                    response.Data = Clientcontactsmatter;
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

        [HttpPost("UpdateClientContact")]
        public IActionResult UpdateClientContact(UpdateClientContact model)
        {
            Response response = new();
            KickOffStatus kickmodel = new KickOffStatus();
            ResultTemp resultModel = new ResultTemp();
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

                    ExClientcontact exClientcontact = _repositorycontext.ExClientcontacts.Where(x => x.Id == model.ID).FirstOrDefault();
                    exClientcontact.Name = model.Name;
                    exClientcontact.Emailid = model.emailid;
                    exClientcontact.PhoneNumber = model.phoneno;
                    exClientcontact.Role = model.role; 
                    exClientcontact.UpdatedBy = model.updatedby;
                    exClientcontact.UpdatedOn = DateTime.Now;
                    _repositorycontext.ExClientcontacts.Update(exClientcontact); 

                    _repositorycontext.SaveChanges();
                    kickmodel.nstatus = "Update Sucessfully";

                }

                response.Status = true;
                response.Message = kickmodel.nstatus;
                response.Data = kickmodel.nstatus;
                response.Error = "";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Something went wrong. Please contact Administrator !!";
                response.Error = ex.ToString();
                return Ok(response);

            }
        }

        //[HttpPost("sendEmail")]
        //public bool sendEmail(emailSendModel model)
        //{
        //    var url = "http://10.50.5.120:3021/api/sendemailv2";
        //    var client = new RestClient();
        //    var request = new RestRequest(url, method: Method.Post);
        //    request.AddHeader("Access-Control-Allow-Origin", "*");
        //    request.AddHeader("Authorization", "Y2F0Y2hlciUyMHdvbmclMjBsb3ZlJTIwLm5ldA");
        //    request.AddHeader("Content-Type", "application/json");
        //    request.AddBody(model);
        //    var response = client.ExecuteAsync(request).Result;
          
        //    bool success = ((int)response.StatusCode) >= 200 && ((int)response.StatusCode) < 300;
        //    return success;
             
        //    //response.Status = true;
        //}

        [HttpPost("addClient")]
        public IActionResult addClient(ClientModel model)
        {
            Response response = new();
            try
            {
                string message = string.Empty;
                if (model is null)
                {
                    response.Status = false;
                    response.Message = "Atleast one record required";
                    response.Data = "";
                    response.Error = "Atleast one record required";
                    return Ok(response);
                }
                else
                {
                    var finddata = (from p in _repositorycontext.MasterAbbrevations
                                    where p.Lob==model.ServiceLine 
                                    select new
                                    {
                                        clientgroup = p.Code  

                                    }).Take(1).ToList();
                    string group = "";
                    if (finddata.Count > 0)
                    {
                        group = finddata[0].clientgroup; 
                    }

                    message = "Client added successfully";

                    Models.Repository.IpCustomer obj = new Models.Repository.IpCustomer();
                    obj.CuComp = model.CU_COMP;
                    obj.ExCuHmth = model.ExCuHmth;
                    _repositorycontext.IpCustomers.Add(obj);
                    _repositorycontext.SaveChanges();
                    Encryption objenc = new Encryption();
                   
                    string key = "mrt_micro_services_key_aes256";



                    if (model.Clienttype != null)
                    {
                        if (model.Clienttype.Length > 0)
                        {
                            string clientEncName = objenc.EncryptData(model.CuName, key);
                            Models.Repository.ExIpcustomer cust = new Models.Repository.ExIpcustomer();
                            cust.CuIden = obj.CuIden;
                            cust.CuCode = model.CU_COMP;
                            //cust.CuName = clientEncName;
                            cust.CuName = model.CuName;
                            cust.Entrystamp = DateTime.Now;
                            cust.Status = "A";
                            cust.WinLoginid = "Admin";
                            cust.Clienttype = model.Clienttype[0];
                            cust.NdasignDate = "N";
                            cust.LastupdatedBy = null;
                            cust.LastupdatedOn = null;
                            cust.Bgv = null;
                            cust.GracePeriod = 0;
                            cust.DrugTestReq = null;
                            cust.Lastupdatedby1 = null;
                            cust.Lastupdatedon1 = null;
                            cust.RepliconDataPort = null; 

                            _repositorycontext.ExIpcustomers.Add(cust);
                            // _repositorycontext.SaveChanges();


                        }
                    } 

                    ExClientServiceline serviceline1 = new ExClientServiceline();
                    serviceline1.CuIden = obj.CuIden;
                    serviceline1.Startdate = Convert.ToDateTime(model.StartDate);
                    serviceline1.Enddate = null;
                    serviceline1.Status = "A";
                    serviceline1.Entrystamp = DateTime.Now;
                    serviceline1.Userlognid = "Admin";
                    serviceline1.EnddateStamp = null;
                    serviceline1.EnddateUserlognid = null;
                    serviceline1.MailStatus = 1;
                    serviceline1.ServiceLine = model.ServiceLine;
                    _repositorycontext.ExClientServicelines.Add(serviceline1);

                    List<ExIpcustomerLocation> lstlocationNew = new List<ExIpcustomerLocation>();
                    if (model.Clienttype != null && model.Clientgeo != null)
                    {
                        if (model.Clienttype.Length > 0 && model.Clientgeo.Length > 0)
                        {
                            for (int i = 0; i < model.Clienttype.Length; i++)
                            {

                                //for (int j = 0; j < model.Clientgroup.Length; j++)
                                //{

                                    for (int p = 0; p < model.Clientgeo.Length; p++)
                                    {
                                        Random random = new Random();
                                        // Any random integer   
                                        int num = random.Next();
                                        ExIpcustomerLocation location = new ExIpcustomerLocation();
                                        location.CuIden = obj.CuIden;
                                        location.CuCode = model.CU_COMP;
                                        location.Sl = num;
                                        location.Clientgeo = model.Clientgeo[p];
                                        location.Clienttype = model.Clienttype[i];
                                        location.Startdt = DateTime.Now;
                                        location.Enddt = null;
                                        location.Clientgroup = group;
                                        location.Entrystamp = DateTime.Now;
                                        location.Status = "A";
                                        location.Userlognid = "Admin";
                                        location.Mailstatus = 1;
                                        location.LastupdatedBy = null;
                                        location.LastupdatedOn = null;
                                        lstlocationNew.Add(location); 
                                    } 

                                //} 

                            }
                        }
                        _repositorycontext.AddRange(lstlocationNew);
                    }
                    List<ExIpcustomerOther> lstCustomerNew = new List<ExIpcustomerOther>();
                    if (model.Clientgeo != null )
                    {
                        if (model.Clientgeo.Length > 0 )
                        { 
                            Random random = new Random();
                            // Any random integer   
                            int num = random.Next();
                            ExIpcustomerOther customer = new ExIpcustomerOther();
                            customer.CuIden = obj.CuIden;
                            customer.ProjId = 0;
                            customer.Sl = 1;
                            customer.Clientgeo = model.Clientgeo[0];
                            customer.PeLogn = model.AcMgrPLOGN;
                            customer.Startdt = DateTime.Now;
                            customer.Enddate = null;
                            customer.Role = "ACCMG";
                            customer.Clientgroup = group;
                            customer.Entrystamp = DateTime.Now;
                            customer.Status = "A";
                            customer.Userlognid = model.USERLOGNID;
                            customer.Userlognid = "Admin";
                            customer.Mailstatus = 1;
                            customer.LastupdatedBy = null;
                            customer.LastupdatedOn = null;
                            lstCustomerNew.Add(customer);
                            if (model.EmgrPLOGN != "NA")
                            {
                                Random randoms = new Random();
                                // Any random integer   
                                int num1 = randoms.Next();
                                ExIpcustomerOther customers = new ExIpcustomerOther();
                                customers.CuIden = obj.CuIden;
                                customers.ProjId = 0;
                                customers.Sl = 2;
                                customers.Clientgeo = model.Clientgeo[0];
                                customers.PeLogn = model.EmgrPLOGN;
                                customers.Startdt = DateTime.Now;
                                customers.Enddate = null;
                                customers.Role = "EMGR";
                                customers.Clientgroup = group;
                                customers.Entrystamp = DateTime.Now;
                                customers.Status = "A";
                                customers.Userlognid = model.USERLOGNID;
                                customers.Userlognid = "Admin";
                                customers.Mailstatus = 1;
                                customers.LastupdatedBy = null;
                                customers.LastupdatedOn = null;
                                lstCustomerNew.Add(customers);
                            }
                            _repositorycontext.AddRange(lstCustomerNew);

                        }
                    }
                    //if(model)
                    List<ExIpcustomerService> lstCust = new List<ExIpcustomerService>();
                    if (model.MainService.Length > 0)
                    {
                        for (int i = 0; i < model.MainService.Length; i++)
                        {
                            ExIpcustomerService newservice = new ExIpcustomerService();
                            newservice.CuIden = obj.CuIden;
                            newservice.Group = null;
                            newservice.MainService = model.MainService[i];
                            newservice.SubService = null;
                            newservice.Startdate = Convert.ToDateTime(model.StartDate);
                            newservice.Enddate = null;
                            newservice.Status = "A";
                            newservice.UserLogn = model.USERLOGNID;
                            newservice.Entrystamp = DateTime.Now;
                            newservice.Lastupdatedon = null;
                            newservice.Lastupdatedby = null;
                            lstCust.Add(newservice);

                        }
                        _repositorycontext.ExIpcustomerServices.AddRange(lstCust);
                    }

                    List<ExIpcustomerEngagement> lstenga = new List<ExIpcustomerEngagement>();
                    if (model.Engagement.Length > 0)
                    {
                        for (int i = 0; i < model.Engagement.Length; i++)
                        {
                            ExIpcustomerEngagement exIpcustomerEngagement = new ExIpcustomerEngagement();
                            exIpcustomerEngagement.CuIden = obj.CuIden;
                            exIpcustomerEngagement.Engagement = model.Engagement[i];
                            exIpcustomerEngagement.Startdate = Convert.ToDateTime(model.StartDate);
                            exIpcustomerEngagement.Enddate = null;
                            exIpcustomerEngagement.Status = "A";
                            exIpcustomerEngagement.UserLogn = model.USERLOGNID;
                            exIpcustomerEngagement.Entrystamp = DateTime.Now;
                            lstenga.Add(exIpcustomerEngagement);

                        }
                        _repositorycontext.ExIpcustomerEngagements.AddRange(lstenga);
                    }



                    ExCuIdenSowIsmandate sow = new ExCuIdenSowIsmandate();
                    sow.CuIden = obj.CuIden;
                    sow.Issowmandate = model.Issowmandate;
                    sow.Startdate = Convert.ToDateTime(model.StartDate);
                    sow.Enddate = null;
                    sow.Status = "A";
                    sow.Userlognid = model.USERLOGNID;
                    sow.Entrystamp = DateTime.Now;
                    sow.Updatedby = null;
                    sow.Updatedon = null;

                    _repositorycontext.ExCuIdenSowIsmandates.Add(sow);

                    _repositorycontext.SaveChanges(); 

                    response.Status = true;
                    response.Message = message;
                    response.Error = "";
                    return Ok(response);
                }

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.InnerException.ToString().Contains("Violation of UNIQUE KEY constraint 'IP_CUSTOMER_Unique_Key'") ? "Client is already present in the system. Duplicate client cannot be added" : "Something went wrong. Please try after some time"; ;
                response.Error = ex.ToString();
                return Ok(response);

            }

        }

        [HttpGet("IsClientDuplicate/{cucomp}")]
        public IActionResult IsClientDuplicate(string cucomp)
        {
            //USP_Get_List_Clients_For_MSA_SOW '26663'
            Response response = new();
            try
            {
                string message = string.Empty;
                if (String.IsNullOrEmpty(cucomp))
                {
                    response.Status = false;
                    response.Message = "pelogin required";
                    response.Data = "";
                    response.Error = "pelogin required";
                    return Ok(response);
                }
                else
                {

                    var clientdata = (from p in _repositorycontext.ExIpcustomers 
                                        where p.CuCode == cucomp  
                                        select new
                                        {
                                            CuName = p.CuName 
                                        }).Distinct().ToList();

                    response.Data = clientdata;
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

        [HttpGet("GetPeopleListForUnbilledReason/{pelogin}")]
        public IActionResult GetPeopleListForUnbilledReason(string pelogin)
        {
            Dictionary<string, object> dList = new Dictionary<string, object>();
            Response response = new();
            try
            {
                string role = string.Empty;
                Core core = new(_repositorycontext, _edmdbcontext);
                role = core.uFn_LoginCheck(pelogin);
              
                string dept = core.getdepartment(pelogin);

                
                var ExResourceassignmentstatuses = (from a in _repositorycontext.ExResourceassignmentstatuses select a).ToList();
                var ExResourceassignment = (from a in _repositorycontext.ExResourceassignments select a).ToList();
                var IPCustomerlist = (from a in _repositorycontext.IpCustomers select a).ToList();
                var ChecklistList = (from a in _repositorycontext.ExResourceassignmentChecklists select a).ToList();
                var IpPersonList = (from a in _edmdbcontext.IpPeople where a.PeQuit == null select a).ToList();
                var IPElementList = (from a in _edmdbcontext.IpElements select a).ToList();
                DateTime todaydate = DateTime.Now;
                

                if (role == "DM")
                { 
                    var emplist = (from ipex in _edmdbcontext.ExIppeople where ipex.QuitDateTemp == null&& ipex.WwPersonId !=null select ipex).ToList();
                    var ippersonlist1 = (from ipex in _edmdbcontext.IpPeople select ipex).ToList();
                    var data21 = (from a in _repositorycontext.ExResourceassignmentstatuses
                                  select a).ToList();

                    var ListBenchResource = (from a in data21
                                             join b1 in ippersonlist1.ToList() on new
                                             { User = a != null ? a.PeLogn : "" }
                                                         equals new { User = b1 != null ? b1.PeLogn : "" }

                                                                     into cp
                                             from b1 in cp.DefaultIfEmpty()
                                             where a.CuIden.ToString() == "85" && a.Enddate == null && a.Status == "B"
                                             select new
                                             {
                                                 value = b1 != null ? a.PeLogn : "",
                                                 label = b1 != null ? b1.PeName : "",
                                                 PeQuit = b1 != null ? b1.PeQuit : null
                                             }).Distinct().ToList();

                    var query4 = ListBenchResource.Where(x => x.PeQuit == null).Select(x => x.value).ToList();


                    var query2 = (from pp in _repositorycontext.ExResourcebillpercents
                                  where pp.BillpercentEnddt == null
                                  group pp by pp.PeLogn into group2
                                  select new
                                  {
                                      Pelogn = group2.Key,
                                      Billpercent = group2.Sum(c => c.Billpercent)
                                  }).ToList();

                    var query3 = query2.Where(x => x.Billpercent < 100).Select(x => x.Pelogn).ToList();

                    var finallist = query4.Union(query3); 

                    var ListBenchResourceFinal = (from a in ippersonlist1
                                                  join b1 in emplist.ToList() on new
                                                  { User = a != null ? a.PeLogn : "" }
                                                       equals new { User = b1 != null ? b1.PeLogn : "" }

                                                                   into cp
                                                  from b1 in cp.DefaultIfEmpty()
                                                  where finallist.Contains(a.PeLogn) 
                                                  select new
                                                  {
                                                      value = a.PeLogn,
                                                      label = a.PeName.ToUpper() + " (" + b1.WwPersonId + ")"
                                                  }).Distinct().ToList();

                    dList.Add("ListBenchResourceFinal", ListBenchResourceFinal);

                }
                else if (role == "EMGR")
                {
                    
                }
                else if (role == "PMO")
                {
                  

                }

                else if (role == "PL")
                { 

                }
                else
                {
                  
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

        [HttpPost("SaveUnbilledReason")]
        public IActionResult SaveUnbilledReason(SaveUnbilledReason model)
        {
            Response response = new Response();
            try
            {
                string message = string.Empty;
                Dictionary<string, object> dList = new Dictionary<string, object>();
                if (model is null)
                {
                    response.Status = false;
                    response.Message = "Atleast one record required";
                    response.Message = "Atleast one record required";
                    response.Data = "";
                    response.Error = "Atleast one record required";
                    return Ok(response);
                }
                else
                {
                     DateTime Startdate = DateTime.Now;
                    var finddata = (from p in _repositorycontext.ExIpcustomerUnbilledReasons
                                    where p.PeLogn == model.PELOGN && p.Enddate == null
                                    orderby p.Startdate descending
                                    select new
                                    {
                                        Startdate = p.Startdate
                                    }).ToList();

                    if (finddata.Count > 0)
                    {
                        Startdate = Convert.ToDateTime(finddata[0].Startdate);
                    }

                    DateTime enddate = Convert.ToDateTime(model.STARTDATE);
                    enddate = enddate.AddDays(-1);

                    if (finddata.Count > 0)
                    {
                        ExIpcustomerUnbilledReason exIpcustomerUnbilledReasons = _repositorycontext.ExIpcustomerUnbilledReasons.Where(x => x.PeLogn == model.PELOGN
                    && x.Enddate == null).FirstOrDefault();
                        exIpcustomerUnbilledReasons.Enddate = enddate;
                        exIpcustomerUnbilledReasons.EnddateStamp = DateTime.Now;
                        exIpcustomerUnbilledReasons.EnddateUserlognid = model.USERLOGNID;
                        exIpcustomerUnbilledReasons.Status = "D";
                        _repositorycontext.ExIpcustomerUnbilledReasons.Update(exIpcustomerUnbilledReasons);
                    }
                 
                    ExIpcustomerUnbilledReason exIpcustomerUnbilledReason = new ExIpcustomerUnbilledReason();
                    exIpcustomerUnbilledReason.PeLogn = model.PELOGN;
                    exIpcustomerUnbilledReason.SubreasonSl = model.SUBREASON;
                    exIpcustomerUnbilledReason.Startdate = model.STARTDATE;
                    exIpcustomerUnbilledReason.NofUnderDelLead = model.NOFUNDERDELLEAD;
                    exIpcustomerUnbilledReason.ClientNameReason = model.CLIENTNAMEREASON;
                    exIpcustomerUnbilledReason.DateOfAllocReserv = model.DATEOFALLOCRESERV;
                    exIpcustomerUnbilledReason.ExpBillStartdt = model.EXPBILLSTARTDT;
                    exIpcustomerUnbilledReason.IsDealSigned = model.ISDEALSIGNED;
                    exIpcustomerUnbilledReason.Skillset = model.SkillSet;
                    exIpcustomerUnbilledReason.Status = "A";
                    exIpcustomerUnbilledReason.Entrystamp = DateTime.Now;
                    exIpcustomerUnbilledReason.Userlognid = model.USERLOGNID; 
                    _repositorycontext.ExIpcustomerUnbilledReasons.Add(exIpcustomerUnbilledReason);

                    _repositorycontext.SaveChanges();



                }
                response.Status = true;
                response.Message = "";
                response.Data = dList;
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

        [HttpPost("sendemails")]
        public IActionResult sendemails(emailSendModelnew model)
        {
            Response response = new Response();
            try
            {
                emailSendModel sendEmail = new emailSendModel();

                sendEmail.from = model.from;
                sendEmail.to = model.to;
                sendEmail.subject = model.subject;
                sendEmail.body = model.body;
                sendEmail.isHTML = true;
                sendEmail.cc = model.cc;
                sendEmail.bcc = model.bcc;
                //sendEmail.url = "http://10.50.5.120:3021/api/sendemailv2";
                sendEmail.url = "https://internalapp.acuitykp.com/BPAS.EMAIL/api/sendemailv2";
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback +=
                                    (sender, certificate, chain, errors) =>
                                    {
                                        return true;
                                    };
                HttpClient client = new(handler);
                //var request = new HttpRequestMessage(HttpMethod.Post, "https://10.50.5.120:3023/api/sendemailv2");
                var request = new HttpRequestMessage(HttpMethod.Post, "https://internalapp.acuitykp.com/BPAS.EMAIL/api/sendemailv2");
                request.Headers.Add("Authorization", "Y2F0Y2hlciUyMHdvbmclMjBsb3ZlJTIwLm5ldA");
                request.Content = JsonContent.Create(sendEmail);
                var response1 = client.SendAsync(request).Result;
                bool success = ((int)response1.StatusCode) >= 200 && ((int)response1.StatusCode) < 300;
                response.Status = success;
                response.Message = "";
                response.Error = "";
                response.Data = "";
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                response.Error = ex.ToString();
                response.Data = "";
                return Ok(response);

            }
        }

        //[HttpGet("GetProfile")]
        //public IActionResult GetProfile()
        //{ 
        //    Response response = new();
        //    try
        //    {
        //        /// _lstParentsG
        //        string email = _httpContextAccessor.HttpContext.Request.Headers["email"];
        //        if (string.IsNullOrEmpty(email))
        //        {
        //            response.Data = string.Empty;
        //            response.Status = false;
        //            response.Message = "Request Headers doesn't have email";
        //            response.Error = string.Empty;
        //            return Ok(response);

        //        }

        //        //IPPersons iPPersons = new(_empcontext);
        //        /*UserProfile profile1 = (from p in _repositorycontext.RfpIpPeople
        //                                   //from p1 in _db.ExIppeople.Where(p1 => p1.PeLogn == p1.PeLogn).DefaultIfEmpty()
        //                               from dep in _repositorycontext.RfpExIpelements.Where(dep => dep.ElCode == p.PeDept).DefaultIfEmpty()
        //                               from cat in _repositorycontext.RfpIpCategories.Where(cat => cat.CaCode == p.PeDesg).DefaultIfEmpty()
        //                               from loc in _repositorycontext.RfpIpLocations.Where(loc => loc.IpLocn.ToString() == p.PeLocn).DefaultIfEmpty()
        //                               where p.PeQuit == null &&
        //                               //p1.WwPersonId != null && 
        //                               p.PeMail == email
        //                               select new UserProfile
        //                               {
        //                                   UserCode = p.PeLogn,
        //                                   Id = p.PeLogn,
        //                                   Username = p.PeName,
        //                                   Email = p.PeMail,
        //                                   Department = dep.ElName,
        //                                   Designation = cat.CaName,
        //                                   Location = loc.LnName,
        //                                   AvatarData = p.AvatarData,
        //                                   isWelcomeFirst = (bool)p.IsWelcome,
        //                                   joiningDate = p.PeJoin.Value.ToString("MMM dd, yyyy"),
        //                                   employeeNo = p.PeEmid,
        //                                   mangerId = p.PeLmgr

        //                               }).FirstOrDefault();*/

        //        var finddata = (from p in _edmdbcontext.IpPeople
        //                        where p.PeMail == email && p.PeQuit == null
        //                        select new
        //                        {
        //                            PeLogn = p.PeLogn
        //                        }).ToList();
        //        string emppelogn = "";
        //        if (finddata.Count > 0)
        //        {
        //            emppelogn = finddata[0].PeLogn;
        //        }

        //        List<GetRole> getRoles = new List<GetRole>();

        //        string role = string.Empty;
        //        Core core = new(_repositorycontext, _edmdbcontext);
        //        role = core.uFn_LoginCheck(emppelogn);

        //        UserProfile profile = (from p in _edmdbcontext.IpPeople 
        //                               from dep in _edmdbcontext.ExIpelements.Where(dep => dep.ElCode == p.PeDept).DefaultIfEmpty()
        //                               from cat in _edmdbcontext.IpCategories.Where(cat => cat.CaCode == p.PeDesg).DefaultIfEmpty()
        //                               from loc in _edmdbcontext.IpLocations.Where(loc => loc.IpLocn.ToString() == p.PeLocn).DefaultIfEmpty()
        //                               where p.PeQuit == null &&
        //                               //p1.WwPersonId != null && 
        //                               p.PeMail == email
        //                               select new UserProfile
        //                               {
        //                                   UserCode = p.PeLogn,
        //                                   Id = p.PeLogn,
        //                                   Username = p.PeName,
        //                                   Email = p.PeMail,
        //                                   Department = dep.ElName,
        //                                   Designation = cat.CaName,
        //                                   Location = loc.LnName,
        //                                   AvatarData = "",
        //                                   isWelcomeFirst = true,
        //                                   joiningDate = p.PeJoin.Value.ToString("MMM dd, yyyy"),
        //                                   employeeNo = p.PeEmid,
        //                                   mangerId = p.PeLmgr,
        //                                   deparatmentcode = p.PeDept,
        //                                   personrole= role

        //                               }).FirstOrDefault();
        //        //iPPersons.GetProfile(email);
        //        if (profile is null)
        //        {
        //            response.Data = email;
        //            response.Status = false;
        //            response.Message = "No data found for given email";
        //            response.Error = string.Empty;
        //            return Ok(response);
        //        }
        //        profile.isWelcome = profile.isWelcomeFirst;
        //        var name = (from a in _edmdbcontext.IpPeople where a.PeLogn == profile.mangerId select a).ToList();
        //        if (name.Count > 0)
        //        {
        //            profile.managerName = name[0].PeName;
        //        }

        //        profile.Rights = null; 

        //        if (profile.Rights is null)
        //        {
        //            profile.Windows = null;
        //            profile.RoleName = null;
        //            profile.RoleId = 0;
        //            profile.Sections = null;
        //            profile.Screens = null;
        //        }

              

               


        //        //getRoles.Add(new GetRole("Role", role));


        //        //Dictionary<string, object> dList = new Dictionary<string, object>();
        //        //dList.Add("profile", profile);
        //        //dList.Add("getRoles", getRoles);

        //        //response.Data = profile;
        //        response.Data = profile;
        //        response.Status = true;
        //        response.Message = "SUCCESS";
        //        response.Error = string.Empty;
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = false;
        //        response.Message = ex.Message;
        //        response.Error = ex.ToString();
        //        return Ok(response);
        //    }
        //}

        [HttpPost("SaveIndustriclassificationMaster")]
        public IActionResult SaveIndustriclassificationMaster(SaveIndustriclassificationMaster model)
        {
            Response response = new Response();
            try
            {
                string message = string.Empty; 
                if (model is null)
                {
                    response.Status = false;
                    response.Message = "Atleast one record required";
                    response.Message = "Atleast one record required";
                    response.Data = "";
                    response.Error = "Atleast one record required";
                    return Ok(response);
                }
                else
                {
                    int count = 0;
                    count = (from p in _repositorycontext.ExIndustoryClassificationMasters
                             where p.Classification == model.industryclassification && p.Status == "A"
                             select new
                             {
                                 p.ClassificationId

                             }).Count();
                    if (count == 0)
                    {

                        ExIndustoryClassificationMaster exIndustoryClassificationMaster = new ExIndustoryClassificationMaster();
                        exIndustoryClassificationMaster.Classification = model.industryclassification;
                        exIndustoryClassificationMaster.Entrystamp = DateTime.Now;
                        exIndustoryClassificationMaster.EntryBy = model.USERLOGNID;
                        exIndustoryClassificationMaster.Status = "A";
                        _repositorycontext.ExIndustoryClassificationMasters.Add(exIndustoryClassificationMaster);
                        _repositorycontext.SaveChanges();

                        var industoryclassification = (from p in _repositorycontext.ExIndustoryClassificationMasters
                                                       where p.Status == "A"
                                                       select new
                                                       {
                                                           value = p.ClassificationId,
                                                           label = p.Classification
                                                       }).ToList();
                        response.Status = true;
                        response.Message = "Update Sucessfully";
                        response.Data = industoryclassification;
                        response.Error = "";
                        return Ok(response);
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "Data already available";
                        response.Data = "";
                        response.Error = "Data already available";
                        return Ok(response);
                    }
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


        [HttpPost("SaveclienttypeMaster")]
        public IActionResult SaveclienttypeMaster(SaveclienttypeMaster model)
        {
            Response response = new Response();
            try
            {
                string message = string.Empty;
                if (model is null)
                {
                    response.Status = false;
                    response.Message = "Atleast one record required";
                    response.Message = "Atleast one record required";
                    response.Data = "";
                    response.Error = "Atleast one record required";
                    return Ok(response);
                }
                else
                {

                    int count = 0;
                    count = (from p in _edmdbcontext.IpElements
                             where p.ElName == model.clienttype && p.CaCode.ToLower() == "clnt"
                             select new
                             {
                                 p.ElCode

                             }).Count();
                    if (count == 0)
                    {


                        int maxid = 0;

                        maxid = (from a in _edmdbcontext.IpElements
                                 where a.ElCode.StartsWith("1")
                                 select a).Max(a => Convert.ToInt16(a.ElCode));

                        maxid = maxid + 1;

                        IpElement ipElement = new IpElement();
                        ipElement.ElCode = maxid.ToString();
                        ipElement.CaCode = "Clnt";
                        ipElement.ElName = model.clienttype;
                        ipElement.ElArch = "0";
                        _edmdbcontext.IpElements.Add(ipElement);
                        _edmdbcontext.SaveChanges();

                        var ClientTypemaster = (from p in _edmdbcontext.IpElements
                                                where p.CaCode == "Clnt"
                                                orderby p.ElName
                                                select new
                                                {
                                                    value = p.ElCode,
                                                    label = p.ElName.ToUpper()
                                                }).Distinct().ToList();

                        response.Status = true;
                        response.Message = "Update Sucessfully";
                        response.Data = ClientTypemaster;
                        response.Error = "";
                        return Ok(response);
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "Data already available";
                        response.Data = "";
                        response.Error = "Data already available";
                        return Ok(response);
                    }

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

        [HttpPost("SavetypeofservicesMaster")]
        public IActionResult SavetypeofservicesMaster(SavetypeofservicesMaster model)
        {
            Response response = new Response();
            try
            {
                string message = string.Empty;
                if (model is null)
                {
                    response.Status = false;
                    response.Message = "Atleast one record required";
                    response.Message = "Atleast one record required";
                    response.Data = "";
                    response.Error = "Atleast one record required";
                    return Ok(response);
                }
                else
                {
                    int count = 0;
                    count = (from p in _repositorycontext.ExGroupMainservices
                             where p.Maingroupdesc == model.typeofservices && p.Status == "A"
                             select new
                             {
                                 p.Maingroupdesc

                             }).Count();

                    if (count == 0)
                    {

                        ExGroupMainservice exGroupMainservice = new ExGroupMainservice();
                        exGroupMainservice.Maingroupdesc = model.typeofservices;
                        exGroupMainservice.Entrystamp = DateTime.Now;
                        exGroupMainservice.Userlognid = model.USERLOGNID;
                        exGroupMainservice.Status = "A";
                        _repositorycontext.ExGroupMainservices.Add(exGroupMainservice);
                        _repositorycontext.SaveChanges();

                        var Servicemaster = (from p in _repositorycontext.ExGroupMainservices
                                             orderby p.Maingroupdesc
                                             select new
                                             {
                                                 value = p.Maingroupid,
                                                 label = p.Maingroupdesc.ToUpper()
                                             }).Distinct().ToList();

                        response.Status = true;
                        response.Message = "Update Sucessfully";
                        response.Data = Servicemaster;
                        response.Error = "";
                        return Ok(response);
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "Data already available";
                        response.Data = "";
                        response.Error = "Data already available";
                        return Ok(response);
                    }

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

        [HttpPost("SaveLocationMaster")]
        public IActionResult SaveLocationMaster(SaveLocationMaster model)
        {
            Response response = new Response();
            try
            {
                string message = string.Empty;
                if (model is null)
                {
                    response.Status = false;
                    response.Message = "Atleast one record required";
                    response.Message = "Atleast one record required";
                    response.Data = "";
                    response.Error = "Atleast one record required";
                    return Ok(response);
                }
                else
                {
                    int count = 0;
                    count = (from p in _edmdbcontext.IpElements
                             where p.ElName == model.location && p.CaCode.ToLower() == "geo"
                             select new
                             {
                                 p.ElCode

                             }).Count();
                    if (count == 0)
                    {

                        int maxid = 0;

                        maxid = (from a in _edmdbcontext.IpElements
                                 where a.ElCode.StartsWith("1")
                                 select a).Max(a => Convert.ToInt16(a.ElCode));

                        maxid = maxid + 1;

                        IpElement ipElement = new IpElement();
                        ipElement.ElCode = maxid.ToString();
                        ipElement.CaCode = "GEO";
                        ipElement.ElName = model.location;
                        ipElement.ElArch = "0";
                        _edmdbcontext.IpElements.Add(ipElement);
                        _edmdbcontext.SaveChanges();

                        var ClientLocationmaster = (from p in _edmdbcontext.IpElements
                                                    where p.CaCode == "Geo"
                                                    orderby p.ElName
                                                    select new
                                                    {
                                                        value = p.ElCode,
                                                        label = p.ElName.ToUpper()
                                                    }).Distinct().ToList();

                        response.Status = true;
                        response.Message = "Update Sucessfully";
                        response.Data = ClientLocationmaster;
                        response.Error = "";
                        return Ok(response);
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "Data already available";
                        response.Data = "";
                        response.Error = "Data already available";
                        return Ok(response);
                    }

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

        [HttpPost("UploadFile")]
        //public IActionResult UploadFile(UploadSOW model, List<IFormFile> postedFiles /*FileInputModel File*/)
        public IActionResult UploadFile(List<IFormFile> postedFiles, string savedfilename /*FileInputModel File*/)
        {
            Response response = new();
            try
            {

                if (postedFiles is null)
                {
                    response.Status = false;
                    response.Message = "Kindly Attach File";
                    response.Data = "";
                    response.Error = "Kindly Attach File";
                    return Ok(response);
                }
                if (postedFiles != null)
                {
                    //string wwwPath = this.Environment.WebRootPath;
                    //string contentPath = this.Environment.ContentRootPath;

                    //string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                    string path = Path.Combine("SOWFiles");

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    List<string> uploadedFiles = new List<string>();
                    foreach (IFormFile postedFile in postedFiles)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        using (FileStream stream = new FileStream(Path.Combine(path, savedfilename), FileMode.Create))
                        {
                            postedFile.CopyTo(stream);
                            uploadedFiles.Add(fileName);
                        }
                    }

                    response.Data = "";
                    response.Status = true;
                    response.Message = "File Upload Sucessfully";
                    response.Error = "";
                    return Ok(response);
                }
                else
                {
                    response.Data = "";
                    response.Status = false;
                    response.Message = "There is some issue in saving file.";
                    response.Error = "";
                    return Ok(response);
                }




                //string path = Server.MapPath("~/Uploads/");
                //var FolderPath = "SOWFiles";


                //postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));

                //SqlConnection SqlConIPlan = new SqlConnection("Data Source=10.50.5.155;Initial Catalog=AKP_CM;user id=sa; pwd=moodys@1234;");
                //if (SqlConIPlan.State == ConnectionState.Closed) SqlConIPlan.Open();
                //SqlCommand SqlCmdInsertAttachDetail = new SqlCommand();
                //SqlCmdInsertAttachDetail.CommandType = CommandType.StoredProcedure;
                //SqlCmdInsertAttachDetail.Connection = SqlConIPlan;
                //SqlCmdInsertAttachDetail.CommandText = "USP_Insert_SowNumber_React";
                //SqlCmdInsertAttachDetail.Parameters.AddWithValue("@Cu_Iden", model.Cu_Iden);
                //SqlCmdInsertAttachDetail.Parameters.AddWithValue("@SowNumber", model.SowNumber);
                //SqlCmdInsertAttachDetail.Parameters.AddWithValue("@SOWDate", model.SOWDate);
                //SqlCmdInsertAttachDetail.Parameters.AddWithValue("@TotalResource", model.TotalResource);
                //SqlCmdInsertAttachDetail.Parameters.AddWithValue("@TotalBilledResource", model.TotalBilledResource);
                //SqlCmdInsertAttachDetail.Parameters.AddWithValue("@FileName", model.FileName);
                //SqlCmdInsertAttachDetail.Parameters.AddWithValue("@FilePath", model.FilePath);
                //SqlCmdInsertAttachDetail.Parameters.AddWithValue("@UserLognID", model.UserLognID);
                //SqlCmdInsertAttachDetail.Parameters.AddWithValue("@SOWRenewDate", model.SOWRenewDate);
                //SqlCmdInsertAttachDetail.Parameters.AddWithValue("@MetaData", model.MetaData);
                //SqlCmdInsertAttachDetail.Parameters.AddWithValue("@serviceline", model.serviceline);
                //SqlCmdInsertAttachDetail.Parameters.AddWithValue("@bgcCheck", model.bgcCheck);
                //SqlCmdInsertAttachDetail.Parameters.AddWithValue("@drugCheck", model.drugCheck);
                //SqlCmdInsertAttachDetail.Parameters.AddWithValue("@identityCheck", model.identityCheck);
                //SqlCmdInsertAttachDetail.Parameters.AddWithValue("@MSANumber", model.MSANumber);
                //SqlCmdInsertAttachDetail.Parameters.AddWithValue("@MSADate", model.MSADate);
                //SqlCmdInsertAttachDetail.Parameters.AddWithValue("@MSAFileName", model.MSAFileName);
                //SqlCmdInsertAttachDetail.Parameters.AddWithValue("@MSAFilePath", model.MSAFilePath);
                //SqlDataAdapter da = new SqlDataAdapter(SqlCmdInsertAttachDetail);

                //DataSet ds = new DataSet();

                //da.Fill(ds);

                //if (SqlConIPlan.State == ConnectionState.Open) SqlConIPlan.Close();

                //response.Data = "";
                //response.Status = true;
                //response.Message = "File Upload Sucessfully";
                //response.Error = "";
                //return Ok(response);

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                response.Error = ex.ToString();
                return Ok(response);
            }

        }

        [HttpGet("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string filename)
        {
            if (filename == null)
            { return Content("filename not present"); }

            //string path = Path.Combine("IncidentAttachments");
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "SOWFiles", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(filename).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();

            return File(memory, mimeType, Path.GetFileName(path));
            //if (filename == null)
            //    return Content("filename not present");

            //string path = Path.Combine("SOWFiles");
            ////var path = Path.Combine(
            ////               Directory.GetCurrentDirectory(),
            ////               "wwwroot", filename);

            //var memory = new MemoryStream();
            //using (var stream = new FileStream(path, FileMode.Open))
            //{
            //    await stream.CopyToAsync(memory);
            //}
            //memory.Position = 0;
            //return File(memory, "ssss", Path.GetFileName(path));
        }


        //[HttpPost("GetProfileByAD")] 
        //public IActionResult GetProfileByAD(Session session)
        //{
        //    Response response = new();
        //    try
        //    {
        //        var text = session.Text;
        //        if (text is null)
        //        {
        //            response.Data = string.Empty;
        //            response.Status = false;
        //            response.Message = "Windows login username required!";
        //            response.Error = string.Empty;
        //            return Ok(response);
        //        }
        //        var userdata = JsonConvert.DeserializeObject<UserData>(EncryptionHelper.Decrypt(text));
        //        if (userdata.Expiry < DateTimeOffset.Now)
        //        {
        //            response.Data = string.Empty;
        //            response.Status = false;
        //            response.Message = "Session expired";
        //            response.Error = string.Empty;
        //            return Ok(response);
        //        }
        //        else if (userdata.IsAuthenticated == false)
        //        {
        //            response.Data = string.Empty;
        //            response.Status = false;
        //            response.Message = "Windows login issue. Please try again later";
        //            response.Error = string.Empty;
        //            return Ok(response);
        //        }
        //        string windowsid = userdata.Name.Contains("CACORP\\") ? userdata.Name.Replace("CACORP\\", "") : userdata.Name;
        //        var data = _edmdbcontext.AmbaIplanmaps.SingleOrDefault(x => x.Activedirectoryusername == windowsid);
        //        if (data == null)
        //        {
        //            response.Data = string.Empty;
        //            response.Status = false;
        //            response.Message = "Windows login username not found. Please contact administrator..!";
        //            response.Error = string.Empty;
        //            return Ok(response);
        //        }

        //        response.Data = data;
        //        response.Status = true;
        //        response.Message = "SUCCESS";
        //        response.Error = string.Empty;
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = false;
        //        response.Message = ex.Message;
        //        response.Error = ex.ToString();
        //        return Ok(response);
        //    }
        //} 






        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
