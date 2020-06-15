using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LyrnicsDotnetCore.Model.Context {
    public class SongConfiguration : IEntityTypeConfiguration<Song> {

        private const int DEFAULT_MAX_LENGTH = 35;
        //All names are set to the postgresql naming convention (singular without capital letters)
        public void Configure( EntityTypeBuilder<Song> builder ) {
            builder.ToTable( "song" );
            builder.HasKey( song => song.Id ).HasName( "pk_song" );
            builder.Property( song => song.Id ).ValueGeneratedOnAdd()
                    .HasColumnName( "id" );
            builder.Property( song => song.Title ).HasMaxLength( DEFAULT_MAX_LENGTH )
                    .IsRequired().HasColumnName( "title" );
            builder.Property( song => song.Code ).HasMaxLength( DEFAULT_MAX_LENGTH )
                    .IsRequired().HasColumnName( "code" );
            builder.Property( song => song.BandId ).HasColumnName( "band_id" ).IsRequired();
            
        }//END Configure()
    }//END class
} //END namespace