using System;
using System.Linq;
using System.Collections.Generic;
using LyrnicsDotnetCore.Model;
using LyrnicsDotnetCore.Model.Context;

namespace LyrnicsDotnetCore.Repository.Implementations{
    public class SongRepositoryImpl : ISongRepository {
        
        LyrnicsDBContext Context;
        public SongRepositoryImpl( LyrnicsDBContext context ) {
            this.Context = context;
        }//END constructor
        
        public IList<Song> FindAll() {
            return this.Context.Songs.ToList();
        }//END FindAll()

        public Song FindById( int id ){
            return this.Context.Songs.SingleOrDefault( b => b.Id.Equals( id) );
        }
        public Song Create( Song song ){
            this.Context.Add( song );
            this.Context.SaveChanges();
            return song;
        }//END Create()
        public Song Update( Song song ){
            
            Song result = this.Context.Songs.SingleOrDefault( b => b.Id.Equals( song.Id ) );
            if( result == null ) return null;
            try{
                this.Context.Entry( result ).CurrentValues.SetValues( song );
                this.Context.SaveChanges();
                return result;
            }catch( Exception e ){
                throw e;
            }//END try
        }//END Update()

        public bool Delete( int id ){
            Song result = this.Context.Songs.SingleOrDefault( b => b.Id.Equals( id ) );
            if( result != null ) {
                this.Context.Remove( result );
                this.Context.SaveChanges();
                return true;
            }//END if
            return false;
        }//END Delete()

        private bool Exists( Song band ){
            return this.Context.Songs.Any( b => b.Id.Equals( band.Id ) );
        }//END Exists()
    }//END class

}//END namespace