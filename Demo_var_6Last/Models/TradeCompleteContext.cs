using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Demo_var_6Last.Models;

public partial class TradeCompleteContext : DbContext
{
    public TradeCompleteContext()
    {
    }

    public TradeCompleteContext(DbContextOptions<TradeCompleteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderImport> OrderImports { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<OrderProductImport> OrderProductImports { get; set; }

    public virtual DbSet<PickUpPoint> PickUpPoints { get; set; }

    public virtual DbSet<PickupImport> PickupImports { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductT> ProductTs { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserImport> UserImports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Trade_Complete;Trusted_connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BAF62396BCD");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.DeliveryDate).HasColumnType("date");
            entity.Property(e => e.OrderDate).HasColumnType("date");
            entity.Property(e => e.PickUpPointId).HasColumnName("PickUpPointID");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.PickUpPoint).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PickUpPointId)
                .HasConstraintName("FK__Order__PickUpPoi__46E78A0C");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Order__UserID__47DBAE45");
        });

        modelBuilder.Entity<OrderImport>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("order_import");

            entity.Property(e => e.ДатаДоставки)
                .HasColumnType("date")
                .HasColumnName("Дата_доставки");
            entity.Property(e => e.ДатаЗаказа)
                .HasColumnType("date")
                .HasColumnName("Дата_заказа");
            entity.Property(e => e.КодДляПолучения).HasColumnName("Код_для_получения");
            entity.Property(e => e.НомерЗаказа).HasColumnName("Номер_заказа");
            entity.Property(e => e.ПунктВыдачи).HasColumnName("Пункт_выдачи");
            entity.Property(e => e.СтатусЗаказа)
                .HasMaxLength(50)
                .HasColumnName("Статус_заказа");
            entity.Property(e => e.ФиоКлиента)
                .HasMaxLength(50)
                .HasColumnName("ФИО_клиента");
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK__OrderPro__08D097C15436E7E9");

            entity.ToTable("OrderProduct");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderProd__Order__48CFD27E");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderProd__Produ__49C3F6B7");
        });

        modelBuilder.Entity<OrderProductImport>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("orderProduct_import");

            entity.Property(e => e.АртикулПродукта)
                .HasMaxLength(50)
                .HasColumnName("Артикул_продукта");
            entity.Property(e => e.НомерЗаказа).HasColumnName("Номер_заказа");
        });

        modelBuilder.Entity<PickUpPoint>(entity =>
        {
            entity.HasKey(e => e.PointId).HasName("PK__PickUpPo__40A97781A5AB6A0C");

            entity.ToTable("PickUpPoint");

            entity.Property(e => e.PointId).HasColumnName("PointID");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(50);
        });

        modelBuilder.Entity<PickupImport>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("pickup_import");

            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6ED67B243FA");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Manufacturer).HasMaxLength(50);
            entity.Property(e => e.Provider).HasMaxLength(50);
            entity.Property(e => e.Unit).HasMaxLength(50);

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Category)
                .HasConstraintName("FK__Product__Categor__4AB81AF0");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__ProductC__19093A2BF97A5FBF");

            entity.ToTable("ProductCategory");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
        });

        modelBuilder.Entity<ProductT>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("productT");

            entity.Property(e => e.Артикул).HasMaxLength(50);
            entity.Property(e => e.ДействующаяСкидка).HasColumnName("Действующая_скидка");
            entity.Property(e => e.ЕдиницаИзмерения)
                .HasMaxLength(50)
                .HasColumnName("Единица_измерения");
            entity.Property(e => e.Изображение).HasMaxLength(50);
            entity.Property(e => e.КатегорияТовара)
                .HasMaxLength(50)
                .HasColumnName("Категория_товара");
            entity.Property(e => e.КолВоНаСкладе).HasColumnName("Кол_во_на_складе");
            entity.Property(e => e.Наименование).HasMaxLength(50);
            entity.Property(e => e.Поставщик).HasMaxLength(50);
            entity.Property(e => e.Производитель).HasMaxLength(50);
            entity.Property(e => e.РазмерМаксимальноВозможнойСкидки).HasColumnName("Размер_максимально_возможной_скидки");
            entity.Property(e => e.Стоимость).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3AA0A5260E");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCACF4B3235F");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Lfp).HasColumnName("LFP");
            entity.Property(e => e.Login).IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__User__RoleID__4BAC3F29");
        });

        modelBuilder.Entity<UserImport>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("user_import");

            entity.Property(e => e.Логин).HasMaxLength(50);
            entity.Property(e => e.Пароль).HasMaxLength(50);
            entity.Property(e => e.РольСотрудника)
                .HasMaxLength(50)
                .HasColumnName("Роль_сотрудника");
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .HasColumnName("ФИО");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
