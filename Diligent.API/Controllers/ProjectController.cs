using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using AutoMapper;
using Diligent.API.Dtos;
using Diligent.BLL;
using Diligent.BOL;

namespace Diligent.API.Controllers
{
    [EnableCors("http://localhost:11932", "*", "*")]
    public class ProjectController : ApiController
    {
        private readonly ProjectBs _projectBs;

        public ProjectController(ProjectBs projectBs)
        {
            _projectBs = projectBs;
        }

        [Route("api/user/{userId}/project")]
        [ResponseType(typeof(IEnumerable<ProjectDto>))]
        [HttpGet]
        public IHttpActionResult GetProjectsByUserId(int userId)
        {
            var projects = _projectBs.GetByUserId(userId);

            var projectDtos = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDto>>(projects);

            return Ok(projectDtos);
        }

        [Route("api/user/{userId}/project")]
        [HttpPost]
        public IHttpActionResult CreateProject(ProjectDto projectDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var project = Mapper.Map<ProjectDto, Project>(projectDto);

            if (_projectBs.CreateProject(project))
            {
                projectDto.Id = project.Id;
                return Created(new Uri(Request.RequestUri + "/" + projectDto.Id), projectDto);
            }

            AddErrorMessageToModelState();

            return BadRequest(ModelState);
        }

        private void AddErrorMessageToModelState()
        {
            foreach (var error in _projectBs.ErrorList)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
