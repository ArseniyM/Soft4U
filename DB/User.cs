using System;
using System.Collections.Generic;

namespace Soft4U.DB;

public partial class User
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Middlename { get; set; }

    public byte[]? Foto { get; set; }

    public long Role { get; set; }

    public virtual ICollection<ApplicationsUser> ApplicationsUsers { get; } = new List<ApplicationsUser>();

    public virtual Role RoleNavigation { get; set; } = null!;

    public virtual ICollection<UserProgram> UserPrograms { get; } = new List<UserProgram>();
}
