using System;
using System.Collections.Generic;

namespace Soft4U.DB;

public partial class Role
{
    public long Id { get; set; }

    public string Rolename { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
