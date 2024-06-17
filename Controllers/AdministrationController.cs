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

namespace ResourceRequestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationController : Controller
    {
        private readonly RepositoryDbContext _repositorycontext;
        private readonly EDMDbContext _edmdbcontext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        //public IConfiguration Configuration { get; }
        public AdministrationController(IHttpContextAccessor httpContextAccessor, IMapper mapper, RepositoryDbContext repositorycontext, EDMDbContext edmrepositorycontext)
        {
            _httpContextAccessor = httpContextAccessor;

            _mapper = mapper;
            _repositorycontext = repositorycontext;
            _edmdbcontext = edmrepositorycontext;
        }

        [HttpPost("SaveRequestRequestConfiguration")]
        public IActionResult SaveRequestRequestConfiguration(SaveRequestRequestConfiguration model)
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

                    ExGeneralParameterConfiguration exGeneralParameterConfiguration = _repositorycontext.ExGeneralParameterConfigurations.Where(x => x.ParameterId == 3).FirstOrDefault();
                    exGeneralParameterConfiguration.ParameterValue = model.status;
                    exGeneralParameterConfiguration.LastUpdatedBy = model.USERLOGNID;
                    exGeneralParameterConfiguration.LastUpdatedOn = DateTime.Now; ;
                    _repositorycontext.ExGeneralParameterConfigurations.Update(exGeneralParameterConfiguration);
                    _repositorycontext.SaveChanges();


                    response.Status = true;
                    response.Message = "Update Successfully";
                    response.Data = "Update Successfully";
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

        [HttpGet("GetConfiguration")] 
        public IActionResult GetConfiguration()
        {
            //USP_Get_List_Clients_For_MSA_SOW '26663'
            Response response = new();
            try
            { 
                {

                    var ParameterConfigurations = (from p in _repositorycontext.ExGeneralParameterConfigurations 
                                      select new
                                      {
                                          ParameterId = p.ParameterId,
                                          ParameterName = p.ParameterName,
                                          ParameterValue = p.ParameterValue
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


        [HttpGet("Getrolescreen/{role}")]
        public IActionResult Getrolescreen(string role)
        { 
            Response response = new();
            try
            {
                string message = string.Empty;
                if (String.IsNullOrEmpty(role))
                {
                    response.Status = false;
                    response.Message = "Role required";
                    response.Data = "";
                    response.Error = "Role required";
                    return Ok(response);
                }
                else
                {
                    int roleid = 0; 

                    roleid = (from a in _repositorycontext.ExIppersonRoleMasters
                              where a.RoleName == role
                              select a).Max(a => a.Id);

                    var screenmaster = (from p in _repositorycontext.ExIppersonRoleModuleMappings
                                        join b in _repositorycontext.ExIppersonModuleMasters on p.ModuleId equals b.Id into sb
                                        from b in sb.DefaultIfEmpty()
                                        where p.RoleId==roleid && p.Status=="A"
                                      select new
                                      {
                                          //ModuleId = p.ModuleId,
                                          //ModuleName = b.ModuleName,
                                          Screens = b.Screens
                                      }).Distinct().ToList();

                    response.Data = screenmaster;
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
