using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SampleWebAPI.Data
{
    public class SamuraiContext: DbContext
    {
        public SamuraiContext()
        {

        }
        public SamuraiContext(DbContextOptions<SamuraiContext> options):base(options)
        {

        }
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<SamuraiBattleStats> SamuraiBattleStats { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          //  optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SampleDb");
            //.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name },Microsoft.Extensions.Logging.LogLevel.Information).EnableSensitiveDataLogging();

        }
        /*menambahkan payload(kolom baru pada implisit tabel,
         * di sini ktia harus membaut tabel explisit kita dahulu, tabel di sini sudah di buat yaitu
         BattleSamurai, case ini jarnag terjadi*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Samurai>().HasMany(s => s.Battles)
                .WithMany(b => b.Samurais)
                .UsingEntity<BattleSamurai>(bs => bs.HasOne<Battle>().WithMany(),
                bs => bs.HasOne<Samurai>().WithMany()).Property(bs => bs.DateJoined)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<SamuraiBattleStats>().HasNoKey().ToView("SamuraiBattleStats");
               
        }
    }
}
