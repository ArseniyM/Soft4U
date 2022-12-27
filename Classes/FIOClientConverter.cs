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
    class FIOClientConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            using (Soft4UDbContext context = new Soft4UDbContext())
            {
               return context.Users.Where(e => e.Id == (long)value).Select(e => e.Surname + " " + e.Name + " " + e.Middlename).First();
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
