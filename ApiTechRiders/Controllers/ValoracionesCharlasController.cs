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
    public class ValoracionesCharlasController : ControllerBase
    {
        private RepositoryTechRiders repo;
        public ValoracionesCharlasController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/valoracionescharlas
        /// <summary>
        /// Obtiene el conjunto de VALORACIONESCHARLAS, tabla VALORACIONESCHARLAS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos las VALORACIONESCHARLAS de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ValoracionCharla>>> Get()
        {
            return await this.repo.GetValoracionesCharlasAsync();
        }

        // GET: api/valoracionescharlas/{id}
        /// <summary>
        /// Obtiene un VALORACIONESCHARLAS por su Id, tabla VALORACIONESCHARLAS.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto VALORACIONESCHARLAS por su ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto VALORACIONESCHARLAS.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ValoracionCharla>> Find(int id)
        {
            var valoracion = await this.repo.FindValoracionCharlaAsync(id);
            if (valoracion == null)
            {
                return NotFound();
            }
            return valoracion;
        }

        // GET: api/valoracionescharlas/{id}
        /// <summary>
        /// Obtiene un VALORACIONESCHARLAS por el Id de CHARLAS, tabla VALORACIONESCHARLAS.
        /// </summary>
        /// <remarks>
        /// Permite buscar un conjunto de VALORACIONESCHARLAS por el ID de Charla
        /// </remarks>
        /// <param name="idcharla">Id de la Charla.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Route("[action]/{idcharla}")]
        public async Task<ActionResult<List<ValoracionCharla>>> 
            Valoraciones(int idcharla)
        {
            var charlas = await this.repo.GetValoracionesCharlaAsync(idcharla);
            return charlas;
        }

        // POST: api/valoracionescharlas
        /// <summary>
        /// Crea una nueva VALORACIONESCHARLAS en la BBDD, tabla VALORACIONESCHARLAS
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo VALORACIONESCHARLAS enviando el Objeto JSON
        /// El ID de la charla se genera automáticamente dentro del método
        /// </remarks>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult<ValoracionCharla>>
            InsertValoracionCharla(ValoracionCharla valoracionRequest)
        {
            ValoracionCharla valoracionNew =
                await this.repo.InsertValoracionCharlasAsync
                (valoracionRequest);
            return valoracionNew;
        }

        // PUT: api/valoracionescharlas
        /// <summary>
        /// Modifica una VALORACIONESCHARLAS en la BBDD mediante su ID, tabla VALORACIONESCHARLAS
        /// </summary>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult> UpdateValoracionCharla
            (ValoracionCharla valoracionRequest)
        {
            var valoracionFind = await 
                this.repo.FindValoracionCharlaAsync
                (valoracionRequest.IdValoracion);
            if (valoracionFind == null)
            {
                return NotFound();
            }
            await this.repo.UpdateValoracionCharlasAsync(valoracionRequest);
            return Ok();
        }

        // DELETE: api/valoracionescharlas/{id}
        /// <summary>
        /// Elimina una VALORACIONESCHARLAS en la BBDD mediante su ID. Tabla VALORACIONESCHARLAS
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="id">ID del VALORACIONESCHARLAS a eliminar</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteValoracionCharla(int id)
        {
            var valoracionFind = await
                this.repo.FindValoracionCharlaAsync(id);
            if (valoracionFind == null)
            {
                return NotFound();
            }
            await this.repo.DeleteValoracionCharlaAsync(id);
            return Ok();
        }
    }
}
