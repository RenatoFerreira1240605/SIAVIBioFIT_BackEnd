using Microsoft.EntityFrameworkCore;
using SIAVIBioFITBackEnd;
using SIAVIBioFITBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIAVIBioFITBackEnd.Data
{
    public class BioFitContext : DbContext
    {
        public BioFitContext(DbContextOptions<BioFitContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Session> Sessions => Set<Session>();
        public DbSet<Exercise> Exercises => Set<Exercise>();
        public DbSet<ExerciseLog> ExerciseLogs => Set<ExerciseLog>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Força todos os nomes a lowercase (tabelas e colunas)
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName()?.ToLower());

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.Name.ToLower());
                }

                foreach (var key in entity.GetKeys())
                {
                    key.SetName(key.GetName()?.ToLower());
                }

                foreach (var fk in entity.GetForeignKeys())
                {
                    fk.SetConstraintName(fk.GetConstraintName()?.ToLower());
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.SetDatabaseName(index.GetDatabaseName()?.ToLower());
                }
            }
        }

    }
}
