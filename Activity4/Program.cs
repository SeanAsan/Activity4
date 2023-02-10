using System;
using System.Runtime.CompilerServices;

namespace Activity4
{
    //interface
    interface IVideoGameRental
    {
        //properties
        string VGNames
        {
            get;
            set;
        }
    }

    //This prints out a list of horror games available
    class HorrorGames : IVideoGameRental
    {
        private string _vgnames = "Resident Evil, Layers of Fear, and Soma";
        public string VGNames
        {
            get { return _vgnames; }
            set { _vgnames = value; }
        }
    }

    //Events 

    class Message
    {
        //delegate
        public delegate void MessageEventHandler(object source, EventArgs args);

        //declares an event 
        public event MessageEventHandler Messaged;
        public void Prompt()
        {
            Console.WriteLine("Thank you for shopping!");
            Thread.Sleep(3000);

            OnMessaged();
        }

        protected virtual void OnMessaged()
        {
            if (Messaged != null)
            {
                Messaged(this, EventArgs.Empty);
            }
        }
    }

    class Revist
    {
        public void OnMessaged (object source, EventArgs args)
        {
            Console.WriteLine("Please! Comeback Soon!");
        }
    }
       


    class Program
    {
        static void Main(string[] args)
        {
            HorrorGames games = new HorrorGames();
            Console.WriteLine(games.VGNames);
            var message = new Message();
            var revisit = new Revist();
            message.Messaged += revisit.OnMessaged;
            message.Prompt();
            Console.ReadKey();
        }
    }
}
