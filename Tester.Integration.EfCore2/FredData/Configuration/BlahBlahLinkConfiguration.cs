// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tester.Integration.EfCore2
{
    // BlahBlahLink
    public class BlahBlahLinkConfiguration : IEntityTypeConfiguration<BlahBlahLink>
    {
        public void Configure(EntityTypeBuilder<BlahBlahLink> builder)
        {
            builder.ToTable("BlahBlahLink", "dbo");
            builder.HasKey(x => new { x.BlahId, x.BlahId2 }).HasName("PK_BlahBlahLink").ForSqlServerIsClustered();

            builder.Property(x => x.BlahId).HasColumnName(@"BlahID").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.BlahId2).HasColumnName(@"BlahID2").HasColumnType("int").IsRequired().ValueGeneratedNever();

            // Foreign keys
            builder.HasOne(a => a.Blah_BlahId).WithMany(b => b.BlahBlahLinks_BlahId).HasForeignKey(c => c.BlahId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_BlahBlahLink_Blah");
            builder.HasOne(a => a.Blah_BlahId2).WithMany(b => b.BlahBlahLinks_BlahId2).HasForeignKey(c => c.BlahId2).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_BlahBlahLink_Blah2");
        }
    }

}
// </auto-generated>