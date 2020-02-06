namespace DisplayTree
{
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    public class catalogDb : DbContext
    {

        public catalogDb()
            : base("name=catalogDb")
        {
        }

        public DbSet<Catalog> CatalogSet { get; set; }
        public DbSet<Catalog_aggregate> CatalogAggrSet { get; set; }
        public DbSet<Catalog_model> CatalogModels { get; set; }
        public DbSet<Catalog_level> CatalogLevelSet { get; set; }

    }

    public class Catalog
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Catalog_aggregate> Catalog_aggregates { get; set; }
        public Catalog()
        {
            Catalog_aggregates = new List<Catalog_aggregate>();
        }
    }
    public class Catalog_aggregate
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public int CatalogId { get; set; }
        public virtual Catalog Catalog { get; set; }

        public virtual ICollection<Catalog_model> Catalog_models { get; set; }
        public Catalog_aggregate()
        {
            Catalog_models = new List<Catalog_model>();
        }

    }

    public class Catalog_model
    {
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public virtual int Catalog_aggregateId { get; set; }
        public virtual Catalog_aggregate catalog_aggr { get; set; }
    }

    public class Catalog_level
    {
        public int Id { get; set; }
        public int? Parent_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }


}