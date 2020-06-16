using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LyrnicsDotnetCore.Model.Context {
    public class LyrnicsDBContext : DbContext {
        public LyrnicsDBContext(){ 
        }

        public LyrnicsDBContext( DbContextOptions<LyrnicsDBContext> options ) : 
                base( options ) {
        }// END constructor

        #region Required
        protected override void OnModelCreating( ModelBuilder modelBuilder ){
            modelBuilder.ApplyConfiguration( new SongConfiguration() );
            modelBuilder.ApplyConfiguration( new ArtistConfiguration() );

        }//END OnModelCreating
        #endregion

        public DbSet<Song> Songs{get;set;}
        public DbSet<Artist> Artists{get;set;}
    }////END class


}//END namespace