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

        //GET: api/Sync/GetAllUsers()
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

        //GET: api/Sync/GetUserById()
        [HttpGet("[action]/{id}")]
        public ActionResult<UserModel> GetUserById(string id)
        {
            try
            {
                var item = _supervisor.GetUserById(id);

                if (item != null)
                    return Ok(item);

                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //GET: api/Sync/GetHouseById()
        [HttpGet("[action]/{id}")]
        public ActionResult<HouseModel> GetHouseById(int id)
        {
            try
            {
                var item = _supervisor.GetHouseById(id);

                if (item != null)
                    return Ok(item);

                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //GET: api/Sync/GetAreaById()
        [HttpGet("[action]/{id}")]
        public ActionResult<AreaModel> GetAreaById(int id)
        {
            try
            {
                var item = _supervisor.GetAreaById(id);

                if (item != null)
                    return Ok(item);

                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //GET: api/Sync/GetDeviceById()
        [HttpGet("[action]/{id}")]
        public ActionResult<DeviceModel> GetDeviceById(int id)
        {
            try
            {
                var item = _supervisor.GetDeviceById(id);

                if (item != null)
                    return Ok(item);

                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}
