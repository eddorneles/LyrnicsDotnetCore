using System.Collections.Generic;

using LyrnicsDotnetCore.Model;

namespace LyrnicsDotnetCore.Business {
    public interface ISongBusiness {
        public IList<Song> FindAll();
        public Song FindById( int id );
        public Song Create( Song song );
        public Song Update( Song song );
        public bool Delete( int id );
    }//END interface
}//END namespace