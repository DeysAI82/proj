using System;
using System.Collections.Generic;

namespace proj.Models.Entities;

public partial class AppSetting
{
    public int SettingId { get; set; }

    public string SettingKey { get; set; } = null!;

    public string SettingValue { get; set; } = null!;

    public string? Description { get; set; }

    public string? DataType { get; set; }

    public int? UpdatedByUserId { get; set; }

    public DateTime? LastUpdated { get; set; }

    public virtual User? UpdatedByUser { get; set; }
}
