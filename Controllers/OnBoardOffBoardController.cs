using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceRequestService.Data;
using ResourceRequestService.Helpers;
using ResourceRequestService.Models.Repository;
using ResourceRequestService.Models.EMPDATA;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections;

namespace ResourceRequestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class OnBoardOffBoardController : Controller
    {
       
            private readonly RepositoryDbContext _repositorycontext;
            private readonly EDMDbContext _edmdbcontext;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly IMapper _mapper;
            private const string extraEmail = "ashwini.holla-non-empl@acuitykp.com"; 

        public IConfiguration Configuration { get; }

        public OnBoardOffBoardController(IHttpContextAccessor httpContextAccessor, IMapper mapper, RepositoryDbContext repositorycontext, EDMDbContext edmrepositorycontext,IConfiguration configuration)
            {
                _httpContextAccessor = httpContextAccessor; 
                _mapper = mapper;
                _repositorycontext = repositorycontext;
                _edmdbcontext = edmrepositorycontext;
                Configuration = configuration;
        }

        [HttpGet("GetPeopleListForOffboard/{pelogin}/{cuiden}")]
        public IActionResult GetPeopleListForOffboard(string pelogin, string cuiden)
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
                    //string[] roleList = { "ADMIN", "EMGR", "CDH" };
                    var ExResourceassignmentstatuses = (from a in _repositorycontext.ExResourceassignmentstatuses select a).ToList();

                    if (role == "DM")
                    {
                        int?[] TypeList = { 1, 2 };
                    //var exreportingmanager = (from a in ExResourceassignmentstatuses
                    //                          join b in _edmdbcontext.ExReportingmanagers on
                    //                          new
                    //                          //{ X1 = a.CuIden ?? default(int), X3 = a.KickOff ?? default(DateTime) }
                    //                          { X1 = a.CuIden , X3 = a.KickOff  }
                    //                                equals new { X1 = b.CuIden ?? default(int), X3 = b.KickOff ?? default(DateTime) }
                    //                          where b.Mngrlognid == pelogin && b.Enddate is null
                    //                          && TypeList.Contains(b.Type) && b.CuIden != 85 && a.Enddate == null && a.CuIden.ToString() == cuiden
                    //                          select a).Distinct().ToList();

                    //string[] VaLognIdList = new string[exreportingmanager.Count];

                    //if (exreportingmanager.Count > 0)
                    //{
                    //    for (int i = 0; i < exreportingmanager.Count; i++)
                    //    {
                    //        VaLognIdList[i] = exreportingmanager[i].PeLogn;
                    //    }
                    //}

                    var deptList = (from a in _edmdbcontext.IpPeople
                                           where a.PeLogn ==pelogin  
                                           select a.PeDept).ToList();


                    var result = (from a in ExResourceassignmentstatuses
                                      join b in _edmdbcontext.IpPeople on a.PeLogn equals b.PeLogn into sb
                                      from b in sb.DefaultIfEmpty()
                                      join c in _edmdbcontext.ExIppeople on a.PeLogn equals c.PeLogn into sc
                                      from c in sc.DefaultIfEmpty()
                                      where a.Enddate == null && a.CuIden != 85 && a.OffboardStatus == null && a.CuIden.ToString() == cuiden
                                      && a.ApproveStatus == "A" /*&& VaLognIdList.Contains(a.PeLogn)*/ && deptList.Contains(b.PeDept) 
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
                                      join b in _edmdbcontext.IpPeople on a.PeLogn equals b.PeLogn into sb
                                      from b in sb.DefaultIfEmpty()
                                      join c in _edmdbcontext.ExIppeople on a.PeLogn equals c.PeLogn into sc
                                      from c in sc.DefaultIfEmpty()
                                      where a.Enddate == null && a.CuIden != 85 && a.OffboardStatus == null && a.CuIden.ToString() == cuiden
                                      && a.ApproveStatus == "A" && serviceLine.Contains(b != null ? b.PeDept : "")
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
                                      join b in _edmdbcontext.IpPeople on a.PeLogn equals b.PeLogn into sb
                                      from b in sb.DefaultIfEmpty()
                                      join c in _edmdbcontext.ExIppeople on a.PeLogn equals c.PeLogn into sc
                                      from c in sc.DefaultIfEmpty()
                                      where a.Enddate == null && a.CuIden != 85 && a.OffboardStatus == null && a.CuIden.ToString() == cuiden
                                      && a.ApproveStatus == "A" && serviceLine.Contains(b != null ? b.PeDept : "")
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
                        //var subquery = (from a in _repositorycontext.ExIpcustomerOthers where a.PeLogn == pelogin && a.Enddate == null && a.Status == "A" && a.Role == "EMGR" select a).ToList();
                        //int?[] CuIden = new int?[subquery.Count + 1];
                        //if (subquery.Count > 0)
                        //{
                        //    for (int i = 0; i < subquery.Count; i++)
                        //    {
                        //        CuIden[i] = subquery[i].CuIden;
                        //    }

                        //}

                        var result = (from a in ExResourceassignmentstatuses
                                      join b in _edmdbcontext.IpPeople on a.PeLogn equals b.PeLogn into sb
                                      from b in sb.DefaultIfEmpty()
                                      join c in _edmdbcontext.ExIppeople on a.PeLogn equals c.PeLogn into sc
                                      from c in sc.DefaultIfEmpty()
                                      where a.Enddate == null && a.CuIden != 85 && a.OffboardStatus == null && a.CuIden.ToString() == cuiden
                                      && a.ApproveStatus == "A" /*&& CuIden.Contains(a.CuIden)*/
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
                                      join b in _edmdbcontext.IpPeople on a.PeLogn equals b.PeLogn into sb
                                      from b in sb.DefaultIfEmpty()
                                      join c in _edmdbcontext.ExIppeople on a.PeLogn equals c.PeLogn into sc
                                      from c in sc.DefaultIfEmpty()
                                      where a.Enddate == null && a.CuIden != 85 && a.OffboardStatus == null && a.CuIden.ToString() == cuiden
                                      && a.ApproveStatus == "A" && b != null 
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

        [HttpGet("GetPersonType/{pelogn}")]
        public IActionResult GetPersonType(string pelogn)
        { 
            Response response = new();
            try
            {
                {

                    var ParameterConfigurations = (from p in _edmdbcontext.ExIppeople
                                                   where p.PeLogn == pelogn
                                                   select new
                                                   {
                                                       PersonType = p.PersonType

                                                   }).Distinct().ToList();

                    response.Data = ParameterConfigurations;
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

        [HttpPost("OffboardResource")]
        public IActionResult OffboardResource(ResourceOffboard model)
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


                    DateTime LockDate = DateTime.Now;
                    var LockDate1 = (from p in _repositorycontext.ExTransactionApprovals
                                     orderby p.Id descending
                                     select new
                                     {
                                         p.LockedOn

                                     }).ToList();
                    if (LockDate1.Count > 0)
                    {

                        LockDate = Convert.ToDateTime(LockDate1[0].LockedOn);
                    }


                    if (LockDate >= Convert.ToDateTime(model.OffboardDate))
                    {
                        response.Status = true;
                        response.Message = "OffBoard Date cannot less than or equal to lock date "  + LockDate.ToString("yyyy-MM-dd");
                        response.Data = "OffBoard Date cannot less than or equal to lock date " + LockDate.ToString("yyyy-MM-dd");
                        response.Error = "";
                        return Ok(response); 
                    }
                    else if (model.OffboardReason == "Replacement" && model.ReplaceWith.ToLower() == "n/a" && model.ReplaceWith == null && model.ReplaceWith == "" && model.ReplaceWith == "null")
                    {
                        response.Status = true;
                        response.Message = "Kindly select replacing person.";
                        response.Data = "Kindly select replacing person.";
                        response.Error = "";
                        return Ok(response);
                    }
                    else
                    {

                        DateTime BenchStart = DateTime.Now; ;
                        DateTime PeJoin = DateTime.Now;

                        string[] reasonLIst = { "BNA", "NBST5", "BILLING" };
                        string[] reasonList2 = { "BNA", "AB", "NBA" };
                        string[] roleList = { "Admin1", "NONE1" };
                        string[] reasonList3 = { "BNA", "AB", "NBST5", "NBST2" };
                        string[] reasonList4 = { "BNA", "AB", "NBST5" };


                        var resource = _repositorycontext.ExResourceassignments.FirstOrDefault(x => x.PeLogn == model.Logn && x.ApproveStatus == "A"
                        && x.KickOffDate == Convert.ToDateTime(model.KickOffDate) && x.OnOff == 0 && x.CuIden == Convert.ToInt16(model.CuIden));

                        var BillPercentResource = _repositorycontext.ExResourcebillpercents.FirstOrDefault(x => x.PeLogn == model.Logn
                        && x.KickOff == Convert.ToDateTime(model.KickOffDate) && x.CuIden == Convert.ToInt16(model.CuIden) && x.BillpercentEnddt ==null);

                        int noofactiveaccount = 0;


                        noofactiveaccount = (from a in _repositorycontext.ExResourceassignmentstatuses
                                             where a.PeLogn == model.Logn && a.CuIden != Convert.ToInt16(model.CuIden) && a.Enddate == null
                                             select a.CuIden).Count();



                        ExResourceassignment Exresource = new ExResourceassignment();
                        Exresource.PeLmgr = resource.PeLmgr;
                        Exresource.PeLogn = model.Logn;
                        Exresource.RepValognid = model.ReplaceWith;
                        Exresource.CuIden = Convert.ToInt32(model.CuIden);
                        Exresource.ProjId = resource.ProjId;
                        Exresource.CuType = resource.CuType;
                        Exresource.IpLocn = resource.IpLocn;
                        Exresource.Groups = resource.Groups;
                        Exresource.AssignType = resource.AssignType;
                        Exresource.Reason = model.Reason;
                        Exresource.ReasonDetail = null;
                        Exresource.Jobrefno = null;
                        Exresource.ReqId = null;
                        Exresource.ResgclntComment = null;
                        Exresource.ItComment = null;
                        Exresource.AdminComment = null;
                        Exresource.DateOfSelectionOrMove = model.OffboardDate == null ? null : Convert.ToDateTime(model.OffboardDate);
                        Exresource.KickOffDate = model.KickOffDate == null ? null : Convert.ToDateTime(model.KickOffDate);
                        Exresource.BillDate = reasonLIst.Contains(model.Reason) ? Convert.ToDateTime(model.OffboardDate) : null;
                        Exresource.BillingStatus = null;
                        Exresource.BillingDetails = null;
                        Exresource.ComplComment = model.CmplComments;
                        Exresource.HrRdAccFinComment = null;
                        Exresource.OnOff = 1;
                        Exresource.Entrystamp = DateTime.Now;
                        Exresource.Userlognid = model.WhoUpdate;
                        Exresource.Status = resource.Status;
                        Exresource.ApproveStatus = (reasonLIst.Contains(model.Reason) && model.OffboardReason != "Replacement" && (model.ReplaceWith.ToLower() == "n/a" || model.ReplaceWith == null || model.ReplaceWith == "" || model.ReplaceWith == "null")) ? "P" : "A";
                        Exresource.BcatId = null;
                        Exresource.BillingRate = null;
                        Exresource.Userapprovestatus = "A";
                        Exresource.FinanceStatus = (reasonLIst.Contains(model.Reason) && model.OffboardReason != "Replacement" && (model.ReplaceWith.ToLower() == "n/a" || model.ReplaceWith == null || model.ReplaceWith == "" || model.ReplaceWith == "null")) ? "P" : "A";
                        Exresource.FinanceComments = null;
                        Exresource.FinanceEntrystamp = null;
                        Exresource.FinanceLognid = null;
                        Exresource.ManagerComments = model.OffboardComments;
                        Exresource.ManagerEntrystamp = DateTime.Now;
                        Exresource.ManagerLognid = model.WhoUpdate;
                        Exresource.ComplianceComments = null;
                        Exresource.ComplianceStatus = "A";
                        Exresource.ComplianceEntrystamp = null;
                        Exresource.ComplianceLognid = null;

                        Exresource.ItCommentsOnapprove = null;
                        //Exresource.ItStatusOnapprove = "P";
                        Exresource.ItStatusOnapprove = (model.itFolderAccess.ToLower() == "na" && model.itEmailAccess.ToLower() == "na") ? "A" : "P";
                        Exresource.ItStatusEntrystamp = null;
                        Exresource.ItStatusLognid = null;
                        Exresource.AdminCommentsOnapprove = null;
                        // Need to work for seat Layout
                        Exresource.AdminStatusOnapprove = "P";
                        Exresource.AdminStatusEntrystamp = null;
                        Exresource.AdminStatusLognid = null;
                        Exresource.Supr = resource.Supr;
                        Exresource.Ndasigneddate = null;
                        Exresource.Documentation = null;
                        Exresource.ManagerUpdate = null;
                        Exresource.OrgnRole = null;
                        Exresource.TdaComments = null;
                        Exresource.CheadTypeoflead = null;
                        Exresource.CheadUpdatedbychead = null;
                        Exresource.CheadEntrystamp = null;
                        Exresource.InvoiceNo = null;
                        Exresource.BillingRole = null;
                        Exresource.Allocation = resource.Allocation;
                        Exresource.Sl = resource.Sl;
                        Exresource.ConversionComplStatus = null;
                        Exresource.Billpercent = resource.Billpercent;
                        Exresource.Sow = resource.Sow;
                        Exresource.OnboardComments = null;
                        Exresource.DmKickOffDate = null;
                        Exresource.BillEntity = resource.BillEntity;
                        _repositorycontext.ExResourceassignments.Add(Exresource);

                        if (reasonLIst.Contains(model.Reason) && model.OffboardReason != "Replacement" && (model.ReplaceWith.ToLower() == "n/a" || model.ReplaceWith == null || model.ReplaceWith == "" || model.ReplaceWith == "null"))
                        {
                            //Update EX_RESOURCEASSIGNMENTSTATUS
                            ExResourceassignmentstatus exResourceassignmentstatus = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.PeLogn == model.Logn
                            && x.Enddate == null && x.CuIden == Convert.ToInt16(model.CuIden) && x.KickOff == Convert.ToDateTime(model.KickOffDate)).FirstOrDefault();
                            exResourceassignmentstatus.OffboardStamp = DateTime.Now;
                            exResourceassignmentstatus.OffboardUserlognid = model.WhoUpdate;
                            exResourceassignmentstatus.OffboardStatus = "P";
                            exResourceassignmentstatus.OffboardReason = model.OffboardReason;
                            _repositorycontext.ExResourceassignmentstatuses.Update(exResourceassignmentstatus);
                        }
                        else
                        {
                            //Update EX_RESOURCEASSIGNMENTSTATUS
                            ExResourceassignmentstatus exResourceassignmentstatus = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.PeLogn == model.Logn
                            && x.Enddate == null && x.CuIden == Convert.ToInt16(model.CuIden) && x.KickOff == Convert.ToDateTime(model.KickOffDate)).FirstOrDefault();
                            exResourceassignmentstatus.Enddate = Convert.ToDateTime(model.OffboardDate);
                            exResourceassignmentstatus.OffboardStamp = DateTime.Now;
                            exResourceassignmentstatus.OffboardUserlognid = model.WhoUpdate;
                            exResourceassignmentstatus.OffboardStatus = "A";
                            exResourceassignmentstatus.DateOfMove = Convert.ToDateTime(model.OffboardDate);
                            exResourceassignmentstatus.OffboardReason = model.OffboardReason;
                            _repositorycontext.ExResourceassignmentstatuses.Update(exResourceassignmentstatus);

                            //Update EX_RESOURCEALLOCATION
                            ExResourceallocation exresourceallocation = _repositorycontext.ExResourceallocations.Where(x => x.PeLogn == model.Logn
                            && x.AllocEnddate == null && x.CuIden == Convert.ToInt16(model.CuIden) && x.KickOff == Convert.ToDateTime(model.KickOffDate)).FirstOrDefault();
                            exresourceallocation.AllocEnddate = Convert.ToDateTime(model.OffboardDate);
                            exresourceallocation.Status = "D";
                            exresourceallocation.EnddateStamp = DateTime.Now;
                            exresourceallocation.EnddateUserlognid = model.WhoUpdate;
                            exresourceallocation.DateOfMove = Convert.ToDateTime(model.OffboardDate);
                            _repositorycontext.ExResourceallocations.Update(exresourceallocation);

                            //Update EX_IPCUSTOMER_GROUP
                            ExIpcustomerGroup exipcustomergroup = _repositorycontext.ExIpcustomerGroups.Where(x => x.PeLogn == model.Logn
                            && x.GroupEnddate == null && x.CuIden == Convert.ToInt16(model.CuIden) && x.KickOff == Convert.ToDateTime(model.KickOffDate)).FirstOrDefault();
                            exipcustomergroup.GroupEnddate = Convert.ToDateTime(model.OffboardDate);
                            exipcustomergroup.Status = "D";
                            exipcustomergroup.EnddateStamp = DateTime.Now;
                            exipcustomergroup.EnddateUserlognid = model.WhoUpdate;
                            exipcustomergroup.DateOfMove = Convert.ToDateTime(model.OffboardDate);
                            _repositorycontext.ExIpcustomerGroups.Update(exipcustomergroup);

                            //Update EX_IPCUSTOMER_ROLE
                            ExIpcustomerRole exipcustomerrole = _repositorycontext.ExIpcustomerRoles.Where(x => x.PeLogn == model.Logn
                            && x.RoleEnddate == null && x.CuIden == Convert.ToInt16(model.CuIden) && x.KickOff == Convert.ToDateTime(model.KickOffDate)).FirstOrDefault();
                            exipcustomerrole.RoleEnddate = Convert.ToDateTime(model.OffboardDate);
                            exipcustomerrole.Status = "D";
                            exipcustomerrole.EnddateStamp = DateTime.Now;
                            exipcustomerrole.EnddateUserlognid = model.WhoUpdate;
                            exipcustomerrole.DateOfMove = Convert.ToDateTime(model.OffboardDate);
                            _repositorycontext.ExIpcustomerRoles.Update(exipcustomerrole);

                            //Update Ex_IPCUSTOMER_TEAM
                            ExIpcustomerTeam exipcustomerteam = _repositorycontext.ExIpcustomerTeams.Where(x => x.PeLogn == model.Logn
                            && x.CuIden == Convert.ToInt16(model.CuIden) && x.KickOff == Convert.ToDateTime(model.KickOffDate)).FirstOrDefault();
                            exipcustomerteam.Status = "D";
                            exipcustomerteam.EnddateEntrystamp = DateTime.Now;
                            exipcustomerteam.EnddateUserlognid = model.WhoUpdate;
                            exipcustomerteam.DateOfMove = Convert.ToDateTime(model.OffboardDate);
                            _repositorycontext.ExIpcustomerTeams.Update(exipcustomerteam);

                            //Update EX_IPCUSTOMER_GEO
                            ExIpcustomerGeo exipcustomergeo = _repositorycontext.ExIpcustomerGeos.Where(x => x.PeLogn == model.Logn
                            && x.GeoEnddate == null && x.CuIden == Convert.ToInt16(model.CuIden) && x.KickOff == Convert.ToDateTime(model.KickOffDate)).FirstOrDefault();
                            exipcustomergeo.GeoEnddate = Convert.ToDateTime(model.OffboardDate);
                            exipcustomergeo.Status = "D";
                            exipcustomergeo.DateOfMove = Convert.ToDateTime(model.OffboardDate);
                            _repositorycontext.ExIpcustomerGeos.Update(exipcustomergeo);

                            //Update EX_IPCUSTOMER_SOW

                            var findipcustomersow = (from p in _repositorycontext.ExIpcustomerSows
                                                     where p.PeLogn == model.Logn && p.SowEnddate == null && p.CuIden == Convert.ToInt16(model.CuIden) && p.KickOff == Convert.ToDateTime(model.KickOffDate)
                                                     select new
                                                     {
                                                         Status = p.Status,

                                                     }).ToList();

                            if (findipcustomersow.Count > 0)
                            {
                                ExIpcustomerSow exipcustomersow = _repositorycontext.ExIpcustomerSows.Where(x => x.PeLogn == model.Logn
                           && x.SowEnddate == null && x.CuIden == Convert.ToInt16(model.CuIden) && x.KickOff == Convert.ToDateTime(model.KickOffDate)).FirstOrDefault();
                                exipcustomersow.SowEnddate = Convert.ToDateTime(model.OffboardDate);
                                exipcustomersow.Status = "D";
                                exipcustomersow.EnddateStamp = DateTime.Now;
                                exipcustomersow.EnddateUserlognid = model.WhoUpdate;
                                exipcustomersow.DateOfMove = Convert.ToDateTime(model.OffboardDate);
                                _repositorycontext.ExIpcustomerSows.Update(exipcustomersow);
                            }

                               

                            //Update EX_RESOURCEBILLPERCENT
                            if (model.Reason.ToLower() == "bna" || model.Reason.ToLower() == "nbst5" || model.Reason.ToLower() == "billing")
                            {

                                ExResourcebillpercent exresourcebillpercent = _repositorycontext.ExResourcebillpercents.Where(x => x.PeLogn == model.Logn
                               && x.BillpercentEnddt == null && x.CuIden == Convert.ToInt16(model.CuIden) && x.KickOff == Convert.ToDateTime(model.KickOffDate)).FirstOrDefault();
                                exresourcebillpercent.BillpercentEnddt = Convert.ToDateTime(model.OffboardDate);
                                exresourcebillpercent.Status = "D";
                                exresourcebillpercent.EnddateStamp = DateTime.Now;
                                exresourcebillpercent.EnddateUserlognid = model.WhoUpdate;
                                exresourcebillpercent.DateOfMove = Convert.ToDateTime(model.OffboardDate);
                                _repositorycontext.ExResourcebillpercents.Update(exresourcebillpercent);

                                //Update EX_IPCUSTOMER_BILLING
                                //ExIpcustomerBilling exipcustomerbilling = _repositorycontext.ExIpcustomerBillings.Where(x => x.PeLogn == model.Logn
                                //&& x.BillEnddate == null && x.CuIden == Convert.ToInt16(model.CuIden) && x.KickOff == Convert.ToDateTime(model.KickOffDate)).FirstOrDefault();
                                //exipcustomerbilling.BillEnddate = Convert.ToDateTime(model.OffboardDate);
                                //exipcustomerbilling.Status = "D";
                                //exipcustomerbilling.DateOfMove = Convert.ToDateTime(model.OffboardDate);
                                //_repositorycontext.ExIpcustomerBillings.Update(exipcustomerbilling);
                            }


                            //Update EX_IPCUSTOMER_BILLING
                            //ExIpcustomerBilling exipcustomerbilling = _repositorycontext.ExIpcustomerBillings.Where(x => x.PeLogn == model.Logn
                            //&& x.BillEnddate == null && x.CuIden == Convert.ToInt16(model.CuIden) && x.KickOff == Convert.ToDateTime(model.KickOffDate)).FirstOrDefault();
                            //exipcustomerbilling.BillEnddate = Convert.ToDateTime(model.OffboardDate);
                            //exipcustomerbilling.Status = "D";
                            //exipcustomerbilling.DateOfMove = Convert.ToDateTime(model.OffboardDate);
                            //_repositorycontext.ExIpcustomerBillings.Update(exipcustomerbilling);

                            //Update EX_IPCUSTOMER_REASON
                            ExIpcustomerReason exipcustomerreason = _repositorycontext.ExIpcustomerReasons.Where(x => x.PeLogn == model.Logn
                            && x.EffectiveTo == null && x.CuIden == Convert.ToInt16(model.CuIden) && x.KickOff == Convert.ToDateTime(model.KickOffDate)).FirstOrDefault();
                            exipcustomerreason.EffectiveTo = Convert.ToDateTime(model.OffboardDate);
                            exipcustomerreason.Status = "D";
                            exipcustomerreason.EnddateStamp = DateTime.Now;
                            exipcustomerreason.EnddateUserlognid = model.WhoUpdate;
                            exipcustomerreason.DateOfMove = Convert.ToDateTime(model.OffboardDate);
                            _repositorycontext.ExIpcustomerReasons.Update(exipcustomerreason);

                            ExReportingmanager exreportingmanager = _edmdbcontext.ExReportingmanagers.Where(x => x.Valognid == model.Logn
                            && x.Enddate == null && x.CuIden == Convert.ToInt16(model.CuIden) && x.KickOff == Convert.ToDateTime(model.KickOffDate)).FirstOrDefault();
                            exreportingmanager.Enddate = Convert.ToDateTime(model.OffboardDate);
                            exreportingmanager.Status = "D";
                            exreportingmanager.EnddateStamp = DateTime.Now;
                            exreportingmanager.EnddateUserlognid = model.WhoUpdate;
                            exreportingmanager.DateOfMove = Convert.ToDateTime(model.OffboardDate);
                            _edmdbcontext.ExReportingmanagers.Update(exreportingmanager);

                            if (noofactiveaccount == 0)
                            {
                                //Add Bench Record
                                ExResourceassignmentstatus statusobj = new ExResourceassignmentstatus();
                                statusobj.Sl = null;
                                statusobj.PeLogn = model.Logn;
                                statusobj.CuIden = 85;
                                statusobj.ProjId = 0;
                                statusobj.Group = null;
                                statusobj.Role = null;
                                statusobj.KickOff = Convert.ToDateTime(model.OffboardDate).AddDays(1);
                                statusobj.DateOfMove = null;
                                statusobj.Startdate = Convert.ToDateTime(model.OffboardDate).AddDays(1);
                                statusobj.Enddate = null;//hard coded from below line
                                statusobj.Status = model.OffboardReason.ToUpper() =="LONG LEAVE" ?"L" : "B";
                                statusobj.StatusLevelId = null;
                                statusobj.Entrystamp = DateTime.Now;
                                statusobj.Userlognid = model.WhoUpdate;
                                statusobj.ApproveStatus = "A";
                                statusobj.OffboardStatus = null;
                                statusobj.OffboardStamp = null;
                                statusobj.OffboardUserlognid = null;
                                statusobj.Reason = null;
                                statusobj.FinStatus = null;
                                statusobj.Tranid = null;
                                _repositorycontext.ExResourceassignmentstatuses.Add(statusobj);

                            }

                            if (model.ReplaceWith.ToLower() != "n/a" && model.ReplaceWith != null && model.ReplaceWith != "" && model.ReplaceWith != "null")
                            //if (model.ReplaceWith.ToLower() != "n/a")
                            {
                                var resourceReplace = _repositorycontext.ExResourceassignmentstatuses.FirstOrDefault(x => x.PeLogn == model.ReplaceWith
                                && x.CuIden == Convert.ToInt16(model.CuIden) && x.Enddate == null && x.Reason.ToUpper() == "NBST1");

                                //Update EX_RESOURCEASSIGNMENTSTATUS
                                ExResourceassignmentstatus exResourceassignmentstatusReplace = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.PeLogn == model.ReplaceWith
                                && x.Enddate == null && x.CuIden == Convert.ToInt16(model.CuIden) && x.Reason.ToUpper() == "NBST1" ).FirstOrDefault();
                                exResourceassignmentstatusReplace.Enddate = Convert.ToDateTime(model.OffboardDate);
                                _repositorycontext.ExResourceassignmentstatuses.Update(exResourceassignmentstatusReplace);

                                //Add New Record in resource assignment status table
                                ExResourceassignmentstatus statusobjreplace = new ExResourceassignmentstatus();
                                statusobjreplace.Sl = resourceReplace.Sl;
                                statusobjreplace.PeLogn = model.ReplaceWith;
                                statusobjreplace.CuIden = Convert.ToInt16(model.CuIden);
                                statusobjreplace.ProjId = resourceReplace.ProjId;
                                statusobjreplace.Group = resourceReplace.Group;
                                statusobjreplace.Role = resourceReplace.Role;
                                statusobjreplace.KickOff = resourceReplace.KickOff;
                                statusobjreplace.DateOfMove = null;
                                statusobjreplace.Startdate = Convert.ToDateTime(model.OffboardDate).AddDays(1);
                                statusobjreplace.Enddate = null;//hard coded from below line
                                statusobjreplace.Status = "A";
                                statusobjreplace.StatusLevelId = null;
                                statusobjreplace.Entrystamp = DateTime.Now;
                                statusobjreplace.Userlognid = model.WhoUpdate;
                                statusobjreplace.ApproveStatus = "A";
                                statusobjreplace.OffboardStatus = null;
                                statusobjreplace.OffboardStamp = null;
                                statusobjreplace.OffboardUserlognid = null;
                                statusobjreplace.Reason = model.Reason;
                                statusobjreplace.FinStatus = "A";
                                statusobjreplace.Tranid = resourceReplace.Tranid + 1 ;
                                statusobjreplace.BillStart = model.Reason.ToUpper() == "BNA" ? Convert.ToDateTime(model.OffboardDate).AddDays(1) : null ;
                                _repositorycontext.ExResourceassignmentstatuses.Add(statusobjreplace);


                                var reasonReplace = _repositorycontext.ExIpcustomerReasons.FirstOrDefault(x => x.PeLogn == model.ReplaceWith
                                && x.CuIden == Convert.ToInt16(model.CuIden) && x.EffectiveTo == null);

                                //Update EX_IPCUSTOMER_REASON
                                ExIpcustomerReason exipcustomerreasonsReplace = _repositorycontext.ExIpcustomerReasons.Where(x => x.PeLogn == model.ReplaceWith
                                && x.EffectiveTo == null && x.CuIden == Convert.ToInt16(model.CuIden)).FirstOrDefault();
                                exipcustomerreasonsReplace.EffectiveTo = Convert.ToDateTime(model.OffboardDate);
                                exipcustomerreasonsReplace.Status = "D";
                                exipcustomerreasonsReplace.EnddateStamp = DateTime.Now;
                                exipcustomerreasonsReplace.EnddateUserlognid = model.WhoUpdate;
                                _repositorycontext.ExIpcustomerReasons.Update(exipcustomerreasonsReplace);

                                //Add New Record in resource reason table
                                ExIpcustomerReason ReasonNewreplace = new ExIpcustomerReason();
                                ReasonNewreplace.Sl = reasonReplace.Sl;
                                ReasonNewreplace.PeLogn = model.ReplaceWith;
                                ReasonNewreplace.CuIden = Convert.ToInt16(model.CuIden);
                                ReasonNewreplace.ProjId = reasonReplace.ProjId;
                                ReasonNewreplace.KickOff = reasonReplace.KickOff;
                                ReasonNewreplace.DateOfMove = null;
                                ReasonNewreplace.Reason = model.Reason;
                                ReasonNewreplace.EffectiveFrom = Convert.ToDateTime(model.OffboardDate).AddDays(1);
                                ReasonNewreplace.EffectiveTo = null;
                                ReasonNewreplace.Replacewith = null;
                                ReasonNewreplace.Comments = model.CmplComments;
                                ReasonNewreplace.Entrystamp = DateTime.Now;
                                ReasonNewreplace.Userlognid = model.WhoUpdate;
                                ReasonNewreplace.EnddateStamp = null;
                                ReasonNewreplace.EnddateUserlognid = null;
                                ReasonNewreplace.Status = "A";
                                _repositorycontext.ExIpcustomerReasons.Add(ReasonNewreplace);

                                decimal? billingsum = 0;
                                var Billing = (from p in _repositorycontext.ExResourcebillpercents
                                               where p.PeLogn == model.ReplaceWith && p.CuIden != Convert.ToInt16(model.CuIden) && p.BillpercentEnddt == null
                                               select new
                                               {
                                                   p.Billpercent

                                               }).ToList();

                                if (Billing.Count > 0)
                                {
                                    billingsum = Billing.Sum(t => t.Billpercent);
                                }

                                billingsum = 100 - billingsum;


                                if (reasonLIst.Contains(model.Reason))
                                {
                                    //Add New Record in resource Billpercent table
                                    ExResourcebillpercent exresourcebillpercentnew = new ExResourcebillpercent();
                                    exresourcebillpercentnew.Sl = reasonReplace.Sl;
                                    exresourcebillpercentnew.PeLogn = model.ReplaceWith;
                                    exresourcebillpercentnew.CuIden = Convert.ToInt16(model.CuIden);
                                    exresourcebillpercentnew.ProjId = reasonReplace.ProjId;
                                    exresourcebillpercentnew.KickOff = Convert.ToDateTime(reasonReplace.KickOff);
                                    exresourcebillpercentnew.DateOfMove = null;
                                    exresourcebillpercentnew.BillpercentStartdt = Convert.ToDateTime(model.OffboardDate).AddDays(1);
                                    exresourcebillpercentnew.BillpercentEnddt = null;
                                    //exresourcebillpercentnew.Billpercent = BillPercentResource.Billpercent;
                                    exresourcebillpercentnew.Billpercent = billingsum;
                                    exresourcebillpercentnew.Entrystamp = DateTime.Now;
                                    exresourcebillpercentnew.Userlognid = model.WhoUpdate;
                                    exresourcebillpercentnew.EnddateStamp = null;
                                    exresourcebillpercentnew.EnddateUserlognid = null;
                                    exresourcebillpercentnew.Status = "A";
                                    exresourcebillpercentnew.FinStatus = "A";
                                    exresourcebillpercentnew.FinComments = null;
                                    exresourcebillpercentnew.FinLogn = null;
                                    exresourcebillpercentnew.FinEntrystamp = null;
                                    exresourcebillpercentnew.EnddateStamp = null;
                                    exresourcebillpercentnew.EnddateUserlognid = null;
                                    exresourcebillpercentnew.UpdateUserlognid = null;
                                    exresourcebillpercentnew.UpdateEntrystamp = null;
                                    _repositorycontext.ExResourcebillpercents.Add(exresourcebillpercentnew);
                                }
                            }
                            //}
                        }

                        _repositorycontext.SaveChanges();
                        _edmdbcontext.SaveChanges();

                    

                        {
                            int RequestId = 0;
                            int SL = 0;

                            RequestId = (from a in _repositorycontext.ExResourceassignments
                                         where a.PeLogn == model.Logn && a.OnOff == 1 && a.CuIden == Convert.ToInt16(model.CuIden)
                                         && a.KickOffDate == Convert.ToDateTime(model.KickOffDate)
                                         select a).Max(a => a.Id);
                            var id = _repositorycontext.ExResourceassignments.FirstOrDefault(x => x.Id == RequestId);
                            SL = (int)id.Sl;

                            ExResourceassignmentChecklist checklist = new ExResourceassignmentChecklist();
                            checklist.ChecklistType = "Offboard IT";
                            checklist.ChecklistId = 10;
                            checklist.OnOff = 1;
                            checklist.Id = RequestId;
                            checklist.YesNoInd = model.itFolderAccess;
                            checklist.Comments = model.itFOlderAccessComments;
                            checklist.Sl = SL;
                            checklist.Status = (model.itFolderAccess.ToLower() == "na") ? "A" : "P";
                            _repositorycontext.ExResourceassignmentChecklists.Add(checklist);
                            _repositorycontext.SaveChanges();

                            ExResourceassignmentChecklist checklist1 = new ExResourceassignmentChecklist();
                            checklist1.ChecklistType = "Offboard IT";
                            checklist1.ChecklistId = 11;
                            checklist1.OnOff = 1;
                            checklist1.Id = RequestId;
                            checklist1.YesNoInd = model.itEmailAccess;
                            checklist1.Comments = model.itEmailAccessComments;
                            checklist1.Sl = SL;
                            checklist1.Status = (model.itEmailAccess.ToLower() == "na") ? "A" : "P";
                            _repositorycontext.ExResourceassignmentChecklists.Add(checklist1);
                            _repositorycontext.SaveChanges();


                            ExResourceassignmentChecklist checklist2 = new ExResourceassignmentChecklist();
                            checklist2.ChecklistType = "Offboard Admin";
                            checklist2.ChecklistId = 12;
                            checklist2.OnOff = 1;
                            checklist2.Id = RequestId;
                            checklist2.YesNoInd = "";
                            checklist2.Comments = model.adminAccessComments;
                            checklist2.Sl = SL;
                            checklist2.Status = "P";
                            _repositorycontext.ExResourceassignmentChecklists.Add(checklist2);
                            _repositorycontext.SaveChanges();
                        }
                        kickmodel.nstatus = "Off-Boarded Successfully";

                        // RequestId = resAssign.Value;

                        //_repositorycontext.SaveChanges();
                        //_edmdbcontext.SaveChanges();


                        //Mail Login
                        {
                            int RequestId = 0;

                            RequestId = (from a in _repositorycontext.ExResourceassignments
                                         where a.PeLogn == model.Logn && a.OnOff == 1 && a.CuIden == Convert.ToInt16(model.CuIden)
                                         && a.KickOffDate == Convert.ToDateTime(model.KickOffDate)
                                         select a).Max(a => a.Id);
                            var id = _repositorycontext.ExResourceassignments.FirstOrDefault(x => x.Id == RequestId);

                            string[] reasonList = { "BNA", "BILLING", "NBST5" };

                            var finddata234 = (from p in _repositorycontext.ExResourceassignments
                                               where p.Id == RequestId
                                               select new
                                               {
                                                   ComplianceStatus = p.ComplianceStatus,
                                                   Reason = p.Reason,
                                                   BillDate = p.BillDate,
                                                   Billpercent = p.Billpercent,
                                                   Allocation = p.Allocation,
                                                   KickOffDate = p.KickOffDate,
                                                   PeLogn = p.PeLogn,
                                                   CuIden = p.CuIden,
                                                   Sl = p.Sl,
                                                   Groups = p.Groups,
                                                   AssignType = p.AssignType,
                                                   PeLmgr = p.PeLmgr,
                                                   ReqId = p.ReqId

                                               }).ToList();

                            string ComplianceStatus = "";
                            string Reason = "";
                            string PeLogn = "";
                            string Groups = "";
                            string AssignType = "";
                            string PeLmgr = "";
                            int CuIden = 0;
                            int ReqId = 0;
                            DateTime BillDate = DateTime.Now;
                            DateTime KickoffDate = DateTime.Now;
                            decimal? BillPercent = 0;
                            decimal? Allocation = 0;
                            int Sl = 0;
                            if (finddata234.Count > 0)
                            {
                                ComplianceStatus = finddata234[0].ComplianceStatus;
                                Reason = finddata234[0].Reason;
                                BillDate = Convert.ToDateTime(finddata234[0].BillDate);
                                BillPercent = finddata234[0].Billpercent;
                                Allocation = finddata234[0].Allocation;
                                PeLmgr = finddata234[0].PeLmgr;
                                KickoffDate = Convert.ToDateTime(finddata234[0].KickOffDate);
                                PeLogn = finddata234[0].PeLogn;
                                Groups = finddata234[0].Groups;
                                AssignType = finddata234[0].AssignType;
                                Sl = Convert.ToInt16(finddata234[0].Sl);
                                CuIden = Convert.ToInt16(finddata234[0].CuIden);
                                ReqId = Convert.ToInt16(finddata234[0].ReqId);
                            }


                            var finddata11 = (from p in _repositorycontext.IpCustomers
                                              where p.CuIden == CuIden
                                              select new
                                              {
                                                  CuComp = p.CuComp

                                              }).Take(1).ToList();
                            string clientcode = "";
                            if (finddata11.Count > 0)
                            {
                                clientcode = finddata11[0].CuComp;
                            }

                            var finddata22 = (from p in _edmdbcontext.IpPeople
                                              where p.PeLogn == PeLogn
                                              select new
                                              {
                                                  PeName = p.PeName,
                                                  PeDept = p.PeDept,
                                                  PeLocn = p.PeLocn

                                              }).Take(1).ToList();
                            string empname = "";
                            string empdepratment = "";
                            int pelocn = 0;
                            if (finddata22.Count > 0)
                            {
                                empname = finddata22[0].PeName;
                                empdepratment = finddata22[0].PeDept;
                                pelocn = Convert.ToInt16(finddata22[0].PeLocn);
                            }



                            var finddata5 = (from p in _edmdbcontext.IpPeople
                                             where p.PeLogn == model.WhoUpdate
                                             select new
                                             {
                                                 PeName = p.PeName

                                             }).Take(1).ToList();
                            string empnamedonetransaction = "";
                            if (finddata5.Count > 0)
                            {
                                empnamedonetransaction = finddata5[0].PeName;
                            }

                            var finddata6 = (from p in _repositorycontext.ExStatusdescs
                                             where p.Level == Reason
                                             select new
                                             {
                                                 StatusDesc = p.StatusDesc

                                             }).Take(1).ToList();
                            string reasondesc = "";
                            if (finddata6.Count > 0)
                            {
                                reasondesc = finddata6[0].StatusDesc;
                            }

                            var finddata7 = (from p in _edmdbcontext.IpElements
                                             where p.ElCode == empdepratment
                                             select new
                                             {
                                                 ElName = p.ElName

                                             }).Take(1).ToList();
                            string departfullname = "";
                            if (finddata7.Count > 0)
                            {
                                departfullname = finddata7[0].ElName;
                            }

                            var findpersonemailid = (from p in _edmdbcontext.IpPeople
                                                     where p.PeLogn == model.Logn
                                                     select new
                                                     {
                                                         PeMail = p.PeMail

                                                     }).Take(1).ToList();
                            string personselfmailid = "";
                            if (findpersonemailid.Count > 0)
                            {
                                personselfmailid = findpersonemailid[0].PeMail;
                            }

                            string url = string.Empty;
                            string AuthorizationCode = string.Empty;
                            string FromEmailAddress = string.Empty;
                            url = Configuration.GetValue<string>("MailConfigutaionsetting:MailEndPointURL");
                            AuthorizationCode = Configuration.GetValue<string>("MailConfigutaionsetting:AuthorizationCode");
                            FromEmailAddress = Configuration.GetValue<string>("MailConfigutaionsetting:FromEmailAddress");

                            // Mail TO & CC . To-Compliance and Finance | CC - PNL(excleintplowner) + PMO(exaccessmaster where role='PMO') + EMGR(exipcustomerother where role="emgr") + DM
                            string to = string.Empty;
                            string cc = string.Empty;


                            //var tolistfinal = "";

                            var tolistfinal = (from p in _repositorycontext.ExGeneralParameterConfigurations
                                               where p.ParameterId == 5
                                               select new
                                               {
                                                   ParameterValue = p.ParameterValue

                                               }).Take(1).ToList();

                            if (reasonList.Contains(Reason))
                            {
                                var findfinanceid = (from p in _repositorycontext.ExGeneralParameterConfigurations
                                                     where p.ParameterName == "Finance Notification ID"
                                                     select new
                                                     {
                                                         ParameterValue = p.ParameterValue

                                                     }).ToList();
                                var tempfinal = tolistfinal.Union(findfinanceid);

                                tolistfinal = tempfinal.ToList();
                            }

                            var ExClientPlOwners = (from a in _repositorycontext.ExClientPlOwners select a).ToList();
                            var ExAccessMasters = (from a in _repositorycontext.ExAccessMasters select a).ToList();
                            var ExIpcustomerOthers = (from a in _repositorycontext.ExIpcustomerOthers select a).ToList();
                            var ExResourceassignmentstatuses = (from a in _repositorycontext.ExResourceassignmentstatuses select a).ToList();
                            var IpPeople = (from a in _edmdbcontext.IpPeople select a).ToList();
                            var ExReportingmanagers = (from a in _edmdbcontext.ExReportingmanagers select a).ToList();

                            var findplowner = (from p in ExClientPlOwners
                                               join b in IpPeople on p.PeLogn equals b.PeLogn into sb
                                               from b in sb.DefaultIfEmpty()
                                               where p.ServiceLine == empdepratment && p.Enddate == null && p.Status == "A" && p.MailStatus == 1
                                               select new
                                               {
                                                   PeMail = b.PeMail

                                               }).Distinct().ToList();


                            var findPMO = (from p in ExAccessMasters
                                           join b in IpPeople on p.PeLogn equals b.PeLogn into sb
                                           from b in sb.DefaultIfEmpty()
                                               //where p.Role == "PMO" && p.Status == "A" && p.ServiceLine == empdepratment
                                           where p.Role == "PMO" && p.Status == "A" && p.Enddate == null && b.PeDept == empdepratment && p.ServiceLine == empdepratment
                                           select new
                                           {
                                               PeMail = b.PeMail

                                           }).Distinct().ToList();


                            var findemgr = (from p in ExIpcustomerOthers
                                            join b in IpPeople on p.PeLogn equals b.PeLogn into sb
                                            from b in sb.DefaultIfEmpty()
                                            where p.Role.ToUpper() == "EMGR" && p.CuIden == CuIden && p.Enddate == null && p.Status == "A"
                                            select new
                                            {
                                                PeMail = b.PeMail

                                            }).Distinct().ToList();


                            var finddm = (from p in ExResourceassignmentstatuses
                                          join b in IpPeople on p.PeLogn equals b.PeLogn into sb
                                          from b in sb.DefaultIfEmpty()
                                          where p.CuIden == CuIden && p.Enddate == null && p.Role == "DM" && b.PeDept == empdepratment
                                          select new
                                          {
                                              PeMail = b.PeMail

                                          }).Distinct().ToList();

                            var personemailid = (from p in _edmdbcontext.IpPeople
                                                 where p.PeLogn == model.Logn
                                                 select new
                                                 {
                                                     PeMail = p.PeMail

                                                 }).Distinct().ToList();

                            var pelogn11 = new string[] { "SEHGROH", "GOELANK", "29057999", "29058385" };

                            var testlist = (from p in IpPeople
                                            where pelogn11.Contains(p.PeLogn)
                                            select new
                                            {
                                                PeMail = p.PeMail

                                            }).Distinct().ToList();

                            var listA = new List<string> { "ankur.goel@acuitykp.com" };
                            var listB = new List<string> { "rohit.sehgal@acuitykp.com" };
                            var listFinal = listA.Union(listB);

                            //var cclistfinal = new List<string> {  };

                            var ITGroupID = (from p in _repositorycontext.ExEmailnotifications
                                             where p.Location == pelocn && p.Modulename == "OnBoardApprove-IT"
                                             select new
                                             {
                                                 PeMail = p.Tomailid

                                             }).Distinct().ToList();

                            var AdminGroupID = (from p in _repositorycontext.ExEmailnotifications
                                                where p.Location == pelocn && p.Modulename == "OnBoardApprove-Admin"
                                                select new
                                                {
                                                    PeMail = p.Tomailid

                                                }).Distinct().ToList();


                            var  cclistfinal = findPMO.Union(findemgr).Union(finddm).Union(personemailid).Union(ITGroupID).Union(AdminGroupID).ToList();

                            if (findplowner.Count > 0)
                            {
                                   cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(personemailid).Union(ITGroupID).Union(AdminGroupID).ToList();
                            }
                           

                            //var cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(personemailid).ToList();

                            var dddddddd = testlist.Union(personemailid).ToList();


                            string aaaaa = "";
                            if (cclistfinal.Count > 0)
                            {
                                for (int i = 0; i < cclistfinal.Count; i++)
                                {
                                    aaaaa = aaaaa + cclistfinal[i].PeMail;
                                }
                            }

                            string tttttt = "";
                            if (tolistfinal.Count > 0)
                            {
                                for (int i = 0; i < tolistfinal.Count; i++)
                                {
                                    tttttt = tttttt + tolistfinal[i].ParameterValue;
                                }
                            }

                            //cc = plowner +";" + pmomail + ";" + emgrmail + ";" + dmmail + ";" + personselfmailid;

                            string subject = string.Empty;
                            if (reasonLIst.Contains(model.Reason) && model.OffboardReason != "Replacement" && (model.ReplaceWith.ToLower() == "n/a" || model.ReplaceWith == null || model.ReplaceWith == "" || model.ReplaceWith == "null"))
                            {
                                subject = "OffBoarding Approval Required From Finance - " + empname + " From " + clientcode + " ( Reason: " + model.OffboardReason + ")";
                            }
                            else
                            {
                                subject = "OffBoarding  - " + empname + " From " + clientcode + " ( Reason: " + model.OffboardReason + ")";

                            }
                            //    if (reasonList.Contains(Reason))
                            //{
                            //    subject = "OffBoard Request  ( " + empname + " to " + clientcode + "(Reason: " + reasondesc + ")";
                            //}
                            //else
                            //{
                            //    subject = "OffBoard Request " + empname + " to " + clientcode + "(Reason: " + reasondesc + ")";
                            //}

                            string ABCD = "<table  border='1'><tr><td>" +
            "<Table BgColor='lavender' border='1' bordercolor ='lightblue' style='font-size:12px;font-family:Arial'>" +
            "<TR><TD BgColor='lavender'><B>Client Code</TD><TD >&nbsp;" + clientcode + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Emp Name</TD><TD >&nbsp;" + empname + "</TD></TR>";
                            // "<TR><TD BgColor='lavender'><B>Project Assignment Role</TD><TD >&nbsp;" + assignrole + "</TD></TR>" +
                            //"<TR><TD BgColor='lavender'><B>Allocation Percentage</TD><TD >&nbsp;" + model.Allocation + "</TD></TR>";
                            if (reasonList.Contains(Reason))
                            {
                                ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Billing Percentage</TD><TD >&nbsp;" + BillPercent + "</TD></TR>";
                            }

                            ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Reason</TD><TD >&nbsp;" + model.OffboardReason + "</TD></TR>";


                            //if (model.Reason.ToUpper() == "NBST1")
                            //{
                            //    ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Replacing</TD><TD >&nbsp;" + empnamereplacewith + "</TD></TR>";
                            //}


                            ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Department</TD><TD >&nbsp;" + departfullname + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Comments</TD><TD >&nbsp;" + model.OffboardComments + "</TD></TR>" +
            //"<TR><TD BgColor='lavender'><B>Request ID</TD><TD >&nbsp;" + (ReqId == -1 ? "NA" : ReqId) + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Kick off Date</TD><TD >&nbsp;" + KickoffDate.ToString("yyyy-MM-dd") + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Date of Move</TD><TD >&nbsp;" + model.OffboardDate + "</TD></TR>" +
            //"<TR><TD BgColor='lavender'><B>Replace With</TD><TD >&nbsp;" + model.ReplaceWith ==null ? "NA" : model.ReplaceWith + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>OffBoard By</TD><TD >&nbsp;" + empnamedonetransaction + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Entry Stamp</TD><TD >&nbsp;" + DateTime.Now + "</TD></TR>" +
             "<TR><TD BgColor='lavender'><B>Checklist For IT</TD><TD ></TD></TR>" +
              "<TR><TD BgColor='lavender'><B>Shared Folder Access</TD><TD >&nbsp;" + model.itFOlderAccessComments + "</TD></TR>" +
               "<TR><TD BgColor='lavender'><B>Email Group Access</TD><TD >&nbsp;" + model.itEmailAccessComments + "</TD></TR>" +
                 "<TR><TD BgColor='lavender'><B>Checklist For Admin</TD><TD ></TD></TR>" +
              "<TR><TD BgColor='lavender'><B>Physical Access Revoke</TD><TD >&nbsp;" + model.adminAccessComments + "</TD></TR>";
             //"<TR><TD BgColor='lavender'><B>Workstation Details</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 9 select a.Comments).FirstOrDefault() + "</TD></TR>" +

             //"<TR><TD BgColor='lavender'><B>TO ID</TD><TD >&nbsp;" + tttttt + "</TD></TR>" +
             // "<TR><TD BgColor='lavender'><B>CC</TD><TD >&nbsp;" + aaaaa + "</TD></TR>";




                            string msg = "<body style='background-color:#cccccc;'>" +
"<table style='background-color:#ffffff;width:80%' border='0' align='center' cellpadding='0' cellspacing='0'>" +
 "<tr>" +
   "<td align='left' valign='top'>" +
"</td>" +
   "<td align='left' valign='top'>" + "<table style='padding:20px;'>" +
"<tr><td colspan='2'><span style='font-size: 20px; font-family: Arial'><b>Acuity Knowledge Partners</b></span><hr/></td></tr>" +

 "<tr>" +
   "<td colspan='2'>" +
 "<div style='height:10px;'></div>";

                            msg = msg + ABCD +
                             "</td>" +
                             "</tr>" +
                             "<tr>" +
                             "<td colspan='2' align='center'>" +
                             "<p>" +
                             "</p>" +
                             "</td>" +
                             "</tr>" +
                             "</table>" +
                             "</td>" +
                             "</tr>" +
                             "</table><br/>" +
                          "<h6>Note: This is auto generated mail by system.</h6>" +
                             "</body>";
                            string sdsdsd = string.Empty;

                            //string[] tomail11 = new string[dddddddd.Count];
                            //if (dddddddd.Count > 0)
                            //{
                            //    for (int i = 0; i < dddddddd.Count; i++)
                            //    {
                            //        tomail11[i] = dddddddd[i].PeMail;
                            //    }
                            //}
                            string[] tomail11 = new string[tolistfinal.Count];
                            if (tolistfinal.Count > 0)
                            {
                                for (int i = 0; i < tolistfinal.Count; i++)
                                {
                                    tomail11[i] = tolistfinal[i].ParameterValue;
                                }
                            }

                            string[] ccmail11 = new string[cclistfinal.Count];
                            if (cclistfinal.Count > 0)
                            {
                                for (int i = 0; i < cclistfinal.Count; i++)
                                {
                                    ccmail11[i] = cclistfinal[i].PeMail;
                                }
                            }



                            emailSendModel sendEmail = new emailSendModel();
                            string[] bccmail = { extraEmail };
                            //List<string> tomail = new List<string>(listFinal);

                            //string[] tomail =  dddddddd;
                            //string[] ccmail = { "rohit.sehgal@acuitykp.com" };
                            sendEmail.from = FromEmailAddress;
                            sendEmail.to = new List<string>(tomail11);
                            sendEmail.subject = subject;
                            sendEmail.body = msg;
                            sendEmail.isHTML = true;
                            sendEmail.cc = new List<string>(ccmail11);
                            sendEmail.bcc = new List<string>(bccmail);
                            //sendEmail.cc = new List<string>(ccmail);
                            //sendEmail.bcc = new List<string>();
                            //sendEmail.url = "http://10.50.5.120:3021/api/sendemailv2";
                            sendEmail.url = url;

                            var handler = new HttpClientHandler();
                            handler.ServerCertificateCustomValidationCallback +=
                                                (sender, certificate, chain, errors) =>
                                                {
                                                    return true;
                                                };
                            HttpClient client = new(handler);
                            var request = new HttpRequestMessage(HttpMethod.Post, url);
                            request.Headers.Add("Authorization", AuthorizationCode);
                            request.Content = JsonContent.Create(sendEmail);
                            var response1 = client.SendAsync(request).Result;
                        }

                        response.Status = true;
                        response.Message = "Off-Boarded Successfully";
                        response.Data = "Off-Boarded Successfully";
                        //response.Message = kickmodel.nstatus;
                        //response.Data = kickmodel;
                        response.Error = "";
                        return Ok(response);
                    }

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

        [HttpPost("OnboardResource")]
        public IActionResult OnboardResource(Resource model)
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
                    DateTime BenchStart = DateTime.Now;
                    DateTime PeJoin = DateTime.Now;
                    DateTime LockDate = DateTime.Now;

                    decimal? allocationsum = 0; 

                    KickOffStatus kickmodel = new KickOffStatus();
                    ResultTemp resultModel = new ResultTemp();

                    string[] statusList = { "B", "T", "L" };
                    var resource = _repositorycontext.ExResourceassignmentstatuses.FirstOrDefault(x => x.PeLogn == model.PeLogn && x.DateOfMove == null && statusList.Contains(x.Status));
                    if (resource != null)
                    {
                        BenchStart = (DateTime)resource.KickOff;
                    }

                    var people = _edmdbcontext.IpPeople.FirstOrDefault(x => x.PeLogn == model.PeLogn);
                    if (people != null)
                    {
                        PeJoin = (DateTime)people.PeJoin;
                    }
                    //var workTypevar = _edmdbcontext.ExIppeople.FirstOrDefault(s => s.PeLogn == model.PeLogn);

                    var Allocation = (from p in _repositorycontext.ExResourceallocations
                                  where p.PeLogn == model.PeLogn && p.AllocStartdt <= Convert.ToDateTime(model.KickOff) &&
                    (p.AllocEnddate == null || p.AllocEnddate >= Convert.ToDateTime(model.KickOff))
                                    select new 
                                    {
                                       p.Allocation
                                        
                                    }).ToList();

                    if (Allocation.Count > 0)
                    {
                        allocationsum = Allocation.Sum(t => t.Allocation);
                    }

                    allocationsum = 100 - allocationsum;

                    //var Allocation = _repositorycontext.ExResourceallocations.FirstOrDefault(x => x.PeLogn == model.PeLogn && x.AllocStartdt <= Convert.ToDateTime(model.KickOff) &&
                    //(x.AllocEnddate == null || x.AllocEnddate >= Convert.ToDateTime(model.KickOff)));
                    //if (Allocation != null)
                    //{
                    //    allocationsum = Allocation.Allocation;
                    //}


                    //var LockDate1 = _repositorycontext.ExTransactionApprovals.OrderByDescending(x => x.Id).Take(1); 

                    var LockDate1 = (from p in _repositorycontext.ExTransactionApprovals 
                                     orderby p.Id descending
                                    select new
                                    {
                                        p.LockedOn

                                    }).ToList();
                    if (LockDate1.Count > 0)
                    {
                        
                        LockDate = Convert.ToDateTime(LockDate1[0].LockedOn);
                    }


                    if (LockDate >= Convert.ToDateTime(model.KickOff))
                    {
                        kickmodel.nstatus = "Kickoff Date cannot less than or equal to lock date " + LockDate.ToString("yyyy-MM-dd");
                    }
                    else if ((from a in _repositorycontext.ExResourceassignmentstatuses
                              where a.PeLogn == model.PeLogn && a.CuIden == Convert.ToInt32(model.CuIden)  
 && a.ApproveStatus == "P"  
                              select a).ToList().Count > 0)
                    {

                        kickmodel.nstatus = "The resource has been already onboarded to the selected client, but awaiting approval(s).";
                    }
                    else if ((from a in _repositorycontext.ExResourceassignmentstatuses
                         where a.PeLogn == model.PeLogn && a.CuIden == Convert.ToInt32(model.CuIden)  && a.Enddate==null 
                         select a).ToList().Count > 0)
                    {
                        //resultModel.ID = 1;
                        //resultModel.Status = "The resource has been already onboarded to the selected client and group and for selected kickoff date" + model.KickOff;
                        kickmodel.nstatus = "The resource has been already onboarded to the selected client for selected kickoff date " + model.KickOff;
                    }
                    else if ((from a in _repositorycontext.ExResourceassignmentstatuses
                              where a.PeLogn == model.PeLogn && a.CuIden == Convert.ToInt32(model.CuIden) &&
                               (Convert.ToDateTime(model.KickOff) > a.Startdate &&
    (Convert.ToDateTime(model.KickOff) < (a.Enddate == null ? DateTime.Now : a.Enddate)))
                              select a).ToList().Count > 0)
                    {
                        //resultModel.ID = 1;
                        //resultModel.Status = "The resource has been already onboarded to the selected client and group and for selected kickoff date" + model.KickOff;
                        kickmodel.nstatus = "The resource has been already onboarded to the selected client for selected kickoff date " + model.KickOff;
                    }
                    else if (Convert.ToDateTime(model.KickOff) < BenchStart &&  resource != null)
                    {
                        //kickmodel.nstatus = "Do not Insert1";
                        //kickmodel.kickoffdate = BenchStart.ToString();
                        kickmodel.nstatus = "Kickoff date cannot be less than bench start date " + BenchStart;
                    }   
                  
                    else if (allocationsum < Convert.ToDecimal(model.Allocation))
                    {
                        kickmodel.nstatus = "Giving Allocation cannot be greater than or equal to remaining allocated percentage " + allocationsum;
                    }

                    else {

                   
                       
                       
    //                    if (workTypevar.WorkType == 2)
    //                    {
    //                        kickmodel.nstatus = "Insert";
    //                        kickmodel.kickoffdate = model.KickOff;

    //                    }
                      
    //                    else if ((from a in _repositorycontext.ExResourceassignmentstatuses
    //                              where a.PeLogn == model.PeLogn
    //&& a.Status != "B" && a.ApproveStatus == "A"
    //                              select a).ToList().Count > 1)
    //                    {
    //                        kickmodel.nstatus = "Insert";
    //                        kickmodel.kickoffdate = model.KickOff;

    //                    }
    //                    else if (Convert.ToDateTime(model.KickOff) >= BenchStart)
    //                    {
    //                        kickmodel.nstatus = "Insert";
    //                        kickmodel.kickoffdate = model.KickOff;
    //                    }
    //                    else
    //                    {
    //                        kickmodel.nstatus = "Do not Insert2";
    //                        kickmodel.kickoffdate = BenchStart.ToString() == null ? PeJoin.ToString() : BenchStart.ToString();

    //                    }
    //                    if (model.Reason != "NBST1")
    //                    {
    //                        model.Replacing = null;
    //                    }
                        string role = string.Empty;
                        //int SI = 1;
                        Core core = new(_repositorycontext, _edmdbcontext);
                        role = core.uFn_LoginCheck(model.PeLogn);

                        int SI = 0;

                        
                        string[] statusLister = { "B", "T", "L" };
                        var SIP = (from p in _repositorycontext.ExResourceassignmentstatuses
                                   where
                                   p.PeLogn == model.PeLogn && p.CuIden == Convert.ToInt32(model.CuIden) /*&& statusLister.Contains(p.Status)*/
                                   select p).Max(p => p.Sl);
                        SI = SIP == null ? 0 : SIP.Value;
                        SI = SI == 0 ? 1 : SI + 1;

                        //                    if ((from a in _repositorycontext.ExResourceassignmentstatuses
                        //                         where a.PeLogn == model.PeLogn && a.CuIden == Convert.ToInt32(model.CuIden) && a.Group == model.Group
                        //&& a.ProjId == Convert.ToInt32(model.ProjID) && a.ApproveStatus == "A" &&
                        //(Convert.ToDateTime(model.KickOff) > a.Startdate &&
                        //(Convert.ToDateTime(model.KickOff) < (a.Enddate == null ? DateTime.Now : a.Enddate)))
                        //                         select a).ToList().Count > 0)
                        //                    {
                        //                        resultModel.ID = 1;
                        //                        resultModel.Status = "The resource has been already onboarded to the selected client and group and for selected kickoff date" + model.KickOff;
                        //                    }
                        //                    else if ((from a in _repositorycontext.ExResourceassignmentstatuses
                        //                              where a.PeLogn == model.PeLogn && a.CuIden == Convert.ToInt32(model.CuIden) && a.Group == model.Group
                        //&& a.ProjId == Convert.ToInt32(model.ProjID) && a.ApproveStatus == "P" &&
                        //(Convert.ToDateTime(model.KickOff) > a.Startdate &&
                        //(Convert.ToDateTime(model.KickOff) < (a.Enddate == null ? DateTime.Now : a.Enddate)))
                        //                              select a).ToList().Count > 0)
                        //                    {
                        //                        resultModel.ID = 1;
                        //                        resultModel.Status = "The resource has been already onboarded to the selected client and group, but awaiting approval(s).";
                        //                    }
                        //                    else if (kickmodel.nstatus != "Insert")
                        //                    {
                        //                        resultModel.ID = 1;
                        //                        resultModel.Status = "The resource is 100% allocated for selected kick off date. Please select another kick off date other than" + model.KickOff;



                        //                    }
                        //                    else
                        {
                            string[] reasonLIst = { "BNA", "NBST5" };
                            string[] reasonList2 = { "BNA", "AB", "NBA" };
                            string[] roleList = { "Admin1", "NONE1" };
                            string[] reasonList3 = { "BNA", "NBST5"};
                            string[] reasonList4 = { "BNA", "NBST5" };

                            ExResourceassignment Exresource = new ExResourceassignment();
                            Exresource.PeLmgr = model.ReportTo;
                            Exresource.PeLogn = model.PeLogn;
                            Exresource.RepValognid = model.Reason.ToUpper()=="NBST1" ? model.Replacing : null;
                            Exresource.CuIden = Convert.ToInt32(model.CuIden);
                            Exresource.ProjId = Convert.ToInt32(model.ProjID);
                            Exresource.CuType = model.ClientType;
                            Exresource.IpLocn = (from a in _edmdbcontext.IpPeople where a.PeLogn == model.PeLogn select a.PeLocn).FirstOrDefault();
                            Exresource.Groups = model.Group;
                            Exresource.AssignType = model.AssignRole;
                            Exresource.Reason = model.Reason;
                            Exresource.ReasonDetail = null;
                            Exresource.Jobrefno = null;
                            Exresource.ReqId = Convert.ToInt32(model.ReqID);
                            Exresource.ResgclntComment = null;
                            Exresource.ItComment = null;
                            Exresource.AdminComment = null;
                            Exresource.DateOfSelectionOrMove = model.DOS == null ? null : Convert.ToDateTime(model.DOS);
                            Exresource.KickOffDate = model.KickOff == null ? null : Convert.ToDateTime(model.KickOff);
                            Exresource.BillDate = reasonLIst.Contains(model.Reason) ? Convert.ToDateTime(model.BillStart) : null;
                            Exresource.BillingStatus = null;
                            Exresource.BillingDetails = null;
                            Exresource.ComplComment = model.Compliance;
                            Exresource.HrRdAccFinComment = null;
                            Exresource.OnOff = 0;
                            Exresource.Entrystamp = DateTime.Now;
                            Exresource.Userlognid = model.Logn;
                            Exresource.Status = reasonList2.Contains(model.Reason) ? "A" : "S";
                            Exresource.ApproveStatus = "P";
                            Exresource.BcatId = null;
                            Exresource.BillingRate = null;
                            Exresource.Userapprovestatus = roleList.Contains(role) ? "P" : "A";
                            Exresource.FinanceStatus = reasonList3.Contains(model.Reason) ? "P" : "A";
                            Exresource.FinanceComments = null;
                            Exresource.FinanceEntrystamp = null;
                            Exresource.FinanceLognid = null;
                            Exresource.ManagerComments = null;
                            Exresource.ManagerEntrystamp = roleList.Contains(role) ? null : DateTime.Now;
                            Exresource.ManagerLognid = roleList.Contains(role) ? null : model.Logn;
                            Exresource.ComplianceComments = null;
                            Exresource.ComplianceStatus = "P";
                            Exresource.ComplianceEntrystamp = null;
                            Exresource.ComplianceLognid = null;

                            Exresource.ItCommentsOnapprove = null;
                            Exresource.ItStatusOnapprove = "P";
                            Exresource.ItStatusEntrystamp = null;
                            Exresource.ItStatusLognid = null;
                            Exresource.AdminCommentsOnapprove = null;
                            Exresource.AdminStatusOnapprove = "P";
                            Exresource.AdminStatusEntrystamp = null;
                            Exresource.AdminStatusLognid = null;
                            Exresource.Supr = model.Supervisor;
                            Exresource.Ndasigneddate = null;
                            Exresource.Documentation = null;
                            Exresource.ManagerUpdate = null;
                            Exresource.OrgnRole = null;
                            Exresource.TdaComments = null;
                            Exresource.CheadTypeoflead = null;
                            Exresource.CheadUpdatedbychead = null;
                            Exresource.CheadEntrystamp = null;
                            Exresource.InvoiceNo = null;
                            Exresource.BillingRole = null;
                            Exresource.Allocation = model.Allocation != null ? Convert.ToDecimal(model.Allocation) : 0;
                            Exresource.Sl = SI;
                            Exresource.ConversionComplStatus = "P";
                            Exresource.Billpercent = reasonLIst.Contains(model.Reason) ? Convert.ToDecimal(model.BillPercentage) : null;
                            Exresource.Sow = model.SOWno;
                            Exresource.OnboardComments = model.OnboardComments;
                            Exresource.DmKickOffDate = Convert.ToDateTime(model.KickOff);
                            _repositorycontext.ExResourceassignments.Add(Exresource);
                             

                            ExResourceassignmentstatus statusobj = new ExResourceassignmentstatus();
                            statusobj.Sl = SI;
                            statusobj.PeLogn = model.PeLogn;
                            statusobj.CuIden = Convert.ToInt32(model.CuIden);
                            statusobj.ProjId = Convert.ToInt32(model.ProjID);
                            statusobj.Group = model.Group;
                            statusobj.Role = model.AssignRole;
                            statusobj.KickOff = Convert.ToDateTime(model.KickOff);
                            statusobj.DateOfMove = null;
                            statusobj.Startdate = Convert.ToDateTime(model.KickOff);
                            statusobj.Enddate = null;//hard coded from below line
                            statusobj.Status = (from a in _repositorycontext.ExStatusdescs where a.Level == model.Reason select a.StatusIndicator).FirstOrDefault(); ;
                            statusobj.StatusLevelId = (from a in _repositorycontext.ExStatusdescs where a.Level == model.Reason select a.StatusLevelId).FirstOrDefault(); ; ;
                            statusobj.Entrystamp = DateTime.Now;
                            statusobj.Userlognid = model.Logn;
                            statusobj.ApproveStatus = "P";
                            statusobj.OffboardStatus = null;
                            statusobj.OffboardStamp = null;
                            statusobj.OffboardUserlognid = null;
                            statusobj.Reason = model.Reason;
                            statusobj.FinStatus = reasonList4.Contains(model.Reason) ? "P" : "A";
                            statusobj.Tranid = 1;
                            _repositorycontext.ExResourceassignmentstatuses.Add(statusobj);
                            _repositorycontext.SaveChanges();

                            Models.EMPDATA.ExIpperson exIpperson = _edmdbcontext.ExIppeople.Where(x => x.PeLogn == model.PeLogn).FirstOrDefault();
                            exIpperson.PersonType = model.PersonType;
                            _edmdbcontext.ExIppeople.Update(exIpperson);
                            _edmdbcontext.SaveChanges();

                            int RequestId = 0;
                            int SL = 0;

                            RequestId = (from a in _repositorycontext.ExResourceassignments
                                         where a.PeLogn == model.PeLogn && a.OnOff == 0
                                         select a).Max(a => a.Id);
                            var id = _repositorycontext.ExResourceassignments.FirstOrDefault(x => x.Id == RequestId);
                            SL = (int)id.Sl;

                            ExResourceassignmentChecklist checklist = new ExResourceassignmentChecklist();
                            checklist.ChecklistType = "Onboard IT";
                            checklist.ChecklistId = 6;
                            checklist.OnOff = 0;
                            checklist.Id = RequestId;
                            checklist.YesNoInd = model.IsFolderAccessRequired;
                            checklist.Comments = model.FolderAccessDetails;
                            checklist.Sl = SL;
                            checklist.Status = "P";
                            _repositorycontext.ExResourceassignmentChecklists.Add(checklist);
                            _repositorycontext.SaveChanges();

                            ExResourceassignmentChecklist checklist1 = new ExResourceassignmentChecklist();
                            checklist1.ChecklistType = "Onboard IT";
                            checklist1.ChecklistId = 7;
                            checklist1.OnOff = 0;
                            checklist1.Id = RequestId;
                            checklist1.YesNoInd = model.IsEmailAccessRequired;
                            checklist1.Comments = model.EmailAccessDetails;
                            checklist1.Sl = SL;
                            checklist1.Status = "P";
                            _repositorycontext.ExResourceassignmentChecklists.Add(checklist1);
                            _repositorycontext.SaveChanges();


                            ExResourceassignmentChecklist checklist2 = new ExResourceassignmentChecklist();
                            checklist2.ChecklistType = "Onboard Admin";
                            checklist2.ChecklistId = 8;
                            checklist2.OnOff = 0;
                            checklist2.Id = RequestId;
                            checklist2.YesNoInd = "";
                            checklist2.Comments = model.ClientRoomDetails;
                            checklist2.Sl = SL;
                            checklist2.Status = "P";
                            _repositorycontext.ExResourceassignmentChecklists.Add(checklist2);
                            _repositorycontext.SaveChanges();
                            // RequestId = resAssign.Value;

                            ExResourceassignmentChecklist checklist3 = new ExResourceassignmentChecklist();
                            checklist3.ChecklistType = "Onboard Admin";
                            checklist3.ChecklistId = 9;
                            checklist3.OnOff = 0;
                            checklist3.Id = RequestId;
                            checklist3.YesNoInd = "";
                            checklist3.Comments = model.WorkStationDetails;
                            checklist3.Sl = SL;
                            checklist3.Status = "P";
                            _repositorycontext.ExResourceassignmentChecklists.Add(checklist3);
                            _repositorycontext.SaveChanges();

                          


                            var finddata = (from p in _repositorycontext.IpCustomers
                                            where p.CuIden.ToString() == model.CuIden
                                            select new
                                            {
                                                CuComp = p.CuComp

                                            }).Take(1).ToList();
                            string clientcode = "";
                            if (finddata.Count > 0)
                            {
                                clientcode = finddata[0].CuComp;
                            }

                            var finddata1 = (from p in _edmdbcontext.IpElements
                                            where p.ElCode  == model.Group
                                            select new
                                            {
                                                groupname = p.ElName

                                            }).Take(1).ToList();
                            string groupname = "";
                            if (finddata1.Count > 0)
                            {
                                groupname = finddata1[0].groupname;
                            }

                            var finddata2 = (from p in _edmdbcontext.IpPeople
                                             where p.PeLogn == model.PeLogn
                                             select new
                                             {
                                                 PeName = p.PeName,
                                                 PeDept = p.PeDept

                                             }).Take(1).ToList();
                            string empname = "";
                            string empdepratment = "";
                            if (finddata2.Count > 0)
                            {
                                empname = finddata2[0].PeName;
                                empdepratment = finddata2[0].PeDept;
                            }

                            var finddata3 = (from p in _edmdbcontext.IpCategories
                                             where p.CaCode == model.AssignRole
                                             select new
                                             {
                                                 CaName = p.CaName

                                             }).Take(1).ToList();
                            string assignrole = "";
                            if (finddata3.Count > 0)
                            {
                                assignrole = finddata3[0].CaName;
                            }

                            var finddata4 = (from p in _edmdbcontext.IpPeople
                                             where p.PeLogn == model.replaceWith
                                             select new
                                             {
                                                 PeName = p.PeName

                                             }).Take(1).ToList();
                            string empnamereplacewith = ""; 
                            if (finddata4.Count > 0)
                            {
                                empnamereplacewith = finddata4[0].PeName; 
                            }

                            var finddata5 = (from p in _edmdbcontext.IpPeople
                                             where p.PeLogn == model.Logn
                                             select new
                                             {
                                                 PeName = p.PeName

                                             }).Take(1).ToList();
                            string empnamedonetransaction = "";
                            if (finddata5.Count > 0)
                            {
                                empnamedonetransaction = finddata5[0].PeName;
                            }

                            var finddata6 = (from p in _repositorycontext.ExStatusdescs
                                             where p.Level == model.Reason
                                             select new
                                             {
                                                 StatusDesc = p.StatusDesc

                                             }).Take(1).ToList();
                            string reasondesc = "";
                            if (finddata6.Count > 0)
                            {
                                reasondesc = finddata6[0].StatusDesc;
                            }

                            var finddata7 = (from p in _edmdbcontext.IpElements
                                             where p.ElCode == empdepratment
                                             select new
                                             {
                                                 ElName = p.ElName

                                             }).Take(1).ToList();
                            string departfullname = "";
                            if (finddata7.Count > 0)
                            {
                                departfullname = finddata7[0].ElName;
                            }

                            var findpersonemailid = (from p in _edmdbcontext.IpPeople
                                             where p.PeLogn == model.Logn
                                             select new
                                             {
                                                 PeMail = p.PeMail

                                             }).Take(1).ToList();
                            string personselfmailid = "";
                            if (findpersonemailid.Count > 0)
                            {
                                personselfmailid = findpersonemailid[0].PeMail;
                            }

                            string url = string.Empty;
                            string AuthorizationCode = string.Empty;
                            string FromEmailAddress = string.Empty;
                            string mailsendingstatus = string.Empty;

                            url = Configuration.GetValue<string>("MailConfigutaionsetting:MailEndPointURL");
                            AuthorizationCode = Configuration.GetValue<string>("MailConfigutaionsetting:AuthorizationCode");
                            FromEmailAddress = Configuration.GetValue<string>("MailConfigutaionsetting:FromEmailAddress");
                            mailsendingstatus = Configuration.GetValue<string>("MailConfigutaionsetting:NeedToSendMail");


                            // Mail TO & CC . To-Compliance and Finance | CC - PNL(excleintplowner) + PMO(exaccessmaster where role='PMO') + EMGR(exipcustomerother where role="emgr") + DM
                            string to = string.Empty; 
                            string cc = string.Empty;


                            //var tolistfinal = "";
                           
                            var tolistfinal = (from p in _repositorycontext.ExGeneralParameterConfigurations
                                                    where p.ParameterId == 5
                                                    select new
                                                    {
                                                        ParameterValue = p.ParameterValue

                                                    }).Take(1).ToList();

                            //if (findcomplianceid.Count > 0)
                            //{
                            //    to = findcomplianceid[0].ParameterValue;
                            //}


                            if (reasonLIst.Contains(model.Reason))
                            {
                                var findfinanceid = (from p in _repositorycontext.ExGeneralParameterConfigurations
                                                     where p.ParameterName == "Finance Notification ID"
                                                     select new
                                                     {
                                                         ParameterValue = p.ParameterValue

                                                     }).ToList();
                                 var tempfinal = tolistfinal.Union(findfinanceid);

                                tolistfinal = tempfinal.ToList();
                                //if (findfinanceid.Count > 0)
                                //{
                                //    to = to +';'+ findfinanceid[0].ParameterValue;
                                //}  
                            } 

                            var ExClientPlOwners = (from a in _repositorycontext.ExClientPlOwners select a).ToList(); 
                            var ExAccessMasters = (from a in _repositorycontext.ExAccessMasters select a).ToList(); 
                            var ExIpcustomerOthers = (from a in _repositorycontext.ExIpcustomerOthers select a).ToList(); 
                            var ExResourceassignmentstatuses = (from a in _repositorycontext.ExResourceassignmentstatuses select a).ToList(); 
                            var IpPeople = (from a in _edmdbcontext.IpPeople select a).ToList();
                            var ExReportingmanagers = (from a in _edmdbcontext.ExReportingmanagers select a).ToList();

                            var findplowner = (from p in ExClientPlOwners
                                               join b in IpPeople on p.PeLogn equals b.PeLogn into sb
                                               from b in sb.DefaultIfEmpty()
                                               where p.ServiceLine==empdepratment && p.Enddate==null && p.Status == "A" && p.MailStatus == 1
                                                    select new
                                                    {
                                                        PeMail = b.PeMail

                                                    }).Distinct().ToList();
 

                            var findPMO = (from p in ExAccessMasters
                                               join b in IpPeople on p.PeLogn equals b.PeLogn into sb
                                               from b in sb.DefaultIfEmpty()
                                               //where p.Role== "PMO" && p.Status=="A" && p.ServiceLine== empdepratment && p.Enddate ==null  
                                               where p.Role== "PMO" && p.Status=="A"  && p.Enddate ==null && b.PeDept == empdepratment && p.ServiceLine == empdepratment
                                           select new
                                               {
                                                   PeMail = b.PeMail

                                               }).Distinct().ToList();

                        

                            var findemgr = (from p in ExIpcustomerOthers
                                            join b in IpPeople on p.PeLogn equals b.PeLogn into sb
                                           from b in sb.DefaultIfEmpty()
                                           where p.Role.ToUpper() == "EMGR" && p.CuIden.ToString() ==model.CuIden  && p.Enddate==null && p.Status=="A"
                                           select new
                                           {
                                               PeMail = b.PeMail

                                           }).Distinct().ToList(); 

                            var finddm = (from p in ExResourceassignmentstatuses
                                            join b in IpPeople on p.PeLogn equals b.PeLogn into sb
                                            from b in sb.DefaultIfEmpty()
                                            where p.CuIden.ToString()==model.CuIden && p.Enddate ==null && p.Role=="DM" && b.PeDept==empdepratment
                                            select new
                                            {
                                                PeMail = b.PeMail

                                            }).Distinct().ToList(); 
                         
                            var personemailid = (from p in _edmdbcontext.IpPeople
                                                 where p.PeLogn == model.Logn
                                                 select new
                                                 {
                                                     PeMail = p.PeMail

                                                 }).Distinct().ToList();

                            var pelogn11 = new string[] { "SEHGROH", "GOELANK", "29057999", "29058385" };

                            var testlist = (from p in IpPeople 
                                          where pelogn11.Contains(p.PeLogn)
                                            select new
                                          {
                                              PeMail = p.PeMail

                                          }).Distinct().ToList();

                            //var listA = new List<string> { "ankur.goel@acuitykp.com" };
                            //var listB = new List<string> { "rohit.sehgal@acuitykp.com" };
                            //var listFinal = listA.Union(listB);


                            var cclistfinal = findPMO.Union(findemgr).Union(finddm).Union(personemailid).ToList();

                            if (findplowner.Count > 0)
                            {
                                cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(personemailid).ToList();
                            }


                            //var cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(personemailid).ToList();

                            var dddddddd = testlist.Union(personemailid).ToList();

                          
                            string aaaaa = "";
                            if (cclistfinal.Count > 0)
                            { 
                                for (int i = 0; i < cclistfinal.Count; i++)
                                {
                                    aaaaa = aaaaa + cclistfinal[i].PeMail;
                                }
                            }

                            string tttttt = "";
                            if (tolistfinal.Count > 0)
                            {
                                for (int i = 0; i < tolistfinal.Count; i++)
                                {
                                    tttttt = tttttt + tolistfinal[i].ParameterValue;
                                }
                            }

                            //cc = plowner +";" + pmomail + ";" + emgrmail + ";" + dmmail + ";" + personselfmailid;

                            string subject= string.Empty;
                            if (reasonLIst.Contains(model.Reason))
                            {
                                subject = "Onboarding Approval Required from Compliance/Finance Department " + empname + " to " + clientcode + "(Reason: " + reasondesc + ")";
                            }
                            else
                            {
                                subject = "Onboarding Approval Required from Compliance Department " + empname + " to " + clientcode + "(Reason: " + reasondesc + ")";
                            }

                            string ABCD = "<table  border='1'><tr><td>" +
            "<Table BgColor='lavender' border='1' bordercolor ='lightblue' style='font-size:12px;font-family:Arial'>" +
            "<TR><TD BgColor='lavender'><B>Client Code</TD><TD >&nbsp;" + clientcode + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Client Group</TD><TD >&nbsp;" + groupname + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Emp Name</TD><TD >&nbsp;" + empname + "</TD></TR>" +
             "<TR><TD BgColor='lavender'><B>Project Assignment Role</TD><TD >&nbsp;" + assignrole + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Allocation Percentage</TD><TD >&nbsp;" + model.Allocation + "</TD></TR>";
                            if (reasonLIst.Contains(model.Reason))
                            {
                                ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Billing Percentage</TD><TD >&nbsp;" + model.BillPercentage + "</TD></TR>";
                            }
                           
            ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Reason</TD><TD >&nbsp;" + reasondesc + "</TD></TR>";
                           

                            if (model.Reason.ToUpper()=="NBST1")
                            {
                                ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Replacing</TD><TD >&nbsp;" + empnamereplacewith + "</TD></TR>";
                            }


                            ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Department</TD><TD >&nbsp;" + departfullname + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Comments</TD><TD >&nbsp;" + model.comments + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Request ID</TD><TD >&nbsp;" + (model.ReqID == "-1" ? "NA" : model.ReqID) + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Kick off Date</TD><TD >&nbsp;" + model.KickOff + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Onboard By</TD><TD >&nbsp;" + empnamedonetransaction + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Entry Stamp</TD><TD >&nbsp;" + DateTime.Now + "</TD></TR>";
             //"<TR><TD BgColor='lavender'><B>TO ID</TD><TD >&nbsp;" + tttttt + "</TD></TR>" +
             // "<TR><TD BgColor='lavender'><B>CC</TD><TD >&nbsp;" + aaaaa + "</TD></TR>";




                            //ABCD = ABCD + case when @Reason = 'NBST1' then '<TR><TD BgColor="lavender"><B>Replacing</TD><TD >&nbsp;' + (select pe_name from EmployeeDataManagement..ip_person where pe_logn = @Replacing)+'</TD></TR>' else '' end;
                            //ABCD = ABCD + case when @Reason in('BNA', 'NBST5') then '<TR><TD BgColor="lavender"><B>Bill Start Date</TD><TD >&nbsp;' + convert(varchar(12), @BillStart, 106) + '</TD></TR>' else '' end;
                            //ABCD = ABCD + '<TR><TD BgColor="lavender"><B>Reporting To</TD><TD >&nbsp;' + (select pe_name from EmployeeDataManagement..ip_person where pe_logn = @ReportTo)+'</TD></TR>';
                            //ABCD = ABCD + '<TR><TD BgColor="lavender"><B>Kick off Date</TD><TD >&nbsp;' + convert(varchar(12), @KickOff, 106) + '</TD></TR>';
                            //ABCD = ABCD + '<TR><TD BgColor="lavender"><B>Request ID</TD><TD >&nbsp;' +case when @ReqID = '-1' then 'N/A' else @ReqID end+'</TD></TR>' +

                            //ABCD = ABCD + '<TR><TD BgColor="lavender"><B>Onboard By</TD><TD >&nbsp;' + (select isnull(pe_name, 'NA') from EmployeeDataManagement..ip_person where pe_logn = @Logn)+'</TD></TR>';
                            //ABCD = ABCD + '</Table></td></tr></Table>';

                            string msg =  "<body style='background-color:#cccccc;'>" +
"<table style='background-color:#ffffff;width:80%' border='0' align='center' cellpadding='0' cellspacing='0'>" +
 "<tr>" +
   "<td align='left' valign='top'>" +
"</td>" +
   "<td align='left' valign='top'>" + "<table style='padding:20px;'>" +
"<tr><td colspan='2'><span style='font-size: 20px; font-family: Arial'><b>Acuity Knowledge Partners</b></span><hr/></td></tr>" +

 "<tr>" +
   "<td colspan='2'>" +
 "<div style='height:10px;'></div>";

  msg = msg + ABCD +
   "</td>" +
   "</tr>" +
   "<tr>" +
   "<td colspan='2' align='center'>" +
   "<p>" +
   "</p>" +
   "</td>" +
   "</tr>" +
   "</table>" +
   "</td>" +
   "</tr>" +
   "</table><br/>" +
"<h6>Note: This is auto generated mail by system.</h6>" +
   "</body>";
                            string sdsdsd =string.Empty;

                            //string[] tomail11 = new string[dddddddd.Count];
                            //if (dddddddd.Count > 0)
                            //{
                            //    for (int i = 0; i < dddddddd.Count; i++)
                            //    {
                            //        tomail11[i] =  dddddddd[i].PeMail;
                            //    }
                            //}

                            string[] tomail11 = new string[tolistfinal.Count];
                            if (tolistfinal.Count > 0)
                            {
                                for (int i = 0; i < tolistfinal.Count; i++)
                                {
                                    tomail11[i] = tolistfinal[i].ParameterValue;
                                }
                            }

                            string[] ccmail11 = new string[cclistfinal.Count];
                            if (cclistfinal.Count > 0)
                            {
                                for (int i = 0; i < cclistfinal.Count; i++)
                                {
                                    ccmail11[i] = cclistfinal[i].PeMail;
                                }
                            }

                            if (mailsendingstatus.ToLower() == "true")
                            {

                                emailSendModel sendEmail = new emailSendModel();
                                string[] bccmail = { extraEmail };
                                //List<string> tomail = new List<string>(listFinal);

                                //string[] tomail =  dddddddd;
                                //string[] ccmail = { "rohit.sehgal@acuitykp.com" };
                                sendEmail.from = FromEmailAddress;
                                sendEmail.to = new List<string>(tomail11);
                                sendEmail.subject = subject;
                                sendEmail.body = msg;
                                sendEmail.isHTML = true;
                                //sendEmail.cc = new List<string>(ccmail);
                                sendEmail.cc = new List<string>(ccmail11);
                                sendEmail.bcc = new List<string>(bccmail);
                                //sendEmail.url = "http://10.50.5.120:3021/api/sendemailv2";
                                sendEmail.url = url; 

                                //bool mailResult = new Utilities().sendEmail(sendEmail);  

                                var handler = new HttpClientHandler();
                                handler.ServerCertificateCustomValidationCallback +=
                                                    (sender, certificate, chain, errors) =>
                                                    {
                                                        return true;
                                                    };
                                HttpClient client = new(handler);
                                var request = new HttpRequestMessage(HttpMethod.Post, url);
                                request.Headers.Add("Authorization", AuthorizationCode);
                                request.Content = JsonContent.Create(sendEmail);
                                var response1 = client.SendAsync(request).Result;

                            }

                            kickmodel.nstatus = "On-Boarded Successfully";
                        }
                        //SI =(from p in _repositorycontext.ExResourceassignmentstatuses where
                        //      p.PeLogn == model.PeLogn && p.CuIden == Convert.ToInt32(model.CuIden) && statusLister.Contains(p.Status) select  );

                       
                    }
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

        [HttpGet("OnboardRequestIDChanged/{ReqID}/{Group}/{cuiden}")]
        public IActionResult GetPeopleListForOffboard(string ReqID, string Group, string cuiden)
        {
            Dictionary<string, object> dList = new Dictionary<string, object>();
            Response response = new();
            try
            {
                 
                
                    var ResourceRequestDetail = (from a in _repositorycontext.ExResourcerequests
                                                 join b1 in _repositorycontext.ExResourcerequestRoles on a.ReqId equals b1.ReqId
                            into cp
                                                 from b1 in cp.DefaultIfEmpty()
                                                 //join b in _repositorycontext.ExResourcerequestRoles on a.ReqId equals b.ReqId
                                                     //ExResourcerequestRoles
                                                 where a.ReqId.ToString() == ReqID 
                                  select new
                                  {
                                      Reason = a != null ? a.ResourceReason : "",
                                    Allocation = b1!=null ? b1.ResourceAllocn.ToString() : "",
                                      Billpercent = b1 != null ?  b1.Billpercent.ToString() : ""
                                  }).Distinct().ToList();


                var ReasonListMaster = (from a in _repositorycontext.ExStatusdescs
                                                 where a.Status=="A"
                                                 orderby a.StatusDesc
                                                 select new
                                                 {
                                                     value = a.Level,
                                                     label = a.StatusDesc
                                                 }).Distinct().ToList();

                dList.Add("ResourceRequestDetail", ResourceRequestDetail); 
                dList.Add("ReasonListMaster", ReasonListMaster); 
                
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

        [HttpGet("OnboardGroupIDChanged/{cuiden}/{Group}/{pelogn}")]
        public IActionResult OnboardGroupIDChanged(string cuiden, string Group, string pelogn)
        {
            Dictionary<string, object> dList = new Dictionary<string, object>();
            Response response = new();
            try
            {
                var emplist = (from ipex in _edmdbcontext.ExIppeople  select ipex ).ToList();
                var ippersonlist = (from ipex in _edmdbcontext.IpPeople   select ipex).ToList();

                var ListResourceRequest = (from a in _repositorycontext.ExResourcerequests
                                   where a.Status == "A" && a.CuIden.ToString() == cuiden && a.GroupCode == Group
                                           select new
                                   {
                                       value=a.ReqId,
                                       label =a.ReqId
                                   }).Distinct().ToList();

                var data1 = (from a in _repositorycontext.ExResourceassignmentstatuses 
                             select a).ToList();
                var ExIpcustomerOthers = (from a in _repositorycontext.ExIpcustomerOthers select a).ToList();
                var data2 = (from a in _repositorycontext.ExResourceassignments where a.RepValognid !=null
                             select a).ToList();

                var ListReplacementeople = (from a in data1
                            join b1 in ippersonlist on a.PeLogn equals b1.PeLogn
                             into cp
                            from b1 in cp.DefaultIfEmpty()
                                //b1.pe_logn equals b2.pe_logn
                            join b2 in emplist on new
                            { User = b1 != null ? b1.PeLogn : "" }
                equals new { User = b2 != null ? b2.PeLogn : "" }

                            into cp1
                            from b2 in cp1.DefaultIfEmpty()
                //                            join b3 in data2 /*on a.PeLogn equals b3.RepValognid */
                //                            on new
                //                            { pelogn = a != null ? a.PeLogn : "" }
                //equals new { pelogn = b3 != null ? b3.RepValognid : "" }
                //                            into cp2
                //                            from b3 in cp2.DefaultIfEmpty()
                //                                // where b1 != null && b2 != null
                //                                //join c in ippersonlist on b.pe_logn equals c.pe_logn
                //                                //where a.AssetId == assetid
                                            where a.CuIden.ToString() == cuiden && a.ApproveStatus == "A" && a.Enddate == null && a.PeLogn != pelogn && a.Group == Group /*&& b2.QuitDateTemp==null*/
                                            //&& b3.ApproveStatus=="P" && b3.OnOff.ToString()=="0" && b3.CuIden.ToString() ==cuiden
                              orderby b1.PeName
                            select new
                            {
                               value = a.PeLogn,
                               label =b2!=null ? b1.PeName + "( " + b2.WwPersonId + " )" : b1.PeName
                            }).ToList();


             

                var ListProjectID = (from a in _repositorycontext.ExIpprojects
                                           where a.CuIden.ToString()==cuiden && a.Status=="A"
                                           select new
                                           {
                                               value = a.PrIden.ToString() ==null ? "0" : a.PrIden.ToString(),
                                               label = a.ProjectName == null ? "N/A" : a.ProjectName
                                           }).Distinct().ToList();
                 
 
                var MasterAbbrevationsList = (from ipex in _repositorycontext.MasterAbbrevations select ipex).ToList();
                var IpElementsList = (from ipex in _edmdbcontext.IpElements select ipex).ToList();
                var AccessMasterList = (from ipex in _repositorycontext.ExAccessMasters select ipex).ToList();

                var ServiceLineList = (from a in MasterAbbrevationsList
                                       join b in IpElementsList on a.Lob equals b.ElCode
                                     where a.Code ==Group
                                     select new
                                     {
                                         value = a.Lob,
                                         label = b.ElName 
                                     }).Distinct().ToList();

                var ProjectEnabledorDisabled = (from a in _repositorycontext.ExClientProjectIsEnables
                                                join b in _repositorycontext.MasterAbbrevations on a.ServiceLine equals b.Lob
                                                where a.CuIden.ToString() == cuiden && b.Code == Group && a.EndDate == null && a.Status == "A"
                                                select new
                                                {
                                                    a.Status
                                                }).Count();

                var OnbaordListDM = (from a in data1
                                                join b in ippersonlist on a.PeLogn equals b.PeLogn
                                                join c in MasterAbbrevationsList on b.PeDept equals c.Lob
                                                where a.Role =="DM" && a.CuIden.ToString() ==cuiden && a.Enddate == null && c.Code ==Group
                                                select new
                                                {
                                                    a.PeLogn,
                                                    b.PeName
                                                }).Union
                                                ((from a in AccessMasterList
                                                  join b in ippersonlist on a.PeLogn equals b.PeLogn
                                                  join c in MasterAbbrevationsList on b.PeDept equals c.Lob
                                                  where (a.Role == "PMO") &&  a.Enddate == null && c.Code == Group
                                                  select new
                                                  {
                                                      a.PeLogn,
                                                      b.PeName
                                                  })).Union
                                                  (from a in ExIpcustomerOthers
                                                   join b in ippersonlist on a.PeLogn equals b.PeLogn 
                                                   where a.Role == "EMGR" && a.CuIden.ToString() == cuiden && a.Enddate == null 
                                                   select new
                                                   {
                                                       a.PeLogn,
                                                       b.PeName
                                                   }).Distinct().ToList();

                var data21 = (from a in _repositorycontext.ExResourceassignmentstatuses 
                             select a).ToList();
                var ippersonlist1 = (from ipex in _edmdbcontext.IpPeople   select ipex).ToList(); 

                var LOBCode = (from a in MasterAbbrevationsList 
                                   where a.Code==Group 
                                   select new
                                   {
                                      LOb = a.Lob

                                   }).ToList();

                var ListBenchResource = (from a in data21
                                         join b1 in ippersonlist1.ToList() on new
                                         { User = a != null ? a.PeLogn : "" }
                                                     equals new { User = b1 != null ? b1.PeLogn : "" }

                                                                 into cp
                                         from b1 in cp.DefaultIfEmpty()
                                         where a.CuIden.ToString() == "85" && a.Enddate == null && a.Status == "B" /*&& c.Code ==Group*/
                                         select new
                                         {
                                             value = b1 != null ? a.PeLogn : "",
                                             label = b1 != null ? b1.PeName : "",
                                             PeQuit = b1 != null ? b1.PeQuit :  null
                                         }).Distinct().ToList();

                var query4 = ListBenchResource.Where(x => x.PeQuit == null).Select(x => x.value).ToList();


                var query2 = (from pp in _repositorycontext.ExResourceallocations
                              where pp.AllocEnddate ==null
                              group pp by pp.PeLogn into group2
                              select new
                              {
                                  Pelogn = group2.Key,
                                  Allocation = group2.Sum(c => c.Allocation)
                              }).ToList();

                var query3 = query2.Where(x => x.Allocation < 100).Select(x => x.Pelogn).ToList();

                var finallist = query4.Union(query3);

                var ListBenchResourceFinal = (from a in ippersonlist1
                                              join b1 in emplist.ToList() on new
                                              { User = a != null ? a.PeLogn : "" }
                                                   equals new { User = b1 != null ? b1.PeLogn : "" }

                                                               into cp
                                              from b1 in cp.DefaultIfEmpty()
                                              where finallist.Contains(a.PeLogn) && a.PeDept==LOBCode[0].LOb
                                         select new
                                         {
                                           value = a.PeLogn,
                                           label =b1!=null ? a.PeName.ToUpper() + " (" + b1.WwPersonId + ")" :""
                                         }).Distinct().ToList(); 


                dList.Add("ListResourceRequest", ListResourceRequest); 
                dList.Add("ListReplacementeople", ListReplacementeople); 
                dList.Add("ListProjectID", ListProjectID); 
                dList.Add("ServiceLineList", ServiceLineList); 
                dList.Add("ProjectEnabledorDisabled", ProjectEnabledorDisabled); 
                dList.Add("OnbaordListDM", OnbaordListDM); 
                //dList.Add("ListBenchResource", ListBenchResource); 
                dList.Add("ListBenchResourceFinal", ListBenchResourceFinal); 
                //dList.Add("ListBenchResource", ListBenchResource); 

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

        [HttpGet("GetPendingOnboardTransaction/{pelogin}")]
        public IActionResult GetPendingOnboardTransaction(string pelogin)
        {
            Dictionary<string, object> dList = new Dictionary<string, object>();
            Response response = new();
            try
            {
                string role = string.Empty;
                Core core = new(_repositorycontext, _edmdbcontext);
                role = core.uFn_LoginCheck(pelogin);
             
                string dept = core.getdepartment(pelogin);

                //string[] roleList = { "ADMIN", "EMGR", "CDH" };
                var ExResourceassignmentstatuses = (from a in _repositorycontext.ExResourceassignmentstatuses select a).ToList();
                var ExResourceassignment = (from a in _repositorycontext.ExResourceassignments select a).ToList();
                var IPCustomerlist = (from a in _repositorycontext.IpCustomers select a).ToList();
                var ChecklistList = (from a in _repositorycontext.ExResourceassignmentChecklists select a).ToList();
                var IpPersonList = (from a in _edmdbcontext.IpPeople where a.PeQuit==null select a).ToList();
                var IPElementList = (from a in _edmdbcontext.IpElements select a).ToList();
                DateTime todaydate = DateTime.Now;
                var ITchecklistid = "7"; 

                if (role == "DM")
                {
                    var IPCustomerlist1 = (from a in _repositorycontext.ExResourceassignmentstatuses 
                                      join b in _repositorycontext.IpCustomers on a.CuIden equals b.CuIden
                                      where a.Role=="DM" && a.Enddate ==null && a.PeLogn==pelogin
                                      select b).ToList();

                    var result = (from a in ExResourceassignment
                                  join b in ExResourceassignmentstatuses on a.PeLogn equals b.PeLogn into sb
                                   from b in sb.DefaultIfEmpty()
                                  join c in IpPersonList on a.PeLogn equals c.PeLogn into sc 
                                  from c in sc.DefaultIfEmpty()
                                  join d in IPCustomerlist1 on a.CuIden equals d.CuIden into sc1
                                  from d in sc1.DefaultIfEmpty()
                                  join e in IPElementList 
                                   on new
                                   { Dept = c != null ? c.PeDept : "" }
                    equals new { Dept = e != null ? e.ElCode : "" } into sc2
                                  from e in sc2.DefaultIfEmpty() 
                                  join f in ChecklistList
                                  on new
                                  { Checklist = a != null ? a.Id.ToString() : ""  }
                   equals new { Checklist = f != null ? f.Id.ToString() : ""  } into sc3
                                  from f in sc3.DefaultIfEmpty()
                                  join g in ChecklistList
                                on new
                                { Checklist = a != null ? a.Id.ToString() : "" }
                 equals new { Checklist = g != null ? g.Id.ToString() : "" } into sc4
                                  from g in sc4.DefaultIfEmpty()
                                  join h in ChecklistList
                               on new
                               { Checklist = a != null ? a.Id.ToString() : "" }
                equals new { Checklist = h != null ? h.Id.ToString() : "" } into sc5
                                  from h in sc5.DefaultIfEmpty()
                                  join i in ChecklistList
                              on new
                              { Checklist = a != null ? a.Id.ToString() : "" }
               equals new { Checklist = i != null ? i.Id.ToString() : "" } into sc6
                                  from i in sc6.DefaultIfEmpty()
                                  where a.ApproveStatus=="P" &&  a.KickOffDate==b.KickOff && a.CuIden==b.CuIden && a.OnOff==0 && f.ChecklistId.ToString()=="7" && g.ChecklistId.ToString() == "6"
                                   && h.ChecklistId.ToString() == "8" && i.ChecklistId.ToString() == "9" && c.PeDept==dept  && a.CuIden !=null
                                  //orderby b != null ? b.PeName : ""
                                  select new
                                  {
                                      PeName = c!=null ?  c.PeName :"",
                                      CuComp = d!=null ? d.CuComp : "",
                                      e.ElName,
                                      a.Id,
                                      a.PeLogn,
                                      a.CuIden,
                                      a.PeLmgr,
                                      a.ReqId,
                                      a.Reason,
                                      a.BillDate,
                                      a.RepValognid,
                                      a.Allocation,
                                      a.OnOff,
                                      a.Groups,
                                      KickOffDate= a.KickOffDate.Value.ToString("yyyy-MM-dd"),
                                      DateOfSelectionOrMove= a.DateOfSelectionOrMove.Value.ToString("yyyy-MM-dd"),
                                      a.AssignType,
                                      a.Billpercent,
                                      a.Sow,
                                      a.ReasonDetail,
                                      a.ResgclntComment,
                                      a.ProjId,
                                      a.OnboardComments,
                                      a.ComplComment,
                                      a.ComplianceStatus,
                                      a.FinanceStatus, 
                                      DateDIff = todaydate.Subtract(a.Entrystamp.Value).TotalDays.ToString(),
                                      Entrystamp =  a.Entrystamp.Value.ToString("yyyy-MM-dd"),
                                      EmailAccessStatus = f!=null ? f.YesNoInd :"",
                                      EmailAccessComments = f != null ? f.Comments : "",
                                      FolderAccessStatus = g != null ? g.YesNoInd :"",
                                      FolderAccessComments = g != null ?  g.Comments : "",
                                      ClientRoomDetail = g != null ?  h.Comments : "",
                                      WorkStaionDetail = i != null ? i.Comments :""
                                      //TimeSpentInSeconds = at.Sum(p => p.AccessedDate.Value.Subtract(p.CreatedDate).TotalSeconds),
                                      //ParticipantId = at.Key
                                      //DateDIFFdd  = (todaydate - a.Entrystamp).to
                                      //a.Entrystamp((p => a.Entrystamp.datediff)   Allocation.Sum(t => t.Allocation);
                                  }).Distinct().ToList();

                    dList.Add("Table", result);

                }
                else if (role == "EMGR")
                {
                    var IPCustomerlist2 = (from a in _repositorycontext.ExIpcustomerOthers
                                           join b in _repositorycontext.IpCustomers on a.CuIden equals b.CuIden
                                           where a.Role.ToUpper() == "EMGR" && a.Enddate == null && a.PeLogn == pelogin && a.Status=="A"
                                           select b.CuIden.ToString()).ToList();

                    var result = (from a in ExResourceassignment
                                  join b in ExResourceassignmentstatuses on a.PeLogn equals b.PeLogn into sb
                                  from b in sb.DefaultIfEmpty()
                                  join c in IpPersonList on a.PeLogn equals c.PeLogn into sc
                                  from c in sc.DefaultIfEmpty()
                                  join d in IPCustomerlist on a.CuIden equals d.CuIden into sc1
                                  from d in sc1.DefaultIfEmpty()
                                  join e in IPElementList
                                   on new
                                   { Dept = c != null ? c.PeDept : "" }
                    equals new { Dept = e != null ? e.ElCode : "" } into sc2
                                  from e in sc2.DefaultIfEmpty()
                                  join f in ChecklistList
                                  on new
                                  { Checklist = a != null ? a.Id.ToString() : "" }
                   equals new { Checklist = f != null ? f.Id.ToString() : "" } into sc3
                                  from f in sc3.DefaultIfEmpty()
                                  join g in ChecklistList
                                on new
                                { Checklist = a != null ? a.Id.ToString() : "" }
                 equals new { Checklist = g != null ? g.Id.ToString() : "" } into sc4
                                  from g in sc4.DefaultIfEmpty()
                                  join h in ChecklistList
                               on new
                               { Checklist = a != null ? a.Id.ToString() : "" }
                equals new { Checklist = h != null ? h.Id.ToString() : "" } into sc5
                                  from h in sc5.DefaultIfEmpty()
                                  join i in ChecklistList
                              on new
                              { Checklist = a != null ? a.Id.ToString() : "" }
               equals new { Checklist = i != null ? i.Id.ToString() : "" } into sc6
                                  from i in sc6.DefaultIfEmpty()
                                  where a.ApproveStatus == "P" && a.KickOffDate == b.KickOff && a.CuIden == b.CuIden && a.OnOff == 0 && f.ChecklistId.ToString() == "7" && g.ChecklistId.ToString() == "6"
                                   && h.ChecklistId.ToString() == "8" && i.ChecklistId.ToString() == "9"  && IPCustomerlist2.Contains(a.CuIden.ToString())
                                  //orderby b != null ? b.PeName : ""
                                  select new
                                  {
                                      PeName = c != null ? c.PeName : "",
                                      d.CuComp,
                                      e.ElName,
                                      a.Id,
                                      a.PeLogn,
                                      a.CuIden,
                                      a.PeLmgr,
                                      a.ReqId,
                                      a.Reason,
                                      a.BillDate,
                                      a.RepValognid,
                                      a.Allocation,
                                      a.OnOff,
                                      a.Groups,
                                      KickOffDate = a.KickOffDate.Value.ToString("yyyy-MM-dd"),
                                      DateOfSelectionOrMove = a.DateOfSelectionOrMove.Value.ToString("yyyy-MM-dd"),
                                      a.AssignType,
                                      a.Billpercent,
                                      a.Sow,
                                      a.ReasonDetail,
                                      a.ResgclntComment,
                                      a.ProjId,
                                      a.OnboardComments,
                                      a.ComplComment,
                                      a.ComplianceStatus,
                                      a.FinanceStatus,
                                      DateDIff = todaydate.Subtract(a.Entrystamp.Value).TotalDays.ToString(),
                                      Entrystamp = a.Entrystamp.Value.ToString("yyyy-MM-dd"),
                                      EmailAccessStatus = f.YesNoInd,
                                      EmailAccessComments = f.Comments,
                                      FolderAccessStatus = g.YesNoInd,
                                      FolderAccessComments = g.Comments,
                                      ClientRoomDetail = h.Comments,
                                      WorkStaionDetail = i.Comments
                                  }).Distinct().ToList();

                    dList.Add("Table", result);



                }
                else if (role == "PMO")
                {
                    var ServiceLineList = (from a in _repositorycontext.ExAccessMasters 
                                           where a.Role.ToUpper() == "PMO" && a.Enddate == null && a.PeLogn == pelogin && a.Status == "A"
                                           select a.ServiceLine).ToList();

                    var result = (from a in ExResourceassignment
                                  join b in ExResourceassignmentstatuses on a.PeLogn equals b.PeLogn into sb
                                  from b in sb.DefaultIfEmpty()
                                  join c in IpPersonList on a.PeLogn equals c.PeLogn into sc
                                  from c in sc.DefaultIfEmpty()
                                  join d in IPCustomerlist on a.CuIden equals d.CuIden into sc1
                                  from d in sc1.DefaultIfEmpty()
                                  join e in IPElementList
                                   on new
                                   { Dept = c != null ? c.PeDept : "" }
                    equals new { Dept = e != null ? e.ElCode : "" } into sc2
                                  from e in sc2.DefaultIfEmpty()
                                  join f in ChecklistList
                                  on new
                                  { Checklist = a != null ? a.Id.ToString() : "" }
                   equals new { Checklist = f != null ? f.Id.ToString() : "" } into sc3
                                  from f in sc3.DefaultIfEmpty()
                                  join g in ChecklistList
                                on new
                                { Checklist = a != null ? a.Id.ToString() : "" }
                 equals new { Checklist = g != null ? g.Id.ToString() : "" } into sc4
                                  from g in sc4.DefaultIfEmpty()
                                  join h in ChecklistList
                               on new
                               { Checklist = a != null ? a.Id.ToString() : "" }
                equals new { Checklist = h != null ? h.Id.ToString() : "" } into sc5
                                  from h in sc5.DefaultIfEmpty()
                                  join i in ChecklistList
                              on new
                              { Checklist = a != null ? a.Id.ToString() : "" }
               equals new { Checklist = i != null ? i.Id.ToString() : "" } into sc6
                                  from i in sc6.DefaultIfEmpty()
                                  where a.ApproveStatus == "P" && a.KickOffDate == b.KickOff && a.CuIden == b.CuIden && a.OnOff == 0 && f.ChecklistId.ToString() == "7" && g.ChecklistId.ToString() == "6"
                                   && h.ChecklistId.ToString() == "8" && i.ChecklistId.ToString() == "9" && ServiceLineList.Contains(c.PeDept)
                                  //orderby b != null ? b.PeName : ""
                                  select new
                                  {
                                      PeName = c != null ? c.PeName : "",
                                      d.CuComp,
                                      e.ElName,
                                      a.Id,
                                      a.PeLogn,
                                      a.CuIden,
                                      a.PeLmgr,
                                      a.ReqId,
                                      a.Reason,
                                      a.BillDate,
                                      a.RepValognid,
                                      a.Allocation,
                                      a.OnOff,
                                      a.Groups,
                                      KickOffDate = a.KickOffDate.Value.ToString("yyyy-MM-dd"),
                                      DateOfSelectionOrMove = a.DateOfSelectionOrMove.Value.ToString("yyyy-MM-dd"),
                                      a.AssignType,
                                      a.Billpercent,
                                      a.Sow,
                                      a.ReasonDetail,
                                      a.ResgclntComment,
                                      a.ProjId,
                                      a.OnboardComments,
                                      a.ComplComment,
                                      a.ComplianceStatus,
                                      a.FinanceStatus,
                                      DateDIff = todaydate.Subtract(a.Entrystamp.Value).TotalDays.ToString(),
                                      Entrystamp = a.Entrystamp.Value.ToString("yyyy-MM-dd"),
                                      EmailAccessStatus = f.YesNoInd,
                                      EmailAccessComments = f.Comments,
                                      FolderAccessStatus = g.YesNoInd,
                                      FolderAccessComments = g.Comments,
                                      ClientRoomDetail = h.Comments,
                                      WorkStaionDetail = i.Comments
                                  }).Distinct().ToList();

                    dList.Add("Table", result);



                }

                else if (role == "PL")
                {
                    var ServiceLineList = (from a in _repositorycontext.ExClientPlOwners
                                           where a.Enddate == null && a.PeLogn == pelogin && a.Status == "A"
                                           select a.ServiceLine).ToList();

                    var result = (from a in ExResourceassignment
                                  join b in ExResourceassignmentstatuses on a.PeLogn equals b.PeLogn into sb
                                  from b in sb.DefaultIfEmpty()
                                  join c in IpPersonList on a.PeLogn equals c.PeLogn into sc
                                  from c in sc.DefaultIfEmpty()
                                  join d in IPCustomerlist on a.CuIden equals d.CuIden into sc1
                                  from d in sc1.DefaultIfEmpty()
                                  join e in IPElementList
                                   on new
                                   { Dept = c != null ? c.PeDept : "" }
                    equals new { Dept = e != null ? e.ElCode : "" } into sc2
                                  from e in sc2.DefaultIfEmpty()
                                  join f in ChecklistList
                                  on new
                                  { Checklist = a != null ? a.Id.ToString() : "" }
                   equals new { Checklist = f != null ? f.Id.ToString() : "" } into sc3
                                  from f in sc3.DefaultIfEmpty()
                                  join g in ChecklistList
                                on new
                                { Checklist = a != null ? a.Id.ToString() : "" }
                 equals new { Checklist = g != null ? g.Id.ToString() : "" } into sc4
                                  from g in sc4.DefaultIfEmpty()
                                  join h in ChecklistList
                               on new
                               { Checklist = a != null ? a.Id.ToString() : "" }
                equals new { Checklist = h != null ? h.Id.ToString() : "" } into sc5
                                  from h in sc5.DefaultIfEmpty()
                                  join i in ChecklistList
                              on new
                              { Checklist = a != null ? a.Id.ToString() : "" }
               equals new { Checklist = i != null ? i.Id.ToString() : "" } into sc6
                                  from i in sc6.DefaultIfEmpty()
                                  where a.ApproveStatus == "P" && a.KickOffDate == b.KickOff && a.CuIden == b.CuIden && a.OnOff == 0 && f.ChecklistId.ToString() == "7" && g.ChecklistId.ToString() == "6"
                                   && h.ChecklistId.ToString() == "8" && i.ChecklistId.ToString() == "9" && ServiceLineList.Contains(c.PeDept)
                                  //orderby b != null ? b.PeName : ""
                                  select new
                                  {
                                      PeName = c != null ? c.PeName : "",
                                      d.CuComp,
                                      e.ElName,
                                      a.Id,
                                      a.PeLogn,
                                      a.CuIden,
                                      a.PeLmgr,
                                      a.ReqId,
                                      a.Reason,
                                      a.BillDate,
                                      a.RepValognid,
                                      a.Allocation,
                                      a.OnOff,
                                      a.Groups,
                                      KickOffDate = a.KickOffDate.Value.ToString("yyyy-MM-dd"),
                                      DateOfSelectionOrMove = a.DateOfSelectionOrMove.Value.ToString("yyyy-MM-dd"),
                                      a.AssignType,
                                      a.Billpercent,
                                      a.Sow,
                                      a.ReasonDetail,
                                      a.ResgclntComment,
                                      a.ProjId,
                                      a.OnboardComments,
                                      a.ComplComment,
                                      a.ComplianceStatus,
                                      a.FinanceStatus,
                                      DateDIff = todaydate.Subtract(a.Entrystamp.Value).TotalDays.ToString(),
                                      Entrystamp = a.Entrystamp.Value.ToString("yyyy-MM-dd"),
                                      EmailAccessStatus = f.YesNoInd,
                                      EmailAccessComments = f.Comments,
                                      FolderAccessStatus = g.YesNoInd,
                                      FolderAccessComments = g.Comments,
                                      ClientRoomDetail = h.Comments,
                                      WorkStaionDetail = i.Comments
                                  }).Distinct().ToList();

                    dList.Add("Table", result);



                }
                else
                {
                    var result = (from a in ExResourceassignment
                                  join b in ExResourceassignmentstatuses on a.PeLogn equals b.PeLogn into sb
                                  from b in sb.DefaultIfEmpty()
                                  join c in IpPersonList on a.PeLogn equals c.PeLogn into sc
                                  from c in sc.DefaultIfEmpty()
                                  join d in IPCustomerlist on a.CuIden equals d.CuIden into sc1
                                  from d in sc1.DefaultIfEmpty()
                                  join e in IPElementList
                                   on new
                                   { Dept = c != null ? c.PeDept : "" }
                    equals new { Dept = e != null ? e.ElCode : "" } into sc2
                                  from e in sc2.DefaultIfEmpty()
                                  join f in ChecklistList
                                  on new
                                  { Checklist = a != null ? a.Id.ToString() : "" }
                   equals new { Checklist = f != null ? f.Id.ToString() : "" } into sc3
                                  from f in sc3.DefaultIfEmpty()
                                  join g in ChecklistList
                                on new
                                { Checklist = a != null ? a.Id.ToString() : "" }
                 equals new { Checklist = g != null ? g.Id.ToString() : "" } into sc4
                                  from g in sc4.DefaultIfEmpty()
                                  join h in ChecklistList
                               on new
                               { Checklist = a != null ? a.Id.ToString() : "" }
                equals new { Checklist = h != null ? h.Id.ToString() : "" } into sc5
                                  from h in sc5.DefaultIfEmpty()
                                  join i in ChecklistList
                              on new
                              { Checklist = a != null ? a.Id.ToString() : "" }
               equals new { Checklist = i != null ? i.Id.ToString() : "" } into sc6
                                  from i in sc6.DefaultIfEmpty()
                                  where a.ApproveStatus == "P" && a.KickOffDate == b.KickOff && a.CuIden == b.CuIden && a.OnOff == 0 && f.ChecklistId.ToString() == "7" && g.ChecklistId.ToString() == "6"
                                   && h.ChecklistId.ToString() == "8" && i.ChecklistId.ToString() == "9" 
                                  //orderby b != null ? b.PeName : ""
                                  select new
                                  {
                                      PeName = c != null ? c.PeName : "",
                                      d.CuComp,
                                      e.ElName,
                                      a.Id,
                                      a.PeLogn,
                                      a.CuIden,
                                      a.PeLmgr,
                                      a.ReqId,
                                      a.Reason,
                                      a.BillDate,
                                      a.RepValognid,
                                      a.Allocation,
                                      a.OnOff,
                                      a.Groups,
                                      KickOffDate = a.KickOffDate.Value.ToString("yyyy-MM-dd"),
                                      DateOfSelectionOrMove = a.DateOfSelectionOrMove.Value.ToString("yyyy-MM-dd"),
                                      a.AssignType,
                                      a.Billpercent,
                                      a.Sow,
                                      a.ReasonDetail,
                                      a.ResgclntComment,
                                      a.ProjId,
                                      a.OnboardComments,
                                      a.ComplComment,
                                      a.ComplianceStatus,
                                      a.FinanceStatus,
                                      DateDIff = todaydate.Subtract(a.Entrystamp.Value).TotalDays.ToString(),
                                      Entrystamp = a.Entrystamp.Value.ToString("yyyy-MM-dd"),
                                      EmailAccessStatus = f.YesNoInd,
                                      EmailAccessComments = f.Comments,
                                      FolderAccessStatus = g.YesNoInd,
                                      FolderAccessComments = g.Comments,
                                      ClientRoomDetail = h.Comments,
                                      WorkStaionDetail = i.Comments 
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


        [HttpPost("GetClientListChange")]
        public IActionResult GetClientListChange(OnlineOffline model)
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
                    response.Data = "";
                    response.Error = "Atleast one record required";
                    return Ok(response);
                }
                else
                {
                    //table0
                    int cnt = 0;
                    if (model.CU_IDEN == 85)
                    {
                        var data0 = (from a in _edmdbcontext.IpElements
                                     where a.CaCode == "CLNT"
                                     orderby a.ElName
                                     select
                                     new
                                     {
                                         Type = a.ElName.ToUpper(),
                                         El_Code = a.ElCode

                                     }).Distinct().ToList();
                        dList.Add("Table0", data0);
                        //response.Data = data0;

                    }
                    else if (model.CU_IDEN != 85)
                    {
                        var ipElements = (from El in _edmdbcontext.IpElements select El).ToList();
                        cnt = (from El in ipElements
                               join
                               Ex in _repositorycontext.ExIpcustomers on El.ElCode equals Ex.Clienttype
                               where Ex.CuIden == model.CU_IDEN && El.CaCode == "CLNT"
                               select new
                               {
                                   El.CaCode
                               }
                             ).ToList().Count;

                    }
                    if (cnt > 0)
                    {
                        var ipElements = (from El in _edmdbcontext.IpElements select El).ToList();
                        var data0 = (from El in ipElements
                                     join
                                    Ex in _repositorycontext.ExIpcustomers on El.ElCode equals Ex.Clienttype
                                     where Ex.CuIden == model.CU_IDEN && El.CaCode == "CLNT"
                                     orderby El.ElName
                                     select new
                                     {
                                         El.CaCode,
                                         Type = El.ElName.ToUpper()
                                     }
                             ).Distinct().ToList();
                        dList.Add("Table0", data0);

                    }
                    else
                    {
                        var data0 = (from a in _edmdbcontext.IpElements
                                     where a.CaCode == "CLNT"
                                     orderby a.ElName
                                     select
                                     new
                                     {
                                         Type = a.ElName.ToUpper(),
                                         El_Code = a.ElCode

                                     }).Distinct().ToList();
                        dList.Add("Table0", data0);

                    }

                    //table1
                    string role = string.Empty;
                    Core core = new(_repositorycontext, _edmdbcontext);
                    role = core.uFn_LoginCheck(model.PE_LOGN);
                    string dept = string.Empty;
                    var deptvar = (from a in _edmdbcontext.IpPeople
                                   where a.PeLogn == model.PE_LOGN && a.PeQuit == null
                                   select new
                                   {
                                       pe_dept = a.PeDept

                                   }).ToList();
                    if (deptvar.Count > 0)
                    {
                        dept = deptvar[0].pe_dept;
                    }
                    string[] roleList = { "ADMIN", "EMGR", "CDH" };
                    if (roleList.Contains(role))
                    {
                        var subquery = (from a in _repositorycontext.ExClientServicelines where a.CuIden == model.CU_IDEN && a.Enddate == null && a.Status == "A" select a).ToList();
                        string[] serviceLine = new string[subquery.Count + 1];
                        if (subquery.Count > 0)
                        {
                            for (int i = 0; i < subquery.Count; i++)
                            {
                                serviceLine[i] = subquery[i].ServiceLine;
                            }


                        }
                        var ipElements = (from El in _edmdbcontext.IpElements select El).ToList();
                        var abbrevations = (from a in _repositorycontext.MasterAbbrevations select a).ToList();
                        var data1 = (from a in abbrevations
                                     join
                                      b in ipElements on a.Code equals b.ElCode into cs
                                     from b in cs.DefaultIfEmpty()
                                     where serviceLine.Contains(a.Lob) && (b != null) ? b.ElName != null : false
                                     orderby b.ElName
                                     select new
                                     {
                                         Group = (a != null) ? a.Code != null ? a.Code : default(string) : default(string),
                                         ClientGroup = (b != null) ? b.ElName != null ? b.ElName.ToUpper() : default(string) : default(string),
                                     }

                                   ).ToList();
                        dList.Add("Table1", data1);
                    }
                    else if (role == "PMO")
                    {
                        var subquery = (from a in _repositorycontext.ExAccessMasters where a.PeLogn == model.PE_LOGN && a.Enddate == null && a.Status == "A" select a).ToList();
                        string[] serviceLine = new string[subquery.Count + 1];
                        if (subquery.Count > 0)
                        {
                            for (int i = 0; i < subquery.Count; i++)
                            {
                                serviceLine[i] = subquery[i].ServiceLine;
                            }


                        }
                        var ipElements = (from El in _edmdbcontext.IpElements select El).ToList();
                        var abbrevations = (from a in _repositorycontext.MasterAbbrevations select a).ToList();

                        var data1 = (from a in abbrevations
                                     join
                                      b in ipElements on a.Code equals b.ElCode into cs
                                     from b in cs.DefaultIfEmpty()
                                     where serviceLine.Contains(a.Lob) && (b != null) ? b.ElName != null : false
                                     orderby b.ElName
                                     select new
                                     {
                                         Group = (a != null) ? a.Code != null ? a.Code : default(string) : default(string),
                                         ClientGroup = (b != null) ? b.ElName != null ? b.ElName.ToUpper() : default(string) : default(string),
                                     }

                                   ).ToList();
                        dList.Add("Table1", data1);

                    }
                    else if (role == "PL")
                    {
                        var subquery = (from a in _repositorycontext.ExClientPlOwners where a.PeLogn == model.PE_LOGN && a.Enddate == null && a.Status == "A" select a).ToList();
                        string[] serviceLine = new string[subquery.Count];
                        if (subquery.Count > 0)
                        {
                            for (int i = 0; i < subquery.Count; i++)
                            {
                                serviceLine[i] = subquery[i].ServiceLine;
                            }


                        }
                        var ipElements = (from El in _edmdbcontext.IpElements select El).ToList();
                        var abbrevations = (from a in _repositorycontext.MasterAbbrevations select a).ToList();
                        var data1 = (from a in abbrevations
                                     join
                                      b in ipElements on a.Code equals b.ElCode into cs
                                     from b in cs.DefaultIfEmpty()
                                     where serviceLine.Contains(a.Lob) && (b != null) ? b.ElName != null : false
                                     orderby b.ElName
                                     select new
                                     {
                                         Group = (a != null) ? a.Code != null ? a.Code : default(string) : default(string),
                                         ClientGroup = (b != null) ? b.ElName != null ? b.ElName.ToUpper() : default(string) : default(string),
                                     }

                                   ).ToList();
                        dList.Add("Table1", data1);


                    }
                    else if (dept == "MATKM")
                    {
                        var subquery = (from a in _repositorycontext.ExClientServicelines where a.CuIden == model.CU_IDEN && a.Enddate == null && a.Status == "A" select a).ToList();
                        string[] serviceLine = new string[subquery.Count + 1];
                        if (subquery.Count > 0)
                        {
                            for (int i = 0; i < subquery.Count; i++)
                            {
                                serviceLine[i] = subquery[i].ServiceLine;
                            }


                        }
                        var ipElements = (from El in _edmdbcontext.IpElements select El).ToList();
                        var abbrevations = (from a in _repositorycontext.MasterAbbrevations select a).ToList();
                        var data1 = (from a in abbrevations
                                     join
                                      b in ipElements on a.Code equals b.ElCode into cs
                                     from b in cs.DefaultIfEmpty()
                                     where serviceLine.Contains(a.Lob) && (b != null) ? b.ElName != null : false
                                     orderby b.ElName
                                     select new
                                     {
                                         Group = (a != null) ? a.Code != null ? a.Code : default(string) : default(string),
                                         ClientGroup = (b != null) ? b.ElName != null ? b.ElName.ToUpper() : default(string) : default(string),
                                     }

                                   ).ToList();
                        dList.Add("Table1", data1);

                    }
                    else
                    {
                        var subquery = (from a in _edmdbcontext.IpPeople where a.PeLogn == model.PE_LOGN && a.PeQuit == null select a).ToList();
                        string[] serviceLine = new string[subquery.Count];
                        if (subquery.Count > 0)
                        {
                            for (int i = 0; i < subquery.Count; i++)
                            {
                                serviceLine[i] = subquery[i].PeDept;
                            }


                        }
                        var ipElements = (from El in _edmdbcontext.IpElements select El).ToList();
                        var abbrevations = (from a in _repositorycontext.MasterAbbrevations select a).ToList();
                        var data1 = (from a in abbrevations
                                     join
                                      b in ipElements on a.Code equals b.ElCode into cs
                                     from b in cs.DefaultIfEmpty()
                                     where
                                     (b != null) ? b.ElName != null : false

                                     &&
                                     serviceLine.Contains(a.Lob)
                                     orderby b.ElName
                                     select new
                                     {
                                         Group = (a != null) ? a.Code != null ? a.Code : default(string) : default(string),
                                         ClientGroup = (b != null) ? b.ElName != null ? b.ElName.ToUpper() : default(string) : default(string),
                                     }

                                   ).ToList();
                        dList.Add("Table1", data1);
                    }

                    //string[] typeList = { "P", "B" };
                    //string[] levelList = { "BP", "BR" };
                    //List<StatusModel> statusList = (from a in _repositorycontext.ExStatusdescs
                    //                                where typeList.Contains(a.Type) && a.OnOff == 0 && a.Status == "A" && !levelList.Contains(a.Level)
                    //                                orderby a.Sl
                    //                                select new StatusModel
                    //                                {
                    //                                    Sl = a!=null ? (int)a.StatusLevelId : 0,
                    //                                    Status = a != null ?  a.StatusIndicator :"",
                    //                                    OnboardStatus = a != null ?  a.Level :"",
                    //                                    Reason = a != null ?  a.StatusShortDesc :"",
                    //                                    Flag = 0
                    //                                }).ToList();
                    //if (model.CU_IDEN != 85 && model.CU_IDEN != 206 && model.CU_IDEN != 207)
                    //{
                    //    // statusList=statusList.Remove()
                    //    var statusListvar = statusList.Where(a => a.OnboardStatus == "NPIT");
                    //    statusList = statusList.Except(statusListvar).ToList();
                    //}
                    //if (model.CU_IDEN != 85 && model.CU_IDEN != 206 && model.CU_IDEN != 207)
                    //{
                    //    var statusListvar = statusList.Where(a => a.OnboardStatus == "NPNJ" && a.Reason == "New Joinee");
                    //    statusList = statusList.Except(statusListvar).ToList();

                    //}
                    //if (model.Req_Id == "N/A")
                    //{

                    //}
                    //else
                    //{
                    //    //var updateQuery=(from a in _repositorycontext.ExResourcerequests where a.ReqId==model.Req_Id select new
                    //    //{
                    //    //    Resource_Reason=a.
                    //    //})

                    //}
                    //dList.Add("Table2", statusList);



                    if (role == "Admin")
                    {
                        var data3 = (from a in _repositorycontext.ExSownumbers
                                     where a.CuIden == model.CU_IDEN && a.Status == "A"
                                     orderby a.SowNumber
                                     select new
                                     {
                                         sownumber = a.SowNumber,
                                         FileName = a.FileName
                                     }
                                   ).ToList();
                        dList.Add("Table3", data3);
                    }
                    else
                    {

                        var dept3 = (from a in _edmdbcontext.IpPeople
                                     where a.PeLogn == model.PE_LOGN && a.PeQuit == null
                                     select new
                                     {
                                         pe_dept = a.PeDept

                                     }).ToList();
                        string[] deptcomp = new string[dept3.Count + 1];
                        if (dept3.Count > 0)
                        {
                            for (int i = 0; i < dept3.Count; i++)
                            {
                                deptcomp[i] = dept3[i].pe_dept;

                            }

                        }
                        var data3 = (from a in _repositorycontext.ExSownumbers
                                     where a.CuIden == model.CU_IDEN && a.Status == "A" && deptcomp.Contains(a.ElCode)
                                     orderby a.SowNumber
                                     select new
                                     {
                                         sownumber = a.SowNumber,
                                         FileName = a.FileName
                                     }
                                   ).ToList();
                        dList.Add("Table3", data3);

                    }

                    var data4 = (from a in _repositorycontext.ExCuIdenSowIsmandates
                                 where a.Status == "A" && a.Enddate == null && a.CuIden == model.CU_IDEN
                                 select new
                                 {
                                     ISSOWMANDATE = a.Issowmandate
                                 }
                               ).ToList();
                    dList.Add("Table4", data4);
                    var ExResourceassignmentstatuses = (from a in _repositorycontext.ExResourceassignmentstatuses select a).ToList();
                    //debugging
                    var ipperson = (from b in _edmdbcontext.IpPeople
                                    join
l in _edmdbcontext.IpLocations on b.PeLocn equals l.IpLocn.ToString() into jb
                                    from l in jb.DefaultIfEmpty()
                                    select new
                                    {
                                        b.PeLocn,
                                        l.IpLocn,
                                        b.PeLogn,
                                        l.LnCaid
                                    }
                                  ).ToList();

                    var data5 = (from a in ExResourceassignmentstatuses
                                 join
                                  b in _edmdbcontext.IpPeople on a.PeLogn equals b.PeLogn into sb
                                 from b in sb.DefaultIfEmpty()
                                 join
                                 c in _edmdbcontext.ExIppeople on a.PeLogn equals c.PeLogn into sc
                                 from c in sc.DefaultIfEmpty()
                                 join
                                 d in _edmdbcontext.IpElements on a.Group equals d.ElCode into sd
                                 from d in sd.DefaultIfEmpty()
                                 join
                                 e in _edmdbcontext.IpCategories on a.Role equals e.CaCode into se
                                 from e in se.DefaultIfEmpty()
                                 join
                                   l in _edmdbcontext.IpLocations on
                                   //new { User =Convert.ToInt16( b.PeLocn.FirstOrDefault()) }
                                   //equals new { User = l.IpLocn }
                                   //new { ID = b.PeLocn } equals new { ID = l.IpLocn!=0? l.IpLocn.ToString():"" }
                                   (b != null) ? b.PeLocn : default(string) equals l.IpLocn.ToString()
                                   into sl
                                 from j in sl.DefaultIfEmpty()
                                 join
                                 d1 in _edmdbcontext.IpElements on (b != null) ? b.PeDept : default(string) equals d1.ElCode into sd1
                                 from d1 in sd1.DefaultIfEmpty()
                                 join
                                 e1 in _edmdbcontext.IpCategories on (b != null) ? b.PeDesg : default(string) equals e1.CaCode into se1
                                 from e1 in se1.DefaultIfEmpty()
                                 where a.CuIden == model.CU_IDEN && a.Enddate == null && (b != null) ? b.PeLogn != null : false
                                 // && b.PeLocn!=null
                                 orderby b.PeName
                                 select new
                                 {
                                     pe_logn = a.PeLogn,
                                     Person_ID = c.WwPersonId,
                                     Name = b.PeName,
                                     Location = j.LnName,
                                     Designation = e1.CaName,
                                     Department = d1.ElName,
                                     Group = d.ElName,
                                     Role = e.CaName,
                                     Start_Date = a.Startdate.ToString(),
                                     Billing_Start_date = a.BillStart.ToString(),
                                     Reason = a.Reason == "BILLING" ? "Billed" : a.Reason == "BNA" ? "Billing New Addition" :
                    a.Reason == "AB" ? "Anticipatory Billing" : a.Reason == "NBA" ? "Non Billing Addition" :
                    a.Reason

                                 }).ToList();
                    dList.Add("Table5", data5);
                    string[] reasonList = { "BNA", "Billing" };

                    var data6 = (from a in ExResourceassignmentstatuses
                                 join
b in _edmdbcontext.IpPeople on a.PeLogn equals b.PeLogn into sb
                                 from b in sb.DefaultIfEmpty()
                                 join
                                 c in _edmdbcontext.ExIppeople on a.PeLogn equals c.PeLogn into sc
                                 from c in sc.DefaultIfEmpty()
                                 join
                                 d in _edmdbcontext.IpElements on a.Group equals d.ElCode into sd
                                 from d in sd.DefaultIfEmpty()
                                 join
                                 e in _edmdbcontext.IpCategories on a.Role equals e.CaCode into se
                                 from e in se.DefaultIfEmpty()
                                 join
                                   l in _edmdbcontext.IpLocations on

                                   (b != null) ? b.PeLocn : default(string) equals l.IpLocn.ToString()
                                   into sl
                                 from j in sl.DefaultIfEmpty()
                                 join
                                 d1 in _edmdbcontext.IpElements on (b != null) ? b.PeDept : default(string) equals d1.ElCode into sd1
                                 from d1 in sd1.DefaultIfEmpty()
                                 join
                                 e1 in _edmdbcontext.IpCategories on (b != null) ? b.PeDesg : default(string) equals e1.CaCode into se1
                                 from e1 in se1.DefaultIfEmpty()
                                 where a.CuIden == model.CU_IDEN && a.Enddate == null && (b != null) ? b.PeLogn != null : false
                                 && reasonList.Contains(a.Reason)
                                 orderby b.PeName
                                 select new
                                 {
                                     pe_logn = a.PeLogn,
                                     Person_ID = c.WwPersonId,
                                     Name = b.PeName,
                                     Location = j.LnName,
                                     Designation = e1.CaName,
                                     Department = d1.ElName,
                                     Group = d.ElName,
                                     Role = e.CaName,
                                     Start_Date = a.Startdate.ToString(),
                                     Billing_Start_date = a.BillStart.ToString(),
                                     Reason = a.Reason == "BILLING" ? "Billed" : a.Reason == "BNA" ? "Billing New Addition" :
                    a.Reason == "AB" ? "Anticipatory Billing" : a.Reason == "NBA" ? "Non Billing Addition" :
                    a.Reason

                                 }).ToList();
                    dList.Add("Table6", data6);

                    var data7 = (from a in ExResourceassignmentstatuses
                                 join
b in _edmdbcontext.IpPeople on a.PeLogn equals b.PeLogn into sb
                                 from b in sb.DefaultIfEmpty()
                                 join
                                 c in _edmdbcontext.ExIppeople on a.PeLogn equals c.PeLogn into sc
                                 from c in sc.DefaultIfEmpty()
                                 join
                                 d in _edmdbcontext.IpElements on a.Group equals d.ElCode into sd
                                 from d in sd.DefaultIfEmpty()
                                 join
                                 e in _edmdbcontext.IpCategories on a.Role equals e.CaCode into se
                                 from e in se.DefaultIfEmpty()
                                 join
                                   l in _edmdbcontext.IpLocations on

                                   (b != null) ? b.PeLocn : default(string) equals l.IpLocn.ToString()
                                   into sl
                                 from j in sl.DefaultIfEmpty()
                                 join
                                 d1 in _edmdbcontext.IpElements on (b != null) ? b.PeDept : default(string) equals d1.ElCode into sd1
                                 from d1 in sd1.DefaultIfEmpty()
                                 join
                                 e1 in _edmdbcontext.IpCategories on (b != null) ? b.PeDesg : default(string) equals e1.CaCode into se1
                                 from e1 in se1.DefaultIfEmpty()
                                 where a.CuIden == model.CU_IDEN && a.Enddate == null && (b != null) ? b.PeLogn != null : false
                                 && !reasonList.Contains(a.Reason)
                                 orderby b.PeName
                                 select new
                                 {
                                     pe_logn = a.PeLogn,
                                     Person_ID = c.WwPersonId,
                                     Name = b.PeName,
                                     Location = j.LnName,
                                     Designation = e1.CaName,
                                     Department = d1.ElName,
                                     Group = d.ElName,
                                     Role = e.CaName,
                                     Start_Date = a.Startdate.ToString(),
                                     Billing_Start_date = a.BillStart.ToString(),
                                     Reason = a.Reason == "BILLING" ? "Billed" : a.Reason == "BNA" ? "Billing New Addition" :
                    a.Reason == "AB" ? "Anticipatory Billing" : a.Reason == "NBA" ? "Non Billing Addition" :
                    a.Reason

                                 }).ToList();
                    dList.Add("Table7", data7);

//                    string[] reasonListT5 = { "BNA", "NBST5" };
//                    var ExResourceassignments = (from a in _repositorycontext.ExResourceassignments select a).ToList();

//                    var data8 = (from a in ExResourceassignments
//                                 join
//b in _edmdbcontext.IpPeople on a.PeLogn equals b.PeLogn into sb
//                                 from b in sb.DefaultIfEmpty()
//                                 join
//                                 c in _edmdbcontext.ExIppeople on a.PeLogn equals c.PeLogn into sc
//                                 from c in sc.DefaultIfEmpty()
//                                 join
//                                 d in _edmdbcontext.IpElements on a.Groups equals d.ElCode into sd
//                                 from d in sd.DefaultIfEmpty()
//                                 join
//                                 e in _edmdbcontext.IpCategories on a.AssignType equals e.CaCode into se
//                                 from e in se.DefaultIfEmpty()
//                                 join
//                                   l in _edmdbcontext.IpLocations on

//                                   (b != null) ? b.PeLocn : default(string) equals l.IpLocn.ToString()
//                                   into sl
//                                 from j in sl.DefaultIfEmpty()
//                                 join
//                                 d1 in _edmdbcontext.IpElements on (b != null) ? b.PeDept : default(string) equals d1.ElCode into sd1
//                                 from d1 in sd1.DefaultIfEmpty()
//                                 join
//                                 e1 in _edmdbcontext.IpCategories on (b != null) ? b.PeDesg : default(string) equals e1.CaCode into se1
//                                 from e1 in se1.DefaultIfEmpty()
//                                 where a.CuIden == model.CU_IDEN && (b != null) ? b.PeLogn != null : false
//                                 && a.ApproveStatus == "P"

//                                 orderby b.PeName
//                                 select new
//                                 {
//                                     pe_logn = a.PeLogn,
//                                     Person_ID = c.WwPersonId,
//                                     Name = b.PeName,
//                                     Location = j.LnName,
//                                     Designation = e1.CaName,
//                                     Department = d1.ElName,
//                                     Group = d.ElName,
//                                     Role = e.CaName,
//                                     Start_Date = a.KickOffDate.ToString(),
//                                     Billing_Start_date = a.BillDate.ToString(),
//                                     Reason = a.Reason == "BILLING" ? "Billed" : a.Reason == "BNA" ? "Billing New Addition" :
//                    a.Reason == "AB" ? "Anticipatory Billing" : a.Reason == "NBA" ? "Non Billing Addition" :
//                    a.Reason,
//                                     Compliance_Approval_Status = a.ComplianceStatus == "P" ? "Pending" : "Approved on" + a.ComplianceEntrystamp.ToString(),
//                                     Finance_Approval_Status = reasonListT5.Contains(a.Reason) && a.FinanceStatus == "P" ? "Pending" :
//                                     !reasonListT5.Contains(a.Reason) ? "NA" : "Approved on " + a.FinanceEntrystamp.ToString()



//                                 }).ToList();
//                    dList.Add("Table8", data8); 

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


        [HttpPost("OnboardResourceRoleBack")]
        public IActionResult OnboardResourceRoleBack(ResourceRoleBack model)
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
                    DateTime BenchStart = DateTime.Now;
                    DateTime PeJoin = DateTime.Now;
                    DateTime LockDate = DateTime.Now;

                    decimal? allocationsum = 0;

                    KickOffStatus kickmodel = new KickOffStatus();
                    ResultTemp resultModel = new ResultTemp();

                    if (model.ActionTaken == "Rollback")
                    {
                        ExResourceassignment exResourceassignment  = _repositorycontext.ExResourceassignments.Where(x => x.Id == model.Tranid
                      && x.ApproveStatus=="P"  ).FirstOrDefault();
                        exResourceassignment.Userapprovestatus = "R";
                        exResourceassignment.ManagerComments = "Transaction Rollback";
                        exResourceassignment.ManagerEntrystamp = DateTime.Now;
                        exResourceassignment.ManagerLognid = model.Logn;
                        exResourceassignment.ApproveStatus = "R";
                        _repositorycontext.ExResourceassignments.Update(exResourceassignment);
                        //_repositorycontext.SaveChanges();

                        ExResourceassignmentChecklist exResourceassignmentChecklist = _repositorycontext.ExResourceassignmentChecklists.Where(x => x.Id == model.Tranid).FirstOrDefault();
                       _repositorycontext.ExResourceassignmentChecklists.Remove(exResourceassignmentChecklist);
                        //_repositorycontext.SaveChanges();

                        var finddata = (from p in _repositorycontext.ExResourceassignments
                                        where p.Id == model.Tranid
                                        orderby p.Id descending
                                         select new
                                         {
                                             personpelogn = p.PeLogn,
                                             Prvkickoff =p.KickOffDate,
                                             cuiden =p.CuIden

                                         }).ToList();
                        string personpelogn = "";
                        DateTime Prvkickoff = DateTime.Now;
                        string prvcuiden = "";
                        if (finddata.Count > 0)
                        {
                            personpelogn = finddata[0].personpelogn;
                            Prvkickoff = Convert.ToDateTime(finddata[0].Prvkickoff);
                            prvcuiden = finddata[0].cuiden.ToString();
                        }

                        ExResourceassignmentstatus exResourceassignmentstatus1 = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.PeLogn == personpelogn 
                        && x.KickOff==Prvkickoff && x.CuIden.ToString()== prvcuiden).FirstOrDefault();
                        _repositorycontext.ExResourceassignmentstatuses.Remove(exResourceassignmentstatus1);

                        _repositorycontext.SaveChanges();

                        kickmodel.nstatus = "Transaction Rollback Successfully";
                    }
                    else
                    {
                       

                        string[] statusList = { "B", "T", "L" };
                        var resource = _repositorycontext.ExResourceassignmentstatuses.FirstOrDefault(x => x.PeLogn == model.PeLogn && x.DateOfMove == null && statusList.Contains(x.Status));
                        if (resource != null)
                        {
                            BenchStart = (DateTime)resource.KickOff;
                        }

                        var people = _edmdbcontext.IpPeople.FirstOrDefault(x => x.PeLogn == model.PeLogn);
                        if (people != null)
                        {
                            PeJoin = (DateTime)people.PeJoin;
                        }
                        //var workTypevar = _edmdbcontext.ExIppeople.FirstOrDefault(s => s.PeLogn == model.PeLogn);

                        var Allocation = (from p in _repositorycontext.ExResourceallocations
                                          where p.PeLogn == model.PeLogn && p.AllocStartdt <= Convert.ToDateTime(model.KickOff) &&
                            (p.AllocEnddate == null || p.AllocEnddate >= Convert.ToDateTime(model.KickOff))
                                          select new
                                          {
                                              p.Allocation

                                          }).ToList();

                        if (Allocation.Count > 0)
                        {
                            allocationsum = Allocation.Sum(t => t.Allocation);
                        }
                        allocationsum = 100 - allocationsum;

                        //var Allocation = _repositorycontext.ExResourceallocations.FirstOrDefault(x => x.PeLogn == model.PeLogn && x.AllocStartdt <= Convert.ToDateTime(model.KickOff) &&
                        //(x.AllocEnddate == null || x.AllocEnddate >= Convert.ToDateTime(model.KickOff)));
                        //if (Allocation != null)
                        //{
                        //    allocationsum = Allocation.Allocation;
                        //}


                        //var LockDate1 = _repositorycontext.ExTransactionApprovals.OrderByDescending(x => x.Id).Take(1); 

                        var LockDate1 = (from p in _repositorycontext.ExTransactionApprovals
                                         orderby p.Id descending
                                         select new
                                         {
                                             p.LockedOn

                                         }).ToList();
                        if (LockDate1.Count > 0)
                        {

                            LockDate = Convert.ToDateTime(LockDate1[0].LockedOn);
                        }


                        if (LockDate >= Convert.ToDateTime(model.KickOff))
                        {
                            kickmodel.nstatus = "Kickoff Date cannot less than or equal to lock date " + LockDate.ToString("yyyy-MM-dd");
                        }
     //                   else if ((from a in _repositorycontext.ExResourceassignmentstatuses
     //                             where a.PeLogn == model.PeLogn && a.CuIden == Convert.ToInt32(model.CuIden)
     //&& a.ApproveStatus == "P"
     //                             select a).ToList().Count > 0)
     //                   {

     //                       kickmodel.nstatus = "The resource has been already onboarded to the selected client, but awaiting approval(s).";
     //                   }
                        else if ((from a in _repositorycontext.ExResourceassignmentstatuses
                                  where a.PeLogn == model.PeLogn && a.CuIden == Convert.ToInt32(model.CuIden) && a.Enddate == null && a.ApproveStatus == "A" 
                                  select a).ToList().Count > 0)
                        {
                            //resultModel.ID = 1;
                            //resultModel.Status = "The resource has been already onboarded to the selected client and group and for selected kickoff date" + model.KickOff;
                            kickmodel.nstatus = "The resource has been already onboarded to the selected client for selected kickoff date " + model.KickOff;
                        }
        //                else if ((from a in _repositorycontext.ExResourceassignmentstatuses
        //                          where a.PeLogn == model.PeLogn && a.CuIden != Convert.ToInt32(model.CuIden) && a.ApproveStatus=="A" &&
        //                           (Convert.ToDateTime(model.KickOff) > a.Startdate &&
        //(Convert.ToDateTime(model.KickOff) < (a.Enddate == null ? DateTime.Now : a.Enddate)))
        //                          select a).ToList().Count > 0)
        //                {
        //                    //resultModel.ID = 1;
        //                    //resultModel.Status = "The resource has been already onboarded to the selected client and group and for selected kickoff date" + model.KickOff;
        //                    kickmodel.nstatus = "The resource has been already onboarded to the selected client for selected kickoff date " + model.KickOff;
        //                }
                        else if (Convert.ToDateTime(model.KickOff) < BenchStart && resource != null)
                        {
                            //kickmodel.nstatus = "Do not Insert1";
                            //kickmodel.kickoffdate = BenchStart.ToString();
                            kickmodel.nstatus = "Kickoff date cannot be less than bench start date " + BenchStart;
                        }
                        else if (allocationsum < Convert.ToDecimal(model.Allocation))
                        {
                            kickmodel.nstatus = "Giving Allocation cannot be greater than or equal to remaining allocated percentage " + allocationsum;
                        }

                        else
                        {




                           
                            string role = string.Empty;

                            int SI = 1;


                            string[] statusLister = { "B", "T", "L" };
                            var SIP = (from p in _repositorycontext.ExResourceassignmentstatuses
                                       where
                                       p.PeLogn == model.PeLogn && p.CuIden == Convert.ToInt32(model.CuIden) && statusLister.Contains(p.Status)
                                       select p).Max(p => p.Sl);
                            SI = SIP == null ? 0 : SIP.Value;
                            SI = SI == 0 ? 1 : SI + 1;

                            Core core = new(_repositorycontext, _edmdbcontext);
                            role = core.uFn_LoginCheck(model.PeLogn); 
 
                            {
                                string[] reasonLIst = { "BNA", "NBST5" };
                                string[] reasonList2 = { "BNA", "AB", "NBA" };
                                string[] roleList = { "Admin1", "NONE1" };
                                string[] reasonList3 = { "BNA", "NBST5" };
                                string[] reasonList4 = { "BNA", "NBST5" };

                                var finddata1 = (from p in _repositorycontext.ExResourceassignments
                                                where p.Id == model.Tranid
                                                orderby p.Id descending
                                                select new
                                                {
                                                    personpelogn = p.PeLogn,
                                                    Prvkickoff = p.KickOffDate,
                                                    cuiden = p.CuIden

                                                }).ToList();
                                string personpelogn1 = "";
                                DateTime Prvkickoff1 = DateTime.Now;
                                string prvcuiden1 = "";
                                if (finddata1.Count > 0)
                                {
                                    personpelogn1 = finddata1[0].personpelogn;
                                    Prvkickoff1 = Convert.ToDateTime(finddata1[0].Prvkickoff);
                                    prvcuiden1 = finddata1[0].cuiden.ToString();
                                }


                                ExResourceassignment Exresource = _repositorycontext.ExResourceassignments.Where(x => x.Id == model.Tranid
                  && x.ApproveStatus == "P").FirstOrDefault();
                                Exresource.PeLmgr = model.ReportTo;
                                Exresource.PeLogn = model.PeLogn;
                                Exresource.RepValognid = model.Replacing;
                                Exresource.CuIden = Convert.ToInt32(model.CuIden);
                                Exresource.ProjId = Convert.ToInt32(model.ProjID);
                                Exresource.CuType = model.ClientType;
                                Exresource.IpLocn = (from a in _edmdbcontext.IpPeople where a.PeLogn == model.PeLogn select a.PeLocn).FirstOrDefault();
                                Exresource.Groups = model.Group;
                                Exresource.AssignType = model.AssignRole;
                                Exresource.Reason = model.Reason;
                                Exresource.ReasonDetail = null;
                                Exresource.Jobrefno = null;
                                Exresource.ReqId = Convert.ToInt32(model.ReqID);
                                Exresource.ResgclntComment = null;
                                Exresource.ItComment = null;
                                Exresource.AdminComment = null;
                                Exresource.DateOfSelectionOrMove = model.DOS == null ? null : Convert.ToDateTime(model.DOS);
                                Exresource.KickOffDate = model.KickOff == null ? null : Convert.ToDateTime(model.KickOff);
                                Exresource.BillDate = reasonLIst.Contains(model.Reason) ? Convert.ToDateTime(model.BillStart) : null;
                                Exresource.BillingStatus = null;
                                Exresource.BillingDetails = null;
                                Exresource.ComplComment = model.Compliance;
                                Exresource.HrRdAccFinComment = null;
                                Exresource.OnOff = 0;
                                Exresource.Entrystamp = DateTime.Now;
                                Exresource.Userlognid = model.Logn;
                                Exresource.Status = reasonList2.Contains(model.Reason) ? "A" : "S";
                                Exresource.ApproveStatus = "P";
                                Exresource.BcatId = null;
                                Exresource.BillingRate = null;
                                Exresource.Userapprovestatus = roleList.Contains(role) ? "P" : "A";
                                Exresource.FinanceStatus = reasonList3.Contains(model.Reason) ? "P" : "A";
                                Exresource.FinanceComments = null;
                                Exresource.FinanceEntrystamp = null;
                                Exresource.FinanceLognid = null;
                                Exresource.ManagerComments = null;
                                Exresource.ManagerEntrystamp = roleList.Contains(role) ? null : DateTime.Now;
                                Exresource.ManagerLognid = roleList.Contains(role) ? null : model.Logn;
                                Exresource.ComplianceComments = null;
                                Exresource.ComplianceStatus = "P";
                                Exresource.ComplianceEntrystamp = null;
                                Exresource.ComplianceLognid = null;
                                Exresource.ItCommentsOnapprove = null;
                                Exresource.ItStatusOnapprove = "P";
                                Exresource.ItStatusEntrystamp = null;
                                Exresource.ItStatusLognid = null;
                                Exresource.AdminCommentsOnapprove = null;
                                Exresource.AdminStatusOnapprove = "P";
                                Exresource.AdminStatusEntrystamp = null;
                                Exresource.AdminStatusLognid = null;
                                Exresource.Supr = model.Supervisor;
                                Exresource.Ndasigneddate = null;
                                Exresource.Documentation = null;
                                Exresource.ManagerUpdate = null;
                                Exresource.OrgnRole = null;
                                Exresource.TdaComments = null;
                                Exresource.CheadTypeoflead = null;
                                Exresource.CheadUpdatedbychead = null;
                                Exresource.CheadEntrystamp = null;
                                Exresource.InvoiceNo = null;
                                Exresource.BillingRole = null;
                                Exresource.Allocation = model.Allocation != null ? Convert.ToDecimal(model.Allocation) : 0;
                                //Exresource.Sl = SI;
                                Exresource.ConversionComplStatus = "P";
                                Exresource.Billpercent = reasonLIst.Contains(model.Reason) ? Convert.ToDecimal(model.BillPercentage) : null;
                                Exresource.Sow = model.SOWno;
                                Exresource.OnboardComments = model.OnboardComments;
                                Exresource.DmKickOffDate = Convert.ToDateTime(model.KickOff);
                                _repositorycontext.ExResourceassignments.Update(Exresource);

                                ExResourceassignmentstatus exResourceassignmentstatus11 = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.PeLogn == personpelogn1
                      && x.KickOff == Prvkickoff1 && x.CuIden.ToString() == prvcuiden1).FirstOrDefault();
                                _repositorycontext.ExResourceassignmentstatuses.Remove(exResourceassignmentstatus11);

                                ExResourceassignmentstatus statusobj = new ExResourceassignmentstatus();
                                statusobj.Sl = SI;
                                statusobj.PeLogn = model.PeLogn;
                                statusobj.CuIden = Convert.ToInt32(model.CuIden);
                                statusobj.ProjId = Convert.ToInt32(model.ProjID);
                                statusobj.Group = model.Group;
                                statusobj.Role = model.AssignRole;
                                statusobj.KickOff = Convert.ToDateTime(model.KickOff);
                                statusobj.DateOfMove = null;
                                statusobj.Startdate = Convert.ToDateTime(model.KickOff);
                                statusobj.Enddate = null;//hard coded from below line
                                statusobj.Status = (from a in _repositorycontext.ExStatusdescs where a.Level == model.Reason select a.StatusIndicator).FirstOrDefault(); ;
                                statusobj.StatusLevelId = (from a in _repositorycontext.ExStatusdescs where a.Level == model.Reason select a.StatusLevelId).FirstOrDefault(); ; ;
                                statusobj.Entrystamp = DateTime.Now;
                                statusobj.Userlognid = model.Logn;
                                statusobj.ApproveStatus = "P";
                                statusobj.OffboardStatus = null;
                                statusobj.OffboardStamp = null;
                                statusobj.OffboardUserlognid = null;
                                statusobj.Reason = model.Reason;
                                statusobj.FinStatus = reasonList4.Contains(model.Reason) ? "P" : "A";
                                statusobj.Tranid = 1;
                                _repositorycontext.ExResourceassignmentstatuses.Add(statusobj);
                                _repositorycontext.SaveChanges();

                                //           ExResourceassignmentstatus statusobj = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.PeLogn == personpelogn1
                                //&& x.KickOff == Prvkickoff1 && x.CuIden.ToString() == prvcuiden1).FirstOrDefault();
                                //           //statusobj.Sl = SI;
                                //           statusobj.PeLogn = model.PeLogn;
                                //           //statusobj.CuIden = Convert.ToInt32(model.CuIden);
                                //           statusobj.ProjId = Convert.ToInt32(model.ProjID);
                                //           statusobj.Group = model.Group;
                                //           statusobj.Role = model.AssignRole;
                                //           statusobj.KickOff = Convert.ToDateTime(model.KickOff); 
                                //           statusobj.Startdate = Convert.ToDateTime(model.KickOff); 
                                //           statusobj.Status = (from a in _repositorycontext.ExStatusdescs where a.Level == model.Reason select a.StatusIndicator).FirstOrDefault(); ;
                                //           statusobj.StatusLevelId = (from a in _repositorycontext.ExStatusdescs where a.Level == model.Reason select a.StatusLevelId).FirstOrDefault(); ; ;
                                //           statusobj.Entrystamp = DateTime.Now;
                                //           statusobj.Userlognid = model.Logn;
                                //           statusobj.ApproveStatus = "P"; 
                                //           statusobj.Reason = model.Reason;
                                //           statusobj.FinStatus = reasonList4.Contains(model.Reason) ? "P" : "A"; 
                                //           _repositorycontext.ExResourceassignmentstatuses.Update(statusobj);
                                //           _repositorycontext.SaveChanges();

                                //ExResourceassignmentChecklist exResourceassignmentChecklist = _repositorycontext.ExResourceassignmentChecklists.Where(x => (x.Id) == (model.Tranid)).FirstOrDefault();
                                //_repositorycontext.ExResourceassignmentChecklists.Remove(exResourceassignmentChecklist);
                                //_repositorycontext.SaveChanges();

                                //ExResourceassignmentChecklist exResourceassignmentChecklist1111 = _repositorycontext.ExResourceassignmentChecklists.Where(x =>  x.Id == model.Tranid).FirstOrDefault();
                                //_repositorycontext.ExResourceassignmentChecklists.Remove(exResourceassignmentChecklist1111); 
                                //_repositorycontext.SaveChanges();

                                int RequestId = model.Tranid;
                                int SL = 0;

                                //RequestId = (from a in _repositorycontext.ExResourceassignments
                                //             where a.PeLogn == model.PeLogn && a.OnOff == 0
                                //             select a).Max(a => a.Id);
                                //RequestId = (from a in _repositorycontext.ExResourceassignments
                                //             where a.PeLogn == model.PeLogn && a.OnOff == 0
                                //             select a).Max(a => a.Id);
                                var id = _repositorycontext.ExResourceassignments.FirstOrDefault(x => x.Id == RequestId);
                                SL = (int)id.Sl;

                                //ExResourceassignmentChecklist checklist = new ExResourceassignmentChecklist();
                                //checklist.ChecklistType = "Onboard IT";
                                //checklist.ChecklistId = 6;
                                //checklist.OnOff = 0;
                                //checklist.Id = RequestId;
                                //checklist.YesNoInd = model.IsFolderAccessRequired;
                                //checklist.Comments = model.FolderAccessDetails;
                                //checklist.Sl = SL;
                                //checklist.Status = "P";
                                //_repositorycontext.ExResourceassignmentChecklists.Add(checklist);
                                //_repositorycontext.SaveChanges();

                                //ExResourceassignmentChecklist checklist1 = new ExResourceassignmentChecklist();
                                //checklist1.ChecklistType = "Onboard IT";
                                //checklist1.ChecklistId = 7;
                                //checklist1.OnOff = 0;
                                //checklist1.Id = RequestId;
                                //checklist1.YesNoInd = model.IsEmailAccessRequired;
                                //checklist1.Comments = model.EmailAccessDetails;
                                //checklist1.Sl = SL;
                                //checklist1.Status = "P";
                                //_repositorycontext.ExResourceassignmentChecklists.Add(checklist1);
                                //_repositorycontext.SaveChanges();


                                //ExResourceassignmentChecklist checklist2 = new ExResourceassignmentChecklist();
                                //checklist2.ChecklistType = "Onboard Admin";
                                //checklist2.ChecklistId = 8;
                                //checklist2.OnOff = 0;
                                //checklist2.Id = RequestId;
                                //checklist2.YesNoInd = "";
                                //checklist2.Comments = model.ClientRoomDetails;
                                //checklist2.Sl = SL;
                                //checklist2.Status = "P";
                                //_repositorycontext.ExResourceassignmentChecklists.Add(checklist2);
                                //_repositorycontext.SaveChanges();
                                //// RequestId = resAssign.Value;

                                //ExResourceassignmentChecklist checklist3 = new ExResourceassignmentChecklist();
                                //checklist3.ChecklistType = "Onboard Admin";
                                //checklist3.ChecklistId = 9;
                                //checklist3.OnOff = 0;
                                //checklist3.Id = RequestId;
                                //checklist3.YesNoInd = "";
                                //checklist3.Comments = model.WorkStationDetails;
                                //checklist3.Sl = SL;
                                //checklist3.Status = "P";
                                //_repositorycontext.ExResourceassignmentChecklists.Add(checklist3);
                                //_repositorycontext.SaveChanges();

                                kickmodel.nstatus = "Transaction Update Successfully";
                            }
                            //SI =(from p in _repositorycontext.ExResourceassignmentstatuses where
                            //      p.PeLogn == model.PeLogn && p.CuIden == Convert.ToInt32(model.CuIden) && statusLister.Contains(p.Status) select  );


                        } 
                    }
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

        [HttpGet("GetPendingOFFBoardTransaction/{pelogin}")]
        public IActionResult GetPendingOFFBoardTransaction(string pelogin)
        {
            Dictionary<string, object> dList = new Dictionary<string, object>();
            Response response = new();
            try
            {
                string role = string.Empty;
                Core core = new(_repositorycontext, _edmdbcontext);
                role = core.uFn_LoginCheck(pelogin);
            
                string dept = core.getdepartment(pelogin);

                //string[] roleList = { "ADMIN", "EMGR", "CDH" };
                var ExResourceassignmentstatuses = (from a in _repositorycontext.ExResourceassignmentstatuses select a).ToList();
                var ExResourceassignment = (from a in _repositorycontext.ExResourceassignments select a).ToList();
                var IPCustomerlist = (from a in _repositorycontext.IpCustomers select a).ToList();
                var ChecklistList = (from a in _repositorycontext.ExResourceassignmentChecklists select a).ToList();
                var IpPersonList = (from a in _edmdbcontext.IpPeople where a.PeQuit == null select a).ToList();
                var IPElementList = (from a in _edmdbcontext.IpElements select a).ToList();
                DateTime todaydate = DateTime.Now;
                //var ITchecklistid = "7";

                if (role == "DM")
                {
                    var IPCustomerlist1 = (from a in _repositorycontext.ExResourceassignmentstatuses
                                           join b in _repositorycontext.IpCustomers on a.CuIden equals b.CuIden
                                           where a.Role == "DM" && a.Enddate == null && a.PeLogn == pelogin
                                           select b).ToList();

                    var result = (from a in ExResourceassignment
                                  join b in ExResourceassignmentstatuses on a.PeLogn equals b.PeLogn into sb
                                  from b in sb.DefaultIfEmpty()
                                  join c in IpPersonList on a.PeLogn equals c.PeLogn into sc
                                  from c in sc.DefaultIfEmpty()
                                  join d in IPCustomerlist1 on a.CuIden equals d.CuIden into sc1
                                  from d in sc1.DefaultIfEmpty()
                                  join e in IPElementList
                                   on new
                                   { Dept = c != null ? c.PeDept : "" }
                    equals new { Dept = e != null ? e.ElCode : "" } into sc2
                                  from e in sc2.DefaultIfEmpty()
                                  join f in ChecklistList
                                  on new
                                  { Checklist = a != null ? a.Id.ToString() : "" }
                   equals new { Checklist = f != null ? f.Id.ToString() : "" } into sc3
                                  from f in sc3.DefaultIfEmpty()
                                  join g in ChecklistList
                                on new
                                { Checklist = a != null ? a.Id.ToString() : "" }
                 equals new { Checklist = g != null ? g.Id.ToString() : "" } into sc4
                                  from g in sc4.DefaultIfEmpty()
                                  join h in ChecklistList
                               on new
                               { Checklist = a != null ? a.Id.ToString() : "" }
                equals new { Checklist = h != null ? h.Id.ToString() : "" } into sc5
                                  from h in sc5.DefaultIfEmpty()
               //                   join i in ChecklistList
               //               on new
               //               { Checklist = a != null ? a.Id.ToString() : "" }
               //equals new { Checklist = i != null ? i.Id.ToString() : "" } into sc6
               //                   from i in sc6.DefaultIfEmpty()
                                  where a.ApproveStatus == "P" && a.KickOffDate == b.KickOff && a.CuIden == b.CuIden && a.OnOff == 1 && f.ChecklistId.ToString() == "10" && g.ChecklistId.ToString() == "11"
                                   && h.ChecklistId.ToString() == "12" && c.PeDept == dept && a.CuIden != null && b.OffboardStatus == "P"
                                  //orderby b != null ? b.PeName : ""
                                  select new
                                  {
                                      PeName = c != null ? c.PeName : "",
                                      CuComp = d != null? d.CuComp : "",
                                      e.ElName,
                                      a.Id,
                                      a.PeLogn,
                                      a.CuIden,
                                      a.PeLmgr,
                                      a.ReqId,
                                      a.Reason,
                                      a.BillDate,
                                      a.RepValognid,
                                      a.Allocation,
                                      a.OnOff,
                                      a.Groups,
                                      KickOffDate = a.KickOffDate.Value.ToString("yyyy-MM-dd"),
                                      DateOfSelectionOrMove = a.DateOfSelectionOrMove.Value.ToString("yyyy-MM-dd"),
                                      a.AssignType,
                                      a.Billpercent,
                                      a.Sow,
                                      a.ReasonDetail,
                                      a.ResgclntComment,
                                      a.ProjId,
                                      a.OnboardComments,
                                      a.ComplComment,
                                      a.ComplianceStatus,
                                      a.FinanceStatus,
                                      DateDIff = todaydate.Subtract(a.Entrystamp.Value).TotalDays.ToString(),
                                      Entrystamp = a.Entrystamp.Value.ToString("yyyy-MM-dd"),
                                      EmailAccessStatus = f.YesNoInd,
                                      EmailAccessComments = f.Comments,
                                      FolderAccessStatus = g.YesNoInd,
                                      FolderAccessComments = g.Comments,
                                      ClientRoomDetail = h.Comments,
                                      b.OffboardReason,
                                      a.ManagerComments

                                      //WorkStaionDetail = i.Comments
                                      //TimeSpentInSeconds = at.Sum(p => p.AccessedDate.Value.Subtract(p.CreatedDate).TotalSeconds),
                                      //ParticipantId = at.Key
                                      //DateDIFFdd  = (todaydate - a.Entrystamp).to
                                      //a.Entrystamp((p => a.Entrystamp.datediff)   Allocation.Sum(t => t.Allocation);
                                  }).Distinct().ToList();

                    dList.Add("Table", result);

                }
                else if (role == "EMGR")
                {
                    var IPCustomerlist2 = (from a in _repositorycontext.ExIpcustomerOthers
                                           join b in _repositorycontext.IpCustomers on a.CuIden equals b.CuIden
                                           where a.Role.ToUpper() == "EMGR" && a.Enddate == null && a.PeLogn == pelogin && a.Status == "A"
                                           select b.CuIden.ToString()).ToList();

                    var result = (from a in ExResourceassignment
                                  join b in ExResourceassignmentstatuses on a.PeLogn equals b.PeLogn into sb
                                  from b in sb.DefaultIfEmpty()
                                  join c in IpPersonList on a.PeLogn equals c.PeLogn into sc
                                  from c in sc.DefaultIfEmpty()
                                  join d in IPCustomerlist on a.CuIden equals d.CuIden into sc1
                                  from d in sc1.DefaultIfEmpty()
                                  join e in IPElementList
                                   on new
                                   { Dept = c != null ? c.PeDept : "" }
                    equals new { Dept = e != null ? e.ElCode : "" } into sc2
                                  from e in sc2.DefaultIfEmpty()
                                  join f in ChecklistList
                                  on new
                                  { Checklist = a != null ? a.Id.ToString() : "" }
                   equals new { Checklist = f != null ? f.Id.ToString() : "" } into sc3
                                  from f in sc3.DefaultIfEmpty()
                                  join g in ChecklistList
                                on new
                                { Checklist = a != null ? a.Id.ToString() : "" }
                 equals new { Checklist = g != null ? g.Id.ToString() : "" } into sc4
                                  from g in sc4.DefaultIfEmpty()
                                  join h in ChecklistList
                               on new
                               { Checklist = a != null ? a.Id.ToString() : "" }
                equals new { Checklist = h != null ? h.Id.ToString() : "" } into sc5
                                  from h in sc5.DefaultIfEmpty()
               //                   join i in ChecklistList
               //               on new
               //               { Checklist = a != null ? a.Id.ToString() : "" }
               //equals new { Checklist = i != null ? i.Id.ToString() : "" } into sc6
               //                   from i in sc6.DefaultIfEmpty()
                                  where a.ApproveStatus == "P" && a.KickOffDate == b.KickOff && a.CuIden == b.CuIden && a.OnOff == 1 && f.ChecklistId.ToString() == "10" && g.ChecklistId.ToString() == "11"
                                   && h.ChecklistId.ToString() == "12"   && IPCustomerlist2.Contains(a.CuIden.ToString()) && b.OffboardStatus == "P"
                                  //orderby b != null ? b.PeName : ""
                                  select new
                                  {
                                      PeName = c != null ? c.PeName : "",
                                      d.CuComp,
                                      e.ElName,
                                      a.Id,
                                      a.PeLogn,
                                      a.CuIden,
                                      a.PeLmgr,
                                      a.ReqId,
                                      a.Reason,
                                      a.BillDate,
                                      a.RepValognid,
                                      a.Allocation,
                                      a.OnOff,
                                      a.Groups,
                                      KickOffDate = a.KickOffDate.Value.ToString("yyyy-MM-dd"),
                                      DateOfSelectionOrMove = a.DateOfSelectionOrMove.Value.ToString("yyyy-MM-dd"),
                                      a.AssignType,
                                      a.Billpercent,
                                      a.Sow,
                                      a.ReasonDetail,
                                      a.ResgclntComment,
                                      a.ProjId,
                                      a.OnboardComments,
                                      a.ComplComment,
                                      a.ComplianceStatus,
                                      a.FinanceStatus,
                                      DateDIff = todaydate.Subtract(a.Entrystamp.Value).TotalDays.ToString(),
                                      Entrystamp = a.Entrystamp.Value.ToString("yyyy-MM-dd"),
                                      EmailAccessStatus = f.YesNoInd,
                                      EmailAccessComments = f.Comments,
                                      FolderAccessStatus = g.YesNoInd,
                                      FolderAccessComments = g.Comments,
                                      ClientRoomDetail = h.Comments,
                                      b.OffboardReason,
                                      a.ManagerComments
                                  }).Distinct().ToList();

                    dList.Add("Table", result);



                }
                else if (role == "PMO")
                {
                    var ServiceLineList = (from a in _repositorycontext.ExAccessMasters
                                           where a.Role.ToUpper() == "PMO" && a.Enddate == null && a.PeLogn == pelogin && a.Status == "A"
                                           select a.ServiceLine).ToList();

                    var result = (from a in ExResourceassignment
                                  join b in ExResourceassignmentstatuses on a.PeLogn equals b.PeLogn into sb
                                  from b in sb.DefaultIfEmpty()
                                  join c in IpPersonList on a.PeLogn equals c.PeLogn into sc
                                  from c in sc.DefaultIfEmpty()
                                  join d in IPCustomerlist on a.CuIden equals d.CuIden into sc1
                                  from d in sc1.DefaultIfEmpty()
                                  join e in IPElementList
                                   on new
                                   { Dept = c != null ? c.PeDept : "" }
                    equals new { Dept = e != null ? e.ElCode : "" } into sc2
                                  from e in sc2.DefaultIfEmpty()
                                  join f in ChecklistList
                                  on new
                                  { Checklist = a != null ? a.Id.ToString() : "" }
                   equals new { Checklist = f != null ? f.Id.ToString() : "" } into sc3
                                  from f in sc3.DefaultIfEmpty()
                                  join g in ChecklistList
                                on new
                                { Checklist = a != null ? a.Id.ToString() : "" }
                 equals new { Checklist = g != null ? g.Id.ToString() : "" } into sc4
                                  from g in sc4.DefaultIfEmpty()
                                  join h in ChecklistList
                               on new
                               { Checklist = a != null ? a.Id.ToString() : "" }
                equals new { Checklist = h != null ? h.Id.ToString() : "" } into sc5
                                  from h in sc5.DefaultIfEmpty()
               //                   join i in ChecklistList
               //               on new
               //               { Checklist = a != null ? a.Id.ToString() : "" }
               //equals new { Checklist = i != null ? i.Id.ToString() : "" } into sc6
               //                   from i in sc6.DefaultIfEmpty()
                                  where a.ApproveStatus == "P" && a.KickOffDate == b.KickOff && a.CuIden == b.CuIden && a.OnOff == 1 && f.ChecklistId.ToString() == "10" && g.ChecklistId.ToString() == "11"
                                   && h.ChecklistId.ToString() == "12"   && ServiceLineList.Contains(c.PeDept) && b.OffboardStatus == "P"
                                  //orderby b != null ? b.PeName : ""
                                  select new
                                  {
                                      PeName = c != null ? c.PeName : "",
                                      d.CuComp,
                                      e.ElName,
                                      a.Id,
                                      a.PeLogn,
                                      a.CuIden,
                                      a.PeLmgr,
                                      a.ReqId,
                                      a.Reason,
                                      a.BillDate,
                                      a.RepValognid,
                                      a.Allocation,
                                      a.OnOff,
                                      a.Groups,
                                      KickOffDate = a.KickOffDate.Value.ToString("yyyy-MM-dd"),
                                      DateOfSelectionOrMove = a.DateOfSelectionOrMove.Value.ToString("yyyy-MM-dd"),
                                      a.AssignType,
                                      a.Billpercent,
                                      a.Sow,
                                      a.ReasonDetail,
                                      a.ResgclntComment,
                                      a.ProjId,
                                      a.OnboardComments,
                                      a.ComplComment,
                                      a.ComplianceStatus,
                                      a.FinanceStatus,
                                      DateDIff = todaydate.Subtract(a.Entrystamp.Value).TotalDays.ToString(),
                                      Entrystamp = a.Entrystamp.Value.ToString("yyyy-MM-dd"),
                                      EmailAccessStatus = f.YesNoInd,
                                      EmailAccessComments = f.Comments,
                                      FolderAccessStatus = g.YesNoInd,
                                      FolderAccessComments = g.Comments,
                                      ClientRoomDetail = h.Comments,
                                      b.OffboardReason,
                                      a.ManagerComments
                                  }).Distinct().ToList();

                    dList.Add("Table", result);



                }

                else if (role == "PL")
                {
                    var ServiceLineList = (from a in _repositorycontext.ExClientPlOwners
                                           where a.Enddate == null && a.PeLogn == pelogin && a.Status == "A"
                                           select a.ServiceLine).ToList();

                    var result = (from a in ExResourceassignment
                                  join b in ExResourceassignmentstatuses on a.PeLogn equals b.PeLogn into sb
                                  from b in sb.DefaultIfEmpty()
                                  join c in IpPersonList on a.PeLogn equals c.PeLogn into sc
                                  from c in sc.DefaultIfEmpty()
                                  join d in IPCustomerlist on a.CuIden equals d.CuIden into sc1
                                  from d in sc1.DefaultIfEmpty()
                                  join e in IPElementList
                                   on new
                                   { Dept = c != null ? c.PeDept : "" }
                    equals new { Dept = e != null ? e.ElCode : "" } into sc2
                                  from e in sc2.DefaultIfEmpty()
                                  join f in ChecklistList
                                  on new
                                  { Checklist = a != null ? a.Id.ToString() : "" }
                   equals new { Checklist = f != null ? f.Id.ToString() : "" } into sc3
                                  from f in sc3.DefaultIfEmpty()
                                  join g in ChecklistList
                                on new
                                { Checklist = a != null ? a.Id.ToString() : "" }
                 equals new { Checklist = g != null ? g.Id.ToString() : "" } into sc4
                                  from g in sc4.DefaultIfEmpty()
                                  join h in ChecklistList
                               on new
                               { Checklist = a != null ? a.Id.ToString() : "" }
                equals new { Checklist = h != null ? h.Id.ToString() : "" } into sc5
                                  from h in sc5.DefaultIfEmpty()
               //                   join i in ChecklistList
               //               on new
               //               { Checklist = a != null ? a.Id.ToString() : "" }
               //equals new { Checklist = i != null ? i.Id.ToString() : "" } into sc6
               //                   from i in sc6.DefaultIfEmpty()
                                  where a.ApproveStatus == "P" && a.KickOffDate == b.KickOff && a.CuIden == b.CuIden && a.OnOff == 1 && f.ChecklistId.ToString() == "10" && g.ChecklistId.ToString() == "11"
                                   && h.ChecklistId.ToString() == "12"  && ServiceLineList.Contains(c.PeDept) && b.OffboardStatus == "P"
                                  //orderby b != null ? b.PeName : ""
                                  select new
                                  {
                                      PeName = c != null ? c.PeName : "",
                                      d.CuComp,
                                      e.ElName,
                                      a.Id,
                                      a.PeLogn,
                                      a.CuIden,
                                      a.PeLmgr,
                                      a.ReqId,
                                      a.Reason,
                                      a.BillDate,
                                      a.RepValognid,
                                      a.Allocation,
                                      a.OnOff,
                                      a.Groups,
                                      KickOffDate = a.KickOffDate.Value.ToString("yyyy-MM-dd"),
                                      DateOfSelectionOrMove = a.DateOfSelectionOrMove.Value.ToString("yyyy-MM-dd"),
                                      a.AssignType,
                                      a.Billpercent,
                                      a.Sow,
                                      a.ReasonDetail,
                                      a.ResgclntComment,
                                      a.ProjId,
                                      a.OnboardComments,
                                      a.ComplComment,
                                      a.ComplianceStatus,
                                      a.FinanceStatus,
                                      DateDIff = todaydate.Subtract(a.Entrystamp.Value).TotalDays.ToString(),
                                      Entrystamp = a.Entrystamp.Value.ToString("yyyy-MM-dd"),
                                      EmailAccessStatus = f.YesNoInd,
                                      EmailAccessComments = f.Comments,
                                      FolderAccessStatus = g.YesNoInd,
                                      FolderAccessComments = g.Comments,
                                      ClientRoomDetail = h.Comments,
                                      b.OffboardReason,
                                      a.ManagerComments
                                  }).Distinct().ToList();

                    dList.Add("Table", result);



                }
                else
                {
                    var result = (from a in ExResourceassignment
                                  join b in ExResourceassignmentstatuses on a.PeLogn equals b.PeLogn into sb
                                  from b in sb.DefaultIfEmpty()
                                  join c in IpPersonList on a.PeLogn equals c.PeLogn into sc
                                  from c in sc.DefaultIfEmpty()
                                  join d in IPCustomerlist on a.CuIden equals d.CuIden into sc1
                                  from d in sc1.DefaultIfEmpty()
                                  join e in IPElementList
                                   on new
                                   { Dept = c != null ? c.PeDept : "" }
                    equals new { Dept = e != null ? e.ElCode : "" } into sc2
                                  from e in sc2.DefaultIfEmpty()
                                  join f in ChecklistList
                                  on new
                                  { Checklist = a != null ? a.Id.ToString() : "" }
                   equals new { Checklist = f != null ? f.Id.ToString() : "" } into sc3
                                  from f in sc3.DefaultIfEmpty()
                                  join g in ChecklistList
                                on new
                                { Checklist = a != null ? a.Id.ToString() : "" }
                 equals new { Checklist = g != null ? g.Id.ToString() : "" } into sc4
                                  from g in sc4.DefaultIfEmpty()
                                  join h in ChecklistList
                               on new
                               { Checklist = a != null ? a.Id.ToString() : "" }
                equals new { Checklist = h != null ? h.Id.ToString() : "" } into sc5
                                  from h in sc5.DefaultIfEmpty()
               //                   join i in ChecklistList
               //               on new
               //               { Checklist = a != null ? a.Id.ToString() : "" }
               //equals new { Checklist = i != null ? i.Id.ToString() : "" } into sc6
               //                   from i in sc6.DefaultIfEmpty()
                                  where a.ApproveStatus == "P" && a.KickOffDate == b.KickOff && a.CuIden == b.CuIden && a.OnOff == 1 && f.ChecklistId.ToString() == "10" && g.ChecklistId.ToString() == "11"
                                   && h.ChecklistId.ToString() == "12"  && b.OffboardStatus=="P"
                                  //orderby b != null ? b.PeName : ""
                                  select new
                                  {
                                      PeName = c != null ? c.PeName : "",
                                      d.CuComp,
                                      e.ElName,
                                      a.Id,
                                      a.PeLogn,
                                      a.CuIden,
                                      a.PeLmgr,
                                      a.ReqId,
                                      a.Reason,
                                      a.BillDate,
                                      a.RepValognid,
                                      a.Allocation,
                                      a.OnOff,
                                      a.Groups,
                                      KickOffDate = a.KickOffDate.Value.ToString("yyyy-MM-dd"),
                                      DateOfSelectionOrMove = a.DateOfSelectionOrMove.Value.ToString("yyyy-MM-dd"),
                                      a.AssignType,
                                      a.Billpercent,
                                      a.Sow,
                                      a.ReasonDetail,
                                      a.ResgclntComment,
                                      a.ProjId,
                                      a.OnboardComments,
                                      a.ComplComment,
                                      a.ComplianceStatus,
                                      a.FinanceStatus,
                                      DateDIff = todaydate.Subtract(a.Entrystamp.Value).TotalDays.ToString(),
                                      Entrystamp = a.Entrystamp.Value.ToString("yyyy-MM-dd"),
                                      EmailAccessStatus = f.YesNoInd,
                                      EmailAccessComments = f.Comments,
                                      FolderAccessStatus = g.YesNoInd,
                                      FolderAccessComments = g.Comments,
                                      ClientRoomDetail = h.Comments,
                                      b.OffboardReason,
                                      a.ManagerComments
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

        [HttpPost("OFFboardResourceRoleBack")]
        public IActionResult OFFboardResourceRoleBack(ResourceOffboardRollBack model)
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
                    DateTime BenchStart = DateTime.Now;
                    DateTime PeJoin = DateTime.Now;
                    DateTime LockDate = DateTime.Now;

                    decimal? allocationsum = 0;

                    KickOffStatus kickmodel = new KickOffStatus();
                    ResultTemp resultModel = new ResultTemp();

                    if (model.ActionTaken == "Rollback")
                    {
                        ExResourceassignment exResourceassignment = _repositorycontext.ExResourceassignments.Where(x => x.Id == model.Tranid
                     && x.ApproveStatus == "P").FirstOrDefault(); 
                        _repositorycontext.ExResourceassignments.Remove(exResourceassignment);
                        //_repositorycontext.SaveChanges();

                        ExResourceassignmentChecklist exResourceassignmentChecklist = _repositorycontext.ExResourceassignmentChecklists.Where(x => x.Id == model.Tranid).FirstOrDefault();
                        _repositorycontext.ExResourceassignmentChecklists.Remove(exResourceassignmentChecklist);
                        //_repositorycontext.SaveChanges();

                        var finddata = (from p in _repositorycontext.ExResourceassignments
                                        where p.Id == model.Tranid
                                        orderby p.Id descending
                                        select new
                                        {
                                            personpelogn = p.PeLogn,
                                            Prvkickoff = p.KickOffDate,
                                            cuiden = p.CuIden

                                        }).ToList();
                        string personpelogn = "";
                        DateTime Prvkickoff = DateTime.Now;
                        string prvcuiden = "";
                        if (finddata.Count > 0)
                        {
                            personpelogn = finddata[0].personpelogn;
                            Prvkickoff = Convert.ToDateTime(finddata[0].Prvkickoff);
                            prvcuiden = finddata[0].cuiden.ToString();
                        } 

                        ExResourceassignmentstatus statusobj = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.PeLogn == personpelogn
             && x.KickOff == Prvkickoff && x.CuIden.ToString() == prvcuiden && x.OffboardStatus=="P").FirstOrDefault(); 
                        statusobj.OffboardStatus =null;
                        statusobj.OffboardStamp = null;
                        statusobj.OffboardReason = null;
                        statusobj.OffboardUserlognid = null; 
                        statusobj.Enddate = null;
                        statusobj.DateOfMove = null;
                        _repositorycontext.ExResourceassignmentstatuses.Update(statusobj);

                        _repositorycontext.SaveChanges();

                        kickmodel.nstatus = "Transaction Rollback Successfully";
                    }
                    else
                    {


                        string[] statusList = { "B", "T", "L" };
                        var resource = _repositorycontext.ExResourceassignmentstatuses.FirstOrDefault(x => x.PeLogn == model.Logn && x.DateOfMove == null && statusList.Contains(x.Status));
                        if (resource != null)
                        {
                            BenchStart = (DateTime)resource.KickOff;
                        }

                        var people = _edmdbcontext.IpPeople.FirstOrDefault(x => x.PeLogn == model.Logn);
                        if (people != null)
                        {
                            PeJoin = (DateTime)people.PeJoin;
                        }
                        //var workTypevar = _edmdbcontext.ExIppeople.FirstOrDefault(s => s.PeLogn == model.PeLogn);

                        //var Allocation = (from p in _repositorycontext.ExResourceallocations
                        //                  where p.PeLogn == model.PeLogn && p.AllocStartdt <= Convert.ToDateTime(model.KickOff) &&
                        //    (p.AllocEnddate == null || p.AllocEnddate >= Convert.ToDateTime(model.KickOff))
                        //                  select new
                        //                  {
                        //                      p.Allocation

                        //                  }).ToList();

                        //if (Allocation.Count > 0)
                        //{
                        //    allocationsum = Allocation.Sum(t => t.Allocation);
                        //}
                        //allocationsum = 100 - allocationsum;

                        //var Allocation = _repositorycontext.ExResourceallocations.FirstOrDefault(x => x.PeLogn == model.PeLogn && x.AllocStartdt <= Convert.ToDateTime(model.KickOff) &&
                        //(x.AllocEnddate == null || x.AllocEnddate >= Convert.ToDateTime(model.KickOff)));
                        //if (Allocation != null)
                        //{
                        //    allocationsum = Allocation.Allocation;
                        //}


                        //var LockDate1 = _repositorycontext.ExTransactionApprovals.OrderByDescending(x => x.Id).Take(1); 

                        var LockDate1 = (from p in _repositorycontext.ExTransactionApprovals
                                         orderby p.Id descending
                                         select new
                                         {
                                             p.LockedOn

                                         }).ToList();
                        if (LockDate1.Count > 0)
                        {

                            LockDate = Convert.ToDateTime(LockDate1[0].LockedOn);
                        }


                        if (LockDate >= Convert.ToDateTime(model.OffboardDate))
                        {
                            kickmodel.nstatus = "OffBoard Date cannot less than or equal to lock date " + LockDate.ToString("yyyy-MM-dd");
                        }
                        //                   else if ((from a in _repositorycontext.ExResourceassignmentstatuses
                        //                             where a.PeLogn == model.PeLogn && a.CuIden == Convert.ToInt32(model.CuIden)
                        //&& a.ApproveStatus == "P"
                        //                             select a).ToList().Count > 0)
                        //                   {

                        //                       kickmodel.nstatus = "The resource has been already onboarded to the selected client, but awaiting approval(s).";
                        //                   }
                        //else if ((from a in _repositorycontext.ExResourceassignmentstatuses
                        //          where a.PeLogn == model.PeLogn && a.CuIden == Convert.ToInt32(model.CuIden) && a.Enddate == null && a.ApproveStatus == "A"
                        //          select a).ToList().Count > 0)
                        //{
                        //    //resultModel.ID = 1;
                        //    //resultModel.Status = "The resource has been already onboarded to the selected client and group and for selected kickoff date" + model.KickOff;
                        //    kickmodel.nstatus = "The resource has been already onboarded to the selected client for selected kickoff date " + model.KickOff;
                        //}
                        //                else if ((from a in _repositorycontext.ExResourceassignmentstatuses
                        //                          where a.PeLogn == model.PeLogn && a.CuIden != Convert.ToInt32(model.CuIden) && a.ApproveStatus=="A" &&
                        //                           (Convert.ToDateTime(model.KickOff) > a.Startdate &&
                        //(Convert.ToDateTime(model.KickOff) < (a.Enddate == null ? DateTime.Now : a.Enddate)))
                        //                          select a).ToList().Count > 0)
                        //                {
                        //                    //resultModel.ID = 1;
                        //                    //resultModel.Status = "The resource has been already onboarded to the selected client and group and for selected kickoff date" + model.KickOff;
                        //                    kickmodel.nstatus = "The resource has been already onboarded to the selected client for selected kickoff date " + model.KickOff;
                        //                }
                        //else if (Convert.ToDateTime(model.KickOff) < BenchStart && resource != null)
                        //{
                        //    //kickmodel.nstatus = "Do not Insert1";
                        //    //kickmodel.kickoffdate = BenchStart.ToString();
                        //    kickmodel.nstatus = "Kickoff date cannot be less than bench start date " + BenchStart;
                        //}
                        //else if (allocationsum <= Convert.ToDecimal(model.Allocation))
                        //{
                        //    kickmodel.nstatus = "Giving Allocation cannot be greater than or equal to remaining allocated percentage " + allocationsum;
                        //}

                        else
                        {





                            string role = string.Empty;
                            int SI = 0;
                            Core core = new(_repositorycontext, _edmdbcontext);
                            role = core.uFn_LoginCheck(model.Logn);

                            {
                                string[] reasonLIst = { "BNA", "NBST5" };
                                string[] reasonList2 = { "BNA", "AB", "NBA" };
                                string[] roleList = { "Admin1", "NONE1" };
                                string[] reasonList3 = { "BNA", "NBST5" };
                                string[] reasonList4 = { "BNA", "NBST5" };

                                var finddata1 = (from p in _repositorycontext.ExResourceassignments
                                                 where p.Id == model.Tranid
                                                 orderby p.Id descending
                                                 select new
                                                 {
                                                     personpelogn = p.PeLogn,
                                                     Prvkickoff = p.KickOffDate,
                                                     cuiden = p.CuIden

                                                 }).ToList();
                                string personpelogn1 = "";
                                DateTime Prvkickoff1 = DateTime.Now;
                                string prvcuiden1 = "";
                                if (finddata1.Count > 0)
                                {
                                    personpelogn1 = finddata1[0].personpelogn;
                                    Prvkickoff1 = Convert.ToDateTime(finddata1[0].Prvkickoff);
                                    prvcuiden1 = finddata1[0].cuiden.ToString();
                                }


                                ExResourceassignment Exresource = _repositorycontext.ExResourceassignments.Where(x => x.Id == model.Tranid
                  && x.ApproveStatus == "P").FirstOrDefault();
                                Exresource.DateOfSelectionOrMove = model.OffboardDate;
                                Exresource.Reason = model.OffboardReason;  
                                Exresource.RepValognid = model.ReplaceWith;
                                Exresource.ManagerComments = model.OffboardComments;
                                Exresource.ReasonDetail = model.ReplacementReason; 
                                _repositorycontext.ExResourceassignments.Update(Exresource);

                                ExResourceassignmentstatus exResourceassignmentstatus11 = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.PeLogn == personpelogn1
                      && x.KickOff == Prvkickoff1 && x.CuIden.ToString() == prvcuiden1 && x.OffboardStatus=="P").FirstOrDefault();
                                exResourceassignmentstatus11.DateOfMove = model.OffboardDate;
                                exResourceassignmentstatus11.OffboardStamp = DateTime.Now;
                                exResourceassignmentstatus11.OffboardUserlognid = model.Logn;
                                exResourceassignmentstatus11.OffboardReason = model.OffboardReason;  
                                _repositorycontext.ExResourceassignmentstatuses.Update(exResourceassignmentstatus11); 
                            
                                _repositorycontext.SaveChanges(); 


                                //ExResourceassignmentChecklist exResourceassignmentChecklist = _repositorycontext.ExResourceassignmentChecklists.Where(x => x.Id == model.Tranid).FirstOrDefault();
                                //_repositorycontext.ExResourceassignmentChecklists.Remove(exResourceassignmentChecklist);
                                //_repositorycontext.SaveChanges();

                                //int RequestId = model.Tranid;
                                //int SL = 0;

                                ////RequestId = (from a in _repositorycontext.ExResourceassignments
                                ////             where a.PeLogn == model.PeLogn && a.OnOff == 0
                                ////             select a).Max(a => a.Id);
                                ////RequestId = (from a in _repositorycontext.ExResourceassignments
                                ////             where a.PeLogn == model.PeLogn && a.OnOff == 0
                                ////             select a).Max(a => a.Id);
                                //var id = _repositorycontext.ExResourceassignments.FirstOrDefault(x => x.Id == RequestId);
                                //SL = (int)id.Sl;

                                //ExResourceassignmentChecklist checklist = new ExResourceassignmentChecklist();
                                //checklist.ChecklistType = "Onboard IT";
                                //checklist.ChecklistId = 6;
                                //checklist.OnOff = 0;
                                //checklist.Id = RequestId;
                                //checklist.YesNoInd = model.IsFolderAccessRequired;
                                //checklist.Comments = model.FolderAccessDetails;
                                //checklist.Sl = SL;
                                //checklist.Status = "P";
                                //_repositorycontext.ExResourceassignmentChecklists.Add(checklist);
                                //_repositorycontext.SaveChanges();

                                //ExResourceassignmentChecklist checklist1 = new ExResourceassignmentChecklist();
                                //checklist1.ChecklistType = "Onboard IT";
                                //checklist1.ChecklistId = 7;
                                //checklist1.OnOff = 0;
                                //checklist1.Id = RequestId;
                                //checklist1.YesNoInd = model.IsEmailAccessRequired;
                                //checklist1.Comments = model.EmailAccessDetails;
                                //checklist1.Sl = SL;
                                //checklist1.Status = "P";
                                //_repositorycontext.ExResourceassignmentChecklists.Add(checklist1);
                                //_repositorycontext.SaveChanges();


                                //ExResourceassignmentChecklist checklist2 = new ExResourceassignmentChecklist();
                                //checklist2.ChecklistType = "Onboard Admin";
                                //checklist2.ChecklistId = 8;
                                //checklist2.OnOff = 0;
                                //checklist2.Id = RequestId;
                                //checklist2.YesNoInd = "";
                                //checklist2.Comments = model.ClientRoomDetails;
                                //checklist2.Sl = SL;
                                //checklist2.Status = "P";
                                //_repositorycontext.ExResourceassignmentChecklists.Add(checklist2);
                                //_repositorycontext.SaveChanges();
                                //// RequestId = resAssign.Value;

                                //ExResourceassignmentChecklist checklist3 = new ExResourceassignmentChecklist();
                                //checklist3.ChecklistType = "Onboard Admin";
                                //checklist3.ChecklistId = 9;
                                //checklist3.OnOff = 0;
                                //checklist3.Id = RequestId;
                                //checklist3.YesNoInd = "";
                                //checklist3.Comments = model.WorkStationDetails;
                                //checklist3.Sl = SL;
                                //checklist3.Status = "P";
                                //_repositorycontext.ExResourceassignmentChecklists.Add(checklist3);
                                //_repositorycontext.SaveChanges();

                                kickmodel.nstatus = "Transaction Update Successfully";
                            }
                            //SI =(from p in _repositorycontext.ExResourceassignmentstatuses where
                            //      p.PeLogn == model.PeLogn && p.CuIden == Convert.ToInt32(model.CuIden) && statusLister.Contains(p.Status) select  );


                        }
                    }
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

        [HttpGet("GetOFFBoardReason/{pelogn}/{cuiden}")]
        public IActionResult GetOFFBoardReason(string pelogn, int cuiden)
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
                    string Reason = "";
                    string Group = "";

                    var finddata = (from p in _repositorycontext.ExResourceassignmentstatuses
                                    where p.CuIden == cuiden && p.PeLogn == pelogn && p.Enddate == null && p.ApproveStatus=="A"
                                    select new
                                    {
                                        Reason = p.Reason,
                                        Group =p.Group
                                      
                                    }).Distinct().ToList();

                    if (finddata.Count > 0)
                    {
                        Reason = finddata[0].Reason;
                        Group = finddata[0].Group;
                    }

                    if(Reason.ToUpper()== "NBST5" || Reason.ToUpper() == "BNA" || Reason.ToUpper() == "BILLING")
                    {
                        var data = (from p in _repositorycontext.ExOffboardReasonMasters 
                                    where p.Id != 7 && p.Id != 2 && p.Id != 3 /*&& p.Id != 5*/ // we remove 5 ID to show reason replacement
                                    select new
                                    {
                                      value=  p.ShortDescription,
                                       label = p.ShortDescription 
                                    }).ToList();

                        dList.Add("Table", data);
                    }
                    else
                    {
                        var data = (from p in _repositorycontext.ExOffboardReasonMasters
                                    where p.Id != 2 && p.Id != 3 && p.Id != 4 /*&& p.Id != 5*/
                                    select new
                                    {
                                        value = p.ShortDescription,
                                        label = p.ShortDescription
                                    }).ToList();

                        dList.Add("Table", data);
                    }

                    var resourceassignemntstatus = (from El in _repositorycontext.ExResourceassignmentstatuses where El.PeLogn==pelogn && El.Enddate==null && El.CuIden==cuiden select El).ToList();
                    var ExResourceallocations = (from El in _repositorycontext.ExResourceallocations where El.CuIden==cuiden && El.PeLogn==pelogn && El.AllocEnddate==null select El).ToList();
                    var ExResourcebillpercents = (from El in _repositorycontext.ExResourcebillpercents where El.CuIden==cuiden && El.PeLogn==pelogn && El.BillpercentEnddt==null select El).ToList();
                    //var ExIpcustomerReasons = (from El in _repositorycontext.ExIpcustomerReasons where El.CuIden == cuiden && El.PeLogn == pelogn && El.Reason.ToUpper()=="NBST1" && El.en select El).ToList();
                    //var ExIpcustomerReasons = (from El in _repositorycontext.ExIpcustomerReasons where El.CuIden==cuiden && El.PeLogn==pelogn && El.gr select El).ToList();
                    
                    var IpElements = (from El in _edmdbcontext.IpElements select El).ToList();
                    var IpCategories = (from El in _edmdbcontext.IpCategories select El).ToList();
                    var ExStatusdescs = (from El in _repositorycontext.ExStatusdescs select El).ToList();
                    var IpPeople = (from El in _edmdbcontext.IpPeople select El).ToList();
                    var ExIppeople = (from El in _edmdbcontext.ExIppeople select El).ToList();
                    //var ExResourceassignmentstatuses = (from El in _edmdbcontext.IpElements select El).ToList();

                    var otherdata = (from p in resourceassignemntstatus
                                     join a in IpElements on p.Group equals a.ElCode
                                     join b in IpCategories on p.Role equals b.CaCode
                                     //join c in ExStatusdescs on p.Reason equals c.Level
                                     join c in ExStatusdescs on p.Reason equals c.Level into sc2
                                     from c in sc2.DefaultIfEmpty()
                                     join d in ExResourceallocations on p.PeLogn equals d.PeLogn into sc
                                     from d in sc.DefaultIfEmpty()
                                     join e in ExResourcebillpercents on p.PeLogn equals e.PeLogn into sc1
                                     from e in sc1.DefaultIfEmpty() 
                                     where p.CuIden == cuiden && p.ApproveStatus == "A"
                                     select new
                                     {
                                         Group = a.ElName,
                                         KickOff = p.KickOff.ToString("yyyy-MM-dd"),
                                         Role = b.CaName,
                                         Reason = c!=null ? c.StatusDesc : p.Reason,
                                         Allocation = d != null ? d.Allocation : 0,
                                         Billing = e != null ? e.Billpercent : 0,
                                         BillStartDate = e != null ? e.BillpercentStartdt.ToString("yyyy-MM-dd") : "" ,
                                         ReasonCode = p.Reason,
                                         Startdate = p.Startdate.ToString("yyyy-MM-dd"),
                                         AllocStartdt = d.AllocStartdt.ToString("yyyy-MM-dd")
                                     }).Distinct().ToList();

                    dList.Add("otherdata", otherdata);

                    var resourceassignemntstatus11 = (from El in _repositorycontext.ExResourceassignmentstatuses where El.Enddate == null && El.CuIden == cuiden select El).ToList();

                    var Replacingperson = (from p in resourceassignemntstatus11
                                           join b in IpPeople on new
                                           { User = p != null ? p.PeLogn : "" }
                   equals new { User = b != null ? b.PeLogn : "" } 
                               into cp1
                                           from b in cp1.DefaultIfEmpty()
                                           join c in ExIppeople on new
                                           { User = p != null ? p.PeLogn : "" }
                 equals new { User = c != null ? c.PeLogn : "" }
                             into cp2
                                           from c in cp2.DefaultIfEmpty()

                                           where p.CuIden == cuiden && p.Group==Group && p.Enddate ==null && p.Reason.ToUpper() =="NBST1" && p.ApproveStatus.ToUpper()=="A"
                                     select new
                                     {

                                     value= p!=null? p.PeLogn :"",
                                      label = b!=null? b.PeName + "( " + c.WwPersonId + " )" :""
                                     }).Distinct().ToList();

                    dList.Add("Replacingperson", Replacingperson);

                    response.Data = dList;
                    response.Status = true;
                    response.Message = "Success";
                    response.Error = "";
                    return Ok(response);
                }
            }
            catch (System.Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                response.Error = ex.ToString();
                return Ok(response);
            }
        }

        [HttpGet("ListBenchPeopleforPool/{pelogn}")]
        public IActionResult ListBenchPeopleforPool(string pelogn)
        {
            Dictionary<string, object> dList = new Dictionary<string, object>();
            Response response = new();
            try
            {
                Core core = new(_repositorycontext, _edmdbcontext); 
                string dept = core.getdepartment(pelogn);

                var emplist = (from ipex in _edmdbcontext.ExIppeople where ipex.QuitDateTemp == null select ipex).ToList();
                var ippersonlist = (from ipex in _edmdbcontext.IpPeople where ipex.PeQuit == null select ipex).ToList(); 

                var data21 = (from a in _repositorycontext.ExResourceassignmentstatuses
                              select a).ToList();
                var ippersonlist1 = (from ipex in _edmdbcontext.IpPeople where ipex.PeQuit ==null select ipex).ToList(); 

                var ListBenchResource = (from a in data21
                                         join b1 in ippersonlist1.ToList() on new
                                         { User = a != null ? a.PeLogn : "" }
                                                     equals new { User = b1 != null ? b1.PeLogn : "" }

                                                                 into cp
                                         from b1 in cp.DefaultIfEmpty()
                                         where a.CuIden.ToString() == "85" && a.Enddate == null && a.Status == "B"  /*&& b1.PeDept== dept*/
                                         //orderby b1.PeName ascending
                                         select new
                                         {
                                             value = a != null ? a.PeLogn : "",
                                             label = b1 != null ? b1.PeName : "",
                                             PeDept = b1 != null ?  b1.PeDept : "NA"
                                         }).Distinct().ToList();
                 

                var filterdata = ListBenchResource.Where(x => x.PeDept == dept).Select(x => x.value).ToList();

                var ListBenchResourceFinal = (from a in ippersonlist1
                                              join b1 in emplist.ToList() on new
                                              { User = a != null ? a.PeLogn : "" }
                                                   equals new { User = b1 != null ? b1.PeLogn : "" } 
                                                               into cp
                                              from b1 in cp.DefaultIfEmpty()
                                              join b2 in data21 on new
                                              { User = a != null ? a.PeLogn : "" }
                                                equals new { User = b2 != null ? b2.PeLogn : "" }
                                                            into cp1
                                              from b2 in cp1.DefaultIfEmpty()
                                              where filterdata.Contains(a.PeLogn)  && b2.Enddate==null && b2.CuIden==85 && b2.Status=="B"
                                              orderby b2.Startdate
                                              select new
                                              {
                                                  value = a.PeLogn,
                                                  label = a.PeName.ToUpper() + " (" + b1.WwPersonId + ")",
                                                  Startdate = b2.Startdate !=null ? b2.Startdate.ToString("yyyy-MM-dd") :null
                                              }).Distinct().ToList();


                dList.Add("ListBenchResource", ListBenchResourceFinal); 

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

        //public IActionResult Index()
        //{
        //    return View();
        //}

    }
}
