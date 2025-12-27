using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proj.Models.Entities;

public partial class EquipmentCategory
{
    [Key]
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;
    public string? Description { get; set; }
    public int? ParentCategoryId { get; set; }

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
    public virtual ICollection<EquipmentCategory> InverseParentCategory { get; set; } = new List<EquipmentCategory>();
    public virtual EquipmentCategory? ParentCategory { get; set; }
}
