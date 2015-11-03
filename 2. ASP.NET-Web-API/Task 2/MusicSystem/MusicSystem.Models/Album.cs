using System.Collections.Generic;

namespace MusicSystem.Models
{
    public class Album
    {
        private ICollection<Artist> artists;
        private ICollection<Song> songs;

        public Album()
        {
            this.Artists = new HashSet<Artist>();
            this.Songs = new HashSet<Song>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public decimal Profit { get; set; }

        public virtual ICollection<Artist> Artists
        {
            get
            {
                return artists;
            }

            set
            {
                artists = value;
            }
        }

        public virtual ICollection<Song> Songs
        {
            get
            {
                return songs;
            }

            set
            {
                songs = value;
            }
        }
    }
}
