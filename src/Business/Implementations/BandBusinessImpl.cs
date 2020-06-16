using System.Collections.Generic;

using LyrnicsDotnetCore.Business;
using LyrnicsDotnetCore.Model;
using LyrnicsDotnetCore.Repository;

namespace LyrnicsDotnetCore.Business.Implementations {
    public class BandBusinessImpl : IBandBusiness {
        private readonly IBandRepository BandRepository;

        public BandBusinessImpl( IBandRepository bandRepository ){
            //this.bandBusiness = bandBusiness;
            this.BandRepository = bandRepository;
        }//END constructor

        public Band Create(Band band) {
            return this.BandRepository.Create( band );
        }

        public bool Delete(int id)
        {
            return this.BandRepository.Delete( id );
        }

        public IList<Band> FindAll()
        {
            return this.BandRepository.FindAll();
        }

        public Band FindById(int id)
        {
            return this.BandRepository.FindById( id );
        }

        public Band Update(Band band)
        {
            return this.BandRepository.Update( band );
        }
    }//END interface
}//END namespace