using ApiTechRiders.Models;
using ApiTechRiders.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTechRiders.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class PeticionesCategoriasController : ControllerBase
    {
        //private RepositoryTechRiders repo;
        //public PeticionesCategoriasController(RepositoryTechRiders repo)
        //{
        //    this.repo = repo;
        //}

        //// GET: api/peticionescategorias
        ///// <summary>
        ///// Obtiene el conjunto de PETICIONESCATEGORIAS, tabla PETICIONESCATEGORIAS.
        ///// </summary>
        ///// <remarks>
        ///// Método para devolver todos los PETICIONESCATEGORIAS de la BBDD
        ///// </remarks>
        ///// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<List<PeticionCategorias>>> Get()
        //{
        //    return await this.repo.GetPeticionCategoriasAsync();
        //}

        //// GET: api/peticionescategorias/{id}
        ///// <summary>
        ///// Obtiene un PETICIONESCATEGORIAS por su Id, tabla PETICIONESCATEGORIAS.
        ///// </summary>
        ///// <remarks>
        ///// Permite buscar un objeto PETICIONESCATEGORIAS por su ID
        ///// </remarks>
        ///// <param name="id">Id (GUID) del objeto PETICIONESCATEGORIAS.</param>
        ///// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        ///// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[HttpGet("{id}")]
        //public async Task<ActionResult<PeticionCategorias>> Find(int id)
        //{
        //    var peticion = await this.repo.FindPeticionCategoriasAsync(id);
        //    if (peticion == null)
        //    {
        //        return NotFound();
        //    }
        //    return peticion;
        //}

        //// POST: api/peticionescategorias
        ///// <summary>
        ///// Crea un nuevo PETICIONESCATEGORIAS en la BBDD, tabla PETICIONESCATEGORIAS
        ///// </summary>
        ///// <remarks>
        ///// Este método inserta un nuevo PETICIONESCATEGORIAS enviando la Categoria
        ///// El ID se genera automáticamente dentro del método
        ///// </remarks>
        ///// <param name="categoria">Nombre de la categoria de la petición de Alta</param>/// 
        ///// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        ///// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<PeticionCategorias>>
        //        InsertPeticionCategorias(string categoria)
        //{
        //    PeticionCategorias peticionNew =
        //            await this.repo.InsertPeticionCategoriasAsync(categoria);
        //    return peticionNew;
        //}

        //// PUT: api/peticiones
        ///// <summary>
        ///// Modifica un PETICIONES en la BBDD mediante su ID, tabla PETICIONES
        ///// </summary>
        ///// <param name="idpeticion">Nombre de la categoria de la petición de Alta</param>/// 
        ///// <param name="categoria">Nombre de la categoria de la petición de Alta</param>/// 
        ///// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        ///// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        ///// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult> UpdatePeticionCategorias
        //        (int idpeticion, string categoria)
        //{
        //    var peticionFind = await this.repo.FindPeticionCategoriasAsync
        //        (idpeticion);
        //    if (peticionFind == null)
        //    {
        //        return NotFound();
        //    }
        //    await this.repo.UpdatePeticionCategoriasAsync(idpeticion, categoria);
        //    return Ok();
        //}

        //// DELETE: api/peticionescategorias/{id}
        ///// <summary>
        ///// Elimina un PETICIONESCATEGORIAS en la BBDD mediante su ID. Tabla PETICIONESCATEGORIAS
        ///// </summary>
        ///// <remarks>
        ///// Enviaremos el ID mediante la URL
        ///// </remarks>
        ///// <param name="idpeticion">ID de PETICIONES a eliminar de PETICIONESCATEGORIAS</param>
        ///// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        ///// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        ///// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeletePeticionCategorias
        //    (int idpeticion)
        //{
        //    var peticionFind = await this.repo.FindPeticionCategoriasAsync
        //        (idpeticion);
        //    if (peticionFind == null)
        //    {
        //        return NotFound();
        //    }
        //    await this.repo.DeletePeticionCategoriasAsync(idpeticion);
        //    return Ok();
        //}
    }
}
