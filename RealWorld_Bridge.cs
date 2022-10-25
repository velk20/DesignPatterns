using System;

/*
 Използвайки шаблона за дизайм Bridge напишете програма на C#, която
да има клас RemoteControler с функционалности за намаляване и увеличаване
на звука, за намаляване и увеличаване на канала и за включване и изключване.
Добавете и още 1 клас AdvancedRemoteControler, който разширява RemoteControler
и добавя функция за Mute(спиране на звука). Всички тези функционалности трябва да са приложими
върху интерфейса Device, който бива наследен от класовете Radio и TV
 */

namespace Bridge
{
   
    //имплементациите на какво може да прави едно устройство
    class RemoteControler
    {
        protected Device device;
       
        public RemoteControler(Device device)
        {
            this.device = device;
        }

        public void togglePower()
        {
            if (device.isEnabled())
            {
                device.disable();
               
            }
            else
            {
                device.enable();
               
            }
        }

        public string volumeDown()
        {
            device.setVolume(device.getVolume() - 5);
            return "Звукът на "+device.GetType().Name+" е намален и в момента е " + device.getVolume()+" звук.";
        }

        public string volumeUp()
        {
            device.setVolume(device.getVolume() + 5);
            return "Звукът на " + device.GetType().Name + " е увеличен и в момента е " + device.getVolume() + " звук.";
        }

        public string channelDown()
        {
            device.setChannel(device.getChannel() - 1);
            return "Каналът на "+device.GetType().Name +" е намален и сега е " + device.getChannel();
        } 
        public string channelUp()
        {
            device.setChannel(device.getChannel() + 1);
            return "Каналът на " + device.GetType().Name + " е увеличен и сега е " + device.getChannel();

        }
    }

    //класа разширява функционалността на горния клас
    class AdvancedRemoteControler : RemoteControler
    {
        public AdvancedRemoteControler(Device implementation) : base(implementation)
        {
        }

        public string mute()
        {
            device.setVolume(0);
            return String.Format("{0} е с изключен звук.",base.device.GetType().Name);
        }
    }

    //интерфейса държи само какво трябва всеки наследник да поддържа като функционалност
    public interface Device
    {
        bool isEnabled();
        void enable();
        void disable();
        int getVolume();
        void setVolume(int volume);
        int getChannel();
        void setChannel(int channel);
    }

    //Конкретен клас TV
    class Tv : Device
    {
        public bool isPowered;
        public int volume;
        public int channel;

        public Tv()
        {
            this.isPowered = false;
            this.volume = 25;
            this.channel = 5;
        }

        public void disable()
        {
            this.isPowered = false;
            Console.WriteLine( this.GetType().Name + " се изклюва.");
        }

        public void enable()
        {
            this.isPowered = true;
            Console.WriteLine( this.GetType().Name + " се стартира.");
        }

        public int getChannel()
        {
            return this.channel;
        }

        public int getVolume()
        {
            return this.volume;
        }

        public bool isEnabled()
        {
            return isPowered;
        }

        public void setChannel(int channel)
        {
            this.channel = channel;
        }

        public void setVolume(int volume)
        {
            this.volume = volume;
        }

    }

    //Конкретен клас Radio
    class Radio : Device
    {
        public bool isPowered;
        public int volume;
        public int channel;

        public Radio()
        {
            this.isPowered = false;
            this.volume = 20;
            this.channel = 105;
        }

        public void disable()
        {
            this.isPowered = false;
            Console.WriteLine(this.GetType().Name + " се изклюва.");
        }

        public void enable()
        {
            this.isPowered = true;
            Console.WriteLine( this.GetType().Name + " се стартира.");
        }

        public int getChannel()
        {
            return this.channel;
        }

        public int getVolume()
        {
            return this.volume;
        }

        public bool isEnabled()
        {
            return isPowered;
        }

        public void setChannel(int channel)
        {
            this.channel = channel;
        }

        public void setVolume(int volume)
        {
            this.volume = volume;
        }
    }

    //класа Клиент държи функционалност за включване и изключване
    class Client
    {
        public void ClientCode(RemoteControler abstraction)
        {
            abstraction.togglePower();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            RemoteControler controler =  new RemoteControler(new Tv());
            client.ClientCode(controler) ;
            Console.WriteLine(controler.volumeUp());
            Console.WriteLine(controler.channelDown());
            client.ClientCode(controler);


            Console.WriteLine();

            AdvancedRemoteControler advancedControler = new AdvancedRemoteControler(new Radio());
            client.ClientCode(advancedControler);
            Console.WriteLine(advancedControler.volumeUp());
            Console.WriteLine(advancedControler.channelDown());
            Console.WriteLine(advancedControler.mute());
            client.ClientCode(advancedControler);

        }
    }
}