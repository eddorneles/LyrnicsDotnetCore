using System.Collections.Generic;

using LyrnicsDotnetCore.Model;

namespace LyrnicsDotnetCore.Business {
    public interface IBandBusiness {
        public IList<Band> FindAll();
        public Band FindById( int id );
        public Band Create( Band band );
        public Band Update( Band band );
        public bool Delete( int id );
    }//END interface
}//END namespace