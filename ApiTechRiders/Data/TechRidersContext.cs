using ApiTechRiders.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ApiTechRiders.Data
{
    public class TechRidersContext: DbContext
    {
        public TechRidersContext(DbContextOptions<TechRidersContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CursosProfesores>()
                .HasKey(x => new { x.IdCurso, x.IdProfesor });
            modelBuilder.Entity<TecnologiaCharlas>()
                .HasKey(x => new { x.IdCharla, x.IdTecnologia });
            modelBuilder.Entity<TecnologiaTechRiders>()
                .HasKey(x => new { x.IdUsuario, x.IdTecnologia });
        }

        public DbSet<Charla> Charlas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<CursosProfesores> CursosProfesores { get; set; }
        public DbSet<EmpresasCentros> EmpresasCentros { get; set; }
        public DbSet<EstadosCharla> EstadosCharlas { get; set; }
        public DbSet<EstadosValidacion> EstadosValidacion { get; set; }
        //public DbSet<Peticion> Peticiones { get; set; }
        public DbSet<PeticionAltaUsers> PeticionesAltaUsers { get; set; }
        //public DbSet<PeticionCategorias> PeticionesCategorias { get; set; }
        public DbSet<PeticionCentroEmpresa> PeticionesCentroEmpresa { get; set; }
        public DbSet<PeticionTecnologia> PeticionesTecnologias { get; set; }
        public DbSet<PeticionCharla> PeticionesCharlas { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tecnologia> Tecnologias { get; set; }
        public DbSet<TecnologiaTechRiders> TecnologiasTechRiders { get; set; }
        public DbSet<TecnologiaCharlas> TecnologiasCharlas { get; set; }
        public DbSet<TipoTecnologia> TiposTecnologias { get; set; }
        public DbSet<Usuario> Usuarios { get;set; }
        public DbSet<ValoracionCharla> ValoracionesCharlas { get; set; }

        public DbSet<TipoEmpresa> TiposEmpresas { get; set; }
        public DbSet<TipoPeticionCategoria> TiposPeticionesCategorias { get; set; }

        public DbSet<CharlaView> CharlasView { get; set; }
        public DbSet<TechRiderTecnologia> TechRiderTecnologias { get; set; }
        public DbSet<CursoProfesorView> CursosProfesoresView { get; set; }
        public DbSet<TechRiderEmpresaView> TechRidersEmpresasView { get; set; }

        public DbSet<CharlaTechRiderEmpresaView> CharlasTechRidersView { get; set; }

        public DbSet<CharlaPendienteEmpresaView> CharlasPendientesEmpresasView { get; set; }
        public DbSet<TecnologiaLibreView> TecnologiasLibresView { get; set; }
        public DbSet<TodoTechRider> TodosTechRidersView { get; set; }
        public DbSet<UserFormatoView> UsersFormatoView { get; set; }
        public DbSet<EmpresaFormatoView> EmpresasFormatoView { get; set; }
        public DbSet<PeticionFormatoView> PeticionesFormatoView { get; set; }

    }
}
