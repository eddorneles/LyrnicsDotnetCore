using System.Collections.Generic;

using LyrnicsDotnetCore.Data.Dto;

namespace LyrnicsDotnetCore.Business {
    public interface IArtistBusiness {
        public List<ArtistDto> FindAll();
        public ArtistDto FindById( int id );
        public ArtistDto Create( ArtistDto artist );
        public ArtistDto Update( ArtistDto artist );
        public bool Delete( int id );
    }//END interface
}//END namespace