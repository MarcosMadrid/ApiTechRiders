using ApiTechRiders.Models;
using ApiTechRiders.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTechRiders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class EstadosCharlasController : ControllerBase
    {
            private RepositoryTechRiders repo;
            public EstadosCharlasController(RepositoryTechRiders repo)
            {
                this.repo = repo;
            }

        // GET: api/estadoscharlas
        /// <summary>
        /// Obtiene el conjunto de ESTADOSCHARLA, tabla ESTADOSCHARLA.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los ESTADOSCHARLA de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
            public async Task<ActionResult<List<EstadosCharla>>> Get()
            {
                return await this.repo.GetEstadosCharlaAsync();
            }

        // GET: api/estadoscharlas/{id}
        /// <summary>
        /// Obtiene un ESTADOSCHARLA por su Id, tabla ESTADOSCHARLA.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto ESTADOSCHARLA por su ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto ESTADOSCHARLA.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [HttpGet("{id}")]
            public async Task<ActionResult<EstadosCharla>> Find(int id)
            {
                var estadosCharlas = await this.repo.FindEstadosCharlaAsync(id);
                if (estadosCharlas == null)
                {
                    return NotFound();
                }
                return estadosCharlas;
            }

        // POST: api/estadoscharlas
        /// <summary>
        /// Crea un nuevo ESTADOSCHARLA en la BBDD, tabla ESTADOSCHARLA
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo ESTADOSCHARLA enviando el Objeto JSON
        /// El ID se genera automáticamente dentro del método
        /// </remarks>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EstadosCharla>>
                InsertEstadosCharla(EstadosCharla estadosCharlaRequest)
            {
            EstadosCharla estadosCharlaNew =
                    await this.repo.InsertEstadosCharlaAsync
                    (estadosCharlaRequest);
                return estadosCharlaNew;
            }

        // PUT: api/estadoscharlas
        /// <summary>
        /// Modifica un ESTADOSCHARLA en la BBDD mediante su ID, tabla ESTADOSCHARLA
        /// </summary>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult> UpdateEstadosCharla
                (EstadosCharla estadosCharlaRequest)
            {
                var estadosCharlaFind = await this.repo.FindEstadosCharlaAsync
                    (estadosCharlaRequest.IdEstadosCharla);
                if (estadosCharlaFind == null)
                {
                    return NotFound();
                }
                await this.repo.UpdateEstadosCharlaAsync(estadosCharlaRequest);
                return Ok();
            }

        // DELETE: api/estadoscharlas/{id}
        /// <summary>
        /// Elimina un ESTADOSCHARLA en la BBDD mediante su ID. Tabla ESTADOSCHARLA
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="id">ID de EMPRESASCENTROS a eliminar</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteEstadosCharla(int id)
       {
            var estadosCharlaFind = await this.repo.FindEstadosCharlaAsync
            (id);
            if (estadosCharlaFind == null)
            {
                return NotFound();
            }
            await this.repo.DeleteEstadosCharlaAsync(id);
            return Ok();
        }
    }
}
