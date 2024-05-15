using ApiTechRiders.Models;
using ApiTechRiders.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTechRiders.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class PeticionesAltaUsersController : ControllerBase
    {
        private RepositoryTechRiders repo;
        public PeticionesAltaUsersController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/peticionesaltausers
        /// <summary>
        /// Obtiene el conjunto de PETICIONESALTAUSERS, tabla PETICIONESALTAUSERS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los PETICIONESALTAUSERS de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PeticionAltaUsers>>> Get()
        {
            return await this.repo.GetPeticionesAltaUsersAsync();
        }

        // GET: api/peticionesaltausers/usuario/{iduser}
        /// <summary>
        /// Obtiene el conjunto de PETICIONESALTAUSERS de UN USUARIO mediante su ID.
        /// </summary>
        /// <remarks>
        /// Método para devolver todss los PETICIONESALTAUSERS de la BBDD de un Usuario
        /// </remarks>
        /// <param name="iduser">Id (GUID) del objeto PETICIONESALTAUSERS.</param>/// 
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]/{iduser}")]
        public async Task<ActionResult<List<PeticionAltaUsers>>> Usuario(int iduser)
        {
            return await this.repo.FindPeticionesAltaUsuarioAsync(iduser);
        }

        // GET: api/peticionesaltausers/{id}
        /// <summary>
        /// Obtiene un PETICIONESALTAUSERS por su Id, tabla PETICIONESALTAUSERS.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto PETICIONESALTAUSERS por su ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto PETICIONESALTAUSERS.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<PeticionAltaUsers>> Find(int id)
        {
            var peticion = await this.repo.FindPeticionesAltaUsersAsync(id);
            if (peticion == null)
            {
                return NotFound();
            }
            return peticion;
        }

        // POST: api/peticionesaltausers
        /// <summary>
        /// Crea un nuevo PETICIONESALTAUSERS en la BBDD, tabla PETICIONESALTAUSERS
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo PETICIONESALTAUSERS enviando el Objeto JSON
        /// El ID se genera automáticamente dentro del método
        /// </remarks>
        /// <param name="iduser">Id del Usuario de la petición de Alta</param>/// 
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PeticionAltaUsers>>
                InsertPeticionAltaUsers(int iduser)
        {
            PeticionAltaUsers peticionNew =
                    await this.repo.InsertPeticionAltaUsersAsync(iduser);
            return peticionNew;
        }

        // DELETE: api/peticionesaltausers/{id}
        /// <summary>
        /// Elimina un PETICIONESALTAUSERS en la BBDD mediante su ID. Tabla PETICIONESALTAUSERS
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="idpeticion">ID de PETICIONES a eliminar de PETICIONESALTAUSERS</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> DeletePeticionAltaUsers
            (int idpeticion)
        {
            var peticionFind = await this.repo.FindPeticionesAltaUsersAsync
                (idpeticion);
            if (peticionFind == null)
            {
                return NotFound();
            }
            await this.repo.DeletePeticionAltaUsersAsync(idpeticion);
            return Ok();
        }

    }
}
