using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data
{
    public class MusicHubDbContext:DbContext
    {
        public MusicHubDbContext()
        {

        }

        public MusicHubDbContext(DbContextOptions options)
            :base(options)
        {

        }

        public  DbSet<Writer> Writers { get; set; }
        public  DbSet<Producer> Producers { get; set; }
        public  DbSet<Album> Albums { get; set; }
        public  DbSet<Performer> Performers  { get; set; }
        public  DbSet<Song> Songs { get; set; }
        public  DbSet<SongPerformer> SongsPerformers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>(entity =>
            {
                entity.Property(s => s.CreatedOn)
                .HasColumnType("date");
            });

            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(s => s.ReleaseDate)
                .HasColumnType("date");
            });

            modelBuilder.Entity<SongPerformer>(entity =>
            {
                entity.HasKey(pk => new
                {
                    pk.SongId,
                    pk.PerformerId
                });
            });
        }
    }
}
