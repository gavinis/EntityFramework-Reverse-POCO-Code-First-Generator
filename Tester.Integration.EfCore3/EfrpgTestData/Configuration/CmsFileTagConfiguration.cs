// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tester.Integration.EfCore3
{
    // CMS_FileTag
    public class CmsFileTagConfiguration : IEntityTypeConfiguration<CmsFileTag>
    {
        public void Configure(EntityTypeBuilder<CmsFileTag> builder)
        {
            builder.ToTable("CMS_FileTag", "dbo");
            builder.HasKey(x => new { x.FileId, x.TagId });

            builder.Property(x => x.FileId).HasColumnName(@"FileId").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.TagId).HasColumnName(@"TagId").HasColumnType("int").IsRequired().ValueGeneratedNever();

            // Foreign keys
            builder.HasOne(a => a.CmsFile).WithMany(b => b.CmsFileTags).HasForeignKey(c => c.FileId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CMS_FileTag_CMS_File");
            builder.HasOne(a => a.CmsTag).WithMany(b => b.CmsFileTags).HasForeignKey(c => c.TagId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CMS_FileTag_CMS_Tag");
        }
    }

}
// </auto-generated>