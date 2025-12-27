using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proj.Models.Entities;

public partial class RentalRequest
{
    [Key]
    public int RequestId { get; set; }

    public int ClientId { get; set; }
    public int EquipmentId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string RentalType { get; set; } = null!;
    public decimal? TotalCost { get; set; }
    public string? Status { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string? Notes { get; set; }

    public virtual User Client { get; set; } = null!;
    public virtual Equipment Equipment { get; set; } = null!;
    public virtual ICollection<RequestStatusHistory> RequestStatusHistories { get; set; } = new List<RequestStatusHistory>();
}
