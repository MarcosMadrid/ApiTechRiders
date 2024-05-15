using ApiTechRiders.Models;
using ApiTechRiders.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace ApiTechRiders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class CharlasController : ControllerBase
    {
        private RepositoryTechRiders repo;
        public CharlasController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/charlas
        /// <summary>
        /// Obtiene el conjunto de CHARLAS, tabla CHARLAS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos las Charlas de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Charla>>> Get()
        {
            return await this.repo.GetCharlasAsync();
        }

        // GET: api/charlas/{id}
        /// <summary>
        /// Obtiene una Charla por su Id, tabla CHARLAS.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto Charla por su ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto Charla.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Charla>> Find(int id)
        {
            var charla = await this.repo.FindCharlaAsync(id);
            if (charla == null)
            {
                return NotFound();
            }
            return charla;
        }

        // GET: api/charlas/FindCharlasStateAsync/{idstate}
        /// <summary>
        /// Obtiene conjunto de Charlas enviando el Estado de la charla, tabla CHARLAS.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto Charla por IDESTADOCHARLA.  Tabla Relacional ESTADOSCHARLA
        /// </remarks>
        /// <param name="idstate">Id del estado de la charla</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Route("[action]/{idstate}")]
        public async Task<ActionResult<List<Charla>>> 
            FindCharlasStateAsync(int idstate)
        {
            return await this.repo.GetCharlaStateAsync(idstate);
        }

        // POST: api/charlas
        /// <summary>
        /// Crea una nueva Charla en la BBDD, tabla CHARLAS
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo CHARLA enviando el Objeto JSON
        /// El ID de la charla se genera automáticamente dentro del método
        /// </remarks>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Charla>>
            InsertCharla(Charla charla)
        {
            Charla charlaNew =
                await this.repo.InsertCharlaAsync
                (charla);
            return charlaNew;
        }

        // PUT: api/charlas
        /// <summary>
        /// Modifica una Charla en la BBDD mediante su ID, tabla CHARLA
        /// </summary>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateCharla
            (Charla charla)
        {
            var charlaFind = await this.repo.FindCharlaAsync(charla.IdCharla);
            if (charlaFind == null)
            {
                return NotFound();
            }
            await this.repo.UpdateCharlaAsync(charla);
            return Ok();
        }

        // DELETE: api/charlas/{id}
        /// <summary>
        /// Elimina una Charla en la BBDD mediante su ID. Tabla CHARLAS
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="id">ID de la Charla a eliminar</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteCharla(int id)
        {
            var charla = await this.repo.FindCharlaAsync(id);
            if (charla == null)
            {
                return NotFound();
            }
            await this.repo.DeleteCharlaAsync(id);
            return Ok();
        }

        // PUT: api/charlas/AsociarTechriderCharla/{idtechrider}/{idcharla}
        /// <summary>
        /// Asocia un TechRider a una Charla, tabla CHARLA
        /// </summary>
        /// <remarks>
        /// Si el ID del TechRider es CERO, se elimina un TechRider de una 
        /// determinada Charla
        /// El estado de la Charla cambia automáticamente en este método
        /// </remarks>
        /// <param name="idtechrider">ID del TechRider a asociar a una Charla</param>
        /// <param name="idcharla">ID de la Charla a asociar el TechRider</param>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [Authorize]
        [Route("[action]/{idtechrider}/{idcharla}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AsociarTechriderCharla
            (int idtechrider, int idcharla)
        {
            var charlaFind = await this.repo.FindCharlaAsync(idcharla);
            if (charlaFind == null)
            {
                return NotFound();
            }
            await this.repo.UpdateCharlaTechRiderAsync
                (idtechrider, idcharla);
            return Ok();
        }

        // PUT: api/charlas/UpdateObservacionesCharla/{idcharla}/{observaciones}
        /// <summary>
        /// Modifica las Observaciones de una Charla, Tabla CHARLAS
        /// </summary>
        /// <param name="idcharla">ID de la Charla a modificar las Observaciones</param>
        /// <param name="observaciones">Texto con las observaciones de la Charla</param>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [Authorize]
        [Route("[action]/{idcharla}/{observaciones}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateObservacionesCharla
            (int idcharla, string observaciones)
        {
            var charlaFind = await this.repo.FindCharlaAsync(idcharla);
            if (charlaFind == null)
            {
                return NotFound();
            }
            await this.repo.UpdateObservacionesCharlaAsync
                (idcharla, observaciones);
            return Ok();
        }

        // PUT: api/charlas/updateestadocharla//{idcharla}/{idestadocharla}
        /// <summary>
        /// Modifica es estado de una Charla, Tabla CHARLAS
        /// </summary>
        /// <param name="idcharla">ID de la Charla a cambiar el Estado</param>
        /// <param name="idestadocharla">ID del estado de la charla</param>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [Authorize]
        [Route("[action]/{idcharla}/{idestadocharla}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateEstadoCharla
            (int idcharla, int idestadocharla)
        {
            var charlaFind = await this.repo.FindCharlaAsync(idcharla);
            if (charlaFind == null)
            {
                return NotFound();
            }
            await this.repo.UpdateEstadoCharlaAsync
                (idcharla, idestadocharla);
            return Ok();
        }

        //updatefechacharla//{idcharla}/{fechacharla}
        // PUT: api/charlas/updatefechacharla//{idcharla}/{fechacharla}
        /// <summary>
        /// Modifica la Fecha de una Charla, Tabla CHARLAS
        /// </summary>
        /// <param name="idcharla">ID de la Charla a cambiar la Fecha</param>
        /// <param name="fechacharla">Nueva fecha de la charla (formato yyyy-mm-dd)</param>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [Authorize]
        [Route("[action]/{idcharla}/{fechacharla}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateFechaCharla
            (int idcharla, DateTime fechacharla)
        {
            var charlaFind = await this.repo.FindCharlaAsync(idcharla);
            if (charlaFind == null)
            {
                return NotFound();
            }
            await this.repo.UpdateFechaCharlaAsync
                (idcharla, fechacharla);
            return Ok();
        }
    }
}
