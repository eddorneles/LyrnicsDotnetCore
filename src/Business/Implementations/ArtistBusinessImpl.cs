using System.Collections.Generic;

using LyrnicsDotnetCore.Business;
using LyrnicsDotnetCore.Model;
using LyrnicsDotnetCore.Repository;

namespace LyrnicsDotnetCore.Business.Implementations {
    public class ArtistBusinessImpl : IArtistBusiness {
        private readonly IGenericRepository<Artist> Repository;

        public ArtistBusinessImpl( IGenericRepository<Artist> repository ){
            this.Repository = repository;
        }//END constructor

        public Artist Create(Artist band) {
            return this.Repository.Create( band );
        }

        public bool Delete(int id)
        {
            return this.Repository.Delete( id );
        }

        public IList<Artist> FindAll()
        {
            return this.Repository.FindAll();
        }

        public Artist FindById(int id)
        {
            return this.Repository.FindById( id );
        }

        public Artist Update(Artist band)
        {
            return this.Repository.Update( band );
        }
    }//END interface
}//END namespace