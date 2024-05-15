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
    public class PeticionesCentroEmpresaController : ControllerBase
    {
        private RepositoryTechRiders repo;
        public PeticionesCentroEmpresaController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/peticionescentroempresa
        /// <summary>
        /// Obtiene el conjunto de PETICIONESCENTROEMPRESA, tabla PETICIONESCENTROEMPRESA.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los PETICIONESCENTROEMPRESA de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PeticionCentroEmpresa>>> Get()
        {
            return await this.repo.GetPeticionCentroEmpresaAsync();
        }

        // GET: api/peticionescentroempresa/{id}
        /// <summary>
        /// Obtiene un PETICIONESCENTROEMPRESA por su Id, tabla PETICIONESCENTROEMPRESA.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto PETICIONESCENTROEMPRESA por su ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto PETICIONESCENTROEMPRESA.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PeticionCentroEmpresa>> Find(int id)
        {
            var peticion = await this.repo.FindPeticionCentroEmpresaAsync(id);
            if (peticion == null)
            {
                return NotFound();
            }
            return peticion;
        }

        // POST: api/peticionescentroempresa
        /// <summary>
        /// Crea un nuevo PETICIONESCENTROEMPRESA en la BBDD, tabla PETICIONESCENTROEMPRESA
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo PETICIONESCENTROEMPRESA enviando el IDEMPRESA
        /// El ID se genera automáticamente dentro del método
        /// </remarks>
        /// <param name="idcentroempresa">Id del Centro/Empresa de la petición de Alta</param>/// 
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PeticionCentroEmpresa>>
                InsertPeticionCentroEmpresa(int idcentroempresa)
        {
            PeticionCentroEmpresa peticionNew =
                    await this.repo.InsertPeticionCentroEmpresaAsync(idcentroempresa);
            return peticionNew;
        }

        //// PUT: api/peticionescentroempresa
        ///// <summary>
        ///// Modifica un PETICIONES en la BBDD mediante su ID, tabla PETICIONES
        ///// </summary>
        ///// <param name="idpeticion">Nombre de la categoria de la petición de Alta</param>/// 
        ///// <param name="idcentroempresa">Id del Centro/Empresa para modificar</param>/// 
        ///// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        ///// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        ///// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult> UpdatePeticionCentroEmpresa
        //        (int idpeticion, int idcentroempresa)
        //{
        //    var peticionFind = await this.repo.FindPeticionCentroEmpresaAsync
        //        (idpeticion);
        //    if (peticionFind == null)
        //    {
        //        return NotFound();
        //    }
        //    await this.repo.UpdatePeticionCentroEmpresaAsync(idpeticion, idcentroempresa);
        //    return Ok();
        //}

        // DELETE: api/peticionescentroempresa/{id}
        /// <summary>
        /// Elimina un PETICIONESCENTROEMPRESA en la BBDD mediante su ID. Tabla PETICIONESCENTROEMPRESA
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="idpeticion">ID de PETICIONESCENTROEMPRESA a eliminar de PETICIONESCENTROEMPRESA</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<ActionResult> DeletePeticionCentroEmpresa
            (int idpeticion)
        {
            var peticionFind = await this.repo.FindPeticionCentroEmpresaAsync
                (idpeticion);
            if (peticionFind == null)
            {
                return NotFound();
            }
            await this.repo.DeletePeticionCentroEmpresaAsync(idpeticion);
            return Ok();
        }

        //
        // DELETE: api/peticionescentroempresa/DeletePeticionEmpresaAll/{idpeticion}
        /// <summary>
        /// Elimina un PETICIONESCENTROEMPRESA en la BBDD mediante su ID. Tabla PETICIONESCENTROEMPRESA
        /// </summary>
        /// <remarks>
        /// Elimina la petición de la Empresa, quita al responsable y también elimina la Empresa
        /// </remarks>
        /// <param name="idpeticion">ID de PETICIONESCENTROEMPRESA a eliminar de PETICIONESCENTROEMPRESA</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        [Route("[action]/{idpeticion}")]
        public async Task<ActionResult> DeletePeticionEmpresaAll
            (int idpeticion)
        {
            var peticionFind = await this.repo.FindPeticionCentroEmpresaAsync
                (idpeticion);
            if (peticionFind == null)
            {
                return NotFound();
            }
            await this.repo.DeletePeticionCentroEmpresaAllAsync(idpeticion);
            return Ok();
        }
    }
}
