using System;
using System.Collections.Generic;

namespace proj.Models.Entities;

public partial class Equipment
{
    public int EquipmentId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int CategoryId { get; set; }

    public int ManufacturerId { get; set; }

    public string? Model { get; set; }

    public int? Year { get; set; }

    public decimal HourlyRate { get; set; }

    public decimal DailyRate { get; set; }

    public decimal WeeklyRate { get; set; }

    public decimal MonthlyRate { get; set; }

    public string? Status { get; set; }

    public string? CurrentLocation { get; set; }

    public string? Specifications { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual EquipmentCategory Category { get; set; } = null!;

    public virtual ICollection<EquipmentImage> EquipmentImages { get; set; } = new List<EquipmentImage>();

    public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual ICollection<RentalRequest> RentalRequests { get; set; } = new List<RentalRequest>();
}
