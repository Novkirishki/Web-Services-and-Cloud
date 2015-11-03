namespace MusicSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        private ICollection<Artist> artists;

        public Country()
        {
            this.Artists = new HashSet<Artist>();
        }

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

        [Key]
        public string Name { get; set; }
    }
}
