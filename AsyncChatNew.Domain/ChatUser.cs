//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AsyncChatNew.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChatUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChatUser()
        {
            this.Incidents = new HashSet<Incident>();
            this.Incidents1 = new HashSet<Incident>();
            this.Messages = new HashSet<Message>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Surname { get; set; }
        public Nullable<byte> SupportLevel { get; set; }
        public string AspNetUserId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Incident> Incidents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Incident> Incidents1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }
    }
}
