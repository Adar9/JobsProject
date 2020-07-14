using JobBoardModels.Context;
using JobBoardModels.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoardCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public JobController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Job>> Get()
        {
            return context.Jobs.ToList();
        }

        [HttpGet("{JobId}", Name = "GetJob")]
        public ActionResult<Job> Get(int JobId)
        {
            var job = context.Jobs.FirstOrDefault(x => x.JobId == JobId);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Job job)
        {
            context.Jobs.Add(job);
            context.SaveChanges();
            //return new CreatedAtRouteResult("GetJob", new { JobId = job.JobId}, job);
            return Ok();
        }

        [HttpPut("{JobId}")]
        public ActionResult Put(int JobId, [FromBody] Job value)
        {
            if (JobId != value.JobId)
            {
                return BadRequest();
            }

            context.Entry(value).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{JobId}")]
        public ActionResult<Job> Delete(int JobId)
        {
            var job = context.Jobs.FirstOrDefault(x => x.JobId == JobId);

            if (job == null)
            {
                return NotFound();
            }

            context.Jobs.Remove(job);
            context.SaveChanges();
            return job;
        }
    }
}
