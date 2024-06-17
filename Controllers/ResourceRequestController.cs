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
    public class ResourceRequestController : ControllerBase
    {
        private readonly RepositoryDbContext _repositorycontext;
         private readonly EDMDbContext _edmdbcontext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public ResourceRequestController(IHttpContextAccessor httpContextAccessor, IMapper mapper, RepositoryDbContext repositorycontext, EDMDbContext edmrepositorycontext)
        {
            _httpContextAccessor = httpContextAccessor;

            _mapper = mapper;
            _repositorycontext = repositorycontext;
            _edmdbcontext = edmrepositorycontext;
        }
        [HttpGet("GetOnboardListProject/{cu_iden}/{group}")]
        public IActionResult GetOnboardListProject(string cu_iden, string group)
        {
            //uSp_Onboard_List_Project '652','ASEUF'
            Response response = new();
            try
            {
                string message = string.Empty;
                if (String.IsNullOrEmpty(cu_iden))
                {
                    response.Status = false;
                    response.Message = "cu_iden required";
                    response.Data = "";
                    response.Error = "cu_iden required";
                    return Ok(response);
                }
                else
                {
                    Core core = new(_repositorycontext,_edmdbcontext);
                    var result = core.USp_Onboard_List_Project(cu_iden, group);
                    return Ok(result);
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

        [HttpPost("RaiseResourceRequest")]

        public IActionResult RaiseResourceRequest(ResourceRequest model)
        {
            Response response = new Response();
            try
            {
                if (model.Resource_Reason != "NBST1")
                {
                    model.REPLACEMENT_LOGN = "NA";
                }
                if (model.Resource_Reason != "BNA")
                {
                    model.BillPercent = 0;
                }

                string LognType = string.Empty;
                int IsPLO = 0;
                string Status = "P";
                Core core = new(_repositorycontext,_edmdbcontext);
                LognType = core.uFn_LoginCheck(model.UserLognID);
                IsPLO = core.uFn_Check_PLOwner(model);
                if (IsPLO == 1)
                {
                    if ((from a in _repositorycontext.ExIpcustomerOthers where a.CuIden == model.Cu_Iden && a.Clientgroup == model.Group_Code && a.Enddate == null select new { a.CuIden }).ToList().Count > 0)
                    {
                        int LOB = core.UFn_GetClientGroupWithLOB(model.UserLognID.ToString());
                        Status = LOB >= 1 ? "A" : "P";
                        //if (LOB.Count())
                    }
                }
                else
                {
                    string[] roleList = { "CHEAD", "EMGR" };
                    if ((from a in _repositorycontext.ExIpcustomerOthers where a.CuIden == model.Cu_Iden && a.PeLogn == model.UserLognID && a.Clientgroup == model.Group_Code && a.Enddate == null && roleList.Contains(a.Role) && a.Startdt <= DateTime.Now select new { a.CuIden }).ToList().Count > 0)
                    {
                        Status = "A";

                    }
                }
                model.REPLACEMENT_LOGN = model.Resource_Reason == "NBST1" ? model.REPLACEMENT_LOGN : null;
                model.BillPercent = model.Resource_Reason == "BNA" ? model.BillPercent : 0;
                Int64 Req_ID = 0;

                Req_ID = _repositorycontext.ExResourcerequests.Max(p => p.ReqId) ?? 0;
                Req_ID = Req_ID + 1;

                ExResourcerequest modelRequest = new ExResourcerequest();
                // ExResourcerequestNew modelRequest = new ExResourcerequestNew();
                modelRequest.ReqId = Req_ID;
                modelRequest.CuIden = model.Cu_Iden;
                modelRequest.RequestDate = Convert.ToDateTime(model.Request_Date);
                modelRequest.CompletionDate = Convert.ToDateTime(model.Completion_Date);
                modelRequest.ResourceCount = 0;
                modelRequest.ActualCount = 0;
                modelRequest.Entrystamp = DateTime.Now;
                modelRequest.Userlognid = model.UserLognID;
                modelRequest.Status = Status;
                modelRequest.Mngrstatus = model.AMVP;
                modelRequest.GroupCode = model.Group_Code;
                modelRequest.ResourceReason = model.Resource_Reason;
                modelRequest.Supr = model.Supr;
                modelRequest.ProjId = model.Proj_Id;
                modelRequest.ReplacementLogn = model.REPLACEMENT_LOGN;
                modelRequest.Mngrstatus = "P";
                modelRequest.Status = "P";
                modelRequest.Sow = model.SowNo;
                _repositorycontext.ExResourcerequests.Add(modelRequest);
                //_repositorycontext.ExResourcerequestNews.Add(modelRequest);
               _repositorycontext.SaveChanges();

                Int64 MaxRoleSL = 0;
                MaxRoleSL = _repositorycontext.ExResourcerequestRoles.Max(p => p.Rolesl) ?? 0;
                MaxRoleSL = MaxRoleSL + 1;

                ExResourcerequestRole reqModel = new ExResourcerequestRole();
                //reqModel.ReqId = (int?)modelRequest.ReqId;
                reqModel.ReqId = (int?)Req_ID;
                reqModel.Rolesl = MaxRoleSL;
                reqModel.Title = model.Title;
                reqModel.Noofresource = model.NoOfResource;
                reqModel.RequiredDate = Convert.ToDateTime(model.Required_Date);
                reqModel.Priority = model.Priority;
                reqModel.Remarks = model.Remarks;
                reqModel.Userlognid = model.UserLognID;
                reqModel.Entrystamp = DateTime.Now;
                reqModel.IpLocn = model.IP_Locn;
                reqModel.ResourceAllocn = (decimal?)model.Resource_Allocn;
                reqModel.Billpercent = (decimal?)model.BillPercent;
                _repositorycontext.ExResourcerequestRoles.Add(reqModel);
                Int64 TotCount = 0;
                var item = (from a in _repositorycontext.ExResourcerequestRoles where a.ReqId == modelRequest.ReqId select a).ToList();
                if (item.Count > 0)
                {
                    var query = item.Sum(x => x.Noofresource);
                    TotCount = (long)query;
                }
                var resReq = _repositorycontext.ExResourcerequests.SingleOrDefault(x => x.ReqId == modelRequest.ReqId);
                resReq.ResourceCount = TotCount;
                resReq.ActualCount = (int?)TotCount;
                _repositorycontext.ExResourcerequests.Update(resReq);

                int Srno = 0;
                // var o = beatles.GroupBy(x => x.inst)
                //.SelectMany(g =>
                //    g.Select((j, i) => new { j.inst, j.name, rn = i + 1 })
                //);

                //List<ExResourcerequestSkill> lstSkill1 = (from ct in _edmdbcontext.IpCategories
                //                                          from rs in _repositorycontext.ExIprolecoreskills
                //                                          from el in _edmdbcontext.IpElements

                //                                          where ct.CaCode == model.Title
                //                                          &&
                //                                          rs.RoleCode == ct.CaCode
                //                                          && rs.CaCode == el.CaCode
                //                                          &&
                //                                          rs.ElCode == el.ElCode
                //                                          select new ExResourcerequestSkill
                //                                          {
                //                                              ReqId = (int?)(long)modelRequest.ReqId,
                //                                              Rolesl = MaxRoleSL,
                //                                              Sl = 0,//
                //                                              Skillscode = el.CaCode,
                //                                              Skills = el.ElCode,
                //                                              Skilllevel = rs.Rating,
                //                                              Userlognid = model.UserLognID,
                //                                              Entrystamp = DateTime.Now
                //                                          }
                //              ).ToList();

                //List<ExResourcerequestSkill> finalSkill = (from t in lstSkill1
                //                                           orderby t.Skills descending
                //                                           select new ExResourcerequestSkill
                //                                           {
                //                                               Sl = ++Srno,
                //                                               ReqId = t.ReqId,
                //                                               Rolesl = t.Rolesl,
                //                                               Skillscode = t.Skillscode,
                //                                               Skills = t.Skills,
                //                                               Skilllevel = t.Skilllevel,
                //                                               Userlognid = t.Userlognid,
                //                                               Entrystamp = t.Entrystamp

                //                                           }).ToList();
                //_repositorycontext.ExResourcerequestSkills.UpdateRange(finalSkill);

                _repositorycontext.SaveChanges();


                response.Data = "";
                response.Status = true;
                response.Message = "Resource Request Added successfully";
                response.Error = "";
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                response.Error = ex.ToString();
                return Ok(response);

            }

        }

        [HttpGet("GetClientDetailForRR/{cuiden}")]
        public IActionResult GetClientDetailForRR(int cuiden)
        {
            Response response = new Response();
            try
            {
                var IpElements = (from a in _edmdbcontext.IpElements select a).ToList();
                var ExIpcustomerOthers = (from a in _repositorycontext.ExIpcustomerOthers select a).ToList();
                var MasterAbbrevations = (from a in _repositorycontext.MasterAbbrevations select a).ToList();

                var dataList = (
                       from a in _repositorycontext.ExClientServicelines
                       where a.CuIden == cuiden && a.Enddate == null && a.Status == "A"
                       select new
                       {
                           service_line = a.ServiceLine
                       }
                       ).ToList();
                string[] serviceLine = new string[dataList.Count + 1];
                for (int i = 0; i < dataList.Count; i++)
                {
                    serviceLine[i] = dataList[i].service_line;
                }

                var data11 = (from a in MasterAbbrevations 
                            join b in IpElements on new
                            { User = a != null ? a.Code : "" }
              equals new { User = b != null ? b.ElCode : "" }

                          into cp1
                            from b in cp1.DefaultIfEmpty()
                            where serviceLine.Contains(a.Lob)
                            //&& b.ElName != null
                            //orderby b.ElName
                            select new
                            {
                                Group = a.Code,
                                ClientGroup = b != null ? b.ElName.ToUpper() : "NA"

                            }).ToList();

                var data1 = data11.ToList().Where(x => x.ClientGroup != "NA");

                ClientModel model = new ClientModel();
                Core core = new(_repositorycontext,_edmdbcontext);
                var Data = core.uSp_Onboard_List_ClientGroup(cuiden);
                model.CU_IDEN = cuiden;
                model.Type = "D";
                var Data1 = core.uSp_RR_ListDM(model);
                model.CU_IDEN = cuiden;
                model.Type = "S";
                var Data2 = core.uSp_RR_ListDM(model);
                var Data3 = core.uSp_Onboard_ListReason(cuiden);
                var Data4 = core.USP_RR_CountryList();
                var Data5 = core.USP_GetApproverList(cuiden);
                Dictionary<string, object> dList = new Dictionary<string, object>();
                //dList.Add("onboardlist", Data.Data);
                dList.Add("onboardlist", data1);
                dList.Add("listdm_d", Data1.Data);
                dList.Add("listdm_s", Data2.Data);
                dList.Add("onboardlistreason", Data3.Data);
                dList.Add("countrylist", Data4.Data);
                dList.Add("approverlist", Data5.Data);


                response.Data = dList;
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
                return Ok(response);

            }

        }

        [HttpGet("GetRoleListBasedonGroup/{Group}")]
        public IActionResult GetRoleListBasedonGroup(string Group)
        {
            Response response = new Response();
            try
            {
                string message = string.Empty;
                if (String.IsNullOrEmpty(Group))
                {
                    response.Status = false;
                    response.Message = "Group required";
                    response.Data = "";
                    response.Error = "Group required";
                    return Ok(response);
                }
                else
                {
                    var data = (from p in _edmdbcontext.IpCategories
                                where p.CaValu == "1" && (p.CaOrdr >= 20 && p.CaOrdr <= 80) && p.CaCode != "TL"
                                select new
                                {
                                    value = p.CaCode,
                                    label = p.CaName
                                }).ToList();
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
                response.Message = "Something went wrong. Please try after some time"; ;
                response.Error = ex.ToString();
                return Ok(response);
            }

        }

        [HttpGet("GetResourceRequest/{pelogn}")]
        public IActionResult GetResourceRequest(string pelogn)
        {
            Response response = new Response();
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
                    var data = (from p in _repositorycontext.ExResourcerequests
                                join a in _repositorycontext.ExStatusdescs on p.ResourceReason equals a.Level
                                join b in _repositorycontext.IpCustomers on p.CuIden equals b.CuIden
                                where p.Userlognid== pelogn 
                                select new
                                {
                                    ReqId= p.ReqId,
                                    ClientCode = b.CuComp,
                                    RequestDate= p.RequestDate.Value.ToString("yyyy-MM-dd"),
                                    CompletionDate = p.CompletionDate.Value.ToString("yyyy-MM-dd"),
                                    ActualCount =  p.ActualCount,
                                    StatusDesc =a.StatusDesc,
                                    Entrystamp = p.Entrystamp.Value.ToString("yyyy-MM-dd"),
                                    Status = p.Status == "P" ? "Pending" : "Approved"
                                }).ToList();
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
                response.Message = "Something went wrong. Please try after some time"; ;
                response.Error = ex.ToString();
                return Ok(response);
            }

        }

        [HttpPost("UpdateRequestStatus")]
        public IActionResult UpdateRequestStatus(UpdateRequestStatus model)
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


                    ExResourcerequest exResourcerequest = _repositorycontext.ExResourcerequests.Where(x => x.ReqId == model.reqid).FirstOrDefault();
                    exResourcerequest.Status = model.status;
                    exResourcerequest.Mngrstatus = model.status;
                    exResourcerequest.UpdatedBy = model.USERLOGNID;
                    exResourcerequest.UpdatedOn = DateTime.Now; ;
                    _repositorycontext.ExResourcerequests.Update(exResourcerequest);
                    _repositorycontext.SaveChanges(); 

                    response.Status = true;
                    response.Message = "Update Sucessfully";
                    response.Data = "";
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


    }
}

