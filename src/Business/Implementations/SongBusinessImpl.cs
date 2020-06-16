using System;
using System.Linq;
using System.Collections.Generic;

using LyrnicsDotnetCore.Model;
using LyrnicsDotnetCore.Repository;



namespace LyrnicsDotnetCore.Business.Implementations {
    public class SongBusinessImpl : ISongBusiness
    {
        ISongRepository SongRepository;
        public SongBusinessImpl( ISongRepository songRepository ){
            this.SongRepository = songRepository;
        }

        public Song Create(Song song)
        {
            return this.SongRepository.Create( song );
        }

        public bool Delete(int id)
        {
            return this.SongRepository.Delete( id );
        }

        public IList<Song> FindAll()
        {
            return this.FindAll();
        }

        public Song FindById(int id)
        {
            return this.FindById( id );
        }

        public Song Update( Song song )
        {
            return this.Update( song );
        }
    }//END interface
}//END namespace