using Business.DTO.Artists;
using Business.Service.Contract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        // GET: api/<ArtistController>
        [HttpGet]
        [ProducesResponseType(typeof(List<ReadArtistDTO>), 200)]
        public async Task<ActionResult> GetAllArtists()
        {
            var artistsDTO = await _artistService.GetAllArtists().ConfigureAwait(false);
            return Ok(artistsDTO);
        }

        // GET api/<ArtistController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadArtistDTO), 200)]

        public async Task<ActionResult> GetArtistById(int artistId)
        {
            var artistDTO = await _artistService.GetArtistById(artistId).ConfigureAwait(false);
            return Ok(artistDTO);
        }

        // POST api/<ArtistController>
        [HttpPost]
        public async Task<ActionResult> CreateArtist([FromBody] CreateArtistDTO artistDTO)
        {
            if (string.IsNullOrWhiteSpace(artistDTO.ArtistName) ||
                string.IsNullOrWhiteSpace(artistDTO.ArtistImage))
            {
                return BadRequest(new
                {
                    Error = "Veuillez remplir tous les champs"
                });
            }

            try
            {
                var artistAdd = await _artistService.CreateArtist(artistDTO).ConfigureAwait(false);
                return Ok(artistAdd);

            }

            catch (Exception e)
            {
                return BadRequest(new
                {
                    Error = e.Message
                });
            }
        }

        // PUT api/<ArtistController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtist(int artistId, [FromBody] UpdateArtistDTO artistDto)
        {
            var artistUpdated = await _artistService.UpdateArtist(artistId, artistDto).ConfigureAwait(false);

            return Ok(artistUpdated);
        }

        // DELETE api/<ArtistController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int ArtistId)
        {
            var artistDeleted = await _artistService.DeleteArtist(ArtistId).ConfigureAwait(false);

            return Ok(artistDeleted);
        }
    }
}
