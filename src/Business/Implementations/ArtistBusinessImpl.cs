using System.Collections.Generic;

using LyrnicsDotnetCore.Business;
using LyrnicsDotnetCore.Model;
using LyrnicsDotnetCore.Repository;
using LyrnicsDotnetCore.Data.Dto;
using LyrnicsDotnetCore.Data.Converters;

namespace LyrnicsDotnetCore.Business.Implementations {
    public class ArtistBusinessImpl : IArtistBusiness {
        private readonly IGenericRepository<Artist> Repository;
        private readonly ArtistConverter Converter;

        public ArtistBusinessImpl( IGenericRepository<Artist> repository ){
            this.Repository = repository;
            this.Converter = new ArtistConverter();
        }//END constructor

        public ArtistDto Create(ArtistDto artist ) {
            Artist artistEntity = this.Converter.Parse( artist );
            Artist artistPersisted = this.Repository.Create( artistEntity );
            return this.Converter.Parse( artistPersisted );
        }//END Create()

        public bool Delete(int id)
        {
            return this.Repository.Delete( id );
        }

        public List<ArtistDto> FindAll() {
            return this.Converter.ParseList( this.Repository.FindAll() );
        }

        public ArtistDto FindById( int id )
        {
            return this.Converter.Parse( this.Repository.FindById( id ) );
        }

        public ArtistDto Update(ArtistDto artist) {
            Artist artistEntity = this.Converter.Parse( artist );
            Artist updatedArtist = this.Repository.Update( artistEntity );
            return this.Converter.Parse( updatedArtist );
        }//END Update()

    }//END class
}//END namespace