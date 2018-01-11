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
    [Route("api/Projects")]
    public class ProjectsController : ApiController
    {
        ProjectOperations objProjetOperations = new ProjectOperations();

        [Authorize]
        [HttpGet]
        [Route("api/Projects")]
        public IHttpActionResult Get()
        {
            return Ok(objProjetOperations.Projects(Constants.SiteUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/Projects/{id}")]
        public IHttpActionResult Get(string id)
        {
            return Ok(objProjetOperations.ProjectByID(id, Constants.SiteUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/Projects/GetProjecBytName/{name}")]
        public IHttpActionResult GetByProjectName(string name)
        {
            return Ok(objProjetOperations.ProjectByName(name, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/Projects/Create")]
        public IHttpActionResult Post(Projects objProject)
        {
            return Ok(objProjetOperations.AddProject(objProject, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/Projects/Update")]
        public IHttpActionResult UpdateProject(Projects objProject)
        {
            return Ok(objProjetOperations.UpdateProject(objProject, Constants.SiteUrl));
        }

    }
}
