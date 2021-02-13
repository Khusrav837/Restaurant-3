
namespace Restaurant.Models
{
    //TODO: Food class should be abstract class, because we don't need instance of this class. Cook, Obtain and Serve methods should be abstract.
    public class Food : IMenuItem
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        protected int Quantity { get; set; }

        public virtual void Cook() { }

        public int GetQuantity()
        {
            return this.Quantity;
        }

        public void Obtain() {}

        public void Serve() {}
    }
}
