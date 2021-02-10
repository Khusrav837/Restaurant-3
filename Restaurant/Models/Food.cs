
namespace Restaurant.Models
{
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
