using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using Microsoft.Extensions.Configuration;

#nullable disable

namespace libraryManagement.Models
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options,IConfiguration configuration)
            : base(options)
        {
            Configuration=configuration;
        }

        public IConfiguration Configuration { get; }
        public virtual DbSet<TblBook> TblBooks { get; set; }
        public virtual DbSet<TblBookAuthor> TblBookAuthors { get; set; }
        public virtual DbSet<TblBookCopy> TblBookCopies { get; set; }
        public virtual DbSet<TblBookLoan> TblBookLoans { get; set; }
        public virtual DbSet<TblBorrower> TblBorrowers { get; set; }
        public virtual DbSet<TblLibraryBranch> TblLibraryBranches { get; set; }
        public virtual DbSet<TblPublisher> TblPublishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                string connString = Configuration.GetSection("ConnectionStrings")["DefaultConnection"];
                optionsBuilder.UseSqlServer(connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBook>(entity =>
            {
                entity.HasKey(e => e.BookBookId)
                    .HasName("PK__tbl_book__6B53AB8B9FBDE19C");

                entity.ToTable("tbl_book");

                entity.Property(e => e.BookBookId).HasColumnName("book_BookID");

                entity.Property(e => e.BookPublisherName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("book_PublisherName");

                entity.Property(e => e.BookTitle)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("book_Title");

                entity.HasOne(d => d.BookPublisherNameNavigation)
                    .WithMany(p => p.TblBooks)
                    .HasForeignKey(d => d.BookPublisherName)
                    .HasConstraintName("fk_publisher_name1");
            });

            modelBuilder.Entity<TblBookAuthor>(entity =>
            {
                entity.HasKey(e => e.BookAuthorsAuthorId)
                    .HasName("PK__tbl_book__A3D4D4CD7144EEA8");

                entity.ToTable("tbl_book_authors");

                entity.Property(e => e.BookAuthorsAuthorId).HasColumnName("book_authors_AuthorID");

                entity.Property(e => e.BookAuthorsAuthorName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("book_authors_AuthorName");

                entity.Property(e => e.BookAuthorsBookId).HasColumnName("book_authors_BookID");

                entity.HasOne(d => d.BookAuthorsBook)
                    .WithMany(p => p.TblBookAuthors)
                    .HasForeignKey(d => d.BookAuthorsBookId)
                    .HasConstraintName("fk_book_id3");
            });

            modelBuilder.Entity<TblBookCopy>(entity =>
            {
                entity.HasKey(e => e.BookCopiesCopiesId)
                    .HasName("PK__tbl_book__18E86D1F468D4743");

                entity.ToTable("tbl_book_copies");

                entity.Property(e => e.BookCopiesCopiesId).HasColumnName("book_copies_CopiesID");

                entity.Property(e => e.BookCopiesBookId).HasColumnName("book_copies_BookID");

                entity.Property(e => e.BookCopiesBranchId).HasColumnName("book_copies_BranchID");

                entity.Property(e => e.BookCopiesNoOfCopies).HasColumnName("book_copies_No_Of_Copies");

                entity.HasOne(d => d.BookCopiesBook)
                    .WithMany(p => p.TblBookCopies)
                    .HasForeignKey(d => d.BookCopiesBookId)
                    .HasConstraintName("fk_book_id2");

                entity.HasOne(d => d.BookCopiesBranch)
                    .WithMany(p => p.TblBookCopies)
                    .HasForeignKey(d => d.BookCopiesBranchId)
                    .HasConstraintName("fk_branch_id2");
            });

            modelBuilder.Entity<TblBookLoan>(entity =>
            {
                entity.HasKey(e => e.BookLoansLoansId)
                    .HasName("PK__tbl_book__9A03D6FBDE8729F8");

                entity.ToTable("tbl_book_loans");

                entity.Property(e => e.BookLoansLoansId).HasColumnName("book_loans_LoansID");

                entity.Property(e => e.BookLoansBookId).HasColumnName("book_loans_BookID");

                entity.Property(e => e.BookLoansBranchId).HasColumnName("book_loans_BranchID");

                entity.Property(e => e.BookLoansCardNo).HasColumnName("book_loans_CardNo");

                entity.Property(e => e.BookLoansDateOut)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("book_loans_DateOut");

                entity.Property(e => e.BookLoansDueDate)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("book_loans_DueDate");

                entity.HasOne(d => d.BookLoansBook)
                    .WithMany(p => p.TblBookLoans)
                    .HasForeignKey(d => d.BookLoansBookId)
                    .HasConstraintName("fk_book_id1");

                entity.HasOne(d => d.BookLoansBranch)
                    .WithMany(p => p.TblBookLoans)
                    .HasForeignKey(d => d.BookLoansBranchId)
                    .HasConstraintName("fk_branch_id1");

                entity.HasOne(d => d.BookLoansCardNoNavigation)
                    .WithMany(p => p.TblBookLoans)
                    .HasForeignKey(d => d.BookLoansCardNo)
                    .HasConstraintName("fk_cardno");
            });

            modelBuilder.Entity<TblBorrower>(entity =>
            {
                entity.HasKey(e => e.BorrowerCardNo)
                    .HasName("PK__tbl_borr__F3500D96782E8E5D");

                entity.ToTable("tbl_borrower");

                entity.Property(e => e.BorrowerCardNo).HasColumnName("borrower_CardNo");

                entity.Property(e => e.BorrowerBorrowerAddress)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("borrower_BorrowerAddress");

                entity.Property(e => e.BorrowerBorrowerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("borrower_BorrowerName");

                entity.Property(e => e.BorrowerBorrowerPhone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("borrower_BorrowerPhone");
            });

            modelBuilder.Entity<TblLibraryBranch>(entity =>
            {
                entity.HasKey(e => e.LibraryBranchBranchId)
                    .HasName("PK__tbl_libr__7C4A21D368C75DDB");

                entity.ToTable("tbl_library_branch");

                entity.Property(e => e.LibraryBranchBranchId).HasColumnName("library_branch_BranchID");

                entity.Property(e => e.LibraryBranchBranchAddress)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("library_branch_BranchAddress");

                entity.Property(e => e.LibraryBranchBranchName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("library_branch_BranchName");
            });

            modelBuilder.Entity<TblPublisher>(entity =>
            {
                entity.HasKey(e => e.PublisherPublisherName)
                    .HasName("PK__tbl_publ__EEF598AA2DEF047C");

                entity.ToTable("tbl_publisher");

                entity.Property(e => e.PublisherPublisherName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("publisher_PublisherName");

                entity.Property(e => e.PublisherPublisherAddress)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("publisher_PublisherAddress");

                entity.Property(e => e.PublisherPublisherPhone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("publisher_PublisherPhone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
