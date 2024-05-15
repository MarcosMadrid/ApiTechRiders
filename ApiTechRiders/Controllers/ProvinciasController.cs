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
    public class ProvinciasController : ControllerBase
    {
        private RepositoryTechRiders repo;
        public ProvinciasController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/provincias
        /// <summary>
        /// Obtiene el conjunto de PROVINCIAS, tabla PROVINCIAS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los PROVINCIAS de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Provincia>>> Get()
        {
            return await this.repo.GetProvinciasAsync();
        }

        // GET: api/provincias/{id}
        /// <summary>
        /// Obtiene un PROVINCIAS por su Id, tabla PROVINCIAS.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto PROVINCIAS por su ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto PROVINCIAS.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Provincia>> Find(int id)
        {
            var peticion = await this.repo.FindProvinciaAsync(id);
            if (peticion == null)
            {
                return NotFound();
            }
            return peticion;
        }

        // POST: api/provincias
        /// <summary>
        /// Crea un nuevo PROVINCIAS en la BBDD, tabla PROVINCIAS
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo PROVINCIAS enviando el nombre de la provincia
        /// El ID se genera automáticamente dentro del método
        /// </remarks>
        /// <param name="nombreprovincia">El nombre de la provincia</param>/// 
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]

        public async Task<ActionResult<Provincia>>
                InsertProvincia(string nombreprovincia)
        {
            Provincia provinciaNew =
                    await this.repo.InsertProvinciaAsync(nombreprovincia);
            return provinciaNew;
        }

        // PUT: api/provincias
        /// <summary>
        /// Modifica un PROVINCIAS en la BBDD mediante su ID, tabla PROVINCIAS
        /// </summary>
        /// <param name="idprovincia">Id de la Provincia a Modificar</param>/// 
        /// <param name="nombreprovincia">El nombre de la provincia</param>/// 
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult> UpdateProvincia
                (int idprovincia, string nombreprovincia)
        {
            var provinciaFind = await this.repo.FindProvinciaAsync
                (idprovincia);
            if (provinciaFind == null)
            {
                return NotFound();
            }
            await this.repo.UpdateProvinciaAsync(idprovincia, nombreprovincia);
            return Ok();
        }

        // DELETE: api/provincias/{id}
        /// <summary>
        /// Elimina un PROVINCIAS en la BBDD mediante su ID. Tabla PROVINCIAS
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="idprovincia">Id de la Provincia a Modificar</param>/// 
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> DeleteProvincia
            (int idprovincia)
        {
            var provinciaFind = await this.repo.FindProvinciaAsync
                (idprovincia);
            if (provinciaFind == null)
            {
                return NotFound();
            }
            await this.repo.DeleteProvinciaAsync(idprovincia);
            return Ok();
        }
    }
}
