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
    public class EmpresasCentrosController : ControllerBase
    {
        private RepositoryTechRiders repo;
        public EmpresasCentrosController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/empresascentros
        /// <summary>
        /// Obtiene el conjunto de EMPRESASCENTROS, tabla EMPRESASCENTROS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los EmpresasCentros de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmpresasCentros>>> Get()
        {
            return await this.repo.GetEmpresasCentrosAsync();
        }

        // GET: api/empresascentros
        /// <summary>
        /// Obtiene el conjunto de EMPRESAS/CENTROS con Formato, tabla EMPRESASFORMATOVIEW.
        /// </summary>
        /// <remarks>
        /// Método para devolver todas las Empresas/Centros con formato
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmpresaFormatoView>>> EmpresasFormato()
        {
            return await this.repo.GetTodosEmpresasFormatoViewAsync();
        }

        // GET: api/EmpresasSinResponsable
        /// <summary>
        /// Obtiene el conjunto de EMPRESA con Formato sin Responsable, tabla EMPRESASFORMATOVIEW.
        /// </summary>
        /// <remarks>
        /// Método para devolver todas las Empresas sin Responsable asociado
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmpresaFormatoView>>> 
            EmpresasSinResponsable()
        {
            return await this.repo.GetEmpresasFormatoLibresViewAsync();
        }

        // GET: api/EmpresasConResponsables
        /// <summary>
        /// Obtiene el conjunto de EMPRESA con Formato CON Responsables, tabla EMPRESASFORMATOVIEW.
        /// </summary>
        /// <remarks>
        /// Método para devolver todas las Empresas con Responsable asignado
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmpresaFormatoView>>>
            EmpresasConResponsables()
        {
            return await this.repo.GetEmpresasFormatoConResponsablesViewAsync();
        }

        // GET: api/empresascentros/EmpresasCentrosFormatoEstado/{estado}
        /// <summary>
        /// Filtra empresas/centros por su Estado, tabla EMPRESASFORMATOVIEW.
        /// </summary>
        /// <remarks>
        /// Método para devolver todas las Empresas/Centros con formato por su estado
        /// 0 - PENDIENTE, 1 - ACTIVO
        /// </remarks>
        /// <param name="estado">Estado de la empresa.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Route("[action]/{estado}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmpresaFormatoView>>>
            EmpresasCentrosFormatoEstado(int estado)
        {
            return await this.repo.GetEmpresasFormatoViewByStateAsync(estado);
        }

        // GET: api/empresascentros/{estado}
        /// <summary>
        /// Filtra empresas/centros por su Estado, tabla EMPRESASCENTROS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los EmpresasCentros por su estado
        /// 0 - PENDIENTE, 1 - ACTIVO
        /// </remarks>
        /// <param name="estado">Estado de la empresa.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Route("[action]/{estado}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmpresasCentros>>> 
            EmpresasCentrosEstado(int estado)
        {
            return await this.repo.GetEmpresasCentrosByStateAsync(estado);
        }

        // GET: api/empresascentros/{id}
        /// <summary>
        /// Obtiene un EMPRESASCENTROS por su Id, tabla EMPRESASCENTROS.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto EMPRESASCENTROS por su ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto EMPRESASCENTROS.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresasCentros>> Find(int id)
        {
            var empresasCentros = await this.repo.FindEmpresasCentrosAsync(id);
            if (empresasCentros == null)
            {
                return NotFound();
            }
            return empresasCentros;
        }

        // POST: api/empresascentros
        /// <summary>
        /// Crea un nuevo EMPRESASCENTROS en la BBDD, tabla EMPRESASCENTROS
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo EMPRESASCENTROS enviando el Objeto JSON
        /// El ID se genera automáticamente dentro del método
        /// </remarks>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult<EmpresasCentros>>
            InsertEmpresasCentros(EmpresasCentros empresasCentrosRequest)
        {
            EmpresasCentros empresasCentrosNew =
                await this.repo.InsertEmpresasCentrosAsync
                (empresasCentrosRequest);
            return empresasCentrosNew;
        }

        // PUT: api/empresascentros
        /// <summary>
        /// Modifica un EMPRESASCENTROS en la BBDD mediante su ID, tabla EMPRESASCENTROS
        /// </summary>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult> UpdateEmpresasCentros
            (EmpresasCentros empresasCentrosRequest)
        {
            var empresasCentrosFind = await this.repo.FindEmpresasCentrosAsync
                (empresasCentrosRequest.IdEmpresaCentro);
            if (empresasCentrosFind == null)
            {
                return NotFound();
            }
            await this.repo.UpdateEmpresasCentrosAsync(empresasCentrosRequest);
            return Ok();
        }

        // DELETE: api/empresascentros/{id}
        /// <summary>
        /// Elimina un EMPRESASCENTROS en la BBDD mediante su ID. Tabla EMPRESASCENTROS
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="id">ID de EMPRESASCENTROS a eliminar</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteEmpresasCentros(int id)
        {
            var empresasCentrosFind = await this.repo.FindEmpresasCentrosAsync
                (id);
            if (empresasCentrosFind == null)
            {
                return NotFound();
            }
            await this.repo.DeleteEmpresasCentrosAsync(id);
            return Ok();
        }


        // PUT: api/empresascentros/UpdateEstadoEmpresaCentro/{idempresacentro}/{estado}
        /// <summary>
        /// Modifica el estado de la Empresa.  0 - PENDIENTE, 1 - ACTIVO. Tabla EMPRESASCENTROS
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID de empresa y el estado 0 - PENDIENTE, 1 - ACTIVO
        /// </remarks>
        /// <param name="idempresacentro">ID de EMPRESASCENTROS a Modificar</param>
        /// <param name="estado">Estado de la EmpresaCentro. ACTIVO - 1, PENDIENTE - 0</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        [Route("[action]/{idempresacentro}/{estado}")]
        [Authorize]
        public async Task<ActionResult> UpdateEstadoEmpresaCentro
            (int idempresacentro, int estado)
        {
            var empresasCentrosFind = await this.repo.FindEmpresasCentrosAsync
                (idempresacentro);
            if (empresasCentrosFind == null)
            {
                return NotFound();
            }
            await this.repo.UpdateEmpresasCentrosEstadoAsync(idempresacentro, estado);
            return Ok();
        }
    }
}
