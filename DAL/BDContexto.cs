using System.Data.Entity;
using EL;

namespace DAL
{
    public class BDContexto:DbContext
    {
        public BDContexto():base(Conexion.ConexionString())
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Formularios> Formularios { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<RolFormularios> RolFormularios { get; set; }
        public virtual DbSet<RolPermisos> RolPermisos { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
    }
}
