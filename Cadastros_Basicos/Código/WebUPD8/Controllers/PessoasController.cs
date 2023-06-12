using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UPD8.Data.Domain.DTOs;
using UPD8.Data.Domain.DTOs.Request;
using UPD8.Data.Domain.Filter;
using UPD8.Data.Domain.Interfaces.Services;

namespace UPD8.Data.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : Controller
    {
        private readonly IPessoaService _iPessoaService;

        public PessoasController(IPessoaService iPessoaService)
        {
            _iPessoaService = iPessoaService;
        }

        [HttpGet]
        [Route("BuscarPorDto")]
        [ProducesResponseType(typeof(PessoaDTO), 200)]
        [ProducesResponseType(typeof(PessoaDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBy([FromQuery] PessoaFilter filter)
        {
            try
            {
                return Ok(await _iPessoaService.GetListAsync(filter));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        [ProducesResponseType(typeof(PessoaDTO), 200)]
        [ProducesResponseType(typeof(PessoaDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                return Ok(await _iPessoaService.GetAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getList")]
        [SwaggerOperation("Buscar lista de Pessoas")]
        [ProducesResponseType(typeof(PessoaDTO), 200)]
        [ProducesResponseType(typeof(PessoaDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _iPessoaService.GetListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/[controller]/[action]/{Id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _iPessoaService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        [SwaggerOperation("Update an Color")]
        [Route("update")]
        [ProducesResponseType(typeof(PessoaRequestDTO), 200)]
        [ProducesResponseType(typeof(PessoaRequestDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] PessoaRequestDTO dto)
        {
            try
            {
                await _iPessoaService.UpdateAsync(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation("Insert an Color")]
        [Route("insert")]
        [ProducesResponseType(typeof(PessoaDTO), 200)]
        [ProducesResponseType(typeof(PessoaDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Insert([FromBody] PessoaDTO dto)
        {
            try
            {
                await _iPessoaService.InsertAsync(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
