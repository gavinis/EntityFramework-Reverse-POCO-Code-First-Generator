// <auto-generated>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace V5EfrpgTest
{
    // Person
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Person").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
        }
    }

}
// </auto-generated>
