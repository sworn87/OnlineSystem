using Ivysoft.OnlineSystem.Models.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ivysoft.OnlineSystem.Models
{
    public partial class EmployeeTerritory : DataModel
    {
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }

        [Column("TerritoryID")]
        [MaxLength(20)]
        public string TerritoryId { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("EmployeeTerritories")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("TerritoryId")]
        [InverseProperty("EmployeeTerritories")]
        public virtual Territory Territory { get; set; }
    }
}
