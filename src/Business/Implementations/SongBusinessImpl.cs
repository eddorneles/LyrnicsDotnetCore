using System;
using System.Linq;
using System.Collections.Generic;

using LyrnicsDotnetCore.Model;
using LyrnicsDotnetCore.Data.Dto;
using LyrnicsDotnetCore.Data.Converters;
using LyrnicsDotnetCore.Repository;

namespace LyrnicsDotnetCore.Business.Implementations {
    public class SongBusinessImpl : ISongBusiness
    {
        IGenericRepository<Song> Repository;
        SongConverter Converter;
        public SongBusinessImpl( IGenericRepository<Song> repository ){
            this.Repository = repository;
            this.Converter = new SongConverter();
        }//END constructor

        public SongDto Create( SongDto song ) {
            Song songEntity = this.Converter.Parse( song );
            Song persistedSong = this.Repository.Create( songEntity );
            return this.Converter.Parse( persistedSong );
        }

        public bool Delete(int id) {
            return this.Repository.Delete( id );
        }

        public List<SongDto> FindAll()
        {
            return this.Converter.ParseList( this.Repository.FindAll() );
        }

        public SongDto FindById(int id) {
            return this.Converter.Parse( this.Repository.FindById( id ) );
        }

        public SongDto Update( SongDto song ) {
            Song songEntity = this.Converter.Parse( song );

            Song updatedSong = this.Repository.Update( songEntity );
            return this.Converter.Parse( updatedSong );
        }
    }//END interface
}//END namespace