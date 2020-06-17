using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LyrnicsDotnetCore.Model.Context {
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist> {
        
        private const int DEFAULT_MAX_LENGTH = 35;
        
        //All names are set to the postgresql naming convention (singular without capital letters)
        public void Configure( EntityTypeBuilder<Artist> builder ) {
            builder.ToTable( "artist" );
            builder.HasKey( b => b.Id ).HasName( "pk_artist" );
            builder.Property( artist => artist.Id ).ValueGeneratedOnAdd()
                    .HasColumnName( "id" );
            builder.Property( b => b.Name ).HasMaxLength( DEFAULT_MAX_LENGTH )
                    .IsRequired().HasColumnName( "name" );
            builder.Property( b => b.Code ).HasMaxLength( DEFAULT_MAX_LENGTH )
                    .IsRequired().HasColumnName( "code" );
            builder.HasMany( b => b.Songs ).WithOne( s => s.Artist )
                    .IsRequired().HasConstraintName( "fk_artist_song_artist_id" );
        }//END Configure()
    }//END class
} //END namespace