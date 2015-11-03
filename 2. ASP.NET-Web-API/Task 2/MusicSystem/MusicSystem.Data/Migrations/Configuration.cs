namespace MusicSystem.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MusicSystem.Data.MusicSystemEntities>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(MusicSystem.Data.MusicSystemEntities context)
        {
            context.Countries.AddOrUpdate(
                c => c.Name,
                new Country() { Name = "Bulgaria" },
                new Country() { Name = "USA" },
                new Country() { Name = "UK" });

            context.SaveChanges();

            context.Artists.AddOrUpdate(
                a => a.Name,
                new Artist() { Name = "Krisko", Age = 28, CountryName = "Bulgaria", DateOfBirth = new DateTime(1987, 3, 17) },
                new Artist() { Name = "100 Kila", Age = 39, CountryName = "Bulgaria", DateOfBirth = new DateTime(1976, 6, 16) });

            context.SaveChanges();

            var album = new Album() { Title = "Some album", Year = 2006, Profit = 100000 };
            album.Artists.Add(context.Artists.Where(a => a.Name == "Krisko").FirstOrDefault());

            context.Albums.AddOrUpdate(a => a.Title, album);

            context.SaveChanges();

            context.Songs.AddOrUpdate(
                s => s.Title,
                new Song() { Title = "Some song", Year = 2001, AlbumId = 1, ArtistId = 1 });

            context.SaveChanges();
        }
    }
}
