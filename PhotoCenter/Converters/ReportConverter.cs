using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PhotoCenter.Converters
{
    class ReportConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            List<int> CountOrder = values[0] as List<int>;
            List<string> NameWorker = values[1] as List<string>;
            if (CountOrder == null || NameWorker == null) return null;

            SeriesCollection series = new SeriesCollection();
            for (int i = 0; i < CountOrder.Count; i++)
            {
                series.Add(new PieSeries {Title = "Сотрудник " + NameWorker[i] + " принял заказов: " + CountOrder[i].ToString(), Values = new ChartValues<int> { CountOrder[i]} });
            }
            return series;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
