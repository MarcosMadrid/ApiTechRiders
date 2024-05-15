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
    public class TipoEmpresaController : ControllerBase
    {
        private RepositoryTechRiders repo;
        public TipoEmpresaController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/tipoempresa
        /// <summary>
        /// Obtiene el conjunto de TIPOEMPRESA, tabla TIPOEMPRESA.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los TIPOEMPRESA de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TipoEmpresa>>> Get()
        {
            return await this.repo.GetTipoEmpresaAsync();
        }

        // GET: api/tipoempresa/{id}
        /// <summary>
        /// Obtiene un TIPOEMPRESA por su Id, tabla TIPOEMPRESA.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto TIPOEMPRESA por su ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto TIPOEMPRESA.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoEmpresa>> Find(int id)
        {
            var peticion = await this.repo.FindTipoEmpresaAsync(id);
            if (peticion == null)
            {
                return NotFound();
            }
            return peticion;
        }

        // POST: api/tipoempresa
        /// <summary>
        /// Crea un nuevo TIPOEMPRESA en la BBDD, tabla TIPOEMPRESA
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo TIPOEMPRESA enviando la Descripcion
        /// El ID se genera automáticamente dentro del método
        /// </remarks>
        /// <param name="descripcion">Descripción del tipo de Empresa</param>/// 
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult<TipoEmpresa>>
                InsertTipoEmpresa(string descripcion)
        {
            TipoEmpresa peticionNew =
                    await this.repo.InsertTipoEmpresaAsync(descripcion);
            return peticionNew;
        }

        // PUT: api/tipoempresa
        /// <summary>
        /// Modifica un TIPOEMPRESA en la BBDD mediante su ID, tabla TIPOEMPRESA
        /// </summary>
        /// <param name="idtipoempresa">ID del tipo de empresa a modificar</param>/// 
        /// <param name="descripcion">Nueva descripción del Tipo de Empresa</param>/// 
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult> UpdateTipoEmpresa
                (int idtipoempresa, string descripcion)
        {
            var peticionFind = await this.repo.FindTipoEmpresaAsync
                (idtipoempresa);
            if (peticionFind == null)
            {
                return NotFound();
            }
            await this.repo.UpdateTipoEmpresaAsync(idtipoempresa, descripcion);
            return Ok();
        }

        // DELETE: api/tipoempresa/{idtipoempresa}
        /// <summary>
        /// Elimina un TIPOEMPRESA en la BBDD mediante su ID. Tabla TIPOEMPRESA
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="idtipoempresa">ID de TIPOEMPRESA a eliminar de TIPOEMPRESA</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{idtipoempresa}")]
        [Authorize]
        public async Task<ActionResult> DeleteTipoEmpresa
            (int idtipoempresa)
        {
            var peticionFind = await this.repo.FindTipoEmpresaAsync
                (idtipoempresa);
            if (peticionFind == null)
            {
                return NotFound();
            }
            await this.repo.DeleteTipoEmpresaAsync(idtipoempresa);
            return Ok();
        }
    }
}
