using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebApiHuman.Repositories;
using WebApiHumanModels.Data;
using WebApiHumanModels.ViewModels.BasicOperation;
using WebApiHumanModels.ViewModels.Human;

namespace WebApiHuman.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HumanController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IGeneralRepository<Human> _humanREpository;
        private readonly IMapper _mapper;

        public HumanController(ILogger<WeatherForecastController> logger, IMapper mapper, IGeneralRepository<Human> humanREpository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _humanREpository = humanREpository ?? throw new ArgumentNullException(nameof(humanREpository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }
        [HttpGet]
        [Route("All")]

        public async Task<IActionResult> All()
        {
            var result = await _humanREpository.GetAll();
            if (result!= null)
                return Ok(result);
            else
                return BadRequest("Please verify the logs of the service");
        }
        [HttpGet]
        [Route("Get/{id}")]

        public async Task<IActionResult> getById(int id)
        {
            var result = await _humanREpository.Get(id);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Please verify the logs of the service");
        }

        [HttpPost]
        [Route("Add")]

        public async Task<IActionResult> Add([FromBody] AddHumanViewModel addmodel)
        {


            var human = _mapper.Map<Human>(addmodel);
            var result = await _humanREpository.Create(human);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Please verify the logs of the service");
        }

        [HttpPut]
        [Route("Update")]

        public async Task<IActionResult> Update([FromBody] UpdateHumanViewModel addmodel)
        {
            var human = _mapper.Map<Human>(addmodel);
            var result = await _humanREpository.Update(human);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Please verify the logs of the service");
        }

    }
}
