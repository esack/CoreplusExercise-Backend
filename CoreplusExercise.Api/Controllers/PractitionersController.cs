using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoreplusExercise.Api.DTOs;
using CoreplusExercise.Managers.Practitioner;
using Microsoft.AspNetCore.Mvc;

namespace CoreplusExercise.API.Controllers
{
    [Route("api/[controller]")]
    public class PractitionersController : Controller
    {
        private readonly IPractitionerManager _practitionerManager;
        public readonly IMapper _mapper;

        public PractitionersController(IPractitionerManager practitionerManager, IMapper mapper)
        {
            _practitionerManager = practitionerManager;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PractitionerBaseDTO>), 200)]
        public async Task<IActionResult> GetPractitioners([FromQuery] long fromUnixTimeMilliseconds, [FromQuery] long toUnixTimeMilliseconds)
        {           
            var practitioners = _mapper.Map< List<PractitionerBaseDTO>>(await _practitionerManager.GetPractitionersAsync(fromUnixTimeMilliseconds, toUnixTimeMilliseconds));

            return Ok(new { practitioners });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PractitionerDTO), 200)]
        public async Task<IActionResult> GetPractitioner(Guid id, [FromQuery] long fromUnixTimeMilliseconds, [FromQuery] long toUnixTimeMilliseconds)
        {
            var practitioner = _mapper.Map<PractitionerDTO>(await _practitionerManager.GetPractitionerAsync(id, fromUnixTimeMilliseconds, toUnixTimeMilliseconds));

            return Ok(new { practitioner });
        }
    }
}
