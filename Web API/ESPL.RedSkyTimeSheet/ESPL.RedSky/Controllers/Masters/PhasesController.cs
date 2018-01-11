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
    public class PhasesController : ApiController
    {
        PhasesOperations objPhasesOperations = new PhasesOperations();

        [Authorize]
        [HttpGet]
        [Route("api/Phases")]
        public IHttpActionResult Get()
        {
            return Ok(objPhasesOperations.Phases(Constants.SiteUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/Phases/{id}")]
        public IHttpActionResult Get(string id)
        {
            return Ok(objPhasesOperations.PhaseByID(id, Constants.SiteUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/Phases/PhasesByProjectID/{id}")]
        public IHttpActionResult PhasesByProjectID(string id)
        {
            return Ok(objPhasesOperations.PhasesByProjectID(id, Constants.SiteUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/Phases/PhasesByProjectName/{name}")]
        public IHttpActionResult PhasesByProjectName(string name)
        {
            return Ok(objPhasesOperations.PhasesByProjectName(name, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/Phases/Create")]
        public IHttpActionResult Post(Phases objPhase)
        {
            return Ok(objPhasesOperations.AddPhase(objPhase, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/Phases/Update")]
        public IHttpActionResult UpdateProject(Phases objPhase)
        {
            return Ok(objPhasesOperations.UpdatePhase(objPhase, Constants.SiteUrl));
        }
    }
}
