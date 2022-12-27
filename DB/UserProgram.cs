using System;
using System.Collections.Generic;
using System.Windows.Controls.Ribbon.Primitives;

namespace Soft4U.DB;

public partial class UserProgram
{
    public long Id { get; set; }

    public long Iduser { get; set; }

    public long Idprograms { get; set; }

    public string DateLicens { get; set; } = null!;

    public string DateLicEnd { get; set; } = null!;

    public virtual Program IdprogramsNavigation { get; set; } = null!;

    public virtual User IduserNavigation { get; set; } = null!;
}
