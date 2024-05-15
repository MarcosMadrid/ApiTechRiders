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
    public class CursosProfesoresController : ControllerBase
    {
        private RepositoryTechRiders repo;
        public CursosProfesoresController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/cursosprofesores
        /// <summary>
        /// Obtiene el conjunto de CURSOS PROFESORES, tabla CURSOSPROFESORES.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los Cursos Profesores de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CursosProfesores>>> Get()
        {
            return await this.repo.GetCursosProfesoresAsync();
        }

        // GET: api/cursos/{id}
        /// <summary>
        /// Obtiene un Curso por su Id, tabla CURSOS.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto Curso por su ID
        /// </remarks>
        /// <param name="idcurso">Id del Curso</param>
        /// <param name="idprofesor">Id del Profesor</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Route("[action]/{idcurso}/{idprofesor}")]
        public async Task<ActionResult<CursosProfesores>> Find(int idcurso, int idprofesor)
        {
            var cursoprofesores = await this.repo.FindCursosProfesoresAsync(idcurso, idprofesor);
            if (cursoprofesores == null)
            {
                return NotFound();
            }
            return cursoprofesores;
        }

        // POST: api/cursosprofesores
        /// <summary>
        /// Crea un nuevo Cursos Profesores en la BBDD, tabla CURSOSPROFESORES
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo CURSO PROFESORES enviando el Objeto JSON
        /// </remarks>
        /// <param name="idcurso">Id del Curso</param>
        /// <param name="idprofesor">Id del Profesor</param>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CursosProfesores>>
            InsertCursoProfesores(int idcurso, int idprofesor)
        {
            CursosProfesores cursoNew =
                await this.repo.InsertCursosProfesoresAsync(idcurso, idprofesor);
            return cursoNew;
        }

        // DELETE: api/cursosprofesores/{idcurso}/{idprofesor}
        /// <summary>
        /// Elimina un Curso en la BBDD mediante su ID. Tabla CURSOS
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="idcurso">Id del Curso</param>
        /// <param name="idprofesor">Id del Profesor</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> DeleteCursoProfesores
            (int idcurso, int idprofesor)
        {
            var cursoprofesores = 
                await this.repo.FindCursosProfesoresAsync(idcurso, idprofesor);
            if (cursoprofesores == null)
            {
                return NotFound();
            }
            await this.repo.DeleteCursosProfesoresAsync(idcurso, idprofesor);
            return Ok();
        }
    }
}
