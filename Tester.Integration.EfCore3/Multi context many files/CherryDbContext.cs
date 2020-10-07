// <auto-generated>

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tester.Integration.EfCore3.Multi_context_many_filesCherry
{
    public class CherryDbContext : DbContext, ICherryDbContext
    {
        private readonly IConfiguration _configuration;

        public CherryDbContext()
        {
        }

        public CherryDbContext(DbContextOptions<CherryDbContext> options)
            : base(options)
        {
        }

        public CherryDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<ColumnName> ColumnNames { get; set; } // ColumnNames

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured && _configuration != null)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString(@"McmfMultiDatabase"));
            }
        }

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

            modelBuilder.ApplyConfiguration(new ColumnNameConfiguration());
        }

    }
}
// </auto-generated>
