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
    class IdStatusNameConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            using(Soft4UDbContext context = new Soft4UDbContext())
            {
                return context.Statuses.Where(e => e.Id == (long)value).Select(e => e.StatusName).First();
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
