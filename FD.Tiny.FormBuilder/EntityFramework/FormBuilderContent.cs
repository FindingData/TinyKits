using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder
{
    public class FormBuilderContent : DbContext
    {

        public FormBuilderContent() : base("name=FormDB")
        {
            Database.SetInitializer(new NullDatabaseInitializer<FormBuilderContent>());
        }

        public DbSet<ApiPO> Apis { get; set; }

        public DbSet<DbTablePO> Tables { get; set; }

        public DbSet<DbColumnPO> Columns { get; set; }

        public DbSet<FormPO> Forms { get; set; }

       // public DbSet<CategoryPO> Categories { get; set; }

        public DbSet<LabelPO> Labels { get; set; }

        public DbSet<FormStorePO> FormStores { get; set; }

        public DbSet<FormVariablePO> FormVariables { get; set; }


        public DbSet<DictionaryPO> Dictionaries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("FORM");
            base.OnModelCreating(modelBuilder);
        }
    }
}
