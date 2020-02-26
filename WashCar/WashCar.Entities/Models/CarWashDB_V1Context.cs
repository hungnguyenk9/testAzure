using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WashCar.Entities.Models
{
    public partial class CarWashDB_V1Context : DbContext
    {
        public CarWashDB_V1Context()
        {
        }

        public CarWashDB_V1Context(DbContextOptions<CarWashDB_V1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountMst> AccountMst { get; set; }
        public virtual DbSet<CustomerMst> CustomerMst { get; set; }
        public virtual DbSet<EmployeeMst> EmployeeMst { get; set; }
        public virtual DbSet<InfoMst> InfoMst { get; set; }
        public virtual DbSet<OccupationMst> OccupationMst { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<ServiceMst> ServiceMst { get; set; }
        public virtual DbSet<StoreMst> StoreMst { get; set; }
        public virtual DbSet<TempOrder> TempOrder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:carwashdbv1.database.windows.net,1433;Initial Catalog=CarWashDB_V1;Persist Security Info=False;User ID=adCarWash;Password=carwash@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountMst>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("AccountMST");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.AccountSt).HasColumnName("accountSt");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("createDt")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("updateDt")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserNm)
                    .HasColumnName("userNm")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerMst>(entity =>
            {
                entity.HasKey(e => e.CustId);

                entity.ToTable("CustomerMST");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.ActiveSt).HasColumnName("activeSt");

                entity.Property(e => e.Address1)
                    .HasColumnName("address1")
                    .HasMaxLength(300);

                entity.Property(e => e.Address2)
                    .HasColumnName("address2")
                    .HasMaxLength(300);

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasColumnType("date");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("createDt")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustNm)
                    .HasColumnName("custNm")
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.MobileNo)
                    .HasColumnName("mobileNo")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("updateDt")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<EmployeeMst>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.ToTable("EmployeeMST");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.ActiveSt).HasColumnName("activeSt");

                entity.Property(e => e.CreateDt).HasColumnName("createDt");

                entity.Property(e => e.EmpNm)
                    .HasColumnName("empNm")
                    .HasMaxLength(100);

                entity.Property(e => e.MobileNo)
                    .HasColumnName("mobileNo")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OccId).HasColumnName("occId");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.Property(e => e.UpdateDt).HasColumnName("updateDt");

                entity.Property(e => e.UserNm)
                    .HasColumnName("userNm")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InfoMst>(entity =>
            {
                entity.HasKey(e => e.InfoId);

                entity.ToTable("InfoMST");

                entity.Property(e => e.InfoId).HasColumnName("infoId");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("createDt")
                    .HasColumnType("datetime");

                entity.Property(e => e.InfoContent).HasColumnName("infoContent");

                entity.Property(e => e.InfoType)
                    .HasColumnName("infoType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("updateDt")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OccupationMst>(entity =>
            {
                entity.HasKey(e => e.OccId);

                entity.ToTable("OccupationMST");

                entity.Property(e => e.OccId).HasColumnName("occId");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("createDt")
                    .HasColumnType("datetime");

                entity.Property(e => e.OccName)
                    .HasColumnName("occName")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("updateDt")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreateBy).HasColumnName("createBy");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("createDt")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.OrderSt).HasColumnName("orderSt");

                entity.Property(e => e.OrderTid).HasColumnName("orderTId");

                entity.Property(e => e.PaymentMethod).HasColumnName("paymentMethod");

                entity.Property(e => e.Services)
                    .HasColumnName("services")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.Property(e => e.UpdateBy).HasColumnName("updateBy");

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("updateDt")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<ServiceMst>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.ToTable("ServiceMST");

                entity.Property(e => e.ServiceId).HasColumnName("serviceId");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("createDt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ServiceDsc)
                    .HasColumnName("serviceDsc")
                    .HasMaxLength(500);

                entity.Property(e => e.ServiceName)
                    .HasColumnName("serviceName")
                    .HasMaxLength(100);

                entity.Property(e => e.ServiceSt).HasColumnName("serviceSt");

                entity.Property(e => e.ServiceUp)
                    .HasColumnName("serviceUp")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("updateDt")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<StoreMst>(entity =>
            {
                entity.HasKey(e => e.StoreId);

                entity.ToTable("StoreMST");

                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.Property(e => e.ActiveSt).HasColumnName("activeSt");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("createDt")
                    .HasColumnType("datetime");

                entity.Property(e => e.Infos)
                    .HasColumnName("infos")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Services)
                    .HasColumnName("services")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.StoreNm)
                    .HasColumnName("storeNm")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("updateDt")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TempOrder>(entity =>
            {
                entity.HasKey(e => e.TempOrdId);

                entity.Property(e => e.TempOrdId).HasColumnName("tempOrdId");

                entity.Property(e => e.CheckinSt).HasColumnName("checkinSt");

                entity.Property(e => e.CreateBy).HasColumnName("createBy");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("createDt")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.Property(e => e.TimeCheckin)
                    .HasColumnName("timeCheckin")
                    .HasColumnType("datetime");

                entity.Property(e => e.TimeEstimate).HasColumnName("timeEstimate");

                entity.Property(e => e.UpdateBy).HasColumnName("updateBy");

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("updateDt")
                    .HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
