

using Restaurant.Moels;
using System;

namespace Restaurant.Models
{
    
    public class Server
    {
        private Cook cook;
        private string[] resultOfCooks;
        private TableRequests tableRequests;
        Boolean sendedToCook = false;
        Boolean served = false;

        public Server()
        {
            cook = new Cook();
            tableRequests = new TableRequests();
        }

        public void Receive(int chickenQuantity, int eggQuantity, object drink)
        {
            if (chickenQuantity > 0)
            {
                var chicken = new Chicken(chickenQuantity);
                tableRequests.Add(chicken);
            }
            else
            {
                tableRequests.Add(null);
            }
            
            if (eggQuantity > 0)
            {
                var egg = new Egg(eggQuantity);
                tableRequests.Add(egg);
            }
            else
            {
                tableRequests.Add(null);
            }

            if (drink is Drinks)
            {
                var egg = new Drink() { drink = (Drinks)drink };
                tableRequests.Add(egg);
            }
            else
            {
                tableRequests.Add(null);
            }
        }

        public void SendToCook()
        {
            if (sendedToCook)
            {
                throw new Exception("already cooked!");
            }
            sendedToCook = true;
            resultOfCooks = cook.Process(tableRequests);
        }

        public string[] Serve()
        {
            if (served)
            {
                throw new Exception("Customers already served!");
            }
            if (!sendedToCook)
            {
                throw new Exception("You didn't cook!");
            }
            served = true;
            return resultOfCooks;
        }
    }

    public enum Drinks : short
    {
        Tea,
        Juice,
        RC_Cola,
        Coca_Cola
    }
}
