//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCKutuphane.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kitap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kitap()
        {
            this.Hareket = new HashSet<Hareket>();
        }
    
        public int Id { get; set; }
        public string Ad { get; set; }
        public Nullable<byte> Kategori { get; set; }
        public Nullable<int> Yazar { get; set; }
        public string Basimyil { get; set; }
        public string Yayinevi { get; set; }
        public string Sayfa { get; set; }
        public Nullable<bool> Durum { get; set; }
        public string KitapResim { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hareket> Hareket { get; set; }
        public virtual Kategori Kategori1 { get; set; }
        public virtual Yazar Yazar1 { get; set; }
    }
}
