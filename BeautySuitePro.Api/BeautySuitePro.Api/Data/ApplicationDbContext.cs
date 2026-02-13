using Microsoft.EntityFrameworkCore;
using BeautySuitePro.Api.Models;
using System.Linq;

namespace BeautySuitePro.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // ================================
        // USERS
        // ================================
        public DbSet<User> Users { get; set; }

        // ================================
        // BOOKINGS
        // ================================
        public DbSet<Booking> Bookings { get; set; }

        // ================================
        // PAYMENTS
        // ================================
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<BankTransferDetail> BankTransferDetails { get; set; }
        public DbSet<Refund> Refunds { get; set; }

        // ================================
        // GIFT CARDS
        // ================================
        public DbSet<GiftCard> GiftCards { get; set; }
        public DbSet<GiftCardTransaction> GiftCardTransactions { get; set; }

        // ================================
        // REVIEWS
        // ================================
        public DbSet<Review> Reviews { get; set; }

        // ================================
        // MEDIA
        // ================================
        public DbSet<MediaContent> MediaContents { get; set; }

        // ================================
        // SYSTEM
        // ================================
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Rename Id column for each entity
        modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("UserId");
        modelBuilder.Entity<Booking>().Property(b => b.Id).HasColumnName("BookingId");
        modelBuilder.Entity<Payment>().Property(p => p.Id).HasColumnName("PaymentId");
        modelBuilder.Entity<Refund>().Property(r => r.Id).HasColumnName("RefundId");
        modelBuilder.Entity<GiftCard>().Property(gc => gc.Id).HasColumnName("GiftCardId");
        modelBuilder.Entity<PaymentMethod>().Property(pm => pm.Id).HasColumnName("PaymentMethodId");
        modelBuilder.Entity<BankTransferDetail>().Property(bt => bt.Id).HasColumnName("BankTransferDetailId");
        modelBuilder.Entity<GiftCardTransaction>().Property(gt => gt.Id).HasColumnName("GiftCardTransactionId");
        modelBuilder.Entity<Review>().Property(r => r.Id).HasColumnName("ReviewId");
        modelBuilder.Entity<MediaContent>().Property(m => m.Id).HasColumnName("MediaContentId");
        modelBuilder.Entity<Currency>().Property(c => c.Id).HasColumnName("CurrencyId");
        modelBuilder.Entity<Notification>().Property(n => n.Id).HasColumnName("NotificationId");
        modelBuilder.Entity<AuditLog>().Property(a => a.Id).HasColumnName("AuditLogId");

        // BankTransferDetail → Payment
        modelBuilder.Entity<BankTransferDetail>()
            .HasOne(bt => bt.Payment)
            .WithMany(p => p.BankTransferDetails)
            .HasForeignKey(bt => bt.PaymentId)
            .OnDelete(DeleteBehavior.NoAction);

        // Refund relationships
        modelBuilder.Entity<Refund>()
            .HasOne(r => r.Payment)
            .WithMany(p => p.Refunds)
            .HasForeignKey(r => r.PaymentId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Refund>()
            .HasOne(r => r.Booking)
            .WithMany()
            .HasForeignKey(r => r.BookingId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Refund>()
            .HasOne(r => r.GiftCard)
            .WithMany()
            .HasForeignKey(r => r.GiftCardId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Refund>()
            .HasOne(r => r.RequestedByUser)
            .WithMany(u => u.RequestedRefunds)
            .HasForeignKey(r => r.RequestedBy)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Refund>()
            .HasOne(r => r.ProcessedByUser)
            .WithMany(u => u.ProcessedRefunds)
            .HasForeignKey(r => r.ProcessedBy)
            .OnDelete(DeleteBehavior.NoAction);

        // GiftCardTransaction → GiftCard
        modelBuilder.Entity<GiftCardTransaction>()
            .HasOne(gt => gt.GiftCard)
            .WithMany(gc => gc.Transactions)
            .HasForeignKey(gt => gt.GiftCardId)
            .OnDelete(DeleteBehavior.NoAction);

        // Review → User & Booking
        modelBuilder.Entity<Review>()
            .HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Booking)
            .WithMany()
            .HasForeignKey(r => r.BookingId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
