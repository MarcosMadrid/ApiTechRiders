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
    public class TecnologiasTechRidersController : ControllerBase
    {
        private RepositoryTechRiders repo;
        public TecnologiasTechRidersController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/tecnologiastechriders
        /// <summary>
        /// Obtiene el conjunto de TECNOLOGIASTECHRIDERS, tabla TECNOLOGIASTECHRIDERS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los TECNOLOGIASTECHRIDERS de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TecnologiaTechRiders>>> Get()
        {
            return await this.repo.GetTecnologiasTechRidersAsync();
        }

        //// GET: api/tecnologiastechriders/{idtechrider}/{idtecnologia}
        ///// <summary>
        ///// Obtiene un TECNOLOGIASTECHRIDERS por el Id de Tecnologia y por el 
        ///// ID del TechRider, tabla TECNOLOGIASTECHRIDERS.
        ///// </summary>
        ///// <remarks>
        ///// Permite buscar un objeto TECNOLOGIASTECHRIDERS por su ID
        ///// </remarks>
        ///// <param name="idtechrider">Id (GUID) del objeto TECHRIDER.</param>
        ///// <param name="idtecnologia">Id (GUID) del objeto ID DE LA TECNOLOGIA.</param>         
        ///// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        ///// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[HttpGet]
        //[Route("[action]/{idtechrider}/{idtecnologia}")]
        //public async Task<ActionResult<TecnologiaTechRiders>>
        //    Find(int idtechrider, int idtecnologia)
        //{
        //    var tecnologiaTechRider =
        //        await this.repo.FindTecnologiasTechRidersAsync(idtechrider, idtecnologia);
        //    if (tecnologiaTechRider == null)
        //    {
        //        return NotFound();
        //    }
        //    return tecnologiaTechRider;
        //}

        // GET: api/tecnologiastechriders/all/{idtechrider}
        /// <summary>
        /// Obtiene un TECNOLOGIASTECHRIDERS por el Id del TechRider
        /// </summary>
        /// <remarks>
        /// Permite buscar todas las TECNOLOGIASTECHRIDERS por su ID de TechRider
        /// </remarks>
        /// <param name="idtechrider">Id (GUID) del objeto TECHRIDER.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Route("[action]/{idtechrider}")]
        public async Task<ActionResult<List<TecnologiaTechRiders>>>
            All(int idtechrider)
        {
            var tecnologiasTechRider =
                await this.repo.GetTecnologiasTechRidersAsync(idtechrider);
            if (tecnologiasTechRider == null)
            {
                return NotFound();
            }
            return tecnologiasTechRider;
        }

        // POST: api/tecnologiastechriders/{idtechrider}/{idtecnologia}
        /// <summary>
        /// Crea un nuevo TECNOLOGIASTECHRIDERS en la BBDD, tabla TECNOLOGIASTECHRIDERS
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo TECNOLOGIASTECHRIDERS enviando el TECHRIDER y 
        /// el ID de la Tecnología
        /// </remarks>
        /// <param name="idtechrider">Id (GUID) del objeto TECHRIDER.</param>
        /// <param name="idtecnologia">Id (GUID) del objeto ID DE LA TECNOLOGIA.</param>  
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult<TecnologiaTechRiders>>
                PostTecnologiaTechRiders(int idtechrider, int idtecnologia)
        {
            TecnologiaTechRiders peticionNew =
                    await this.repo.InsertTecnologiaTechRiderAsync
                    (idtechrider, idtecnologia);
            return peticionNew;
        }

        // POST: api/tecnologiastechriders/{idtechrider}/{idtecnologia}
        /// <summary>
        /// Crea un nuevo TECNOLOGIASTECHRIDERS en la BBDD, tabla TECNOLOGIASTECHRIDERS
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo TECNOLOGIASTECHRIDERS enviando el TECHRIDER y 
        /// el ID de la Tecnología
        /// </remarks>
        /// <param name="idtechrider">Id (GUID) del objeto TECHRIDER.</param>
        /// <param name="idtecnologia">Id (GUID) del objeto ID DE LA TECNOLOGIA.</param>  
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("[action]/{idtechrider}/{idtecnologia}")]
        [Authorize]
        public async Task<ActionResult<TecnologiaTechRiders>>
                InsertTecnologiaTechRiders(int idtechrider, int idtecnologia)
        {
            TecnologiaTechRiders peticionNew =
                    await this.repo.InsertTecnologiaTechRiderAsync
                    (idtechrider, idtecnologia);
            return peticionNew;
        }

        // PUT: api/tecnologiastechriders/{idtechrider}/{idtecnologia}
        /// <summary>
        /// Modifica un TECNOLOGIASTECHRIDERS en la BBDD mediante su ID, tabla TECNOLOGIASTECHRIDERS
        /// </summary>
        /// <param name="idtechrider">Id (GUID) del objeto TECHRIDER.</param>
        /// <param name="idtecnologia">Id (GUID) del objeto ID DE LA TECNOLOGIA.</param>  
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult> UpdateTecnologiaTechRiders
                (int idtechrider, int idtecnologia)
        {
            var peticionFind = await this.repo.FindTecnologiasTechRidersAsync
                (idtechrider, idtecnologia);
            if (peticionFind == null)
            {
                return NotFound();
            }
            await this.repo.UpdateTecnologiaTechRiderAsync(idtechrider, idtecnologia);
            return Ok();
        }

        // DELETE: api/tecnologiastechriders/{id}
        /// <summary>
        /// Elimina un TECNOLOGIASTECHRIDERS en la BBDD mediante su ID. Tabla TECNOLOGIASTECHRIDERS
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="idtechrider">Id (GUID) del objeto TECHRIDER.</param>
        /// <param name="idtecnologia">Id (GUID) del objeto ID DE LA TECNOLOGIA.</param> 
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        [Route("[action]/{idtechrider}/{idtecnologia}")]
        [Authorize]
        public async Task<ActionResult> Delete
            (int idtechrider, int idtecnologia)
        {
            var peticionFind = await this.repo.FindTecnologiasTechRidersAsync
                (idtechrider, idtecnologia);
            if (peticionFind == null)
            {
                return NotFound();
            }
            await this.repo.DeleteTecnologiaTechRidersAsync
                (idtechrider, idtecnologia);
            return Ok();
        }
    }
}
