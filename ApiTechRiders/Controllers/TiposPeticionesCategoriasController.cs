using ApiTechRiders.Models;
using ApiTechRiders.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTechRiders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposPeticionesCategoriasController : ControllerBase
    {
        private RepositoryTechRiders repo;
        public TiposPeticionesCategoriasController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/tipospeticionescategorias
        /// <summary>
        /// Obtiene el conjunto de TIPOSPETICIONESCATEGORIAS, tabla TIPOSPETICIONESCATEGORIAS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los TIPOSPETICIONESCATEGORIAS de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TipoPeticionCategoria>>> Get()
        {
            return await this.repo.GetTipoPeticionCategoriaAsync();
        }

        // GET: api/tipospeticionescategorias/{id}
        /// <summary>
        /// Obtiene un TIPOSPETICIONESCATEGORIAS por su Id, tabla TIPOSPETICIONESCATEGORIAS.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto TIPOSPETICIONESCATEGORIAS por su ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto TIPOSPETICIONESCATEGORIAS.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPeticionCategoria>> Find(int id)
        {
            var peticion = await this.repo.FindTipoPeticionCategoriaAsync(id);
            if (peticion == null)
            {
                return NotFound();
            }
            return peticion;
        }

        // POST: api/tipospeticionescategorias
        /// <summary>
        /// Crea un nuevo TIPOSPETICIONESCATEGORIAS en la BBDD, tabla TIPOSPETICIONESCATEGORIAS
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo TIPOSPETICIONESCATEGORIAS
        /// El ID se genera automáticamente dentro del método
        /// </remarks>
        /// <param name="nombrecategoria">Nombre la Categoría de la petición.</param>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult<TipoPeticionCategoria>>
                InsertTipoPeticionCategoria
            (string nombrecategoria)
        {
            TipoPeticionCategoria tipoPeticionNew =
                    await this.repo.InsertTiposPeticionesCategoriasAsync
                    (nombrecategoria);
            return tipoPeticionNew;
        }

        // PUT: api/tipospeticionescategorias
        /// <summary>
        /// Modifica un TIPOSPETICIONESCATEGORIAS en la BBDD mediante su ID, tabla TIPOSPETICIONESCATEGORIAS
        /// </summary>
        /// <param name="idtipopeticioncategoria">Id de la categoría de la petición</param>   
        /// <param name="nombrecategoria">Nombre la Categoría de la petición a modificar.</param> 
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult> UpdateTipoPeticionCategoria
                (int idtipopeticioncategoria, string nombrecategoria)
        {
            var peticionFind = await this.repo.FindTipoPeticionCategoriaAsync
                (idtipopeticioncategoria);
            if (peticionFind == null)
            {
                return NotFound();
            }
            await this.repo.UpdateTipoPeticionCategoriaAsync
                (idtipopeticioncategoria, nombrecategoria);
            return Ok();
        }

        // DELETE: api/tipospeticionescategorias/{id}
        /// <summary>
        /// Elimina un TIPOSPETICIONESCATEGORIAS en la BBDD mediante su ID. Tabla TIPOSPETICIONESCATEGORIAS
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="id">ID de TIPOSPETICIONESCATEGORIAS a eliminar</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteTipoPeticionCategoria(int id)
        {
            var peticionFind = await this.repo.FindTipoPeticionCategoriaAsync
                (id);
            if (peticionFind == null)
            {
                return NotFound();
            }
            await this.repo.DeleteTipoPeticionCategoriaAsync(id);
            return Ok();
        }
    }
}
