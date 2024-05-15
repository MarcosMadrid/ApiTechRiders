using ApiTechRiders.Models;
using ApiTechRiders.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTechRiders.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class EstadosValidacionController : ControllerBase
    {
        private RepositoryTechRiders repo;
        public EstadosValidacionController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/estadosvalidacion
        /// <summary>
        /// Obtiene el conjunto de ESTADOSVALIDACION, tabla ESTADOSVALIDACION.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los ESTADOSVALIDACION de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EstadosValidacion>>> Get()
        {
            return await this.repo.GetEstadosValidacionAsync();
        }

        // GET: api/estadosvalidacion/{id}
        /// <summary>
        /// Obtiene un ESTADOSVALIDACION por su Id, tabla ESTADOSVALIDACION.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto ESTADOSVALIDACION por su ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto ESTADOSVALIDACION.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadosValidacion>> Find(int id)
        {
            var estadosValidacion = await this.repo.FindEstadosValidacionAsync(id);
            if (estadosValidacion == null)
            {
                return NotFound();
            }
            return estadosValidacion;
        }

        // POST: api/estadosvalidacion
        /// <summary>
        /// Crea un nuevo ESTADOSVALIDACION en la BBDD, tabla ESTADOSVALIDACION
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo ESTADOSVALIDACION enviando el Objeto JSON
        /// El ID se genera automáticamente dentro del método
        /// </remarks>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EstadosValidacion>>
                InsertEstadosValidacion(EstadosValidacion estadosValidacionRequest)
        {
            EstadosValidacion estadosValidacionNew =
                    await this.repo.InsertEstadosValidacionAsync
                    (estadosValidacionRequest);
            return estadosValidacionNew;
        }

        // PUT: api/estadosvalidacion
        /// <summary>
        /// Modifica un ESTADOSVALIDACION en la BBDD mediante su ID, tabla ESTADOSVALIDACION
        /// </summary>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateEstadosValidacion
                (EstadosValidacion estadosValidacionRequest)
        {
            var estadosValidacionFind = await this.repo.FindEstadosValidacionAsync
                (estadosValidacionRequest.IdEstadoValidacion);
            if (estadosValidacionFind == null)
            {
                return NotFound();
            }
            await this.repo.UpdateEstadosValidacionAsync(estadosValidacionRequest);
            return Ok();
        }

        // DELETE: api/estadosvalidacion/{id}
        /// <summary>
        /// Elimina un ESTADOSVALIDACION en la BBDD mediante su ID. Tabla ESTADOSVALIDACION
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="id">ID de ESTADOSVALIDACION a eliminar</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEstadosValidacion(int id)
        {
            var estadosValidacionFind = await this.repo.FindEstadosValidacionAsync
                (id);
            if (estadosValidacionFind == null)
            {
                return NotFound();
            }
            await this.repo.DeleteEstadosValidacionAsync(id);
            return Ok();
        }
    }
}
