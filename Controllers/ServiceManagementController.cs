using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ResourceRequestService.Data;
using ResourceRequestService.Helpers;
using ResourceRequestService.Models.Repository;
using ResourceRequestService.Models.ServiceManagement;
//using Rest;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ResourceRequestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceManagementController : Controller
    {
        private readonly RepositoryDbContext _repositorycontext;
        private readonly EDMDbContext _edmdbcontext;
        private readonly ServiceManagementDbContext _servicemanagementdbcontext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        //public IConfiguration Configuration { get; }
        public ServiceManagementController(IHttpContextAccessor httpContextAccessor, IMapper mapper, RepositoryDbContext repositorycontext, EDMDbContext edmrepositorycontext, ServiceManagementDbContext serviceManagementDbContext)
        {
            _httpContextAccessor = httpContextAccessor;

            _mapper = mapper;
            _repositorycontext = repositorycontext;
            _edmdbcontext = edmrepositorycontext;
            _servicemanagementdbcontext = serviceManagementDbContext;
        }

        [HttpGet("GetMaster")]
        public IActionResult GetMaster()
        {
            Response response = new();
            try
            {
                //List<AdminGetRole> listAdminGetRole = new List<AdminGetRole>();

                var ProjectNameMaster = (from p in _servicemanagementdbcontext.ExProjectMasters
                                  where p.ProjStatus=="A"
                                  orderby p.ProjName
                                         select new
                                  {
                                      value = p.ProjId,
                                      label = p.ProjName
                                  }).ToList();

                var RequestTypeMaster = (from p in _servicemanagementdbcontext.ExRequestTypes
                                         where p.Status == "A"
                                         orderby p.RequestType
                                         select new
                                         {
                                             value = p.ReqTypeId,
                                             label = p.RequestType
                                         }).ToList();

                var PriorityMaster = (from p in _servicemanagementdbcontext.ExPriorityMasters
                                         where p.Status == "A"
                                         orderby p.Priority
                                         select new
                                         {
                                             value = p.PriorityId,
                                             label = p.Priority
                                         }).ToList();

                var StatusMaster = (from p in _servicemanagementdbcontext.ExStatusMasters
                                      where p.Status == "A"
                                      orderby p.TranStatus
                                      select new
                                      {
                                          value = p.StatusId,
                                          label = p.TranStatus
                                      }).ToList();

                Dictionary<string, object> dList = new Dictionary<string, object>();

                dList.Add("ProjectNameMaster", ProjectNameMaster);
                dList.Add("RequestTypeMaster", RequestTypeMaster);
                dList.Add("PriorityMaster", PriorityMaster);
                dList.Add("StatusMaster", StatusMaster);
           
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
                    string path = Path.Combine("HelpDeskTicketDocuments");

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
                           "HelpDeskTicketDocuments", filename);

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
        }

        [HttpPost("SaveHelpdeskTicket")]
        public IActionResult SaveHelpdeskTicket(SaveHelpdeskTicket model)
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

                    ExRequesttran exRequestType = new ExRequesttran();
                    exRequestType.ProjId = model.ProjID;
                    exRequestType.ReqTypeId = model.ReqTypeID;
                    exRequestType.PriorityId = model.PriorityID;
                    exRequestType.TranDesc = model.TranDesc;
                    exRequestType.TranComments=model.TranComments;
                    exRequestType.TranAttachFileName    = model.TranAttachFileName;
                    exRequestType.TranRequestor = model.TranRequestor;
                    exRequestType.TranRaiseOn = DateTime.Now;
                    exRequestType.TranRequestStatus = "3";
                    _servicemanagementdbcontext.ExRequesttrans.Add(exRequestType);
                    _servicemanagementdbcontext.SaveChanges();

                    kickmodel.nstatus = "Saved Successfully";

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

        [HttpGet("GetHelpdeskTicket/{pelogin}/{role}")]
        public IActionResult GetHelpdeskTicket(string pelogin, string role)
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

                    var ExRequesttrans = (from ipex in _servicemanagementdbcontext.ExRequesttrans select ipex).ToList();
                    var ExProjectMasters = (from ipex in _servicemanagementdbcontext.ExProjectMasters select ipex).ToList();
                    var ExRequestTypes = (from ipex in _servicemanagementdbcontext.ExRequestTypes select ipex).ToList();
                    var ExPriorityMasters = (from ipex in _servicemanagementdbcontext.ExPriorityMasters select ipex).ToList();
                    var ExStatusMasters = (from ipex in _servicemanagementdbcontext.ExStatusMasters select ipex).ToList();

                    Dictionary<string, object> dList = new Dictionary<string, object>();

                    if (role.ToUpper() == "ADMIN")
                    {
                        var request = (from p in ExRequesttrans
                                       join a in ExProjectMasters on p.ProjId equals a.ProjId into sc
                                       from a in sc.DefaultIfEmpty()
                                       join b in ExRequestTypes on p.ReqTypeId equals b.ReqTypeId into sc1
                                       from b in sc1.DefaultIfEmpty()
                                       join c in ExPriorityMasters on p.PriorityId equals c.PriorityId into sc2
                                       from c in sc2.DefaultIfEmpty()
                                       join d in ippersonlist on p.TranRequestor equals d.PeLogn into sc4
                                       from d in sc4.DefaultIfEmpty()
                                       join e in ippersonlist on p.TranActionBy equals e.PeLogn into sc5
                                       from e in sc5.DefaultIfEmpty()
                                       join f in ExStatusMasters on p.TranRequestStatus equals f.StatusId.ToString() into sc6
                                       from f in sc6.DefaultIfEmpty()
                                       orderby p.TranId
                                            select new
                                            {
                                                TranId = p.TranId,
                                                ProjName = a.ProjName,
                                                RequestType = b.RequestType,
                                                Priority = c.Priority,
                                                TranDesc =  p.TranDesc,
                                                TranComments = p.TranComments,
                                                TranAttachFileName= p.TranAttachFileName,
                                                TranRequestor = d!=null ? d.PeName :"",
                                                TranRaiseOn = p.TranRaiseOn.Value.ToString("yyyy-MM-dd"),
                                                TranActionBy= e != null ? e.PeName : "",
                                                TranActionOn = p.TranActionOn !=null ? p.TranActionOn.Value.ToString("yyyy-MM-dd") : null,
                                                EngineerComments = p.EngineerComments  !=null ? p.EngineerComments :"",
                                                TranRequestStatus = f!=null ? f.TranStatus : null
                                            }).Distinct().ToList(); 
                        dList.Add("request", request); 
                    }
                    else
                    {
                        var request = (from p in ExRequesttrans
                                       join a in ExProjectMasters on p.ProjId equals a.ProjId into sc
                                       from a in sc.DefaultIfEmpty()
                                       join b in ExRequestTypes on p.ReqTypeId equals b.ReqTypeId into sc1
                                       from b in sc1.DefaultIfEmpty()
                                       join c in ExPriorityMasters on p.PriorityId equals c.PriorityId into sc2
                                       from c in sc2.DefaultIfEmpty()
                                       join d in ippersonlist on p.TranRequestor equals d.PeLogn into sc4
                                       from d in sc4.DefaultIfEmpty()
                                       join e in ippersonlist on p.TranActionBy equals e.PeLogn into sc5
                                       from e in sc5.DefaultIfEmpty()
                                       join f in ExStatusMasters on p.TranRequestStatus equals f.StatusId.ToString() into sc6
                                       from f in sc6.DefaultIfEmpty()
                                       where p.TranRequestor.ToUpper() == pelogin.ToUpper()
                                       orderby p.TranId
                                       select new
                                       {
                                           TranId = p.TranId,
                                           ProjName = a.ProjName,
                                           RequestType = b.RequestType,
                                           Priority = c.Priority,
                                           TranDesc = p.TranDesc,
                                           TranComments = p.TranComments,
                                           TranAttachFileName = p.TranAttachFileName,
                                           TranRequestor = d != null ? d.PeName : "",
                                           TranRaiseOn = p.TranRaiseOn.Value.ToString("yyyy-MM-dd"),
                                           TranActionBy = e != null ? e.PeName : "",
                                           TranActionOn = p.TranActionOn != null ? p.TranActionOn.Value.ToString("yyyy-MM-dd") : null,
                                           EngineerComments = p.EngineerComments != null ? p.EngineerComments : "",
                                           TranRequestStatus = f != null ? f.TranStatus : null
                                       }).Distinct().ToList();
                        dList.Add("request", request);
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

        [HttpPost("UpdateHelpdeskTicket")]
        public IActionResult UpdateHelpdeskTicket(UpdateHelpdeskTicket model)
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

                    ExRequesttran exRequesttran = _servicemanagementdbcontext.ExRequesttrans.Where(x => x.TranId == model.TranID).FirstOrDefault();
                    exRequesttran.TranRequestStatus = model.TranRequestStatus.ToString();
                    exRequesttran.TranActionBy = model.TranActionBy;
                    exRequesttran.TranActionOn = DateTime.Now;
                    exRequesttran.EngineerComments = model.EngineerComments;
                    _servicemanagementdbcontext.ExRequesttrans.Update(exRequesttran);

                    _servicemanagementdbcontext.SaveChanges();

                    kickmodel.nstatus = "Update Successfully";

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


        [HttpPost("SaveProjectLogs")]
        public IActionResult SaveProjectLogs(SaveProjectLogs model)
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

                    ExAccessLog exAccessLog = new ExAccessLog();
                    exAccessLog.ProjectId = model.ProjectID;
                    exAccessLog.UserPelogn = model.UserPelogn;
                    exAccessLog.Entrystamp = DateTime.Now;
                    _servicemanagementdbcontext.ExAccessLogs.Add(exAccessLog);
                    _servicemanagementdbcontext.SaveChanges(); 

                    kickmodel.nstatus = "Saved Successfully";

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
