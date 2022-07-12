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
    public class ProfileController : BaseController
    {
        private readonly ISupervisor _supervisor;

        public ProfileController(ISupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        //GET: api/Profile/GetAllProfiles
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<ProfileGetDto>> GetAllProfiles()
        {
            try
            {
                var allItems = _supervisor.GetAllProfiles(CurrentUser.Id);

                if (allItems.Any())
                    return Ok(allItems);
                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //GET: api/Profile/GetPagedList
        [HttpGet("[action]")]
        public ActionResult<PagedList<ProfileGetDto>> GetPagedList(int pageIndex = 1, int pageSize = SystemConstants.PageSizeDefault)
        {
            try
            {
                var profilePagedList = _supervisor.GetPagedList<ProfileGetDto>(_supervisor.GetAllProfiles(CurrentUser.Id).ToList() ,pageIndex, pageSize);

                if (profilePagedList.Any())
                    return Ok(profilePagedList);
                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //GET: api/Profile/{id}
        [HttpGet("{id}", Name = "GetProfileById")]
        public ActionResult<ProfileGetDto> GetProfileById(int id)
        {
            try
            {
                var profile = _supervisor.GetProfileById(id, CurrentUser.Id);

                if (profile != null)
                    return Ok(profile);
                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //POST: api/Profile
        [HttpPost]
        public ActionResult<ProfileGetDto> CreateProfile([FromBody] ProfileGetDto model)
        {
            try
            {
                if (model == null || !ModelState.IsValid) return BadRequest();

                model = _supervisor.CreateProfile(model, CurrentUser.Id);

                return CreatedAtRoute(nameof(GetProfileById), new {id = model.Id}, model);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //PUT: api/Profile/{id}
        [HttpPut("{id}")]
        public ActionResult<ProfileGetDto> UpdateProfile(int id, [FromBody] ProfileGetDto model)
        {
            try
            {
                if (model == null || !ModelState.IsValid) return BadRequest();

                if (_supervisor.GetProfileById(id, CurrentUser.Id) == null) return NotFound();

                model.Id = id;

                return _supervisor.UpdateProfile(model, CurrentUser.Id) ? NoContent() : StatusCode(500);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //PATCH: api/Profile/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdateProfile(int id, [FromBody] JsonPatchDocument<ProfileGetDto> patchDoc)
        {
            try
            {
                var model = _supervisor.GetProfileById(id, CurrentUser.Id);
                if (model == null) return NotFound();

                patchDoc.ApplyTo(model, ModelState);

                if (!TryValidateModel(model, CurrentUser.Id))
                {
                    return ValidationProblem(ModelState);
                }

                model.Id = id;

                return _supervisor.UpdateProfile(model, CurrentUser.Id) ? NoContent() : StatusCode(500);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //DELETE: api/Profile/id
        [HttpDelete("{id}")]
        public ActionResult DeleteProfile(int id)
        {
            try
            {
                if (_supervisor.GetProfileById(id, CurrentUser.Id) == null) return NotFound();

                return _supervisor.DeleteProfile(id, CurrentUser.Id) ? NoContent() : StatusCode(500);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}
