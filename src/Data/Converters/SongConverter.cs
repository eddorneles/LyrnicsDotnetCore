using System.Collections.Generic;
using System.Linq;

using LyrnicsDotnetCore.Model;
using LyrnicsDotnetCore.Data.Dto;

namespace LyrnicsDotnetCore.Data.Converters{

    public class SongConverter : IParser<SongDto, Song>, IParser<Song, SongDto> {

        public SongDto Parse(Song origin) {
            if( origin == null ) return new SongDto();
            return new SongDto{
                ArtistId = origin.ArtistId,
                Code = origin.Code,
                Title = origin.Title
            };
        }

        public List<SongDto> ParseList(List<Song> origin)
        {
            if( origin == null ) return new List<SongDto>();
            return origin.Select( elem => this.Parse( elem ) ).ToList();
        }

        public Song Parse(SongDto origin) {
            if( origin == null ) return new Song();
            return new Song {
                Id = origin.Id,
                ArtistId = origin.ArtistId,
                Code = origin.Code,
                Title = origin.Title
            };
        }

        public List<Song> ParseList(List<SongDto> origin)
        {
            if( origin == null ) return new List<Song>();
            return origin.Select( item => this.Parse( item ) ).ToList();
        }
    }//END interface
}


