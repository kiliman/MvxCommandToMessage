using System;
using System.Globalization;
using System.Windows.Input;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Converters;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using KittenView.Core.Services;

namespace KittenView.Core.Converters
{
    public class KittenAcceptedMessageValueConverter : MvxValueConverter<Kitten, ICommand>
    {
        protected override ICommand Convert(Kitten kitten, Type targetType, object parameter, CultureInfo culture)
        {
            return new MvxCommand(() =>
            {
                var messenger = Mvx.Resolve<IMvxMessenger>();
                var message = new KittenAcceptedMessage(this, kitten);
                messenger.Publish(message);
            });
        }
    }
}