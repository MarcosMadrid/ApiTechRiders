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
    public class SolicitudAcreditacionesCharlasController : ControllerBase
    {
        private RepositoryTechRiders repo;
        public SolicitudAcreditacionesCharlasController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/peticionescharlas
        /// <summary>
        /// Obtiene el conjunto de PETICIONESCHARLAS, tabla PETICIONESCHARLAS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los PETICIONESCHARLAS de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PeticionCharla>>> Get()
        {
            return await this.repo.GetPeticionCharlaAsync();
        }

        // GET: api/peticionescharlas/{id}
        /// <summary>
        /// Obtiene un PETICIONESCHARLAS por su Id, tabla PETICIONESCHARLAS.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto PETICIONESCHARLAS por su ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto PETICIONESCHARLAS.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PeticionCharla>> Find(int id)
        {
            var peticion = await this.repo.FindPeticionCharlaAsync(id);
            if (peticion == null)
            {
                return NotFound();
            }
            return peticion;
        }

        // POST: api/peticionescharlas
        /// <summary>
        /// Crea un nuevo PETICIONESCHARLAS en la BBDD, tabla PETICIONESCHARLAS
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo PETICIONESCHARLAS enviando el IDCHARLA
        /// El ID se genera automáticamente dentro del método
        /// </remarks>
        /// <param name="idcharla">Id del Centro/Empresa de la petición de Alta</param>/// 
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PeticionCharla>>
                InsertPeticionCharla(int idcharla)
        {
            PeticionCharla peticionNew =
                    await this.repo.InsertPeticionCharlaAsync(idcharla);
            return peticionNew;
        }

        //// PUT: api/peticionescharlas
        ///// <summary>
        ///// Modifica un PETICIONESCHARLAS en la BBDD mediante su ID, tabla PETICIONESCHARLAS
        ///// </summary>
        ///// <param name="idpeticioncharla">Nombre de la categoria de la petición de Alta</param>/// 
        ///// <param name="idcharla">Id de la Charla para Modificar</param>/// 
        ///// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        ///// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        ///// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult> UpdatePeticionCharla
        //        (int idpeticioncharla, int idcharla)
        //{
        //    var peticionFind = await this.repo.FindPeticionCharlaAsync
        //        (idpeticioncharla);
        //    if (peticionFind == null)
        //    {
        //        return NotFound();
        //    }
        //    await this.repo.UpdatePeticionCharlaAsync(idpeticioncharla, idcharla);
        //    return Ok();
        //}

        // DELETE: api/peticionescharlas/{id}
        /// <summary>
        /// Elimina un PETICIONESCHARLAS en la BBDD mediante su ID. Tabla PETICIONESCHARLAS
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="idpeticioncharla">ID de PETICIONESCHARLAS a eliminar de PETICIONESCHARLAS</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{idpeticioncharla}")]
        public async Task<ActionResult> DeletePeticionCharla
            (int idpeticioncharla)
        {
            var peticionFind = await this.repo.FindPeticionCharlaAsync
                (idpeticioncharla);
            if (peticionFind == null)
            {
                return NotFound();
            }
            await this.repo.DeletePeticionCharlaAsync(idpeticioncharla);
            return Ok();
        }
    }
}
