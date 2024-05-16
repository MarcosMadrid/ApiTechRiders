//PONER EN LA DOCUMENTACION QUE CERO QUITARA AL TECHRIDER DE LA CHARLA (PROBAR...)
//updateobservacionescharla//{idcharla}/{observaciones} (READY)
//updateestadocharla//{idcharla}/{idestadocharla} (READY)
//updatefechacharla//{idcharla}/{fechacharla} (READY)

//USUARIOS (READY)
//	DAR DE ALTA USUARIO (CAMBIAR ESTADO) 
//	DAR DE BAJA USUARIO (CAMBIAR ESTADO)

//METODO CON TODOS LOS DATOS DE UNA CHARLA

//BUSCAR CHARLAS DE UN TECHRIDER/PROFESOR

//CURSOS POR PROFESOR (VARIOS)

//PEDIR TECNOLOGIAS INCLUIR DENTRO DEL SCRIPT EL VALOR
//eliminar PETICIONES
//CAMBIAR TABLA PETICIONES_CATEGORIAS POR OTRO NOMBRE MAS INTUITIVO
//INCLUIR IDCATEGORIAPETICION EN LAS TABLAS DE PETICION
//REALIZAR LAS FOREIGN KEY

//cambiar IDPETICION POR IDPETICION CATEGORIAS TABLA PETICIONES_CATEGORIAS
//CAMBIAR provincia STRING por IDPROVINCIA ALTER TABLE en CHARLAS
//cambiar IDPETICION POR IdPeticionAltaUsers EN PETCIONALTAUSERS
//cambiar IDPETICION POR IdPeticionCentrosEmpresa EN PETCIONCENTROSEMPRESA
//cambiar IDPETICION POR IdPeticionCharla EN PETICIONCHARLA
//INCLUIR IDCHARLA DENTRO DE VALORACIONES CHARLAS
//CAMBIAR LOS NULL EN BBDD Y EN PROGRAM, SEGUIMIENTO...

using ApiTechRiders.Data;
using ApiTechRiders.Helpers;
using ApiTechRiders.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTechRiders.Repositories
{
    public class RepositoryTechRiders
    {
        private TechRidersContext context;
        private HelperTokenPass helper;

        public RepositoryTechRiders(TechRidersContext context,HelperTokenPass helper)
        {
            this.context = context;
            this.helper = helper;
        }

        #region CHARLAS

        public async Task<List<Charla>> GetCharlasAsync()
        {
            return await this.context.Charlas.ToListAsync();
        }

        public async Task<Charla>
            FindCharlaAsync(int id)
        {
            return await
                this.context.Charlas
                .FirstOrDefaultAsync(x => x.IdCharla == id);
        }

        public async Task<List<Charla>>
            GetCharlaStateAsync(int idState)
        {
            return await
                this.context.Charlas
                .Where(x => x.IdEstadoCharla == idState).ToListAsync();
        }

        private async Task<int> GetMaxIdCharla()
        {
            if (this.context.Charlas.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.Charlas.MaxAsync(z => z.IdCharla) + 1;
            }
        }

        public async Task<Charla> InsertCharlaAsync
            (Charla requestCharla)
        {
            Charla newCharla = new Charla();
            newCharla.IdCharla = await this.GetMaxIdCharla();
            newCharla.IdCurso = requestCharla.IdCurso;
            newCharla.IdEstadoCharla = requestCharla.IdEstadoCharla;
            newCharla.IdProvincia = requestCharla.IdProvincia;
            newCharla.IdTechRider = requestCharla.IdTechRider;
            newCharla.Modalidad = requestCharla.Modalidad;
            newCharla.Observaciones = requestCharla.Observaciones;
            newCharla.Turno = requestCharla.Turno;
            //newCharla.Valoracion = requestCharla.Valoracion;
            newCharla.FechaCharla = requestCharla.FechaCharla;
            newCharla.FechaSolicitud = requestCharla.FechaSolicitud;
            newCharla.Descripcion = requestCharla.Descripcion;
            //newCharla.Comentarios = requestCharla.Comentarios;
            newCharla.AcreditacionLinkedIn = requestCharla.AcreditacionLinkedIn;
            this.context.Charlas.Add(newCharla);
            await this.context.SaveChangesAsync();
            return newCharla;
        }

        public async Task UpdateCharlaAsync
           (Charla requestCharla)
        {
            Charla newCharla = await this.FindCharlaAsync(requestCharla.IdCharla);
            newCharla.IdCurso = requestCharla.IdCurso;
            newCharla.IdEstadoCharla = requestCharla.IdEstadoCharla;
            newCharla.IdProvincia = requestCharla.IdProvincia;
            newCharla.IdTechRider = requestCharla.IdTechRider;
            newCharla.Modalidad = requestCharla.Modalidad;
            newCharla.Observaciones = requestCharla.Observaciones;
            newCharla.Turno = requestCharla.Turno;
            //newCharla.Valoracion = requestCharla.Valoracion;
            newCharla.FechaCharla = requestCharla.FechaCharla;
            newCharla.FechaSolicitud = requestCharla.FechaSolicitud;
            newCharla.Descripcion = requestCharla.Descripcion;
            //newCharla.Comentarios = requestCharla.Comentarios;
            newCharla.AcreditacionLinkedIn = requestCharla.AcreditacionLinkedIn;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteCharlaAsync(int idCharla)
        {
            Charla charla = await this.FindCharlaAsync(idCharla);
            this.context.Charlas.Remove(charla);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateCharlaTechRiderAsync
           (int idTechrider, int idCharla)
        {
            Charla newCharla =
                await this.FindCharlaAsync(idCharla);
            if (idTechrider == 0)
            {
                newCharla.IdTechRider = null;
                newCharla.IdEstadoCharla = 2;
            }
            else
            {
                newCharla.IdTechRider = idTechrider;
                newCharla.IdEstadoCharla = 3;
            }

            await this.context.SaveChangesAsync();
        }

        public async Task UpdateObservacionesCharlaAsync
            (int idCharla, string observaciones)
        {
            Charla newCharla =
                await this.FindCharlaAsync(idCharla);
            newCharla.Observaciones = observaciones;
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateEstadoCharlaAsync
            (int idCharla, int idestadocharla)
        {
            Charla newCharla =
                await this.FindCharlaAsync(idCharla);
            newCharla.IdEstadoCharla = idestadocharla;
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateFechaCharlaAsync
            (int idCharla, DateTime fechacharla)
        {
            Charla newCharla =
                await this.FindCharlaAsync(idCharla);
            newCharla.FechaCharla = fechacharla;
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region CURSOS

        public async Task<List<Curso>> GetCursosAsync()
        {
            return await this.context.Cursos.ToListAsync();
        }

        public async Task<Curso>
            FindCursoAsync(int id)
        {
            return await
                this.context.Cursos
                .FirstOrDefaultAsync(x => x.IdCurso == id);
        }

        private async Task<int> GetMaxIdCurso()
        {
            if (this.context.Cursos.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.Cursos.MaxAsync(z => z.IdCurso) + 1;
            }
        }

        public async Task<Curso> InsertCursoAsync
            (Curso requestCurso)
        {
            Curso newCurso = new Curso();
            newCurso.IdCurso = await this.GetMaxIdCurso();
            newCurso.Descripcion = requestCurso.Descripcion;
            newCurso.IdCentro = requestCurso.IdCentro;
            newCurso.NombreCurso = requestCurso.NombreCurso;
            this.context.Cursos.Add(newCurso);
            await this.context.SaveChangesAsync();
            return newCurso;
        }

        public async Task UpdateCursoAsync
           (Curso requestCurso)
        {
            Curso newCurso = await this.FindCursoAsync(requestCurso.IdCurso);
            newCurso.Descripcion = requestCurso.Descripcion;
            newCurso.IdCentro = requestCurso.IdCentro;
            newCurso.NombreCurso = requestCurso.NombreCurso;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteCursoAsync(int idCurso)
        {
            Curso curso = await this.FindCursoAsync(idCurso);
            this.context.Cursos.Remove(curso);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region CURSOS PROFESORES

        public async Task<List<CursosProfesores>> GetCursosProfesoresAsync()
        {
            return await this.context.CursosProfesores.ToListAsync();
        }

        public async Task<CursosProfesores>
            FindCursosProfesoresAsync(int idcurso, int idprofesor)
        {
            return await
                this.context.CursosProfesores
                .FirstOrDefaultAsync(x => x.IdCurso == idcurso &&
                x.IdProfesor == idprofesor);
        }

        //private async Task<int> GetMaxIdCursosProfesores()
        //{
        //    if (this.context.CursosProfesores.Count() == 0)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return await
        //            this.context.CursosProfesores.MaxAsync(z => z.IdCurso) + 1;
        //    }
        //}

        public async Task<CursosProfesores> InsertCursosProfesoresAsync
            (int idcurso, int idprofesor)
        {
            CursosProfesores newCurso = new CursosProfesores();
            newCurso.IdCurso = idcurso;
            newCurso.IdProfesor = idprofesor;
            this.context.CursosProfesores.Add(newCurso);
            await this.context.SaveChangesAsync();
            return newCurso;
        }

        public async Task UpdateProfesorCursosProfesoresAsync
            (int idcurso, int idprofesor, int newIdProfesor)
        {
            CursosProfesores newCurso =
                await this.FindCursosProfesoresAsync
                (idcurso, idprofesor);
            newCurso.IdProfesor = newIdProfesor;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteCursosProfesoresAsync(int idCurso
            , int idProfesor)
        {
            CursosProfesores curso =
                await this.FindCursosProfesoresAsync
                    (idCurso, idProfesor);
            this.context.CursosProfesores.Remove(curso);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region EMPRESASCENTROS

        public async Task<List<EmpresasCentros>> GetEmpresasCentrosAsync()
        {
            return await this.context.EmpresasCentros.ToListAsync();
        }

        public async Task<EmpresasCentros>
            FindEmpresasCentrosAsync(int idempresacentro)
        {
            return await
                this.context.EmpresasCentros
                .FirstOrDefaultAsync(x => x.IdEmpresaCentro == idempresacentro);
        }

        public async Task<List<EmpresasCentros>>
                GetEmpresasCentrosByStateAsync(int estado)
        {
            return await
                this.context.EmpresasCentros
                .Where(x => x.EstadoEmpresa == estado).ToListAsync();
        }

        private async Task<int> GetMaxIdEmpresasCentros()
        {
            if (this.context.EmpresasCentros.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.EmpresasCentros.MaxAsync(z => z.IdEmpresaCentro) + 1;
            }
        }

        public async Task<EmpresasCentros> InsertEmpresasCentrosAsync
            (EmpresasCentros requestEmpresasCentros)
        {
            EmpresasCentros newEmpresasCentros = new EmpresasCentros();
            newEmpresasCentros.IdEmpresaCentro = await this.GetMaxIdEmpresasCentros();
            newEmpresasCentros.Cif = requestEmpresasCentros.Cif;
            newEmpresasCentros.Direccion = requestEmpresasCentros.Direccion;
            newEmpresasCentros.IdProvincia = requestEmpresasCentros.IdProvincia;
            newEmpresasCentros.IdTipoEmpresa = requestEmpresasCentros.IdTipoEmpresa;
            newEmpresasCentros.Nombre = requestEmpresasCentros.Nombre;
            newEmpresasCentros.PersonaContacto = requestEmpresasCentros.PersonaContacto;
            newEmpresasCentros.RazonSocial = requestEmpresasCentros.RazonSocial;
            newEmpresasCentros.Telefono = requestEmpresasCentros.Telefono;
            newEmpresasCentros.EstadoEmpresa = requestEmpresasCentros.EstadoEmpresa;
            this.context.EmpresasCentros.Add(newEmpresasCentros);
            await this.context.SaveChangesAsync();
            return newEmpresasCentros;
        }

        public async Task UpdateEmpresasCentrosAsync
           (EmpresasCentros requestEmpresasCentros)
        {
            EmpresasCentros newEmpresasCentros =
                await this.FindEmpresasCentrosAsync(requestEmpresasCentros.IdEmpresaCentro);
            newEmpresasCentros.Cif = requestEmpresasCentros.Cif;
            newEmpresasCentros.Direccion = requestEmpresasCentros.Direccion;
            newEmpresasCentros.IdProvincia = requestEmpresasCentros.IdProvincia;
            newEmpresasCentros.IdTipoEmpresa = requestEmpresasCentros.IdTipoEmpresa;
            newEmpresasCentros.Nombre = requestEmpresasCentros.Nombre;
            newEmpresasCentros.PersonaContacto = requestEmpresasCentros.PersonaContacto;
            newEmpresasCentros.RazonSocial = requestEmpresasCentros.RazonSocial;
            newEmpresasCentros.Telefono = requestEmpresasCentros.Telefono;
            newEmpresasCentros.EstadoEmpresa = requestEmpresasCentros.EstadoEmpresa;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteEmpresasCentrosAsync(int idEmpresaCentro)
        {
            EmpresasCentros newEmpresasCentros =
                await this.FindEmpresasCentrosAsync(idEmpresaCentro);
            this.context.EmpresasCentros.Remove(newEmpresasCentros);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateEmpresasCentrosEstadoAsync
            (int idEmpresaCentro, int estado)
        {
            EmpresasCentros newEmpresasCentros =
                await this.FindEmpresasCentrosAsync(idEmpresaCentro);
            newEmpresasCentros.EstadoEmpresa = estado;
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateEmpresasCentrosResponsableAsync
    (int idEmpresaCentro, int idResponsable)
        {
            Usuario usuario =
                this.context.Usuarios.FirstOrDefault(x => x.IdUsuario
                == idResponsable);
            if (idEmpresaCentro == 0)
            {
                usuario.IdEmpresaCentro = null;
            }
            else
            {
                usuario.IdEmpresaCentro = idEmpresaCentro;
            }
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region ESTADOSCHARLAS

        public async Task<List<EstadosCharla>> GetEstadosCharlaAsync()
        {
            return await this.context.EstadosCharlas.ToListAsync();
        }

        public async Task<EstadosCharla>
            FindEstadosCharlaAsync(int id)
        {
            return await
                this.context.EstadosCharlas
                .FirstOrDefaultAsync(x => x.IdEstadosCharla == id);
        }

        private async Task<int> GetMaxEstadosCharla()
        {
            if (this.context.EstadosCharlas.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.EstadosCharlas.MaxAsync(z => z.IdEstadosCharla) + 1;
            }
        }

        public async Task<EstadosCharla> InsertEstadosCharlaAsync
            (EstadosCharla requestEstadosCharla)
        {
            EstadosCharla newCurso = new EstadosCharla();
            newCurso.IdEstadosCharla = await this.GetMaxEstadosCharla();
            newCurso.Tipo = requestEstadosCharla.Tipo;
            this.context.EstadosCharlas.Add(newCurso);
            await this.context.SaveChangesAsync();
            return newCurso;
        }

        public async Task UpdateEstadosCharlaAsync
           (EstadosCharla requestEstadosCharla)
        {
            EstadosCharla newCurso = await
                this.FindEstadosCharlaAsync(requestEstadosCharla.IdEstadosCharla);
            newCurso.Tipo = requestEstadosCharla.Tipo;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteEstadosCharlaAsync(int idEstadosCharla)
        {
            EstadosCharla estadoCharla = await
                this.FindEstadosCharlaAsync(idEstadosCharla);
            this.context.EstadosCharlas.Remove(estadoCharla);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region ESTADOSVALIDACION

        public async Task<List<EstadosValidacion>> GetEstadosValidacionAsync()
        {
            return await this.context.EstadosValidacion.ToListAsync();
        }

        public async Task<EstadosValidacion>
            FindEstadosValidacionAsync(int id)
        {
            return await
                this.context.EstadosValidacion
                .FirstOrDefaultAsync(x => x.IdEstadoValidacion == id);
        }

        private async Task<int> GetMaxEstadosValidacion()
        {
            if (this.context.EstadosValidacion.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.EstadosValidacion.MaxAsync(z => z.IdEstadoValidacion) + 1;
            }
        }

        public async Task<EstadosValidacion> InsertEstadosValidacionAsync
            (EstadosValidacion requestEstadosValidacion)
        {
            EstadosValidacion newCurso = new EstadosValidacion();
            newCurso.IdEstadoValidacion = await this.GetMaxEstadosValidacion();
            newCurso.NombreEstado = requestEstadosValidacion.NombreEstado;
            this.context.EstadosValidacion.Add(newCurso);
            await this.context.SaveChangesAsync();
            return newCurso;
        }

        public async Task UpdateEstadosValidacionAsync
           (EstadosValidacion requestEstadosValidacion)
        {
            EstadosValidacion newCurso = await
                this.FindEstadosValidacionAsync(requestEstadosValidacion.IdEstadoValidacion);
            newCurso.NombreEstado = requestEstadosValidacion.NombreEstado;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteEstadosValidacionAsync(int idEstadosValidacion)
        {
            EstadosValidacion estadoCharla = await
                this.FindEstadosValidacionAsync(idEstadosValidacion);
            this.context.EstadosValidacion.Remove(estadoCharla);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region PETICIONES

        //public async Task<List<Peticion>> GetPeticionesAsync()
        //{
        //    return await this.context.Peticiones.ToListAsync();
        //}

        //public async Task<Peticion>
        //    FindPeticionAsync(int id)
        //{
        //    return await
        //        this.context.Peticiones
        //        .FirstOrDefaultAsync(x => x.IdPeticion == id);
        //}

        //private async Task<int> GetMaxPeticion()
        //{
        //    if (this.context.Peticiones.Count() == 0)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return await
        //            this.context.Peticiones.MaxAsync(z => z.IdPeticion) + 1;
        //    }
        //}

        //public async Task<Peticion> InsertPeticionAsync
        //    (Peticion requestPeticion)
        //{
        //    Peticion newPeticion = new Peticion();
        //    newPeticion.IdPeticion = await this.GetMaxPeticion();
        //    newPeticion.IdGeneral = requestPeticion.IdGeneral;
        //    newPeticion.FechaPeticion = requestPeticion.FechaPeticion;
        //    newPeticion.Descripcion = requestPeticion.Descripcion;
        //    newPeticion.TipoPeticion = requestPeticion.TipoPeticion;
        //    this.context.Peticiones.Add(newPeticion);
        //    await this.context.SaveChangesAsync();
        //    return newPeticion;
        //}

        //public async Task UpdatePeticionAsync
        //    (Peticion requestPeticion)
        //{
        //    Peticion newPeticion = await this.FindPeticionAsync(requestPeticion.IdPeticion);
        //    newPeticion.IdGeneral = requestPeticion.IdGeneral;
        //    newPeticion.FechaPeticion = requestPeticion.FechaPeticion;
        //    newPeticion.Descripcion = requestPeticion.Descripcion;
        //    newPeticion.TipoPeticion = requestPeticion.TipoPeticion;
        //    await this.context.SaveChangesAsync();
        //}

        //public async Task DeletePeticionAsync(int idPeticion)
        //{
        //    Peticion peticion = await
        //        this.FindPeticionAsync(idPeticion);
        //    this.context.Peticiones.Remove(peticion);
        //    await this.context.SaveChangesAsync();
        //}

        #endregion

        #region PETICIONES ALTA USERS

        public async Task<List<PeticionAltaUsers>>
            GetPeticionesAltaUsersAsync()
        {
            return await this.context.PeticionesAltaUsers.ToListAsync();
        }

        private async Task<int> GetMaxPeticionAltaUsers()
        {
            if (this.context.PeticionesAltaUsers.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.PeticionesAltaUsers.MaxAsync(z =>
                    z.IdPeticionAltaUsers) + 1;
            }
        }

        public async Task<PeticionAltaUsers>
            FindPeticionesAltaUsersAsync(int idpeticion)
        {
            return await
                this.context.PeticionesAltaUsers
                .FirstOrDefaultAsync(x => x.IdPeticionAltaUsers == idpeticion);
        }

        public async Task<List<PeticionAltaUsers>>
            FindPeticionesAltaUsuarioAsync(int iduser)
        {
            return await
                this.context.PeticionesAltaUsers
                .Where(x => x.IdUser == iduser).ToListAsync();
        }


        public async Task<PeticionAltaUsers> InsertPeticionAltaUsersAsync
            (int iduser)
        {
            PeticionAltaUsers newPeticion = new PeticionAltaUsers();
            newPeticion.IdPeticionAltaUsers =
                await this.GetMaxPeticionAltaUsers();
            newPeticion.IdUser = iduser;
            //TIPOSPETICIONESCATEGORIAS
            newPeticion.IdTipoPeticionCategoria = 1; //ALTAUSER
            this.context.PeticionesAltaUsers.Add(newPeticion);
            await this.context.SaveChangesAsync();
            return newPeticion;
        }

        public async Task DeletePeticionAltaUsersAsync
             (int idpeticion)
        {
            PeticionAltaUsers peticionuser = await
                this.FindPeticionesAltaUsersAsync(idpeticion);
            this.context.PeticionesAltaUsers.Remove(peticionuser);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region PETICIONES CATEGORIAS

        //public async Task<List<PeticionCategorias>> GetPeticionCategoriasAsync()
        //{
        //    return await this.context.PeticionesCategorias.ToListAsync();
        //}

        //public async Task<PeticionCategorias>
        //    FindPeticionCategoriasAsync(int id)
        //{
        //    return await
        //        this.context.PeticionesCategorias
        //        .FirstOrDefaultAsync(x => x.IdPeticionCategorias == id);
        //}

        //private async Task<int> GetMaxPeticionCategorias()
        //{
        //    if (this.context.PeticionesCategorias.Count() == 0)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return await
        //            this.context.PeticionesCategorias.MaxAsync
        //            (z => z.IdPeticionCategorias) + 1;
        //    }
        //}

        //public async Task<PeticionCategorias> InsertPeticionCategoriasAsync
        //    (string categoria)
        //{
        //    PeticionCategorias newPeticionCategorias = new PeticionCategorias();
        //    newPeticionCategorias.IdPeticionCategorias = await this.GetMaxPeticionCategorias();
        //    newPeticionCategorias.Categoria = categoria;
        //    this.context.PeticionesCategorias.Add(newPeticionCategorias);
        //    await this.context.SaveChangesAsync();
        //    return newPeticionCategorias;
        //}

        //public async Task UpdatePeticionCategoriasAsync
        //   (int idpeticion, string categoria)
        //{
        //    PeticionCategorias newPeticionCategorias = await
        //        this.FindPeticionCategoriasAsync
        //        (idpeticion);
        //    newPeticionCategorias.Categoria = categoria;
        //    await this.context.SaveChangesAsync();
        //}

        //public async Task DeletePeticionCategoriasAsync(int idnewPeticionCategorias)
        //{
        //    PeticionCategorias peticionCategorias = await
        //        this.FindPeticionCategoriasAsync(idnewPeticionCategorias);
        //    this.context.PeticionesCategorias.Remove(peticionCategorias);
        //    await this.context.SaveChangesAsync();
        //}

        #endregion

        #region PETICIONES CENTRO EMPRESA

        public async Task<List<PeticionCentroEmpresa>> GetPeticionCentroEmpresaAsync()
        {
            return await this.context.PeticionesCentroEmpresa.ToListAsync();
        }

        public async Task<PeticionCentroEmpresa>
            FindPeticionCentroEmpresaAsync(int id)
        {
            return await
                this.context.PeticionesCentroEmpresa
                .FirstOrDefaultAsync(x => x.IdPeticionCentroEmpresa == id);
        }

        private async Task<int> GetMaxPeticionCentroEmpresa()
        {
            if (this.context.PeticionesCentroEmpresa.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.PeticionesCentroEmpresa.MaxAsync
                    (z => z.IdPeticionCentroEmpresa) + 1;
            }
        }

        public async Task<PeticionCentroEmpresa> InsertPeticionCentroEmpresaAsync
            (int idcentroempresa)
        {
            PeticionCentroEmpresa newPeticionCentroEmpresa =
                new PeticionCentroEmpresa();
            newPeticionCentroEmpresa.IdPeticionCentroEmpresa =
                await this.GetMaxPeticionCentroEmpresa();
            newPeticionCentroEmpresa.IdCentroEmpresa = idcentroempresa;
            newPeticionCentroEmpresa.IdTipoPeticionCategoria = 3; //CENTRO-EMPRESA
            this.context.PeticionesCentroEmpresa.Add(newPeticionCentroEmpresa);
            await this.context.SaveChangesAsync();
            return newPeticionCentroEmpresa;
        }

        public async Task UpdatePeticionCentroEmpresaAsync
           (int idpeticion, int idcentroempresa)
        {
            PeticionCentroEmpresa newPeticionCentroEmpresa = await
                this.FindPeticionCentroEmpresaAsync
                (idpeticion);
            newPeticionCentroEmpresa.IdCentroEmpresa = idcentroempresa;
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePeticionCentroEmpresaAsync(int idPeticionCentroEmpresa)
        {
            PeticionCentroEmpresa peticionCentroEmpresa = await
                this.FindPeticionCentroEmpresaAsync(idPeticionCentroEmpresa);
            this.context.PeticionesCentroEmpresa.Remove(peticionCentroEmpresa);
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePeticionCentroEmpresaAllAsync
            (int idPeticionCentroEmpresa)
        {
            PeticionCentroEmpresa peticionCentroEmpresa = await
                this.FindPeticionCentroEmpresaAsync(idPeticionCentroEmpresa);
            /*
             AL ELIMINAR UNA PETICION DEL CENTRO DE EMPRESA, 
                QUITAR AL RESPONSABLE (IDCENTROEMPRESA=null)
                Y ELIMINAR LA EMPRESA SOLICITANTE
             */
            int idEmpresaEliminar =
                peticionCentroEmpresa.IdCentroEmpresa;
            //BUSCAMOS AL USUARIO RESPONSABLE DE LA EMPRESA
            var consulta = this.context.Usuarios
                .Where(x => x.IdEmpresaCentro == idEmpresaEliminar);
            List<Usuario> listaResponsables =
                await consulta.ToListAsync();
            //QUITAMOS A LOS RESPONSABLES DE EMPRESA
            foreach (Usuario user in listaResponsables)
            {
                user.IdEmpresaCentro = null;
            }
            //GUARDAMOS CAMBIOS PARA LIBERAR LOS DATOS
            await this.context.SaveChangesAsync();
            //ELIMINAMOS LA PETICION
            this.context.PeticionesCentroEmpresa.Remove(peticionCentroEmpresa);
            //ELIMINAMOS LA EMPRESA
            await this.context.SaveChangesAsync();
            EmpresasCentros empresaEliminar =
                await this.FindEmpresasCentrosAsync(idEmpresaEliminar);
            this.context.EmpresasCentros.Remove(empresaEliminar);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region PETICIONES CHARLA

        public async Task<List<PeticionCharla>> GetPeticionCharlaAsync()
        {
            return await this.context.PeticionesCharlas.ToListAsync();
        }

        public async Task<PeticionCharla>
            FindPeticionCharlaAsync(int id)
        {
            return await
                this.context.PeticionesCharlas
                .FirstOrDefaultAsync(x => x.IdPeticionCharla == id);
        }

        private async Task<int> GetMaxPeticionCharla()
        {
            if (this.context.PeticionesCharlas.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.PeticionesCharlas.MaxAsync
                    (z => z.IdPeticionCharla) + 1;
            }
        }

        public async Task<PeticionCharla> InsertPeticionCharlaAsync
            (int idcharla)
        {
            PeticionCharla newPeticionCharla = new PeticionCharla();
            newPeticionCharla.IdPeticionCharla =
                await this.GetMaxPeticionCharla();
            newPeticionCharla.IdCharla = idcharla;
            //PONEMOS LA CATEGORIA DE LA PETICION DE LA CHARLA
            //TABLA TIPOSPETICIONESCATEGORIAS
            newPeticionCharla.IdTipoPeticionCategoria = 2; //CHARLA
            this.context.PeticionesCharlas.Add(newPeticionCharla);
            await this.context.SaveChangesAsync();
            return newPeticionCharla;
        }

        public async Task UpdatePeticionCharlaAsync
           (int idpeticioncharla, int idcharla)
        {
            PeticionCharla newPeticionCharla = await
                this.FindPeticionCharlaAsync
                (idpeticioncharla);
            newPeticionCharla.IdCharla = idcharla;
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePeticionCharlaAsync(int idPeticionCharla)
        {
            PeticionCharla peticionCharla = await
                this.FindPeticionCharlaAsync(idPeticionCharla);
            this.context.PeticionesCharlas.Remove(peticionCharla);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region PETICIONES TECNOLOGIAS

        public async Task<List<PeticionTecnologia>> GetPeticionTecnologiasAsync()
        {
            return await this.context.PeticionesTecnologias.ToListAsync();
        }

        public async Task<PeticionTecnologia>
            FindPeticionTecnologiasAsync(int id)
        {
            return await
                this.context.PeticionesTecnologias
                .FirstOrDefaultAsync(x => x.IdPeticionTecnologia == id);
        }

        private async Task<int> GetMaxIdPeticionTecnologia()
        {
            if (this.context.PeticionesTecnologias.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.PeticionesTecnologias.MaxAsync
                    (z => z.IdPeticionTecnologia) + 1;
            }
        }

        public async Task<PeticionTecnologia> InsertPeticionTecnologiaAsync
            (string tecnologia)
        {
            PeticionTecnologia newPeticionTecnologia = new PeticionTecnologia();
            newPeticionTecnologia.IdPeticionTecnologia =
                await this.GetMaxIdPeticionTecnologia();
            newPeticionTecnologia.NombreTecnologia = tecnologia;
            newPeticionTecnologia.IdTipoPeticionCategoria = 4;
            this.context.PeticionesTecnologias.Add(newPeticionTecnologia);
            await this.context.SaveChangesAsync();
            return newPeticionTecnologia;
        }

        public async Task UpdatePeticionTecnologiaAsync
           (int idpeticiontecnologia, string tecnologia, int idtipopeticioncategoria)
        {
            PeticionTecnologia newPeticionTecnologia = await
                this.FindPeticionTecnologiasAsync
                (idpeticiontecnologia);
            newPeticionTecnologia.NombreTecnologia = tecnologia;
            newPeticionTecnologia.IdTipoPeticionCategoria = idtipopeticioncategoria;
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePeticionTecnologiaAsync(int idpeticiontecnologia)
        {
            PeticionTecnologia peticionTecnologia = await
                this.FindPeticionTecnologiasAsync(idpeticiontecnologia);
            this.context.PeticionesTecnologias.Remove(peticionTecnologia);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region PROVINCIAS

        public async Task<List<Provincia>> GetProvinciasAsync()
        {
            return await this.context.Provincias.ToListAsync();
        }

        public async Task<Provincia>
            FindProvinciaAsync(int id)
        {
            return await
                this.context.Provincias
                .FirstOrDefaultAsync(x => x.IdProvincia == id);
        }

        private async Task<int> GetMaxProvincia()
        {
            if (this.context.Provincias.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.Provincias.MaxAsync
                    (z => z.IdProvincia) + 1;
            }
        }

        public async Task<Provincia> InsertProvinciaAsync
            (string nombreProvincia)
        {
            Provincia newProvincia = new Provincia();
            newProvincia.IdProvincia =
                await this.GetMaxProvincia();
            newProvincia.NombreProvincia = nombreProvincia;
            this.context.Provincias.Add(newProvincia);
            await this.context.SaveChangesAsync();
            return newProvincia;
        }

        public async Task UpdateProvinciaAsync
           (int idprovincia, string nombreprovincia)
        {
            Provincia newProvincia = await
                this.FindProvinciaAsync
                (idprovincia);
            newProvincia.NombreProvincia = nombreprovincia;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteProvinciaAsync(int idProvincia)
        {
            Provincia provincia = await
                this.FindProvinciaAsync(idProvincia);
            this.context.Provincias.Remove(provincia);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region ROLES

        public async Task<List<Role>> GetRolesAsync()
        {
            return await this.context.Roles.ToListAsync();
        }

        public async Task<Role>
            FindRoleAsync(int id)
        {
            return await
                this.context.Roles
                .FirstOrDefaultAsync(x => x.IdRole == id);
        }

        private async Task<int> GetMaxRole()
        {
            if (this.context.Roles.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.Roles.MaxAsync
                    (z => z.IdRole) + 1;
            }
        }

        public async Task<Role> InsertRoleAsync
            (string tipoRole)
        {
            Role newRole = new Role();
            newRole.IdRole =
                await this.GetMaxRole();
            newRole.TipoRole = tipoRole;
            this.context.Roles.Add(newRole);
            await this.context.SaveChangesAsync();
            return newRole;
        }

        public async Task UpdateRoleAsync
           (int idRole, string tipoRole)
        {
            Role newRole = await
                this.FindRoleAsync
                (idRole);
            newRole.TipoRole = tipoRole;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int idRole)
        {
            Role role = await
                this.FindRoleAsync(idRole);
            this.context.Roles.Remove(role);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region TECNOLOGIAS

        public async Task<List<Tecnologia>> GetTecnologiasAsync()
        {
            return await this.context.Tecnologias.ToListAsync();
        }

        public async Task<Tecnologia>
            FindTecnologiaAsync(int id)
        {
            return await
                this.context.Tecnologias
                .FirstOrDefaultAsync(x => x.IdTecnologia == id);
        }

        private async Task<int> GetMaxTecnologia()
        {
            if (this.context.Tecnologias.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.Tecnologias.MaxAsync
                    (z => z.IdTecnologia) + 1;
            }
        }

        public async Task<Tecnologia> InsertTecnologiaAsync
            (Tecnologia requestTecnologia)
        {
            Tecnologia newTecnologia = new Tecnologia();
            newTecnologia.IdTecnologia =
                await this.GetMaxTecnologia();
            newTecnologia.IdTipoTecnologia = requestTecnologia.IdTipoTecnologia;
            newTecnologia.NombreTecnologia = requestTecnologia.NombreTecnologia;
            this.context.Tecnologias.Add(newTecnologia);
            await this.context.SaveChangesAsync();
            return newTecnologia;
        }

        public async Task UpdateTecnologiaAsync
           (Tecnologia requestTecnologia)
        {
            Tecnologia newTecnologia = await
                this.FindTecnologiaAsync
                (requestTecnologia.IdTecnologia);
            newTecnologia.IdTipoTecnologia = requestTecnologia.IdTipoTecnologia;
            newTecnologia.NombreTecnologia = requestTecnologia.NombreTecnologia;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteTecnologiaAsync(int idTecnologia)
        {
            Tecnologia tecno = await
                this.FindTecnologiaAsync(idTecnologia);
            this.context.Tecnologias.Remove(tecno);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region TECNOLOGIAS TECHRIDERS

        public async Task<List<TecnologiaTechRiders>> GetTecnologiasTechRidersAsync()
        {
            return await this.context.TecnologiasTechRiders.ToListAsync();
        }

        public async Task<TecnologiaTechRiders>
            FindTecnologiasTechRidersAsync
            (int idTechRider, int idTecnologia)
        {
            return await this.context.TecnologiasTechRiders
                .FirstOrDefaultAsync(z => z.IdUsuario == idTechRider
                && z.IdTecnologia == idTecnologia);
        }

        public async Task<List<TecnologiaTechRiders>>
            GetTecnologiasTechRidersAsync(int idTechRider)
        {
            return await this.context.TecnologiasTechRiders
                .Where(z => z.IdUsuario == idTechRider)
                .ToListAsync();
        }

        public async Task<TecnologiaTechRiders> InsertTecnologiaTechRiderAsync
            (int idTechRider, int idTecnologia)
        {
            TecnologiaTechRiders newTecnologiaTechRiders = new TecnologiaTechRiders();
            newTecnologiaTechRiders.IdUsuario = idTechRider;
            newTecnologiaTechRiders.IdTecnologia = idTecnologia;
            this.context.TecnologiasTechRiders.Add(newTecnologiaTechRiders);
            await this.context.SaveChangesAsync();
            return newTecnologiaTechRiders;
        }

        public async Task
            UpdateTecnologiaTechRiderAsync
             (int idTechRider, int idTecnologia)
        {
            TecnologiaTechRiders newTecnologiaTechRiders =
                await
                this.FindTecnologiasTechRidersAsync(idTechRider, idTecnologia);
            newTecnologiaTechRiders.IdTecnologia = idTecnologia;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteTecnologiaTechRidersAsync
             (int idTechRider, int idTecnologia)
        {
            TecnologiaTechRiders newTecnologiaTechRiders =
                await
                this.FindTecnologiasTechRidersAsync(idTechRider, idTecnologia);
            this.context.TecnologiasTechRiders.Remove(newTecnologiaTechRiders);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region TECNOLOGIAS CHARLAS

        public async Task<List<TecnologiaCharlas>>
            GetTecnologiasCharlasAsync()
        {
            return await this.context.TecnologiasCharlas.ToListAsync();
        }

        public async Task<TecnologiaCharlas>
            FindTecnologiasCharlaAsync
            (int idCharla, int idTecnologia)
        {
            return await this.context.TecnologiasCharlas
                .FirstOrDefaultAsync(z => z.IdCharla == idCharla);
        }

        public async Task<List<TecnologiaCharlas>>
            FindTecnologiasCharlaByCharlaAsync
            (int idCharla)
        {
            return await this.context.TecnologiasCharlas
                .Where(z => z.IdCharla == idCharla).ToListAsync();
        }

        public async Task<List<TecnologiaCharlas>>
            FindTecnologiasCharlaByTecnologiaAsync
            (int idTecnologia)
        {
            return await this.context.TecnologiasCharlas
                .Where(z => z.IdTecnologia == idTecnologia).ToListAsync();
        }

        public async Task<TecnologiaCharlas>
            InsertTecnologiaCharlasAsync
            (int idCharla, int idTecnologia)
        {
            TecnologiaCharlas newTecnologiaCharlas =
                new TecnologiaCharlas();
            newTecnologiaCharlas.IdCharla = idCharla;
            newTecnologiaCharlas.IdTecnologia = idTecnologia;
            this.context.TecnologiasCharlas.Add(newTecnologiaCharlas);
            await this.context.SaveChangesAsync();
            return newTecnologiaCharlas;
        }

        public async Task DeleteTecnologiaCharlasAsync
             (int idCharla, int idTecnologia)
        {
            TecnologiaCharlas newTecnologiaCharlas =
                await
                this.FindTecnologiasCharlaAsync(idCharla, idTecnologia);
            this.context.TecnologiasCharlas.Remove(newTecnologiaCharlas);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteTecnologiaCharlaByCharlaAsync(int idCharla)
        {
            List<TecnologiaCharlas> datos =
                await this.FindTecnologiasCharlaByCharlaAsync(idCharla);
            foreach (var eliminar in datos)
            {
                this.context.TecnologiasCharlas.Remove(eliminar);
            }
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region TIPO EMPRESA

        public async Task<List<TipoEmpresa>> GetTipoEmpresaAsync()
        {
            return await this.context.TiposEmpresas.ToListAsync();
        }

        public async Task<TipoEmpresa>
            FindTipoEmpresaAsync(int id)
        {
            return await
                this.context.TiposEmpresas
                .FirstOrDefaultAsync(x => x.IdTipoEmpresa == id);
        }

        private async Task<int> GetMaxTipoEmpresa()
        {
            if (this.context.TiposEmpresas.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.TiposEmpresas.MaxAsync
                    (z => z.IdTipoEmpresa) + 1;
            }
        }

        public async Task<TipoEmpresa> InsertTipoEmpresaAsync
            (string descripcion)
        {
            TipoEmpresa newTipoEmpresa = new TipoEmpresa();
            newTipoEmpresa.IdTipoEmpresa =
                await this.GetMaxTipoEmpresa();
            newTipoEmpresa.Descripcion = descripcion;
            this.context.TiposEmpresas.Add(newTipoEmpresa);
            await this.context.SaveChangesAsync();
            return newTipoEmpresa;
        }

        public async Task UpdateTipoEmpresaAsync
                (int idtipoempresa, string descripcion)
        {
            TipoEmpresa newTipoEmpresa = await
                this.FindTipoEmpresaAsync(idtipoempresa);
            newTipoEmpresa.Descripcion = descripcion;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteTipoEmpresaAsync
                (int idTipoEmpresa)
        {
            TipoEmpresa newTipoEmpresa = await
                this.FindTipoEmpresaAsync(idTipoEmpresa);
            this.context.TiposEmpresas.Remove(newTipoEmpresa);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region TIPO TECNOLOGIA

        public async Task<List<TipoTecnologia>> GetTipoTecnologiaAsync()
        {
            return await this.context.TiposTecnologias.ToListAsync();
        }

        public async Task<TipoTecnologia>
            FindTipoTecnologiaAsync(int id)
        {
            return await
                this.context.TiposTecnologias
                .FirstOrDefaultAsync(x => x.IdTipoTecnologia == id);
        }

        private async Task<int> GetMaxTipoTecnologia()
        {
            if (this.context.TiposTecnologias.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.TiposTecnologias.MaxAsync
                    (z => z.IdTipoTecnologia) + 1;
            }
        }

        public async Task<TipoTecnologia> InsertTipoTecnologiaAsync
            (string descripcion)
        {
            TipoTecnologia newTipoTecnologia = new TipoTecnologia();
            newTipoTecnologia.IdTipoTecnologia =
                await this.GetMaxTipoTecnologia();
            newTipoTecnologia.Descripcion = descripcion;
            this.context.TiposTecnologias.Add(newTipoTecnologia);
            await this.context.SaveChangesAsync();
            return newTipoTecnologia;
        }

        public async Task UpdateTipoTecnologiaAsync
                (int idTipoTecnologia, string descripcion)
        {
            TipoTecnologia newTipoTecnologia = await
                this.FindTipoTecnologiaAsync(idTipoTecnologia);
            newTipoTecnologia.Descripcion = descripcion;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteTipoTecnologiaAsync
                (int idTipoTecnologia)
        {
            TipoTecnologia newTipoTecnologia = await
                this.FindTipoTecnologiaAsync(idTipoTecnologia);
            this.context.TiposTecnologias.Remove(newTipoTecnologia);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region USUARIOS

        public async Task<List<Usuario>> GetUsuarioAsync()
        {
            return await this.context.Usuarios.ToListAsync();
        }

        public async Task<Usuario>
            FindUsuarioAsync(int id)
        {
            return await
                this.context.Usuarios
                .FirstOrDefaultAsync(x => x.IdUsuario == id);
        }

        public async Task<Usuario>
            FindUsuarioPasswordAsync(string email, string password)
        {
            return await
                this.context.Usuarios
                .FirstOrDefaultAsync(x => x.Email == email &&
                x.Password == password);
        }

        private async Task<int> GetMaxIdUsuario()
        {
            if (this.context.Usuarios.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.Usuarios.MaxAsync(z => z.IdUsuario) + 1;
            }
        }

        public async Task<Usuario> InsertUsuarioAsync
            (Usuario requestUsuario)
        {
            Usuario newUsuario = new Usuario();
            newUsuario.IdUsuario = await this.GetMaxIdUsuario();
            newUsuario.IdEmpresaCentro = requestUsuario.IdEmpresaCentro;
            newUsuario.IdProvincia = requestUsuario.IdProvincia;
            newUsuario.IdRole = requestUsuario.IdRole;
            newUsuario.LinkedIn = requestUsuario.LinkedIn;
            newUsuario.Nombre = requestUsuario.Nombre;
            newUsuario.Password = requestUsuario.Password;
            newUsuario.Telefono = requestUsuario.Telefono;
            newUsuario.Estado = requestUsuario.Estado;
            newUsuario.Apellidos = requestUsuario.Apellidos;
            newUsuario.Email = requestUsuario.Email;
            newUsuario.LinkedInVisible = requestUsuario.LinkedInVisible;
            newUsuario.Imagen = requestUsuario.Imagen != null ?
                requestUsuario.Imagen.Replace("0", newUsuario.IdUsuario.ToString()) : null;

            this.context.Usuarios.Add(newUsuario);
            await this.context.SaveChangesAsync();
            return newUsuario;
        }

        public async Task<Usuario> UpdateUsuarioAsync
            (Usuario requestUsuario)
        {
            Usuario newUsuario = await
                this.FindUsuarioAsync(requestUsuario.IdUsuario);
            newUsuario.IdEmpresaCentro = requestUsuario.IdEmpresaCentro;
            newUsuario.IdProvincia = requestUsuario.IdProvincia;
            newUsuario.IdRole = requestUsuario.IdRole;
            newUsuario.LinkedIn = requestUsuario.LinkedIn;
            newUsuario.Nombre = requestUsuario.Nombre;
            newUsuario.Password = requestUsuario.Password;
            newUsuario.Telefono = requestUsuario.Telefono;
            newUsuario.Estado = requestUsuario.Estado;
            newUsuario.Apellidos = requestUsuario.Apellidos;
            newUsuario.Email = requestUsuario.Email;
            newUsuario.LinkedInVisible = requestUsuario.LinkedInVisible;
            newUsuario.Imagen = requestUsuario.Imagen != null ?
               requestUsuario.Imagen.Replace("x", newUsuario.IdUsuario.ToString()) : null;

            await this.context.SaveChangesAsync();
            return newUsuario;
        }

        public async Task DeleteUsuarioAsync(int idUsuario)
        {
            Usuario user = await this.FindUsuarioAsync(idUsuario);
            this.context.Usuarios.Remove(user);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateEstadoUsuarioAsync(int idUsuario, int estado)
        {
            Usuario user = await this.FindUsuarioAsync(idUsuario);
            user.Estado = estado;
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePasswordUsuarioAsync
            (int idUsuario, string password)
        {
            Usuario user = await this.FindUsuarioAsync(idUsuario);
            user.Password = password;
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateLinkedInVisibleAsync(int idUsuario, bool peticion)
        {
            int linkedInVisible = 0;
            if (peticion == true)
            {
                linkedInVisible = 1;
            }
            Usuario user = await this.FindUsuarioAsync(idUsuario);
            user.LinkedInVisible = linkedInVisible;
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region VALORACION CHARLAS

        public async Task<List<ValoracionCharla>> GetValoracionesCharlasAsync()
        {
            return await this.context.ValoracionesCharlas.ToListAsync();
        }

        public async Task<ValoracionCharla>
            FindValoracionCharlaAsync(int id)
        {
            return await
                this.context.ValoracionesCharlas
                .FirstOrDefaultAsync(x => x.IdValoracion == id);
        }

        public async Task<List<ValoracionCharla>>
            GetValoracionesCharlaAsync(int idcharla)
        {
            return await
                this.context.ValoracionesCharlas
                .Where(x => x.IdCharla == idcharla).ToListAsync();
        }

        private async Task<int> GetMaxIdValoracionCharla()
        {
            if (this.context.ValoracionesCharlas.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.ValoracionesCharlas.MaxAsync
                    (z => z.IdValoracion) + 1;
            }
        }

        public async Task<ValoracionCharla> InsertValoracionCharlasAsync
            (ValoracionCharla requestValoracionCharla)
        {
            ValoracionCharla newValoracionCharla = new ValoracionCharla();
            newValoracionCharla.IdValoracion =
                await this.GetMaxIdValoracionCharla();
            newValoracionCharla.Comentario = requestValoracionCharla.Comentario;
            newValoracionCharla.Valoracion = requestValoracionCharla.Valoracion;
            newValoracionCharla.IdCharla = requestValoracionCharla.IdCharla;
            this.context.ValoracionesCharlas.Add(newValoracionCharla);
            await this.context.SaveChangesAsync();
            return newValoracionCharla;
        }

        public async Task UpdateValoracionCharlasAsync
            (ValoracionCharla requestValoracionCharla)
        {
            ValoracionCharla newValoracionCharla = await
                this.FindValoracionCharlaAsync
                (requestValoracionCharla.IdValoracion);
            newValoracionCharla.Comentario = requestValoracionCharla.Comentario;
            newValoracionCharla.Valoracion = requestValoracionCharla.Valoracion;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteValoracionCharlaAsync
                (int idValoracionCharla)
        {
            ValoracionCharla newValoracionCharla = await
                this.FindValoracionCharlaAsync(idValoracionCharla);
            this.context.ValoracionesCharlas.Remove(newValoracionCharla);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region TIPOS PETICION CATEGORIAS

        public async Task<List<TipoPeticionCategoria>> GetTipoPeticionCategoriaAsync()
        {
            return await this.context.TiposPeticionesCategorias.ToListAsync();
        }

        public async Task<TipoPeticionCategoria>
            FindTipoPeticionCategoriaAsync(int id)
        {
            return await
                this.context.TiposPeticionesCategorias
                .FirstOrDefaultAsync(x => x.IdTipoPeticionCategoria == id);
        }

        private async Task<int> GetMaxIdTiposPeticionesCategorias()
        {
            if (this.context.TiposPeticionesCategorias.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await
                    this.context.TiposPeticionesCategorias.MaxAsync
                    (z => z.IdTipoPeticionCategoria) + 1;
            }
        }

        public async Task<TipoPeticionCategoria> InsertTiposPeticionesCategoriasAsync
            (string nombrepeticion)
        {
            TipoPeticionCategoria newTipoPeticionCategoria = new TipoPeticionCategoria();
            newTipoPeticionCategoria.IdTipoPeticionCategoria =
                await this.GetMaxIdPeticionTecnologia();
            newTipoPeticionCategoria.Categoria = nombrepeticion;
            this.context.TiposPeticionesCategorias.Add(newTipoPeticionCategoria);
            await this.context.SaveChangesAsync();
            return newTipoPeticionCategoria;
        }

        public async Task UpdateTipoPeticionCategoriaAsync
           (int idpeticiontecnologia, string nombrepeticion)
        {
            TipoPeticionCategoria newTipoPeticionCategoria = await
                this.FindTipoPeticionCategoriaAsync
                (idpeticiontecnologia);
            newTipoPeticionCategoria.Categoria = nombrepeticion;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteTipoPeticionCategoriaAsync
            (int idpeticiontecnologia)
        {
            TipoPeticionCategoria tipoPeticionCategoria = await
                this.FindTipoPeticionCategoriaAsync(idpeticiontecnologia);
            this.context.TiposPeticionesCategorias.Remove(tipoPeticionCategoria);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region CHARLAS VIEW

        public async Task<List<CharlaView>> GetCharlasViewAsync()
        {
            return await this.context.CharlasView.ToListAsync();
        }

        public async Task<CharlaView>
            FindCharlaViewAsync(int id)
        {
            return await
                this.context.CharlasView
                .FirstOrDefaultAsync(x => x.IdCharla == id);
        }

        public async Task<List<CharlaView>>
            GetCharlasViewTechrRiderAsync(int idTechRider)
        {
            return await this.context.CharlasView
                .Where(x => x.IdTechRider == idTechRider)
                .ToListAsync();
        }

        //METODO PARA DEVOLVER TODAS LAS CHARLAS de TODOS LOS CURSOS DE UN PROFESOR
        public async Task<List<CharlaView>>
            GetCharlasViewProfesorCursosAsync(int idProfesor)
        {
            //PRIMERO DEBEMOS BUSCAR EL IDCURSO DE UN USUARIO
            //SELECT * FROM CURSOS_PROFESORES
            var consultaCursosProfe = from datos in this.context.CursosProfesores
                                      where datos.IdProfesor == idProfesor
                                      select datos.IdCurso;
            List<int> cursosOfTeacher = new List<int>();
            cursosOfTeacher = await consultaCursosProfe.ToListAsync();
            //AHORA DEVOLVEMOS EL CONTAINS FILTRANDO POR LOS CURSOS
            var consulta = from datos in this.context.CharlasView
                           where cursosOfTeacher.Contains(datos.IdCurso)
                           select datos;
            return await consulta.ToListAsync();
        }

        #endregion

        #region TECHRIDERS TECNOLOGIAS 

        public async Task<List<TechRiderTecnologia>>
            GetTechRidersTecnologias()
        {
            return await this.context.TechRiderTecnologias.ToListAsync();
        }

        //METODO PARA BUSCAR TECNOLOGIAS POR TECHRIDER
        public async Task<List<TechRiderTecnologia>>
            FindTechRidersTecnologias(int idTechRider)
        {
            return await this.context.TechRiderTecnologias
                .Where(x => x.IdTechRider == idTechRider)
                .ToListAsync();
        }

        #endregion

        #region CURSOSPROFESORESVIEW

        public async Task<List<CursoProfesorView>>
            GetCursosProfesoresView()
        {
            return await this.context.CursosProfesoresView.ToListAsync();
        }

        public async Task<List<CursoProfesorView>>
            GetCursosProfesorView(int idProfesor)
        {
            return await
                this.context.CursosProfesoresView.
                Where(x => x.IdProfesor == idProfesor).
                ToListAsync();
        }

        #endregion

        #region TECHRIDERSEMPRESASVIEW

        public async Task<List<TechRiderEmpresaView>>
            GetTechRidersEmpresasViewAsync()
        {
            return await this.context.TechRidersEmpresasView.ToListAsync();
        }

        public async Task<List<TechRiderEmpresaView>>
            FindTechRidersEmpresaByTechRiderViewAsync(int idTechRider)
        {
            return await
                this.context.TechRidersEmpresasView.
                Where(x => x.IdTechRider == idTechRider).
                ToListAsync();
        }

        public async Task<List<TechRiderEmpresaView>>
            FindTechRidersEmpresaByEmpresaViewAsync(int idEmpresa)
        {
            return await
                this.context.TechRidersEmpresasView.
                Where(x => x.IdEmpresa == idEmpresa).
                ToListAsync();
        }

        #endregion

        #region CHARLASTECHRIDERSEMPRESAVIEW

        public async Task<List<CharlaTechRiderEmpresaView>>
            GetCharlasTechRidersViewAsync()
        {
            return await this.context.CharlasTechRidersView.ToListAsync();
        }

        public async Task<List<CharlaTechRiderEmpresaView>>
            FindCharlasTechRidersViewAsync(int idEmpresa)
        {
            return await
                this.context.CharlasTechRidersView.
                Where(x => x.IdEmpresa == idEmpresa).
                ToListAsync();
        }

        #endregion

        #region CHARLASPENDIENTESEMPRESAVIEW

        //VISTA PARA MOSTRAR LAS CHARLAS PENDIENTES 
        //QUE COINCIDAN CON LAS TECNOLOGIAS DE UN TECHRIDER Y DE UNA CHARLA
        public async Task<List<CharlaPendienteEmpresaView>>
            FindCharlasPendientesMatchTecnologiaTechRider
            (int idtechrider)
        {
            //TRAEMOS TODAS LAS TECNOLOGIAS QUE DOMINA UN TECHRIDER
            var consultaTecnologiasTechRider = await
                (from datos in this.context.TecnologiasTechRiders
                 where datos.IdUsuario == idtechrider
                 select datos.IdTecnologia).ToListAsync();
            //EXTREAMOS TODOS LOS ID DE TECNOLOGIAS
            List<int> idTecnologiasTechRider = new List<int>();

            //A CONTINUACION,
            //DEBEMOS BUSCAR LAS CHARLAS QUE COINCIDAN
            //CON LAS TECNOLOGIAS DE UN TECHRIDER
            //Y EXTRAEMOS EL ID DE LAS CHARLAS
            var consultaTecnologiasCharlas = await
                (from datos in this.context.TecnologiasCharlas
                 where consultaTecnologiasTechRider.Contains(datos.IdTecnologia)
                 select datos.IdCharla).ToListAsync();
            //DEBEMOS FILTRAR POR EL ESTADO DE LA CHARLA 2, PENDIENTE
            //Y POR LAS TECNOLOGIAS QUE HAN COINCIDIDO
            var consultaCharlasPendientes =
                from datos in this.context.CharlasPendientesEmpresasView
                where datos.IdEstadoCharla == 2
                && consultaTecnologiasCharlas.Contains(datos.IdCharla)
                select datos;
            return await consultaCharlasPendientes.ToListAsync();
        }


        #endregion

        #region CONSULTA TECNOLOGIAS PENDIENTES CON SUS CHARLAS

        //VISTA PARA MOSTRAR TODAS LAS TECNOLOGIAS
        //PENDIENTES POR CUBRIR EN LAS CHARLAS
        public async Task<List<TecnologiaLibreView>>
            GetTecnologiasPendientesEnCharlas()
        {
            //RECUPERAMOS TODOS LOS ID CHARLAS CON ESTADO PENDIENTE
            var consultaTecnologiasCharlasPendientes = await
                (from datos in this.context.TecnologiasLibresView
                 where datos.IdEstadoCharla == 2
                 select datos).ToListAsync();
            return consultaTecnologiasCharlasPendientes;
        }

        #endregion

        #region TODOSTECHRIDERSVIEW

        //CONSULTA PARA TODOS LOS TECHRIDERS
        //DEBEMOS INDICAR SOLO LOS QUE ESTEN ACTIVOS???
        public async Task<List<TodoTechRider>> GetTodosTechRidersViewAsync()
        {
            return await this.context.TodosTechRidersView.ToListAsync();
        }

        #endregion

        #region USERSFORMATOVIEW

        //DEVUELVE TODOS LOS USUARIOS CON FORMATO
        public async Task<List<UserFormatoView>> GetTodosUsersFormatoViewAsync()
        {
            return await this.context.UsersFormatoView.ToListAsync();
        }

        //DEVUELVE TODOS LOS USUARIOS CON FORMATO POR ESTADO
        public async Task<List<UserFormatoView>>
            GetUsersFormatoViewByEstadoAsync(int estado)
        {
            return await this.context.UsersFormatoView
                .Where(z => z.IdEstadoValidacion == estado)
                .ToListAsync();
        }

        #endregion

        #region EMPRESASFORMATOVIEW

        //DEVUELVE TODAS LAS EMPRESAS CON FORMATO
        public async Task<List<EmpresaFormatoView>> GetTodosEmpresasFormatoViewAsync()
        {
            return await this.context.EmpresasFormatoView.ToListAsync();
        }

        //DEVUELVE TODAS LAS EMPRESAS CON FORMATO POR SU ESTADO
        public async Task<List<EmpresaFormatoView>>
            GetEmpresasFormatoViewByStateAsync(int estado)
        {
            return await this.context.EmpresasFormatoView
                .Where(z => z.EstadoEmpresa == estado)
                .ToListAsync();
        }

        //METODO PARA DEVOLVER TODAS LAS EMPRESAS LIBRES, ES DECIR, 
        //QUE NO TENGAN UN RESPONSABLE DE EMPRESA ASIGNADO
        //DEVUELVE TODAS LAS EMPRESAS CON FORMATO
        public async Task<List<EmpresaFormatoView>>
            GetEmpresasFormatoLibresViewAsync()
        {
            //BUSCAMOS LOS ID DE EMPRESAS DE LOS USUARIOS CON ROLE RESPONSABLE
            //LOS IDS QUE EXISTEN
            var consultaEmpresasOcupadas = from datos in this.context.Usuarios
                                           where datos.IdRole == 4
                                           && datos.IdEmpresaCentro != null
                                           select datos.IdEmpresaCentro.Value;
            List<int> idsEmpresasOcupadas = new List<int>();
            idsEmpresasOcupadas = await consultaEmpresasOcupadas.ToListAsync();
            //BUSCAMOS LAS EMPRESAS QUE NO ESTEN DENTRO DE LA COLECCION
            var consulta = from datos in this.context.EmpresasFormatoView
                           where idsEmpresasOcupadas.Contains(datos.IdEmpresaCentro) == false
                           select datos;
            return await consulta.ToListAsync();
        }

        //METODO PARA DEVOLVER TODAS LAS EMPRESAS CON RESPONSABLE ASIGNADO
        public async Task<List<EmpresaFormatoView>>
            GetEmpresasFormatoConResponsablesViewAsync()
        {
            //BUSCAMOS LOS ID DE EMPRESAS DE LOS USUARIOS CON ROLE RESPONSABLE
            //LOS IDS QUE EXISTEN
            var consultaEmpresasOcupadas = from datos in this.context.Usuarios
                                           where datos.IdRole == 4
                                           && datos.IdEmpresaCentro != null
                                           select datos.IdEmpresaCentro.Value;
            List<int> idsEmpresasOcupadas = new List<int>();
            idsEmpresasOcupadas = await consultaEmpresasOcupadas.ToListAsync();
            //BUSCAMOS LAS EMPRESAS QUE ESTEN DENTRO DE LA COLECCION
            var consulta = from datos in this.context.EmpresasFormatoView
                           where idsEmpresasOcupadas.Contains(datos.IdEmpresaCentro)
                           select datos;
            return await consulta.ToListAsync();
        }

        #endregion

        #region PETICIONESFORMATOVIEW

        //DEVUELVE TODAS LAS PETICIONES CON FORMATO
        public async Task<List<PeticionFormatoView>> GetPeticionesFormatoViewAsync()
        {
            return await this.context.PeticionesFormatoView
                .OrderBy(z => z.IdTipoPeticion)
                .ToListAsync();
        }

        //FILTRA PETICIONES POR EL ID DEL TIPO DE PETICION CON FORMATO
        public async Task<List<PeticionFormatoView>>
            GetPeticionesFormatoByTipoPeticionViewAsync(int idTipoPeticion)
        {
            return await this.context.PeticionesFormatoView
                .Where(z => z.IdTipoPeticion == idTipoPeticion)
                .OrderBy(z => z.IdRegistroPeticion)
                .ToListAsync();
        }

        #endregion

        #region MODIFICARPASS

        public async Task<string> RecuperarUsuarioAsync(string email)
        {
            Usuario usuario = await this.context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
            if (usuario == null)
            {
                return null;
            }
            string codigo = helper.GenerarCodigoAsync();
            usuario.TokenPass = codigo;
            await this.context.SaveChangesAsync();
            return codigo;
        }
        public async Task<Usuario> UpdatePasswordAsync(string email, string codigo, string password)
        {
            Usuario usuario = await this.context.Usuarios.FirstOrDefaultAsync(x => x.Email == email && x.TokenPass == codigo);
            if (usuario != null)
            {
                usuario.TokenPass = null;
                usuario.Password = password;
                await this.context.SaveChangesAsync();
            }

            return usuario;
        }
        #endregion
    }
}
