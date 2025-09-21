using ContactList.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Data.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<IdentityUser>(options)
{
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Category> Category { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Contact>(eb =>
        {
            eb.HasKey(c => c.Id);
            eb.Property(c => c.FirstName).IsRequired().HasMaxLength(100);
            eb.Property(c => c.LastName).IsRequired().HasMaxLength(100);
            eb.Property(c => c.Email).IsRequired();
            eb.Property(c => c.Phone).IsRequired();
            eb.Property(c => c.Birthday)
                .IsRequired()
                .HasColumnType("timestamp without time zone");
            eb.HasOne(c => c.Category)
                .WithMany()
                .HasForeignKey(c => c.CategoryId)
                .IsRequired();
            eb.HasOne(c => c.Subcategory)
                .WithMany()
                .HasForeignKey(c => c.SubcategoryId)
                .IsRequired(false);
        });
        builder.Entity<Category>(eb =>
        {
            eb.HasKey(c => c.Id);
            eb.Property(c => c.Name).IsRequired().HasMaxLength(100);
        });
    }
}