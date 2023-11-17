using Business.DTO.Merches;
using Business.Service.Contract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchController : ControllerBase
    {
        private readonly IMerchService _merchService;

        public MerchController(IMerchService merchService)
        {
            _merchService = merchService;
        }

        // GET: api/<MerchController>
        [HttpGet]
        [ProducesResponseType(typeof(List<ReadMerchDTO>), 200)]
        public async Task<ActionResult> GetAllMerches()
        {
            var merchesDTO = await _merchService.GetAllMerches().ConfigureAwait(false);
            return Ok(merchesDTO);
        }

        // GET api/<MerchController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadMerchDTO), 200)]

        public async Task<ActionResult> GetMerchById(int merchId)
        {
            var merchDTO = await _merchService.GetMerchById(merchId).ConfigureAwait(false);
            return Ok(merchDTO);
        }

        // POST api/<MerchController>
        [HttpPost]
        public async Task<ActionResult> CreateMerch([FromBody] CreateMerchDTO merchDTO)
        {
            if (string.IsNullOrWhiteSpace(merchDTO.MerchName) ||
                string.IsNullOrWhiteSpace(merchDTO.MerchImage))
            {
                return BadRequest(new
                {
                    Error = "Veuillez remplir tous les champs"
                });
            }

            try
            {
                var merchAdd = await _merchService.CreateMerch(merchDTO).ConfigureAwait(false);
                return Ok(merchAdd);

            }

            catch (Exception e)
            {
                return BadRequest(new
                {
                    Error = e.Message
                });
            }
        }

        // PUT api/<MerchController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMerch(int merchId, [FromBody] UpdateMerchDTO merchDto)
        {
            var merchUpdated = await _merchService.UpdateMerch(merchId, merchDto).ConfigureAwait(false);

            return Ok(merchUpdated);
        }

        // DELETE api/<MerchController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMerch(int MerchId)
        {
            var merchDeleted = await _merchService.DeleteMerch(MerchId).ConfigureAwait(false);

            return Ok(merchDeleted);
        }
    }
}
