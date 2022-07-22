using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SmartLiving.Api.Middleware;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Supervisors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartLiving.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Authorize]
    public class DeviceController : BaseController
    {
        private readonly ISupervisor _supervisor;

        public DeviceController(ISupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        //GET: api/Device/GetAllDevices
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<DeviceGetDto>> GetAllDevices()
        {
            try
            {
                var allItems = _supervisor.GetAllDevices(CurrentUser.Id);

                if (allItems.Any())
                    return Ok(allItems);
                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        ////GET: api/Device/GetPagedList
        //[HttpGet("[action]")]
        //public ActionResult<PagedList<DeviceGetDto>> GetPagedList(int pageIndex = 1, int pageSize = SystemConstants.PageSizeDefault)
        //{
        //    try
        //    {
        //        var devicePagedList = _supervisor.GetPagedList<DeviceGetDto>(_supervisor.GetAllDevices(CurrentUser.Id).ToList() ,pageIndex, pageSize);

        //        if (devicePagedList.Any())
        //            return Ok(devicePagedList);
        //        return NotFound();
        //    }
        //    catch (Exception e)
        //    {
        //        return HandleException(e);
        //    }
        //}

        //GET: api/Device/{id}
        [HttpGet("{id}", Name = "GetDeviceById")]
        public ActionResult<DeviceGetDto> GetDeviceById(int id)
        {
            try
            {
                var device = _supervisor.GetDeviceById(id, CurrentUser.Id);

                if (device != null)
                    return Ok(device);
                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //POST: api/Device
        [HttpPost]
        public ActionResult<DeviceGetDto> CreateDevice([FromBody] DevicePostDto model)
        {
            try
            {
                if (model == null || !ModelState.IsValid) return BadRequest();

                model = _supervisor.CreateDevice(model, CurrentUser.Id);

                return CreatedAtRoute(nameof(GetDeviceById), new { id = model.Id }, model);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //PUT: api/Device/{id}
        [HttpPut("{id}")]
        public ActionResult<DeviceGetDto> UpdateDevice(int id, [FromBody] DevicePostDto model)
        {
            try
            {
                if (model == null || !ModelState.IsValid) return BadRequest();

                if (_supervisor.GetDeviceById(id, CurrentUser.Id) == null) return NotFound();

                model.Id = id;

                return _supervisor.UpdateDevice(model, CurrentUser.Id) ? NoContent() : StatusCode(500);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        ////PATCH: api/Device/{id}
        //[HttpPatch("{id}")]
        //public ActionResult PartialUpdateDevice(int id, [FromBody] JsonPatchDocument<DeviceGetDto> patchDoc)
        //{
        //    try
        //    {
        //        var model = _supervisor.GetDeviceById(id, CurrentUser.Id);
        //        if (model == null) return NotFound();

        //        patchDoc.ApplyTo(model, ModelState);

        //        if (!TryValidateModel(model, CurrentUser.Id))
        //        {
        //            return ValidationProblem(ModelState);
        //        }

        //        model.Id = id;

        //        return _supervisor.UpdateDevice(model, CurrentUser.Id) ? NoContent() : StatusCode(500);
        //    }
        //    catch (Exception e)
        //    {
        //        return HandleException(e);
        //    }
        //}

        //DELETE: api/Device/id
        [HttpDelete("{id}")]
        public ActionResult DeleteDevice(int id)
        {
            try
            {
                if (_supervisor.GetDeviceById(id, CurrentUser.Id) == null) return NotFound();

                return _supervisor.DeleteDevice(id, CurrentUser.Id) ? NoContent() : StatusCode(500);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}