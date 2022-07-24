using System;
using System.Linq;
using EventBus.Base.Standard;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SmartLiving.Api.Middleware;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Services;
using SmartLiving.Domain.Supervisors.Interfaces;

namespace SmartLiving.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Authorize]
    public class HouseController : BaseController
    {
        private readonly IJsonStringService _jsonService;
        private readonly ISupervisor _supervisor;

        public HouseController(ISupervisor supervisor, IJsonStringService jsonService, IEventBus eventBus)
        {
            _supervisor = supervisor;
            _jsonService = jsonService;
        }

        //GET: api/House/GetAllHouses
        [HttpGet("[action]")]
        public ActionResult GetAllHouses()
        {
            try
            {
                var allItems = _supervisor.GetAllHouses(CurrentUser.Id).ToList();

                if (allItems.Any())
                {
                    var json = new JObject();

                    foreach (var item in allItems)
                    {
                        json[Convert.ToString(item.Id)] = _jsonService.Serialize(item);
                    }

                    return Ok(json);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        ////GET: api/House/GetPagedList
        //[HttpGet("[action]")]
        //public ActionResult<PagedList<HouseGetDto>> GetPagedList(int pageIndex = 1, int pageSize = SystemConstants.PageSizeDefault)
        //{
        //    try
        //    {
        //        var housePagedList = _supervisor.GetPagedList(_supervisor.GetAllHouses(CurrentUser.Id).ToList() ,pageIndex, pageSize);

        //        if (housePagedList.Any())
        //            return Ok(housePagedList);
        //        return NotFound();
        //    }
        //    catch (Exception e)
        //    {
        //        return HandleException(e);
        //    }
        //}

        //GET: api/House/{id}
        [HttpGet("{id}", Name = "GetHouseById")]
        public ActionResult GetHouseById(int id)
        {
            try
            {
                var house = _supervisor.GetHouseById(id, CurrentUser.Id);

                if (house != null)
                {
                    var json = _jsonService.Serialize(house);

                    return Ok(json);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //POST: api/House
        [HttpPost]
        public ActionResult CreateHouse([FromBody] HousePostDto model)
        {
            try
            {
                if (model == null || !ModelState.IsValid) return BadRequest();

                model = _supervisor.CreateHouse(model, CurrentUser.Id);

                return CreatedAtRoute(nameof(GetHouseById), new {id = model.Id}, model);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //PUT: api/House/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateHouse(int id, [FromBody] HousePostDto model)
        {
            try
            {
                if (model == null || !ModelState.IsValid) return BadRequest();

                if (_supervisor.GetHouseById(id, CurrentUser.Id) == null) return NotFound();

                model.Id = id;

                return _supervisor.UpdateHouse(model, CurrentUser.Id) ? NoContent() : StatusCode(500);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        ////PATCH: api/House/{id}
        //[HttpPatch("{id}")]
        //public ActionResult PartialUpdateHouse(int id, [FromBody] JsonPatchDocument<HouseGetDto> patchDoc)
        //{
        //    try
        //    {
        //        var model = _supervisor.GetHouseById(id, CurrentUser.Id);
        //        if (model == null) return NotFound();

        //        patchDoc.ApplyTo(model, ModelState);

        //        if (!TryValidateModel(model, CurrentUser.Id))
        //        {
        //            return ValidationProblem(ModelState);
        //        }

        //        model.Id = id;

        //        return _supervisor.UpdateHouse(model, CurrentUser.Id) ? NoContent() : StatusCode(500);
        //    }
        //    catch (Exception e)
        //    {
        //        return HandleException(e);
        //    }
        //}

        //DELETE: api/House/id
        [HttpDelete("{id}")]
        public ActionResult DeleteHouse(int id)
        {
            try
            {
                if (_supervisor.GetHouseById(id, CurrentUser.Id) == null) return NotFound();

                return _supervisor.DeleteHouse(id, CurrentUser.Id) ? NoContent() : StatusCode(500);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}