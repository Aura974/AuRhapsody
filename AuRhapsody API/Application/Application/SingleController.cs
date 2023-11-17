using Business.DTO.Singles;
using Business.Service.Contract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingleController : ControllerBase
    {
        private readonly ISingleService _singleService;

        public SingleController(ISingleService singleService)
        {
            _singleService = singleService;
        }
        
        // GET: api/<SingleController>
        [HttpGet]
        [ProducesResponseType(typeof(List<ReadSingleDTO>), 200)]
        public async Task<ActionResult> GetAllSingles()
        {
            var singlesDTO = await _singleService.GetAllSingles().ConfigureAwait(false);
            return Ok(singlesDTO);
        }

        // GET api/<SingleController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadSingleDTO), 200)]

        public async Task<ActionResult> GetSingleById(int singleId)
        {
            var singleDTO = await _singleService.GetSingleById(singleId).ConfigureAwait(false);
            return Ok(singleDTO);
        }

        // POST api/<SingleController>
        [HttpPost]
        public async Task<ActionResult> CreateSingle([FromBody] CreateSingleDTO singleDTO)
        {
            if (string.IsNullOrWhiteSpace(singleDTO.SingleTitle) ||
                singleDTO.SinglePrice <= 0 ||
                singleDTO.SingleQuantity <= 0 ||
                string.IsNullOrWhiteSpace(singleDTO.SingleImage))
            {
                return BadRequest(new
                {
                    Error = "Veuillez remplir tous les champs"
                });
            }

            try
            {
                var singleAdd = await _singleService.CreateSingle(singleDTO).ConfigureAwait(false);
                return Ok(singleAdd);

            }

            catch (Exception e)
            {
                return BadRequest(new
                {
                    Error = e.Message
                });
            }
        }

        // PUT api/<SingleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSingle(int singleId, [FromBody] UpdateSingleDTO singleDto)
        {
            var singleUpdated = await _singleService.UpdateSingle(singleId, singleDto).ConfigureAwait(false);

            return Ok(singleUpdated);
        }

        // DELETE api/<SingleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSingle(int SingleId)
        {
            var singleDeleted = await _singleService.DeleteSingle(SingleId).ConfigureAwait(false);

            return Ok(singleDeleted);
        }
    }
}
