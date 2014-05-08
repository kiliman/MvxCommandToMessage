using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using KittenView.Core.Plugins;
using KittenView.Core.Services;
using KittenView.Core.Messages;

namespace KittenView.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        private readonly IMvxMessenger _messenger;

        public FirstViewModel(IKittenGenesisService service, IMvxMessenger messenger)
        {
            _messenger = messenger;
            var newList = new List<Kitten>();
            for (var i = 0; i < 100; i++)
            {
                var newKitten = service.CreateNewKitten(i.ToString());
                newList.Add(newKitten);
            }

            _messenger.Subscribe<KittenAcceptedMessage>(message => KittenAcceptedCommand.Execute(message.Kitten));

            Kittens = newList;
        }

        private List<Kitten> _kittens;
        public List<Kitten> Kittens
        {
            get { return _kittens; }
            set { _kittens = value; RaisePropertyChanged(() => Kittens); }
        }

        private MvxCommand<Kitten> _kittenAcceptedCommand;
        public ICommand KittenAcceptedCommand
        {
            get
            {
                _kittenAcceptedCommand = _kittenAcceptedCommand ?? new MvxCommand<Kitten>(kitten =>
                {
                    var toast = Mvx.Resolve<IToastPlugin>();
                    toast.Show(string.Format("You accepted {0}", kitten.Name));
                });
                return _kittenAcceptedCommand;
            }
        }

    }
}
