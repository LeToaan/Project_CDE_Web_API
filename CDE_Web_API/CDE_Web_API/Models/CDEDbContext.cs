using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CDE_Web_API.Models;

public class CDEDbContext : DbContext
{
    public CDEDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Tokent> Tokents { get; set; }
    public DbSet<UserList> UserLists { get; set; }
    public DbSet<Media> Medias { get; set; }
    public DbSet<Area> Areas { get; set; }
    public DbSet<PositionGroup> PositionGroups { get; set; }
    public DbSet<PositionTitle> PositionTitles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<PermissionModule> PermissionModules { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<Distributor> Distributors { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<NotifiUser> NotifiUsers { get; set; }
    public DbSet<SurveyDetail> SurveyDetails { get; set; }
    public DbSet<SurveyRequest> SurveyRequests { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Rate> Rates { get; set; }
    public DbSet<CMS> CMSs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>()
            .HasOne<Account>(t => t.ReportAccount)
            .WithMany()
            .HasForeignKey(t => t.Report)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Task>()
            .HasOne<Account>(t => t.ImplementAccount)
            .WithMany()
            .HasForeignKey(t => t.Implement)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<SurveyDetail>()
            .HasOne<SurveyRequest>(t => t.SurveyRequest)
            .WithMany()
            .HasForeignKey(t => t.Id)
            .OnDelete(DeleteBehavior.NoAction);

        base.OnModelCreating(modelBuilder);
    }
}
