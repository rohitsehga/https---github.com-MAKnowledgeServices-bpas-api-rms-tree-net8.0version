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

namespace ResourceRequestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryBuilder : Controller
    {
        private readonly RepositoryDbContext _repositorycontext;
        private readonly EDMDbContext _edmdbcontext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public QueryBuilder(IHttpContextAccessor httpContextAccessor, IMapper mapper, RepositoryDbContext repositorycontext, EDMDbContext edmrepositorycontext)
        {
            _httpContextAccessor = httpContextAccessor;

            _mapper = mapper;
            _repositorycontext = repositorycontext;
            _edmdbcontext = edmrepositorycontext;
        }
        [HttpGet("GetMaster")]
        public IActionResult GetMaster()
        {
            Response response = new();
            try
            {
                //List<AdminGetRole> listAdminGetRole = new List<AdminGetRole>();

                var QueryBuilderColumns = (from p in _repositorycontext.ExQueryBuilderColumns
                                  where p.Status=="A"
                                  orderby p.ReportColumn 
                                  select new
                                  {
                                      Sqlcolumn = p.Sqlcolumn,
                                      ReportColumn = p.ReportColumn,
                                      ColumnDatatype = p.ColumnDatatype,
                                      label = p.ReportColumn,
                                      value = p.Sqlcolumn
                                  }).ToList(); 

                Dictionary<string, object> dList = new Dictionary<string, object>();
                dList.Add("QueryBuilderColumns", QueryBuilderColumns);
               


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
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
