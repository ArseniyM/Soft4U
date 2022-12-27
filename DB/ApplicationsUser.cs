using System;
using System.Collections.Generic;

namespace Soft4U.DB;

public partial class ApplicationsUser
{
    public long Id { get; set; }

    public long Iduser { get; set; }

    public long Idprogramm { get; set; }

    public long Idtype { get; set; }

    public long Idstatus { get; set; }

    public string? Comment { get; set; }

    public virtual Program IdprogrammNavigation { get; set; } = null!;

    public virtual Type IdtypeNavigation { get; set; } = null!;

    public virtual User IduserNavigation { get; set; } = null!;
    public virtual Status IdstatusNavigation { get; set; } = null!;
}
