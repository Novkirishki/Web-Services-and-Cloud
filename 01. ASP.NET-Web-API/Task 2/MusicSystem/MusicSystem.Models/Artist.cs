namespace MusicSystem.Models
{
    using System;
    using System.Collections.Generic;

    public class Artist
    {
        private ICollection<Album> albums;
        private ICollection<Song> songs;

        public Artist()
        {
            this.Albums = new HashSet<Album>();
            this.Songs = new HashSet<Song>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string CountryName { get; set; }

        public virtual Country Country { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Album> Albums
        {
            get
            {
                return albums;
            }

            set
            {
                albums = value;
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
