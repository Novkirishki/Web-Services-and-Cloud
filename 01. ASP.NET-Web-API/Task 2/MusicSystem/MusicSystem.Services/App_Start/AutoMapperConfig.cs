namespace MusicSystem.Services.App_Start
{
    using MusicSystem.Models;
    using MusicSystem.Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<Album, AlbumModel>().ReverseMap();

            AutoMapper.Mapper.CreateMap<Artist, ArtistModel>()
                .ForMember(dest => dest.Country,
                           opts => opts.MapFrom(src => src.CountryName))
                .ReverseMap();

            AutoMapper.Mapper.CreateMap<Song, SongModel>().ReverseMap();
        }
    }
}