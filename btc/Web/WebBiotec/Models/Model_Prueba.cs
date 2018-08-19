namespace WebBiotec.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model_Prueba : DbContext
    {
        public Model_Prueba()
            : base("name=Model_Prueba")
        {
        }

        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
