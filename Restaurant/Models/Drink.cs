
namespace Restaurant.Models
{
    //TODO: Drink class will be abstract class. Obtain and Serve methods should be abstract.
    public class Drink : IMenuItem
    {
        public Drinks drink { get; set; }

        public void Obtain() {}

        public void Serve() {}
    }
}
