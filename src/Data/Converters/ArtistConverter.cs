using System.Collections.Generic;
using System.Linq;

using LyrnicsDotnetCore.Model;
using LyrnicsDotnetCore.Data.Dto;

namespace LyrnicsDotnetCore.Data.Converters{

    public class ArtistConverter : IParser<ArtistDto, Artist>, IParser<Artist, ArtistDto> {

        public ArtistDto Parse(Artist origin) {
            if( origin == null ) return new ArtistDto();
            return new ArtistDto {
                Id = origin.Id,
                Code = origin.Code,
                Name = origin.Name
            };
        }

        public List<ArtistDto> ParseList(List<Artist> origin)
        {
            if( origin == null ) return new List<ArtistDto>();
            return origin.Select( elem => this.Parse( elem ) ).ToList();
        }

        public Artist Parse(ArtistDto origin) {
            if( origin == null ) return new Artist();
            return new Artist {
                Id = origin.Id,
                Code = origin.Code,
                Name = origin.Name
            };
        }

        public List<Artist> ParseList(List<ArtistDto> origin)
        {
            if( origin == null ) return new List<Artist>();
            return origin.Select( item => this.Parse( item ) ).ToList();
        }
    }//END interface
}


