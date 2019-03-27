namespace AnimalRegistration
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AnimalDB : DbContext
    {
        public AnimalDB()
            : base("name=AnimalDB1")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Amphibian> Amphibians { get; set; }
        public virtual DbSet<animal> animals { get; set; }
        public virtual DbSet<Arthropod> Arthropods { get; set; }
        public virtual DbSet<Bird> Birds { get; set; }
        public virtual DbSet<Fish> Fish { get; set; }
        public virtual DbSet<Mammal> Mammals { get; set; }
        public virtual DbSet<Reptile> Reptiles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<animal>()
                .HasMany(e => e.Amphibians)
                .WithOptional(e => e.animal)
                .HasForeignKey(e => e.animal_animalID);

            modelBuilder.Entity<animal>()
                .HasMany(e => e.Arthropods)
                .WithOptional(e => e.animal)
                .HasForeignKey(e => e.animal_animalID);

            modelBuilder.Entity<animal>()
                .HasMany(e => e.Birds)
                .WithOptional(e => e.animal)
                .HasForeignKey(e => e.animal_animalID);

            modelBuilder.Entity<animal>()
                .HasMany(e => e.Fish)
                .WithOptional(e => e.animal)
                .HasForeignKey(e => e.animal_animalID);

            modelBuilder.Entity<animal>()
                .HasMany(e => e.Mammals)
                .WithOptional(e => e.animal)
                .HasForeignKey(e => e.animal_animalID);

            modelBuilder.Entity<animal>()
                .HasMany(e => e.Reptiles)
                .WithOptional(e => e.animal)
                .HasForeignKey(e => e.animal_animalID);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
