﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookShop.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TestDBEntities : DbContext
    {
        public TestDBEntities()
            : base("name=TestDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<author> authors { get; set; }
        public virtual DbSet<banner> banners { get; set; }
        public virtual DbSet<book> books { get; set; }
        public virtual DbSet<cart> carts { get; set; }
        public virtual DbSet<cart_item> cart_item { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<detail_receipt> detail_receipt { get; set; }
        public virtual DbSet<favourite> favourites { get; set; }
        public virtual DbSet<favourite_item> favourite_item { get; set; }
        public virtual DbSet<image_products> image_products { get; set; }
        public virtual DbSet<order_detail> order_detail { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<publicsher> publicshers { get; set; }
        public virtual DbSet<receipt> receipts { get; set; }
        public virtual DbSet<review> reviews { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<users_roles> users_roles { get; set; }
        public virtual DbSet<warehouse> warehouses { get; set; }
    }
}
