using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Moels
{
    public class Egg : Food, IDisposable
    {
        private int _quality;

        public int Quality
        {
            get { return _quality; }
            private set { _quality = value; }
        }

        private Boolean _isDisposed = false;

        private Boolean IsDisposed
        {
            get => _isDisposed;
            set => _isDisposed = value;
        }


        public Egg(int quantity) : base(quantity)
        {
            Random rand = new Random();
            this.Quality = rand.Next(101);
        }

        public int GetQuality()
        {
            return this.Quality;
        }

        public void Crack()
        {
            if (this.Quality < 25)
            {
                throw new Exception("Quality is less!");
            }
        }

        public override void Cook()
        {
            base.Cook();
        }

        public void DiscardShell() { }

        protected void Dispose(bool disposing)
        {
            if(!this.IsDisposed)
            {
                if(disposing)
                {
                    Console.WriteLine("Cleaning!");
                }
                Console.WriteLine("Cleaning!");
                this.IsDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Egg()
        {
            this.Dispose(false);
        }
    }
}
