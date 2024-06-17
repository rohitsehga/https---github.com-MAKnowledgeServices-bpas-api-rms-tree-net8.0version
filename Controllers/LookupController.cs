using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ResourceRequestService.Helpers;

namespace ResourceRequestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LookupController : ControllerBase
    {
        private readonly IOptions<Connection> _connections;
        public IConfiguration Configuration { get; }

        public LookupController(IOptions<Connection> connections, IConfiguration configuration)
        {
            Configuration = configuration;
            _connections = connections;
        }


        [HttpPost("request")]
        public IActionResult LookupCall(StoredProcdure storedProcedure)
        {
            Response response = new();
            if (storedProcedure is null)
            {
                response.Status = false;
                response.Message = "Store Procedure details required";
                response.Data = "";
                response.Error = "";
                return Ok(response);
            }
            ADO sql = new();
            if (storedProcedure.ProviderName.ToUpper() == "EMPLOYEE")
            {
                response = sql.CallStoreProcedure(_connections.Value.Employee, storedProcedure.ProcedureName, storedProcedure.Params);
            }
            else if (storedProcedure.ProviderName.ToUpper() == "RESOURCE")
            {
                response = sql.CallStoreProcedure(_connections.Value.Resource, storedProcedure.ProcedureName, storedProcedure.Params);
            }
            else if (storedProcedure.ProviderName.ToUpper() == "AMBA")
            {
                response = sql.CallStoreProcedure(_connections.Value.Amba, storedProcedure.ProcedureName, storedProcedure.Params);
            }
            else if (storedProcedure.ProviderName.ToUpper() == "CANDIDATE")
            {
                response = sql.CallStoreProcedure(_connections.Value.Candidate, storedProcedure.ProcedureName, storedProcedure.Params);
            }
            else if (storedProcedure.ProviderName.ToUpper() == "REPOSITORY")
            {
                response = sql.CallStoreProcedure(_connections.Value.Repository, storedProcedure.ProcedureName, storedProcedure.Params);
            }
            else
            {
                response.Status = false;
                response.Message = "Invalid Provider name";
                response.Data = "";
                response.Error = "";
            }
            return Ok(response);
        }

        [HttpPost("CallStorProc")]
        public IActionResult CallStoredProcedure(StoredProcdure storedProcedure)
        {
            Response response = new();
            if (storedProcedure is null)
            {
                response.Status = false;
                response.Message = "Store Procedure details required";
                response.Data = "";
                response.Error = "";
                return Ok(response);
            }
            ADO sql = new();
            if (storedProcedure.ProviderName.ToUpper() == "EDMREPOSITORY")
            {
                response = sql.CallStoreProcedure(_connections.Value.Employee, storedProcedure.ProcedureName, storedProcedure.Params);
            }
            //else if (storedProcedure.ProviderName.ToUpper() == "RESOURCE")
            //{
            //    response = sql.CallStoreProcedure(_connections.Value.Resource, storedProcedure.ProcedureName, storedProcedure.Params);
            //}
            //else if (storedProcedure.ProviderName.ToUpper() == "AMBA")
            //{
            //    response = sql.CallStoreProcedure(_connections.Value.Amba, storedProcedure.ProcedureName, storedProcedure.Params);
            //}
            //else if (storedProcedure.ProviderName.ToUpper() == "CANDIDATE")
            //{
            //    response = sql.CallStoreProcedure(_connections.Value.Candidate, storedProcedure.ProcedureName, storedProcedure.Params);
            //}
            else if (storedProcedure.ProviderName.ToUpper() == "REPOSITORY")
            {
                response = sql.CallStoreProcedure(_connections.Value.Repository, storedProcedure.ProcedureName, storedProcedure.Params);
            }
            //else if (storedProcedure.ProviderName.ToUpper() == "ANALYSIS")
            //{
            //    response = sql.CallStoreProcedure(_connections.Value.Analysis, storedProcedure.ProcedureName, storedProcedure.Params);
            //}
            else
            {
                response.Status = false;
                response.Message = "Invalid Provider name";
                response.Data = "";
                response.Error = "";
            }
            return Ok(response);
        }

        [HttpPost("CallStorProcNew")]
        [EnableCors("MyPolicy")]
        public IActionResult CallStoredProcedureNew(StoredProcdure storedProcedure)
        {
            Response response = new();
            if (storedProcedure is null)
            {
                response.Status = false;
                response.Message = "Store Procedure details required";
                response.Data = "";
                response.Error = "";
                return Ok(response);
            }
            ADO sql = new();
            if (storedProcedure.ProviderName.ToUpper() == "EDMREPOSITORY")
            {
                response = sql.CallStoreProcedureNew(_connections.Value.Employee, storedProcedure.ProcedureName, storedProcedure.Params);
            }
            //else if (storedProcedure.ProviderName.ToUpper() == "RESOURCE")
            //{
            //    response = sql.CallStoreProcedureNew(_connections.Value.Resource, storedProcedure.ProcedureName, storedProcedure.Params);
            //}
            //else if (storedProcedure.ProviderName.ToUpper() == "AMBA")
            //{
            //    response = sql.CallStoreProcedureNew(_connections.Value.Amba, storedProcedure.ProcedureName, storedProcedure.Params);
            //}
            //else if (storedProcedure.ProviderName.ToUpper() == "CANDIDATE")
            //{
            //    response = sql.CallStoreProcedureNew(_connections.Value.Candidate, storedProcedure.ProcedureName, storedProcedure.Params);
            //}
            else if (storedProcedure.ProviderName.ToUpper() == "REPOSITORY")
            {
                string drive = Configuration.GetValue<string>("ConnectionStrings:Repository");

                response = sql.CallStoreProcedureNew(drive, storedProcedure.ProcedureName, storedProcedure.Params);
            }
            //else if (storedProcedure.ProviderName.ToUpper() == "ANALYSIS")
            //{
            //    response = sql.CallStoreProcedureNew(_connections.Value.Analysis, storedProcedure.ProcedureName, storedProcedure.Params);
            //}
            else
            {
                response.Status = false;
                response.Message = "Invalid Provider name";
                response.Data = "";
                response.Error = "";
            }
            return Ok(response);
        }
    }
    //public class LookupController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }
    //}
}
