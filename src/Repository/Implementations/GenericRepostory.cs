using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using LyrnicsDotnetCore.Model;
using LyrnicsDotnetCore.Model.Context;

namespace LyrnicsDotnetCore.Repository {
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity {
        
        private readonly LyrnicsDBContext Context;
        private DbSet<T> Dataset;

        public GenericRepository( LyrnicsDBContext context ){
            this.Context = context;
            this.Dataset = context.Set<T>();
        }
        
        public List<T> FindAll(){
            return this.Dataset.ToList();
        }
        public T FindById( int id ){
            return this.Dataset.SingleOrDefault( item => item.Id.Equals( id ) );
        }
        public T Create( T item ){
            this.Context.Add( item );
            this.Context.SaveChanges();
            return item;
        }
        public T Update( T item ){
            T result = this.Dataset.SingleOrDefault( dbElement => dbElement.Id.Equals( item.Id ) );
            if( result == null ) return null;
            try{
                this.Context.Entry( result ).CurrentValues.SetValues( item );
                this.Context.SaveChanges();
                return result;
            }catch( Exception e ){
                throw e;
            }//END try
        }
        public bool Delete( int id ){
            T result = this.Dataset.SingleOrDefault( dbElement => dbElement.Id.Equals( id ) );
            if( result != null ){
                this.Dataset.Remove( result );
                this.Context.SaveChanges();
                return true;
            }//END if
            return false;
        }

        public bool Exists( int id ){
            return this.Dataset.Any( item => item.Id.Equals( id ) );
        }//END Exists
    }//END interface

}//END namespace