using Microsoft.EntityFrameworkCore;

namespace FireFighterOperations.Models
{
    public class EinsatzContext : DbContext
    {
        public DbSet<Einsatz> Einsatz { get; set; }
        public DbSet<Fahrzeug> Fahrzeug { get; set; }
        public DbSet<EingesetztesFahrzeug> EingesetzesFahrzeug { get; set; }


        public EinsatzContext(DbContextOptions<EinsatzContext> options) : base(options)
        {
        }
    }
}
