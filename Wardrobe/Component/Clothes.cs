//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wardrobe.Component
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clothes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clothes()
        {
            this.Offer = new HashSet<Offer>();
        }
    
        public int id { get; set; }
        public int TypeId { get; set; }
        public int ColourId { get; set; }
        public string Size { get; set; }
        public byte[] Photo { get; set; }
    
        public virtual CollorId CollorId { get; set; }
        public virtual Type Type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Offer> Offer { get; set; }
    }
}