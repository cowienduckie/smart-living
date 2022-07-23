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
    public class CommandController : BaseController
    {
        private readonly ISupervisor _supervisor;

        public CommandController(ISupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        ////GET: api/Command/GetAllCommands
        //[HttpGet("[action]")]
        //public ActionResult<IEnumerable<CommandGetDto>> GetAllCommands()
        //{
        //    try
        //    {
        //        var allItems = _supervisor.GetAllCommands(CurrentUser.Id);

        //        if (allItems.Any())
        //            return Ok(allItems);
        //        return NotFound();
        //    }
        //    catch (Exception e)
        //    {
        //        return HandleException(e);
        //    }
        //}

        ////GET: api/Command/GetPagedList
        //[HttpGet("[action]")]
        //public ActionResult<PagedList<CommandGetDto>> GetPagedList(int pageIndex = 1, int pageSize = SystemConstants.PageSizeDefault)
        //{
        //    try
        //    {
        //        var commandPagedList = _supervisor.GetPagedList<CommandGetDto>(_supervisor.GetAllCommands(CurrentUser.Id).ToList() ,pageIndex, pageSize);

        //        if (commandPagedList.Any())
        //            return Ok(commandPagedList);
        //        return NotFound();
        //    }
        //    catch (Exception e)
        //    {
        //        return HandleException(e);
        //    }
        //}

        //GET: api/Command/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandGetDto> GetCommandById(int id)
        {
            try
            {
                var command = _supervisor.GetCommandById(id, CurrentUser.Id);

                if (command != null)
                    return Ok(command);
                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //POST: api/Command
        [HttpPost]
        public ActionResult<CommandGetDto> CreateCommand([FromBody] CommandGetDto model)
        {
            try
            {
                if (model == null || !ModelState.IsValid) return BadRequest();

                model = _supervisor.CreateCommand(model, CurrentUser.Id);

                return CreatedAtRoute(nameof(GetCommandById), new {id = model.Id}, model);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        ////PUT: api/Command/{id}
        //[HttpPut("{id}")]
        //public ActionResult<CommandGetDto> UpdateCommand(int id, [FromBody] CommandGetDto model)
        //{
        //    try
        //    {
        //        if (model == null || !ModelState.IsValid) return BadRequest();

        //        if (_supervisor.GetCommandById(id, CurrentUser.Id) == null) return NotFound();

        //        model.Id = id;

        //        return _supervisor.UpdateCommand(model, CurrentUser.Id) ? NoContent() : StatusCode(500);
        //    }
        //    catch (Exception e)
        //    {
        //        return HandleException(e);
        //    }
        //}

        ////PATCH: api/Command/{id}
        //[HttpPatch("{id}")]
        //public ActionResult PartialUpdateCommand(int id, [FromBody] JsonPatchDocument<CommandGetDto> patchDoc)
        //{
        //    try
        //    {
        //        var model = _supervisor.GetCommandById(id, CurrentUser.Id);
        //        if (model == null) return NotFound();

        //        patchDoc.ApplyTo(model, ModelState);

        //        if (!TryValidateModel(model))
        //        {
        //            return ValidationProblem(ModelState);
        //        }

        //        model.Id = id;

        //        return _supervisor.UpdateCommand(model, CurrentUser.Id) ? NoContent() : StatusCode(500);
        //    }
        //    catch (Exception e)
        //    {
        //        return HandleException(e);
        //    }
        //}

        ////DELETE: api/Command/id
        //[HttpDelete("{id}")]
        //public ActionResult DeleteCommand(int id)
        //{
        //    try
        //    {
        //        if (_supervisor.GetCommandById(id, CurrentUser.Id) == null) return NotFound();

        //        return _supervisor.DeleteCommand(id, CurrentUser.Id) ? NoContent() : StatusCode(500);
        //    }
        //    catch (Exception e)
        //    {
        //        return HandleException(e);
        //    }
        //}
    }
}