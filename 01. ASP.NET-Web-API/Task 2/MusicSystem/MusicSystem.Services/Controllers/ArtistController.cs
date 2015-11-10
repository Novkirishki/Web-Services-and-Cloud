namespace MusicSystem.Services.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using Data.Repositories;
    using MusicSystem.Models;
    using System;
    using System.Linq;
    using System.Web.Http;

    public class ArtistsController : ApiController
    {
        private IRepository<Artist> artists;
        private IRepository<Country> countries;

        public ArtistsController(IRepository<Artist> artists, IRepository<Country> countries)
        {
            this.artists = artists;
            this.countries = countries;
        }

        public IHttpActionResult Get()
        {
            var result = this.artists.All().ProjectTo<ArtistModel>();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = this.artists.All().Where(a => a.Id == id).ProjectTo<ArtistModel>().First();

            return this.Ok(result);
        }

        public IHttpActionResult Post([FromBody] ArtistModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                var result = Mapper.Map<Artist>(artist);

                this.artists.Add(result);
                this.artists.SaveChanges();

                return this.Created(this.Url.ToString(), result);
            }
        }

        public IHttpActionResult Put([FromBody] ArtistModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                var result = this.artists.All()
                    .Where(a => a.Name == artist.Name).FirstOrDefault();

                if (result == null)
                {
                    return this.NotFound();
                }
                else
                {
                    if (artist.Age != 0)
                    {
                        result.Age = artist.Age;
                    }

                    if (artist.Country != null)
                    {
                        result.Country = this.countries.All().Where(c => c.Name == artist.Country).First();
                    }                    

                    //this.artists.Update(result);
                    this.artists.SaveChanges();

                    return this.Ok(result);
                }
            }
        }

        public IHttpActionResult Delete(int id)
        {
            var artist = this.artists.All().Where(s => s.Id == id).FirstOrDefault();

            if (artist == null)
            {
                return this.NotFound();
            }
            else
            {
                this.artists.Delete(artist);
                this.artists.SaveChanges();

                return this.Ok(artist);
            }
        }
    }
}
