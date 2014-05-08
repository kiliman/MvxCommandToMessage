using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Plugins.Messenger;
using KittenView.Core.Services;

namespace KittenView.Core.Messages
{
    public class KittenAcceptedMessage : MvxMessage
    {
        public KittenAcceptedMessage(object sender, object item)
            : base(sender)
        {
            Kitten = (Kitten)item;
        }

        public Kitten Kitten { get; set; }
    }

}
