//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XnxGaming.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Match
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Match()
        {
            this.GameStates = new HashSet<GameState>();
            this.MatchDetails = new HashSet<MatchDetail>();
            this.PlayerStats = new HashSet<PlayerStat>();
        }
    
        public int Id { get; set; }
        public Nullable<int> TenantId { get; set; }
        public string CompanyId { get; set; }
        public string CreateUserId { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string EditUserId { get; set; }
        public Nullable<System.DateTime> EditTime { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] Timestamp { get; set; }
        public Nullable<int> Team1Id { get; set; }
        public bool IsActive { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
        public Nullable<int> Team2Id { get; set; }
        public Nullable<bool> IsStart { get; set; }
        public Nullable<bool> IsFinished { get; set; }
        public Nullable<int> ApprovalCounter { get; set; }
        public int Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GameState> GameStates { get; set; }
        public virtual Team Team { get; set; }
        public virtual Team Team1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatchDetail> MatchDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlayerStat> PlayerStats { get; set; }
    }
}
