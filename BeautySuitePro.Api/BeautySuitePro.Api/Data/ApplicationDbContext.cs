using Microsoft.EntityFrameworkCore;
using BeautySuitePro.Api.Models;

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

            // ================================
            // BankTransferDetail → Payment
            // ================================
            modelBuilder.Entity<BankTransferDetail>()
                .HasOne(bt => bt.Payment)
                .WithMany(p => p.BankTransferDetails)
                .HasForeignKey(bt => bt.PaymentId)
                .OnDelete(DeleteBehavior.Cascade);

            // ================================
            // Refund relationships
            // ================================
            modelBuilder.Entity<Refund>()
                .HasOne(r => r.Payment)
                .WithMany(p => p.Refunds)
                .HasForeignKey(r => r.PaymentId)
                .OnDelete(DeleteBehavior.Cascade);

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
                .WithMany()
                .HasForeignKey(r => r.RequestedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Refund>()
                .HasOne(r => r.ProcessedByUser)
                .WithMany()
                .HasForeignKey(r => r.ProcessedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // ================================
            // GiftCardTransaction → GiftCard
            // ================================
            modelBuilder.Entity<GiftCardTransaction>()
                .HasOne(gt => gt.GiftCard)
                .WithMany(gc => gc.Transactions)
                .HasForeignKey(gt => gt.GiftCardId)
                .OnDelete(DeleteBehavior.Cascade);

            // ================================
            // Review → User & Booking
            // ================================
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Booking)
                .WithMany()
                .HasForeignKey(r => r.BookingId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}