using KoudWS.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KoudWS.Data
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {

        }
        public DbSet<TvShowEntity> TvShow { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TvShowEntity>(entity =>
            {
                entity.HasKey(tvShowEntity => tvShowEntity.ID_tvshow);
                entity.Property(tvShowsEntity => tvShowsEntity.Favorite_tvshow).HasConversion(value => value ? 1 : 0, value => value == 1);
            });
        }
    }
}