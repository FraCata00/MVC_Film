//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Film.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Cloud_FilmEntities : DbContext
    {
        public Cloud_FilmEntities()
            : base("name=Cloud_FilmEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Abbonamento> Abbonamento { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<MetodoPagamento> MetodoPagamento { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
