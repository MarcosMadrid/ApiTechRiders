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
    public class RolesController : ControllerBase
    {
        private RepositoryTechRiders repo;
        public RolesController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/roles
        /// <summaryROLES
        /// Obtiene el conjunto de ROLES, tabla PROVINCIAS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los ROLES de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Role>>> Get()
        {
            return await this.repo.GetRolesAsync();
        }

        // GET: api/roles/{id}
        /// <summary>
        /// Obtiene un ROLES por su Id, tabla ROLES.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto ROLES por su ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto ROLES.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> Find(int id)
        {
            var role = await this.repo.FindRoleAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return role;
        }

        // POST: api/roles
        /// <summary>
        /// Crea un nuevo ROLES en la BBDD, tabla ROLES
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo ROLES enviando el nombre del tipo de ROLE
        /// El ID se genera automáticamente dentro del método
        /// </remarks>
        /// <param name="tiporole">El nombre de la provincia</param>/// 
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Role>>
                InsertRole(string tiporole)
        {
            Role roleNew =
                    await this.repo.InsertRoleAsync(tiporole);
            return roleNew;
        }

        // PUT: api/roles
        /// <summary>
        /// Modifica un ROLES en la BBDD mediante su ID, tabla ROLES
        /// </summary>
        /// <param name="idrole">Id del Role a Modificar</param>/// 
        /// <param name="tiporole">El nuevo Tipo de Role</param>/// 
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateRole
                (int idrole, string tiporole)
        {
            var roleFind = await this.repo.FindProvinciaAsync
                (idrole);
            if (roleFind == null)
            {
                return NotFound();
            }
            await this.repo.UpdateRoleAsync(idrole, tiporole);
            return Ok();
        }

        // DELETE: api/roles/{id}
        /// <summary>
        /// Elimina un ROLES en la BBDD mediante su ID. Tabla ROLES
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="idrole">Id del Role a Eliminar</param>/// 
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<ActionResult> DeleteRole
            (int idrole)
        {
            var roleFind = await this.repo.FindRoleAsync
                (idrole);
            if (roleFind == null)
            {
                return NotFound();
            }
            await this.repo.DeleteRoleAsync(idrole);
            return Ok();
        }
    }
}
