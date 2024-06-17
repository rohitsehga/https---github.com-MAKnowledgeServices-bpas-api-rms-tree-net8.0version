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
    public class DashboardController : Controller
    {
        private readonly RepositoryDbContext _repositorycontext;
        private readonly EDMDbContext _edmdbcontext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public DashboardController(IHttpContextAccessor httpContextAccessor, IMapper mapper, RepositoryDbContext repositorycontext, EDMDbContext edmrepositorycontext)
        {
            _httpContextAccessor = httpContextAccessor;

            _mapper = mapper;
            _repositorycontext = repositorycontext;
            _edmdbcontext = edmrepositorycontext;
        } 

        [HttpGet("GetTotalHCForKPI/{pelogin}")]
        public IActionResult GetTotalHCForKPI(string pelogin)
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

                    var result = (from b in ExResourceassignmentstatuses
                                  join c in IpPersonList
                                  on new
                                  { User = b != null ? b.PeLogn : "" }
                   equals new { User = c != null ? c.PeLogn : "" } into sc21
                                  from c in sc21.DefaultIfEmpty()
                                      //join c in IpPersonList on b.PeLogn equals c.PeLogn into sc
                                      //from c in sc.DefaultIfEmpty()
                                  join d in IPCustomerlist1
                            on new
                            { cuiden = b != null ? b.CuIden.ToString() : "" }
             equals new { cuiden = d != null ? d.CuIden.ToString() : "" } into sc22
                                  from d in sc22.DefaultIfEmpty()
                                      //join d in IPCustomerlist1 on b.CuIden equals d.CuIden into sc1
                                      //from d in sc1.DefaultIfEmpty()
                                  join e in IPElementList
                                   on new
                                   { Dept = c != null ? c.PeDept : "" }
                    equals new { Dept = e != null ? e.ElCode : "" } into sc2
                                  from e in sc2.DefaultIfEmpty() 
                                  where b.Enddate==null  
                                  //orderby b != null ? b.PeName : ""
                                  select new
                                  {
                                      PeName = c != null ? c.PeName : "",
                                      CuComp = d != null ? d.CuComp : "",
                                      PeDept= c != null ?  c.PeDept : "",
                                      Email = c != null ? c.PeMail : "",
                                      ElName = e != null ?  e.ElName : "",
                                      PeLogn = b != null ? b.PeLogn : "",
                                      CuIden= b != null ? b.CuIden.ToString() : "", 
                                      KickOffDate = b != null ?  b.KickOff.ToString("yyyy-MM-dd") : ""

                                  }).Distinct().ToList();

                    result = result.Where(x => x.PeDept == dept && x.CuComp !=null && x.CuComp != "").ToList();

                    dList.Add("Table", result);

                }
                else if (role == "EMGR")
                {
                    var IPCustomerlist2 = (from a in _repositorycontext.ExIpcustomerOthers
                                           join b in _repositorycontext.IpCustomers on a.CuIden equals b.CuIden
                                           where a.Role.ToUpper() == "EMGR" && a.Enddate == null && a.PeLogn == pelogin && a.Status == "A"
                                           select b.CuIden.ToString()).ToList(); 

                    var result = ( from b in ExResourceassignmentstatuses  
                                  join c in IpPersonList on b.PeLogn equals c.PeLogn into sc
                                  from c in sc.DefaultIfEmpty()
                                  join d in IPCustomerlist on b.CuIden equals d.CuIden into sc1
                                  from d in sc1.DefaultIfEmpty()
                                  join e in IPElementList
                                   on new
                                   { Dept = c != null ? c.PeDept : "" }
                    equals new { Dept = e != null ? e.ElCode : "" } into sc2
                                  from e in sc2.DefaultIfEmpty()
                                
                              
                                  where b.Enddate==null     && IPCustomerlist2.Contains(b.CuIden.ToString())  
                                  //orderby b != null ? b.PeName : ""
                                  select new
                                  {
                                      PeName = c != null ? c.PeName : "",
                                      CuComp = d != null ? d.CuComp : "",
                                      PeDept = c != null ? c.PeDept : "",
                                      Email = c != null ? c.PeMail : "",
                                      ElName = e != null ? e.ElName : "",
                                      PeLogn = b != null ? b.PeLogn : "",
                                      CuIden = b != null ? b.CuIden.ToString() : "",
                                      KickOffDate = b != null ? b.KickOff.ToString("yyyy-MM-dd") : ""

                                  }).Distinct().ToList();

                    dList.Add("Table", result);



                }
                else if (role == "PMO")
                {
                    var ServiceLineList = (from a in _repositorycontext.ExAccessMasters
                                           where a.Role.ToUpper() == "PMO" && a.Enddate == null && a.PeLogn == pelogin && a.Status == "A"
                                           select a.ServiceLine).ToList();

                    var result = (from b in ExResourceassignmentstatuses  
                                  join c in IpPersonList on b.PeLogn equals c.PeLogn into sc
                                  from c in sc.DefaultIfEmpty()
                                  join d in IPCustomerlist on b.CuIden equals d.CuIden into sc1
                                  from d in sc1.DefaultIfEmpty()
                                  join e in IPElementList
                                   on new
                                   { Dept = c != null ? c.PeDept : "" }
                    equals new { Dept = e != null ? e.ElCode : "" } into sc2
                                  from e in sc2.DefaultIfEmpty() 

                                  where b.Enddate == null /*&& ServiceLineList.Contains(c.PeDept)  */
                                  //orderby b != null ? b.PeName : ""
                                  select new
                                  {
                                      PeName = c != null ? c.PeName : "",
                                      CuComp = d != null ? d.CuComp : "",
                                      PeDept = c != null ? c.PeDept : "",
                                      Email = c != null ? c.PeMail : "",
                                      ElName = e != null ? e.ElName : "",
                                      PeLogn = b != null ? b.PeLogn : "",
                                      CuIden = b != null ? b.CuIden.ToString() : "",
                                      KickOffDate = b != null ? b.KickOff.ToString("yyyy-MM-dd") : ""
                                  }).Distinct().ToList();

                    result = result.Where(x => ServiceLineList.Contains(x.PeDept)  && x.CuIden.ToString() !="85").ToList();

                    dList.Add("ServiceLineList", ServiceLineList);
                    dList.Add("Table", result);
                    



                }

                else if (role == "PL")
                {
                    var ServiceLineList = (from a in _repositorycontext.ExClientPlOwners
                                           where a.Enddate == null && a.PeLogn == pelogin && a.Status == "A"
                                           select a.ServiceLine).ToList();

                    var result = (from b in ExResourceassignmentstatuses
                                  join c in IpPersonList on b.PeLogn equals c.PeLogn into sc
                                  from c in sc.DefaultIfEmpty()
                                  join d in IPCustomerlist on b.CuIden equals d.CuIden into sc1
                                  from d in sc1.DefaultIfEmpty()
                                  join e in IPElementList
                                   on new
                                   { Dept = c != null ? c.PeDept : "" }
                    equals new { Dept = e != null ? e.ElCode : "" } into sc2
                                  from e in sc2.DefaultIfEmpty()

                                  where b.Enddate == null /*&& ServiceLineList.Contains(c.PeDept)  */
                                  //orderby b != null ? b.PeName : ""
                                  select new
                                  {
                                      PeName = c != null ? c.PeName : "",
                                      CuComp = d != null ? d.CuComp : "",
                                      PeDept = c != null ? c.PeDept : "",
                                      Email = c != null ? c.PeMail : "",
                                      ElName = e != null ? e.ElName : "",
                                      PeLogn = b != null ? b.PeLogn : "",
                                      CuIden = b != null ? b.CuIden.ToString() : "",
                                      KickOffDate = b != null ? b.KickOff.ToString("yyyy-MM-dd") : ""
                                  }).Distinct().ToList();

                    result = result.Where(x => ServiceLineList.Contains(x.PeDept) && x.CuIden.ToString() != "85").ToList();
                   
                    dList.Add("ServiceLineList", ServiceLineList);
                    dList.Add("Table", result);
                    



                }
                else
                {
                    var ServiceLineList = (from a in IpPersonList
                                          //join b in _repositorycontext.IpCustomers on a.CuIden equals b.CuIden
                                          where a.PeQuit is null
                                          select a.PeDept).Distinct().ToList();

                    var result = (from b in ExResourceassignmentstatuses
                                  join c in IpPersonList on b.PeLogn equals c.PeLogn into sc
                                  from c in sc.DefaultIfEmpty()
                                  join d in IPCustomerlist on b.CuIden equals d.CuIden into sc1
                                  from d in sc1.DefaultIfEmpty()
                                  join e in IPElementList
                                   on new
                                   { Dept = c != null ? c.PeDept : "" }
                    equals new { Dept = e != null ? e.ElCode : "" } into sc2
                                  from e in sc2.DefaultIfEmpty()

                                  where b.Enddate == null /*&& ServiceLineList.Contains(c.PeDept)  */
                                  //orderby b != null ? b.PeName : ""
                                  select new
                                  {
                                      PeName = c != null ? c.PeName : "",
                                      CuComp = d != null ? d.CuComp : "",
                                      PeDept = c != null ? c.PeDept : "",
                                      Email = c != null ? c.PeMail : "",
                                      ElName = e != null ? e.ElName : "",
                                      PeLogn = b != null ? b.PeLogn : "",
                                      CuIden = b != null ? b.CuIden.ToString() : "",
                                      KickOffDate = b != null ? b.KickOff.ToString("yyyy-MM-dd") : ""
                                  }).Distinct().ToList(); 


                    dList.Add("ServiceLineList", ServiceLineList);
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

        [HttpGet("GetServiceLine/{pelogin}")]
        public IActionResult GetServiceLine(string pelogin)
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
                //var ExResourceassignmentstatuses = (from a in _repositorycontext.ExResourceassignmentstatuses select a).ToList();
                //var ExResourceassignment = (from a in _repositorycontext.ExResourceassignments select a).ToList();
                //var IPCustomerlist = (from a in _repositorycontext.IpCustomers select a).ToList();
                //var ChecklistList = (from a in _repositorycontext.ExResourceassignmentChecklists select a).ToList();
                var IpPersonList = (from a in _edmdbcontext.IpPeople where a.PeQuit == null select a).ToList();
                var IPElementList = (from a in _edmdbcontext.IpElements select a).ToList();
                var IpLocationsList = (from a in _edmdbcontext.IpLocations select a).ToList();
                var ExAccessMasters = (from a in _repositorycontext.ExAccessMasters select a).ToList();
                var ExClientPlOwners = (from a in _repositorycontext.ExClientPlOwners select a).ToList();
                //DateTime todaydate = DateTime.Now;
                //var ITchecklistid = "7";


                if (role == "PMO")
                {
                    var ServiceLineList = (from a in ExAccessMasters
                                           join b in IPElementList on a.ServiceLine equals b.ElCode
                                           where a.Role.ToUpper() == "PMO" && a.Enddate == null && a.PeLogn == pelogin && a.Status == "A"
                                           select new
                                           {
                                               value = a.ServiceLine,
                                               label = b.ElName
                                           }).Distinct().ToList();
                    //select a.ServiceLine).ToList();  

                    dList.Add("ServiceLineList", ServiceLineList); 

                }

                else if (role == "PL")
                {
                    var ServiceLineList = (from a in ExClientPlOwners
                                           join b in IPElementList on a.ServiceLine equals b.ElCode
                                           where a.Enddate == null && a.PeLogn == pelogin && a.Status == "A"
                                           select new
                                           {
                                               value = a.ServiceLine,
                                               label = b.ElName
                                           }).Distinct().ToList();
                    //select a.ServiceLine).ToList();  

                    dList.Add("ServiceLineList", ServiceLineList); 

                }
                else if (role.ToUpper() == "ADMIN")
                {
                  
                    var ServiceLineList = (from p in IpPersonList
                                        join a in IPElementList on p.PeDept equals a.ElCode
                                        where p.PeQuit is null && a.CaCode =="LOB" && a.ElCode.ToUpper() !="CBL"
                                        orderby a.ElName
                                        select new
                                        {
                                           value= p.PeDept,
                                           label= a.ElName
                                        }).Distinct().ToList(); 

                    dList.Add("ServiceLineList", ServiceLineList); 
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

        [HttpGet("GetKPIforOnboard/{pelogin}")]
        public IActionResult GetKPIforOnboard(string pelogin)
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

                //var ServiceLineList = (from a in IpPersonList
                //                           //join b in _repositorycontext.IpCustomers on a.CuIden equals b.CuIden
                //                       where a.PeQuit is null
                //                       select a.PeDept).Distinct().ToList();

                //             (from a in IpPersonList
                //              join c in IpPersonList on b.PeLogn equals c.PeLogn into sc
                //              from c in sc.DefaultIfEmpty()
                //              join d in IPCustomerlist on b.CuIden equals d.CuIden into sc1
                //              from d in sc1.DefaultIfEmpty()
                //              join e in IPElementList
                //               on new
                //               { Dept = c != null ? c.PeDept : "" }
                //equals new { Dept = e != null ? e.ElCode : "" } into sc2
                //              from e in sc2.DefaultIfEmpty()



                var lobHC = (from b in ExResourceassignmentstatuses
                              join c in IpPersonList on b.PeLogn equals c.PeLogn into sc
                              from c in sc.DefaultIfEmpty()
                              join d in IPCustomerlist on b.CuIden equals d.CuIden into sc1
                              from d in sc1.DefaultIfEmpty()
                              join e in IPElementList
                               on new
                               { Dept = c != null ? c.PeDept : "" }
                equals new { Dept = e != null ? e.ElCode : "" } into sc2
                              from e in sc2.DefaultIfEmpty()

                              where b.Enddate == null /*&& ServiceLineList.Contains(c.PeDept)  */
                             //orderby c.PeName
                              select new
                              {
                                  PeName = c != null ? c.PeName : "",
                                  CuComp = d != null ? d.CuComp : "",
                                  PeDept = c != null ? c.PeDept : "",
                                  Email = c != null ? c.PeMail : "",
                                  ElName = e != null ? e.ElName : "",
                                  PeLogn = b != null ? b.PeLogn : "",
                                  CuIden = b != null ? b.CuIden.ToString() : "",
                                  KickOffDate = b != null ? b.KickOff.ToString("yyyy-MM-dd") : ""
                              }).Distinct().ToList();

                lobHC = lobHC.Where(x => x.PeDept==dept).ToList(); 

                var data21 = (from a in _repositorycontext.ExResourceassignmentstatuses
                              select a).ToList();
                var ippersonlist1 = (from ipex in _edmdbcontext.IpPeople where ipex.PeQuit == null select ipex).ToList();
                var emplist = (from ipex in _edmdbcontext.ExIppeople where ipex.QuitDateTemp == null select ipex).ToList();

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
                                             PeDept = b1 != null ? b1.PeDept : "NA"
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
                                              where filterdata.Contains(a.PeLogn) && b2.Enddate == null && b2.CuIden == 85 && b2.Status == "B"
                                              orderby b2.Startdate
                                              select new
                                              {
                                                  value = a.PeLogn,
                                                  label = a.PeName.ToUpper() + " (" + b1.WwPersonId + ")",
                                                  Startdate = b2.Startdate != null ? b2.Startdate.ToString("yyyy-MM-dd") : null
                                              }).Distinct().ToList();

                List<LOBHC> lOBHCs = new List<LOBHC>();

                var row1col1 = (from s in _edmdbcontext.IpPeople
                                where s.PeQuit == null && s.PeDept==dept
                                select new
                                {
                                    s.PeLogn
                                }
                          ).Count();

                dList.Add("LobListBenchResource", ListBenchResourceFinal);

                dList.Add("lobHC", lobHC);

                dList.Add("lobHCCount", row1col1);


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

        // For Client Count We use Client Controller and for Client People details we use from onboardand offbaord controller
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
