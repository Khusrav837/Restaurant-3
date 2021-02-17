
namespace Restaurant.Models
{
    //TODO: Food class should be abstract class, because we don't need instance of this class. Cook, Obtain and Serve methods should be abstract.
    public abstract class Food : IMenuItem
    {

        protected int Quantity { get; set; }

        public abstract void Cook();

        public int GetQuantity()
        {
            return this.Quantity;
        }

        public abstract void Obtain();

        public abstract void Serve();
    }
}
