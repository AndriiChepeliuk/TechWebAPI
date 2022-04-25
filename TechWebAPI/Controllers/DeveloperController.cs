using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeveloperController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("Get")]
        public IActionResult GetPopularDevelopers([FromQuery] int count)
        {
            var popularDevelopers = _unitOfWork.Developers.GetPopularDevelopers(count);
            return Ok(popularDevelopers);
        }

        [HttpPost("AddDeveloper")]
        public IActionResult AddDeveloperAndProject(Developer developer)
        {
            _unitOfWork.Developers.Add(developer);
            _unitOfWork.Complete();
            return Ok();
        }

    }
}
