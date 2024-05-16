using ApiTechRiders.Helpers;
using ApiTechRiders.Models;
using ApiTechRiders.Models.MultiDataModels;
using System.Security.Claims;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ApiTechRiders.Repositories;

namespace ApiTechRiders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class UsuariosController : ControllerBase
    {
        private RepositoryTechRiders repo;
        private HelperFilesManager filesManager;
        private HelperPathProvider pathProvider;
        public UsuariosController(RepositoryTechRiders repo, HelperFilesManager filesManager, HelperPathProvider pathProvider)
        {
            this.repo = repo;
            this.filesManager = filesManager;
            this.pathProvider = pathProvider;
        }

        // GET: api/usuarios
        /// <summary>
        /// Obtiene el conjunto de USUARIOS, tabla USUARIOS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos las USUARIOS de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Usuario>>> Get()
        {

            List<Usuario> usuarios = await this.repo.GetUsuarioAsync();
            foreach (Usuario usuario in usuarios)
            {
                if (usuario.Imagen != null)
                {
                    usuario.Imagen = this.pathProvider.MapUrlPath(Folders.Images) + usuario.Imagen;
                }
            }
            return usuarios;
        }

        // GET: api/usuarios/UsersFormato
        /// <summary>
        /// Obtiene el conjunto de USUARIOS con formato, tabla USERSFORMATOVIEW.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos las USUARIOS con datos Formateados
        /// Necesario TOKEN
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Authorize]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UserFormatoView>>> UsersFormato()
        {
            return await this.repo.GetTodosUsersFormatoViewAsync();
        }

        // GET: api/usuarios/UsersFormatoByEstado/{estado}
        /// <summary>
        /// Obtiene el conjunto de USUARIOS con formato por Estado, tabla USERSFORMATOVIEW.
        /// </summary>
        /// <remarks>
        /// Método para filtrar todos las USUARIOS con datos Formateados por Estado
        /// Necesario TOKEN
        /// </remarks>
        /// <param name="estado">Id del estado del Usuario.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Authorize]
        [Route("[action]/{estado}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UserFormatoView>>>
            UsersFormatoByEstado(int estado)
        {
            return await this.repo.GetUsersFormatoViewByEstadoAsync(estado);
        }

        // GET: api/usuarios/{id}
        /// <summary>
        /// Obtiene un USUARIOS por su Id, tabla USUARIOS.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto USUARIOS por su ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto USUARIOS.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Usuario>> Find(int id)
        {
            var user = await this.repo.FindUsuarioAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST: api/usuarios
        /// <summary>
        /// Crea una nueva USUARIOS en la BBDD, tabla USUARIOS
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo USUARIOS enviando el Objeto JSON
        /// El ID de la charla se genera automáticamente dentro del método
        /// </remarks>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Usuario>>
            InsertUsuario([FromForm] UsuarioFormData usuarioFormData)
        {
            Usuario usuarioRequest = usuarioFormData.Usuario;
            IFormFile imagen = usuarioFormData.Imagen;
            Usuario usuarioNew;

            if (imagen != null)
            {
                usuarioRequest.Imagen = this.filesManager.GetNameImage(usuarioRequest.IdUsuario);
            }
            usuarioNew = await this.repo.InsertUsuarioAsync(usuarioRequest);
            await this.filesManager.CreateImg(usuarioNew.Imagen, imagen.OpenReadStream());            
            return usuarioNew;
        }

        // PUT: api/usuarios
        /// <summary>
        /// Modifica una USUARIOS en la BBDD mediante su ID, tabla USUARIOS y manda la imagen al servidor de Imágenes o la elimina.
        /// </summary>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut("EditFormData")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateUsuario
            ([FromForm] UsuarioFormData usuarioFormData)
        {
            Usuario usuarioRequest = usuarioFormData.Usuario;
            IFormFile imagen = usuarioFormData.Imagen;
            Usuario usuarioFind = await this.repo.FindUsuarioAsync(usuarioRequest.IdUsuario);

            if (usuarioFind == null)
            {
                return NotFound();
            }
            if (imagen != null)
            {                
                string imageName = this.filesManager.GetNameImage(usuarioRequest.IdUsuario);
                usuarioRequest.Imagen = imageName;
                try
                {
                    await filesManager.UpdateImg(imageName, usuarioFormData.Imagen.OpenReadStream());
                }
                catch (FileNotFoundException ex)
                {
                    await filesManager.CreateImg(imageName, usuarioFormData.Imagen.OpenReadStream());
                }
            }
            else
            {
                if (usuarioRequest.Imagen == null )
                {
                    usuarioRequest.Imagen = usuarioFind.Imagen;
                }
            }
            Usuario usuario = await this.repo.UpdateUsuarioAsync(usuarioRequest);
            return Ok();
        }

        // PUT: api/usuarios
        /// <summary>
        /// Modifica una USUARIOS en la BBDD mediante su ID, tabla USUARIOS
        /// </summary>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateUsuario
            (Usuario usuarioRequest)
        {
            var usuarioFind = await this.repo.FindUsuarioAsync(usuarioRequest.IdUsuario);
            if (usuarioFind == null)
            {
                return NotFound();
            }
            await this.repo.UpdateUsuarioAsync(usuarioRequest);
            return Ok();
        }

        // DELETE: api/usuarios/{id}
        /// <summary>
        /// Elimina una USUARIOS en la BBDD mediante su ID. Tabla USUARIOS
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="id">ID del USUARIOS a eliminar</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteUsuario(int id)
        {
            var user = await this.repo.FindUsuarioAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            if (user.Imagen != null)
            {                    
                try
                {
                    filesManager.DeleteImg(user.Imagen);
                }
                catch (FileNotFoundException ex)
                {
                    Console.Write(ex.Message);
                }
            }            
            await this.repo.DeleteUsuarioAsync(id);
            return Ok();
        }

        // GET: api/usuarios/perfilusuario
        /// <summary>
        /// Obtiene un USUARIO a partir de su TOKEN, tabla USUARIOS.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        /// <response code="401">NotAuthorized. No autorizado, sin Token válido.</response>         
        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<Usuario> PerfilUsuario()
        {
            Claim claimUser = HttpContext.User.Claims
                .SingleOrDefault(x => x.Type == "UserData");
            string jsonUser = claimUser.Value;
            Usuario user = JsonConvert.DeserializeObject<Usuario>(jsonUser);
            int idUser = user.IdUsuario;
            Usuario userValid = await this.repo.FindUsuarioAsync(idUser);
            if (userValid.Imagen != null)
            {
                userValid.Imagen = this.pathProvider.MapUrlPath(Folders.Images) + userValid.Imagen;                
            }
            return userValid;
        }

        // PUT: api/usuarios/UpdateEstadoUsuario/{idusuario}/{estado}
        /// <summary>
        /// Modifica el estado de un usuario. Tabla USUARIOS
        /// </summary>
        /// <remarks>
        /// Debemos enviar el estado según los datos de ESTADOSVALIDACION.
        /// 0 - BAJA, 1 - ACTIVO, 2 - PENDIENTE
        /// </remarks>
        /// <param name="idusuario">ID del USUARIOS a Modificar</param>
        /// <param name="estado">Estado del Usuario. Tabla ESTADOSVALIDACION</param>
        /// <response code="201">Updated. Objeto modificado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha modificado el objeto en la BD. Error en la BBDD.</response>/// 
        /// <response code="400">BBDD. Se ha enviado un estado no válido</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Route("[action]/{idusuario}/{estado}")]
        [Authorize]
        public async Task<ActionResult> UpdateEstadoUsuario
            (int idusuario, int estado)
        {
            var user = await this.repo.FindUsuarioAsync(idusuario);
            if (user == null)
            {
                return NotFound();
            }
            if (estado == 0 || estado == 1 || estado == 2)
            {
                await this.repo.UpdateEstadoUsuarioAsync(idusuario, estado);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //ModelIdUserPassword
        // PUT: api/usuarios/UpdatePasswordUsuario
        /// <summary>
        /// Modifica la constraseña de un Usuario. Tabla USUARIOS
        /// </summary>
        /// <remarks>
        /// Debemos enviar JSON con IdUser y el nuevo Password
        /// </remarks>
        /// <response code="201">Updated. Objeto modificado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha modificado el objeto en la BD. Error en la BBDD.</response>/// 
        /// <response code="400">BBDD. Se ha enviado un estado no válido</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Route("[action]")]
        [Authorize]
        public async Task<ActionResult> UpdatePasswordUsuario
            (ModelIdUserPassword model)
        {
            var user = await this.repo.FindUsuarioAsync(model.IdUser);
            if (user == null)
            {
                return NotFound();
            }
            await this.repo.UpdatePasswordUsuarioAsync(model.IdUser
                , model.Password);
            return Ok();
        }

        // PUT: api/usuarios/UpdateVisibilidadLinkedIn/{idusuario}/{visible}
        /// <summary>
        /// Modifica la visibilidad de LinkedIn de un usuario. Tabla USUARIOS
        /// </summary>
        /// <remarks>
        /// Debemos enviar la visibilidad.
        /// 0 - NO VISIBLE, 1 - VISIBLE
        /// </remarks>
        /// <param name="idusuario">ID del USUARIOS a Modificar</param>
        /// <param name="visible">Visibilidad del LinkedIn del usuario</param>
        /// <response code="201">Updated. Objeto modificado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha modificado el objeto en la BD. Error en la BBDD.</response>/// 
        /// <response code="400">BBDD. Se ha enviado un estado no válido</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Route("[action]/{idusuario}/{visible}")]
        [Authorize]
        public async Task<ActionResult> UpdateVisibilidadLinkedIn
            (int idusuario, int visible)
        {
            var user = await this.repo.FindUsuarioAsync(idusuario);
            if (user == null)
            {
                return NotFound();
            }
            bool dato = false;
            if (visible == 1)
            {
                dato = true;
            }
            await this.repo.UpdateLinkedInVisibleAsync(idusuario, dato);
            return Ok();
        }

        // PUT: api/usuarios/UpdateResponsableEmpresaCentro/{idempresacentro}/{idresponsable}
        /// <summary>
        /// Modifica el Responsable de una Empresa. Tabla USUARIOS
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID de empresa y el Id del Responsable
        /// Si envíamos el valor de 0, se quitará (null) el responsable de una Empresa
        /// </remarks>
        /// <param name="idempresacentro">ID de EMPRESASCENTROS a Modificar</param>
        /// <param name="idresponsable">Id del Responsable de Empresa.</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        [Route("[action]/{idempresacentro}/{idresponsable}")]
        [Authorize]
        public async Task<ActionResult> UpdateResponsableEmpresaCentro
            (int idempresacentro, int idresponsable)
        {
            var empresasCentrosFind = await this.repo.FindEmpresasCentrosAsync
                (idempresacentro);
            var responsable = await
                this.repo.FindUsuarioAsync(idresponsable);
            if (empresasCentrosFind == null)
            {
                return NotFound();
            }
            else if (responsable == null)
            {
                return NotFound();
            }
            await this.repo.UpdateEmpresasCentrosResponsableAsync
                (idempresacentro, idresponsable);
            return Ok();
        }


        //UPDATE PASSWORD 
        // PUT: api/usuarios/UpdatePassword/{password}/{codigo}
        /// <summary>
        /// Modifica la password del usuario. TABLA USUARIOS
        /// </summary>
        /// <remarks>
        /// Recibimos la nueva password
        /// </remarks>
        ///   /// <param name="email">Email del usuario que quiere modifcar</param>
        /// <param name="password">Nueva password a Modificar</param>
        /// <param name="codigo">codigo rebiciod</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        [Route("[action]/{password}/{codigo}/{email}")]
        public async Task<ActionResult> UpdatePassword(string email, string password,string codigo)
        {
            Usuario usuario = await this.repo.UpdatePasswordAsync(email,codigo,password);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok();
        }

        //Get CODIGO 
        // PUT: api/usuarios/RecuperarTokenPass/{email}/
        /// <summary>
        /// Generar Codigo que le llega al usuario para modifcar su password. TABLA USUARIOS
        /// </summary>
        /// <remarks>
        /// Recibimos la nueva password
        /// </remarks>
        /// <param name="email">Email del user que quiere modificar</param>
        [HttpGet]
        [Route("[action]/{email}")]
        public async Task<ActionResult<string>> RecuperarTokenPass(string email)
        {
            string codigo = await this.repo.RecuperarUsuarioAsync(email);
            if (codigo == null)
            {
                return NotFound();
            }
            return Ok(codigo);
        }
    }
}
