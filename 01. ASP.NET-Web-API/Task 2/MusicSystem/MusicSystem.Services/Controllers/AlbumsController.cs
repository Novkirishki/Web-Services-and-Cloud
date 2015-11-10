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

    public class AlbumsController : ApiController
    {
        private IRepository<Artist> artists;
        private IRepository<Country> countries;
        private IRepository<Album> albums;

        public AlbumsController(IRepository<Artist> artists, IRepository<Country> countries, IRepository<Album> albums)
        {
            this.artists = artists;
            this.countries = countries;
            this.albums = albums;
        }

        public IHttpActionResult Get()
        {
            var result = this.albums.All().ProjectTo<AlbumModel>();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = this.albums.All().Where(a => a.Id == id).ProjectTo<AlbumModel>().First();

            return this.Ok(result);
        }

        public IHttpActionResult Post([FromBody] AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                var result = Mapper.Map<Album>(album);

                this.albums.Add(result);
                this.albums.SaveChanges();

                return this.Created(this.Url.ToString(), result);
            }
        }

        public IHttpActionResult Put([FromBody] AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                var result = this.albums.All()
                    .Where(a => a.Title == album.Title).FirstOrDefault();

                if (result == null)
                {
                    return this.NotFound();
                }
                else
                {
                    result.Year = album.Year;
                    result.Profit = album.Profit;

                    this.albums.Add(result);
                    this.albums.SaveChanges();

                    return this.Ok(result);
                }
            }
        }

        public IHttpActionResult Delete(int id)
        {
            var album = this.albums.All().Where(s => s.Id == id).FirstOrDefault();

            if (album == null)
            {
                return this.NotFound();
            }
            else
            {
                this.albums.Delete(album);
                this.albums.SaveChanges();

                return this.Ok(album);
            }
        }
    }
}
