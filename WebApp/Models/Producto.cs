//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Producto
    {
        public int id_Producto { get; set; }
        public string nombre { get; set; }
        public string categoria { get; set; }
        public Nullable<int> idcategoria { get; set; }
    
        public virtual Categoria Categoria1 { get; set; }
    }
}
