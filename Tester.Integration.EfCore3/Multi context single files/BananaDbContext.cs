// <auto-generated>

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tester.Integration.EfCore3.Multi_context_single_filesBananaDbContext
{
    #region Database context interface

    public interface IBananaDbContext : IDisposable
    {
        DbSet<Stafford_ComputedColumn> Stafford_ComputedColumns { get; set; } // ComputedColumns

        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));
        DatabaseFacade Database { get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string ToString();
    }

    #endregion

    #region Database context

    public class BananaDbContext : DbContext, IBananaDbContext
    {
        public BananaDbContext()
        {
        }

        public BananaDbContext(DbContextOptions<BananaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Stafford_ComputedColumn> Stafford_ComputedColumns { get; set; } // ComputedColumns

        public bool IsSqlParameterNull(SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == DBNull.Value);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new Stafford_ComputedColumnConfiguration());
        }

    }

    #endregion

    #region Database context factory

    public class BananaDbContextFactory : IDesignTimeDbContextFactory<BananaDbContext>
    {
        public BananaDbContext CreateDbContext(string[] args)
        {
            return new BananaDbContext();
        }
    }

    #endregion

    #region POCO classes

    // ComputedColumns
    public class Stafford_ComputedColumn
    {
        public int id { get; set; } // Id (Primary key)
        public string MyColumn { get; set; } // MyColumn (length: 10)
    }


    #endregion

    #region POCO Configuration

    // ComputedColumns
    public class Stafford_ComputedColumnConfiguration : IEntityTypeConfiguration<Stafford_ComputedColumn>
    {
        public void Configure(EntityTypeBuilder<Stafford_ComputedColumn> builder)
        {
            builder.ToTable("ComputedColumns", "Stafford");
            builder.HasKey(x => x.id).HasName("PK_Stafford_ComputedColumns").IsClustered();

            builder.Property(x => x.id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.MyColumn).HasColumnName(@"MyColumn").HasColumnType("varchar(10)").IsRequired().IsUnicode(false).HasMaxLength(10);
        }
    }


    #endregion

}
// </auto-generated>
