using ApiTechRiders.Models;
using ApiTechRiders.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTechRiders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnologiasCharlasController : ControllerBase
    {
        private RepositoryTechRiders repo;
        public TecnologiasCharlasController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/TecnologiasCharlas
        /// <summary>
        /// Obtiene el conjunto de TecnologiasCharlas, tabla TECNOLOGIASCHARLAS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los TECNOLOGIASCHARLAS de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TecnologiaCharlas>>> Get()
        {
            return await this.repo.GetTecnologiasCharlasAsync();
        }

        // GET: api/TecnologiasCharlas/byCharla/{idCharla}
        /// <summary>
        /// Obtiene todas las tecnologías de una Charla por el Id de la Charla
        /// </summary>
        /// <remarks>
        /// Permite buscar todas las tecnologías de una Charla por IDCharla
        /// </remarks>
        /// <param name="idcharla">Id (GUID) del objeto CHARLA.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Route("[action]/{idcharla}")]
        public async Task<ActionResult<List<TecnologiaCharlas>>>
            ByCharla(int idcharla)
        {
            var tecnologiasCharlas =
                await this.repo.FindTecnologiasCharlaByCharlaAsync(idcharla);
            if (tecnologiasCharlas == null)
            {
                return NotFound();
            }
            return tecnologiasCharlas;
        }

        // GET: api/TecnologiasCharlas/byCharla/{idCharla}
        /// <summary>
        /// Obtiene todas las charlas por una tecnología
        /// </summary>
        /// <remarks>
        /// Permite buscar todas las Charlas de una Tecnología indicando IDTecnologia
        /// </remarks>
        /// <param name="idtecnologia">Id (GUID) del objeto TECNOLOGIAS.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Route("[action]/{idtecnologia}")]
        public async Task<ActionResult<List<TecnologiaCharlas>>>
            ByTecnologia(int idtecnologia)
        {
            var tecnologiasCharlas =
                await this.repo.FindTecnologiasCharlaByTecnologiaAsync(idtecnologia);
            if (tecnologiasCharlas == null)
            {
                return NotFound();
            }
            return tecnologiasCharlas;
        }

        // POST: api/tecnologiascharlas/{idcharla}/{idtecnologia}
        /// <summary>
        /// Crea un nuevo TECNOLOGIASCHARLAS en la BBDD, tabla TECNOLOGIASCHARLAS
        /// </summary>
        /// <remarks>
        /// Este método asocia una Charla a una tecnología
        /// </remarks>
        /// <param name="idcharla">Id (GUID) del objeto CHARLA.</param>
        /// <param name="idtecnologia">Id (GUID) del objeto TECNOLOGIA.</param>  
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult<TecnologiaCharlas>>
                InsertTecnologiaCharlas(int idcharla, int idtecnologia)
        {
            TecnologiaCharlas peticionNew =
                    await this.repo.InsertTecnologiaCharlasAsync
                    (idcharla, idtecnologia);
            return peticionNew;
        }

        // POST: api/tecnologiascharlas/{idcharla}/{idtecnologia}
        /// <summary>
        /// Crea un nuevo TECNOLOGIASCHARLAS en la BBDD, tabla TECNOLOGIASCHARLAS
        /// </summary>
        /// <remarks>
        /// Este método asocia una Charla a una tecnología
        /// </remarks>
        /// <param name="idcharla">Id (GUID) del objeto CHARLA.</param>
        /// <param name="idtecnologia">Id (GUID) del objeto TECNOLOGIA.</param>  
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [Route("[action]/{idcharla}/{idtecnologia}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult<TecnologiaCharlas>>
                CreateTecnologiaCharlas(int idcharla, int idtecnologia)
        {
            TecnologiaCharlas peticionNew =
                    await this.repo.InsertTecnologiaCharlasAsync
                    (idcharla, idtecnologia);
            return peticionNew;
        }

        // DELETE: api/tecnologiascharlas/{idcharla}/{idtecnologia}
        /// <summary>
        /// Elimina una tecnología en una Charla. 
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="idcharla">Id (GUID) del objeto CHARLA.</param>
        /// <param name="idtecnologia">Id (GUID) del objeto ID DE LA TECNOLOGIA.</param> 
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        [Route("[action]/{idcharla}/{idtecnologia}")]
        [Authorize]
        public async Task<ActionResult> Delete
            (int idcharla, int idtecnologia)
        {
            var peticionFind = 
                await this.repo.FindTecnologiasCharlaAsync
                (idcharla, idtecnologia);
            if (peticionFind == null)
            {
                return NotFound();
            }
            await this.repo.DeleteTecnologiaCharlasAsync
                (idcharla, idtecnologia);
            return Ok();
        }

        // DELETE: api/tecnologiascharlas/{idcharla}
        /// <summary>
        /// Elimina todas las tecnologías asociadas a una Charla. 
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID de la Charla
        /// </remarks>
        /// <param name="idcharla">Id (GUID) del objeto CHARLA.</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        [Route("[action]/{idcharla}")]
        [Authorize]
        public async Task<ActionResult> DeleteByIdCharla
            (int idcharla)
        {
            await this.repo.DeleteTecnologiaCharlaByCharlaAsync
                (idcharla);
            return Ok();
        }
    }
}
