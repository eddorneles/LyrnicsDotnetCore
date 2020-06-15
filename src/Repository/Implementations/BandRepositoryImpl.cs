using System;
using System.Linq;
using System.Collections.Generic;
using LyrnicsDotnetCore.Model;
using LyrnicsDotnetCore.Model.Context;

namespace LyrnicsDotnetCore.Repository.Implementations{
    public class BandRepositoryImpl : IBandRepository {
        
        LyrnicsDBContext Context;
        public BandRepositoryImpl( LyrnicsDBContext context ) {
            this.Context = context;
        }//END constructor
        
        public IList<Song> FindAll() {
            return this.Context.Bands.ToList();
        }//END FindAll()

        public Song FindById( int id ){
            return this.Context.Bands.SingleOrDefault( b => b.Id.Equals( id) );
            //return this.Context.Bands.Find(id);
        }
        public Song Create( Song band ){
            this.Context.Add( band );
            this.Context.SaveChanges();
            return band;
        }//END Create()
        public Song Update( Song band ){
            
            Song result = this.Context.Bands.SingleOrDefault( b => b.Id.Equals( band.Id ) );
            if( result == null ) return null;
            try{
                this.Context.Entry( result ).CurrentValues.SetValues( band );
                this.Context.SaveChanges();
                return result;
            }catch( Exception e ){
                throw e;
            }//END try

        }//END Update()

        public bool Delete( int id ){
            Song result = this.Context.Bands.SingleOrDefault( b => b.Id.Equals( id ) );
            if( result != null ) {
                this.Context.Remove( result );
                this.Context.SaveChanges();
                return true;
            }//END if
            return false;
        }//END Delete()

        private bool Exists( Song band ){
            return this.Context.Bands.Any( b => b.Id.Equals( band.Id ) );
        }//END Exists()
        
    }//END class

}//END namespace