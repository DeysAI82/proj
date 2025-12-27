using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proj.Models.Entities;

public partial class MaintenanceRecord
{
    [Key]
    public int MaintenanceId { get; set; }

    public int EquipmentId { get; set; }
    public string MaintenanceType { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Description { get; set; }
    public decimal? Cost { get; set; }
    public int? PerformedByUserId { get; set; }
    public string? Status { get; set; }
    public DateTime? CreatedDate { get; set; }

    public virtual Equipment Equipment { get; set; } = null!;
    public virtual User? PerformedByUser { get; set; }
}

