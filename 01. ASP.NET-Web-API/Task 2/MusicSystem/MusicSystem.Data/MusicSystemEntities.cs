namespace MusicSystem.Data
{
    using Models;
    using System.Data.Entity;

    public class MusicSystemEntities : DbContext
    {
        public MusicSystemEntities() : base("MusicSystemConnection")
        {
        }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Song> Songs { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }
    }
}
