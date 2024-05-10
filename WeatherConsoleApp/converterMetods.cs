using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherConsoleApp
{
    internal class converterMetods
    {

        int convertTofarenheits(double celsiusValue)
        {
            double farenheitValue = 0;
            farenheitValue = (celsiusValue * 1.8) + 32;
            return (int)farenheitValue;
        }

    }
}
