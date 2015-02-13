# MvxCommandToMessage
Sample showing how to use a value converter to convert a command into a message

```c#
public class CommandToMessageValueConverter : MvxValueConverter<string, ICommand>
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
```

The message class. Note the _item_ parameter will be an instance of the list item model.

```c#
public class KittenAcceptedMessage : MvxMessage
{
	public KittenAcceptedMessage(object sender, object item) : base(sender)
	{
		Kitten = (Kitten)item;
	}

	public Kitten Kitten { get; set; }
}
```  

Subscribe to the message in your ViewModel and delegate it to a command, or simply handle it inline.

```c#
public FirstViewModel(IKittenGenesisService service, IMvxMessenger messenger)
{
	...

	_messenger.Subscribe<KittenAcceptedMessage>(message => KittenAcceptedCommand.Execute(message.Kitten));
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
```

The layout for the ListItem view binds the _Click_ event to the _CommandToMessage_ value converter. The first parameter is
the message type, and the second parameter is (.) which represents the current list item model. This is passed into
the constructor of the message class.

```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
	xmlns:local="http://schemas.android.com/apk/res-auto"
	android:orientation="horizontal"
	android:layout_width="fill_parent"
	android:layout_height="fill_parent">
	<Mvx.MvxImageView
		android:layout_width="75dp"
		android:layout_height="75dp"
		android:layout_margin="10dp"
		local:MvxBind="ImageUrl ImageUrl; Click CommandToMessage('KittenView.Core.Messages.KittenAcceptedMessage', .)" />
		
		...
		
</LinearLayout>
```
