using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
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
    public class HouseController : BaseController
    {
        private readonly ISupervisor _supervisor;

        public HouseController(ISupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        //GET: api/House/GetAllHouses
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<HouseGetDto>> GetAllHouses()
        {
            try
            {
                var allItems = _supervisor.GetAllHouses();

                if (allItems.Any())
                    return Ok(allItems);
                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //GET: api/House/GetPagedList
        [HttpGet("[action]")]
        public ActionResult<PagedList<HouseGetDto>> GetPagedList(int pageIndex = 1, int pageSize = SystemConstants.PageSizeDefault)
        {
            try
            {
                var housePagedList = _supervisor.GetPagedList(_supervisor.GetAllHouses().ToList() ,pageIndex, pageSize);

                if (housePagedList.Any())
                    return Ok(housePagedList);
                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //GET: api/House/{id}
        [HttpGet("{id}", Name = "GetHouseById")]
        public ActionResult<HouseGetDto> GetHouseById(int id)
        {
            try
            {
                var house = _supervisor.GetHouseById(id);

                if (house != null)
                    return Ok(house);
                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //POST: api/House
        [HttpPost]
        public ActionResult<HouseGetDto> CreateHouse([FromBody] HouseGetDto model)
        {
            try
            {
                if (model == null || !ModelState.IsValid) return BadRequest();

                model = _supervisor.CreateHouse(model);

                return CreatedAtRoute(nameof(GetHouseById), new {id = model.Id}, model);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //PUT: api/House/{id}
        [HttpPut("{id}")]
        public ActionResult<HouseGetDto> UpdateHouse(int id, [FromBody] HouseGetDto model)
        {
            try
            {
                if (model == null || !ModelState.IsValid) return BadRequest();

                if (_supervisor.GetHouseById(id) == null) return NotFound();

                model.Id = id;

                return _supervisor.UpdateHouse(model) ? NoContent() : StatusCode(500);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //PATCH: api/House/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdateHouse(int id, [FromBody] JsonPatchDocument<HouseGetDto> patchDoc)
        {
            try
            {
                var model = _supervisor.GetHouseById(id);
                if (model == null) return NotFound();

                patchDoc.ApplyTo(model, ModelState);

                if (!TryValidateModel(model))
                {
                    return ValidationProblem(ModelState);
                }

                model.Id = id;

                return _supervisor.UpdateHouse(model) ? NoContent() : StatusCode(500);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //DELETE: api/House/id
        [HttpDelete("{id}")]
        public ActionResult DeleteHouse(int id)
        {
            try
            {
                if (_supervisor.GetHouseById(id) == null) return NotFound();

                return _supervisor.DeleteHouse(id) ? NoContent() : StatusCode(500);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}
