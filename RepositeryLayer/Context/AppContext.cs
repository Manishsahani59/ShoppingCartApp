using CommonLayer.ModelDB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;


namespace RepositeryLayer.Context
{
    public class AppContext : DbContext
    {
        public AppContext() : base("ShoppingcartApplication")
        { }
        public DbSet<ProductDetails> Products { get; set; }

    }
}
