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
    public class PeticionesTecnologiasController : ControllerBase
    {
        private RepositoryTechRiders repo;
        public PeticionesTecnologiasController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/peticionestecnologias
        /// <summary>
        /// Obtiene el conjunto de PETICIONES, tabla PETICIONES.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los PETICIONES de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PeticionTecnologia>>> Get()
        {
            return await this.repo.GetPeticionTecnologiasAsync();
        }

        // GET: api/peticionestecnologias/{id}
        /// <summary>
        /// Obtiene un PETICIONES_TECNOLOGIAS por su Id, tabla PETICIONES_TECNOLOGIAS.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto PETICIONES_TECNOLOGIAS por su ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto PETICIONES_TECNOLOGIAS.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PeticionTecnologia>> Find(int id)
        {
            var peticion = await this.repo.FindPeticionTecnologiasAsync(id);
            if (peticion == null)
            {
                return NotFound();
            }
            return peticion;
        }

        // POST: api/peticionestecnologias/{tecnologia}
        /// <summary>
        /// Crea un nuevo PETICIONES_TECNOLOGIAS en la BBDD, tabla PETICIONES_TECNOLOGIAS
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo PETICIONES_TECNOLOGIAS enviando Tecnología
        /// El ID se genera automáticamente dentro del método
        /// </remarks>
        /// <param name="tecnologia">Nombre la tecnología a solicitar.</param>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PeticionTecnologia>>
                PostPeticionTecnologia
            (string tecnologia)
        {
            PeticionTecnologia peticionNew =
                    await this.repo.InsertPeticionTecnologiaAsync
                    (tecnologia);
            return peticionNew;
        }

        // POST: api/peticionestecnologias/InsertPeticionTecnologia/{tecnologia}
        /// <summary>
        /// Crea un nuevo PETICIONES_TECNOLOGIAS en la BBDD, tabla PETICIONES_TECNOLOGIAS
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo PETICIONES_TECNOLOGIAS enviando la tecnología
        /// El ID se genera automáticamente dentro del método
        /// </remarks>
        /// <param name="tecnologia">Nombre la tecnología a solicitar.</param>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("[action]/{tecnologia}")]
        public async Task<ActionResult<PeticionTecnologia>>
                InsertPeticionTecnologia
            (string tecnologia)
        {
            PeticionTecnologia peticionNew =
                    await this.repo.InsertPeticionTecnologiaAsync
                    (tecnologia);
            return peticionNew;
        }

        //// PUT: api/peticionestecnologias
        ///// <summary>
        ///// Modifica un PETICIONES_TECNOLOGIAS en la BBDD mediante su ID, tabla PETICIONES_TECNOLOGIAS
        ///// </summary>
        ///// <param name="idpeticiontecnologia">Id de la petición de tecnología a modificar.</param>         
        ///// <param name="tecnologia">Nombre la tecnología a solicitar.</param>
        ///// <param name="idtipopeticioncategoria">Id de la categoría de la petición</param>       
        ///// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        ///// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        ///// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult> UpdatePeticion
        //        (int idpeticiontecnologia,string tecnologia, int idtipopeticioncategoria)
        //{
        //    var peticionFind = await this.repo.FindPeticionTecnologiasAsync
        //        (idpeticiontecnologia);
        //    if (peticionFind == null)
        //    {
        //        return NotFound();
        //    }
        //    await this.repo.UpdatePeticionTecnologiaAsync
        //        (idpeticiontecnologia, tecnologia, idtipopeticioncategoria);
        //    return Ok();
        //}

        // DELETE: api/peticionestecnologias/{id}
        /// <summary>
        /// Elimina un PETICIONES_TECNOLOGIAS en la BBDD mediante su ID. Tabla PETICIONES_TECNOLOGIAS
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="id">ID de PETICIONES_TECNOLOGIAS a eliminar</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePeticionTecnologia(int id)
        {
            var peticionFind = await this.repo.FindPeticionTecnologiasAsync
                (id);
            if (peticionFind == null)
            {
                return NotFound();
            }
            await this.repo.DeletePeticionTecnologiaAsync(id);
            return Ok();
        }
    }
}
