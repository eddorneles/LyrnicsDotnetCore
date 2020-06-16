using System.Collections.Generic;

using LyrnicsDotnetCore.Model;

namespace LyrnicsDotnetCore.Repository {
    public interface IArtistRepository {
        
        public IList<Artist> FindAll();
        public Artist FindById( int id );
        public Artist Create( Artist band );
        public Artist Update( Artist band );
        public bool Delete( int id );
    }//END interface

}//END namespace