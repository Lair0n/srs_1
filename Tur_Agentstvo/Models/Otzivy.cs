//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tur_Agentstvo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Otzivy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Otzivy()
        {
            this.Tur = new HashSet<Tur>();
        }
    
        public int ID_Otziva { get; set; }
        public string Otziv { get; set; }
        public System.DateTime Data_napisania { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tur> Tur { get; set; }
    }
}