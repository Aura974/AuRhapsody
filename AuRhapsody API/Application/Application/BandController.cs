using Business.DTO.Bands;
using Business.Service.Contract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandController : ControllerBase
    {
        private readonly IBandService _bandService;

        public BandController(IBandService bandService)
        {
            _bandService = bandService;
        }

        // GET: api/<BandController>
        [HttpGet]
        [ProducesResponseType(typeof(List<ReadBandDTO>), 200)]
        public async Task<ActionResult> GetAllBands()
        {
            var bandsDTO = await _bandService.GetAllBands().ConfigureAwait(false);
            return Ok(bandsDTO);
        }

        // GET api/<BandController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadBandDTO), 200)]

        public async Task<ActionResult> GetBandById(int bandId)
        {
            var bandDTO = await _bandService.GetBandById(bandId).ConfigureAwait(false);
            return Ok(bandDTO);
        }

        // POST api/<BandController>
        [HttpPost]
        public async Task<ActionResult> CreateBand([FromBody] CreateBandDTO bandDTO)
        {
            if (string.IsNullOrWhiteSpace(bandDTO.BandName) ||
                string.IsNullOrWhiteSpace(bandDTO.BandImage))
            {
                return BadRequest(new
                {
                    Error = "Veuillez remplir tous les champs"
                });
            }

            try
            {
                var bandAdd = await _bandService.CreateBand(bandDTO).ConfigureAwait(false);
                return Ok(bandAdd);

            }

            catch (Exception e)
            {
                return BadRequest(new
                {
                    Error = e.Message
                });
            }
        }

        // PUT api/<BandController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBand(int bandId, [FromBody] UpdateBandDTO bandDto)
        {
            var bandUpdated = await _bandService.UpdateBand(bandId, bandDto).ConfigureAwait(false);

            return Ok(bandUpdated);
        }

        // DELETE api/<BandController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBand(int BandId)
        {
            var bandDeleted = await _bandService.DeleteBand(BandId).ConfigureAwait(false);

            return Ok(bandDeleted);
        }
    }
}
