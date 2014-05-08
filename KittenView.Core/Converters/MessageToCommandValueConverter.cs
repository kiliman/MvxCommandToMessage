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
    public class MessageToCommandValueConverter : MvxValueConverter<string, ICommand>
    {
        protected override ICommand Convert(string typeName, Type targetType, object parameter, CultureInfo culture)
        {
            return new MvxCommand(() =>
            {
                var messenger = Mvx.Resolve<IMvxMessenger>();
                var message = (MvxMessage)Activator.CreateInstance(Type.GetType(typeName), this, parameter);
                messenger.Publish(message);
            });
        }
    }
}