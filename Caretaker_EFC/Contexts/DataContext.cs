using Caretaker_EFC.MVVM.Models;
using Caretaker_EFC.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Caretaker_EFC.Contexts
{
    internal class DataContext : DbContext
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lirij\OneDrive\Skrivbord\Caretaker_EFC\Caretaker_EFC\Contexts\SQL_DB_Caretaker.mdf;Integrated Security=True;Connect Timeout=30";

        #region constructors

        public DataContext ()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        #endregion

        #region overrides

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #endregion

        //lägg in de olika listorna nedan 
        public DbSet<AddressEntity> Addresses { get; set; } = null!;
        public DbSet<EmployeeEntity> Employees { get; set; } = null!;
        public DbSet<ErrandEntity> Errands { get; set; } = null!;
        public DbSet<CommentEntity> Comments { get; set; } = null!;
        public DbSet<StatusEntity> Status { get; set; } = null!;
    }
}
