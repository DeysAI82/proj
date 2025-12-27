using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proj.Models.Entities;

public partial class RequestStatusHistory
{
    [Key]
    public int HistoryId { get; set; }

    public int RequestId { get; set; }
    public string Status { get; set; } = null!;
    public int ChangedByUserId { get; set; }
    public DateTime? ChangeDate { get; set; }
    public string? Notes { get; set; }

    public virtual User ChangedByUser { get; set; } = null!;
    public virtual RentalRequest Request { get; set; } = null!;
}
