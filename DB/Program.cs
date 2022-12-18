using System;
using System.Collections.Generic;

namespace Soft4U.DB;

public partial class Program
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long License { get; set; }

    public string Discription { get; set; } = null!;

    public double Cost { get; set; }

    public virtual ICollection<ApplicationsUser> ApplicationsUsers { get; } = new List<ApplicationsUser>();

    public virtual ICollection<UserProgram> UserPrograms { get; } = new List<UserProgram>();
}
