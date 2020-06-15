using System.Collections.Generic;
using System.Linq;
using System;
using LyrnicsDotnetCore.Model;
using LyrnicsDotnetCore.Model.Context;

namespace LyrnicsDotnetCore.Repository.Implementations{
    public class BandRepository : IBandRepository {
        
        LyrnicsDBContext Context;
        public BandRepository( LyrnicsDBContext context ) {
            this.Context = context;
        }
        
        public IList<Band> FindAll() {
            return this.Context.Bands.ToList();
        }//END FindAll()

        public Band FindById( int id ){
            return this.Context.Bands.SingleOrDefault( b => b.Id.Equals( id) );
            //return this.Context.Bands.Find(id);
        }
        public Band Create( Band band ){
            this.Context.Add( band );
            this.Context.SaveChanges();
            return band;
        }
        public Band Update( Band band ){
            throw new NotImplementedException();
        }
        public bool Delete( int id ){
            throw new NotImplementedException();
        }
        
    }//END interface

}//END namespace