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
    public class CursosController : ControllerBase
    {
        private RepositoryTechRiders repo;
        public CursosController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/cursos
        /// <summary>
        /// Obtiene el conjunto de CURSOS, tabla CURSOS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los Cursos de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Curso>>> Get()
        {
            return await this.repo.GetCursosAsync();
        }

        // GET: api/cursos/{id}
        /// <summary>
        /// Obtiene un Curso por su Id, tabla CURSOS.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto Curso por su ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto CURSO.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> Find(int id)
        {
            var curso = await this.repo.FindCursoAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            return curso;
        }

        // POST: api/cursos
        /// <summary>
        /// Crea un nuev Curso en la BBDD, tabla CURSOS
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo CURSO enviando el Objeto JSON
        /// El ID del Curso se genera automáticamente dentro del método
        /// </remarks>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Curso>>
            InsertCurso(Curso curso)
        {
            Curso cursoNew =
                await this.repo.InsertCursoAsync
                (curso);
            return cursoNew;
        }

        // PUT: api/cursos
        /// <summary>
        /// Modifica un Curso en la BBDD mediante su ID, tabla CURSOS
        /// </summary>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateCurso
            (Curso curso)
        {
            var cursoFind = await this.repo.FindCursoAsync(curso.IdCurso);
            if (cursoFind == null)
            {
                return NotFound();
            }
            await this.repo.UpdateCursoAsync(curso);
            return Ok();
        }

        // DELETE: api/cursos/{id}
        /// <summary>
        /// Elimina un Curso en la BBDD mediante su ID. Tabla CURSOS
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="id">ID deL CURSO a eliminar</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteCurso(int id)
        {
            var curso = await this.repo.FindCursoAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            await this.repo.DeleteCursoAsync(id);
            return Ok();
        }
    }
}
