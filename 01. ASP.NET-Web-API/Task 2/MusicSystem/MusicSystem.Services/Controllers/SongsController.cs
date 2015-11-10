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

    public class SongsController : ApiController
    {
        private IRepository<Song> songs;

        public SongsController(IRepository<Song> songs)
        {
            this.songs = songs;
        }

        public IHttpActionResult Get()
        {
            var result = this.songs.All().ProjectTo<SongModel>();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = this.songs.All().Where(s => s.Id == id).ProjectTo<SongModel>().First();

            return this.Ok(result);
        }

        public IHttpActionResult Post([FromBody] SongModel song)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                var result = Mapper.Map<Song>(song);

                this.songs.Add(result);
                this.songs.SaveChanges();

                return this.Created(this.Url.ToString(), result);
            }
        }

        public IHttpActionResult Put([FromBody] SongModel song)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                var result = this.songs.All()
                    .Where(s => s.Title == song.Title).FirstOrDefault();

                if (result == null)
                {
                    return this.NotFound();
                }
                else
                {
                    result.Year = song.Year;

                    this.songs.Add(result);
                    this.songs.SaveChanges();

                    return this.Ok(result);
                }
            }
        }

        public IHttpActionResult Delete(int id)
        {
            var song = this.songs.All().Where(s => s.Id == id).FirstOrDefault();

            if (song == null)
            {
                return this.NotFound();
            }
            else
            {
                this.songs.Delete(song);
                this.songs.SaveChanges();

                return this.Ok(song);
            }
        }
    }
}
