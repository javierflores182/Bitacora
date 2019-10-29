using bitacora.API.Models;
using Microsoft.EntityFrameworkCore;

namespace bitacora.API.Data
{
   public class BitacoraMap : IEntityTypeConfiguration<Bitacora>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Bitacora> builder)
        {
            builder.ToTable("Bitacora", "dbo");
            builder.HasKey(q => q.bitacoraId);
            builder.Property(e => e.bitacoraId).IsRequired();
            builder.Property(e => e.bitacoraFecha).HasColumnType("DateTime").IsRequired();
            builder.Property(e => e.bitacoraHoraInicio).HasColumnType("DateTime").IsRequired();
            builder.Property(e => e.bitacoraHoraFinal).HasColumnType("DateTime").IsRequired();
            builder.HasOne(e => e.Category).WithMany(e => e.Bitacoras).HasForeignKey(e => e.category_Id);
        }
    }
}