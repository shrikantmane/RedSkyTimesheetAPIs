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
    public class TasksController : ApiController
    {
        TasksOperations objTasksOperations = new TasksOperations();

        [Authorize]
        [HttpGet]
        [Route("api/Tasks")]
        public IHttpActionResult Get()
        {
            return Ok(objTasksOperations.Tasks(Constants.SiteUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/Tasks/{id}")]
        public IHttpActionResult Get(string id)
        {
            return Ok(objTasksOperations.TaskByID(id, Constants.SiteUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/Tasks/TasksByPhaseID/{id}")]
        public IHttpActionResult TasksByPhaseID(string id)
        {
            return Ok(objTasksOperations.TasksByPhaseID(id, Constants.SiteUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/Tasks/TasksByPhaseName/{projectName}")]
        public IHttpActionResult TasksByPhaseName(string projectName)
        {
            return Ok(objTasksOperations.TasksByPhaseName(projectName, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/Tasks/Create")]
        public IHttpActionResult Post(Tasks objTask)
        {
            return Ok(objTasksOperations.AddTask(objTask, Constants.SiteUrl));
        }

        [Authorize]
        [HttpPost]
        [Route("api/Tasks/Update")]
        public IHttpActionResult UpdateTask(Tasks objTask)
        {
            return Ok(objTasksOperations.UpdateTask(objTask, Constants.SiteUrl));
        }
    }
}
