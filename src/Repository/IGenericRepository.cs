using System.Collections.Generic;

using LyrnicsDotnetCore.Model;

namespace LyrnicsDotnetCore.Repository {
    public interface IGenericRepository<T> where T : BaseEntity {
        
        public IList<T> FindAll();
        public T FindById( int id );
        public T Create( T item );
        public T Update( T item );
        public bool Delete( int id );
        public bool Exists( int id );
    }//END interface

}//END namespace