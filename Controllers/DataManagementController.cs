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
    public class DataManagementController : Controller
    {
        private readonly RepositoryDbContext _repositorycontext;
        private readonly EDMDbContext _edmdbcontext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public DataManagementController(IHttpContextAccessor httpContextAccessor, IMapper mapper, RepositoryDbContext repositorycontext, EDMDbContext edmrepositorycontext)
        {
            _httpContextAccessor = httpContextAccessor;

            _mapper = mapper;
            _repositorycontext = repositorycontext;
            _edmdbcontext = edmrepositorycontext;
        }

        [HttpPost("UpdateRoleReasonGroupChanges")]
        public IActionResult UpdateRoleReasonGroupChanges(Resource model)
        {
            Response response = new Response();
            try
            {
                string pe_mail = string.Empty;
                pe_mail = (from s in _edmdbcontext.IpPeople where s.PeLogn == model.PeLogn select s.PeMail).ToString();
                DateTime enddate = Convert.ToDateTime(model.newstartdate);
                enddate = enddate.AddDays(-1);
                int ID = 0;
                var resAss = (from a in _repositorycontext.ExResourceassignments
                              where a.PeLogn == model.PeLogn && a.CuIden == Convert.ToInt32(model.CuIden)
                              && a.KickOffDate == Convert.ToDateTime(model.KickOff) && a.OnOff == 0
                              && a.ApproveStatus == "A"
                              select a
                            ).ToList();
                if (resAss.Count > 0)
                {
                    ID = resAss[0].Id;
                }
                var resAss2 = (from a in _repositorycontext.ExResourceassignmentstatuses
                               where a.PeLogn == model.PeLogn && a.CuIden == Convert.ToInt32(model.CuIden)
                               && a.KickOff == Convert.ToDateTime(model.KickOff) && a.Enddate == null
                               select a
                            ).ToList();
                int SL = 0;
                int tranid = 0;
                int newTranID = 0;
                DateTime startdate = DateTime.Now;
                int ProjID = 0;
                string groups = string.Empty;
                string role = string.Empty;
                string reason = string.Empty;
                if (resAss2.Count > 0)
                {
                    SL = (int)resAss2[0].Sl;
                    tranid = (int)resAss2[0].Tranid;
                    newTranID = tranid + 1;
                    startdate = (DateTime)resAss2[0].Startdate;
                    ProjID = (int)resAss2[0].ProjId;
                    groups = resAss2[0].Group;
                    role = resAss2[0].Role;
                    reason = resAss2[0].Reason;
                }
                string[] reasonList = { "BNA", "BILLING", "NBST5" };
                string[] roleReasonGroupList = { "BNA", "BILLING", "NBST5" };
                if (model.ChangeType == "Role" && model.RoleReasonGroup != role)
                {
                    ExResourceassignmentTran modelTran = new ExResourceassignmentTran();
                    modelTran.Id = ID;
                    modelTran.Sl = SL;
                    modelTran.Tranid = tranid;
                    modelTran.PeLogn = model.PeLogn;
                    modelTran.CuIden = Convert.ToInt32(model.CuIden);
                    modelTran.ProjId = ProjID;
                    modelTran.KickOff = Convert.ToDateTime(model.KickOff);
                    modelTran.Group = groups;
                    modelTran.Role = model.RoleReasonGroup;
                    modelTran.Reason = reason;
                    modelTran.Startdate = Convert.ToDateTime(model.newstartdate);
                    modelTran.ChangeType = model.ChangeType;
                    modelTran.Comments = model.comments;
                    modelTran.Entrystamp = DateTime.Now;
                    modelTran.Userlognid = model.Logn;
                    modelTran.Status = "A";
                    modelTran.Oldvalue = role;
                    _repositorycontext.ExResourceassignmentTrans.Add(modelTran);
                    var res3 = (from a in _repositorycontext.ExResourceassignmentstatuses
                                where a.PeLogn == model.PeLogn && a.CuIden == Convert.ToInt32(model.CuIden)
                                && a.Tranid == tranid && a.KickOff == Convert.ToDateTime(model.KickOff)
                                && a.Sl == SL && a.Enddate == null
                                select a
                            ).ToList();
                    if (res3.Count > 0)
                    {
                        ExResourceassignmentstatus statusmodel = new ExResourceassignmentstatus();
                        statusmodel.Sl = SL;
                        statusmodel.Tranid = newTranID;
                        statusmodel.PeLogn = model.PeLogn;
                        statusmodel.CuIden = Convert.ToInt32(model.CuIden);
                        statusmodel.ProjId = res3[0].ProjId;
                        statusmodel.Group = res3[0].Group;
                        statusmodel.Role = model.RoleReasonGroup;
                        statusmodel.KickOff = res3[0].KickOff;
                        statusmodel.DateOfMove = res3[0].DateOfMove;
                        statusmodel.Startdate = Convert.ToDateTime(model.newstartdate);
                        statusmodel.Enddate = null;
                        statusmodel.BillStart = res3[0].BillStart;
                        statusmodel.BillEnd = res3[0].BillEnd;
                        statusmodel.Status = res3[0].Status;
                        statusmodel.StatusLevelId = res3[0].StatusLevelId;
                        statusmodel.Entrystamp = DateTime.Now;
                        statusmodel.Userlognid = model.Logn;
                        statusmodel.ApproveStatus = res3[0].ApproveStatus;
                        statusmodel.OffboardStatus = res3[0].OffboardStatus;
                        statusmodel.OffboardStamp = res3[0].OffboardStamp;
                        statusmodel.OffboardUserlognid = res3[0].OffboardUserlognid;
                        statusmodel.Reason = res3[0].Reason;
                        statusmodel.OffboardReason = res3[0].OffboardReason;
                        statusmodel.FinStatus = res3[0].FinStatus;
                        statusmodel.BillpauseStartdate = res3[0].BillpauseStartdate;
                        statusmodel.BillpauseEnddate = res3[0].BillpauseEnddate;
                        _repositorycontext.ExResourceassignmentstatuses.Add(statusmodel);
                    }

                    var update1 = _repositorycontext.ExResourceassignmentstatuses.SingleOrDefault(e => e.Enddate == null && e.PeLogn == model.PeLogn && e.CuIden == Convert.ToInt32(model.CuIden) && e.Tranid == tranid && e.KickOff == Convert.ToDateTime(model.KickOff));
                    update1.Enddate = enddate;
                    _repositorycontext.ExResourceassignmentstatuses.Update(update1);

                    var update2 = _repositorycontext.ExIpcustomerRoles.SingleOrDefault(e => e.PeLogn == model.PeLogn && e.CuIden == Convert.ToInt32(model.CuIden) && e.KickOff == Convert.ToDateTime(model.KickOff) && e.ProjId == ProjID && e.Sl == SL && e.RoleEnddate == null && e.Role == role);
                    update2.RoleEnddate = enddate;
                    update2.EnddateStamp = DateTime.Now;
                    update2.EnddateUserlognid = model.Logn;
                    update2.Status = "D";
                    _repositorycontext.ExIpcustomerRoles.Update(update2);

                    var custRoleVar = (from a in _repositorycontext.ExIpcustomerRoles
                                       where a.PeLogn == model.PeLogn
&& a.CuIden == Convert.ToInt32(model.CuIden) && a.KickOff == Convert.ToDateTime(model.KickOff)
&& a.ProjId == ProjID && a.Sl == SL && a.RoleEnddate == enddate
&& a.Role == role
                                       select a).ToList();
                    if (custRoleVar.Count > 0)
                    {
                        ExIpcustomerRole rolemodel = new ExIpcustomerRole();
                        rolemodel.Sl = custRoleVar[0].Sl;
                        rolemodel.CuIden = custRoleVar[0].CuIden;
                        rolemodel.ProjId = custRoleVar[0].ProjId;
                        rolemodel.PeLogn = custRoleVar[0].PeLogn;
                        rolemodel.Role = model.RoleReasonGroup;
                        rolemodel.KickOff = custRoleVar[0].KickOff;
                        rolemodel.DateOfMove = custRoleVar[0].DateOfMove;
                        rolemodel.RoleStartdt = Convert.ToDateTime(model.newstartdate);
                        rolemodel.RoleEnddate = null;
                        rolemodel.Userlognid = model.Logn;
                        rolemodel.Entrystamp = DateTime.Now;
                        rolemodel.Status = "A";
                        rolemodel.EnddateStamp = null;
                        rolemodel.EnddateUserlognid = null;
                        rolemodel.ConfirmedBy = model.Logn;
                        rolemodel.ConfirmedDate = DateTime.Now;
                        _repositorycontext.ExIpcustomerRoles.Add(rolemodel);

                    }
                    //mail send logic


                }
                else if (model.ChangeType == "Group" && model.RoleReasonGroup != groups)
                {
                    ExResourceassignmentTran modelTran = new ExResourceassignmentTran();
                    modelTran.Id = ID;
                    modelTran.Sl = SL;
                    modelTran.Tranid = tranid;
                    modelTran.PeLogn = model.PeLogn;
                    modelTran.CuIden = Convert.ToInt32(model.CuIden);
                    modelTran.ProjId = ProjID;
                    modelTran.KickOff = Convert.ToDateTime(model.KickOff);
                    modelTran.Group = model.RoleReasonGroup;
                    modelTran.Role = role;
                    modelTran.Reason = reason;
                    modelTran.Startdate = Convert.ToDateTime(model.newstartdate);
                    modelTran.ChangeType = model.ChangeType;
                    modelTran.Comments = model.comments;
                    modelTran.Entrystamp = DateTime.Now;
                    modelTran.Userlognid = model.Logn;
                    modelTran.Status = "A";
                    modelTran.Oldvalue = groups;
                    _repositorycontext.ExResourceassignmentTrans.Add(modelTran);

                    var res3 = (from a in _repositorycontext.ExResourceassignmentstatuses
                                where a.PeLogn == model.PeLogn && a.CuIden == Convert.ToInt32(model.CuIden)
                                && a.Tranid == tranid && a.KickOff == Convert.ToDateTime(model.KickOff)
                                && a.Sl == SL && a.Enddate == null
                                select a
                            ).ToList();
                    if (res3.Count > 0)
                    {
                        ExResourceassignmentstatus statusmodel = new ExResourceassignmentstatus();
                        statusmodel.Sl = SL;
                        statusmodel.Tranid = newTranID;
                        statusmodel.PeLogn = res3[0].PeLogn;
                        statusmodel.CuIden = res3[0].CuIden;
                        statusmodel.ProjId = res3[0].ProjId;
                        statusmodel.Group = model.RoleReasonGroup;
                        statusmodel.Role = res3[0].Role;
                        statusmodel.KickOff = res3[0].KickOff;
                        statusmodel.DateOfMove = res3[0].DateOfMove;
                        statusmodel.Startdate = Convert.ToDateTime(model.newstartdate);
                        statusmodel.Enddate = null;
                        statusmodel.BillStart = res3[0].BillStart;
                        statusmodel.BillEnd = res3[0].BillEnd;
                        statusmodel.Status = res3[0].Status;
                        statusmodel.StatusLevelId = res3[0].StatusLevelId;
                        statusmodel.Entrystamp = DateTime.Now;
                        statusmodel.Userlognid = model.Logn;
                        statusmodel.ApproveStatus = res3[0].ApproveStatus;
                        statusmodel.OffboardStatus = res3[0].OffboardStatus;
                        statusmodel.OffboardStamp = res3[0].OffboardStamp;
                        statusmodel.OffboardUserlognid = res3[0].OffboardUserlognid;
                        statusmodel.Reason = res3[0].Reason;
                        statusmodel.OffboardReason = res3[0].OffboardReason;
                        statusmodel.FinStatus = res3[0].FinStatus;
                        statusmodel.BillpauseStartdate = res3[0].BillpauseStartdate;
                        statusmodel.BillpauseEnddate = res3[0].BillpauseEnddate;
                        _repositorycontext.ExResourceassignmentstatuses.Add(statusmodel);
                    }
                    var update1 = _repositorycontext.ExResourceassignmentstatuses.SingleOrDefault(e => e.Enddate == null && e.PeLogn == model.PeLogn && e.CuIden == Convert.ToInt32(model.CuIden) && e.Tranid == tranid && e.KickOff == Convert.ToDateTime(model.KickOff) && e.Sl == SL);
                    update1.Enddate = enddate;
                    _repositorycontext.ExResourceassignmentstatuses.Update(update1);

                    var update2 = _repositorycontext.ExIpcustomerGroups.SingleOrDefault(e => e.PeLogn == model.PeLogn && e.CuIden == Convert.ToInt32(model.CuIden) && e.KickOff == Convert.ToDateTime(model.KickOff) && e.ProjId == ProjID && e.Sl == SL && e.GroupEnddate == null && e.Group == groups);
                    update2.GroupEnddate = enddate;
                    update2.EnddateStamp = DateTime.Now;
                    update2.EnddateUserlognid = model.Logn;
                    update2.Status = "D";
                    _repositorycontext.ExIpcustomerGroups.Update(update2);

                    var custRoleVar = (from a in _repositorycontext.ExIpcustomerGroups
                                       where a.PeLogn == model.PeLogn
&& a.CuIden == Convert.ToInt32(model.CuIden) &&
a.KickOff == Convert.ToDateTime(model.KickOff)
&& a.ProjId == ProjID && a.Sl == SL && a.GroupEnddate == enddate
&& a.Group == groups
                                       select a).ToList();
                    if (custRoleVar.Count > 0)
                    {
                        ExIpcustomerGroup rolemodel = new ExIpcustomerGroup();
                        rolemodel.Sl = custRoleVar[0].Sl;
                        rolemodel.CuIden = custRoleVar[0].CuIden;
                        rolemodel.ProjId = custRoleVar[0].ProjId;
                        rolemodel.PeLogn = custRoleVar[0].PeLogn;
                        rolemodel.Group = model.RoleReasonGroup;
                        rolemodel.KickOff = custRoleVar[0].KickOff;
                        rolemodel.DateOfMove = custRoleVar[0].DateOfMove;
                        rolemodel.GroupStartdt = Convert.ToDateTime(model.newstartdate);
                        rolemodel.GroupEnddate = null;
                        rolemodel.Userlognid = model.Logn;
                        rolemodel.Entrystamp = DateTime.Now;
                        rolemodel.Status = "A";
                        rolemodel.EnddateStamp = null;
                        rolemodel.EnddateUserlognid = null;
                        _repositorycontext.ExIpcustomerGroups.Add(rolemodel);

                    }
                    //mail send logic



                }
                else if (model.ChangeType == "Reason" && model.RoleReasonGroup != reason)
                {
                    //building cc mail to send mail

                }
                else if (reasonList.Contains(reason) && roleReasonGroupList.Contains(model.RoleReasonGroup))
                {
                    ExResourceassignmentTran modelTran = new ExResourceassignmentTran();
                    modelTran.Id = ID;
                    modelTran.Sl = SL;
                    modelTran.Tranid = tranid;
                    modelTran.PeLogn = model.PeLogn;
                    modelTran.CuIden = Convert.ToInt32(model.CuIden);
                    modelTran.ProjId = ProjID;
                    modelTran.KickOff = Convert.ToDateTime(model.KickOff);
                    modelTran.Group = groups;
                    modelTran.Role = role;
                    modelTran.Reason = model.RoleReasonGroup;
                    modelTran.Startdate = Convert.ToDateTime(model.newstartdate);
                    modelTran.ChangeType = model.ChangeType;
                    modelTran.Comments = model.comments;
                    modelTran.Entrystamp = DateTime.Now;
                    modelTran.Userlognid = model.Logn;
                    modelTran.Status = "A";
                    modelTran.Oldvalue = reason;
                    _repositorycontext.ExResourceassignmentTrans.Add(modelTran);

                    var res3 = (from a in _repositorycontext.ExResourceassignmentstatuses
                                where a.PeLogn == model.PeLogn && a.CuIden == Convert.ToInt32(model.CuIden)
                                && a.Tranid == tranid && a.KickOff == Convert.ToDateTime(model.KickOff)
                                && a.Sl == SL && a.Enddate == null
                                select a
                           ).ToList();
                    if (res3.Count > 0)
                    {
                        ExResourceassignmentstatus statusmodel = new ExResourceassignmentstatus();
                        statusmodel.Sl = SL;
                        statusmodel.Tranid = newTranID;
                        statusmodel.PeLogn = model.PeLogn;
                        statusmodel.CuIden = Convert.ToInt32(model.CuIden);
                        statusmodel.ProjId = res3[0].ProjId;
                        statusmodel.Group = res3[0].Group;
                        statusmodel.Role = res3[0].Role;
                        statusmodel.KickOff = res3[0].KickOff;
                        statusmodel.DateOfMove = res3[0].DateOfMove;
                        statusmodel.Startdate = Convert.ToDateTime(model.newstartdate);
                        statusmodel.Enddate = null;
                        statusmodel.BillStart = model.RoleReasonGroup == "NBST5" ? null : Convert.ToDateTime(model.newstartdate);
                        statusmodel.BillEnd = null;
                        statusmodel.Status = model.RoleReasonGroup == "NBST5" ? "S" : res3[0].Status;
                        statusmodel.StatusLevelId = model.RoleReasonGroup == "NBST5" ? 5 : res3[0].StatusLevelId;
                        statusmodel.Entrystamp = DateTime.Now;
                        statusmodel.Userlognid = model.Logn;
                        statusmodel.ApproveStatus = res3[0].ApproveStatus;
                        statusmodel.OffboardStatus = res3[0].OffboardStatus;
                        statusmodel.OffboardStamp = res3[0].OffboardStamp;
                        statusmodel.OffboardUserlognid = res3[0].OffboardUserlognid;
                        statusmodel.Reason = model.RoleReasonGroup;
                        statusmodel.OffboardReason = res3[0].OffboardReason;
                        statusmodel.FinStatus = res3[0].FinStatus;
                        statusmodel.BillpauseStartdate = res3[0].BillpauseStartdate;
                        statusmodel.BillpauseEnddate = res3[0].BillpauseEnddate;
                        _repositorycontext.ExResourceassignmentstatuses.Add(statusmodel);
                    }

                    var update1 = _repositorycontext.ExResourceassignmentstatuses.SingleOrDefault(e => e.Enddate == null && e.PeLogn == model.PeLogn && e.CuIden == Convert.ToInt32(model.CuIden) && e.Tranid == tranid && e.KickOff == Convert.ToDateTime(model.KickOff));
                    update1.Enddate = enddate;
                    update1.BillEnd = reason == "NBST5" ? null : enddate;
                    _repositorycontext.ExResourceassignmentstatuses.Update(update1);

                    var update2 = _repositorycontext.ExIpcustomerReasons.SingleOrDefault(e => e.PeLogn == model.PeLogn && e.CuIden == Convert.ToInt32(model.CuIden) && e.KickOff == Convert.ToDateTime(model.KickOff) && e.ProjId == ProjID && e.Sl == SL && e.EffectiveTo == null && e.Reason == reason);
                    update2.EffectiveTo = enddate;
                    update2.EnddateStamp = DateTime.Now;
                    update2.EnddateUserlognid = model.Logn;
                    update2.Status = "D";
                    _repositorycontext.ExIpcustomerReasons.Update(update2);

                    var custRoleVar = (from a in _repositorycontext.ExIpcustomerReasons
                                       where a.PeLogn == model.PeLogn
                                       && a.CuIden == Convert.ToInt32(model.CuIden) && a.KickOff == Convert.ToDateTime(model.KickOff)
                                       && a.ProjId == ProjID && a.Sl == SL && a.EffectiveTo == enddate
                                       && a.Reason == reason
                                       select a).ToList();
                    if (custRoleVar.Count > 0)
                    {
                        ExIpcustomerReason rolemodel = new ExIpcustomerReason();
                        rolemodel.Sl = custRoleVar[0].Sl;
                        rolemodel.CuIden = custRoleVar[0].CuIden;
                        rolemodel.ProjId = custRoleVar[0].ProjId;
                        rolemodel.PeLogn = custRoleVar[0].PeLogn;
                        rolemodel.Reason = model.RoleReasonGroup;
                        rolemodel.KickOff = custRoleVar[0].KickOff;
                        rolemodel.DateOfMove = custRoleVar[0].DateOfMove;
                        rolemodel.EffectiveFrom = Convert.ToDateTime(model.newstartdate);
                        rolemodel.EffectiveTo = null;
                        rolemodel.Replacewith = null;
                        rolemodel.Comments = model.comments;
                        rolemodel.Userlognid = model.Logn;
                        rolemodel.Entrystamp = DateTime.Now;
                        rolemodel.Status = "A";
                        rolemodel.EnddateStamp = null;
                        rolemodel.EnddateUserlognid = null;

                        _repositorycontext.ExIpcustomerReasons.Add(rolemodel);

                    }
                    //mail send logic

                }
                else if (!reasonList.Contains(reason) && !roleReasonGroupList.Contains(model.RoleReasonGroup))
                {
                    ExResourceassignmentTran modelTran = new ExResourceassignmentTran();
                    modelTran.Id = ID;
                    modelTran.Sl = SL;
                    modelTran.Tranid = tranid;
                    modelTran.PeLogn = model.PeLogn;
                    modelTran.CuIden = Convert.ToInt32(model.CuIden);
                    modelTran.ProjId = ProjID;
                    modelTran.KickOff = Convert.ToDateTime(model.KickOff);
                    modelTran.Group = groups;
                    modelTran.Role = role;
                    modelTran.Reason = model.RoleReasonGroup;
                    modelTran.Startdate = Convert.ToDateTime(model.newstartdate);
                    modelTran.ChangeType = model.ChangeType;
                    modelTran.Comments = model.comments;
                    modelTran.Entrystamp = DateTime.Now;
                    modelTran.Userlognid = model.Logn;
                    modelTran.Status = "A";
                    modelTran.Oldvalue = reason;
                    _repositorycontext.ExResourceassignmentTrans.Add(modelTran);

                    var res3 = (from a in _repositorycontext.ExResourceassignmentstatuses
                                where a.PeLogn == model.PeLogn && a.CuIden == Convert.ToInt32(model.CuIden)
                                && a.Tranid == tranid && a.KickOff == Convert.ToDateTime(model.KickOff)
                                && a.Sl == SL && a.Enddate == null
                                select a
                           ).ToList();
                    if (res3.Count > 0)
                    {
                        ExResourceassignmentstatus statusmodel = new ExResourceassignmentstatus();
                        statusmodel.Sl = SL;
                        statusmodel.Tranid = newTranID;
                        statusmodel.PeLogn = model.PeLogn;
                        statusmodel.CuIden = Convert.ToInt32(model.CuIden);
                        statusmodel.ProjId = res3[0].ProjId;
                        statusmodel.Group = res3[0].Group;
                        statusmodel.Role = res3[0].Role;
                        statusmodel.KickOff = res3[0].KickOff;
                        statusmodel.DateOfMove = res3[0].DateOfMove;
                        statusmodel.Startdate = Convert.ToDateTime(model.newstartdate);
                        statusmodel.Enddate = null;
                        statusmodel.BillStart = null;
                        statusmodel.BillEnd = null;
                        statusmodel.Status = res3[0].Status;
                        statusmodel.StatusLevelId = res3[0].StatusLevelId;
                        statusmodel.Entrystamp = DateTime.Now;
                        statusmodel.Userlognid = model.Logn;
                        statusmodel.ApproveStatus = res3[0].ApproveStatus;
                        statusmodel.OffboardStatus = res3[0].OffboardStatus;
                        statusmodel.OffboardStamp = res3[0].OffboardStamp;
                        statusmodel.OffboardUserlognid = res3[0].OffboardUserlognid;
                        statusmodel.Reason = model.RoleReasonGroup;
                        statusmodel.OffboardReason = res3[0].OffboardReason;
                        statusmodel.FinStatus = res3[0].FinStatus;
                        statusmodel.BillpauseStartdate = res3[0].BillpauseStartdate;
                        statusmodel.BillpauseEnddate = res3[0].BillpauseEnddate;
                        _repositorycontext.ExResourceassignmentstatuses.Add(statusmodel);
                    }

                    var update1 = _repositorycontext.ExResourceassignmentstatuses.SingleOrDefault(e => e.Enddate == null && e.PeLogn == model.PeLogn && e.CuIden == Convert.ToInt32(model.CuIden) && e.Tranid == tranid && e.KickOff == Convert.ToDateTime(model.KickOff));
                    update1.Enddate = enddate;
                    //update1.BillEnd = reason == "NBST5" ? null : enddate;
                    _repositorycontext.ExResourceassignmentstatuses.Update(update1);

                    var update2 = _repositorycontext.ExIpcustomerReasons.SingleOrDefault(e => e.PeLogn == model.PeLogn && e.CuIden == Convert.ToInt32(model.CuIden) && e.KickOff == Convert.ToDateTime(model.KickOff) && e.ProjId == ProjID && e.Sl == SL && e.EffectiveTo == null && e.Reason == reason);
                    update2.EffectiveTo = enddate;
                    update2.EnddateStamp = DateTime.Now;
                    update2.EnddateUserlognid = model.Logn;
                    update2.Status = "D";
                    _repositorycontext.ExIpcustomerReasons.Update(update2);

                    var custRoleVar = (from a in _repositorycontext.ExIpcustomerReasons
                                       where a.PeLogn == model.PeLogn
                                       && a.CuIden == Convert.ToInt32(model.CuIden) &&
                                       a.KickOff == Convert.ToDateTime(model.KickOff)
                                       && a.ProjId == ProjID && a.Sl == SL && a.EffectiveTo == enddate
                                       && a.Reason == reason
                                       select a).ToList();
                    string repWith = string.Empty;
                    var ipPeople = (from a in _edmdbcontext.IpPeople where a.PeLogn == model.replaceWith select a).ToList();
                    if (ipPeople.Count > 0)
                    {
                        repWith = ipPeople[0].PeName.ToUpper();

                    }
                    if (custRoleVar.Count > 0)
                    {
                        ExIpcustomerReason rolemodel = new ExIpcustomerReason();
                        rolemodel.Sl = custRoleVar[0].Sl;
                        rolemodel.CuIden = custRoleVar[0].CuIden;
                        rolemodel.ProjId = custRoleVar[0].ProjId;
                        rolemodel.PeLogn = custRoleVar[0].PeLogn;
                        rolemodel.Reason = model.RoleReasonGroup;
                        rolemodel.KickOff = custRoleVar[0].KickOff;
                        rolemodel.DateOfMove = custRoleVar[0].DateOfMove;
                        rolemodel.EffectiveFrom = Convert.ToDateTime(model.newstartdate);
                        rolemodel.EffectiveTo = null;
                        rolemodel.Replacewith = model.RoleReasonGroup == "NBST1" ? repWith : "";
                        rolemodel.Comments = model.comments;
                        rolemodel.Userlognid = model.Logn;
                        rolemodel.Entrystamp = DateTime.Now;
                        rolemodel.Status = "A";
                        rolemodel.EnddateStamp = null;
                        rolemodel.EnddateUserlognid = null;

                        _repositorycontext.ExIpcustomerReasons.Add(rolemodel);

                    }
                    //mail send logic

                }
                //check from here
                else if (!reasonList.Contains(reason) && roleReasonGroupList.Contains(model.RoleReasonGroup))
                {
                    ExIpcustomerConversion modelTran = new ExIpcustomerConversion();

                    modelTran.Sl = SL;
                    modelTran.PeLogn = model.PeLogn;
                    modelTran.CuIden = Convert.ToInt32(model.CuIden);
                    modelTran.ProjId = ProjID;
                    modelTran.KickOff = Convert.ToDateTime(model.KickOff);
                    modelTran.Group = groups;
                    modelTran.Role = role;
                    modelTran.Reason = model.RoleReasonGroup;
                    modelTran.Startdate = Convert.ToDateTime(model.newstartdate);
                    modelTran.BillEnd = null;
                    modelTran.BillStart = Convert.ToDateTime(model.newstartdate);
                    modelTran.Enddate = null;
                    modelTran.CurrentReason = reason;
                    modelTran.RepLogn = null;
                    modelTran.Entrystamp = DateTime.Now;
                    modelTran.Userlognid = model.Logn;
                    modelTran.FinStatus = "P";

                    _repositorycontext.ExIpcustomerConversions.Add(modelTran);




                    //mail send logic

                }
                else if (reasonList.Contains(reason) && !roleReasonGroupList.Contains(model.RoleReasonGroup))
                {
                    ExIpcustomerConversion modelTran = new ExIpcustomerConversion();

                    modelTran.Sl = SL;
                    modelTran.PeLogn = model.PeLogn;
                    modelTran.CuIden = Convert.ToInt32(model.CuIden);
                    modelTran.ProjId = ProjID;
                    modelTran.KickOff = Convert.ToDateTime(model.KickOff);
                    modelTran.Group = groups;
                    modelTran.Role = role;
                    modelTran.Reason = model.RoleReasonGroup;
                    modelTran.Startdate = Convert.ToDateTime(model.newstartdate);
                    modelTran.BillEnd = null;
                    modelTran.BillStart = Convert.ToDateTime(model.newstartdate);
                    modelTran.Enddate = null;
                    modelTran.CurrentReason = reason;
                    modelTran.RepLogn = model.RoleReasonGroup == "NBST1" ? model.replaceWith : null;
                    modelTran.Entrystamp = DateTime.Now;
                    modelTran.Userlognid = model.Logn;
                    modelTran.FinStatus = "P";

                    _repositorycontext.ExIpcustomerConversions.Add(modelTran); 

                    //mail send logic

                }



                response.Status = true;
                response.Message = "Success";
                response.Error = "";
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

        [HttpPost("BillPercentageUpdate")]
        public IActionResult BillPercentageUpdate(BillPercenateUpdate model)
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
                    if (LockDate >= Convert.ToDateTime(model.NewStart))
                    {
                        kickmodel.nstatus = "Billing Start Date cannot less than or equal to lock date " + LockDate.ToString("yyyy-MM-dd");
                    }
                    else
                    {


                        int ID = 0;
                        int SL = 0;
                        int TranID = 0;
                        int ProjID = 0;
                        DateTime KickOff = DateTime.Now;
                        DateTime OldStart = DateTime.Now;
                        decimal? OldBillPercent = 0;
                        DateTime EntryStamp = DateTime.Now;
                        string Group = "";
                        int Maxid = 0;



                        var finddata = (from p in _repositorycontext.ExResourceassignmentstatuses
                                        where p.CuIden == model.CuIden && p.PeLogn == model.PeLogn && p.Enddate == null
                                        select new
                                        {
                                            SL = p.Sl,
                                            TranID = p.Tranid,
                                            KickOff = p.KickOff,
                                            ProjID = p.ProjId,
                                            Group = p.Group
                                        }).Distinct().ToList();

                        if (finddata.Count > 0)
                        {
                            SL = Convert.ToInt16(finddata[0].SL);
                            TranID = Convert.ToInt16(finddata[0].TranID);
                            KickOff = Convert.ToDateTime(finddata[0].KickOff);
                            ProjID = Convert.ToInt16(finddata[0].ProjID);
                            Group = finddata[0].Group;
                        }

                        var finddata1 = (from p in _repositorycontext.ExResourcebillpercents
                                         where p.CuIden == model.CuIden && p.PeLogn == model.PeLogn && p.BillpercentEnddt == null && p.KickOff == KickOff 
                                         select new
                                         {
                                             Billpercent = p.Billpercent,
                                             BillpercentStartdt = p.BillpercentStartdt
                                         }).Distinct().ToList();

                        if (finddata1.Count > 0)
                        {
                            OldBillPercent = finddata1[0].Billpercent;
                            OldStart = finddata1[0].BillpercentStartdt;
                        }

                        if(OldStart >= model.NewStart)
                        {
                            kickmodel.nstatus = "Billing Start Date cannot less than or equal to current billing start date " + OldStart.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            decimal?billingsum = 0;
                            var Billing = (from p in _repositorycontext.ExResourcebillpercents
                                           where p.PeLogn == model.PeLogn && p.BillpercentStartdt <= Convert.ToDateTime(model.NewStart) &&
                                (p.BillpercentEnddt == null || p.BillpercentEnddt >= Convert.ToDateTime(model.NewStart)) && p.CuIden != model.CuIden
                                              select new
                                              {
                                                  p.Billpercent

                                              }).ToList();

                            if (Billing.Count > 0)
                            {
                                billingsum = Billing.Sum(t => t.Billpercent);
                            }

                            billingsum = 100 - billingsum;

                            if (billingsum < Convert.ToDecimal(model.NewBillPercent))
                            {
                                kickmodel.nstatus = "Giving Billing Percentage cannot be greater than or equal to remaining Billing percentage " + billingsum;
                            }
                            else
                            {
                                DateTime Billingenddate = DateTime.Now;
                                Billingenddate = model.NewStart.AddDays(-1);

                                ExResourcebillpercent exresourcebillpercent = _repositorycontext.ExResourcebillpercents.Where(x => x.PeLogn == model.PeLogn
                             && x.BillpercentEnddt == null && x.CuIden == Convert.ToInt16(model.CuIden)).FirstOrDefault();
                                exresourcebillpercent.BillpercentEnddt = Billingenddate;
                                exresourcebillpercent.Status = "D";
                                exresourcebillpercent.EnddateStamp = DateTime.Now;
                                exresourcebillpercent.EnddateUserlognid = model.UserLognID;
                                exresourcebillpercent.DateOfMove = Billingenddate;
                                _repositorycontext.ExResourcebillpercents.Update(exresourcebillpercent);
                                //_repositorycontext.SaveChanges();

                                ExResourcebillpercent statusobj =new ExResourcebillpercent();
                                statusobj.Sl = SL;
                                statusobj.CuIden = model.CuIden;
                                statusobj.PeLogn = model.PeLogn;
                                statusobj.ProjId = 0;
                                statusobj.KickOff = KickOff;
                                statusobj.DateOfMove = null;
                                statusobj.BillpercentStartdt = model.NewStart;
                                statusobj.BillpercentEnddt = null;
                                statusobj.Billpercent = model.NewBillPercent;
                                statusobj.Userlognid =model.UserLognID;
                                statusobj.Entrystamp = DateTime.Now;
                                statusobj.Status = "A";
                                statusobj.FinStatus = "A";
                                _repositorycontext.ExResourcebillpercents.Add(statusobj);

                                _repositorycontext.SaveChanges();

                                kickmodel.nstatus = "Update Sucessfully";
                            }

                        }
                        //var finddata2 = (from p in _repositorycontext.ExResourceassignmentTrans
                        //                 where p.CuIden == model.CuIden && p.PeLogn == model.PeLogn  && p.KickOff == KickOff && p.Sl == SL
                        //                 select new
                        //                 {
                        //                     MaxID = p.Tranid, 
                        //                 }).Max(p => p.Tranid)

                        //if (finddata2.Count > 0)
                        //{
                        //    OldBillPercent = finddata1[0].Billpercent;
                        //    OldStart = finddata1[0].BillpercentStartdt;
                        //}
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

        [HttpGet("ChangesGrpRoleReasonPersonClientGroup")]
        public IActionResult ChangesGrpRoleReasonPersonClientGroup(Resource model)
        {
            Response response = new Response();
            try
            {
                string LognType = string.Empty;
                Core core = new(_repositorycontext, _edmdbcontext);
                LognType = core.uFn_LoginCheck(model.Logn);
                var serList = (from a in _repositorycontext.ExClientServicelines where a.CuIden == Convert.ToInt32(model.CuIden) && a.Enddate == null && a.Status == "A" select new { ServiceLine = a.ServiceLine }).ToList();
                string[] serviceLineList = new string[serList.Count];
                if (serList.Count > 0)
                {
                    for (int i = 0; i < serList.Count; i++)
                    {
                        serviceLineList[i] = serList[i].ServiceLine;
                    }
                }
                var ipelement = (from a in _edmdbcontext.IpElements select a).ToList();
                List<Groups> grp0 = (from a in _repositorycontext.MasterAbbrevations.ToList()
                                     join
b in ipelement on a.Code equals b.ElCode into se
                                     from b in se.DefaultIfEmpty()
                                     where (b != null) ? b.ElName != null : false && serviceLineList.Contains(a.Lob)
                                     select new Groups
                                     {
                                         Group = a.Code
                                     }
                                   ).ToList();
                grp0 = grp0.Where(e => e.Group != "BD" || e.Group != "FIBD").ToList();
                List<PersonGroup> pg0 = (from a in _repositorycontext.ExResourceassignmentstatuses
                                         where a.PeLogn == model.PeLogn && a.CuIden == Convert.ToInt32(model.CuIden)
                                         && a.ProjId == Convert.ToInt32(model.ProjID) && a.Enddate == null
                                         select new PersonGroup
                                         {
                                             Group = a.Group
                                         }

                                       ).Distinct().ToList();
                string[] grpLists = new string[pg0.Count];
                if (pg0.Count > 0)
                {
                    for (int i = 0; i < pg0.Count; i++)
                    {
                        grpLists[i] = pg0[i].Group;
                    }
                }
                grp0 = grp0.Where(e => !grpLists.Contains(e.Group)).ToList();
                string[] cacodeList = { "SUPP", "SSSER" };
                var ipelementcode = (from a in _edmdbcontext.IpElements
                                     where cacodeList.Contains(a.CaCode)
                                     select a
                                   ).ToList();
                string[] elcodelist = new string[ipelementcode.Count];
                if (ipelementcode.Count > 0)
                {
                    for (int i = 0; i < ipelementcode.Count; i++)
                    {
                        elcodelist[i] = ipelementcode[i].ElCode;
                    }
                }
                pg0 = pg0.Where(e => elcodelist.Contains(e.Group)).ToList();
                if (pg0.Count > 0)
                {
                    string[] cacodeslist = { "SUPP", "SSSER" };
                    string[] grpLis = new string[grp0.Count];
                    if (grp0.Count > 0)
                    {
                        for (int i = 0; i < grp0.Count; i++)
                        {
                            grpLis[i] = grp0[i].Group;
                        }
                    }
                    List<Groups> grp1 = (from a in _edmdbcontext.IpElements
                                         where cacodeslist.Contains(a.CaCode)
   && !grpLis.Contains(a.ElCode)
                                         select new Groups
                                         {
                                             Group = a.ElCode
                                         }
                                       ).ToList();
                    grp0.AddRange(grp1);
                }


                string[] LognTypeList = { "TDA", "ADMIN", "TRAJAN" };
                if (LognTypeList.Contains(LognType))
                {
                    var data = (from E1 in _edmdbcontext.IpElements.ToList()
                                join
b in grp0 on E1.ElCode equals b.Group
                                orderby b.Group
                                select new
                                {
                                    GroupCode = b.Group,
                                    Group = E1.ElName.ToUpper()

                                }
                              ).ToList();
                    response.Data = data;
                }
                else if (LognType == "QNTS")
                {
                    var code = (from a in _repositorycontext.MasterAbbrevations
                                where a.Abbr == "RPT" && a.Groupping == "QNTSS" && a.Status == "A"
                                select a
                             ).ToList();
                    string[] grpList = new string[code.Count];
                    if (code.Count > 0)
                    {
                        for (int i = 0; i < code.Count; i++)
                        {
                            grpList[i] = code[i].Code;
                        }
                    }
                    var data = (from E1 in _edmdbcontext.IpElements.ToList()
                                join
b in grp0 on E1.ElCode equals b.Group
                                where grpList.Contains(b.Group)
                                orderby b.Group
                                select new
                                {
                                    GroupCode = b.Group,
                                    Group = E1.ElName.ToUpper()

                                }
                             ).ToList();
                    response.Data = data;
                }
                else if (LognType == "CDH" || LognType == "EMGR")
                {
                    var pe_de = (from a in _edmdbcontext.IpPeople where a.PeLogn == model.Logn select a).ToList();
                    string[] deptList = new string[pe_de.Count];
                    if (pe_de.Count > 0)
                    {
                        for (int i = 0; i < pe_de.Count; i++)
                        {
                            deptList[i] = pe_de[i].PeDept;
                        }
                    }
                    var codevar = (from a in _repositorycontext.MasterAbbrevations where deptList.Contains(a.Lob) select a).ToList();

                    string[] codelist = new string[codevar.Count];
                    if (codevar.Count > 0)
                    {
                        for (int i = 0; i < codevar.Count; i++)
                        {
                            codelist[i] = codevar[i].Code;
                        }
                    }
                    var data = (from El in _edmdbcontext.IpElements
                                join
b in grp0 on El.ElCode equals b.Group
                                where codelist.Contains(b.Group)
                                orderby b.Group
                                select new
                                {
                                    GroupCode = b.Group,
                                    Group = El.ElName.ToUpper()

                                }
                              ).ToList();
                    response.Data = data;

                }
                else if (LognType == "PMO")
                {
                    var data = (from E1 in _edmdbcontext.IpElements.ToList()
                                join
b in grp0 on E1.ElCode equals b.Group
                                orderby b.Group
                                select new
                                {
                                    GroupCode = b.Group,
                                    Group = E1.ElName.ToUpper()

                                }
                              ).ToList();
                    response.Data = data;

                }
                else if (LognType == "DM" || LognType == "VP")
                {
                    var grpDisLists = (from a in _repositorycontext.ExResourceassignmentstatuses
                                       where a.PeLogn == model.Logn && a.Enddate == null
                                       && a.CuIden == Convert.ToInt32(model.CuIden)
                                       && a.ProjId == Convert.ToInt32(model.ProjID)
                                       select a
                                     ).Distinct().ToList();
                    string[] grp_lst = new string[grpDisLists.Count];
                    if (grpDisLists.Count > 0)
                    {
                        for (int i = 0; i < grpDisLists.Count; i++)
                        {
                            grp_lst[i] = grpDisLists[i].Group;
                        }
                    }
                    var data = (from E1 in _edmdbcontext.IpElements.ToList()
                                join
b in grp0 on E1.ElCode equals b.Group
                                where grp_lst.Contains(b.Group)
                                orderby b.Group
                                select new
                                {
                                    GroupCode = b.Group,
                                    Group = E1.ElName.ToUpper()

                                }
                              ).ToList();
                    response.Data = data;

                } 


                response.Status = true;
                response.Message = "Success";
                response.Error = "";
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

        [HttpGet("ReasonChangeReasonMaster/{pelogn}/{cuiden}")]
        public IActionResult ReasonChangeReasonMaster(string pelogn, int cuiden)
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

                    var finddata = (from p in _repositorycontext.ExIpcustomerReasons
                                    where p.PeLogn == pelogn && p.EffectiveTo==null && p.CuIden == cuiden
                                    select new
                                    {
                                        Reason = p.Reason 

                                    }).Distinct().ToList();

                    if (finddata.Count > 0)
                    {
                        Reason = finddata[0].Reason; 
                    }

                    if (Reason.ToUpper() == "NBST5" || Reason.ToUpper() == "BNA" || Reason.ToUpper() == "BILLING")
                    {
                        var data = (from p in _repositorycontext.ExStatusdescs
                                    where (p.Type=="P" || p.Type == "B") && p.OnOff== 0 && p.Status =="A" && (p.Level== "NBST1" || p.Level == "NBST2" || p.Level == "AB"|| p.Level == "NBA") 
                                    select new
                                    {
                                        value = p.Level,
                                        label = p.StatusShortDesc
                                    }).ToList();

                        dList.Add("Table", data);
                    }
                    else if(Reason.ToUpper() == "BNA")
                    {
                        var data = (from p in _repositorycontext.ExStatusdescs
                                    where (p.Type == "P" || p.Type == "B") && p.OnOff == 0 && p.Status == "A" && p.Level == "NBST5" 
                                    select new
                                    {
                                        value = p.Level,
                                        label = p.StatusShortDesc
                                    }).ToList();

                        dList.Add("Table", data); 
                    }

                    else 
                    {
                        var data = (from p in _repositorycontext.ExStatusdescs
                                    where p.Level !=Reason && p.Level!= "BP" && p.Level != "BR" && p.Level != "NPNJ" && p.Level != "NPIT" && p.Level != "NBST6"
                                    select new
                                    {
                                        value = p.Level,
                                        label = p.StatusShortDesc
                                    }).ToList();

                        dList.Add("Table", data);
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

        [HttpPost("AllocationUpdate")]
        public IActionResult AllocationUpdate(AllocationUpdate model)
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
                    if (LockDate >= Convert.ToDateTime(model.NewStart))
                    {
                        kickmodel.nstatus = "Allocation Start Date cannot less than or equal to lock date " + LockDate.ToString("yyyy-MM-dd");
                    }
                    else
                    {


                        int ID = 0;
                        int SL = 0;
                        int TranID = 0;
                        int ProjID = 0;
                        DateTime KickOff = DateTime.Now;
                        DateTime OldStart = DateTime.Now;
                        decimal? OldAllocation = 0;
                        DateTime EntryStamp = DateTime.Now;
                        string Group = "";
                        int Maxid = 0;



                        var finddata = (from p in _repositorycontext.ExResourceassignmentstatuses
                                        where p.CuIden == model.CuIden && p.PeLogn == model.PeLogn && p.Enddate == null
                                        select new
                                        {
                                            SL = p.Sl,
                                            TranID = p.Tranid,
                                            KickOff = p.KickOff,
                                            ProjID = p.ProjId,
                                            Group = p.Group
                                        }).Distinct().ToList();

                        if (finddata.Count > 0)
                        {
                            SL = Convert.ToInt16(finddata[0].SL);
                            TranID = Convert.ToInt16(finddata[0].TranID);
                            KickOff = Convert.ToDateTime(finddata[0].KickOff);
                            ProjID = Convert.ToInt16(finddata[0].ProjID);
                            Group = finddata[0].Group;
                        }

                        var finddata1 = (from p in _repositorycontext.ExResourceallocations
                                         where p.CuIden == model.CuIden && p.PeLogn == model.PeLogn && p.AllocEnddate == null && p.KickOff == KickOff
                                         select new
                                         {
                                             Allocation = p.Allocation,
                                             AllocStartdt = p.AllocStartdt
                                         }).Distinct().ToList();

                        if (finddata1.Count > 0)
                        {
                            OldAllocation = finddata1[0].Allocation;
                            OldStart = finddata1[0].AllocStartdt;
                        }

                        if (OldStart >= model.NewStart)
                        {
                            kickmodel.nstatus = "Allocation Start Date cannot less than or equal to current Allocation start date " + OldStart.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            decimal? allocationsum = 0;
                            var Allocation = (from p in _repositorycontext.ExResourceallocations
                                           where p.PeLogn == model.PeLogn && p.AllocStartdt <= Convert.ToDateTime(model.NewStart) &&
                                (p.AllocEnddate == null || p.AllocEnddate >= Convert.ToDateTime(model.NewStart)) && p.CuIden != model.CuIden
                                           select new
                                           {
                                               p.Allocation

                                           }).ToList();

                            if (Allocation.Count > 0)
                            {
                                allocationsum = Allocation.Sum(t => t.Allocation);
                            }

                            allocationsum = 100 - allocationsum;

                            if (allocationsum < Convert.ToDecimal(model.NewAllocation))
                            {
                                kickmodel.nstatus = "Giving Allocation cannot be greater than or equal to remaining Allocation " + allocationsum;
                            }
                            else
                            {
                                DateTime Allocationenddate = DateTime.Now;
                                Allocationenddate = model.NewStart.AddDays(-1);

                                ExResourceallocation exResourceallocation = _repositorycontext.ExResourceallocations.Where(x => x.PeLogn == model.PeLogn
                             && x.AllocEnddate == null && x.CuIden == Convert.ToInt16(model.CuIden)).FirstOrDefault();
                                exResourceallocation.AllocEnddate = Allocationenddate;
                                exResourceallocation.Status = "D";
                                exResourceallocation.EnddateStamp = DateTime.Now;
                                exResourceallocation.EnddateUserlognid = model.UserLognID;
                                exResourceallocation.DateOfMove = Allocationenddate;
                                _repositorycontext.ExResourceallocations.Update(exResourceallocation);
                                //_repositorycontext.SaveChanges();

                                ExResourceallocation statusobj = new ExResourceallocation();
                                statusobj.Sl = SL;
                                statusobj.CuIden = model.CuIden;
                                statusobj.PeLogn = model.PeLogn;
                                statusobj.ProjId = 0;
                                statusobj.KickOff = KickOff;
                                statusobj.DateOfMove = null;
                                statusobj.AllocStartdt = model.NewStart;
                                statusobj.AllocEnddate = null;
                                statusobj.Allocation = model.NewAllocation;
                                statusobj.Userlognid = model.UserLognID;
                                statusobj.Entrystamp = DateTime.Now;
                                statusobj.Status = "A"; 
                                _repositorycontext.ExResourceallocations.Add(statusobj);

                                _repositorycontext.SaveChanges();

                                kickmodel.nstatus = "Update Sucessfully";
                            }

                        }
                        //var finddata2 = (from p in _repositorycontext.ExResourceassignmentTrans
                        //                 where p.CuIden == model.CuIden && p.PeLogn == model.PeLogn  && p.KickOff == KickOff && p.Sl == SL
                        //                 select new
                        //                 {
                        //                     MaxID = p.Tranid, 
                        //                 }).Max(p => p.Tranid)

                        //if (finddata2.Count > 0)
                        //{
                        //    OldBillPercent = finddata1[0].Billpercent;
                        //    OldStart = finddata1[0].BillpercentStartdt;
                        //}
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

        [HttpGet("GetAllocationandBillingRecord/{pelogn}/{cuiden}")]
        public IActionResult GetAllocationandBillingRecord(string pelogn, int cuiden)
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
                    var resourceassignemntstatus = (from El in _repositorycontext.ExResourceassignmentstatuses select El).ToList();
                    var ExResourceallocations = (from El in _repositorycontext.ExResourceallocations   select El).ToList();
                    var ExResourcebillpercents = (from El in _repositorycontext.ExResourcebillpercents   select El).ToList(); 
                    var IpCustomers = (from El in _repositorycontext.IpCustomers   select El).ToList(); 

                    var IpElements = (from El in _edmdbcontext.IpElements select El).ToList();
                    var IpCategories = (from El in _edmdbcontext.IpCategories select El).ToList();
                    var ExStatusdescs = (from El in _repositorycontext.ExStatusdescs select El).ToList();
                    var IpPeople = (from El in _edmdbcontext.IpPeople select El).ToList();
                    var ExIppeople = (from El in _edmdbcontext.ExIppeople select El).ToList();


                    var AllocationHistory = (from p in ExResourceallocations 
                                             join b in IpPeople on p.PeLogn equals b.PeLogn into sc2
                                             from b in sc2.DefaultIfEmpty()
                                             join c in ExIppeople on p.PeLogn equals c.PeLogn into sc3
                                             from c in sc3.DefaultIfEmpty()  
                                             join d in IpCustomers on p.CuIden equals d.CuIden into sc4
                                             from d in sc4.DefaultIfEmpty() 
                                             where p.PeLogn == pelogn && p.CuIden == cuiden 
                                             orderby p.AllocStartdt
                                           
                                     select new
                                     {
                                         Allocation = p != null? p.Allocation :0, 
                                         AllocStartdt = p != null ? p.AllocStartdt.ToString("yyyy-MM-dd") : "NA",
                                         AllocEnddate = p.AllocEnddate !=null ? p.AllocEnddate.Value.ToString("yyyy-MM-dd") : " ",
                                          Name = b!=null ? b.PeName +" ("+c.WwPersonId +")" :"",
                                          ClientName = d.CuComp
                                     }).ToList();

                    var BillingHistory = (from p in ExResourcebillpercents
                                          join b in IpPeople on p.PeLogn equals b.PeLogn into sc2
                                             from b in sc2.DefaultIfEmpty()
                                             join c in ExIppeople on p.PeLogn equals c.PeLogn into sc3
                                             from c in sc3.DefaultIfEmpty()
                                             join d in IpCustomers on p.CuIden equals d.CuIden into sc4
                                             from d in sc4.DefaultIfEmpty()
                                             where p.PeLogn == pelogn && p.CuIden == cuiden
                                             orderby p.BillpercentStartdt

                                             select new
                                             {
                                                 Allocation = p != null ? p.Billpercent : 0,
                                                 AllocStartdt = p != null ? p.BillpercentStartdt.ToString("yyyy-MM-dd") : "NA",
                                                 AllocEnddate = p.BillpercentEnddt != null ? p.BillpercentEnddt.Value.ToString("yyyy-MM-dd") : " ",
                                                 Name = b != null ?  b.PeName + " (" + c.WwPersonId + ")" :"",
                                                 ClientName = d.CuComp
                                             }).ToList();

                    decimal? allocationsum = 0;
                    decimal? billingsum = 0;

                    var allocation = (from pp in _repositorycontext.ExResourceallocations
                                  where pp.AllocEnddate == null && pp.CuIden != cuiden && pp.PeLogn==pelogn
                                  group pp by pp.PeLogn into group2
                                  select new
                                  {
                                      Pelogn = group2.Key,
                                      Allocation = group2.Sum(c => c.Allocation)
                                  }).ToList();

                    var billing = (from pp in _repositorycontext.ExResourcebillpercents
                                      where pp.BillpercentEnddt == null && pp.CuIden != cuiden && pp.PeLogn == pelogn
                                   group pp by pp.PeLogn into group2
                                      select new
                                      {
                                          Pelogn = group2.Key,
                                          Billing = group2.Sum(c => c.Billpercent)
                                      }).ToList();

                    var AllocationCurrent = (from p in ExResourceallocations
                                             join b in IpPeople on p.PeLogn equals b.PeLogn into sc2
                                             from b in sc2.DefaultIfEmpty()
                                             join c in ExIppeople on p.PeLogn equals c.PeLogn into sc3
                                             from c in sc3.DefaultIfEmpty()
                                             join d in IpCustomers on p.CuIden equals d.CuIden into sc4
                                             from d in sc4.DefaultIfEmpty()
                                             where p.PeLogn == pelogn && p.CuIden != cuiden && p.AllocEnddate ==null
                                             orderby p.AllocStartdt

                                             select new
                                             {
                                                 Allocation = p != null ? p.Allocation : 0,
                                                 AllocStartdt = p != null ? p.AllocStartdt.ToString("yyyy-MM-dd") : "NA",
                                                 AllocEnddate = p.AllocEnddate != null ? p.AllocEnddate.Value.ToString("yyyy-MM-dd") : " ",
                                                 Name = b!=null ? b.PeName + " (" + c.WwPersonId + ")" :"",
                                                 ClientName = d.CuComp
                                             }).ToList();

                    var BillingCurrent = (from p in ExResourcebillpercents
                                          join b in IpPeople on p.PeLogn equals b.PeLogn into sc2
                                          from b in sc2.DefaultIfEmpty()
                                          join c in ExIppeople on p.PeLogn equals c.PeLogn into sc3
                                          from c in sc3.DefaultIfEmpty()
                                          join d in IpCustomers on p.CuIden equals d.CuIden into sc4
                                          from d in sc4.DefaultIfEmpty()
                                          where p.PeLogn == pelogn && p.CuIden != cuiden && p.BillpercentEnddt==null
                                          orderby p.BillpercentStartdt

                                          select new
                                          {
                                              Allocation = p != null ? p.Billpercent : 0,
                                              AllocStartdt = p != null ? p.BillpercentStartdt.ToString("yyyy-MM-dd") : "NA",
                                              AllocEnddate = p.BillpercentEnddt != null ? p.BillpercentEnddt.Value.ToString("yyyy-MM-dd") : " ",
                                              Name = b!=null ?  b.PeName + " (" + c.WwPersonId + ")" :"",
                                              ClientName = d.CuComp
                                          }).ToList();

                    dList.Add("AllocationHistory", AllocationHistory);
                    dList.Add("BillingHistory", BillingHistory);
                    dList.Add("allocation", allocation);
                    dList.Add("billing", billing);
                    dList.Add("AllocationCurrent", AllocationCurrent);
                    dList.Add("BillingCurrent", BillingCurrent);

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

        [HttpPost("GroupUpdate")]
        public IActionResult GroupUpdate(GroupUpdate model)
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
                    if (LockDate >= Convert.ToDateTime(model.NewStartDate))
                    {
                        kickmodel.nstatus = "Group Start Date cannot less than or equal to lock date " + LockDate.ToString("yyyy-MM-dd");
                    }
                    else
                    {


                        int ID = 0;
                        int SL = 0;
                        int TranID = 0;
                        int ProjID = 0;
                        DateTime KickOff = DateTime.Now;
                        DateTime OldStart = DateTime.Now;
                        decimal? OldAllocation = 0;
                        DateTime EntryStamp = DateTime.Now;
                        string Group = "";
                        int Maxid = 0;

                        string Role = "";
                        DateTime BillStart = DateTime.Now;
                        string Status = "";
                        int StatusLevelId = 0;
                        string ApproveStatus = "";
                        string Reason = "";
                        string FinStatus = ""; 

                        var finddata = (from p in _repositorycontext.ExResourceassignmentstatuses
                                        where p.CuIden == model.CuIden && p.PeLogn == model.PeLogn && p.Enddate == null && p.ApproveStatus=="A"
                                        select new
                                        {
                                            SL = p.Sl,
                                            TranID = p.Tranid,
                                            KickOff = p.KickOff,
                                            ProjID = p.ProjId,
                                            //Group = p.Group,
                                            Role =p.Role,
                                            BillStart= p.BillStart,
                                            Status=  p.Status,
                                            StatusLevelId =p.StatusLevelId,
                                            ApproveStatus =p.ApproveStatus,
                                            Reason = p.Reason,
                                            FinStatus =p.FinStatus  
                                        }).Distinct().ToList();

                        if (finddata.Count > 0)
                        {
                            SL = Convert.ToInt16(finddata[0].SL);
                            TranID = Convert.ToInt16(finddata[0].TranID);
                            KickOff = Convert.ToDateTime(finddata[0].KickOff);
                            ProjID = Convert.ToInt16(finddata[0].ProjID);
                            //Group = finddata[0].Group;
                            Role = finddata[0].Role;
                            BillStart = Convert.ToDateTime(finddata[0].BillStart);
                            Status = finddata[0].Status;
                            StatusLevelId = Convert.ToInt16(finddata[0].StatusLevelId);
                            ApproveStatus = finddata[0].ApproveStatus;
                            Reason = finddata[0].Reason;
                            FinStatus = finddata[0].FinStatus;
                        }

                        var finddata1 = (from p in _repositorycontext.ExIpcustomerGroups
                                         where p.CuIden == model.CuIden && p.PeLogn == model.PeLogn && p.GroupEnddate == null && p.KickOff == KickOff
                                         select new
                                         {
                                             GroupStartdt = p.GroupStartdt
                                         }).Distinct().ToList();

                        if (finddata1.Count > 0)
                        { 
                            OldStart = finddata1[0].GroupStartdt;
                        }

                        if (OldStart >= model.NewStartDate)
                        {
                            kickmodel.nstatus = "Group Start Date cannot less than or equal to current Group start date " + OldStart.ToString("yyyy-MM-dd");
                        }
                        else
                        { 
                                DateTime Groupenddate = DateTime.Now;
                            Groupenddate = model.NewStartDate.AddDays(-1);

                                ExIpcustomerGroup exIpcustomerGroup = _repositorycontext.ExIpcustomerGroups.Where(x => x.PeLogn == model.PeLogn
                             && x.GroupEnddate == null && x.CuIden == Convert.ToInt16(model.CuIden)).FirstOrDefault();
                            //exIpcustomerGroup.DateOfMove = Groupenddate;
                            exIpcustomerGroup.GroupEnddate = Groupenddate;
                            exIpcustomerGroup.Status = "D";
                            exIpcustomerGroup.EnddateStamp = DateTime.Now;
                            exIpcustomerGroup.EnddateUserlognid = model.UserLognID; 
                                _repositorycontext.ExIpcustomerGroups.Update(exIpcustomerGroup);
                            //_repositorycontext.SaveChanges();

                            ExIpcustomerGroup statusobj = new ExIpcustomerGroup();
                                statusobj.Sl = SL;
                                statusobj.CuIden = model.CuIden;
                                statusobj.ProjId = 0; 
                                statusobj.PeLogn = model.PeLogn;
                            statusobj.Group = model.Group; 
                                statusobj.KickOff = KickOff;
                                statusobj.DateOfMove = null;
                                statusobj.GroupStartdt = model.NewStartDate;
                                statusobj.GroupEnddate = null;
                            statusobj.Status = "A";
                            statusobj.Userlognid = model.UserLognID;
                                statusobj.Entrystamp = DateTime.Now; 
                                _repositorycontext.ExIpcustomerGroups.Add(statusobj);


                            ExResourceassignmentstatus exResourceassignmentstatus = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.PeLogn == model.PeLogn
                           && x.Enddate==null && x.CuIden == Convert.ToInt16(model.CuIden) && x.ApproveStatus=="A").FirstOrDefault();
                            exResourceassignmentstatus.Enddate = Groupenddate;  
                            _repositorycontext.ExResourceassignmentstatuses.Update(exResourceassignmentstatus);


                            TranID = TranID + 1;

                            ExResourceassignmentstatus exResourceassignmentstatus1 = new ExResourceassignmentstatus();
                           exResourceassignmentstatus1.Sl = SL;
                           exResourceassignmentstatus1.PeLogn = model.PeLogn;
                           exResourceassignmentstatus1.CuIden = Convert.ToInt32(model.CuIden);
                            exResourceassignmentstatus1.ProjId = ProjID;
                           exResourceassignmentstatus1.Group = model.Group;
                           exResourceassignmentstatus1.Role = Role;
                           exResourceassignmentstatus1.KickOff = KickOff;
                           exResourceassignmentstatus1.BillStart = BillStart.ToString() == "1/1/0001 12:00:00 AM" ? null : BillStart;
                           exResourceassignmentstatus1.DateOfMove = null;
                           exResourceassignmentstatus1.Startdate = model.NewStartDate;
                           exResourceassignmentstatus1.Enddate = null;//hard coded from below line
                           exResourceassignmentstatus1.Status = Status ;
                           exResourceassignmentstatus1.StatusLevelId = StatusLevelId;
                           exResourceassignmentstatus1.Entrystamp = DateTime.Now;
                           exResourceassignmentstatus1.Userlognid = model.UserLognID;
                           exResourceassignmentstatus1.ApproveStatus = ApproveStatus;
                           exResourceassignmentstatus1.OffboardStatus = null;
                           exResourceassignmentstatus1.OffboardStamp = null;
                           exResourceassignmentstatus1.OffboardUserlognid = null;
                           exResourceassignmentstatus1.Reason = Reason;
                           exResourceassignmentstatus1.FinStatus = FinStatus;
                            exResourceassignmentstatus1.Tranid = TranID;
                            _repositorycontext.ExResourceassignmentstatuses.Add(exResourceassignmentstatus1);

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

        //[HttpPost("ReasonUpdate")]
        //public IActionResult ReasonUpdate(ReasonUpdate model)
        //{
        //    Response response = new();
        //    try
        //    {
        //        string message = string.Empty;
        //        if (model is null)
        //        {
        //            response.Status = false;
        //            response.Message = "model is required";
        //            response.Data = "";
        //            response.Error = "model is required";
        //            return Ok(response);
        //        }
        //        else
        //        {
        //            KickOffStatus kickmodel = new KickOffStatus();
        //            ResultTemp resultModel = new ResultTemp();

        //            DateTime LockDate = DateTime.Now;
        //            var LockDate1 = (from p in _repositorycontext.ExTransactionApprovals
        //                             orderby p.Id descending
        //                             select new
        //                             {
        //                                 p.LockedOn

        //                             }).ToList();
        //            if (LockDate1.Count > 0)
        //            {

        //                LockDate = Convert.ToDateTime(LockDate1[0].LockedOn);
        //            }
        //            if (LockDate >= Convert.ToDateTime(model.NewStartDate))
        //            {
        //                kickmodel.nstatus = "Reason Start Date cannot less than or equal to lock date " + LockDate.ToString("yyyy-MM-dd");
        //            }
        //            else
        //            {


        //                int ID = 0;
        //                int SL = 0;
        //                int TranID = 0;
        //                int ProjID = 0;
        //                DateTime KickOff = DateTime.Now;
        //                DateTime OldStart = DateTime.Now;
        //                decimal? OldAllocation = 0;
        //                DateTime EntryStamp = DateTime.Now;
        //                string Group = "";
        //                int Maxid = 0;



        //                var finddata = (from p in _repositorycontext.ExResourceassignmentstatuses
        //                                where p.CuIden == model.CuIden && p.PeLogn == model.PeLogn && p.Enddate == null
        //                                select new
        //                                {
        //                                    SL = p.Sl,
        //                                    TranID = p.Tranid,
        //                                    KickOff = p.KickOff,
        //                                    ProjID = p.ProjId,
        //                                    Group = p.Group
        //                                }).Distinct().ToList();

        //                if (finddata.Count > 0)
        //                {
        //                    SL = Convert.ToInt16(finddata[0].SL);
        //                    TranID = Convert.ToInt16(finddata[0].TranID);
        //                    KickOff = Convert.ToDateTime(finddata[0].KickOff);
        //                    ProjID = Convert.ToInt16(finddata[0].ProjID);
        //                    Group = finddata[0].Group;
        //                }

        //                var finddata1 = (from p in _repositorycontext.ExIpcustomerReasons
        //                                 where p.CuIden == model.CuIden && p.PeLogn == model.PeLogn && p.EffectiveTo == null && p.KickOff == KickOff
        //                                 select new
        //                                 {
        //                                     EffectiveFrom = p.EffectiveFrom
        //                                 }).Distinct().ToList();

        //                if (finddata1.Count > 0)
        //                { 
        //                    OldStart = finddata1[0].EffectiveFrom;
        //                }

        //                if (OldStart >= model.NewStartDate)
        //                {
        //                    kickmodel.nstatus = "New Reason Start Date cannot less than or equal to current Group start date " + OldStart.ToString("yyyy-MM-dd");
        //                }
        //                else
        //                {
        //                    DateTime Reasonenddate = DateTime.Now;
        //                    Reasonenddate = model.NewStartDate.AddDays(-1);

        //                    ExIpcustomerReason exIpcustomerReason = _repositorycontext.ExIpcustomerReasons.Where(x => x.PeLogn == model.PeLogn
        //                 && x.EffectiveTo == null && x.CuIden == Convert.ToInt16(model.CuIden)).FirstOrDefault();
        //                    exIpcustomerReason.DateOfMove = Reasonenddate;
        //                    exIpcustomerReason.EffectiveTo = Reasonenddate;
        //                    exIpcustomerReason.Status = "D";
        //                    exIpcustomerReason.EnddateStamp = DateTime.Now;
        //                    exIpcustomerReason.EnddateUserlognid = model.UserLognID;
        //                    _repositorycontext.ExIpcustomerReasons.Update(exIpcustomerReason);
        //                    //_repositorycontext.SaveChanges();

        //                    ExIpcustomerReason statusobj = new ExIpcustomerReason();
        //                    statusobj.Sl = SL;
        //                    statusobj.PeLogn = model.PeLogn;
        //                    statusobj.CuIden = model.CuIden;
        //                    statusobj.ProjId = 0;
        //                    statusobj.KickOff = KickOff;
        //                    statusobj.DateOfMove = null; 
        //                    statusobj.Reason = model.Reason; 
        //                    statusobj.EffectiveFrom = model.NewStartDate;
        //                    statusobj.EffectiveTo = null; 
        //                    statusobj.Status = "A";
        //                    statusobj.Userlognid = model.UserLognID;
        //                    statusobj.Entrystamp = DateTime.Now; 
        //                    _repositorycontext.ExIpcustomerReasons.Add(statusobj);

        //                    _repositorycontext.SaveChanges();

        //                    kickmodel.nstatus = "Update Sucessfully";

        //                }

        //            }

        //            response.Status = true;
        //            response.Message = kickmodel.nstatus;
        //            response.Data = kickmodel;
        //            response.Error = "";
        //            return Ok(response);

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = false;
        //        response.Message = "Something went wrong. Please contact Administrator !!";
        //        response.Error = ex.ToString();
        //        return Ok(response);

        //    }
        //}

        [HttpGet("GetBillingPeopleList/{pelogin}/{cuiden}")]
        public IActionResult GetBillingPeopleList(string pelogin, string cuiden)
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

                if (role == "DM")
                {
                    //int?[] TypeList = { 1, 2 };

                    //var exreportingmanager = (from a in ExResourceassignmentstatuses
                    //                          join b in _edmdbcontext.ExReportingmanagers on
                    //                          new
                    //                              //{ X1 = a.CuIden ?? default(int), X3 = a.KickOff ?? default(DateTime) }
                    //                              { X1 = a.CuIden, X3 = a.KickOff }
                    //                                equals new { X1 = b.CuIden ?? default(int), X3 = b.KickOff ?? default(DateTime) }
                    //                          where b.Mngrlognid == pelogin && b.Enddate is null
                    //                          && TypeList.Contains(b.Type) && b.CuIden != 85 && a.Enddate == null && a.CuIden.ToString() == cuiden && reasonlist.Contains(a.Reason)
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
                                    where a.PeLogn == pelogin
                                    select a.PeDept).ToList();

                    var result = (from a in ExResourceassignmentstatuses
                                  join b in _edmdbcontext.IpPeople on a.PeLogn equals b.PeLogn into sb
                                  from b in sb.DefaultIfEmpty()
                                  join c in _edmdbcontext.ExIppeople on a.PeLogn equals c.PeLogn into sc
                                  from c in sc.DefaultIfEmpty()
                                  where a.Enddate == null && a.CuIden != 85 && a.OffboardStatus == null && a.CuIden.ToString() == cuiden
                                  && a.ApproveStatus == "A" && /*VaLognIdList.Contains(a.PeLogn)*/ deptList.Contains(b.PeDept) && reasonlist.Contains(a.Reason)
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
                                  && a.ApproveStatus == "A" && serviceLine.Contains(b != null ? b.PeDept : "") && reasonlist.Contains(a.Reason)
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
                                  && a.ApproveStatus == "A" && serviceLine.Contains(b != null ? b.PeDept : "") && reasonlist.Contains(a.Reason)
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
                                  join b in _edmdbcontext.IpPeople on a.PeLogn equals b.PeLogn into sb
                                  from b in sb.DefaultIfEmpty()
                                  join c in _edmdbcontext.ExIppeople on a.PeLogn equals c.PeLogn into sc
                                  from c in sc.DefaultIfEmpty()
                                  where a.Enddate == null && a.CuIden != 85 && a.OffboardStatus == null && a.CuIden.ToString() == cuiden
                                  && a.ApproveStatus == "A" && CuIden.Contains(a.CuIden) && reasonlist.Contains(a.Reason)
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
                                  && a.ApproveStatus == "A" && b != null && reasonlist.Contains(a.Reason)
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

        [HttpGet("GetGroupMaster/{pelogin}")]
        public IActionResult GetGroupMaster(string pelogin)
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
              
                var ExResourceassignmentstatuses = (from a in _repositorycontext.ExResourceassignmentstatuses select a).ToList();
                var MasterAbbrevations = (from a in _repositorycontext.MasterAbbrevations select a).ToList();
                var IpElements = (from a in _edmdbcontext.IpElements select a).ToList();


                //var subquery = (from a in _repositorycontext.ExClientPlOwners where a.PeLogn == pelogin && a.Enddate == null && a.Status == "A" select a).ToList();
                //string[] serviceLine = new string[subquery.Count + 1];
                //if (subquery.Count > 0)
                //{
                //    for (int i = 0; i < subquery.Count; i++)
                //    {
                //        serviceLine[i] = subquery[i].ServiceLine;
                //    }

                //}

                var result = (from a in MasterAbbrevations 
                              join b in IpElements on a.Code equals b.ElCode
                              where a.Lob==dept  
                              //orderby b != null ? b.PeName : ""
                              select new
                              {
                                  value = b.ElCode,
                                  label = b.ElName
                              }).Distinct().ToList();

                dList.Add("Table", result);

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

        [HttpPost("RoleUpdate")]
        public IActionResult RoleUpdate(RoleUpdate model)
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
                    if (LockDate >= Convert.ToDateTime(model.NewStartDate))
                    {
                        kickmodel.nstatus = "Role Start Date cannot less than or equal to lock date " + LockDate.ToString("yyyy-MM-dd");
                    }
                    else
                    {


                        int ID = 0;
                        int SL = 0;
                        int TranID = 0;
                        int ProjID = 0;
                        DateTime KickOff = DateTime.Now;
                        DateTime OldStart = DateTime.Now;
                        decimal? OldAllocation = 0;
                        DateTime EntryStamp = DateTime.Now;
                        string Group = "";
                        int Maxid = 0;

                        string Role = "";
                        DateTime BillStart = DateTime.Now;
                        string Status = "";
                        int StatusLevelId = 0;
                        string ApproveStatus = "";
                        string Reason = "";
                        string FinStatus = "";

                        var finddata = (from p in _repositorycontext.ExResourceassignmentstatuses
                                        where p.CuIden == model.CuIden && p.PeLogn == model.PeLogn && p.Enddate == null && p.ApproveStatus == "A"
                                        select new
                                        {
                                            SL = p.Sl,
                                            TranID = p.Tranid,
                                            KickOff = p.KickOff,
                                            ProjID = p.ProjId,
                                            Group = p.Group,
                                            Role = p.Role,
                                            BillStart = p.BillStart,
                                            Status = p.Status,
                                            StatusLevelId = p.StatusLevelId,
                                            ApproveStatus = p.ApproveStatus,
                                            Reason = p.Reason,
                                            FinStatus = p.FinStatus
                                        }).Distinct().ToList();

                        if (finddata.Count > 0)
                        {
                            SL = Convert.ToInt16(finddata[0].SL);
                            TranID = Convert.ToInt16(finddata[0].TranID);
                            KickOff = Convert.ToDateTime(finddata[0].KickOff);
                            ProjID = Convert.ToInt16(finddata[0].ProjID);
                            Group = finddata[0].Group;
                            Role = finddata[0].Role;
                            BillStart = Convert.ToDateTime(finddata[0].BillStart);
                            Status = finddata[0].Status;
                            StatusLevelId = Convert.ToInt16(finddata[0].StatusLevelId);
                            ApproveStatus = finddata[0].ApproveStatus;
                            Reason = finddata[0].Reason;
                            FinStatus = finddata[0].FinStatus;
                        }

                        var finddata1 = (from p in _repositorycontext.ExIpcustomerRoles
                                         where p.CuIden == model.CuIden && p.PeLogn == model.PeLogn && p.RoleEnddate == null && p.KickOff == KickOff
                                         select new
                                         {
                                             RoleStartdt = p.RoleStartdt
                                         }).Distinct().ToList();

                        if (finddata1.Count > 0)
                        {
                            OldStart = finddata1[0].RoleStartdt;
                        }

                        if (OldStart >= model.NewStartDate)
                        {
                            kickmodel.nstatus = "Role Start Date cannot less than or equal to current Role start date " + OldStart.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            DateTime Roleenddate = DateTime.Now;
                            Roleenddate = model.NewStartDate.AddDays(-1);

                            ExIpcustomerRole exIpcustomerRole = _repositorycontext.ExIpcustomerRoles.Where(x => x.PeLogn == model.PeLogn
                         && x.RoleEnddate == null && x.CuIden == Convert.ToInt16(model.CuIden)).FirstOrDefault();
                            //exIpcustomerRole.DateOfMove = Roleenddate;
                            exIpcustomerRole.RoleEnddate = Roleenddate;
                            exIpcustomerRole.Status = "D";
                            exIpcustomerRole.EnddateStamp = DateTime.Now;
                            exIpcustomerRole.EnddateUserlognid = model.UserLognID;
                            _repositorycontext.ExIpcustomerRoles.Update(exIpcustomerRole);
                            //_repositorycontext.SaveChanges();

                            ExIpcustomerRole statusobj = new ExIpcustomerRole();
                            statusobj.Sl = SL;
                            statusobj.CuIden = model.CuIden;
                            statusobj.ProjId = 0;
                            statusobj.PeLogn = model.PeLogn;
                            statusobj.Role = model.Role;
                            statusobj.KickOff = KickOff;
                            statusobj.DateOfMove = null;
                            statusobj.RoleStartdt = model.NewStartDate;
                            statusobj.RoleEnddate = null;
                            statusobj.Status = "A";
                            statusobj.Userlognid = model.UserLognID;
                            statusobj.Entrystamp = DateTime.Now;
                            _repositorycontext.ExIpcustomerRoles.Add(statusobj);


                            ExResourceassignmentstatus exResourceassignmentstatus = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.PeLogn == model.PeLogn
                           && x.Enddate == null && x.CuIden == Convert.ToInt16(model.CuIden) && x.ApproveStatus == "A").FirstOrDefault();
                            exResourceassignmentstatus.Enddate = Roleenddate;
                            _repositorycontext.ExResourceassignmentstatuses.Update(exResourceassignmentstatus);


                            TranID = TranID + 1;

                            ExResourceassignmentstatus exResourceassignmentstatus1 = new ExResourceassignmentstatus();
                            exResourceassignmentstatus1.Sl = SL;
                            exResourceassignmentstatus1.PeLogn = model.PeLogn;
                            exResourceassignmentstatus1.CuIden = Convert.ToInt32(model.CuIden);
                            exResourceassignmentstatus1.ProjId = ProjID;
                            exResourceassignmentstatus1.Group = Group;
                            exResourceassignmentstatus1.Role = model.Role;
                            exResourceassignmentstatus1.KickOff = KickOff;
                            exResourceassignmentstatus1.BillStart = BillStart.ToString() == "1/1/0001 12:00:00 AM" ? null : BillStart;
                            exResourceassignmentstatus1.DateOfMove = null;
                            exResourceassignmentstatus1.Startdate = model.NewStartDate;
                            exResourceassignmentstatus1.Enddate = null;//hard coded from below line
                            exResourceassignmentstatus1.Status = Status;
                            exResourceassignmentstatus1.StatusLevelId = StatusLevelId;
                            exResourceassignmentstatus1.Entrystamp = DateTime.Now;
                            exResourceassignmentstatus1.Userlognid = model.UserLognID;
                            exResourceassignmentstatus1.ApproveStatus = ApproveStatus;
                            exResourceassignmentstatus1.OffboardStatus = null;
                            exResourceassignmentstatus1.OffboardStamp = null;
                            exResourceassignmentstatus1.OffboardUserlognid = null;
                            exResourceassignmentstatus1.Reason = Reason;
                            exResourceassignmentstatus1.FinStatus = FinStatus;
                            exResourceassignmentstatus1.Tranid = TranID;
                            _repositorycontext.ExResourceassignmentstatuses.Add(exResourceassignmentstatus1);

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


        [HttpPost("ReasonUpdate")]
        public IActionResult ReasonUpdate(ReasonUpdate model)
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
                    if (LockDate >= Convert.ToDateTime(model.NewStartDate))
                    {
                        kickmodel.nstatus = "Reason Start Date cannot less than or equal to lock date " + LockDate.ToString("yyyy-MM-dd");
                    }
                    else
                    {


                        int ID = 0;
                        int SL = 0;
                        int TranID = 0;
                        int ProjID = 0;
                        DateTime KickOff = DateTime.Now;
                        DateTime OldStart = DateTime.Now;
                        decimal? OldAllocation = 0;
                        DateTime EntryStamp = DateTime.Now;
                        string Group = "";
                        int Maxid = 0;

                        string Role = "";
                        DateTime BillStart = DateTime.Now;
                        string Status = "";
                        int StatusLevelId = 0;
                        string ApproveStatus = "";
                        string Reason = "";
                        string FinStatus = "";

                        var finddata = (from p in _repositorycontext.ExResourceassignmentstatuses
                                        where p.CuIden == model.CuIden && p.PeLogn == model.PeLogn && p.Enddate == null && p.ApproveStatus == "A"
                                        select new
                                        {
                                            SL = p.Sl,
                                            TranID = p.Tranid,
                                            KickOff = p.KickOff,
                                            ProjID = p.ProjId,
                                            Group = p.Group,
                                            Role = p.Role,
                                            BillStart = p.BillStart,
                                            Status = p.Status,
                                            StatusLevelId = p.StatusLevelId,
                                            ApproveStatus = p.ApproveStatus,
                                            Reason = p.Reason,
                                            FinStatus = p.FinStatus
                                        }).Distinct().ToList();

                        if (finddata.Count > 0)
                        {
                            SL = Convert.ToInt16(finddata[0].SL);
                            TranID = Convert.ToInt16(finddata[0].TranID);
                            KickOff = Convert.ToDateTime(finddata[0].KickOff);
                            ProjID = Convert.ToInt16(finddata[0].ProjID);
                            Group = finddata[0].Group;
                            Role = finddata[0].Role;
                            BillStart = Convert.ToDateTime(finddata[0].BillStart);
                            Status = finddata[0].Status;
                            StatusLevelId = Convert.ToInt16(finddata[0].StatusLevelId);
                            ApproveStatus = finddata[0].ApproveStatus;
                            Reason = finddata[0].Reason;
                            FinStatus = finddata[0].FinStatus;
                        }

                        var finddata1 = (from p in _repositorycontext.ExIpcustomerReasons
                                         where p.CuIden == model.CuIden && p.PeLogn == model.PeLogn && p.EffectiveTo == null && p.KickOff == KickOff
                                         select new
                                         {
                                             EffectiveFrom = p.EffectiveFrom
                                         }).Distinct().ToList();

                        if (finddata1.Count > 0)
                        {
                            OldStart = finddata1[0].EffectiveFrom;
                        }

                        if (OldStart >= model.NewStartDate)
                        {
                            kickmodel.nstatus = "Reason Start Date cannot less than or equal to current Reason start date " + OldStart.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            string[] reasonList = { "BNA", "BILLING", "NBST5" };
                            string[] reasonList1 = { "BNA", "BILLING", "NBST5" };
                            if ((reasonList.Contains(Reason) && reasonList.Contains(model.Reason)) ||
                                (!reasonList.Contains(Reason) && !reasonList.Contains(model.Reason))
                                )
                            {

                                DateTime Reasonenddate = DateTime.Now;
                                Reasonenddate = model.NewStartDate.AddDays(-1);

                                ExIpcustomerReason exIpcustomerReason = _repositorycontext.ExIpcustomerReasons.Where(x => x.PeLogn == model.PeLogn
                             && x.EffectiveTo == null && x.CuIden == Convert.ToInt16(model.CuIden)).FirstOrDefault();
                                //exIpcustomerReason.DateOfMove = Reasonenddate;
                                exIpcustomerReason.EffectiveTo = Reasonenddate;
                                exIpcustomerReason.Status = "D";
                                exIpcustomerReason.EnddateStamp = DateTime.Now;
                                exIpcustomerReason.EnddateUserlognid = model.UserLognID;
                                _repositorycontext.ExIpcustomerReasons.Update(exIpcustomerReason);
                        

                                ExIpcustomerReason statusobj = new ExIpcustomerReason();
                                statusobj.Sl = SL;
                                statusobj.CuIden = model.CuIden;
                                statusobj.ProjId = 0;
                                statusobj.PeLogn = model.PeLogn;
                                statusobj.Reason = model.Reason;
                                statusobj.KickOff = KickOff;
                                statusobj.DateOfMove = null;
                                statusobj.EffectiveFrom = model.NewStartDate;
                                statusobj.EffectiveTo = null;
                                statusobj.Status = "A";
                                statusobj.Userlognid = model.UserLognID;
                                statusobj.Entrystamp = DateTime.Now;
                                statusobj.Replacewith = model.ReplaceWith;
                                _repositorycontext.ExIpcustomerReasons.Add(statusobj);
                               

                                ExResourceassignmentstatus exResourceassignmentstatus = _repositorycontext.ExResourceassignmentstatuses.Where(x => x.PeLogn == model.PeLogn
                               && x.Enddate == null && x.CuIden == Convert.ToInt16(model.CuIden) && x.ApproveStatus == "A").FirstOrDefault();
                                exResourceassignmentstatus.Enddate = Reasonenddate;
                                _repositorycontext.ExResourceassignmentstatuses.Update(exResourceassignmentstatus);
                              

                                TranID = TranID + 1;

                                if (BillStart.ToString() == "1/1/0001 12:00:00 AM")
                                {
                                    ExResourceassignmentstatus exResourceassignmentstatus1 = new ExResourceassignmentstatus();
                                    exResourceassignmentstatus1.Sl = SL;
                                    exResourceassignmentstatus1.PeLogn = model.PeLogn;
                                    exResourceassignmentstatus1.CuIden = Convert.ToInt32(model.CuIden);
                                    exResourceassignmentstatus1.ProjId = ProjID;
                                    exResourceassignmentstatus1.Group = Group;
                                    exResourceassignmentstatus1.Role = Role;
                                    exResourceassignmentstatus1.KickOff = KickOff;
                                    exResourceassignmentstatus1.BillStart = null;
                                    exResourceassignmentstatus1.DateOfMove = null;
                                    exResourceassignmentstatus1.Startdate = model.NewStartDate;
                                    exResourceassignmentstatus1.Enddate = null;//hard coded from below line
                                    exResourceassignmentstatus1.Status = Status;
                                    exResourceassignmentstatus1.StatusLevelId = StatusLevelId;
                                    exResourceassignmentstatus1.Entrystamp = DateTime.Now;
                                    exResourceassignmentstatus1.Userlognid = model.UserLognID;
                                    exResourceassignmentstatus1.ApproveStatus = ApproveStatus;
                                    exResourceassignmentstatus1.OffboardStatus = null;
                                    exResourceassignmentstatus1.OffboardStamp = null;
                                    exResourceassignmentstatus1.OffboardUserlognid = null;
                                    exResourceassignmentstatus1.Reason = model.Reason;
                                    exResourceassignmentstatus1.FinStatus = FinStatus;
                                    exResourceassignmentstatus1.Tranid = TranID;
                                    _repositorycontext.ExResourceassignmentstatuses.Add(exResourceassignmentstatus1);
                                }
                                else
                                {
                                    ExResourceassignmentstatus exResourceassignmentstatus1 = new ExResourceassignmentstatus();
                                    exResourceassignmentstatus1.Sl = SL;
                                    exResourceassignmentstatus1.PeLogn = model.PeLogn;
                                    exResourceassignmentstatus1.CuIden = Convert.ToInt32(model.CuIden);
                                    exResourceassignmentstatus1.ProjId = ProjID;
                                    exResourceassignmentstatus1.Group = Group;
                                    exResourceassignmentstatus1.Role = Role;
                                    exResourceassignmentstatus1.KickOff = KickOff;
                                    exResourceassignmentstatus1.BillStart = BillStart;
                                    exResourceassignmentstatus1.DateOfMove = null;
                                    exResourceassignmentstatus1.Startdate = model.NewStartDate;
                                    exResourceassignmentstatus1.Enddate = null;//hard coded from below line
                                    exResourceassignmentstatus1.Status = Status;
                                    exResourceassignmentstatus1.StatusLevelId = StatusLevelId;
                                    exResourceassignmentstatus1.Entrystamp = DateTime.Now;
                                    exResourceassignmentstatus1.Userlognid = model.UserLognID;
                                    exResourceassignmentstatus1.ApproveStatus = ApproveStatus;
                                    exResourceassignmentstatus1.OffboardStatus = null;
                                    exResourceassignmentstatus1.OffboardStamp = null;
                                    exResourceassignmentstatus1.OffboardUserlognid = null;
                                    exResourceassignmentstatus1.Reason = model.Reason;
                                    exResourceassignmentstatus1.FinStatus = FinStatus;
                                    exResourceassignmentstatus1.Tranid = TranID;
                                    _repositorycontext.ExResourceassignmentstatuses.Add(exResourceassignmentstatus1);

                                } 

                                _repositorycontext.SaveChanges();

                                kickmodel.nstatus = "Update Sucessfully";
                            }
                            else
                            {
                                ExIpcustomerConversion statusobj = new ExIpcustomerConversion();
                                statusobj.Sl = SL;
                                statusobj.CuIden = model.CuIden;
                                statusobj.ProjId = 0;
                                statusobj.PeLogn = model.PeLogn;
                                statusobj.Reason = model.Reason;
                                statusobj.KickOff = KickOff;
                                statusobj.Group = Group;
                                statusobj.Role = Role; 
                                statusobj.Startdate = model.NewStartDate;
                                statusobj.Enddate = null;
                                statusobj.BillStart = model.NewStartDate;
                                statusobj.BillEnd = null; 
                                statusobj.Userlognid = model.UserLognID;
                                statusobj.Entrystamp = DateTime.Now;
                                statusobj.CurrentReason =Reason; 
                                statusobj.RepLogn =model.ReplaceWith; 
                                statusobj.FinStatus ="P"; 
                                _repositorycontext.ExIpcustomerConversions.Add(statusobj);
                                _repositorycontext.SaveChanges();
                                kickmodel.nstatus = "Update Sucessfully";
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

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
