using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proj.Models.Entities;

public partial class EquipmentImage
{
    [Key]
    public int ImageId { get; set; }

    public int EquipmentId { get; set; }
    public string ImageUrl { get; set; } = null!;
    public bool? IsPrimary { get; set; }
    public DateTime? UploadDate { get; set; }

    public virtual Equipment Equipment { get; set; } = null!;
}
