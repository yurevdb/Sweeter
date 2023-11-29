using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace Sweeter.Client.WPF
{
	public class BooleanToForegroundConverter : ValueConverter<BooleanToForegroundConverter>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is not bool)
				return Brushes.Black;

			return (bool)value ? Application.Current.Resources["SuccessBrush"] : Application.Current.Resources["FailureBrush"];
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
