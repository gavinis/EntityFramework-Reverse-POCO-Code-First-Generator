// <auto-generated>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace V6EfrpgTest
{
    // OpenDays
    public class EnumTest_OpenDayConfiguration : IEntityTypeConfiguration<EnumTest_OpenDay>
    {
        public void Configure(EntityTypeBuilder<EnumTest_OpenDay> builder)
        {
            builder.ToTable("OpenDays", "EnumTest");
            builder.HasKey(x => x.Id).HasName("PK_OpenDays").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.EnumId).HasColumnName(@"EnumId").HasColumnType("int").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.EnumTest_DaysOfWeek).WithMany(b => b.EnumTest_OpenDays).HasForeignKey(c => c.EnumId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Fk_OpenDays_EnumId");
        }
    }

}
// </auto-generated>