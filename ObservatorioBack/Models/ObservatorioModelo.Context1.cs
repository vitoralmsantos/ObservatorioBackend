﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ObservatorioBack.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ObservatorioEntities : DbContext
    {
        public ObservatorioEntities()
            : base("name=ObservatorioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Detento> Detentos { get; set; }
        public virtual DbSet<Acompanhamento> Acompanhamentos { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Resposta> Respostas { get; set; }
        public virtual DbSet<Processo> Processos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}