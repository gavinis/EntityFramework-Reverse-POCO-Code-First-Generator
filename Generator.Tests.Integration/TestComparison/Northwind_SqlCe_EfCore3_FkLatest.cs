// <auto-generated>

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Efrpg.SqlCE
{
    #region Database context interface

    public interface IMyDbContext : IDisposable
    {
        DbSet<Category> Categories { get; set; } // Categories
        DbSet<Customer> Customers { get; set; } // Customers
        DbSet<Employee> Employees { get; set; } // Employees
        DbSet<Order> Orders { get; set; } // Orders
        DbSet<OrderDetail> OrderDetails { get; set; } // Order Details
        DbSet<Product> Products { get; set; } // Products
        DbSet<Shipper> Shippers { get; set; } // Shippers
        DbSet<Supplier> Suppliers { get; set; } // Suppliers

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

    public class MyDbContext : DbContext, IMyDbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } // Categories
        public DbSet<Customer> Customers { get; set; } // Customers
        public DbSet<Employee> Employees { get; set; } // Employees
        public DbSet<Order> Orders { get; set; } // Orders
        public DbSet<OrderDetail> OrderDetails { get; set; } // Order Details
        public DbSet<Product> Products { get; set; } // Products
        public DbSet<Shipper> Shippers { get; set; } // Shippers
        public DbSet<Supplier> Suppliers { get; set; } // Suppliers

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=C:\S\Source (open source)\EntityFramework Reverse POCO Code Generator\EntityFramework.Reverse.POCO.Generator\App_Data\NorthwindSqlCe40.sdf");
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

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ShipperConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
        }

    }

    #endregion

    #region Database context factory

    public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            return new MyDbContext();
        }
    }

    #endregion

    #region Fake Database context

    public class FakeMyDbContext : IMyDbContext
    {
        public DbSet<Category> Categories { get; set; } // Categories
        public DbSet<Customer> Customers { get; set; } // Customers
        public DbSet<Employee> Employees { get; set; } // Employees
        public DbSet<Order> Orders { get; set; } // Orders
        public DbSet<OrderDetail> OrderDetails { get; set; } // Order Details
        public DbSet<Product> Products { get; set; } // Products
        public DbSet<Shipper> Shippers { get; set; } // Shippers
        public DbSet<Supplier> Suppliers { get; set; } // Suppliers

        public FakeMyDbContext()
        {
            _database = null;

            Categories = new FakeDbSet<Category>("CategoryId");
            Customers = new FakeDbSet<Customer>("CustomerId");
            Employees = new FakeDbSet<Employee>("EmployeeId");
            Orders = new FakeDbSet<Order>("OrderId");
            OrderDetails = new FakeDbSet<OrderDetail>("OrderId", "ProductId");
            Products = new FakeDbSet<Product>("ProductId");
            Shippers = new FakeDbSet<Shipper>("ShipperId");
            Suppliers = new FakeDbSet<Supplier>("SupplierId");

        }

        public int SaveChangesCount { get; private set; }
        public virtual int SaveChanges()
        {
            ++SaveChangesCount;
            return 1;
        }

        public virtual int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return SaveChanges();
        }

        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            ++SaveChangesCount;
            return Task<int>.Factory.StartNew(() => 1, cancellationToken);
        }
        public virtual Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken)
        {
            ++SaveChangesCount;
            return Task<int>.Factory.StartNew(x => 1, acceptAllChangesOnSuccess, cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private DatabaseFacade _database;
        public DatabaseFacade Database { get { return _database; } }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }

    #endregion

    #region Fake DbSet

    // ************************************************************************
    // Fake DbSet
    // Implementing Find:
    //      The Find method is difficult to implement in a generic fashion. If
    //      you need to test code that makes use of the Find method it is
    //      easiest to create a test DbSet for each of the entity types that
    //      need to support find. You can then write logic to find that
    //      particular type of entity, as shown below:
    //      public class FakeBlogDbSet : FakeDbSet<Blog>
    //      {
    //          public override Blog Find(params object[] keyValues)
    //          {
    //              var id = (int) keyValues.Single();
    //              return this.SingleOrDefault(b => b.BlogId == id);
    //          }
    //      }
    //      Read more about it here: https://msdn.microsoft.com/en-us/data/dn314431.aspx
    public class FakeDbSet<TEntity> : DbSet<TEntity>, IQueryable<TEntity>, IAsyncEnumerable<TEntity>, IListSource where TEntity : class
    {
        private readonly PropertyInfo[] _primaryKeys;
        private readonly ObservableCollection<TEntity> _data;
        private readonly IQueryable _query;

        public FakeDbSet()
        {
            _primaryKeys = null;
            _data        = new ObservableCollection<TEntity>();
            _query       = _data.AsQueryable();
        }

        public FakeDbSet(params string[] primaryKeys)
        {
            _primaryKeys = typeof(TEntity).GetProperties().Where(x => primaryKeys.Contains(x.Name)).ToArray();
            _data        = new ObservableCollection<TEntity>();
            _query       = _data.AsQueryable();
        }

        public override TEntity Find(params object[] keyValues)
        {
            if (_primaryKeys == null)
                throw new ArgumentException("No primary keys defined");
            if (keyValues.Length != _primaryKeys.Length)
                throw new ArgumentException("Incorrect number of keys passed to Find method");

            var keyQuery = this.AsQueryable();
            keyQuery = keyValues
                .Select((t, i) => i)
                .Aggregate(keyQuery,
                    (current, x) =>
                        current.Where(entity => _primaryKeys[x].GetValue(entity, null).Equals(keyValues[x])));

            return keyQuery.SingleOrDefault();
        }

        public override ValueTask<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            return new ValueTask<TEntity>(Task<TEntity>.Factory.StartNew(() => Find(keyValues), cancellationToken));
        }

        public override ValueTask<TEntity> FindAsync(params object[] keyValues)
        {
            return new ValueTask<TEntity>(Task<TEntity>.Factory.StartNew(() => Find(keyValues)));
        }

        IAsyncEnumerator<TEntity> IAsyncEnumerable<TEntity>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAsyncEnumerator(cancellationToken);
        }

        public override EntityEntry<TEntity> Add(TEntity entity)
        {
            _data.Add(entity);
            return null;
        }

        public override void AddRange(params TEntity[] entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            foreach (var entity in entities.ToList())
                _data.Add(entity);
        }

        public override void AddRange(IEnumerable<TEntity> entities)
        {
            AddRange(entities.ToArray());
        }

        public override Task AddRangeAsync(params TEntity[] entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            return Task.Factory.StartNew(() => AddRange(entities), cancellationToken);
        }

        public override void AttachRange(params TEntity[] entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            AddRange(entities);
        }

        public override void RemoveRange(params TEntity[] entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            foreach (var entity in entities.ToList())
                _data.Remove(entity);
        }

        public override void RemoveRange(IEnumerable<TEntity> entities)
        {
            RemoveRange(entities.ToArray());
        }

        public override void UpdateRange(params TEntity[] entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            RemoveRange(entities);
            AddRange(entities);
        }

        public IList GetList()
        {
            return _data;
        }

        IList IListSource.GetList()
        {
            return _data;
        }

        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new FakeDbAsyncQueryProvider<TEntity>(_query.Provider); }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IAsyncEnumerator<TEntity> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
        {
            return new FakeDbAsyncEnumerator<TEntity>(this.AsEnumerable().GetEnumerator());
        }

    }

    public class FakeDbAsyncQueryProvider<TEntity> : IAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        public FakeDbAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            var m = expression as MethodCallExpression;
            if (m != null)
            {
                var resultType = m.Method.ReturnType; // it should be IQueryable<T>
                var tElement = resultType.GetGenericArguments()[0];
                var queryType = typeof(FakeDbAsyncEnumerable<>).MakeGenericType(tElement);
                return (IQueryable) Activator.CreateInstance(queryType, expression);
            }
            return new FakeDbAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            var queryType = typeof(FakeDbAsyncEnumerable<>).MakeGenericType(typeof(TElement));
            return (IQueryable<TElement>) Activator.CreateInstance(queryType, expression);
        }

        public object Execute(Expression expression)
        {
            return _inner.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public TResult ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken = new CancellationToken())
        {
            var expectedResultType = typeof(TResult).GetGenericArguments()[0];
            var executionResult = typeof(IQueryProvider)
                .GetMethod(
                    name: nameof(IQueryProvider.Execute),
                    genericParameterCount: 1,
                    types: new[] { typeof(Expression) })
                .MakeGenericMethod(expectedResultType)
                .Invoke(this, new[] { expression });

            return (TResult) typeof(Task).GetMethod(nameof(Task.FromResult))
                ?.MakeGenericMethod(expectedResultType)
                .Invoke(null, new[] { executionResult });
        }
    }

    public class FakeDbAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        public FakeDbAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        {
        }

        public FakeDbAsyncEnumerable(Expression expression)
            : base(expression)
        {
        }

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = new CancellationToken())
        {
            return new FakeDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        IAsyncEnumerator<T> IAsyncEnumerable<T>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAsyncEnumerator(cancellationToken);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.AsEnumerable().GetEnumerator();
        }
    }

    public class FakeDbAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _inner;

        public FakeDbAsyncEnumerator(IEnumerator<T> inner)
        {
            _inner = inner;
        }

        public T Current
        {
            get { return _inner.Current; }
        }
        public ValueTask<bool> MoveNextAsync()
        {
            return new ValueTask<bool>(_inner.MoveNext());
        }

        public ValueTask DisposeAsync()
        {
            _inner.Dispose();
            return new ValueTask(Task.CompletedTask);
        }
    }

    #endregion

    #region POCO classes

    // Categories
    public class Category
    {
        public int CategoryId { get; set; } // Category ID (Primary key)
        public string CategoryName { get; set; } // Category Name (length: 15)
        public string Description { get; set; } // Description (length: 536870911)
        public byte[] Picture { get; set; } // Picture (length: 1073741823)

        // Reverse navigation

        /// <summary>
        /// Child Products where [Products].[Category ID] point to this entity (Products_FK01)
        /// </summary>
        public virtual ICollection<Product> Products { get; set; } // Products.Products_FK01

        public Category()
        {
            Products = new List<Product>();
        }
    }

    // Customers
    public class Customer
    {
        public string CustomerId { get; set; } // Customer ID (Primary key) (length: 5)
        public string CompanyName { get; set; } // Company Name (length: 40)
        public string ContactName { get; set; } // Contact Name (length: 30)
        public string ContactTitle { get; set; } // Contact Title (length: 30)
        public string Address { get; set; } // Address (length: 60)
        public string City { get; set; } // City (length: 15)
        public string Region { get; set; } // Region (length: 15)
        public string PostalCode { get; set; } // Postal Code (length: 10)
        public string Country { get; set; } // Country (length: 15)
        public string Phone { get; set; } // Phone (length: 24)
        public string Fax { get; set; } // Fax (length: 24)

        // Reverse navigation

        /// <summary>
        /// Child Orders where [Orders].[Customer ID] point to this entity (Orders_FK00)
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; } // Orders.Orders_FK00

        public Customer()
        {
            Orders = new List<Order>();
        }
    }

    // Employees
    public class Employee
    {
        public int EmployeeId { get; set; } // Employee ID (Primary key)
        public string LastName { get; set; } // Last Name (length: 20)
        public string FirstName { get; set; } // First Name (length: 10)
        public string Title { get; set; } // Title (length: 30)
        public DateTime? BirthDate { get; set; } // Birth Date
        public DateTime? HireDate { get; set; } // Hire Date
        public string Address { get; set; } // Address (length: 60)
        public string City { get; set; } // City (length: 15)
        public string Region { get; set; } // Region (length: 15)
        public string PostalCode { get; set; } // Postal Code (length: 10)
        public string Country { get; set; } // Country (length: 15)
        public string HomePhone { get; set; } // Home Phone (length: 24)
        public string Extension { get; set; } // Extension (length: 4)
        public byte[] Photo { get; set; } // Photo (length: 1073741823)
        public string Notes { get; set; } // Notes (length: 536870911)
        public int? ReportsTo { get; set; } // Reports To

        // Reverse navigation

        /// <summary>
        /// Child Orders where [Orders].[Employee ID] point to this entity (Orders_FK02)
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; } // Orders.Orders_FK02

        public Employee()
        {
            Orders = new List<Order>();
        }
    }

    // Orders
    public class Order
    {
        public int OrderId { get; set; } // Order ID (Primary key)
        public string CustomerId { get; set; } // Customer ID (length: 5)
        public int? EmployeeId { get; set; } // Employee ID
        public string ShipName { get; set; } // Ship Name (length: 40)
        public string ShipAddress { get; set; } // Ship Address (length: 60)
        public string ShipCity { get; set; } // Ship City (length: 15)
        public string ShipRegion { get; set; } // Ship Region (length: 15)
        public string ShipPostalCode { get; set; } // Ship Postal Code (length: 10)
        public string ShipCountry { get; set; } // Ship Country (length: 15)
        public int? ShipVia { get; set; } // Ship Via
        public DateTime? OrderDate { get; set; } // Order Date
        public DateTime? RequiredDate { get; set; } // Required Date
        public DateTime? ShippedDate { get; set; } // Shipped Date
        public decimal? Freight { get; set; } // Freight

        // Reverse navigation

        /// <summary>
        /// Child OrderDetails where [Order Details].[Order ID] point to this entity (Order Details_FK01)
        /// </summary>
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } // Order Details.Order Details_FK01

        // Foreign keys

        /// <summary>
        /// Parent Customer pointed by [Orders].([CustomerId]) (Orders_FK00)
        /// </summary>
        public virtual Customer Customer { get; set; } // Orders_FK00

        /// <summary>
        /// Parent Employee pointed by [Orders].([EmployeeId]) (Orders_FK02)
        /// </summary>
        public virtual Employee Employee { get; set; } // Orders_FK02

        /// <summary>
        /// Parent Shipper pointed by [Orders].([ShipVia]) (Orders_FK01)
        /// </summary>
        public virtual Shipper Shipper { get; set; } // Orders_FK01

        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }

    // Order Details
    public class OrderDetail
    {
        public int OrderId { get; set; } // Order ID (Primary key)
        public int ProductId { get; set; } // Product ID (Primary key)
        public decimal UnitPrice { get; set; } // Unit Price
        public short Quantity { get; set; } // Quantity
        public float Discount { get; set; } // Discount

        // Foreign keys

        /// <summary>
        /// Parent Order pointed by [Order Details].([OrderId]) (Order Details_FK01)
        /// </summary>
        public virtual Order Order { get; set; } // Order Details_FK01

        /// <summary>
        /// Parent Product pointed by [Order Details].([ProductId]) (Order Details_FK00)
        /// </summary>
        public virtual Product Product { get; set; } // Order Details_FK00
    }

    // Products
    public class Product
    {
        public int ProductId { get; set; } // Product ID (Primary key)
        public int? SupplierId { get; set; } // Supplier ID
        public int? CategoryId { get; set; } // Category ID
        public string ProductName { get; set; } // Product Name (length: 40)
        public string EnglishName { get; set; } // English Name (length: 40)
        public string QuantityPerUnit { get; set; } // Quantity Per Unit (length: 20)
        public decimal? UnitPrice { get; set; } // Unit Price
        public short? UnitsInStock { get; set; } // Units In Stock
        public short? UnitsOnOrder { get; set; } // Units On Order
        public short? ReorderLevel { get; set; } // Reorder Level
        public bool Discontinued { get; set; } // Discontinued

        // Reverse navigation

        /// <summary>
        /// Child OrderDetails where [Order Details].[Product ID] point to this entity (Order Details_FK00)
        /// </summary>
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } // Order Details.Order Details_FK00

        // Foreign keys

        /// <summary>
        /// Parent Category pointed by [Products].([CategoryId]) (Products_FK01)
        /// </summary>
        public virtual Category Category { get; set; } // Products_FK01

        /// <summary>
        /// Parent Supplier pointed by [Products].([SupplierId]) (Products_FK00)
        /// </summary>
        public virtual Supplier Supplier { get; set; } // Products_FK00

        public Product()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }

    // Shippers
    public class Shipper
    {
        public int ShipperId { get; set; } // Shipper ID (Primary key)
        public string CompanyName { get; set; } // Company Name (length: 40)

        // Reverse navigation

        /// <summary>
        /// Child Orders where [Orders].[Ship Via] point to this entity (Orders_FK01)
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; } // Orders.Orders_FK01

        public Shipper()
        {
            Orders = new List<Order>();
        }
    }

    // Suppliers
    public class Supplier
    {
        public int SupplierId { get; set; } // Supplier ID (Primary key)
        public string CompanyName { get; set; } // Company Name (length: 40)
        public string ContactName { get; set; } // Contact Name (length: 30)
        public string ContactTitle { get; set; } // Contact Title (length: 30)
        public string Address { get; set; } // Address (length: 60)
        public string City { get; set; } // City (length: 15)
        public string Region { get; set; } // Region (length: 15)
        public string PostalCode { get; set; } // Postal Code (length: 10)
        public string Country { get; set; } // Country (length: 15)
        public string Phone { get; set; } // Phone (length: 24)
        public string Fax { get; set; } // Fax (length: 24)

        // Reverse navigation

        /// <summary>
        /// Child Products where [Products].[Supplier ID] point to this entity (Products_FK00)
        /// </summary>
        public virtual ICollection<Product> Products { get; set; } // Products.Products_FK00

        public Supplier()
        {
            Products = new List<Product>();
        }
    }


    #endregion

    #region POCO Configuration

    // Categories
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(x => x.CategoryId);

            builder.Property(x => x.CategoryId).HasColumnName(@"Category ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.CategoryName).HasColumnName(@"Category Name").HasColumnType("nvarchar(15)").IsRequired().HasMaxLength(15);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("ntext").IsRequired(false);
            builder.Property(x => x.Picture).HasColumnName(@"Picture").HasColumnType("image").IsRequired(false);
        }
    }

    // Customers
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.CustomerId);

            builder.Property(x => x.CustomerId).HasColumnName(@"Customer ID").HasColumnType("nvarchar(5)").IsRequired().HasMaxLength(5).ValueGeneratedNever();
            builder.Property(x => x.CompanyName).HasColumnName(@"Company Name").HasColumnType("nvarchar(40)").IsRequired().HasMaxLength(40);
            builder.Property(x => x.ContactName).HasColumnName(@"Contact Name").HasColumnType("nvarchar(30)").IsRequired(false).HasMaxLength(30);
            builder.Property(x => x.ContactTitle).HasColumnName(@"Contact Title").HasColumnType("nvarchar(30)").IsRequired(false).HasMaxLength(30);
            builder.Property(x => x.Address).HasColumnName(@"Address").HasColumnType("nvarchar(60)").IsRequired(false).HasMaxLength(60);
            builder.Property(x => x.City).HasColumnName(@"City").HasColumnType("nvarchar(15)").IsRequired(false).HasMaxLength(15);
            builder.Property(x => x.Region).HasColumnName(@"Region").HasColumnType("nvarchar(15)").IsRequired(false).HasMaxLength(15);
            builder.Property(x => x.PostalCode).HasColumnName(@"Postal Code").HasColumnType("nvarchar(10)").IsRequired(false).HasMaxLength(10);
            builder.Property(x => x.Country).HasColumnName(@"Country").HasColumnType("nvarchar(15)").IsRequired(false).HasMaxLength(15);
            builder.Property(x => x.Phone).HasColumnName(@"Phone").HasColumnType("nvarchar(24)").IsRequired(false).HasMaxLength(24);
            builder.Property(x => x.Fax).HasColumnName(@"Fax").HasColumnType("nvarchar(24)").IsRequired(false).HasMaxLength(24);
        }
    }

    // Employees
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(x => x.EmployeeId);

            builder.Property(x => x.EmployeeId).HasColumnName(@"Employee ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.LastName).HasColumnName(@"Last Name").HasColumnType("nvarchar(20)").IsRequired().HasMaxLength(20);
            builder.Property(x => x.FirstName).HasColumnName(@"First Name").HasColumnType("nvarchar(10)").IsRequired().HasMaxLength(10);
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(30)").IsRequired(false).HasMaxLength(30);
            builder.Property(x => x.BirthDate).HasColumnName(@"Birth Date").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.HireDate).HasColumnName(@"Hire Date").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.Address).HasColumnName(@"Address").HasColumnType("nvarchar(60)").IsRequired(false).HasMaxLength(60);
            builder.Property(x => x.City).HasColumnName(@"City").HasColumnType("nvarchar(15)").IsRequired(false).HasMaxLength(15);
            builder.Property(x => x.Region).HasColumnName(@"Region").HasColumnType("nvarchar(15)").IsRequired(false).HasMaxLength(15);
            builder.Property(x => x.PostalCode).HasColumnName(@"Postal Code").HasColumnType("nvarchar(10)").IsRequired(false).HasMaxLength(10);
            builder.Property(x => x.Country).HasColumnName(@"Country").HasColumnType("nvarchar(15)").IsRequired(false).HasMaxLength(15);
            builder.Property(x => x.HomePhone).HasColumnName(@"Home Phone").HasColumnType("nvarchar(24)").IsRequired(false).HasMaxLength(24);
            builder.Property(x => x.Extension).HasColumnName(@"Extension").HasColumnType("nvarchar(4)").IsRequired(false).HasMaxLength(4);
            builder.Property(x => x.Photo).HasColumnName(@"Photo").HasColumnType("image").IsRequired(false);
            builder.Property(x => x.Notes).HasColumnName(@"Notes").HasColumnType("ntext").IsRequired(false);
            builder.Property(x => x.ReportsTo).HasColumnName(@"Reports To").HasColumnType("int").IsRequired(false);
        }
    }

    // Orders
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.OrderId);

            builder.Property(x => x.OrderId).HasColumnName(@"Order ID").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.CustomerId).HasColumnName(@"Customer ID").HasColumnType("nvarchar(5)").IsRequired().HasMaxLength(5);
            builder.Property(x => x.EmployeeId).HasColumnName(@"Employee ID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ShipName).HasColumnName(@"Ship Name").HasColumnType("nvarchar(40)").IsRequired(false).HasMaxLength(40);
            builder.Property(x => x.ShipAddress).HasColumnName(@"Ship Address").HasColumnType("nvarchar(60)").IsRequired(false).HasMaxLength(60);
            builder.Property(x => x.ShipCity).HasColumnName(@"Ship City").HasColumnType("nvarchar(15)").IsRequired(false).HasMaxLength(15);
            builder.Property(x => x.ShipRegion).HasColumnName(@"Ship Region").HasColumnType("nvarchar(15)").IsRequired(false).HasMaxLength(15);
            builder.Property(x => x.ShipPostalCode).HasColumnName(@"Ship Postal Code").HasColumnType("nvarchar(10)").IsRequired(false).HasMaxLength(10);
            builder.Property(x => x.ShipCountry).HasColumnName(@"Ship Country").HasColumnType("nvarchar(15)").IsRequired(false).HasMaxLength(15);
            builder.Property(x => x.ShipVia).HasColumnName(@"Ship Via").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.OrderDate).HasColumnName(@"Order Date").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.RequiredDate).HasColumnName(@"Required Date").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.ShippedDate).HasColumnName(@"Shipped Date").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.Freight).HasColumnName(@"Freight").HasColumnType("money").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.Customer).WithMany(b => b.Orders).HasForeignKey(c => c.CustomerId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Orders_FK00");
            builder.HasOne(a => a.Employee).WithMany(b => b.Orders).HasForeignKey(c => c.EmployeeId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Orders_FK02");
            builder.HasOne(a => a.Shipper).WithMany(b => b.Orders).HasForeignKey(c => c.ShipVia).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Orders_FK01");
        }
    }

    // Order Details
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("Order Details");
            builder.HasKey(x => new { x.OrderId, x.ProductId });

            builder.Property(x => x.OrderId).HasColumnName(@"Order ID").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.ProductId).HasColumnName(@"Product ID").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.UnitPrice).HasColumnName(@"Unit Price").HasColumnType("money").IsRequired();
            builder.Property(x => x.Quantity).HasColumnName(@"Quantity").HasColumnType("smallint").IsRequired();
            builder.Property(x => x.Discount).HasColumnName(@"Discount").HasColumnType("real").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.Order).WithMany(b => b.OrderDetails).HasForeignKey(c => c.OrderId).HasConstraintName("Order Details_FK01");
            builder.HasOne(a => a.Product).WithMany(b => b.OrderDetails).HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Order Details_FK00");
        }
    }

    // Products
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.ProductId);

            builder.Property(x => x.ProductId).HasColumnName(@"Product ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.SupplierId).HasColumnName(@"Supplier ID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CategoryId).HasColumnName(@"Category ID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ProductName).HasColumnName(@"Product Name").HasColumnType("nvarchar(40)").IsRequired().HasMaxLength(40);
            builder.Property(x => x.EnglishName).HasColumnName(@"English Name").HasColumnType("nvarchar(40)").IsRequired(false).HasMaxLength(40);
            builder.Property(x => x.QuantityPerUnit).HasColumnName(@"Quantity Per Unit").HasColumnType("nvarchar(20)").IsRequired(false).HasMaxLength(20);
            builder.Property(x => x.UnitPrice).HasColumnName(@"Unit Price").HasColumnType("money").IsRequired(false);
            builder.Property(x => x.UnitsInStock).HasColumnName(@"Units In Stock").HasColumnType("smallint").IsRequired(false);
            builder.Property(x => x.UnitsOnOrder).HasColumnName(@"Units On Order").HasColumnType("smallint").IsRequired(false);
            builder.Property(x => x.ReorderLevel).HasColumnName(@"Reorder Level").HasColumnType("smallint").IsRequired(false);
            builder.Property(x => x.Discontinued).HasColumnName(@"Discontinued").HasColumnType("bit").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.Category).WithMany(b => b.Products).HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Products_FK01");
            builder.HasOne(a => a.Supplier).WithMany(b => b.Products).HasForeignKey(c => c.SupplierId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Products_FK00");
        }
    }

    // Shippers
    public class ShipperConfiguration : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.ToTable("Shippers");
            builder.HasKey(x => x.ShipperId);

            builder.Property(x => x.ShipperId).HasColumnName(@"Shipper ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.CompanyName).HasColumnName(@"Company Name").HasColumnType("nvarchar(40)").IsRequired().HasMaxLength(40);
        }
    }

    // Suppliers
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");
            builder.HasKey(x => x.SupplierId);

            builder.Property(x => x.SupplierId).HasColumnName(@"Supplier ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.CompanyName).HasColumnName(@"Company Name").HasColumnType("nvarchar(40)").IsRequired().HasMaxLength(40);
            builder.Property(x => x.ContactName).HasColumnName(@"Contact Name").HasColumnType("nvarchar(30)").IsRequired(false).HasMaxLength(30);
            builder.Property(x => x.ContactTitle).HasColumnName(@"Contact Title").HasColumnType("nvarchar(30)").IsRequired(false).HasMaxLength(30);
            builder.Property(x => x.Address).HasColumnName(@"Address").HasColumnType("nvarchar(60)").IsRequired(false).HasMaxLength(60);
            builder.Property(x => x.City).HasColumnName(@"City").HasColumnType("nvarchar(15)").IsRequired(false).HasMaxLength(15);
            builder.Property(x => x.Region).HasColumnName(@"Region").HasColumnType("nvarchar(15)").IsRequired(false).HasMaxLength(15);
            builder.Property(x => x.PostalCode).HasColumnName(@"Postal Code").HasColumnType("nvarchar(10)").IsRequired(false).HasMaxLength(10);
            builder.Property(x => x.Country).HasColumnName(@"Country").HasColumnType("nvarchar(15)").IsRequired(false).HasMaxLength(15);
            builder.Property(x => x.Phone).HasColumnName(@"Phone").HasColumnType("nvarchar(24)").IsRequired(false).HasMaxLength(24);
            builder.Property(x => x.Fax).HasColumnName(@"Fax").HasColumnType("nvarchar(24)").IsRequired(false).HasMaxLength(24);
        }
    }


    #endregion

}
// </auto-generated>
