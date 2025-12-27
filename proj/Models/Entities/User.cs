using System;
using System.Collections.Generic;

namespace proj.Models.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Phone { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public bool? IsActive { get; set; }

    public User()
    {
        RegistrationDate = DateTime.Now;
    }

    public virtual ICollection<AppSetting> AppSettings { get; set; } = new List<AppSetting>();

    public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<RentalRequest> RentalRequests { get; set; } = new List<RentalRequest>();

    public virtual ICollection<RequestStatusHistory> RequestStatusHistories { get; set; } = new List<RequestStatusHistory>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public User Clone()
    {
        return new User
        {
            UserId = this.UserId,
            FirstName = this.FirstName,
            LastName = this.LastName,
            PasswordHash = this.PasswordHash,
            Email = this.Email,
            Phone = this.Phone,
            IsActive = this.IsActive
        };
    }
}
