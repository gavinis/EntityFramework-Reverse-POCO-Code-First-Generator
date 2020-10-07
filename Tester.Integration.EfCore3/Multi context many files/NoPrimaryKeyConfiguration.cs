// <auto-generated>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tester.Integration.EfCore3.Multi_context_many_filesPlum
{
    // NoPrimaryKeys
    public class NoPrimaryKeyConfiguration : IEntityTypeConfiguration<NoPrimaryKey>
    {
        public void Configure(EntityTypeBuilder<NoPrimaryKey> builder)
        {
            builder.ToTable("NoPrimaryKeys", "dbo");
            builder.HasKey(x => x.Description);

            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("varchar(10)").IsRequired(false).IsUnicode(false).HasMaxLength(10).ValueGeneratedNever();
        }
    }

}
// </auto-generated>
