using Android.Content;
using Android.Widget;
using KittenView.Core.Plugins;

namespace KittenView.Droid.Plugins
{
    public class ToastPlugin : IToastPlugin
    {
        private readonly Context _context;

        public ToastPlugin(Context context)
        {
            _context = context;
        }

        public void Show(string text)
        {
            Toast.MakeText(_context, text, ToastLength.Short).Show();
        }

        public void ShowLong(string text)
        {
            Toast.MakeText(_context, text, ToastLength.Long).Show();
        }
    }
}