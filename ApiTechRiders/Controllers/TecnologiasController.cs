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
    public class TecnologiasController : ControllerBase
    {
        private RepositoryTechRiders repo;
        public TecnologiasController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/tecnologias
        /// <summary>
        /// Obtiene el conjunto de TECNOLOGIAS, tabla TECNOLOGIAS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los TECNOLOGIAS de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Tecnologia>>> Get()
        {
            return await this.repo.GetTecnologiasAsync();
        }

        // GET: api/tecnologias/{id}
        /// <summary>
        /// Obtiene un TECNOLOGIAS por su Id, tabla TECNOLOGIAS.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto TECNOLOGIAS por su ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto TECNOLOGIAS.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Tecnologia>> Find(int id)
        {
            var tecnologia = await this.repo.FindTecnologiaAsync(id);
            if (tecnologia == null)
            {
                return NotFound();
            }
            return tecnologia;
        }

        // POST: api/tecnologias
        /// <summary>
        /// Crea un nuevo TECNOLOGIAS en la BBDD, tabla TECNOLOGIAS
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo TECNOLOGIAS enviando el Objeto JSON
        /// El ID del TECNOLOGIAS se genera automáticamente dentro del método
        /// </remarks>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult<Tecnologia>>
            InsertTecnologia(Tecnologia tecnologiaRequest)
        {
            Tecnologia tecnologiaNew =
                await this.repo.InsertTecnologiaAsync
                (tecnologiaRequest);
            return tecnologiaNew;
        }

        // PUT: api/tecnologias
        /// <summary>
        /// Modifica un TECNOLOGIAS en la BBDD mediante su ID, tabla TECNOLOGIAS
        /// </summary>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult> UpdateTecnologia
            (Tecnologia tecnologiaRequest)
        {
            var tecnologiaFind = 
                await this.repo.FindTecnologiaAsync(tecnologiaRequest.IdTecnologia);
            if (tecnologiaFind == null)
            {
                return NotFound();
            }
            await this.repo.UpdateTecnologiaAsync(tecnologiaRequest);
            return Ok();
        }

        // DELETE: api/tecnologias/{id}
        /// <summary>
        /// Elimina un TECNOLOGIAS en la BBDD mediante su ID. Tabla TECNOLOGIAS
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="id">ID de TECNOLOGIAS a eliminar</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteTecnologia(int id)
        {
            var tecnologiaFind = await this.repo.FindTecnologiaAsync(id);
            if (tecnologiaFind == null)
            {
                return NotFound();
            }
            await this.repo.DeleteTecnologiaAsync(id);
            return Ok();
        }
    }
}
