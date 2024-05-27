using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FlightBooking.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FbookingBookDltsPs> FbookingBookDltsPs { get; set; }
        public virtual DbSet<FbookingBookMstPs> FbookingBookMstPs { get; set; }
        public virtual DbSet<FbookingDestMstPs> FbookingDestMstPs { get; set; }
        public virtual DbSet<FbookingUserDltsPs> FbookingUserDltsPs { get; set; }
        public virtual DbSet<FbookingUserPs> FbookingUserPs { get; set; }
        public virtual DbSet<FbookingFinalPs> FbookingFinalPs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseOracle("License Key=vEyr8GdnIarOKlEHQKxi+4E0HlXN85PVGHI096M18fHO05syciZT/8xvOeNbTwuMbqdZkRZ1qbdPjO13mrnBnlMUyskKr9qbBNMTzJAp5+R858T7YUZaTY5rodcDl7pDutJBeuYiwHG+xtXnywKMPX+9u82fR1AMT9EailpEiBp1OAn6IbJ55eXY15+rsAfDDwUuIv/js610S6cy9vLt37IL4PcZ8Wx/MrQlA38Z+kEH9Wztcv+NSWFVRz2wnVRDtIowaySSKk30sA+MBbg2IIUI+/MgDUp6w53NCxQSsuM=; User Id=iusf;Password=iusf_dev;SERVICE NAME=iffcodevpd;Direct=true;Data Source=iffcoexadr-92rdq-scan.drhyddbcltsn01.drhydebsprodvcn.oraclevcn.com:1521/ifppdbdev.drhyddbcltsn01.drhydebsprodvcn.oraclevcn.com;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FbookingBookDltsPs>(entity =>
            {
                entity.HasKey(e => e.FlightId);

                entity.ToTable("FBOOKING_BOOK_DLTS_PS", "IUSF");

                entity.HasIndex(e => e.FlightId)
                    .HasName("FBOOKING_BOOK_DLTS_PS_PK")
                    .IsUnique();

                entity.Property(e => e.FlightId)
                    .HasColumnName("CLASS_ID")
                    .HasColumnType("varchar2")
                    .HasMaxLength(30);

                entity.Property(e => e.ReturnDate)
                    .HasColumnName("RETURN_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Traveller).HasColumnName("TRAVELLER");
            });

            modelBuilder.Entity<FbookingBookMstPs>(entity =>
            {
                entity.HasKey(e => e.FlightId);

                entity.ToTable("FBOOKING_BOOK_MST_PS", "IUSF");

                entity.HasIndex(e => e.FlightId)
                    .HasName("FBOOKING_BOOK_MST_PS_PK")
                    .IsUnique();

                entity.Property(e => e.FlightId)
                    .HasColumnName("FLIGHT_ID");

                entity.Property(e => e.DepartureAp)
                    .HasColumnName("DEPARTURE_AP");

                entity.Property(e => e.DestinationAp)
                    .HasColumnName("DESTINATION_AP");

                entity.Property(e => e.JourneyDate)
                    .HasColumnName("JOURNEY_DATE")
                    .HasColumnType("date"); 

                entity.Property(e => e.Price).HasColumnName("PRICE");

                entity.Property(e => e.JourneyDuration).HasColumnName("JOURNEY_DURATION");
            });

            modelBuilder.Entity<FbookingDestMstPs>(entity =>
            {
                entity.HasKey(e => e.DestinationId);

                entity.ToTable("FBOOKING_DEST_MST_PS", "IUSF");

                entity.HasIndex(e => e.DestinationId)
                    .HasName("FBOOKING_DEST_MST_PS_PK")
                    .IsUnique();

                entity.Property(e => e.DestinationId).HasColumnName("DESTINATION_ID");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasColumnType("varchar2")
                    .HasMaxLength(30);

                entity.Property(e => e.DestinationCode)
                    .HasColumnName("DESTINATION_CODE")
                    .HasColumnType("varchar2")
                    .HasMaxLength(30);

            });

            modelBuilder.Entity<FbookingUserDltsPs>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("FBOOKING_USER_DLTS_PS", "IUSF");

                entity.HasIndex(e => e.UserId)
                    .HasName("FBOOKING_USER_DLTS_PS_PK")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasColumnType("varchar2")
                    .HasMaxLength(20);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasColumnType("varchar2")
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNo).HasColumnName("PHONE_NO");
            });

            modelBuilder.Entity<FbookingUserPs>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("FBOOKING_USER_PS", "IUSF");

                entity.HasIndex(e => e.UserId)
                    .HasName("FBOOKING_USER_PS_PK")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasColumnType("varchar2")
                    .HasMaxLength(20);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasColumnType("varchar2")
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasColumnType("varchar2")
                    .HasMaxLength(20);

                entity.Property(e => e.Username)
                    .HasColumnName("USERNAME")
                    .HasColumnType("varchar2");
            });



            modelBuilder.Entity<FbookingFinalPs>(entity =>
            {

                entity.HasKey(e => e.BookingId);

                entity.ToTable("FBOOKING_FINAL_PS", "IUSF");

                entity.HasIndex(e => e.BookingId)
                    .HasName("FBOOKING_FINAL_PS")
                    .IsUnique();


                entity.Property(e => e.BookingId)
                  .HasColumnName("BOOKING_ID");

                entity.Property(e => e.UserId)
                   .HasColumnName("USER_ID")
                   .HasColumnType("varchar2");


                entity.Property(e => e.Username)
                   .HasColumnName("USERNAME")
                   .HasColumnType("varchar2");

                entity.Property(e => e.FlightId)
                    .HasColumnName("FLIGHT_ID");

                entity.Property(e => e.PhoneNo).HasColumnName("PHONE_NO");

                entity.Property(e => e.Email)
                   .HasColumnName("EMAIL")
                   .HasColumnType("varchar2")
                   .HasMaxLength(100);

                entity.Property(e => e.Dob)
                   .HasColumnName("DOB")
                   .HasColumnType("date");

                entity.Property(e => e.DepartureAp)
                   .HasColumnName("DEPARTURE_AP");

                entity.Property(e => e.DestinationAp)
                   .HasColumnName("DESTINATION_AP");

                entity.Property(e => e.Traveller).HasColumnName("TRAVELLER");

                entity.Property(e => e.JourneyDate)
                   .HasColumnName("JOURNEY_DATE");

                entity.Property(e => e.Price).HasColumnName("PRICE");

                entity.Property(e => e.JourneyDuration).HasColumnName("JOURNEY_DURATION");

                entity.Property(e => e.BookingStatus)
                   .HasColumnName("BOOKING_STATUS");
                   
            });
        }
    }
}
