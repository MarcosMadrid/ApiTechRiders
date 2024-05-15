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
    public class TipoTecnologiasController : ControllerBase
    {
        private RepositoryTechRiders repo;
        public TipoTecnologiasController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/tipotecnologia
        /// <summary>
        /// Obtiene el conjunto de TIPOTECNOLOGIAS, tabla TIPOTECNOLOGIAS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los TIPOTECNOLOGIAS de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TipoTecnologia>>> Get()
        {
            return await this.repo.GetTipoTecnologiaAsync();
        }

        // GET: api/tipotecnologia/{id}
        /// <summary>
        /// Obtiene un TIPOTECNOLOGIAS por su Id, tabla TIPOTECNOLOGIAS.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto TIPOTECNOLOGIAS por su ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto TIPOTECNOLOGIAS.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoTecnologia>> Find(int id)
        {
            var peticion = await this.repo.FindTipoTecnologiaAsync(id);
            if (peticion == null)
            {
                return NotFound();
            }
            return peticion;
        }

        // POST: api/tipotecnologia
        /// <summary>
        /// Crea un nuevo TIPOTECNOLOGIAS en la BBDD, tabla TIPOTECNOLOGIAS
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo TIPOTECNOLOGIAS enviando la Descripcion
        /// El ID se genera automáticamente dentro del método
        /// </remarks>
        /// <param name="descripcion">Descripción del tipo de Tecnología</param>/// 
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult<TipoTecnologia>>
                InsertTipoEmpresa(string descripcion)
        {
            TipoTecnologia peticionNew =
                    await this.repo.InsertTipoTecnologiaAsync(descripcion);
            return peticionNew;
        }

        // PUT: api/tipotecnologia
        /// <summary>
        /// Modifica un TIPOTECNOLOGIAS en la BBDD mediante su ID, tabla TIPOTECNOLOGIAS
        /// </summary>
        /// <param name="idtipotecnologia">ID del tipo de tecnología a modificar</param>/// 
        /// <param name="descripcion">Nueva descripción del Tipo de tecnología</param>/// 
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult> UpdateTipoTecnologia
                (int idtipotecnologia, string descripcion)
        {
            var peticionFind = await this.repo.FindTipoTecnologiaAsync
                (idtipotecnologia);
            if (peticionFind == null)
            {
                return NotFound();
            }
            await this.repo.UpdateTipoTecnologiaAsync
                (idtipotecnologia, descripcion);
            return Ok();
        }

        // DELETE: api/tipotecnologia/{idtipotecnologia}
        /// <summary>
        /// Elimina un TIPOTECNOLOGIAS en la BBDD mediante su ID. Tabla TIPOTECNOLOGIAS
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="idtipotecnologia">ID de TIPOTECNOLOGIAS a eliminar de TIPOTECNOLOGIAS</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{idtipotecnologia}")]
        [Authorize]
        public async Task<ActionResult> DeleteTipoEmpresa
            (int idtipotecnologia)
        {
            var peticionFind = await this.repo.FindTipoTecnologiaAsync
                (idtipotecnologia);
            if (peticionFind == null)
            {
                return NotFound();
            }
            await this.repo.DeleteTipoTecnologiaAsync(idtipotecnologia);
            return Ok();
        }
    }
}
