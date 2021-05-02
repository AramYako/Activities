using Domain;
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

        public ActivitiesController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActitivites()
        {
            return await this._context.Activities.ToListAsync();
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Activity>> GetActitivites(Guid Id)
        {
            return await this._context.Activities.FindAsync(Id);
        }
    }
}
