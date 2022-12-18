using System;
using System.Collections.Generic;

namespace Soft4U.DB;

public partial class Type
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ApplicationsUser> ApplicationsUsers { get; } = new List<ApplicationsUser>();
}
