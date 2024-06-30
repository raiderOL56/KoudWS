using KoudWS.Exceptions;
using KoudWS.Interfaces;
using KoudWS.Models.DTOs;
using KoudWS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KoudWS.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class ShowController : ControllerBase
    {
        private readonly ITvShowService _tvShowService;
        public ShowController(ITvShowService tvShowService)
        {
            _tvShowService = tvShowService;
        }
        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            try
            {
                IEnumerable<TvShowDTO> tvShotDTOs = await _tvShowService.GetAll();

                return Ok(tvShotDTOs);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error en el servidor.");
            }
        }

        [MapToApiVersion("1.0")]
        [HttpGet()]
        public async Task<IActionResult> GetTvShow([FromQuery] string name)
        {
            try
            {
                TvShowDTO? tvShowDTO = await _tvShowService.GetShow(name);
                if (tvShowDTO == null)
                    return BadRequest();

                return Ok(tvShowDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error en el servidor.");
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<IActionResult> AddTvShow([FromBody] TvShowVM tvShowVM)
        {
            try
            {
                TvShowDTO? tvShowDTO = await _tvShowService.AddShow(tvShowVM);
                if (tvShowDTO == null)
                    return BadRequest();

                return Ok(tvShowDTO);
            }
            catch (TvShowNotAdded e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error en el servidor.");
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPut]
        public async Task<IActionResult> IsFavorite([FromBody] TvShowVM tvShowVM)
        {
            try
            {
                TvShowDTO? tvShowDTO = await _tvShowService.IsFavorite(tvShowVM);
                if (tvShowDTO == null)
                    return BadRequest();

                return Ok(tvShowDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error en el servidor.");
            }
        }

        [MapToApiVersion("1.0")]
        [HttpDelete()]
        public async Task<IActionResult> DeleteTvShow([FromQuery] string name)
        {
            try
            {
                if (await _tvShowService.DeleteShow(name))
                    return Ok();
                else
                    return StatusCode(500, $"Error al eliminar el programa de televisión '{name}' debido a un problema de conexión con la base de datos.");
            }
            catch (TvShowNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error en el servidor.");
            }
        }
    }
}