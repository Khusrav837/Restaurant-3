
namespace Restaurant.Models
{
    //TODO: Drink class will be abstract class. Obtain and Serve methods should be abstract.
    public class Tea : IMenuItem
    {

        public void Obtain() {}

        public void Serve() {}
    }

    public class Juice : IMenuItem
    {

        public void Obtain() { }

        public void Serve() { }
    }

    public class RC_Cola : IMenuItem
    {

        public void Obtain() { }

        public void Serve() { }
    }

    public class Coca_Cola : IMenuItem
    {

        public void Obtain() { }

        public void Serve() { }
    }
}
