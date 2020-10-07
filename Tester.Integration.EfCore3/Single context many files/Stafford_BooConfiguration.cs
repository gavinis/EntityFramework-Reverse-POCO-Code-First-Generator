// <auto-generated>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tester.Integration.EfCore3.Single_context_many_files
{
    // Boo
    public class Stafford_BooConfiguration : IEntityTypeConfiguration<Stafford_Boo>
    {
        public void Configure(EntityTypeBuilder<Stafford_Boo> builder)
        {
            builder.ToTable("Boo", "Stafford");
            builder.HasKey(x => x.Id).HasName("PK_Boo").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName(@"name").HasColumnType("nchar(10)").IsRequired().IsFixedLength().HasMaxLength(10);
        }
    }

}
// </auto-generated>
