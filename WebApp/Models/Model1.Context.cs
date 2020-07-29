﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ADMINWEBEntities : DbContext
    {
        public ADMINWEBEntities()
            : base("name=ADMINWEBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    
        //public virtual ObjectResult<Producto> USP_Categoria_Procedure(Nullable<int> id)
        //{
        //    var idParameter = id.HasValue ?
        //        new ObjectParameter("id", id) :
        //        new ObjectParameter("id", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Producto>("USP_Categoria", idParameter);
        //}
    
        //public virtual ObjectResult<Producto> GetCategoria(Nullable<int> id)
        //{
        //    var idParameter = id.HasValue ?
        //        new ObjectParameter("id", id) :
        //        new ObjectParameter("id", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Producto>("GetCategoria", idParameter);
        //}
    
        public virtual ObjectResult<Producto> GetCategoria(Nullable<int> id, MergeOption mergeOption)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Producto>("GetCategoria", mergeOption, idParameter);
        }
    
        public virtual ObjectResult<Producto> USP_Categoria_Procedure(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Producto>("USP_Categoria_Procedure", idParameter);
        }
    
        //public virtual ObjectResult<Producto> USP_Categoria_Procedure(Nullable<int> id, MergeOption mergeOption)
        //{
        //    var idParameter = id.HasValue ?
        //        new ObjectParameter("id", id) :
        //        new ObjectParameter("id", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Producto>("USP_Categoria_Procedure", mergeOption, idParameter);
        //}
    }
}
