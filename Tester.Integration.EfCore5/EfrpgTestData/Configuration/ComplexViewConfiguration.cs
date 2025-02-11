// <auto-generated>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace V5EfrpgTest
{
    // ComplexView
    public class ComplexViewConfiguration : IEntityTypeConfiguration<ComplexView>
    {
        public void Configure(EntityTypeBuilder<ComplexView> builder)
        {
            builder.ToView("ComplexView", "dbo");
            builder.HasNoKey();

            builder.Property(x => x.LicenseType).HasColumnName(@"LicenseType").HasColumnType("nvarchar(128)").IsRequired().HasMaxLength(128);
            builder.Property(x => x.Count).HasColumnName(@"Count").HasColumnType("int").IsRequired(false);
        }
    }

}
// </auto-generated>
