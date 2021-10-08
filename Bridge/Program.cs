using System;

namespace Bridge
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Tv tv = new Tv();
            Radio radio = new Radio();
            RemoteControl remote = new RemoteControl(tv);

            remote.ChannelUp();
            remote.ChannelDown();
            remote.VolumeUp();
            remote.VolumeDown();
            remote.TogglePower();

            Console.WriteLine($"Before: {tv.IsEnabled}" );
            remote.TogglePower();
            Console.WriteLine($"After: {tv.IsEnabled}");


        }
    }

    interface IDevice
    {
        bool IsEnabled { get; set; }
        short Volume { get; set; }
        short Channel { get; set; }
        void Enable();
        void Disable();
    }

    class Tv : IDevice
    {
        public bool IsEnabled { get; set; }

        public short Volume { get; set; }

        public short Channel { get; set; }


        public void Enable() => IsEnabled = true;

        public void Disable() => IsEnabled = false;
    }

    class Radio : IDevice
    {
        public bool IsEnabled { get; set; }

        public short Volume { get; set; }

        public short Channel { get; set; }


        public void Enable() => IsEnabled = true;

        public void Disable() => IsEnabled = false;
    }

    class RemoteControl
    {
        protected IDevice Device { get; set; }

        public RemoteControl(IDevice device)
        {
            Device = device;
        }

        public void TogglePower()
        {
            if (Device.IsEnabled) Device.Disable();
            else Device.Enable();
        }

        public void VolumeUp() => Device.Volume += 10;
        public void VolumeDown() => Device.Volume -= 10;

        public void ChannelUp() => Device.Channel++;
        public void ChannelDown() => Device.Channel--;
    }
}
