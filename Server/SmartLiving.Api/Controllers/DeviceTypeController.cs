using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SmartLiving.Api.Middleware;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Supervisors.Interfaces;

namespace SmartLiving.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Authorize]
    public class DeviceTypeController : BaseController
    {
        private readonly ISupervisor _supervisor;

        public DeviceTypeController(ISupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        //GET: api/Device/GetAllDeviceTypes
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<DeviceTypeGetDto>> GetAllDevices()
        {
            try
            {
                var allItems = _supervisor.GetAllDeviceTypes(CurrentUser.Id);

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
