using ESPL.RedSkyTimeSheet.BL.Operations.Masters;
using ESPL.RedSkyTimeSheet.Lists;
using ESPL.RedSkyTimeSheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ESPL.RedSkyTimeSheet.Controllers.Masters
{
    [Route("api/Phases")]
    public class EngagementsController : ApiController
    {
        EngagementOperations objPhasesOperations = new EngagementOperations();

        [Authorize]
        [HttpGet]
        [Route("api/Engagements")]
        public IHttpActionResult Get()
        {
            return Ok(objPhasesOperations.Engagements(Constants.SiteUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/Engagements/{id}")]
        public IHttpActionResult Get(string id)
        {
            return Ok(objPhasesOperations.EngagementByID(id, Constants.SiteUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/Engagements/GetEngagementByName/{name}")]
        public IHttpActionResult GetByEngagementName(string name)
        {
            return Ok(objPhasesOperations.EngagementByName(name, Constants.SiteUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/Engagements/EngagementsByProjectID/{id}")]
        public IHttpActionResult EngagementsByProjectID(string id)
        {
            return Ok(objPhasesOperations.EngagementsByProjectID(id, Constants.SiteUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/Engagements/EngagementsByProjectName/{projectName}")]
        public IHttpActionResult EngagementsByProjectName(string projectName)
        {
            return Ok(objPhasesOperations.EngagementsByProjectName(projectName, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/Engagements/Create")]
        public IHttpActionResult Post(Engagements objEngagement)
        {
            return Ok(objPhasesOperations.AddEngagement(objEngagement, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/Engagements/Update")]
        public IHttpActionResult UpdateProject(Engagements objEngagement)
        {
            return Ok(objPhasesOperations.UpdateEngagement(objEngagement, Constants.SiteUrl));
        }
    }
}
