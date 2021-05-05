using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;

        public ActivitiesController()
        {

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActitivites()
        {
            return await Mediator.Send(new List.Query());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Activity>> GetActitivites(Guid Id)
        {
            return await Mediator.Send(new Details.Query {Id = Id });
        }

        [HttpPost]
        public async Task<ActionResult> CreateActivity(Activity activity)
        {
            return Ok(await this.Mediator.Send(new Create.Command { Activity = activity }));
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> EditActivity(Guid Id, Activity activity)
        {
            activity.Id = Id;

            return Ok(await this.Mediator.Send(new Edit.Command { Activity = activity }));
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteActivity(Guid Id)
        {
            return Ok(await this.Mediator.Send(new Delete.Command { Id = Id }));
        }
    }
}
