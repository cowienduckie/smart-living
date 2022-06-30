using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Supervisors.Interfaces;

namespace SmartLiving.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class DeviceController : BaseController
    {
        private readonly ISupervisor _supervisor;

        public DeviceController(ISupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        //GET: api/Product/GetAllDevices
        [HttpGet]
        public ActionResult<IEnumerable<DeviceGetDto>> GetAllDevices()
        {
            try
            {
                var allItems = _supervisor.GetAllDevices();

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
