using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Drawing;


namespace FamousKiwisApp.Converters
{
    internal class Base64ToBitmapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string base64String = (string)value;

            var bytes = System.Convert.FromBase64String(base64String);
            //var bytes = Image.FromStream(new MemoryStream(Convert.FromBase64String(base64String)));

            using (var stream = new MemoryStream(bytes))
            {
                return BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }


            //return StringToBitmap(base64String);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


        private BitmapFrame StringToBitmap(string str)
        {

            var bytes = System.Convert.FromBase64String(str);
            //var bytes = Image.FromStream(new MemoryStream(Convert.FromBase64String(base64String)));

            using (var stream = new MemoryStream(bytes))
            {
                return BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }
    }
}
