// <auto-generated>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace V5EfrpgTest
{
    // ThisIsMemoryOptimised
    public class ThisIsMemoryOptimisedConfiguration : IEntityTypeConfiguration<ThisIsMemoryOptimised>
    {
        public void Configure(EntityTypeBuilder<ThisIsMemoryOptimised> builder)
        {
            builder.ToTable("ThisIsMemoryOptimised", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ThisIsMemoryOptimised");

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("varchar(20)").IsRequired().IsUnicode(false).HasMaxLength(20);
        }
    }

}
// </auto-generated>
