using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft4U.DB
{
    public partial class Status
    {
        public long Id { get; set; }
        public string StatusName { get; set; } = null!;
        public virtual ICollection<ApplicationsUser> ApplicationsUsers { get; } = new List<ApplicationsUser>();
    }
}
