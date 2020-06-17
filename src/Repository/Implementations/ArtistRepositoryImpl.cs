using System;
using System.Linq;
using System.Collections.Generic;
using LyrnicsDotnetCore.Model;
using LyrnicsDotnetCore.Model.Context;

namespace LyrnicsDotnetCore.Repository.Implementations{
    public class ArtistRepositoryImpl : IArtistRepository {
        
        private LyrnicsDBContext Context;
        public ArtistRepositoryImpl( LyrnicsDBContext context ) {
            this.Context = context;
        }//END constructor
        
        public List<Artist> FindAll() {
            return this.Context.Artists.ToList();
        }//END FindAll()

        public Artist FindById( int id ){
            return this.Context.Artists.SingleOrDefault( b => b.Id.Equals( id) );
            //return this.Context.Artists.Find(id);
        }
        public Artist Create( Artist artist ){
            this.Context.Add( artist );
            this.Context.SaveChanges();
            return artist;
        }//END Create()
        public Artist Update( Artist artist ){
            
            Artist result = this.Context.Artists.SingleOrDefault( b => b.Id.Equals( artist.Id ) );
            if( result == null ) return null;
            try{
                this.Context.Entry( result ).CurrentValues.SetValues( artist );
                this.Context.SaveChanges();
                return result;
            }catch( Exception e ){
                throw e;
            }//END try

        }//END Update()

        public bool Delete( int id ){
            Artist result = this.Context.Artists.SingleOrDefault( b => b.Id.Equals( id ) );
            if( result != null ) {
                this.Context.Remove( result );
                this.Context.SaveChanges();
                return true;
            }//END if
            return false;
        }//END Delete()

        private bool Exists( Artist artist ){
            return this.Context.Artists.Any( b => b.Id.Equals( artist.Id ) );
        }//END Exists()
        
    }//END class

}//END namespace