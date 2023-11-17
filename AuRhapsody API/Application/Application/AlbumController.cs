using Business.DTO.Albums;
using Business.Service.Contract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        // GET: api/<AlbumController>
        [HttpGet]
        [ProducesResponseType(typeof(List<ReadAlbumDTO>), 200)]
        public async Task<ActionResult> GetAllAlbums()
        {
            var albumsDTO = await _albumService.GetAllAlbums().ConfigureAwait(false);
            return Ok(albumsDTO);
        }

        // GET api/<AlbumController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadAlbumDTO), 200)]

        public async Task<ActionResult> GetAlbumById(int albumId)
        {
            var albumDTO = await _albumService.GetAlbumById(albumId).ConfigureAwait(false);
            return Ok(albumDTO);
        }

        // POST api/<AlbumController>
        [HttpPost]
        public async Task<ActionResult> CreateAlbum([FromBody] CreateAlbumDTO albumDTO)
        {
            if (string.IsNullOrWhiteSpace(albumDTO.AlbumTitle) ||
                albumDTO.AlbumPrice <= 0 ||
                albumDTO.AlbumQuantity <= 0 ||
                string.IsNullOrWhiteSpace(albumDTO.AlbumImage))
            {
                return BadRequest(new
                {
                    Error = "Veuillez remplir tous les champs"
                });
            }

            try
            {
                var albumAdd = await _albumService.CreateAlbum(albumDTO).ConfigureAwait(false);
                return Ok(albumAdd);

            }

            catch (Exception e)
            {
                return BadRequest(new
                {
                    Error = e.Message
                });
            }
        }

        // PUT api/<AlbumController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlbum(int albumId, [FromBody] UpdateAlbumDTO albumDto)
        {
            var albumUpdated = await _albumService.UpdateAlbum(albumId, albumDto).ConfigureAwait(false);

            return Ok(albumUpdated);
        }

        // DELETE api/<AlbumController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(int AlbumId)
        {
            var albumDeleted = await _albumService.DeleteAlbum(AlbumId).ConfigureAwait(false);

            return Ok(albumDeleted);
        }
    }
}
