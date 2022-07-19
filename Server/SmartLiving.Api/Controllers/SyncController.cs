using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SmartLiving.Domain.Models;
using SmartLiving.Domain.Supervisors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartLiving.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class SyncController : BaseController
    {
        private readonly ISupervisor _supervisor;

        public SyncController(ISupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        //GET: api/User/GetAllUsers()
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<UserModel>> GetAllUsers()
        {
            try
            {
                var allItems = _supervisor.GetAllUsers();

                if (allItems.Any())
                    return Ok(allItems);
                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}
