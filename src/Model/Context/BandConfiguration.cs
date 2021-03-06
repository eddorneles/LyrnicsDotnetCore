using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LyrnicsDotnetCore.Model.Context {
    public class BandConfiguration : IEntityTypeConfiguration<Band> {
        
        private const int DEFAULT_MAX_LENGTH = 35;
        
        //All names are set to the postgresql naming convention (singular without capital letters)
        public void Configure( EntityTypeBuilder<Band> builder ) {
            builder.ToTable( "band" );
            builder.HasKey( b => b.Id ).HasName( "pk_band" );
            builder.Property( band => band.Id ).ValueGeneratedOnAdd()
                    .HasColumnName( "id" );
            builder.Property( b => b.Name ).HasMaxLength( DEFAULT_MAX_LENGTH )
                    .IsRequired().HasColumnName( "name" );
            builder.Property( b => b.Code ).HasMaxLength( DEFAULT_MAX_LENGTH )
                    .IsRequired().HasColumnName( "code" );
            builder.HasMany( b => b.Songs ).WithOne( s => s.Band )
                    .IsRequired().HasConstraintName( "fk_song_band_band_id" );
        }//END Configure()
    }//END class
} //END namespace