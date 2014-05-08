using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Plugins.Messenger;
using KittenView.Core.Services;

namespace KittenView.Core.Converters
{
    public class KittenAcceptedMessage : MvxMessage
    {
        public KittenAcceptedMessage(object sender, Kitten kitten) : base(sender)
        {
            Kitten = kitten;
        }

        public Kitten Kitten { get; set; }
    }

}
