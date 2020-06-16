using System.Collections.Generic;

using LyrnicsDotnetCore.Business;
using LyrnicsDotnetCore.Model;
using LyrnicsDotnetCore.Repository;

namespace LyrnicsDotnetCore.Business.Implementations {
    public class ArtistBusinessImpl : IArtistBusiness {
        private readonly IArtistRepository ArtistRepository;

        public ArtistBusinessImpl( IArtistRepository bandRepository ){
            //this.bandBusiness = bandBusiness;
            this.ArtistRepository = bandRepository;
        }//END constructor

        public Artist Create(Artist band) {
            return this.ArtistRepository.Create( band );
        }

        public bool Delete(int id)
        {
            return this.ArtistRepository.Delete( id );
        }

        public IList<Artist> FindAll()
        {
            return this.ArtistRepository.FindAll();
        }

        public Artist FindById(int id)
        {
            return this.ArtistRepository.FindById( id );
        }

        public Artist Update(Artist band)
        {
            return this.ArtistRepository.Update( band );
        }
    }//END interface
}//END namespace