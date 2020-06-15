using System.Collections.Generic;

using LyrnicsDotnetCore.Model;

namespace LyrnicsDotnetCore.Repository {
    public interface IBandRepository {
        
        public IList<Song> FindAll();
        public Song FindById( int id );
        public Song Create( Song band );
        public Song Update( Song band );
        public bool Delete( int id );
    }//END interface

}//END namespace