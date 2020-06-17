using System.Collections.Generic;

using LyrnicsDotnetCore.Data.Dto;

namespace LyrnicsDotnetCore.Business {
    public interface ISongBusiness {
        public List<SongDto> FindAll();
        public SongDto FindById( int id );
        public SongDto Create( SongDto song );
        public SongDto Update( SongDto song );
        public bool Delete( int id );
    }//END interface
}//END namespace