using System.Collections.Generic;

using LyrnicsDotnetCore.Model;

namespace LyrnicsDotnetCore.Business {
    public interface IArtistBusiness {
        public IList<Artist> FindAll();
        public Artist FindById( int id );
        public Artist Create( Artist artist );
        public Artist Update( Artist artist );
        public bool Delete( int id );
    }//END interface
}//END namespace