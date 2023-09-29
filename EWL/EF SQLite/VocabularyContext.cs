using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EWL;

public partial class VocabularyContext : DbContext
{
    static string connectionString = "Data Source=.\\Vocabulary.db;";

    //static public bool DoLogActions { get; set; } = true;
    //readonly StreamWriter logStream = new("log\\SQLog.txt", true);

    public VocabularyContext()
    {
        //Database.EnsureCreated();
    }

    public VocabularyContext(string connectionStr) : this()
    {
        connectionString = connectionStr;
    }

    public VocabularyContext(DbContextOptions<VocabularyContext> options)
        : base(options)
    { }


    public virtual DbSet<Word> AllWords { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<WordCategory> WordCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    {
        optionsBuilder.UseSqlite(connectionString);
        //if (DoLogActions)
        //    optionsBuilder.LogTo(logStream.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Word>(entity =>
        {
            entity.HasKey(e => e.WordId);

            entity.Property(e => e.WordId)
                //.ValueGeneratedNever()
                .HasColumnName("WordID");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId)
                //.ValueGeneratedNever()
                .HasColumnName("CategoryID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt)
                .HasDefaultValueSql("'2000-01-01 00:00:00'")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.SettingsId);

            entity.Property(e => e.SettingsId)
                //.ValueGeneratedNever()
                .HasColumnName("SettingsID");
            entity.Property(e => e.CurrentCategoryId).HasColumnName("CurrentCategoryID");

            entity.HasOne(d => d.CurrentCategory)
                .WithMany(p => p.Settings)
                .HasForeignKey(d => d.CurrentCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<WordCategory>(entity =>
        {
            entity.HasKey(e => new { e.CategoryId, e.WordId }); //Визначення складеного первинного ключа

            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.WordId).HasColumnName("WordID");

            entity.HasOne(d => d.Category)
                .WithMany()
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Word)
                .WithMany()
                .HasForeignKey(d => d.WordId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public override void Dispose()
    {
        base.Dispose();
        //logStream.Dispose();
    }
}
