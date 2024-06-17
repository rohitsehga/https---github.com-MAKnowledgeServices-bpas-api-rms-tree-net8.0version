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
using Newtonsoft.Json;

namespace ResourceRequestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkFlowController : Controller
    {
        private readonly RepositoryDbContext _repositorycontext;
        private readonly EDMDbContext _edmdbcontext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private const string extraEmail = "ashwini.holla-non-empl@acuitykp.com";
        public IConfiguration Configuration { get; }

        public WorkFlowController(IHttpContextAccessor httpContextAccessor, IMapper mapper, RepositoryDbContext repositorycontext, EDMDbContext edmrepositorycontext, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;

            _mapper = mapper;
            _repositorycontext = repositorycontext;
            _edmdbcontext = edmrepositorycontext;
            Configuration = configuration;
        }

        [HttpGet("GetPendingOnbaordTransactions/{role}")]
        public IActionResult GetPendingComplianceOnbaordTransactions(string role)
        {
            Dictionary<string, object> dList = new Dictionary<string, object>();
            Response response = new();
            try
            {
                //string dept = core.getdepartment(pelogin);

                //string[] roleList = { "ADMIN", "EMGR", "CDH" };
                //var ExResourceassignmentstatuses = (from a in _repositorycontext.ExResourceassignmentstatuses select a).ToList();
                var ExResourceassignment = (from a in _repositorycontext.ExResourceassignments select a).ToList();
                var IPCustomerlist = (from a in _repositorycontext.IpCustomers select a).ToList();
                var ExStatusdescs = (from a in _repositorycontext.ExStatusdescs select a).ToList();
                //var ChecklistList = (from a in _repositorycontext.ExResourceassignmentChecklists select a).ToList();
                var IpPersonList = (from a in _edmdbcontext.IpPeople where a.PeQuit == null select a).ToList();
                var IpLocations = (from a in _edmdbcontext.IpLocations select a).ToList();
                //var IPElementList = (from a in _edmdbcontext.IpElements select a).ToList();
                //var IpLocationsList = (from a in _edmdbcontext.IpLocations select a).ToList();
                //var ExAccessMasters = (from a in _repositorycontext.ExAccessMasters select a).ToList();
                //var ExClientPlOwners = (from a in _repositorycontext.ExClientPlOwners select a).ToList();
                //DateTime todaydate = DateTime.Now;
                //var ITchecklistid = "7";


                if (role == "ComplianceTeam")
                {

                    var complianceonbaordpending = (from a in ExResourceassignment
                                                    join b in IpPersonList
                                 on new
                                 { User = a != null ? a.PeLogn : "" }
                  equals new { User = b != null ? b.PeLogn : "" } into sc1
                                                    from b in sc1.DefaultIfEmpty()
                                                    join c in IPCustomerlist
                               on new
                               { CLientcode = a != null ? a.CuIden.ToString() : "" }
                equals new { CLientcode = c != null ? c.CuIden.ToString() : "" } into sc2
                                                    from c in sc2.DefaultIfEmpty()

                                                    join d in ExStatusdescs
                            on new
                            { Status = a != null ? a.Reason : "" }
             equals new { Status = d != null ? d.Level : "" } into sc3
                                                    from d in sc3.DefaultIfEmpty()

                                                    join e in IpLocations
                         on new
                         { Location = b != null ? b.PeLocn : "" }
          equals new { Location = e != null ? e.IpLocn.ToString() : "" } into sc4
                                                    from e in sc4.DefaultIfEmpty()

                                                    where a.OnOff == 0 && a.ApproveStatus == "P" && a.Userapprovestatus == "A" && (a.ComplianceStatus == "P" || a.ComplianceStatus == null)
                                                    select new
                                                    {
                                                        ID = a.Id,
                                                        PeLogn = a.PeLogn,
                                                        CuIden = a.CuIden,
                                                        PeName = b.PeName,
                                                        CuComp = c.CuComp,
                                                        StatusDesc = d!=null ? d.StatusDesc : "NA",
                                                        KickOffDate = a != null ? a.KickOffDate.Value.ToString("yyyy-MM-dd") : "",
                                                        Allocation = a.Allocation,
                                                        Billpercent = a.Billpercent,
                                                        LnName = e.LnName

                                                    }).Distinct().ToList();

                    dList.Add("Table", complianceonbaordpending);
                }
                else if (role == "FinanceTeam")
                {

                    var Financeonbaordpending = (from a in ExResourceassignment
                                                 join b in IpPersonList
                              on new
                              { User = a != null ? a.PeLogn : "" }
               equals new { User = b != null ? b.PeLogn : "" } into sc1
                                                 from b in sc1.DefaultIfEmpty()
                                                 join c in IPCustomerlist
                            on new
                            { CLientcode = a != null ? a.CuIden.ToString() : "" }
             equals new { CLientcode = c != null ? c.CuIden.ToString() : "" } into sc2
                                                 from c in sc2.DefaultIfEmpty()

                                                 join d in ExStatusdescs
                         on new
                         { Status = a != null ? a.Reason : "" }
          equals new { Status = d != null ? d.Level : "" } into sc3
                                                 from d in sc3.DefaultIfEmpty()

                                                 where a.OnOff == 0 && a.ApproveStatus == "P" && a.Userapprovestatus == "A" && a.FinanceStatus == "P"
                                                 && (a.Reason == "BNA" || a.Reason == "NBST5")
                                                 select new
                                                 {
                                                     ID = a.Id,
                                                     PeLogn = a.PeLogn,
                                                     CuIden = a.CuIden,
                                                     PeName = b.PeName,
                                                     CuComp = c.CuComp,
                                                     StatusDesc = d.StatusDesc,
                                                     KickOffDate = a != null ? a.KickOffDate.Value.ToString("yyyy-MM-dd") : "",
                                                     Allocation = a.Allocation,
                                                     Billpercent = a.Billpercent,
                                                     BillDate = a != null ? a.BillDate.Value.ToString("yyyy-MM-dd") : ""

                                                 }).Distinct().ToList();

                    dList.Add("Table", Financeonbaordpending);
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

        [HttpPost("ComplianceOnbaordAction")]
        public IActionResult ComplianceOnbaordAction(ComplianceOnbaordAction model)
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

                    var finddata = (from p in _repositorycontext.ExResourceassignments
                                    where p.Id == model.ID
                                    select new
                                    {
                                        FinanceStatus = p.FinanceStatus,
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
                                        ReqId = p.ReqId,
                                        RepValognid = p.RepValognid

                                    }).ToList();

                    string FinanceStatus = "";
                    string Reason = "";
                    string PeLogn = "";
                    string Groups = "";
                    string AssignType = "";
                    string PeLmgr = "";
                    string RepValognid = "";
                    int ReqId = 0;
                    int CuIden = 0;
                    DateTime BillDate = DateTime.Now;
                    DateTime KickoffDate = DateTime.Now;
                    decimal? BillPercent = 0;
                    decimal? Allocation = 0;
                    int Sl = 0;
                    if (finddata.Count > 0)
                    {
                        FinanceStatus = finddata[0].FinanceStatus;
                        Reason = finddata[0].Reason;
                        RepValognid = finddata[0].RepValognid;
                        BillDate = Convert.ToDateTime(finddata[0].BillDate);
                        BillPercent = finddata[0].Billpercent;
                        Allocation = finddata[0].Allocation;
                        PeLmgr = finddata[0].PeLmgr;
                        ReqId = Convert.ToInt16(finddata[0].ReqId);
                        KickoffDate = Convert.ToDateTime(finddata[0].KickOffDate);
                        PeLogn = finddata[0].PeLogn;
                        Groups = finddata[0].Groups;
                        AssignType = finddata[0].AssignType;
                        Sl = Convert.ToInt16(finddata[0].Sl);
                        CuIden = Convert.ToInt16(finddata[0].CuIden);
                    }


                    KickOffStatus kickmodel = new KickOffStatus();
                    ResultTemp resultModel = new ResultTemp();

                    string[] reasonList = { "BNA", "BILLING", "NBST5" };

                    if ((FinanceStatus == "A" && model.ComplianceAction == "A" && reasonList.Contains(Reason)) || (model.ComplianceAction == "A" && !reasonList.Contains(Reason)))
                    {
                        if (BillDate.ToString() == "1/1/0001 12:00:00 AM")
                        {
                            ExResourceassignment exResourceassignment = _repositorycontext.ExResourceassignments.Where(x => x.ApproveStatus == "P"
                       && x.Id == model.ID).FirstOrDefault();
                            exResourceassignment.ComplianceStatus = model.ComplianceAction;
                            exResourceassignment.ComplianceComments = model.ComplianceComments;
                            exResourceassignment.ComplianceEntrystamp = DateTime.Now;
                            exResourceassignment.ComplianceLognid = model.ComplianceLoginID;
                            exResourceassignment.Usageclauseid = model.UsageClauseID;
                            exResourceassignment.Blackout = model.BlackOut;
                            exResourceassignment.Ndasigneddate = model.NDASignedDate;
                            exResourceassignment.Sow = model.SOWNo;
                            exResourceassignment.ApproveStatus = "A";
                            exResourceassignment.BillDate = null;
                            exResourceassignment.BillingRate = 1;
                            exResourceassignment.Jobrefno = null;
                            exResourceassignment.BcatId = null;
                            exResourceassignment.ProjDuration = null;
                            exResourceassignment.ProjFrequency = null;
                            exResourceassignment.BillFrequency = null;
                            exResourceassignment.Billpercent = BillPercent;
                            _repositorycontext.ExResourceassignments.Update(exResourceassignment);
                            //_repositorycontext.SaveChanges();

                            ExResourceassignmentstatus exResourceassignmentstatus = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.Startdate == KickoffDate
                       && x.Enddate == null && x.ApproveStatus == "P" && x.PeLogn == PeLogn && x.CuIden == CuIden).FirstOrDefault();
                            exResourceassignmentstatus.FinStatus = "A";
                            exResourceassignmentstatus.ApproveStatus = "A";
                            exResourceassignmentstatus.BillStart = null;
                            _repositorycontext.ExResourceassignmentstatuses.Update(exResourceassignmentstatus);
                            //_repositorycontext.SaveChanges();
                        }
                        else
                        {
                            ExResourceassignment exResourceassignment = _repositorycontext.ExResourceassignments.Where(x => x.ApproveStatus == "P"
                       && x.Id == model.ID).FirstOrDefault();
                            exResourceassignment.ComplianceStatus = model.ComplianceAction;
                            exResourceassignment.ComplianceComments = model.ComplianceComments;
                            exResourceassignment.ComplianceEntrystamp = DateTime.Now;
                            exResourceassignment.ComplianceLognid = model.ComplianceLoginID;
                            exResourceassignment.Usageclauseid = model.UsageClauseID;
                            exResourceassignment.Blackout = model.BlackOut;
                            exResourceassignment.Ndasigneddate = model.NDASignedDate;
                            exResourceassignment.Sow = model.SOWNo;
                            exResourceassignment.ApproveStatus = "A";
                            exResourceassignment.BillDate = BillDate;
                            exResourceassignment.BillingRate = 1;
                            exResourceassignment.Jobrefno = null;
                            exResourceassignment.BcatId = null;
                            exResourceassignment.ProjDuration = null;
                            exResourceassignment.ProjFrequency = null;
                            exResourceassignment.BillFrequency = null;
                            exResourceassignment.Billpercent = BillPercent;
                            _repositorycontext.ExResourceassignments.Update(exResourceassignment);
                            //_repositorycontext.SaveChanges();

                            ExResourceassignmentstatus exResourceassignmentstatus = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.Startdate == KickoffDate
                       && x.Enddate == null && x.ApproveStatus == "P" && x.PeLogn == PeLogn && x.CuIden == CuIden).FirstOrDefault();
                            exResourceassignmentstatus.FinStatus = "A";
                            exResourceassignmentstatus.ApproveStatus = "A";
                            exResourceassignmentstatus.BillStart = BillDate;
                            _repositorycontext.ExResourceassignmentstatuses.Update(exResourceassignmentstatus);
                            //_repositorycontext.SaveChanges();
                        }




                        var finddata1 = (from p in _repositorycontext.ExResourceassignmentstatuses
                                         where p.CuIden.ToString() == "85" && p.PeLogn == PeLogn && p.Enddate == null
                                         select new
                                         {
                                             CuIden = p.CuIden,
                                             Startdate = p.Startdate
                                         }).Distinct().ToList();
                        DateTime StartDate = DateTime.Now;
                        if (finddata1.Count > 0)
                        {
                            StartDate = Convert.ToDateTime(finddata1[0].Startdate);
                            if (StartDate > KickoffDate.AddDays(-1))
                            {
                                ExResourceassignmentstatus exResourceassignmentstatus1 = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.PeLogn == PeLogn
              && x.Status == "B" && x.CuIden == 85 && x.Enddate == null).FirstOrDefault();
                                exResourceassignmentstatus1.Enddate = StartDate;
                                exResourceassignmentstatus1.DateOfMove = StartDate;
                                _repositorycontext.ExResourceassignmentstatuses.Update(exResourceassignmentstatus1);
                                //_repositorycontext.SaveChanges();

                            }
                            else
                            {
                                ExResourceassignmentstatus exResourceassignmentstatus1 = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.PeLogn == PeLogn
            && x.Status == "B" && x.CuIden == 85 && x.Enddate == null).FirstOrDefault();
                                exResourceassignmentstatus1.Enddate = KickoffDate.AddDays(-1);
                                exResourceassignmentstatus1.DateOfMove = KickoffDate.AddDays(-1);
                                _repositorycontext.ExResourceassignmentstatuses.Update(exResourceassignmentstatus1);
                                //_repositorycontext.SaveChanges(); 

                            }

                        }

                        var finddata2 = (from p in _edmdbcontext.ExReportingmanagers
                                         where p.CuIden.ToString() == "85" && p.Valognid == PeLogn && p.Enddate == null && p.Type == 1
                                         select new
                                         {
                                             CuIden = p.CuIden,
                                             Startdate = p.Startdt
                                         }).Distinct().ToList();
                        DateTime StartDate1 = DateTime.Now;
                        if (finddata2.Count > 0)
                        {
                            StartDate1 = Convert.ToDateTime(finddata2[0].Startdate);
                            if (StartDate1 > KickoffDate.AddDays(-1))
                            {
                                ExReportingmanager exreportingmanager = _edmdbcontext.ExReportingmanagers.Where(x => x.Valognid == PeLogn
                            && x.Enddate == null && x.CuIden == 85 && x.Type == 1).FirstOrDefault();
                                exreportingmanager.Enddate = Convert.ToDateTime(StartDate1);
                                exreportingmanager.Status = "D";
                                exreportingmanager.EnddateStamp = DateTime.Now;
                                exreportingmanager.EnddateUserlognid = model.ComplianceLoginID;
                                _edmdbcontext.ExReportingmanagers.Update(exreportingmanager);

                            }
                            else
                            {
                                ExReportingmanager exreportingmanager = _edmdbcontext.ExReportingmanagers.Where(x => x.Valognid == PeLogn
                    && x.Enddate == null && x.CuIden == 85 && x.Type == 1).FirstOrDefault();
                                exreportingmanager.Enddate = KickoffDate.AddDays(-1);
                                exreportingmanager.Status = "D";
                                exreportingmanager.EnddateStamp = DateTime.Now;
                                exreportingmanager.EnddateUserlognid = model.ComplianceLoginID;
                                _edmdbcontext.ExReportingmanagers.Update(exreportingmanager);
                                //_repositorycontext.SaveChanges(); 
                            }
                        }



                        ExResourceallocation statusobj = new ExResourceallocation();
                        statusobj.Sl = Sl;
                        statusobj.CuIden = CuIden;
                        statusobj.PeLogn = PeLogn;
                        statusobj.ProjId = 0;
                        statusobj.KickOff = KickoffDate;
                        statusobj.DateOfMove = null;
                        statusobj.AllocStartdt = KickoffDate;
                        statusobj.AllocEnddate = null;
                        statusobj.Allocation = Allocation;
                        statusobj.Userlognid = model.ComplianceLoginID;
                        statusobj.Entrystamp = DateTime.Now;
                        statusobj.Status = "A";
                        _repositorycontext.ExResourceallocations.Add(statusobj);
                        //_repositorycontext.SaveChanges();

                        ExReportingmanager exreportingmanager1 = new ExReportingmanager();
                        exreportingmanager1.CuIden = CuIden;
                        exreportingmanager1.ProjId = 0;
                        exreportingmanager1.Group = Groups;
                        exreportingmanager1.Valognid = PeLogn;
                        exreportingmanager1.Mngrlognid = PeLmgr;
                        exreportingmanager1.KickOff = KickoffDate;
                        exreportingmanager1.Startdt = KickoffDate;
                        exreportingmanager1.EnddateStamp = DateTime.Now;
                        exreportingmanager1.Status = "A";
                        exreportingmanager1.Type = 1;
                        exreportingmanager1.Userlognid = model.ComplianceLoginID;
                        _edmdbcontext.ExReportingmanagers.Update(exreportingmanager1);

                        ExIpcustomerGroup rolemodel = new ExIpcustomerGroup();
                        rolemodel.Sl = Sl;
                        rolemodel.CuIden = CuIden;
                        rolemodel.ProjId = 0;
                        rolemodel.PeLogn = PeLogn;
                        rolemodel.Group = Groups;
                        rolemodel.KickOff = KickoffDate;
                        rolemodel.DateOfMove = null;
                        rolemodel.GroupStartdt = KickoffDate;
                        rolemodel.GroupEnddate = null;
                        rolemodel.Userlognid = model.ComplianceLoginID;
                        rolemodel.Entrystamp = DateTime.Now;
                        rolemodel.Status = "A";
                        rolemodel.EnddateStamp = null;
                        rolemodel.EnddateUserlognid = null;
                        _repositorycontext.ExIpcustomerGroups.Add(rolemodel);
                        //_repositorycontext.SaveChanges();

                        ExIpcustomerRole statusobj1 = new ExIpcustomerRole();
                        statusobj1.Sl = Sl;
                        statusobj1.CuIden = CuIden;
                        statusobj1.ProjId = 0;
                        statusobj1.PeLogn = PeLogn;
                        statusobj1.Role = AssignType;
                        statusobj1.KickOff = KickoffDate;
                        statusobj1.DateOfMove = null;
                        statusobj1.RoleStartdt = KickoffDate;
                        statusobj1.RoleEnddate = null;
                        statusobj1.Status = "A";
                        statusobj1.Userlognid = model.ComplianceLoginID;
                        statusobj1.Entrystamp = DateTime.Now;
                        _repositorycontext.ExIpcustomerRoles.Add(statusobj1);
                        //_repositorycontext.SaveChanges();

                        ExIpcustomerTeam statusobj2 = new ExIpcustomerTeam();
                        statusobj2.Sl = Sl;
                        statusobj2.CuIden = CuIden;
                        statusobj2.ProjId = 0;
                        statusobj2.PeLogn = PeLogn;
                        statusobj2.KickOff = KickoffDate;
                        statusobj2.DateOfMove = null;
                        statusobj2.Status = "A";
                        statusobj2.Userlognid = model.ComplianceLoginID;
                        statusobj2.Entrystamp = DateTime.Now;
                        _repositorycontext.ExIpcustomerTeams.Add(statusobj2);
                        //_repositorycontext.SaveChanges();

                        ExIpcustomerGeo statusobj3 = new ExIpcustomerGeo();
                        statusobj3.Sl = Sl;
                        statusobj3.CuIden = CuIden;
                        statusobj3.ProjId = 0;
                        statusobj3.PeLogn = PeLogn;
                        statusobj3.Group = Groups;
                        statusobj3.Geo = "27";
                        statusobj3.KickOff = KickoffDate;
                        statusobj3.GeoStartdt = KickoffDate;
                        statusobj3.DateOfMove = null;
                        statusobj3.Status = "A";
                        statusobj3.Userlognid = model.ComplianceLoginID;
                        statusobj3.Entrystamp = DateTime.Now;
                        _repositorycontext.ExIpcustomerGeos.Add(statusobj3);
                        //_repositorycontext.SaveChanges();

                        ExIpcustomerReason rolemodel1 = new ExIpcustomerReason();
                        rolemodel1.Sl = Sl;
                        rolemodel1.CuIden = CuIden;
                        rolemodel1.ProjId = 0;
                        rolemodel1.PeLogn = PeLogn;
                        rolemodel1.Reason = Reason;
                        rolemodel1.KickOff = KickoffDate;
                        rolemodel1.EffectiveFrom = KickoffDate;
                        rolemodel1.EffectiveTo = null;
                        rolemodel1.Replacewith = Reason.ToUpper()=="NBST1" ? RepValognid :null;
                        rolemodel1.Userlognid = model.ComplianceLoginID;
                        rolemodel1.Entrystamp = DateTime.Now;
                        rolemodel1.Status = "A";
                        rolemodel1.EnddateStamp = null;
                        rolemodel1.EnddateUserlognid = null;
                        _repositorycontext.ExIpcustomerReasons.Add(rolemodel1);
                        //_repositorycontext.SaveChanges();

                        ExIpcustomerBilling exIpcustomerBilling = new ExIpcustomerBilling();
                        exIpcustomerBilling.Sl = Sl;
                        exIpcustomerBilling.CuIden = CuIden;
                        exIpcustomerBilling.ProjId = 0;
                        exIpcustomerBilling.PeLogn = PeLogn;
                        exIpcustomerBilling.Group = Groups;
                        exIpcustomerBilling.Jobrefno = null;
                        exIpcustomerBilling.BillingRole = AssignType;
                        exIpcustomerBilling.KickOff = KickoffDate;
                        exIpcustomerBilling.BillStartdt = KickoffDate;
                        exIpcustomerBilling.Status = "A";
                        exIpcustomerBilling.Entrystamp = DateTime.Now;
                        exIpcustomerBilling.Userlognid = model.ComplianceLoginID;
                        _repositorycontext.ExIpcustomerBillings.Add(exIpcustomerBilling);
                        //_repositorycontext.SaveChanges();

                        ExIpcustomerSow exIpcustomerSow1 = new ExIpcustomerSow();
                        exIpcustomerSow1.Sl = Sl;
                        exIpcustomerSow1.CuIden = CuIden;
                        exIpcustomerSow1.ProjId = 0;
                        exIpcustomerSow1.PeLogn = PeLogn;
                        exIpcustomerSow1.KickOff = KickoffDate;
                        exIpcustomerSow1.Sow = model.SOWNo;
                        exIpcustomerSow1.SowStartdt = KickoffDate;
                        exIpcustomerSow1.Status = "A";
                        exIpcustomerSow1.Entrystamp = DateTime.Now;
                        exIpcustomerSow1.Userlognid = model.ComplianceLoginID;
                        _repositorycontext.ExIpcustomerSows.Add(exIpcustomerSow1);
                        //_repositorycontext.SaveChanges();

                        if (Reason == "BNA" || Reason == "NBST5")
                        {
                            ExResourcebillpercent exresourcebillpercentnew = new ExResourcebillpercent();
                            exresourcebillpercentnew.Sl = Sl;
                            exresourcebillpercentnew.PeLogn = PeLogn;
                            exresourcebillpercentnew.CuIden = CuIden;
                            exresourcebillpercentnew.ProjId = 0;
                            exresourcebillpercentnew.KickOff = KickoffDate;
                            exresourcebillpercentnew.DateOfMove = null;
                            exresourcebillpercentnew.BillpercentStartdt = BillDate;
                            exresourcebillpercentnew.BillpercentEnddt = null;
                            exresourcebillpercentnew.Billpercent = BillPercent;
                            exresourcebillpercentnew.Entrystamp = DateTime.Now;
                            exresourcebillpercentnew.Userlognid = model.ComplianceLoginID;
                            exresourcebillpercentnew.EnddateStamp = null;
                            exresourcebillpercentnew.EnddateUserlognid = null;
                            exresourcebillpercentnew.Status = "A";
                            exresourcebillpercentnew.FinStatus = "A";
                            _repositorycontext.ExResourcebillpercents.Add(exresourcebillpercentnew);
                            //_repositorycontext.SaveChanges();
                        }

                        _repositorycontext.SaveChanges();
                        _edmdbcontext.SaveChanges();

                        if (model.ComplianceAction == "A")
                        {
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
                                             where p.PeLogn == model.ComplianceLoginID
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
                                                     where p.PeLogn == model.ComplianceLoginID
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
                                                   PeMail = p.ParameterValue

                                               }).Take(1).ToList();

                            if (reasonList.Contains(Reason))
                            {
                                var findfinanceid = (from p in _repositorycontext.ExGeneralParameterConfigurations
                                                     where p.ParameterName == "Finance Notification ID"
                                                     select new
                                                     {
                                                         PeMail = p.ParameterValue

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
                                          where p.CuIden == CuIden && p.Enddate == null && p.Role == "DM" && b.PeDept==empdepratment
                                          select new
                                          {
                                              PeMail = b.PeMail

                                          }).Distinct().ToList();

                            var personemailid = (from p in _edmdbcontext.IpPeople
                                                 where p.PeLogn == model.ComplianceLoginID
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

                            //var cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(personemailid).ToList();

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

                            var cclistfinal = findPMO.Union(findemgr).Union(finddm).Union(tolistfinal).Union(ITGroupID).Union(AdminGroupID).ToList();

                            if (findplowner.Count > 0)
                            {
                                cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(tolistfinal).Union(ITGroupID).Union(AdminGroupID).ToList();
                            }

                            //var cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(tolistfinal).Union(ITGroupID).Union(AdminGroupID).ToList();

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
                                    tttttt = tttttt + tolistfinal[i].PeMail;
                                }
                            }

                            //cc = plowner +";" + pmomail + ";" + emgrmail + ";" + dmmail + ";" + personselfmailid;

                            string subject = string.Empty;
                            if (reasonList.Contains(Reason))
                            {
                                subject = "Onboard Approved By - Compliance ( " + empname + " to " + clientcode + "(Reason: " + reasondesc + ")";
                            }
                            else
                            {
                                subject = "Onboard Approved By - Compliance " + empname + " to " + clientcode + "(Reason: " + reasondesc + ")";
                            }

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

                            ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Reason</TD><TD >&nbsp;" + reasondesc + "</TD></TR>";


                            //if (model.Reason.ToUpper() == "NBST1")
                            //{
                            //    ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Replacing</TD><TD >&nbsp;" + empnamereplacewith + "</TD></TR>";
                            //}


                            ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Department</TD><TD >&nbsp;" + departfullname + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Comments</TD><TD >&nbsp;" + model.ComplianceComments + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Request ID</TD><TD >&nbsp;" + (ReqId == -1 ? "NA" : ReqId) + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Kick off Date</TD><TD >&nbsp;" + KickoffDate.ToString("yyyy-MM-dd") + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Action By</TD><TD >&nbsp;" + empnamedonetransaction + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Action On</TD><TD >&nbsp;" + DateTime.Now + "</TD></TR>" +
             "<TR><TD BgColor='lavender'><B>Checklist For IT</TD><TD ></TD></TR>" +
              "<TR><TD BgColor='lavender'><B>Shared Folder Access</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 6 select a.Comments).FirstOrDefault() + "</TD></TR>" +
               "<TR><TD BgColor='lavender'><B>Email Group Access</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 7 select a.Comments).FirstOrDefault() + "</TD></TR>" +
                 "<TR><TD BgColor='lavender'><B>Checklist For Admin</TD><TD ></TD></TR>" +
              "<TR><TD BgColor='lavender'><B>Client Room Access Details</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 8 select a.Comments).FirstOrDefault() + "</TD></TR>" +
               "<TR><TD BgColor='lavender'><B>Workstation Details</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 9 select a.Comments).FirstOrDefault() + "</TD></TR>";

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

                            string[] tomail11 = new string[personemailid.Count];
                            if (cclistfinal.Count > 0)
                            {
                                for (int i = 0; i < personemailid.Count; i++)
                                {
                                    tomail11[i] = tolistfinal[i].PeMail;
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
                        }

                        kickmodel.nstatus = "Update Sucessfully";

                    }
                    else
                    {
                        if (model.ComplianceAction == "A")
                        {
                            ExResourceassignment exResourceassignment = _repositorycontext.ExResourceassignments.Where(x => x.ApproveStatus == "P"
                   && x.Id == model.ID && x.ComplianceStatus == "P").FirstOrDefault();
                            exResourceassignment.ComplianceStatus = model.ComplianceAction;
                            exResourceassignment.ComplianceComments = model.ComplianceComments;
                            exResourceassignment.ComplianceEntrystamp = DateTime.Now;
                            exResourceassignment.ComplianceLognid = model.ComplianceLoginID;
                            exResourceassignment.Usageclauseid = model.UsageClauseID;
                            exResourceassignment.Blackout = model.BlackOut;
                            exResourceassignment.Ndasigneddate = model.NDASignedDate;
                            exResourceassignment.Sow = model.SOWNo;
                            exResourceassignment.Billpercent = BillPercent;

                            _repositorycontext.SaveChanges();
                            _edmdbcontext.SaveChanges();

                            if (model.ComplianceAction == "A")
                            {
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
                                                 where p.PeLogn == model.ComplianceLoginID
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
                                                         where p.PeLogn == model.ComplianceLoginID
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
                                                       PeMail = p.ParameterValue

                                                   }).Take(1).ToList();

                                if (reasonList.Contains(Reason))
                                {
                                    var findfinanceid = (from p in _repositorycontext.ExGeneralParameterConfigurations
                                                         where p.ParameterName == "Finance Notification ID"
                                                         select new
                                                         {
                                                             PeMail = p.ParameterValue

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
                                              where p.CuIden == CuIden && p.Enddate == null && p.Role == "DM" && b.PeDept==empdepratment
                                              select new
                                              {
                                                  PeMail = b.PeMail

                                              }).Distinct().ToList();

                                var personemailid = (from p in _edmdbcontext.IpPeople
                                                     where p.PeLogn == model.ComplianceLoginID
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

                                //var listA = new List<string> { "ankur.goel@acuitykp.com" };
                                //var listB = new List<string> { "rohit.sehgal@acuitykp.com" };
                                //var listFinal = listA.Union(listB);

                                //var cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(personemailid).ToList();

                                var cclistfinal = findPMO.Union(findemgr).Union(finddm).Union(tolistfinal).Union(ITGroupID).Union(AdminGroupID).ToList();

                                if (findplowner.Count > 0)
                                {
                                    cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(tolistfinal).Union(ITGroupID).Union(AdminGroupID).ToList();
                                }


                                //var cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(tolistfinal).Union(ITGroupID).Union(AdminGroupID).ToList();

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
                                        tttttt = tttttt + tolistfinal[i].PeMail;
                                    }
                                }

                                //cc = plowner +";" + pmomail + ";" + emgrmail + ";" + dmmail + ";" + personselfmailid;

                                string subject = string.Empty;
                                if (reasonList.Contains(Reason))
                                {
                                    subject = "Onboard Approved By - Compliance ( " + empname + " to " + clientcode + "(Reason: " + reasondesc + ")";
                                }
                                else
                                {
                                    subject = "Onboard Approved By - Compliance " + empname + " to " + clientcode + "(Reason: " + reasondesc + ")";
                                }

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

                                ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Reason</TD><TD >&nbsp;" + reasondesc + "</TD></TR>";


                                //if (model.Reason.ToUpper() == "NBST1")
                                //{
                                //    ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Replacing</TD><TD >&nbsp;" + empnamereplacewith + "</TD></TR>";
                                //}


                                ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Department</TD><TD >&nbsp;" + departfullname + "</TD></TR>" +
                "<TR><TD BgColor='lavender'><B>Comments</TD><TD >&nbsp;" + model.ComplianceComments + "</TD></TR>" +
                "<TR><TD BgColor='lavender'><B>Request ID</TD><TD >&nbsp;" + (ReqId == -1 ? "NA" : ReqId) + "</TD></TR>" +
                "<TR><TD BgColor='lavender'><B>Kick off Date</TD><TD >&nbsp;" + KickoffDate.ToString("yyyy-MM-dd") + "</TD></TR>" +
                "<TR><TD BgColor='lavender'><B>Action By</TD><TD >&nbsp;" + empnamedonetransaction + "</TD></TR>" +
                "<TR><TD BgColor='lavender'><B>Action On</TD><TD >&nbsp;" + DateTime.Now + "</TD></TR>" +
                 "<TR><TD BgColor='lavender'><B>Checklist For IT</TD><TD ></TD></TR>" +
                  "<TR><TD BgColor='lavender'><B>Shared Folder Access</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 6 select a.Comments).FirstOrDefault() + "</TD></TR>" +
                   "<TR><TD BgColor='lavender'><B>Email Group Access</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 7 select a.Comments).FirstOrDefault() + "</TD></TR>" +
                     "<TR><TD BgColor='lavender'><B>Checklist For Admin</TD><TD ></TD></TR>" +
                  "<TR><TD BgColor='lavender'><B>Client Room Access Details</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 8 select a.Comments).FirstOrDefault() + "</TD></TR>" +
                   "<TR><TD BgColor='lavender'><B>Workstation Details</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 9 select a.Comments).FirstOrDefault() + "</TD></TR>";

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

                                string[] tomail11 = new string[personemailid.Count];
                                if (cclistfinal.Count > 0)
                                {
                                    for (int i = 0; i < personemailid.Count; i++)
                                    {
                                        tomail11[i] = tolistfinal[i].PeMail;
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
                            }

                            kickmodel.nstatus = "Update Sucessfully";
                        }
                        else
                        {
                            ExResourceassignment exResourceassignment = _repositorycontext.ExResourceassignments.Where(x => x.ApproveStatus == "P"
                   && x.Id == model.ID && x.ComplianceStatus == "P").FirstOrDefault();
                            exResourceassignment.ComplianceStatus = model.ComplianceAction;
                            exResourceassignment.ComplianceComments = model.ComplianceComments;
                            exResourceassignment.ComplianceEntrystamp = DateTime.Now;
                            exResourceassignment.ComplianceLognid = model.ComplianceLoginID;
                            exResourceassignment.Usageclauseid = model.UsageClauseID;
                            exResourceassignment.Blackout = model.BlackOut;
                            exResourceassignment.Ndasigneddate = model.NDASignedDate;
                            exResourceassignment.Sow = model.SOWNo;
                            exResourceassignment.Billpercent = BillPercent;
                            exResourceassignment.ApproveStatus = model.ComplianceAction;

                            ExResourceassignmentstatus exResourceassignmentstatus1 = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.PeLogn == PeLogn
                      && x.KickOff == KickoffDate && x.CuIden == CuIden && x.ApproveStatus == "P").FirstOrDefault();
                            _repositorycontext.ExResourceassignmentstatuses.Remove(exResourceassignmentstatus1);


                            _repositorycontext.SaveChanges();
                            _edmdbcontext.SaveChanges();


                            kickmodel.nstatus = "Update Sucessfully";
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

        [HttpGet("GetClientSOW/{cuiden}")]
        public IActionResult GetClientSOW(string cuiden)
        {
            Dictionary<string, object> dList = new Dictionary<string, object>();
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
                    if (cuiden == "0") {
                        var sowdata = (from p in _repositorycontext.ExResourceassignments
                                       join a in _repositorycontext.ExClientsows on p.CuIden equals a.CuIden into sc
                                       from a in sc.DefaultIfEmpty()
                                       where p.ApproveStatus == "P"
                                       select new
                                       {
                                           CuIden = p.CuIden,
                                           value = a.Sowno != null ? a.Sowno : "NA",
                                           label = a.Sowno != null ? a.Sowno : "NA"

                                       }).Distinct().ToList();

                        dList.Add("Table", sowdata);
                    }
                    else
                    {
                        var sowdata = (from p in _repositorycontext.ExClientsows
                                       where p.Status == "A" && p.CuIden.ToString() == cuiden
                                       select new
                                       {
                                           value = p.Sowno,
                                           label = p.Sowno

                                       }).Distinct().ToList();

                        dList.Add("Table", sowdata);
                    }



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

        [HttpPost("FinanceOnbaordAction")]
        public IActionResult FinanceOnbaordAction(FinanceOnbaordAction model)
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

                    var finddata = (from p in _repositorycontext.ExResourceassignments
                                    where p.Id == model.ID
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
                                        ReqId =p.ReqId

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
                    if (finddata.Count > 0)
                    {
                        ComplianceStatus = finddata[0].ComplianceStatus;
                        Reason = finddata[0].Reason;
                        BillDate = Convert.ToDateTime(finddata[0].BillDate);
                        BillPercent = finddata[0].Billpercent;
                        Allocation = finddata[0].Allocation;
                        PeLmgr = finddata[0].PeLmgr;
                        KickoffDate = Convert.ToDateTime(finddata[0].KickOffDate);
                        PeLogn = finddata[0].PeLogn;
                        Groups = finddata[0].Groups;
                        AssignType = finddata[0].AssignType;
                        Sl = Convert.ToInt16(finddata[0].Sl);
                        CuIden = Convert.ToInt16(finddata[0].CuIden);
                        ReqId = Convert.ToInt16(finddata[0].ReqId);
                    }


                    KickOffStatus kickmodel = new KickOffStatus();
                    ResultTemp resultModel = new ResultTemp();

                    string[] reasonList = { "BNA", "BILLING", "NBST5" };

                    if ((ComplianceStatus == "A" && model.FinanceAction == "A" && reasonList.Contains(Reason)) || (model.FinanceAction == "A" && !reasonList.Contains(Reason)))
                    {
                        if (BillDate.ToString() == "1/1/0001 12:00:00 AM")
                        {
                            ExResourceassignment exResourceassignment = _repositorycontext.ExResourceassignments.Where(x => x.ApproveStatus == "P"
                       && x.Id == model.ID).FirstOrDefault();
                            exResourceassignment.FinanceStatus = model.FinanceAction;
                            exResourceassignment.FinanceComments = model.FinanceComments;
                            exResourceassignment.FinanceEntrystamp = DateTime.Now;
                            exResourceassignment.FinanceLognid = model.FinanceLoginID;
                            exResourceassignment.Sow = model.SOWNo;
                            exResourceassignment.ApproveStatus = "A";
                            exResourceassignment.BillDate = null;
                            exResourceassignment.BillingRate = 1;
                            exResourceassignment.Jobrefno = null;
                            exResourceassignment.BcatId = null;
                            exResourceassignment.ProjDuration = null;
                            exResourceassignment.ProjFrequency = null;
                            exResourceassignment.BillFrequency = null;
                            exResourceassignment.Billpercent = BillPercent;
                            exResourceassignment.BillEntity = model.BillEntity;
                            _repositorycontext.ExResourceassignments.Update(exResourceassignment);
                            //_repositorycontext.SaveChanges();

                            ExResourceassignmentstatus exResourceassignmentstatus = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.Startdate == KickoffDate
                       && x.Enddate == null && x.ApproveStatus == "P" && x.PeLogn == PeLogn && x.CuIden == CuIden).FirstOrDefault();
                            exResourceassignmentstatus.FinStatus = "A";
                            exResourceassignmentstatus.ApproveStatus = "A";
                            exResourceassignmentstatus.BillStart = null;
                            _repositorycontext.ExResourceassignmentstatuses.Update(exResourceassignmentstatus);
                            //_repositorycontext.SaveChanges();
                        }
                        else
                        {
                            ExResourceassignment exResourceassignment = _repositorycontext.ExResourceassignments.Where(x => x.ApproveStatus == "P"
                       && x.Id == model.ID).FirstOrDefault();
                            exResourceassignment.FinanceStatus = model.FinanceAction;
                            exResourceassignment.FinanceComments = model.FinanceComments;
                            exResourceassignment.FinanceEntrystamp = DateTime.Now;
                            exResourceassignment.FinanceLognid = model.FinanceLoginID;
                            exResourceassignment.Sow = model.SOWNo;
                            exResourceassignment.ApproveStatus = "A";
                            exResourceassignment.BillDate = model.billstartdate;
                            exResourceassignment.BillingRate = 1;
                            exResourceassignment.Jobrefno = null;
                            exResourceassignment.BcatId = null;
                            exResourceassignment.ProjDuration = null;
                            exResourceassignment.ProjFrequency = null;
                            exResourceassignment.BillFrequency = null;
                            exResourceassignment.Billpercent = BillPercent;
                            exResourceassignment.BillEntity = model.BillEntity;
                            _repositorycontext.ExResourceassignments.Update(exResourceassignment);
                            //_repositorycontext.SaveChanges();


                            ExResourceassignmentstatus exResourceassignmentstatus = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.Startdate == KickoffDate
                   && x.Enddate == null && x.ApproveStatus == "P" && x.PeLogn == PeLogn && x.CuIden == CuIden).FirstOrDefault();
                            exResourceassignmentstatus.FinStatus = "A";
                            exResourceassignmentstatus.ApproveStatus = "A";
                            exResourceassignmentstatus.BillStart = Reason == "BNA" ? model.billstartdate : null;
                            _repositorycontext.ExResourceassignmentstatuses.Update(exResourceassignmentstatus);
                            //_repositorycontext.SaveChanges();
                        }


                        var finddata1 = (from p in _repositorycontext.ExResourceassignmentstatuses
                                         where p.CuIden.ToString() == "85" && p.PeLogn == PeLogn && p.Enddate == null
                                         select new
                                         {
                                             CuIden = p.CuIden,
                                             Startdate = p.Startdate
                                         }).Distinct().ToList();
                        DateTime StartDate = DateTime.Now;
                        if (finddata1.Count > 0)
                        {
                            StartDate = Convert.ToDateTime(finddata1[0].Startdate);
                            if (StartDate > KickoffDate.AddDays(-1))
                            {
                                ExResourceassignmentstatus exResourceassignmentstatus1 = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.PeLogn == PeLogn
              && x.Status == "B" && x.CuIden == 85 && x.Enddate == null).FirstOrDefault();
                                exResourceassignmentstatus1.Enddate = StartDate;
                                exResourceassignmentstatus1.DateOfMove = StartDate;
                                _repositorycontext.ExResourceassignmentstatuses.Update(exResourceassignmentstatus1);

                            }
                            else
                            {
                                ExResourceassignmentstatus exResourceassignmentstatus1 = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.PeLogn == PeLogn
            && x.Status == "B" && x.CuIden == 85 && x.Enddate == null).FirstOrDefault();
                                exResourceassignmentstatus1.Enddate = KickoffDate.AddDays(-1);
                                exResourceassignmentstatus1.DateOfMove = KickoffDate.AddDays(-1);
                                _repositorycontext.ExResourceassignmentstatuses.Update(exResourceassignmentstatus1);

                            }
                        }


                        var finddata2 = (from p in _edmdbcontext.ExReportingmanagers
                                         where p.CuIden.ToString() == "85" && p.Valognid == PeLogn && p.Enddate == null && p.Type == 1
                                         select new
                                         {
                                             CuIden = p.CuIden,
                                             Startdate = p.Startdt
                                         }).Distinct().ToList();
                        DateTime StartDate1 = DateTime.Now;
                        if (finddata2.Count > 0)
                        {
                            StartDate1 = Convert.ToDateTime(finddata2[0].Startdate);
                            if (StartDate1 > KickoffDate.AddDays(-1))
                            {
                                ExReportingmanager exreportingmanager = _edmdbcontext.ExReportingmanagers.Where(x => x.Valognid == PeLogn
                            && x.Enddate == null && x.CuIden == 85 && x.Type == 1).FirstOrDefault();
                                exreportingmanager.Enddate = Convert.ToDateTime(StartDate1);
                                exreportingmanager.Status = "D";
                                exreportingmanager.EnddateStamp = DateTime.Now;
                                exreportingmanager.EnddateUserlognid = model.FinanceLoginID;
                                _edmdbcontext.ExReportingmanagers.Update(exreportingmanager);

                            }
                            else
                            {
                                ExReportingmanager exreportingmanager = _edmdbcontext.ExReportingmanagers.Where(x => x.Valognid == PeLogn
                    && x.Enddate == null && x.CuIden == 85 && x.Type == 1).FirstOrDefault();
                                exreportingmanager.Enddate = KickoffDate.AddDays(-1);
                                exreportingmanager.Status = "D";
                                exreportingmanager.EnddateStamp = DateTime.Now;
                                exreportingmanager.EnddateUserlognid = model.FinanceLoginID;
                                _edmdbcontext.ExReportingmanagers.Update(exreportingmanager);
                                //_repositorycontext.SaveChanges(); 
                            }
                        }



                        ExResourceallocation statusobj = new ExResourceallocation();
                        statusobj.Sl = Sl;
                        statusobj.CuIden = CuIden;
                        statusobj.PeLogn = PeLogn;
                        statusobj.ProjId = 0;
                        statusobj.KickOff = KickoffDate;
                        statusobj.DateOfMove = null;
                        statusobj.AllocStartdt = KickoffDate;
                        statusobj.AllocEnddate = null;
                        statusobj.Allocation = Allocation;
                        statusobj.Userlognid = model.FinanceLoginID;
                        statusobj.Entrystamp = DateTime.Now;
                        statusobj.Status = "A";
                        _repositorycontext.ExResourceallocations.Add(statusobj);
                        //_repositorycontext.SaveChanges();

                        ExIpcustomerGroup rolemodel = new ExIpcustomerGroup();
                        rolemodel.Sl = Sl;
                        rolemodel.CuIden = CuIden;
                        rolemodel.ProjId = 0;
                        rolemodel.PeLogn = PeLogn;
                        rolemodel.Group = Groups;
                        rolemodel.KickOff = KickoffDate;
                        rolemodel.DateOfMove = null;
                        rolemodel.GroupStartdt = KickoffDate;
                        rolemodel.GroupEnddate = null;
                        rolemodel.Userlognid = model.FinanceLoginID;
                        rolemodel.Entrystamp = DateTime.Now;
                        rolemodel.Status = "A";
                        rolemodel.EnddateStamp = null;
                        rolemodel.EnddateUserlognid = null;
                        _repositorycontext.ExIpcustomerGroups.Add(rolemodel);
                        //_repositorycontext.SaveChanges();

                        ExReportingmanager exreportingmanager1 = new ExReportingmanager();
                        exreportingmanager1.CuIden = CuIden;
                        exreportingmanager1.ProjId = 0;
                        exreportingmanager1.Group = Groups;
                        exreportingmanager1.Valognid = PeLogn;
                        exreportingmanager1.Mngrlognid = PeLmgr;
                        exreportingmanager1.KickOff = KickoffDate;
                        exreportingmanager1.Startdt = KickoffDate;
                        exreportingmanager1.EnddateStamp = DateTime.Now;
                        exreportingmanager1.Status = "A";
                        exreportingmanager1.Type = 1;
                        exreportingmanager1.Userlognid = model.FinanceLoginID;
                        _edmdbcontext.ExReportingmanagers.Update(exreportingmanager1);

                        ExIpcustomerRole statusobj1 = new ExIpcustomerRole();
                        statusobj1.Sl = Sl;
                        statusobj1.CuIden = CuIden;
                        statusobj1.ProjId = 0;
                        statusobj1.PeLogn = PeLogn;
                        statusobj1.Role = AssignType;
                        statusobj1.KickOff = KickoffDate;
                        statusobj1.DateOfMove = null;
                        statusobj1.RoleStartdt = KickoffDate;
                        statusobj1.RoleEnddate = null;
                        statusobj1.Status = "A";
                        statusobj1.Userlognid = model.FinanceLoginID;
                        statusobj1.Entrystamp = DateTime.Now;
                        _repositorycontext.ExIpcustomerRoles.Add(statusobj1);
                        //_repositorycontext.SaveChanges();

                        ExIpcustomerTeam statusobj2 = new ExIpcustomerTeam();
                        statusobj2.Sl = Sl;
                        statusobj2.CuIden = CuIden;
                        statusobj2.ProjId = 0;
                        statusobj2.PeLogn = PeLogn;
                        statusobj2.KickOff = KickoffDate;
                        statusobj2.DateOfMove = null;
                        statusobj2.Status = "A";
                        statusobj2.Userlognid = model.FinanceLoginID;
                        statusobj2.Entrystamp = DateTime.Now;
                        _repositorycontext.ExIpcustomerTeams.Add(statusobj2);
                        //_repositorycontext.SaveChanges();

                        ExIpcustomerGeo statusobj3 = new ExIpcustomerGeo();
                        statusobj3.Sl = Sl;
                        statusobj3.CuIden = CuIden;
                        statusobj3.ProjId = 0;
                        statusobj3.PeLogn = PeLogn;
                        statusobj3.Group = Groups;
                        statusobj3.Geo = "27";
                        statusobj3.KickOff = KickoffDate;
                        statusobj3.GeoStartdt = KickoffDate;
                        statusobj3.DateOfMove = null;
                        statusobj3.Status = "A";
                        statusobj3.Userlognid = model.FinanceLoginID;
                        statusobj3.Entrystamp = DateTime.Now;
                        _repositorycontext.ExIpcustomerGeos.Add(statusobj3);
                        //_repositorycontext.SaveChanges();

                        ExIpcustomerReason rolemodel1 = new ExIpcustomerReason();
                        rolemodel1.Sl = Sl;
                        rolemodel1.CuIden = CuIden;
                        rolemodel1.ProjId = 0;
                        rolemodel1.PeLogn = PeLogn;
                        rolemodel1.Reason = Reason;
                        rolemodel1.KickOff = KickoffDate;
                        rolemodel1.EffectiveFrom = KickoffDate;
                        rolemodel1.EffectiveTo = null;
                        rolemodel1.Replacewith = null;
                        rolemodel1.Userlognid = model.FinanceLoginID;
                        rolemodel1.Entrystamp = DateTime.Now;
                        rolemodel1.Status = "A";
                        rolemodel1.EnddateStamp = null;
                        rolemodel1.EnddateUserlognid = null;
                        _repositorycontext.ExIpcustomerReasons.Add(rolemodel1);
                        //_repositorycontext.SaveChanges();

                        ExIpcustomerBilling exIpcustomerBilling = new ExIpcustomerBilling();
                        exIpcustomerBilling.Sl = Sl;
                        exIpcustomerBilling.CuIden = CuIden;
                        exIpcustomerBilling.ProjId = 0;
                        exIpcustomerBilling.PeLogn = PeLogn;
                        exIpcustomerBilling.Group = Groups;
                        exIpcustomerBilling.Jobrefno = null;
                        exIpcustomerBilling.BillingRole = AssignType;
                        exIpcustomerBilling.KickOff = KickoffDate;
                        exIpcustomerBilling.BillStartdt = KickoffDate;
                        exIpcustomerBilling.Status = "A";
                        exIpcustomerBilling.Entrystamp = DateTime.Now;
                        exIpcustomerBilling.Userlognid = model.FinanceLoginID;
                        _repositorycontext.ExIpcustomerBillings.Add(exIpcustomerBilling);
                        //_repositorycontext.SaveChanges();

                        ExIpcustomerSow exIpcustomerSow1 = new ExIpcustomerSow();
                        exIpcustomerSow1.Sl = Sl;
                        exIpcustomerSow1.CuIden = CuIden;
                        exIpcustomerSow1.ProjId = 0;
                        exIpcustomerSow1.PeLogn = PeLogn;
                        exIpcustomerSow1.KickOff = KickoffDate;
                        exIpcustomerSow1.Sow = model.SOWNo;
                        exIpcustomerSow1.SowStartdt = KickoffDate;
                        exIpcustomerSow1.Status = "A";
                        exIpcustomerSow1.Entrystamp = DateTime.Now;
                        exIpcustomerSow1.Userlognid = model.FinanceLoginID;
                        _repositorycontext.ExIpcustomerSows.Add(exIpcustomerSow1);
                        //_repositorycontext.SaveChanges();

                        if (Reason == "BNA" || Reason == "NBST5")
                        {
                            ExResourcebillpercent exresourcebillpercentnew = new ExResourcebillpercent();
                            exresourcebillpercentnew.Sl = Sl;
                            exresourcebillpercentnew.PeLogn = PeLogn;
                            exresourcebillpercentnew.CuIden = CuIden;
                            exresourcebillpercentnew.ProjId = 0;
                            exresourcebillpercentnew.KickOff = KickoffDate;
                            exresourcebillpercentnew.DateOfMove = null;
                            exresourcebillpercentnew.BillpercentStartdt = model.billstartdate;
                            exresourcebillpercentnew.BillpercentEnddt = null;
                            exresourcebillpercentnew.Billpercent = BillPercent;
                            exresourcebillpercentnew.Entrystamp = DateTime.Now;
                            exresourcebillpercentnew.Userlognid = model.FinanceLoginID;
                            exresourcebillpercentnew.EnddateStamp = null;
                            exresourcebillpercentnew.EnddateUserlognid = null;
                            exresourcebillpercentnew.Status = "A";
                            exresourcebillpercentnew.FinStatus = "A";
                            _repositorycontext.ExResourcebillpercents.Add(exresourcebillpercentnew);
                            //_repositorycontext.SaveChanges();
                        }

                        _edmdbcontext.SaveChanges();
                        _repositorycontext.SaveChanges();


                        if (model.FinanceAction == "A")
                        {
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
                                             where p.PeLogn == model.FinanceLoginID
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
                                                     where p.PeLogn == model.FinanceLoginID
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
                                                   PeMail = p.ParameterValue

                                               }).Take(1).ToList();

                            if (reasonList.Contains(Reason))
                            {
                                var findfinanceid = (from p in _repositorycontext.ExGeneralParameterConfigurations
                                                     where p.ParameterName == "Finance Notification ID"
                                                     select new
                                                     {
                                                         PeMail = p.ParameterValue

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
                                          where p.CuIden == CuIden && p.Enddate == null && p.Role == "DM" && b.PeDept==empdepratment
                                          select new
                                          {
                                              PeMail = b.PeMail

                                          }).Distinct().ToList();

                            var personemailid = (from p in _edmdbcontext.IpPeople
                                                 where p.PeLogn == model.FinanceLoginID
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

                            var cclistfinal = findPMO.Union(findemgr).Union(finddm).Union(tolistfinal).Union(ITGroupID).Union(AdminGroupID).ToList();

                            if (findplowner.Count > 0)
                            {
                                cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(tolistfinal).Union(ITGroupID).Union(AdminGroupID).ToList();
                            }



                            //var cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(personemailid).ToList();
                            //var cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(tolistfinal).Union(ITGroupID).Union(AdminGroupID).ToList();

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
                                    tttttt = tttttt + tolistfinal[i].PeMail;
                                }
                            }

                            //cc = plowner +";" + pmomail + ";" + emgrmail + ";" + dmmail + ";" + personselfmailid;

                            string subject = string.Empty;
                            if (reasonList.Contains(Reason))
                            {
                                subject = "Onboard Approved By - Finance ( " + empname + " to " + clientcode + "(Reason: " + reasondesc + ")";
                            }
                            else
                            {
                                subject = "Onboard Approved By - Finance " + empname + " to " + clientcode + "(Reason: " + reasondesc + ")";
                            }

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

                            ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Reason</TD><TD >&nbsp;" + reasondesc + "</TD></TR>";


                            //if (model.Reason.ToUpper() == "NBST1")
                            //{
                            //    ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Replacing</TD><TD >&nbsp;" + empnamereplacewith + "</TD></TR>";
                            //}


                            ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Department</TD><TD >&nbsp;" + departfullname + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Comments</TD><TD >&nbsp;" + model.FinanceComments + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Request ID</TD><TD >&nbsp;" + (ReqId == -1 ? "NA" : ReqId) + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Kick off Date</TD><TD >&nbsp;" + KickoffDate.ToString("yyyy-MM-dd") + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Action By</TD><TD >&nbsp;" + empnamedonetransaction + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Action On</TD><TD >&nbsp;" + DateTime.Now + "</TD></TR>" +
             "<TR><TD BgColor='lavender'><B>Checklist For IT</TD><TD ></TD></TR>" +
              "<TR><TD BgColor='lavender'><B>Shared Folder Access</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 6 select a.Comments).FirstOrDefault() + "</TD></TR>" +
               "<TR><TD BgColor='lavender'><B>Email Group Access</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 7 select a.Comments).FirstOrDefault() + "</TD></TR>" +
                 "<TR><TD BgColor='lavender'><B>Checklist For Admin</TD><TD ></TD></TR>" +
              "<TR><TD BgColor='lavender'><B>Client Room Access Details</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 8 select a.Comments).FirstOrDefault() + "</TD></TR>" +
               "<TR><TD BgColor='lavender'><B>Workstation Details</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 9 select a.Comments).FirstOrDefault() + "</TD></TR>";

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

                            string[] tomail11 = new string[personemailid.Count];
                            if (cclistfinal.Count > 0)
                            {
                                for (int i = 0; i < personemailid.Count; i++)
                                {
                                    tomail11[i] = tolistfinal[i].PeMail;
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
                                string[] ccmail = { "rohit.sehgal@acuitykp.com" };
                                sendEmail.from = FromEmailAddress;
                                sendEmail.to = new List<string>(tomail11);
                                sendEmail.subject = subject;
                                sendEmail.body = msg;
                                sendEmail.isHTML = true;
                                sendEmail.cc = new List<string>(ccmail11);
                                sendEmail.bcc = new List<string>(bccmail);
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
                        }

                        kickmodel.nstatus = "Update Sucessfully";

                    }
                    else
                    {
                        if (model.FinanceAction == "A")
                        {
                            ExResourceassignment exResourceassignment = _repositorycontext.ExResourceassignments.Where(x => x.ApproveStatus == "P"
                   && x.Id == model.ID && x.FinanceStatus == "P").FirstOrDefault();
                            exResourceassignment.FinanceStatus = model.FinanceAction;
                            exResourceassignment.FinanceComments = model.FinanceComments;
                            exResourceassignment.FinanceEntrystamp = DateTime.Now;
                            exResourceassignment.FinanceLognid = model.FinanceLoginID;
                            exResourceassignment.Sow = model.SOWNo;
                            exResourceassignment.BillEntity = model.BillEntity;
                            exResourceassignment.BillDate = model.billstartdate;
                            exResourceassignment.Billpercent = BillPercent;
                            _repositorycontext.ExResourceassignments.Update(exResourceassignment);

                            _edmdbcontext.SaveChanges();
                            _repositorycontext.SaveChanges();

                            if (model.FinanceAction == "A")
                            {
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
                                                 where p.PeLogn == model.FinanceLoginID
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
                                                         where p.PeLogn == model.FinanceLoginID
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
                                                       PeMail = p.ParameterValue

                                                   }).Take(1).ToList();

                                if (reasonList.Contains(Reason))
                                {
                                    var findfinanceid = (from p in _repositorycontext.ExGeneralParameterConfigurations
                                                         where p.ParameterName == "Finance Notification ID"
                                                         select new
                                                         {
                                                             PeMail = p.ParameterValue

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
                                              where p.CuIden == CuIden && p.Enddate == null && p.Role == "DM" && b.PeDept==empdepratment
                                              select new
                                              {
                                                  PeMail = b.PeMail

                                              }).Distinct().ToList();

                                var personemailid = (from p in _edmdbcontext.IpPeople
                                                     where p.PeLogn == model.FinanceLoginID
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

                                var listA = new List<string> { "ankur.goel@acuitykp.com" };
                                var listB = new List<string> { "rohit.sehgal@acuitykp.com" };
                                var listFinal = listA.Union(listB);

                                //var cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(personemailid).ToList();

                                var cclistfinal = findPMO.Union(findemgr).Union(finddm).Union(tolistfinal).Union(ITGroupID).Union(AdminGroupID).ToList();

                                if (findplowner.Count > 0)
                                {
                                    cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(tolistfinal).Union(ITGroupID).Union(AdminGroupID).ToList();
                                }



                                //var cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(tolistfinal).Union(ITGroupID).Union(AdminGroupID).ToList();

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
                                        tttttt = tttttt + tolistfinal[i].PeMail;
                                    }
                                }

                                //cc = plowner +";" + pmomail + ";" + emgrmail + ";" + dmmail + ";" + personselfmailid;

                                string subject = string.Empty;
                                if (reasonList.Contains(Reason))
                                {
                                    subject = "Onboard Approved By - Finance ( " + empname + " to " + clientcode + "(Reason: " + reasondesc + ")";
                                }
                                else
                                {
                                    subject = "Onboard Approved By - Finance " + empname + " to " + clientcode + "(Reason: " + reasondesc + ")";
                                }

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

                                ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Reason</TD><TD >&nbsp;" + reasondesc + "</TD></TR>";


                                //if (model.Reason.ToUpper() == "NBST1")
                                //{
                                //    ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Replacing</TD><TD >&nbsp;" + empnamereplacewith + "</TD></TR>";
                                //}


                                ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Department</TD><TD >&nbsp;" + departfullname + "</TD></TR>" +
                "<TR><TD BgColor='lavender'><B>Comments</TD><TD >&nbsp;" + model.FinanceComments + "</TD></TR>" +
                "<TR><TD BgColor='lavender'><B>Request ID</TD><TD >&nbsp;" + (ReqId == -1 ? "NA" : ReqId) + "</TD></TR>" +
                "<TR><TD BgColor='lavender'><B>Kick off Date</TD><TD >&nbsp;" + KickoffDate.ToString("yyyy-MM-dd") + "</TD></TR>" +
                "<TR><TD BgColor='lavender'><B>Action By</TD><TD >&nbsp;" + empnamedonetransaction + "</TD></TR>" +
                "<TR><TD BgColor='lavender'><B>Action On</TD><TD >&nbsp;" + DateTime.Now + "</TD></TR>" +
                 "<TR><TD BgColor='lavender'><B>Checklist For IT</TD><TD ></TD></TR>" +
                  "<TR><TD BgColor='lavender'><B>Shared Folder Access</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 6 select a.Comments).FirstOrDefault() + "</TD></TR>" +
                   "<TR><TD BgColor='lavender'><B>Email Group Access</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 7 select a.Comments).FirstOrDefault() + "</TD></TR>" +
                     "<TR><TD BgColor='lavender'><B>Checklist For Admin</TD><TD ></TD></TR>" +
                  "<TR><TD BgColor='lavender'><B>Client Room Access Details</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 8 select a.Comments).FirstOrDefault() + "</TD></TR>" +
                   "<TR><TD BgColor='lavender'><B>Workstation Details</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 9 select a.Comments).FirstOrDefault() + "</TD></TR>";

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

                                string[] tomail11 = new string[personemailid.Count];
                                if (cclistfinal.Count > 0)
                                {
                                    for (int i = 0; i < personemailid.Count; i++)
                                    {
                                        tomail11[i] = tolistfinal[i].PeMail;
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
                                    string[] ccmail = { "rohit.sehgal@acuitykp.com" };
                                    sendEmail.from = FromEmailAddress;
                                    sendEmail.to = new List<string>(tomail11);
                                    sendEmail.subject = subject;
                                    sendEmail.body = msg;
                                    sendEmail.isHTML = true;
                                    sendEmail.cc = new List<string>(ccmail11);
                                    sendEmail.bcc = new List<string>(bccmail); 
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
                            }


                            kickmodel.nstatus = "Update Sucessfully";
                        }
                        else
                        {
                            ExResourceassignment exResourceassignment = _repositorycontext.ExResourceassignments.Where(x => x.ApproveStatus == "P"
                   && x.Id == model.ID && x.FinanceStatus == "P").FirstOrDefault();
                            exResourceassignment.FinanceStatus = model.FinanceAction;
                            exResourceassignment.FinanceComments = model.FinanceComments;
                            exResourceassignment.FinanceEntrystamp = DateTime.Now;
                            exResourceassignment.FinanceLognid = model.FinanceLoginID;
                            exResourceassignment.Sow = model.SOWNo;
                            exResourceassignment.BillEntity = model.BillEntity;
                            exResourceassignment.BillDate = model.billstartdate;
                            exResourceassignment.ApproveStatus = model.FinanceAction;

                            ExResourceassignmentstatus exResourceassignmentstatus1 = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.PeLogn == PeLogn
                      && x.KickOff == KickoffDate && x.CuIden == CuIden && x.ApproveStatus == "P").FirstOrDefault();
                            _repositorycontext.ExResourceassignmentstatuses.Remove(exResourceassignmentstatus1);

                            _edmdbcontext.SaveChanges();
                            _repositorycontext.SaveChanges();
                             
                            kickmodel.nstatus = "Update Sucessfully";
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

        [HttpGet("GetPendingOffBoardTransactions/{role}")]
        public IActionResult GetPendingOffBoardTransactions(string role)
        {
            Dictionary<string, object> dList = new Dictionary<string, object>();
            Response response = new();
            try
            {
                //string dept = core.getdepartment(pelogin);

                //string[] roleList = { "ADMIN", "EMGR", "CDH" };
                //var ExResourceassignmentstatuses = (from a in _repositorycontext.ExResourceassignmentstatuses select a).ToList();
                var ExResourceassignment = (from a in _repositorycontext.ExResourceassignments select a).ToList();
                var IPCustomerlist = (from a in _repositorycontext.IpCustomers select a).ToList();
                var ExStatusdescs = (from a in _repositorycontext.ExStatusdescs select a).ToList();

                var IpPersonList = (from a in _edmdbcontext.IpPeople where a.PeQuit == null select a).ToList();




                if (role == "FinanceTeam")
                {

                    var Financeonbaordpending = (from a in ExResourceassignment
                                                 join b in IpPersonList
                              on new
                              { User = a != null ? a.PeLogn : "" }
               equals new { User = b != null ? b.PeLogn : "" } into sc1
                                                 from b in sc1.DefaultIfEmpty()
                                                 join c in IPCustomerlist
                            on new
                            { CLientcode = a != null ? a.CuIden.ToString() : "" }
             equals new { CLientcode = c != null ? c.CuIden.ToString() : "" } into sc2
                                                 from c in sc2.DefaultIfEmpty()

                                                     //                                       join d in ExStatusdescs
                                                     //               on new
                                                     //               { Status = a != null ? a.Reason : "" }
                                                     //equals new { Status = d != null ? d.Level : "" } into sc3
                                                     //                                       from d in sc3.DefaultIfEmpty()

                                                 where a.OnOff == 1 && a.ApproveStatus == "P" && a.Userapprovestatus == "A" && a.FinanceStatus == "P"
                                                 //&& (a.Reason == "BNA" || a.Reason == "NBST5")
                                                 select new
                                                 {
                                                     ID = a.Id,
                                                     PeLogn = a.PeLogn,
                                                     CuIden = a.CuIden,
                                                     PeName = b.PeName,
                                                     CuComp = c.CuComp,
                                                     // StatusDesc = d.StatusDesc,
                                                     KickOffDate = a != null ? a.KickOffDate.Value.ToString("yyyy-MM-dd") : "",
                                                     Allocation = a.Allocation,
                                                     Billpercent = a.Billpercent,
                                                     BillDate = a != null ? a.BillDate.Value.ToString("yyyy-MM-dd") : "",
                                                     DateOfSelectionOrMove = a.DateOfSelectionOrMove.Value.ToString("yyyy-MM-dd"),
                                                     Reason = a.Reason

                                                 }).Distinct().ToList();

                    dList.Add("Table", Financeonbaordpending);
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

        [HttpPost("FinanceOffboardAction")]
        public IActionResult FinanceOffboardAction(FinanceOffBoardAction model)
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

                    var finddata = (from p in _repositorycontext.ExResourceassignments
                                    where p.Id == model.ID
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
                                        DateOfSelectionOrMove = p.DateOfSelectionOrMove

                                    }).ToList();

                    string ComplianceStatus = "";
                    string Reason = "";
                    string PeLogn = "";
                    string Groups = "";
                    string AssignType = "";
                    string PeLmgr = "";
                    int CuIden = 0;
                    DateTime BillDate = DateTime.Now;
                    DateTime KickoffDate = DateTime.Now;
                    DateTime DateOfSelectionOrMove = DateTime.Now;
                    decimal? BillPercent = 0;
                    decimal? Allocation = 0;
                    int Sl = 0;
                    if (finddata.Count > 0)
                    {
                        ComplianceStatus = finddata[0].ComplianceStatus;
                        Reason = finddata[0].Reason;
                        BillDate = Convert.ToDateTime(finddata[0].BillDate);
                        BillPercent = finddata[0].Billpercent;
                        Allocation = finddata[0].Allocation;
                        PeLmgr = finddata[0].PeLmgr;
                        KickoffDate = Convert.ToDateTime(finddata[0].KickOffDate);
                        DateOfSelectionOrMove = Convert.ToDateTime(finddata[0].DateOfSelectionOrMove);
                        PeLogn = finddata[0].PeLogn;
                        Groups = finddata[0].Groups;
                        AssignType = finddata[0].AssignType;
                        Sl = Convert.ToInt16(finddata[0].Sl);
                        CuIden = Convert.ToInt16(finddata[0].CuIden);
                    }


                    KickOffStatus kickmodel = new KickOffStatus();
                    ResultTemp resultModel = new ResultTemp();

                    if (model.FinanceAction == "R")
                    {
                        ExResourceassignment exResourceassignment = _repositorycontext.ExResourceassignments.Where(x => x.ApproveStatus == "P"
                     && x.Id == model.ID).FirstOrDefault();
                        exResourceassignment.ApproveStatus = model.FinanceAction;
                        exResourceassignment.FinanceStatus = model.FinanceAction;
                        exResourceassignment.FinanceComments = model.FinanceComments;
                        exResourceassignment.FinanceEntrystamp = DateTime.Now;
                        exResourceassignment.FinanceLognid = model.FinanceLoginID;
                        _repositorycontext.ExResourceassignments.Update(exResourceassignment);

                        ExResourceassignmentstatus exResourceassignmentstatus = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.PeLogn == PeLogn
                    && x.OffboardStatus == "P" && x.CuIden == CuIden && x.KickOff == KickoffDate).FirstOrDefault();
                        exResourceassignmentstatus.DateOfMove = null;
                        exResourceassignmentstatus.Enddate = null;
                        exResourceassignmentstatus.OffboardStatus = null;
                        exResourceassignmentstatus.OffboardUserlognid = null;
                        exResourceassignmentstatus.OffboardReason = null;
                        exResourceassignmentstatus.OffboardStamp = null;
                        _repositorycontext.ExResourceassignmentstatuses.Update(exResourceassignmentstatus);

                        _repositorycontext.SaveChanges();
                        kickmodel.nstatus = "Update Sucessfully";

                    }
                    else
                    {
                        ExResourceassignment exResourceassignment = _repositorycontext.ExResourceassignments.Where(x => x.ApproveStatus == "P"
                    && x.Id == model.ID).FirstOrDefault();
                        exResourceassignment.ApproveStatus = model.FinanceAction;
                        exResourceassignment.FinanceStatus = model.FinanceAction;
                        exResourceassignment.FinanceComments = model.FinanceComments;
                        exResourceassignment.FinanceEntrystamp = DateTime.Now;
                        exResourceassignment.FinanceLognid = model.FinanceLoginID;
                        _repositorycontext.ExResourceassignments.Update(exResourceassignment);

                        ExResourceassignmentstatus exResourceassignmentstatus = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.PeLogn == PeLogn
                    && x.OffboardStatus == "P" && x.CuIden == CuIden && x.KickOff == KickoffDate).FirstOrDefault();
                        exResourceassignmentstatus.Status = "D";
                        exResourceassignmentstatus.OffboardStatus = model.FinanceAction;
                        exResourceassignmentstatus.OffboardStamp = DateTime.Now;
                        exResourceassignmentstatus.BillEnd = model.billenddate;
                        exResourceassignmentstatus.Enddate = DateOfSelectionOrMove;
                        exResourceassignmentstatus.DateOfMove = DateOfSelectionOrMove;
                        _repositorycontext.ExResourceassignmentstatuses.Update(exResourceassignmentstatus);


                        ExResourceallocation exResourceallocation = _repositorycontext.ExResourceallocations.Where(x => x.PeLogn == PeLogn
                  && x.AllocEnddate == null && x.CuIden == CuIden && x.KickOff == KickoffDate).FirstOrDefault();
                        exResourceallocation.Status = "D";
                        exResourceallocation.DateOfMove = DateOfSelectionOrMove;
                        exResourceallocation.AllocEnddate = DateOfSelectionOrMove;
                        exResourceallocation.EnddateStamp = DateTime.Now;
                        exResourceallocation.EnddateUserlognid = model.FinanceLoginID;
                        _repositorycontext.ExResourceallocations.Update(exResourceallocation);

                        ExResourcebillpercent exResourcebillpercent = _repositorycontext.ExResourcebillpercents.Where(x => x.PeLogn == PeLogn
                 && x.BillpercentEnddt == null && x.CuIden == CuIden && x.KickOff == KickoffDate).FirstOrDefault();
                        exResourcebillpercent.Status = "D";
                        exResourcebillpercent.BillpercentEnddt = model.billenddate;
                        exResourcebillpercent.DateOfMove = DateOfSelectionOrMove;
                        exResourcebillpercent.EnddateStamp = DateTime.Now;
                        exResourcebillpercent.EnddateUserlognid = model.FinanceLoginID;
                        _repositorycontext.ExResourcebillpercents.Update(exResourcebillpercent);

                        ExIpcustomerTeam exIpcustomerTeam = _repositorycontext.ExIpcustomerTeams.Where(x => x.PeLogn == PeLogn
               && x.DateOfMove == null && x.CuIden == CuIden && x.KickOff == KickoffDate).FirstOrDefault();
                        exIpcustomerTeam.Status = "D";
                        exIpcustomerTeam.DateOfMove = DateOfSelectionOrMove;
                        exIpcustomerTeam.EnddateEntrystamp = DateTime.Now;
                        exIpcustomerTeam.EnddateUserlognid = model.FinanceLoginID;
                        _repositorycontext.ExIpcustomerTeams.Update(exIpcustomerTeam);

                        ExIpcustomerGroup exIpcustomerGroup = _repositorycontext.ExIpcustomerGroups.Where(x => x.PeLogn == PeLogn
               && x.DateOfMove == null && x.CuIden == CuIden && x.KickOff == KickoffDate).FirstOrDefault();
                        exIpcustomerGroup.Status = "D";
                        exIpcustomerGroup.DateOfMove = DateOfSelectionOrMove;
                        exIpcustomerGroup.EnddateStamp = DateTime.Now;
                        exIpcustomerGroup.EnddateUserlognid = model.FinanceLoginID;
                        exIpcustomerGroup.GroupEnddate = DateOfSelectionOrMove;
                        _repositorycontext.ExIpcustomerGroups.Update(exIpcustomerGroup);

                        ExIpcustomerRole exIpcustomerRole = _repositorycontext.ExIpcustomerRoles.Where(x => x.PeLogn == PeLogn
               && x.RoleEnddate == null && x.CuIden == CuIden && x.KickOff == KickoffDate).FirstOrDefault();
                        exIpcustomerRole.Status = "D";
                        exIpcustomerRole.DateOfMove = DateOfSelectionOrMove;
                        exIpcustomerRole.EnddateStamp = DateTime.Now;
                        exIpcustomerRole.EnddateUserlognid = model.FinanceLoginID;
                        exIpcustomerRole.RoleEnddate = DateOfSelectionOrMove;
                        _repositorycontext.ExIpcustomerRoles.Update(exIpcustomerRole);

                        ExIpcustomerGeo exIpcustomerGeo = _repositorycontext.ExIpcustomerGeos.Where(x => x.PeLogn == PeLogn
              && x.GeoEnddate == null && x.CuIden == CuIden && x.KickOff == KickoffDate).FirstOrDefault();
                        exIpcustomerGeo.Status = "D";
                        exIpcustomerGeo.DateOfMove = DateOfSelectionOrMove;
                        exIpcustomerGeo.GeoEnddate = DateOfSelectionOrMove;
                        _repositorycontext.ExIpcustomerGeos.Update(exIpcustomerGeo);

                        ExIpcustomerReason exIpcustomerReason = _repositorycontext.ExIpcustomerReasons.Where(x => x.PeLogn == PeLogn
         && x.DateOfMove == null && x.EffectiveTo == null && x.CuIden == CuIden && x.KickOff == KickoffDate).FirstOrDefault();
                        exIpcustomerReason.Status = "D";
                        exIpcustomerReason.DateOfMove = DateOfSelectionOrMove;
                        exIpcustomerReason.EffectiveTo = DateOfSelectionOrMove;
                        exIpcustomerReason.EnddateStamp = DateTime.Now;
                        exIpcustomerReason.EnddateUserlognid = model.FinanceLoginID;
                        _repositorycontext.ExIpcustomerReasons.Update(exIpcustomerReason);

                        ExIpcustomerSow exIpcustomerSow = _repositorycontext.ExIpcustomerSows.Where(x => x.PeLogn == PeLogn
       && x.DateOfMove == null && x.SowEnddate == null && x.CuIden == CuIden && x.KickOff == KickoffDate).FirstOrDefault();
                        exIpcustomerSow.Status = "D";
                        exIpcustomerSow.DateOfMove = DateOfSelectionOrMove;
                        exIpcustomerSow.SowEnddate = DateOfSelectionOrMove;
                        exIpcustomerSow.EnddateStamp = DateTime.Now;
                        exIpcustomerSow.EnddateUserlognid = model.FinanceLoginID;
                        _repositorycontext.ExIpcustomerSows.Update(exIpcustomerSow);

                        //                  ExIpcustomerBilling exIpcustomerBilling = _repositorycontext.ExIpcustomerBillings.Where(x => x.PeLogn == PeLogn
                        //&& x.DateOfMove == null && x.BillEnddate == null && x.CuIden == CuIden && x.KickOff == KickoffDate).FirstOrDefault();
                        //                  exIpcustomerBilling.Status = "D";
                        //                  exIpcustomerBilling.DateOfMove = DateOfSelectionOrMove;
                        //                  exIpcustomerBilling.BillEnddate = model.billenddate; 
                        //                  _repositorycontext.ExIpcustomerBillings.Update(exIpcustomerBilling);


                        var findexistingrecodreportingmanager = (from p in _edmdbcontext.ExReportingmanagers
                                                                 where p.Valognid == PeLogn && p.Status.ToUpper() == "A" && p.Enddate == null && p.CuIden == CuIden && p.Type == 1
                                                                 select new
                                                                 {
                                                                     Valognid = p.Valognid
                                                                 }).ToList();

                        if (findexistingrecodreportingmanager.Count > 0)
                        {

                            ExReportingmanager exreportingmanager = _edmdbcontext.ExReportingmanagers.Where(x => x.Valognid == PeLogn
                            && x.Enddate == null && x.CuIden == CuIden && x.Type == 1).FirstOrDefault();
                            exreportingmanager.DateOfMove = DateOfSelectionOrMove;
                            exreportingmanager.Enddate = DateOfSelectionOrMove;
                            exreportingmanager.Status = "D";
                            exreportingmanager.EnddateStamp = DateTime.Now;
                            exreportingmanager.EnddateUserlognid = model.FinanceLoginID;
                            _edmdbcontext.ExReportingmanagers.Update(exreportingmanager);
                        }

                        var findoffboardreason = (from p in _repositorycontext.ExResourceassignmentstatuses
                                                  where p.PeLogn == PeLogn && p.CuIden==CuIden && p.OffboardStatus.ToUpper()=="P"
                                        select new
                                        {
                                            OffboardReason = p.OffboardReason 
                                        }).ToList();

                        string OffboardReason = "";
                       
                        if (findoffboardreason.Count > 0)
                        {
                            OffboardReason = findoffboardreason[0].OffboardReason;
                        }

                        int noofactiveaccount = 0;
                        noofactiveaccount = (from a in _repositorycontext.ExResourceassignmentstatuses
                                             where a.PeLogn == PeLogn && a.CuIden != Convert.ToInt16(CuIden) && a.Enddate == null
                                             select a.CuIden).Count();

                        if (noofactiveaccount == 0)
                        {
                            //Add Bench Record
                            ExResourceassignmentstatus statusobj = new ExResourceassignmentstatus();
                            statusobj.Sl = null;
                            statusobj.PeLogn = PeLogn;
                            statusobj.CuIden = 85;
                            statusobj.ProjId = 0;
                            statusobj.Group = null;
                            statusobj.Role = null;
                            statusobj.KickOff = Convert.ToDateTime(DateOfSelectionOrMove).AddDays(1);
                            statusobj.DateOfMove = null;
                            statusobj.Startdate = Convert.ToDateTime(DateOfSelectionOrMove).AddDays(1);
                            statusobj.Enddate = null;//hard coded from below line
                            statusobj.Status = OffboardReason.ToUpper() == "LONG LEAVE" ? "L" : "B";
                            statusobj.StatusLevelId = null;
                            statusobj.Entrystamp = DateTime.Now;
                            statusobj.Userlognid = model.FinanceLoginID;
                            statusobj.ApproveStatus = "A";
                            statusobj.OffboardStatus = null;
                            statusobj.OffboardStamp = null;
                            statusobj.OffboardUserlognid = null;
                            statusobj.Reason = null;
                            statusobj.FinStatus = null;
                            statusobj.Tranid = null;
                            _repositorycontext.ExResourceassignmentstatuses.Add(statusobj);

                        }

                        _repositorycontext.SaveChanges();
                        _edmdbcontext.SaveChanges();
                        kickmodel.nstatus = "Update Sucessfully";


                        if (model.FinanceAction == "A")
                        {
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
                                             where p.PeLogn == model.FinanceLoginID
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
                                                     where p.PeLogn == model.FinanceLoginID
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
                                               where p.ParameterName == "Finance Notification ID"
                                               select new
                                               {
                                                   PeMail = p.ParameterValue

                                               }).ToList();

                            //if (reasonList.Contains(Reason))
                            //{
                            //    var findfinanceid = (from p in _repositorycontext.ExGeneralParameterConfigurations
                            //                         where p.ParameterName == "Finance Notification ID"
                            //                         select new
                            //                         {
                            //                             PeMail = p.ParameterValue

                            //                         }).ToList();
                            //    var tempfinal = tolistfinal.Union(findfinanceid);

                            //    tolistfinal = tempfinal.ToList();
                            //}

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
                                          where p.CuIden == CuIden && p.Enddate == null && p.Role == "DM" && b.PeDept==empdepratment
                                          select new
                                          {
                                              PeMail = b.PeMail

                                          }).Distinct().ToList();

                            var personemailid = (from p in _edmdbcontext.IpPeople
                                                 where p.PeLogn == model.FinanceLoginID
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

                            //var cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(personemailid).ToList();

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

                            var cclistfinal = findPMO.Union(findemgr).Union(finddm).Union(tolistfinal).Union(ITGroupID).Union(AdminGroupID).ToList();

                            if (findplowner.Count > 0)
                            {
                                cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(tolistfinal).Union(ITGroupID).Union(AdminGroupID).ToList();
                            }



                            //var cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(tolistfinal).ToList();

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
                                    tttttt = tttttt + tolistfinal[i].PeMail;
                                }
                            }

                            //cc = plowner +";" + pmomail + ";" + emgrmail + ";" + dmmail + ";" + personselfmailid;

                            string subject = string.Empty;

                            subject = "OffBoarding Approved By - Finance ( " + empname + " to " + clientcode + "(Reason: " + reasondesc + ")";

                            //if (reasonList.Contains(Reason))
                            //{
                            //    subject = "Onboard Approved By - Finance ( " + empname + " to " + clientcode + "(Reason: " + reasondesc + ")";
                            //}
                            //else
                            //{
                            //    subject = "Onboard Approved By - Finance " + empname + " to " + clientcode + "(Reason: " + reasondesc + ")";
                            //}

                            decimal? billingsum = 0;
                            var Billing = (from p in _repositorycontext.ExResourcebillpercents
                                           where p.PeLogn == PeLogn && p.CuIden == Convert.ToInt16(CuIden) && p.BillpercentEnddt == null
                                           select new
                                           {
                                               p.Billpercent

                                           }).ToList();

                            if (Billing.Count > 0)
                            {
                                billingsum = Billing[0].Billpercent;
                                //billingsum = Billing.Sum(t => t.Billpercent);
                            }

                            string ABCD = "<table  border='1'><tr><td>" +
            "<Table BgColor='lavender' border='1' bordercolor ='lightblue' style='font-size:12px;font-family:Arial'>" +
            "<TR><TD BgColor='lavender'><B>Client Code</TD><TD >&nbsp;" + clientcode + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Emp Name</TD><TD >&nbsp;" + empname + "</TD></TR>";
                            // "<TR><TD BgColor='lavender'><B>Project Assignment Role</TD><TD >&nbsp;" + assignrole + "</TD></TR>" +
                            //"<TR><TD BgColor='lavender'><B>Allocation Percentage</TD><TD >&nbsp;" + model.Allocation + "</TD></TR>";
                            //if (reasonList.Contains(Reason))
                            //{
                            //    ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Billing Percentage</TD><TD >&nbsp;" + BillPercent + "</TD></TR>";
                            //}



                            //ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Billing Percentage</TD><TD >&nbsp;" + BillPercent + "</TD></TR>";
                            ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Billing Percentage</TD><TD >&nbsp;" + billingsum + "</TD></TR>";

                            ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Reason</TD><TD >&nbsp;" + reasondesc + "</TD></TR>";


                            //if (model.Reason.ToUpper() == "NBST1")
                            //{
                            //    ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Replacing</TD><TD >&nbsp;" + empnamereplacewith + "</TD></TR>";
                            //}


                            ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Department</TD><TD >&nbsp;" + departfullname + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Comments</TD><TD >&nbsp;" + model.FinanceComments + "</TD></TR>" +
            //"<TR><TD BgColor='lavender'><B>Request ID</TD><TD >&nbsp;" + (ReqId == -1 ? "NA" : ReqId) + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Kick off Date</TD><TD >&nbsp;" + KickoffDate.ToString("yyyy-MM-dd") + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Date of Move</TD><TD >&nbsp;" +DateOfSelectionOrMove.ToString("yyyy-MM-dd") + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Action By</TD><TD >&nbsp;" + empnamedonetransaction + "</TD></TR>" +
            "<TR><TD BgColor='lavender'><B>Action On</TD><TD >&nbsp;" + DateTime.Now + "</TD></TR>" +
             "<TR><TD BgColor='lavender'><B>Checklist For IT</TD><TD ></TD></TR>" +
              "<TR><TD BgColor='lavender'><B>Shared Folder Access</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 6 select a.Comments).FirstOrDefault() + "</TD></TR>" +
               "<TR><TD BgColor='lavender'><B>Email Group Access</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 7 select a.Comments).FirstOrDefault() + "</TD></TR>" +
                 "<TR><TD BgColor='lavender'><B>Checklist For Admin</TD><TD ></TD></TR>" +
              "<TR><TD BgColor='lavender'><B>Client Room Access Details</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 8 select a.Comments).FirstOrDefault() + "</TD></TR>" +
               "<TR><TD BgColor='lavender'><B>Workstation Details</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 9 select a.Comments).FirstOrDefault() + "</TD></TR>";

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

                            string[] tomail11 = new string[personemailid.Count];
                            if (cclistfinal.Count > 0)
                            {
                                for (int i = 0; i < personemailid.Count; i++)
                                {
                                    tomail11[i] = tolistfinal[i].PeMail;
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
                                string[] ccmail = { "rohit.sehgal@acuitykp.com" };
                                sendEmail.from = FromEmailAddress;
                                sendEmail.to = new List<string>(tomail11);
                                sendEmail.subject = subject;
                                sendEmail.body = msg;
                                sendEmail.isHTML = true;
                                sendEmail.cc = new List<string>(ccmail11);
                                sendEmail.bcc = new List<string>(bccmail);
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

        [HttpGet("GetPendingBillingConversionTransaction/{role}")]
        public IActionResult GetPendingBillingConversionTransaction(string role)
        {
            Dictionary<string, object> dList = new Dictionary<string, object>();
            Response response = new();
            try
            {
                //string dept = core.getdepartment(pelogin);

                //string[] roleList = { "ADMIN", "EMGR", "CDH" };
                //var ExResourceassignmentstatuses = (from a in _repositorycontext.ExResourceassignmentstatuses select a).ToList();
                //var ExResourceassignment = (from a in _repositorycontext.ExResourceassignments select a).ToList();
                var ExIpcustomerConversions = (from a in _repositorycontext.ExIpcustomerConversions where a.FinStatus.ToUpper() == "P" select a).ToList();
                var IPCustomerlist = (from a in _repositorycontext.IpCustomers select a).ToList();
                var ExStatusdescs = (from a in _repositorycontext.ExStatusdescs select a).ToList();

                var IpPersonList = (from a in _edmdbcontext.IpPeople where a.PeQuit == null select a).ToList();
                var IpCategories = (from a in _edmdbcontext.IpCategories select a).ToList();




                if (role == "FinanceTeam")
                {

                    var BillingConversionpending = (from a in ExIpcustomerConversions
                                                    join b in IpPersonList
                                 on new
                                 { User = a != null ? a.PeLogn : "" }
                  equals new { User = b != null ? b.PeLogn : "" } into sc1
                                                    from b in sc1.DefaultIfEmpty()
                                                    join c in IPCustomerlist
                               on new
                               { CLientcode = a != null ? a.CuIden.ToString() : "" }
                equals new { CLientcode = c != null ? c.CuIden.ToString() : "" } into sc2
                                                    from c in sc2.DefaultIfEmpty()

                                                    join d in ExStatusdescs
                            on new
                            { Status = a != null ? a.CurrentReason : "" }
             equals new { Status = d != null ? d.Level : "" } into sc3
                                                    from d in sc3.DefaultIfEmpty()

                                                    join e in ExStatusdescs
                          on new
                          { Status = a != null ? a.Reason : "" }
           equals new { Status = e != null ? e.Level : "" } into sc4
                                                    from e in sc4.DefaultIfEmpty()

                                                    join f in IpCategories
                       on new
                       { Status = a != null ? a.Role : "" }
        equals new { Status = f != null ? f.CaCode : "" } into sc5
                                                    from f in sc5.DefaultIfEmpty()

                                                    join g in IpPersonList
                           on new
                           { User = a != null ? a.RepLogn : "" }
            equals new { User = g != null ? g.PeLogn : "" } into sc6
                                                    from g in sc6.DefaultIfEmpty()

                                                    where a.FinStatus.ToUpper() == "P"
                                                    select new
                                                    {
                                                        currentreason = d != null ? d.StatusDesc : a.CurrentReason,
                                                        newreason = e != null ? e.StatusDesc : "",
                                                        PeLogn = a.PeLogn,
                                                        CuIden = a.CuIden,
                                                        CuComp = c.CuComp,
                                                        PeName = b.PeName,
                                                        Role = f.CaName,
                                                        KickOffDate = a != null ? a.KickOff.ToString("yyyy-MM-dd") : "",
                                                        ReplaceWith = g != null ? g.PeName : "NA",
                                                        BillStart = a.BillStart != null ? a.BillStart.Value.ToString("yyyy-MM-dd") : "",
                                                        BillEnd = a.BillEnd != null ? a.BillEnd.Value.ToString("yyyy-MM-dd") : "",
                                                        Startdate = a.Startdate != null ? a.Startdate.Value.ToString("yyyy-MM-dd") : "",
                                                        Group = a.Group != null ? a.Group : "",
                                                        RepLogn = a.RepLogn != null ? a.RepLogn : "",
                                                        CurrentReasoncode = a.CurrentReason,
                                                        NewReasoncode = a.Reason
                                                    }).Distinct().ToList();

                    dList.Add("Table", BillingConversionpending);
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

        [HttpPost("FinanceBillingCOnversionAction")]
        public IActionResult FinanceBillingCOnversionAction(FinanceBillingConversionAction model)
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

                    if (model.FinanceAction == "R")
                    {
                        ExIpcustomerConversion exIpcustomerConversion = _repositorycontext.ExIpcustomerConversions.Where(x => x.PeLogn == model.pelogn
                       && x.CuIden == model.cuiden && x.FinStatus == "P" && x.KickOff == model.kickofdate).FirstOrDefault();
                        exIpcustomerConversion.FinComments = model.FinanceComments;
                        exIpcustomerConversion.FinStatus = model.FinanceAction;
                        exIpcustomerConversion.FinEntrystamp = DateTime.Now;
                        exIpcustomerConversion.FinUsrlogn = model.FinanceLoginID;
                        _repositorycontext.ExIpcustomerConversions.Update(exIpcustomerConversion);

                        _repositorycontext.SaveChanges();
                        kickmodel.nstatus = "Update Sucessfully";

                    }
                    else
                    {
                        ExIpcustomerConversion exIpcustomerConversion = _repositorycontext.ExIpcustomerConversions.Where(x => x.PeLogn == model.pelogn
                       && x.CuIden == model.cuiden && x.FinStatus == "P" && x.KickOff == model.kickofdate).FirstOrDefault();
                        exIpcustomerConversion.FinComments = model.FinanceComments;
                        exIpcustomerConversion.FinStatus = model.FinanceAction;
                        exIpcustomerConversion.FinEntrystamp = DateTime.Now;
                        exIpcustomerConversion.FinUsrlogn = model.FinanceLoginID;
                        _repositorycontext.ExIpcustomerConversions.Update(exIpcustomerConversion);

                        var finddata = (from p in _repositorycontext.ExResourceassignmentstatuses
                                        where p.CuIden == model.cuiden && p.KickOff == model.kickofdate && p.PeLogn == model.pelogn && p.Enddate == null
                                        select new
                                        {
                                            Sl = p.Sl,
                                            Tranid = p.Tranid,
                                            Group = p.Group,
                                            ProjId = p.ProjId,
                                            Role = p.Role,
                                            BillStart = p.BillStart,
                                            BillEnd = p.BillEnd,
                                            Status = p.Status,
                                            StatusLevelId = p.StatusLevelId,
                                            ApproveStatus = p.ApproveStatus,
                                            OffboardStatus = p.OffboardStatus,
                                            Reason = p.Reason,
                                            FinStatus = p.FinStatus,
                                            BillpauseStartdate = p.BillpauseStartdate,
                                            BillpauseEnddate = p.BillpauseEnddate,
                                            OffboardReason = p.OffboardReason
                                        }).ToList();
                        int Sl = 0;
                        int Tranid = 0;
                        int ProjId = 0;
                        int StatusLevelId = 0;
                        string Group = "";
                        string Role = "";
                        DateTime BillStart = DateTime.Now;
                        DateTime BillEnd = DateTime.Now;
                        string Status = "";
                        string ApproveStatus = "";
                        string OffboardStatus = "";
                        string Reason = "";
                        string FinStatus = "";
                        string OffboardReason = "";
                        DateTime BillpauseStartdate = DateTime.Now;
                        DateTime BillpauseEnddate = DateTime.Now;
                        if (finddata.Count > 0)
                        {
                            Sl = Convert.ToInt16(finddata[0].Sl);
                            Tranid = Convert.ToInt16(finddata[0].Tranid);
                            ProjId = Convert.ToInt16(finddata[0].ProjId);
                            StatusLevelId = Convert.ToInt16(finddata[0].StatusLevelId);
                            Group = finddata[0].Group;
                            Role = finddata[0].Role;
                            Status = finddata[0].Status;
                            ApproveStatus = finddata[0].ApproveStatus;
                            OffboardStatus = finddata[0].OffboardStatus;
                            Reason = finddata[0].Reason;
                            FinStatus = finddata[0].FinStatus;
                            OffboardReason = finddata[0].OffboardReason;
                            BillStart = Convert.ToDateTime(finddata[0].BillStart);
                            BillEnd = Convert.ToDateTime(finddata[0].BillEnd);
                            BillpauseStartdate = Convert.ToDateTime(finddata[0].BillpauseStartdate);
                            BillpauseEnddate = Convert.ToDateTime(finddata[0].BillpauseEnddate);
                        }
                        string[] reasonLIst = { "BNA", "BILLING" };

                        ExResourceassignmentstatus exResourceassignmentstatus = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.PeLogn == model.pelogn
                         && x.CuIden == model.cuiden && x.KickOff == model.kickofdate && x.Enddate == null).FirstOrDefault();
                        exResourceassignmentstatus.Enddate = model.Startdate.AddDays(-1);
                        exResourceassignmentstatus.BillEnd = reasonLIst.Contains(model.currentreason) ? model.Startdate.AddDays(-1) : null;
                        _repositorycontext.ExResourceassignmentstatuses.Update(exResourceassignmentstatus);

                        ExResourceassignmentstatus statusmodel = new ExResourceassignmentstatus();
                        statusmodel.Sl = Sl;
                        statusmodel.Tranid = Tranid + 1;
                        statusmodel.PeLogn = model.pelogn;
                        statusmodel.CuIden = Convert.ToInt32(model.cuiden);
                        statusmodel.ProjId = ProjId;
                        statusmodel.Group = Group;
                        statusmodel.Role = Role;
                        statusmodel.KickOff = model.kickofdate;
                        statusmodel.DateOfMove = null;
                        statusmodel.Startdate = model.Startdate;
                        statusmodel.Enddate = null;
                        statusmodel.BillStart = model.newreason == "BNA" ? model.Startdate : null;
                        statusmodel.BillEnd = model.newreason == "BNA" ? null : BillEnd.ToString() == "1/1/0001 12:00:00 AM" ? null : BillEnd;
                        statusmodel.Status = model.newreason.Length < 5 ? "A" : "S";
                        statusmodel.StatusLevelId = model.newreason.Length < 5 ? null : Convert.ToInt16(model.newreason.Substring(4, 1));
                        statusmodel.Entrystamp = DateTime.Now;
                        statusmodel.Userlognid = model.FinanceLoginID;
                        statusmodel.ApproveStatus = ApproveStatus;
                        statusmodel.OffboardStatus = OffboardStatus;
                        statusmodel.OffboardStamp = null;
                        statusmodel.OffboardUserlognid = null;
                        statusmodel.Reason = model.newreason;
                        statusmodel.OffboardReason = OffboardReason;
                        statusmodel.FinStatus = FinStatus;
                        statusmodel.BillpauseStartdate = BillpauseStartdate.ToString() == "1/1/0001 12:00:00 AM" ? null : BillpauseStartdate;
                        statusmodel.BillpauseEnddate = BillpauseEnddate.ToString() == "1/1/0001 12:00:00 AM" ? null : BillpauseEnddate;
                        _repositorycontext.ExResourceassignmentstatuses.Add(statusmodel);



                        var finddata1 = (from p in _repositorycontext.ExIpcustomerReasons
                                         where p.CuIden == model.cuiden && p.KickOff == model.kickofdate && p.PeLogn == model.pelogn && p.EffectiveTo == null
                                         select new
                                         {
                                             Sl = p.Sl,
                                             ProjId = p.ProjId,
                                             Reason = p.Reason,
                                             KickOff = p.KickOff,
                                             DateOfMove = p.DateOfMove,
                                             EffectiveFrom = p.EffectiveFrom,
                                             Replacewith = p.Replacewith,
                                             Comments = p.Comments,
                                             EnddateStamp = p.EnddateStamp,
                                             EnddateUserlognid = p.EnddateUserlognid
                                         }).ToList();

                        int Sl1 = 0;
                        int ProjId1 = 0;
                        string Reason1 = "";
                        DateTime KickOff = DateTime.Now;
                        DateTime DateOfMove = DateTime.Now;
                        DateTime EffectiveFrom = DateTime.Now;
                        DateTime EnddateStamp = DateTime.Now;
                        string Replacewith = "";
                        string Comments = "";
                        string EnddateUserlognid = "";

                        if (finddata1.Count > 0)
                        {
                            Sl1 = Convert.ToInt16(finddata1[0].Sl);
                            ProjId1 = Convert.ToInt16(finddata1[0].ProjId);
                            Reason1 = finddata1[0].Reason;
                            KickOff = Convert.ToDateTime(finddata1[0].KickOff);
                            DateOfMove = Convert.ToDateTime(finddata1[0].DateOfMove);
                            EffectiveFrom = Convert.ToDateTime(finddata1[0].EffectiveFrom);
                            EnddateStamp = Convert.ToDateTime(finddata1[0].EnddateStamp);
                            Replacewith = finddata1[0].Replacewith;
                            Comments = finddata1[0].Comments;
                            EnddateUserlognid = finddata1[0].EnddateUserlognid;
                        }

                        ExIpcustomerReason exIpcustomerReason = _repositorycontext.ExIpcustomerReasons.Where(x => x.PeLogn == model.pelogn
         && x.DateOfMove == null && x.EffectiveTo == null && x.CuIden == model.cuiden && x.KickOff == model.kickofdate).FirstOrDefault();
                        exIpcustomerReason.Status = "D";
                        exIpcustomerReason.EffectiveTo = model.Startdate.AddDays(-1);
                        exIpcustomerReason.EnddateStamp = DateTime.Now;
                        exIpcustomerReason.EnddateUserlognid = model.FinanceLoginID;
                        _repositorycontext.ExIpcustomerReasons.Update(exIpcustomerReason);

                        ExIpcustomerReason exIpcustomerReason1 = new ExIpcustomerReason();
                        exIpcustomerReason1.Sl = Sl1;
                        exIpcustomerReason1.CuIden = model.cuiden;
                        exIpcustomerReason1.ProjId = ProjId1;
                        exIpcustomerReason1.PeLogn = model.pelogn;
                        exIpcustomerReason1.Reason = model.newreason;
                        exIpcustomerReason1.KickOff = KickOff;
                        exIpcustomerReason1.DateOfMove = DateOfMove.ToString() == "1/1/0001 12:00:00 AM" ? null : DateOfMove;
                        exIpcustomerReason1.EffectiveFrom = model.Startdate;
                        exIpcustomerReason1.EffectiveTo = null;
                        exIpcustomerReason1.Replacewith = model.reppelogn == null ? null : model.reppelogn;
                        exIpcustomerReason1.Comments = model.FinanceComments;
                        exIpcustomerReason1.Userlognid = model.FinanceLoginID;
                        exIpcustomerReason1.Entrystamp = DateTime.Now;
                        exIpcustomerReason1.Status = "A";
                        exIpcustomerReason1.EnddateStamp = null;
                        exIpcustomerReason1.EnddateUserlognid = null;
                        _repositorycontext.ExIpcustomerReasons.Add(exIpcustomerReason1);

                        if (model.newreason.ToUpper() == "BNA" || model.newreason.ToUpper() == "NBST5")
                        {
                            decimal? billingsum = 0;
                            var Billing = (from p in _repositorycontext.ExResourcebillpercents
                                           where p.PeLogn == model.pelogn && p.CuIden != model.cuiden && p.BillpercentEnddt == null
                                           select new
                                           {
                                               p.Billpercent

                                           }).ToList();

                            if (Billing.Count > 0)
                            {
                                billingsum = Billing.Sum(t => t.Billpercent);
                            }

                            billingsum = 100 - billingsum;

                            ExResourcebillpercent statusobj = new ExResourcebillpercent();
                            statusobj.Sl = Sl;
                            statusobj.CuIden = model.cuiden;
                            statusobj.PeLogn = model.pelogn;
                            statusobj.ProjId = ProjId;
                            statusobj.KickOff = model.kickofdate;
                            statusobj.DateOfMove = null;
                            statusobj.BillpercentStartdt = model.Startdate;
                            statusobj.BillpercentEnddt = null;
                            statusobj.Billpercent = billingsum;
                            statusobj.Userlognid = model.FinanceLoginID;
                            statusobj.Entrystamp = DateTime.Now;
                            statusobj.Status = "A";
                            statusobj.FinStatus = "A";
                            _repositorycontext.ExResourcebillpercents.Add(statusobj);

                            ExResourceassignment exResourceassignment = _repositorycontext.ExResourceassignments.Where(x => x.PeLogn == model.pelogn
                         && x.CuIden == model.cuiden && x.KickOffDate == model.kickofdate && x.ApproveStatus == "A" && x.OnOff == 0).FirstOrDefault();
                            exResourceassignment.BillEntity = model.billentity;
                            _repositorycontext.ExResourceassignments.Update(exResourceassignment);
                        }
                        else
                        {
                            ExResourcebillpercent exResourcebillpercent = _repositorycontext.ExResourcebillpercents.Where(x => x.PeLogn == model.pelogn
                       && x.CuIden == model.cuiden && x.KickOff == model.kickofdate && x.BillpercentEnddt == null).FirstOrDefault();
                            exResourcebillpercent.BillpercentEnddt = model.Startdate.AddDays(-1);
                            exResourcebillpercent.Status = "D";
                            exResourcebillpercent.EnddateUserlognid = model.FinanceLoginID;
                            exResourcebillpercent.EnddateStamp = DateTime.Now;
                            _repositorycontext.ExResourcebillpercents.Update(exResourcebillpercent);

                        }

                        if (model.newreason.ToUpper() == "NBST1")
                        {
                            ExResourceassignment exResourceassignment1 = _repositorycontext.ExResourceassignments.Where(x => x.PeLogn == model.pelogn
                      && x.CuIden == model.cuiden && x.KickOffDate == model.kickofdate && x.ApproveStatus == "A" && x.OnOff == 0).FirstOrDefault();
                            exResourceassignment1.RepValognid = model.reppelogn;
                            _repositorycontext.ExResourceassignments.Update(exResourceassignment1);
                        }

                        _repositorycontext.SaveChanges();
                        kickmodel.nstatus = "Update Sucessfully";

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

        [HttpGet("GetPendingAdminTransactions/{location}/{onoff}")]
        public IActionResult GetPendingAdminTransactions(string location, string onoff)
        {
            Dictionary<string, object> dList = new Dictionary<string, object>();
            Response response = new();
            try
            {

                var ExResourceassignment = (from a in _repositorycontext.ExResourceassignments where a.AdminStatusOnapprove.ToUpper() == "P" select a).ToList();
                var IPCustomerlist = (from a in _repositorycontext.IpCustomers select a).ToList();
                var ExStatusdescs = (from a in _repositorycontext.ExStatusdescs select a).ToList();

                var IpPersonList = (from a in _edmdbcontext.IpPeople  select a).ToList();
                var IpLocations = (from a in _edmdbcontext.IpLocations select a).ToList();
                var IpCategories = (from a in _edmdbcontext.IpCategories select a).ToList();
                var IpElements = (from a in _edmdbcontext.IpElements select a).ToList();

                if (location == "-1")
                {
                    if (onoff == "0")
                    {
                        var Adminpending = (from a in ExResourceassignment
                                            join b in IpPersonList
                         on new
                         { User = a != null ? a.PeLogn : "" }
          equals new { User = b != null ? b.PeLogn : "" } into sc1
                                            from b in sc1.DefaultIfEmpty()
                                            join c in IPCustomerlist
                       on new
                       { CLientcode = a != null ? a.CuIden.ToString() : "" }
        equals new { CLientcode = c != null ? c.CuIden.ToString() : "" } into sc2
                                            from c in sc2.DefaultIfEmpty()

                                            join e in IpLocations
                     on new
                     { Location = b != null ? b.PeLocn.ToString() : "" }
        equals new { Location = e != null ? e.IpLocn.ToString() : "" } into sc4
                                            from e in sc4.DefaultIfEmpty()

                                            join f in IpCategories
                  on new
                  { Role = a != null ? a.AssignType.ToLower() : "" }
     equals new { Role = f != null ? f.CaCode.ToLower() : "" } into sc5
                                            from f in sc5.DefaultIfEmpty()
                                            join g in IpPersonList
                       on new
                       { User = a != null ? a.PeLmgr : "" }
        equals new { User = g != null ? g.PeLogn : "" } into sc6
                                            from g in sc6.DefaultIfEmpty()

                                            join h in IpElements
                    on new
                    { Dept = b != null ? b.PeDept : "" }
     equals new { Dept = h != null ? h.ElCode : "" } into sc7
                                            from h in sc7.DefaultIfEmpty()

                                                //                                    join d in ExStatusdescs
                                                //            on new
                                                //            { Status = a != null ? a.Reason : "" }
                                                //equals new { Status = d != null ? d.Level : "" } into sc3
                                                //                                    from d in sc3.DefaultIfEmpty()

                                            where a.OnOff == 0 && a.ApproveStatus == "A" && a.ComplianceStatus == "A" && (a.FinanceStatus == "A" || a.FinanceStatus == "P")
                                                        && a.AdminStatusOnapprove == "P" && b.PeQuit ==null
                                            orderby a.KickOffDate
                                            select new
                                            {
                                                ID = a.Id,
                                                PeLogn = a.PeLogn,
                                                CuIden = a.CuIden,
                                                PeName = b != null ? b.PeName : "NA",
                                                CuComp = c.CuComp,
                                                //StatusDesc = d.StatusDesc,
                                                KickOffDate = a != null ? a.KickOffDate.Value.ToString("yyyy-MM-dd") : "",
                                                Allocation = a.Allocation,
                                                Billpercent = a.Billpercent,
                                                Location = e != null ? e.LnName : "NA",
                                                ManagerComments = a.ManagerComments,
                                                ComplianceComments = a.ComplianceComments,
                                                FinanceComments = a.FinanceComments,
                                                Role = f!=null ? f.CaName :"NA",
                                                Manager = g != null ? g.PeName : "NA",
                                                Department = h != null ? h.ElName : "NA"

                                            }).Distinct().ToList();

                        var Checklistpending = (from a in _repositorycontext.ExResourceassignmentChecklists
                                                join b in _repositorycontext.ExChecklistMasters on a.ChecklistId equals b.ChecklistId into sc
                                                from b in sc.DefaultIfEmpty()
                                                where (a.ChecklistId == 8 || a.ChecklistId == 9) && a.Status == "P"
                                                select new
                                                {
                                                    ID = a.Id,
                                                    Comments = a.Comments,
                                                    YesNoInd = a.YesNoInd,
                                                    ChecklistDesc = b.ChecklistDesc
                                                }).Distinct().ToList();


                        dList.Add("Checklistpending", Checklistpending);
                        dList.Add("Table", Adminpending);
                    }
                    else
                    {
                        var Adminpending = (from a in ExResourceassignment
                                            join b in IpPersonList
                         on new
                         { User = a != null ? a.PeLogn : "" }
          equals new { User = b != null ? b.PeLogn : "" } into sc1
                                            from b in sc1.DefaultIfEmpty()
                                            join c in IPCustomerlist
                       on new
                       { CLientcode = a != null ? a.CuIden.ToString() : "" }
        equals new { CLientcode = c != null ? c.CuIden.ToString() : "" } into sc2
                                            from c in sc2.DefaultIfEmpty()

                                            join e in IpLocations
                     on new
                     { Location = b != null ? b.PeLocn.ToString() : "" }
        equals new { Location = e != null ? e.IpLocn.ToString() : "" } into sc4
                                            from e in sc4.DefaultIfEmpty()

                                            join f in IpCategories
                  on new
                  { Role = a != null ? a.AssignType : "" }
     equals new { Role = f != null ? f.CaCode : "" } into sc5
                                            from f in sc5.DefaultIfEmpty()
                                            join g in IpPersonList
                       on new
                       { User = a != null ? a.PeLmgr : "" }
        equals new { User = g != null ? g.PeLogn : "" } into sc6
                                            from g in sc6.DefaultIfEmpty()

                                            join h in IpElements
                    on new
                    { Dept = b != null ? b.PeDept : "" }
     equals new { Dept = h != null ? h.ElCode : "" } into sc7
                                            from h in sc7.DefaultIfEmpty()

                                                //                                    join d in ExStatusdescs
                                                //            on new
                                                //            { Status = a != null ? a.Reason : "" }
                                                //equals new { Status = d != null ? d.Level : "" } into sc3
                                                //                                    from d in sc3.DefaultIfEmpty()

                                            where a.OnOff == 1 && a.ApproveStatus == "A" && a.ComplianceStatus == "A" && (a.FinanceStatus == "A" || a.FinanceStatus == "P")
                                                        && a.AdminStatusOnapprove == "P" && b.PeQuit == null
                                            orderby a.KickOffDate
                                            select new
                                            {
                                                ID = a.Id,
                                                PeLogn = a.PeLogn,
                                                CuIden = a.CuIden,
                                                PeName = b != null ? b.PeName : "NA",
                                                CuComp = c.CuComp,
                                                //StatusDesc = d.StatusDesc,
                                                KickOffDate = a != null ? a.KickOffDate.Value.ToString("yyyy-MM-dd") : "",
                                                Allocation = a.Allocation,
                                                Billpercent = a.Billpercent,
                                                Location = e != null ? e.LnName : "NA",
                                                ManagerComments = a.ManagerComments,
                                                ComplianceComments = a.ComplianceComments,
                                                FinanceComments = a.FinanceComments,
                                                Role = f.CaName,
                                                Manager = g != null ? g.PeName : "NA",
                                                Department = h != null ? h.ElName : "NA",
                                                DateOfSelectionOrMove = a.DateOfSelectionOrMove.Value.ToString("yyyy-MM-dd")

                                            }).Distinct().ToList();


                        var Checklistpending = (from a in _repositorycontext.ExResourceassignmentChecklists
                                                join b in _repositorycontext.ExChecklistMasters on a.ChecklistId equals b.ChecklistId into sc
                                                from b in sc.DefaultIfEmpty()
                                                where (a.ChecklistId == 12) && a.Status == "P"
                                                select new
                                                {
                                                    ID = a.Id,
                                                    Comments = a.Comments,
                                                    YesNoInd = a.YesNoInd,
                                                    ChecklistDesc = b.ChecklistDesc
                                                }).Distinct().ToList();


                        dList.Add("Checklistpending", Checklistpending);

                        dList.Add("Table", Adminpending);
                    }
                }
                else
                {
                    if (onoff == "0")
                    {
                        var Adminpending = (from a in ExResourceassignment
                                            join b in IpPersonList
                         on new
                         { User = a != null ? a.PeLogn : "" }
          equals new { User = b != null ? b.PeLogn : "" } into sc1
                                            from b in sc1.DefaultIfEmpty()
                                            join c in IPCustomerlist
                       on new
                       { CLientcode = a != null ? a.CuIden.ToString() : "" }
        equals new { CLientcode = c != null ? c.CuIden.ToString() : "" } into sc2
                                            from c in sc2.DefaultIfEmpty()

                                            join e in IpLocations
                     on new
                     { Location = b != null ? b.PeLocn.ToString() : "" }
        equals new { Location = e != null ? e.IpLocn.ToString() : "" } into sc4
                                            from e in sc4.DefaultIfEmpty()

                                            join f in IpCategories
             on new
             { Role = a != null ? a.AssignType : "" }
    equals new { Role = f != null ? f.CaCode : "" } into sc5
                                            from f in sc5.DefaultIfEmpty()
                                            join g in IpPersonList
                     on new
                     { User = a != null ? a.PeLmgr : "" }
      equals new { User = g != null ? g.PeLogn : "" } into sc6
                                            from g in sc6.DefaultIfEmpty()

                                            join h in IpElements
                    on new
                    { Dept = b != null ? b.PeDept : "" }
     equals new { Dept = h != null ? h.ElCode : "" } into sc7
                                            from h in sc7.DefaultIfEmpty()

                                                //                                    join d in ExStatusdescs
                                                //            on new
                                                //            { Status = a != null ? a.Reason : "" }
                                                //equals new { Status = d != null ? d.Level : "" } into sc3
                                                //                                    from d in sc3.DefaultIfEmpty()

                                            where a.OnOff == 0 && a.ApproveStatus == "A" && a.ComplianceStatus == "A" && (a.FinanceStatus == "A" || a.FinanceStatus == "P")
                                                        && a.AdminStatusOnapprove == "P" && b.PeLocn == location && b.PeQuit == null


                                            orderby a.KickOffDate
                                            select new
                                            {
                                                ID = a.Id,
                                                PeLogn = a.PeLogn,
                                                CuIden = a.CuIden,
                                                PeName = b != null ? b.PeName : "NA",
                                                CuComp = c.CuComp,
                                                //StatusDesc = d.StatusDesc,
                                                KickOffDate = a != null ? a.KickOffDate.Value.ToString("yyyy-MM-dd") : "",
                                                Allocation = a.Allocation,
                                                Billpercent = a.Billpercent,
                                                Location = e != null ? e.LnName : "NA",
                                                ManagerComments = a.ManagerComments,
                                                ComplianceComments = a.ComplianceComments,
                                                FinanceComments = a.FinanceComments,
                                                Role = f != null ? f.CaName : "NA",
                                                Manager = g != null ? g.PeName : "NA",
                                                Department = h != null ? h.ElName : "NA"

                                            }).Distinct().ToList();


                        var Checklistpending = (from a in _repositorycontext.ExResourceassignmentChecklists
                                                join b in _repositorycontext.ExChecklistMasters on a.ChecklistId equals b.ChecklistId into sc
                                                from b in sc.DefaultIfEmpty()
                                                where (a.ChecklistId == 8 || a.ChecklistId == 9) && a.Status == "P"
                                                select new
                                                {
                                                    ID = a.Id,
                                                    Comments = a.Comments,
                                                    YesNoInd = a.YesNoInd,
                                                    ChecklistDesc = b.ChecklistDesc
                                                }).Distinct().ToList();


                        dList.Add("Checklistpending", Checklistpending);

                        dList.Add("Table", Adminpending);
                    }
                    else
                    {
                        var Adminpending = (from a in ExResourceassignment
                                            join b in IpPersonList
                         on new
                         { User = a != null ? a.PeLogn : "" }
          equals new { User = b != null ? b.PeLogn : "" } into sc1
                                            from b in sc1.DefaultIfEmpty()
                                            join c in IPCustomerlist
                       on new
                       { CLientcode = a != null ? a.CuIden.ToString() : "" }
        equals new { CLientcode = c != null ? c.CuIden.ToString() : "" } into sc2
                                            from c in sc2.DefaultIfEmpty()

                                            join e in IpLocations
                     on new
                     { Location = b != null ? b.PeLocn.ToString() : "" }
        equals new { Location = e != null ? e.IpLocn.ToString() : "" } into sc4
                                            from e in sc4.DefaultIfEmpty()

                                            join f in IpCategories
             on new
             { Role = a != null ? a.AssignType : "" }
    equals new { Role = f != null ? f.CaCode : "" } into sc5
                                            from f in sc5.DefaultIfEmpty()
                                            join g in IpPersonList
                     on new
                     { User = a != null ? a.PeLmgr : "" }
      equals new { User = g != null ? g.PeLogn : "" } into sc6
                                            from g in sc6.DefaultIfEmpty()

                                            join h in IpElements
                    on new
                    { Dept = b != null ? b.PeDept : "" }
     equals new { Dept = h != null ? h.ElCode : "" } into sc7
                                            from h in sc7.DefaultIfEmpty()

                                                //                                    join d in ExStatusdescs
                                                //            on new
                                                //            { Status = a != null ? a.Reason : "" }
                                                //equals new { Status = d != null ? d.Level : "" } into sc3
                                                //                                    from d in sc3.DefaultIfEmpty()

                                            where a.OnOff == 1 && a.ApproveStatus == "A" && a.ComplianceStatus == "A" && (a.FinanceStatus == "A" || a.FinanceStatus == "P")
                                                        && a.AdminStatusOnapprove == "P" && b.PeLocn == location && b.PeQuit == null
                                            orderby a.KickOffDate
                                            select new
                                            {
                                                ID = a.Id,
                                                PeLogn = a.PeLogn,
                                                CuIden = a.CuIden,
                                                PeName = b != null ? b.PeName : "NA",
                                                CuComp = c.CuComp,
                                                //StatusDesc = d.StatusDesc,
                                                KickOffDate = a != null ? a.KickOffDate.Value.ToString("yyyy-MM-dd") : "",
                                                Allocation = a.Allocation,
                                                Billpercent = a.Billpercent,
                                                Location = e != null ? e.LnName : "NA",
                                                ManagerComments = a.ManagerComments,
                                                ComplianceComments = a.ComplianceComments,
                                                FinanceComments = a.FinanceComments,
                                                Role = f != null ? f.CaName : "NA",
                                                Manager = g != null ? g.PeName : "NA",
                                                Department = h != null ? h.ElName : "NA",
                                                DateOfSelectionOrMove = a.DateOfSelectionOrMove.Value.ToString("yyyy-MM-dd")

                                            }).Distinct().ToList();

                        var Checklistpending = (from a in _repositorycontext.ExResourceassignmentChecklists
                                                join b in _repositorycontext.ExChecklistMasters on a.ChecklistId equals b.ChecklistId into sc
                                                from b in sc.DefaultIfEmpty()
                                                where (a.ChecklistId == 12) && a.Status == "P"
                                                select new
                                                {
                                                    ID = a.Id,
                                                    Comments = a.Comments,
                                                    YesNoInd = a.YesNoInd,
                                                    ChecklistDesc = b.ChecklistDesc
                                                }).Distinct().ToList();


                        dList.Add("Checklistpending", Checklistpending);

                        dList.Add("Table", Adminpending);
                    }

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

        [HttpGet("GetPendingITTransactions/{location}/{onoff}")]
        public IActionResult GetPendingITTransactions(string location, string onoff)
        {
            Dictionary<string, object> dList = new Dictionary<string, object>();
            Response response = new();
            try
            {

                var ExResourceassignment = (from a in _repositorycontext.ExResourceassignments where a.AdminStatusOnapprove.ToUpper() == "P" select a).ToList();
                var IPCustomerlist = (from a in _repositorycontext.IpCustomers select a).ToList();
                var ExStatusdescs = (from a in _repositorycontext.ExStatusdescs select a).ToList();

                var IpPersonList = (from a in _edmdbcontext.IpPeople where a.PeQuit == null select a).ToList();
                var IpLocations = (from a in _edmdbcontext.IpLocations select a).ToList();
                var IpCategories = (from a in _edmdbcontext.IpCategories select a).ToList();
                var IpElements = (from a in _edmdbcontext.IpElements select a).ToList();

                if (location == "-1")
                {
                    if (onoff == "0")
                    {
                        var Adminpending = (from a in ExResourceassignment
                                            join b in IpPersonList
                         on new
                         { User = a != null ? a.PeLogn : "" }
          equals new { User = b != null ? b.PeLogn : "" } into sc1
                                            from b in sc1.DefaultIfEmpty()
                                            join c in IPCustomerlist
                       on new
                       { CLientcode = a != null ? a.CuIden.ToString() : "" }
        equals new { CLientcode = c != null ? c.CuIden.ToString() : "" } into sc2
                                            from c in sc2.DefaultIfEmpty()

                                            join e in IpLocations
                     on new
                     { Location = b != null ? b.PeLocn.ToString() : "" }
        equals new { Location = e != null ? e.IpLocn.ToString() : "" } into sc4
                                            from e in sc4.DefaultIfEmpty()

                                            join f in IpCategories
                  on new
                  { Role = a != null ? a.AssignType : "" }
     equals new { Role = f != null ? f.CaCode : "" } into sc5
                                            from f in sc5.DefaultIfEmpty()
                                            join g in IpPersonList
                       on new
                       { User = a != null ? a.PeLmgr : "" }
        equals new { User = g != null ? g.PeLogn : "" } into sc6
                                            from g in sc6.DefaultIfEmpty()

                                            join h in IpElements
                    on new
                    { Dept = b != null ? b.PeDept : "" }
     equals new { Dept = h != null ? h.ElCode : "" } into sc7
                                            from h in sc7.DefaultIfEmpty()

                                                //                                    join d in ExStatusdescs
                                                //            on new
                                                //            { Status = a != null ? a.Reason : "" }
                                                //equals new { Status = d != null ? d.Level : "" } into sc3
                                                //                                    from d in sc3.DefaultIfEmpty()

                                            where a.OnOff == 0 && a.ApproveStatus == "A" && a.ComplianceStatus == "A" && (a.FinanceStatus == "A" || a.FinanceStatus == "P")
                                                        && a.ItStatusOnapprove == "P"
                                            orderby a.KickOffDate
                                            select new
                                            {
                                                ID = a.Id,
                                                PeLogn = a.PeLogn,
                                                CuIden = a.CuIden,
                                                PeName = b != null ? b.PeName : "NA",
                                                CuComp = c.CuComp,
                                                //StatusDesc = d.StatusDesc,
                                                KickOffDate = a != null ? a.KickOffDate.Value.ToString("yyyy-MM-dd") : "",
                                                Allocation = a.Allocation,
                                                Billpercent = a.Billpercent,
                                                Location = e != null ? e.LnName : "NA",
                                                ManagerComments = a.ManagerComments,
                                                ComplianceComments = a.ComplianceComments,
                                                FinanceComments = a.FinanceComments,
                                                Role = f!=null ? f.CaName :"NA",
                                                Manager = g != null ? g.PeName : "NA",
                                                Department = h != null ? h.ElName : "NA"

                                            }).Distinct().ToList();

                        var Checklistpending = (from a in _repositorycontext.ExResourceassignmentChecklists
                                                join b in _repositorycontext.ExChecklistMasters on a.ChecklistId equals b.ChecklistId into sc
                                                from b in sc.DefaultIfEmpty()
                                                where (a.ChecklistId == 6 || a.ChecklistId == 7) && a.Status == "P"
                                                select new
                                                {
                                                    ID = a.Id,
                                                    Comments = a.Comments,
                                                    YesNoInd = a.YesNoInd,
                                                    ChecklistDesc = b.ChecklistDesc
                                                }).Distinct().ToList();


                        dList.Add("Checklistpending", Checklistpending);

                        dList.Add("Table", Adminpending);
                    }
                    else
                    {
                        var Adminpending = (from a in ExResourceassignment
                                            join b in IpPersonList
                         on new
                         { User = a != null ? a.PeLogn : "" }
          equals new { User = b != null ? b.PeLogn : "" } into sc1
                                            from b in sc1.DefaultIfEmpty()
                                            join c in IPCustomerlist
                       on new
                       { CLientcode = a != null ? a.CuIden.ToString() : "" }
        equals new { CLientcode = c != null ? c.CuIden.ToString() : "" } into sc2
                                            from c in sc2.DefaultIfEmpty()

                                            join e in IpLocations
                     on new
                     { Location = b != null ? b.PeLocn.ToString() : "" }
        equals new { Location = e != null ? e.IpLocn.ToString() : "" } into sc4
                                            from e in sc4.DefaultIfEmpty()

                                            join f in IpCategories
                  on new
                  { Role = a != null ? a.AssignType : "" }
     equals new { Role = f != null ? f.CaCode : "" } into sc5
                                            from f in sc5.DefaultIfEmpty()
                                            join g in IpPersonList
                       on new
                       { User = a != null ? a.PeLmgr : "" }
        equals new { User = g != null ? g.PeLogn : "" } into sc6
                                            from g in sc6.DefaultIfEmpty()

                                            join h in IpElements
                    on new
                    { Dept = b != null ? b.PeDept : "" }
     equals new { Dept = h != null ? h.ElCode : "" } into sc7
                                            from h in sc7.DefaultIfEmpty()

                                                //                                    join d in ExStatusdescs
                                                //            on new
                                                //            { Status = a != null ? a.Reason : "" }
                                                //equals new { Status = d != null ? d.Level : "" } into sc3
                                                //                                    from d in sc3.DefaultIfEmpty()

                                            where a.OnOff == 1 && a.ApproveStatus == "A" && a.ComplianceStatus == "A" && (a.FinanceStatus == "A" || a.FinanceStatus == "P")
                                                        && a.ItStatusOnapprove == "P"
                                            orderby a.KickOffDate
                                            select new
                                            {
                                                ID = a.Id,
                                                PeLogn = a.PeLogn,
                                                CuIden = a.CuIden,
                                                PeName = b != null ? b.PeName : "NA",
                                                CuComp = c.CuComp,
                                                //StatusDesc = d.StatusDesc,
                                                KickOffDate = a != null ? a.KickOffDate.Value.ToString("yyyy-MM-dd") : "",
                                                Allocation = a.Allocation,
                                                Billpercent = a.Billpercent,
                                                Location = e != null ? e.LnName : "NA",
                                                ManagerComments = a.ManagerComments,
                                                ComplianceComments = a.ComplianceComments,
                                                FinanceComments = a.FinanceComments,
                                                Role = f.CaName,
                                                Manager = g != null ? g.PeName : "NA",
                                                Department = h != null ? h.ElName : "NA",
                                                DateOfSelectionOrMove = a.DateOfSelectionOrMove.Value.ToString("yyyy-MM-dd")

                                            }).Distinct().ToList();

                        var Checklistpending = (from a in _repositorycontext.ExResourceassignmentChecklists
                                                join b in _repositorycontext.ExChecklistMasters on a.ChecklistId equals b.ChecklistId into sc
                                                from b in sc.DefaultIfEmpty()
                                                where (a.ChecklistId == 10 || a.ChecklistId == 11) && a.Status == "P"
                                                select new
                                                {
                                                    ID = a.Id,
                                                    Comments = a.Comments,
                                                    YesNoInd = a.YesNoInd,
                                                    ChecklistDesc = b.ChecklistDesc
                                                }).Distinct().ToList();


                        dList.Add("Checklistpending", Checklistpending);

                        dList.Add("Table", Adminpending);
                    }
                }
                else
                {
                    if (onoff == "0")
                    {
                        var Adminpending = (from a in ExResourceassignment
                                            join b in IpPersonList
                         on new
                         { User = a != null ? a.PeLogn : "" }
          equals new { User = b != null ? b.PeLogn : "" } into sc1
                                            from b in sc1.DefaultIfEmpty()
                                            join c in IPCustomerlist
                       on new
                       { CLientcode = a != null ? a.CuIden.ToString() : "" }
        equals new { CLientcode = c != null ? c.CuIden.ToString() : "" } into sc2
                                            from c in sc2.DefaultIfEmpty()

                                            join e in IpLocations
                     on new
                     { Location = b != null ? b.PeLocn.ToString() : "" }
        equals new { Location = e != null ? e.IpLocn.ToString() : "" } into sc4
                                            from e in sc4.DefaultIfEmpty()

                                            join f in IpCategories
             on new
             { Role = a != null ? a.AssignType : "" }
    equals new { Role = f != null ? f.CaCode : "" } into sc5
                                            from f in sc5.DefaultIfEmpty()
                                            join g in IpPersonList
                     on new
                     { User = a != null ? a.PeLmgr : "" }
      equals new { User = g != null ? g.PeLogn : "" } into sc6
                                            from g in sc6.DefaultIfEmpty()

                                            join h in IpElements
                    on new
                    { Dept = b != null ? b.PeDept : "" }
     equals new { Dept = h != null ? h.ElCode : "" } into sc7
                                            from h in sc7.DefaultIfEmpty()

                                                //                                    join d in ExStatusdescs
                                                //            on new
                                                //            { Status = a != null ? a.Reason : "" }
                                                //equals new { Status = d != null ? d.Level : "" } into sc3
                                                //                                    from d in sc3.DefaultIfEmpty()

                                            where a.OnOff == 0 && a.ApproveStatus.ToUpper() == "A" && a.ComplianceStatus.ToUpper() == "A" && (a.FinanceStatus.ToUpper() == "A" || a.FinanceStatus.ToUpper() == "P")
                                                        && a.ItStatusOnapprove.ToUpper() == "P" && a.IpLocn == location
                                            orderby a.KickOffDate
                                            select new
                                            {
                                                ID = a.Id,
                                                PeLogn = a.PeLogn,
                                                CuIden = a.CuIden,
                                                PeName = b != null ? b.PeName : "NA",
                                                CuComp = c.CuComp,
                                                //StatusDesc = d.StatusDesc,
                                                KickOffDate = a != null ? a.KickOffDate.Value.ToString("yyyy-MM-dd") : "",
                                                Allocation = a.Allocation,
                                                Billpercent = a.Billpercent,
                                                Location = e != null ? e.LnName : "NA",
                                                ManagerComments = a.ManagerComments,
                                                ComplianceComments = a.ComplianceComments,
                                                FinanceComments = a.FinanceComments,
                                                Role = f != null ? f.CaName : "NA",
                                                Manager = g != null ? g.PeName : "NA",
                                                Department = h != null ? h.ElName : "NA"

                                            }).Distinct().ToList();

                        var Checklistpending = (from a in _repositorycontext.ExResourceassignmentChecklists
                                                join b in _repositorycontext.ExChecklistMasters on a.ChecklistId equals b.ChecklistId into sc
                                                from b in sc.DefaultIfEmpty()
                                                where (a.ChecklistId == 6 || a.ChecklistId == 7) && a.Status == "P"
                                                select new
                                                {
                                                    ID = a.Id,
                                                    Comments = a.Comments,
                                                    YesNoInd = a.YesNoInd,
                                                    ChecklistDesc = b.ChecklistDesc
                                                }).Distinct().ToList();


                        dList.Add("Checklistpending", Checklistpending);

                        dList.Add("Table", Adminpending);
                    }
                    else
                    {
                        var Adminpending = (from a in ExResourceassignment
                                            join b in IpPersonList
                         on new
                         { User = a != null ? a.PeLogn : "" }
          equals new { User = b != null ? b.PeLogn : "" } into sc1
                                            from b in sc1.DefaultIfEmpty()
                                            join c in IPCustomerlist
                       on new
                       { CLientcode = a != null ? a.CuIden.ToString() : "" }
        equals new { CLientcode = c != null ? c.CuIden.ToString() : "" } into sc2
                                            from c in sc2.DefaultIfEmpty()

                                            join e in IpLocations
                     on new
                     { Location = b != null ? b.PeLocn.ToString() : "" }
        equals new { Location = e != null ? e.IpLocn.ToString() : "" } into sc4
                                            from e in sc4.DefaultIfEmpty()

                                            join f in IpCategories
             on new
             { Role = a != null ? a.AssignType : "" }
    equals new { Role = f != null ? f.CaCode : "" } into sc5
                                            from f in sc5.DefaultIfEmpty()
                                            join g in IpPersonList
                     on new
                     { User = a != null ? a.PeLmgr : "" }
      equals new { User = g != null ? g.PeLogn : "" } into sc6
                                            from g in sc6.DefaultIfEmpty()

                                            join h in IpElements
                    on new
                    { Dept = b != null ? b.PeDept : "" }
     equals new { Dept = h != null ? h.ElCode : "" } into sc7
                                            from h in sc7.DefaultIfEmpty()

                                                //                                    join d in ExStatusdescs
                                                //            on new
                                                //            { Status = a != null ? a.Reason : "" }
                                                //equals new { Status = d != null ? d.Level : "" } into sc3
                                                //                                    from d in sc3.DefaultIfEmpty()

                                            where a.OnOff == 1 && a.ApproveStatus == "A" && a.ComplianceStatus == "A" && (a.FinanceStatus == "A" || a.FinanceStatus == "P")
                                                        && a.ItStatusOnapprove == "P" && a.IpLocn == location 
                                            orderby a.KickOffDate
                                            select new
                                            {
                                                ID = a.Id,
                                                PeLogn = a.PeLogn,
                                                CuIden = a.CuIden,
                                                PeName = b != null ? b.PeName : "NA",
                                                CuComp = c.CuComp,
                                                //StatusDesc = d.StatusDesc,
                                                KickOffDate = a != null ? a.KickOffDate.Value.ToString("yyyy-MM-dd") : "",
                                                Allocation = a.Allocation,
                                                Billpercent = a.Billpercent,
                                                Location = e != null ? e.LnName : "NA",
                                                ManagerComments = a.ManagerComments,
                                                ComplianceComments = a.ComplianceComments,
                                                FinanceComments = a.FinanceComments,
                                                Role = f != null ? f.CaName : "NA",
                                                Manager = g != null ? g.PeName : "NA",
                                                Department = h != null ? h.ElName : "NA",
                                                DateOfSelectionOrMove = a.DateOfSelectionOrMove.Value.ToString("yyyy-MM-dd")

                                            }).Distinct().ToList();

                        var Checklistpending = (from a in _repositorycontext.ExResourceassignmentChecklists
                                                join b in _repositorycontext.ExChecklistMasters on a.ChecklistId equals b.ChecklistId into sc
                                                from b in sc.DefaultIfEmpty()
                                                where (a.ChecklistId == 10 || a.ChecklistId == 11) && a.Status == "P"
                                                select new
                                                {
                                                    ID = a.Id,
                                                    Comments = a.Comments,
                                                    YesNoInd = a.YesNoInd,
                                                    ChecklistDesc = b.ChecklistDesc
                                                }).Distinct().ToList();


                        dList.Add("Checklistpending", Checklistpending);


                        dList.Add("Table", Adminpending);
                    }

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

        [HttpPost("AdminAction")]
        public IActionResult AdminAction(AdminAction model)
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

                    var findonoff = (from p in _repositorycontext.ExResourceassignments
                                     where p.Id == model.ID
                                    select new
                                    {
                                        OnOff = p.OnOff

                                    }).ToList();
                    int OnOff = 0;
                    if (findonoff.Count > 0)
                    {
                        OnOff = Convert.ToInt16(findonoff[0].OnOff);
                    }


                        ExResourceassignment exResourceassignment = _repositorycontext.ExResourceassignments.Where(x => x.AdminStatusOnapprove == "P"
                  && x.Id == model.ID && x.ApproveStatus == "A").FirstOrDefault();
                    exResourceassignment.AdminStatusOnapprove = "A";
                    exResourceassignment.AdminComment = model.Comments;
                    exResourceassignment.AdminCommentsOnapprove = model.Comments;
                    exResourceassignment.AdminStatusEntrystamp = DateTime.Now;
                    exResourceassignment.AdminStatusLognid = model.LoginID;
                    _repositorycontext.ExResourceassignments.Update(exResourceassignment);

                    var finddata = (from p in _repositorycontext.ExResourceassignmentChecklists
                                    where p.Id == model.ID && p.ChecklistId==8
                                    select new
                                    {
                                        ID = p.Id

                                    }).ToList();
                    if (finddata.Count > 0)
                    {
                        ExResourceassignmentChecklist exResourceassignmentChecklist = _repositorycontext.ExResourceassignmentChecklists.Where(x => x.Id == model.ID
                         && x.ChecklistId == 8).FirstOrDefault();
                        exResourceassignmentChecklist.Status = "A";
                        _repositorycontext.ExResourceassignmentChecklists.Update(exResourceassignmentChecklist); 

                    }


                    var finddata2222 = (from p in _repositorycontext.ExResourceassignmentChecklists
                                    where p.Id == model.ID && p.ChecklistId == 9
                                    select new
                                    {
                                        ID = p.Id

                                    }).ToList();
                    if (finddata2222.Count > 0)
                    { 
                        ExResourceassignmentChecklist exResourceassignmentChecklist1 = _repositorycontext.ExResourceassignmentChecklists.Where(x => x.Id == model.ID
                      && x.ChecklistId == 9).FirstOrDefault();
                        exResourceassignmentChecklist1.Status = "A";
                        _repositorycontext.ExResourceassignmentChecklists.Update(exResourceassignmentChecklist1);

                    }


                    var finddata1 = (from p in _repositorycontext.ExResourceassignmentChecklists
                                    where p.Id == model.ID && p.ChecklistId==12
                                    select new
                                    {
                                        ID = p.Id

                                    }).ToList();
                    if (finddata1.Count > 0)
                    {
                        ExResourceassignmentChecklist exResourceassignmentChecklist2 = _repositorycontext.ExResourceassignmentChecklists.Where(x => x.Id == model.ID
                  && x.ChecklistId == 12).FirstOrDefault();
                        exResourceassignmentChecklist2.Status = "A";
                        _repositorycontext.ExResourceassignmentChecklists.Update(exResourceassignmentChecklist2);
                    } 

                    _repositorycontext.SaveChanges();
                    kickmodel.nstatus = "Update Sucessfully";

                    // Admin Mail
                    {
                        string[] reasonList = { "BNA", "BILLING", "NBST5" };

                        var finddata234 = (from p in _repositorycontext.ExResourceassignments
                                           where p.Id == model.ID
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
                                         where p.PeLogn == model.LoginID
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
                                                 where p.PeLogn == model.LoginID
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
                                               PeMail = p.ParameterValue

                                           }).Take(1).ToList();

                        if (reasonList.Contains(Reason))
                        {
                            var findfinanceid = (from p in _repositorycontext.ExGeneralParameterConfigurations
                                                 where p.ParameterName == "Finance Notification ID"
                                                 select new
                                                 {
                                                     PeMail = p.ParameterValue

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
                                      where p.CuIden == CuIden && p.Enddate == null && p.Role == "DM" && b.PeDept==empdepratment
                                      select new
                                      {
                                          PeMail = b.PeMail

                                      }).Distinct().ToList();

                        var personemailid = (from p in _edmdbcontext.IpPeople
                                             where p.PeLogn == model.LoginID
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

                        var adminid = (from p in _repositorycontext.ExGeneralParameterConfigurations
                                           where p.ParameterId == 8
                                           select new
                                           {
                                               PeMail = p.ParameterValue

                                           }).Take(1).ToList();

                        var AdminGroupID = (from p in _repositorycontext.ExEmailnotifications
                                            where p.Location == pelocn && p.Modulename == "OnBoardApprove-Admin"
                                            select new
                                            {
                                                PeMail = p.Tomailid

                                            }).Distinct().ToList();


                        var cclistfinal = findPMO.Union(findemgr).Union(finddm).Union(tolistfinal).Union(AdminGroupID).ToList(); ;

                        if (findplowner.Count > 0)
                        {
                            cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(tolistfinal).Union(AdminGroupID).ToList();
                        }


                        //var cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(tolistfinal).Union(adminid).ToList();

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
                                tttttt = tttttt + tolistfinal[i].PeMail;
                            }
                        }

                        //cc = plowner +";" + pmomail + ";" + emgrmail + ";" + dmmail + ";" + personselfmailid;

                        string subject = string.Empty;

                        if (OnOff == 0)
                        {
                            //subject = "Onboard Updated By - ADMIN ( " + empname + " to " + clientcode + "(Reason: " + reasondesc + ")";
                            subject = "Onboard Updated By - ADMIN ( " + empname + " to " + clientcode;
                        }
                        else
                        {
                            subject = "OffBoard Updated By - ADMIN " + empname + " to " + clientcode;
                        }

                        string ABCD = "<table  border='1'><tr><td>" +
        "<Table BgColor='lavender' border='1' bordercolor ='lightblue' style='font-size:12px;font-family:Arial'>" +
        "<TR><TD BgColor='lavender'><B>Client Code</TD><TD >&nbsp;" + clientcode + "</TD></TR>" +
        "<TR><TD BgColor='lavender'><B>Emp Name</TD><TD >&nbsp;" + empname + "</TD></TR>";
                        
                        //if (reasonList.Contains(Reason))
                        //{
                        //    ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Billing Percentage</TD><TD >&nbsp;" + BillPercent + "</TD></TR>";
                        //}

                        //ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Reason</TD><TD >&nbsp;" + reasondesc + "</TD></TR>";


                       


                        ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Department</TD><TD >&nbsp;" + departfullname + "</TD></TR>" +
        "<TR><TD BgColor='lavender'><B>Comments</TD><TD >&nbsp;" + model.Comments + "</TD></TR>" +
        //"<TR><TD BgColor='lavender'><B>Request ID</TD><TD >&nbsp;" + (ReqId == -1 ? "NA" : ReqId) + "</TD></TR>" +
        "<TR><TD BgColor='lavender'><B>Kick off Date</TD><TD >&nbsp;" + KickoffDate.ToString("yyyy-MM-dd") + "</TD></TR>" +
        "<TR><TD BgColor='lavender'><B>Action By</TD><TD >&nbsp;" + empnamedonetransaction + "</TD></TR>" +
        "<TR><TD BgColor='lavender'><B>Action On</TD><TD >&nbsp;" + DateTime.Now + "</TD></TR>" +
         "<TR><TD BgColor='lavender'><B>Checklist For IT</TD><TD ></TD></TR>" +
          "<TR><TD BgColor='lavender'><B>Shared Folder Access</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 6 select a.Comments).FirstOrDefault() + "</TD></TR>" +
           "<TR><TD BgColor='lavender'><B>Email Group Access</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 7 select a.Comments).FirstOrDefault() + "</TD></TR>" +
             "<TR><TD BgColor='lavender'><B>Checklist For Admin</TD><TD ></TD></TR>" +
          "<TR><TD BgColor='lavender'><B>Client Room Access Details</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 8 select a.Comments).FirstOrDefault() + "</TD></TR>" +
           "<TR><TD BgColor='lavender'><B>Workstation Details</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 9 select a.Comments).FirstOrDefault() + "</TD></TR>";

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

                        string[] tomail11 = new string[personemailid.Count];
                        if (personemailid.Count > 0)
                        {
                            for (int i = 0; i < personemailid.Count; i++)
                            {
                                tomail11[i] = personemailid[i].PeMail;
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
                            string[] ccmail = { "rohit.sehgal@acuitykp.com" };
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

        [HttpPost("ITAction")]
        public IActionResult ITAction(AdminAction model)
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

                    var findonoff = (from p in _repositorycontext.ExResourceassignments
                                     where p.Id == model.ID
                                     select new
                                     {
                                         OnOff = p.OnOff

                                     }).ToList();
                    int OnOff = 0;
                    if (findonoff.Count > 0)
                    {
                        OnOff = Convert.ToInt16(findonoff[0].OnOff);
                    }

                    ExResourceassignment exResourceassignment = _repositorycontext.ExResourceassignments.Where(x => x.AdminStatusOnapprove == "P"
                  && x.Id == model.ID && x.ApproveStatus == "A").FirstOrDefault();
                    exResourceassignment.ItStatusOnapprove = "A";
                    exResourceassignment.ItComment = model.Comments;
                    exResourceassignment.ItCommentsOnapprove = model.Comments;
                    exResourceassignment.ItStatusEntrystamp = DateTime.Now;
                    exResourceassignment.ItStatusLognid = model.LoginID;
                    _repositorycontext.ExResourceassignments.Update(exResourceassignment);

                    var finddata = (from p in _repositorycontext.ExResourceassignmentChecklists
                                    where p.Id == model.ID && p.ChecklistId==6
                                    select new
                                    {
                                        ID = p.Id

                                    }).ToList();
                    if (finddata.Count > 0)
                    {
                        ExResourceassignmentChecklist exResourceassignmentChecklist = _repositorycontext.ExResourceassignmentChecklists.Where(x => x.Id == model.ID
                        &&  x.ChecklistId == 6 ).FirstOrDefault(); 
                        exResourceassignmentChecklist.Status = "A"; 
                        _repositorycontext.ExResourceassignmentChecklists.Update(exResourceassignmentChecklist); 
                    }


                    var finddata2222 = (from p in _repositorycontext.ExResourceassignmentChecklists
                                    where p.Id == model.ID && p.ChecklistId == 7
                                      select new
                                    {
                                        ID = p.Id

                                    }).ToList();
                    if (finddata2222.Count > 0)
                    { 

                        ExResourceassignmentChecklist exResourceassignmentChecklist1 = _repositorycontext.ExResourceassignmentChecklists.Where(x => x.Id == model.ID
                      && x.ChecklistId == 7).FirstOrDefault();
                        exResourceassignmentChecklist1.Status = "A";
                        _repositorycontext.ExResourceassignmentChecklists.Update(exResourceassignmentChecklist1);

                    }


                    var finddata1 = (from p in _repositorycontext.ExResourceassignmentChecklists
                                     where p.Id == model.ID && p.ChecklistId == 10
                                     select new
                                     {
                                         ID = p.Id

                                     }).ToList();
                    if (finddata1.Count > 0)
                    {
                        ExResourceassignmentChecklist exResourceassignmentChecklist2 = _repositorycontext.ExResourceassignmentChecklists.Where(x => x.Id == model.ID
                  && x.ChecklistId == 10).FirstOrDefault();
                        exResourceassignmentChecklist2.Status = "A";
                        _repositorycontext.ExResourceassignmentChecklists.Update(exResourceassignmentChecklist2);
                    }

                    var finddata2 = (from p in _repositorycontext.ExResourceassignmentChecklists
                                     where p.Id == model.ID && p.ChecklistId == 11
                                     select new
                                     {
                                         ID = p.Id

                                     }).ToList();
                    if (finddata2.Count > 0)
                    {
                        ExResourceassignmentChecklist exResourceassignmentChecklist2 = _repositorycontext.ExResourceassignmentChecklists.Where(x => x.Id == model.ID
                  && x.ChecklistId == 11).FirstOrDefault();
                        exResourceassignmentChecklist2.Status = "A";
                        _repositorycontext.ExResourceassignmentChecklists.Update(exResourceassignmentChecklist2);
                    }
                     

                    _repositorycontext.SaveChanges();
                    kickmodel.nstatus = "Update Sucessfully";

                    // IT Mail
                    {
                        string[] reasonList = { "BNA", "BILLING", "NBST5" };

                        var finddata234 = (from p in _repositorycontext.ExResourceassignments
                                           where p.Id == model.ID
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
                                              PeDept = p.PeDept

                                          }).Take(1).ToList();
                        string empname = "";
                        string empdepratment = "";
                        if (finddata22.Count > 0)
                        {
                            empname = finddata22[0].PeName;
                            empdepratment = finddata22[0].PeDept;
                        }



                        var finddata5 = (from p in _edmdbcontext.IpPeople
                                         where p.PeLogn == model.LoginID
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
                                                 where p.PeLogn == model.LoginID
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
                                               PeMail = p.ParameterValue

                                           }).Take(1).ToList();

                        if (reasonList.Contains(Reason))
                        {
                            var findfinanceid = (from p in _repositorycontext.ExGeneralParameterConfigurations
                                                 where p.ParameterName == "Finance Notification ID"
                                                 select new
                                                 {
                                                     PeMail = p.ParameterValue

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
                                      where p.CuIden == CuIden && p.Enddate == null && p.Role == "DM" && b.PeDept==empdepratment
                                      select new
                                      {
                                          PeMail = b.PeMail

                                      }).Distinct().ToList();

                        var personemailid = (from p in _edmdbcontext.IpPeople
                                             where p.PeLogn == model.LoginID
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

                        var cclistfinal = findPMO.Union(findemgr).Union(finddm).Union(tolistfinal).ToList();

                        if (findplowner.Count > 0)
                        {
                            cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(tolistfinal).ToList();
                        }


                        //var cclistfinal = findplowner.Union(findPMO).Union(findemgr).Union(finddm).Union(tolistfinal).ToList();

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
                                tttttt = tttttt + tolistfinal[i].PeMail;
                            }
                        }

                        //cc = plowner +";" + pmomail + ";" + emgrmail + ";" + dmmail + ";" + personselfmailid;

                        string subject = string.Empty;

                        if (OnOff == 0)
                        {
                            subject = "Onboard Updated By - ADMIN ( " + empname + " to " + clientcode + "(Reason: " + reasondesc + ")";
                        }
                        else
                        {
                            subject = "OffBoard Updated By - ADMIN " + empname + " to " + clientcode + "(Reason: " + reasondesc + ")";
                        }

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

                        ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Reason</TD><TD >&nbsp;" + reasondesc + "</TD></TR>";


                        //if (model.Reason.ToUpper() == "NBST1")
                        //{
                        //    ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Replacing</TD><TD >&nbsp;" + empnamereplacewith + "</TD></TR>";
                        //}


                        ABCD = ABCD + "<TR><TD BgColor='lavender'><B>Department</TD><TD >&nbsp;" + departfullname + "</TD></TR>" +
        "<TR><TD BgColor='lavender'><B>Comments</TD><TD >&nbsp;" + model.Comments + "</TD></TR>" +
        "<TR><TD BgColor='lavender'><B>Request ID</TD><TD >&nbsp;" + (ReqId == -1 ? "NA" : ReqId) + "</TD></TR>" +
        "<TR><TD BgColor='lavender'><B>Kick off Date</TD><TD >&nbsp;" + KickoffDate.ToString("yyyy-MM-dd") + "</TD></TR>" +
        "<TR><TD BgColor='lavender'><B>Action By</TD><TD >&nbsp;" + empnamedonetransaction + "</TD></TR>" +
        "<TR><TD BgColor='lavender'><B>Action On</TD><TD >&nbsp;" + DateTime.Now + "</TD></TR>" +
         "<TR><TD BgColor='lavender'><B>Checklist For IT</TD><TD ></TD></TR>" +
          "<TR><TD BgColor='lavender'><B>Shared Folder Access</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 6 select a.Comments).FirstOrDefault() + "</TD></TR>" +
           "<TR><TD BgColor='lavender'><B>Email Group Access</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 7 select a.Comments).FirstOrDefault() + "</TD></TR>" +
             "<TR><TD BgColor='lavender'><B>Checklist For Admin</TD><TD ></TD></TR>" +
          "<TR><TD BgColor='lavender'><B>Client Room Access Details</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 8 select a.Comments).FirstOrDefault() + "</TD></TR>" +
           "<TR><TD BgColor='lavender'><B>Workstation Details</TD><TD >&nbsp;" + (from a in _repositorycontext.ExResourceassignmentChecklists where a.Id == model.ID && a.ChecklistId == 9 select a.Comments).FirstOrDefault() + "</TD></TR>";

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

                        string[] tomail11 = new string[personemailid.Count];
                        if (personemailid.Count > 0)
                        {
                            for (int i = 0; i < personemailid.Count; i++)
                            {
                                tomail11[i] = personemailid[i].PeMail;
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
                            string[] ccmail = { "rohit.sehgal@acuitykp.com" };
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

        [HttpPost("UpdatePersonType")]
        public IActionResult UpdatePersonType(PersonTypeUpdate personTypeUpdate)
        {
            Response response = new();
            try
            {
                string message = string.Empty;
                if (personTypeUpdate is null)
                {
                    response.Status = false;
                    response.Message = "Atleast one record required";
                    response.Data = "";
                    response.Error = "Atleast one record required";
                    return Ok(response);
                }
                else
                {
                    foreach (var obj in personTypeUpdate.objectList)
                    {
                        Models.EMPDATA.ExIpperson exIpperson = _edmdbcontext.ExIppeople.Where(x => x.PeLogn == obj.pelogn).FirstOrDefault();
                        exIpperson.PersonType = obj.persontype;
                        _edmdbcontext.ExIppeople.Update(exIpperson);
                    } 
                   
                    _edmdbcontext.SaveChanges();

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


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
