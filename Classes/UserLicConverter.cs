using Soft4U.DB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Soft4U.Classes
{
    internal class UserLicConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            using (Soft4UDbContext context = new Soft4UDbContext())
            {
                var userPrograms = context.UserPrograms.Where(e => e.Iduser == (long)value).ToList();
                List<UserProgramList> list = new List<UserProgramList>();
                foreach (var item in userPrograms)
                {
                    list.Add(new UserProgramList()
                    {
                        Name = context.Programs.Where(e => e.Id == item.Idprograms).Select(e => e.Name).First(),
                        DateLicens = item.DateLicens,
                        DateLicEnd = item.DateLicEnd,
                        Discription = context.Programs.Where(e => e.Id == item.Idprograms).Select(e => e.Discription).First()
                    });
                }
               return list;
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
