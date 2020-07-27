using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zendid.Models;
using Zendid;
using Zendid.Views;

namespace Zendid.ValueConverters
{
    /// <summary>
    /// converts the application page to an actual view/page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Find the appropriate page
            switch ((ApplicationPageModel)value)
            {
                case ApplicationPageModel.Login:
                    return new LoginView();

                case ApplicationPageModel.Registration:
                    return new RegisterView();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        //we dont need to convert back, so we dont need to create this
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
