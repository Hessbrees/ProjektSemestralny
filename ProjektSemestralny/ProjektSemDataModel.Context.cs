﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjektSemestralny
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProjektSemestralnyDBEntities : DbContext
    {
        public ProjektSemestralnyDBEntities()
            : base("name=ProjektSemestralnyDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AnimationBoard400> AnimationBoard400 { get; set; }
        public virtual DbSet<AnimationBoard640> AnimationBoard640 { get; set; }
        public virtual DbSet<AnimationBoard800> AnimationBoard800 { get; set; }
        public virtual DbSet<BoardColor> BoardColors { get; set; }
        public virtual DbSet<DefaultColor> DefaultColors { get; set; }
        public virtual DbSet<GlobalColor> GlobalColors { get; set; }
        public virtual DbSet<GlobalValue> GlobalValues { get; set; }
        public virtual DbSet<NewColor> NewColors { get; set; }
        public virtual DbSet<NewProject> NewProjects { get; set; }
        public virtual DbSet<SquareFill> SquareFills { get; set; }
    }
}
