using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SmartLiving.Api.Middleware;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Supervisors.Interfaces;
using SmartLiving.Library.Constants;
using SmartLiving.Library.DataTypes;

namespace SmartLiving.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Authorize]
    public class ScheduleController : BaseController
    {
        private readonly ISupervisor _supervisor;

        public ScheduleController(ISupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        //GET: api/Schedule/GetAllSchedules
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<ScheduleGetDto>> GetAllSchedules()
        {
            try
            {
                var allItems = _supervisor.GetAllSchedules(CurrentUser.Id);

                if (allItems.Any())
                    return Ok(allItems);
                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //GET: api/Schedule/GetPagedList
        [HttpGet("[action]")]
        public ActionResult<PagedList<ScheduleGetDto>> GetPagedList(int pageIndex = 1, int pageSize = SystemConstants.PageSizeDefault)
        {
            try
            {
                var schedulePagedList = _supervisor.GetPagedList<ScheduleGetDto>(_supervisor.GetAllSchedules(CurrentUser.Id).ToList() ,pageIndex, pageSize);

                if (schedulePagedList.Any())
                    return Ok(schedulePagedList);
                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //GET: api/Schedule/{id}
        [HttpGet("[action]/{id}")]
        public ActionResult<ScheduleGetDto> GetScheduleById(int id)
        {
            try
            {
                var schedule = _supervisor.GetScheduleById(id, CurrentUser.Id);

                if (schedule != null)
                    return Ok(schedule);
                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //POST: api/Schedule
        [HttpPost("[action]")]
        public ActionResult<ScheduleGetDto> CreateSchedule([FromBody] ScheduleGetDto model)
        {
            try
            {
                if (model == null || !ModelState.IsValid) return BadRequest();

                model = _supervisor.CreateSchedule(model, CurrentUser.Id);

                return CreatedAtRoute(nameof(GetScheduleById), new {id = model.Id}, model);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //PUT: api/Schedule/{id}
        [HttpPut("[action]/{id}")]
        public ActionResult<ScheduleGetDto> UpdateSchedule(int id, [FromBody] ScheduleGetDto model)
        {
            try
            {
                if (model == null || !ModelState.IsValid) return BadRequest();

                if (_supervisor.GetScheduleById(id, CurrentUser.Id) == null) return NotFound();

                model.Id = id;

                return _supervisor.UpdateSchedule(model, CurrentUser.Id) ? NoContent() : StatusCode(500);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //PATCH: api/Schedule/{id}
        [HttpPatch("[action]/{id}")]
        public ActionResult PartialUpdateSchedule(int id, [FromBody] JsonPatchDocument<ScheduleGetDto> patchDoc)
        {
            try
            {
                var model = _supervisor.GetScheduleById(id, CurrentUser.Id);
                if (model == null) return NotFound();

                patchDoc.ApplyTo(model, ModelState);

                if (!TryValidateModel(model, CurrentUser.Id))
                {
                    return ValidationProblem(ModelState);
                }

                model.Id = id;

                return _supervisor.UpdateSchedule(model, CurrentUser.Id) ? NoContent() : StatusCode(500);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //DELETE: api/Schedule/id
        [HttpDelete("[action]/{id}")]
        public ActionResult DeleteSchedule(int id)
        {
            try
            {
                if (_supervisor.GetScheduleById(id, CurrentUser.Id) == null) return NotFound();

                return _supervisor.DeleteSchedule(id, CurrentUser.Id) ? NoContent() : StatusCode(500);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}
