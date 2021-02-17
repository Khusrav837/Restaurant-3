

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
        private int customerIndex = 0;

        public Server()
        {
            cook = new Cook();
            tableRequests = new TableRequests();
        }

        public Egg Receive(int chickenQuantity, int eggQuantity, object drink)
        {
            if (customerIndex == 8)
            {
                throw new Exception("All customers already gave order!");
            }
            IMenuItem chickenMenuItem = null;
            if (chickenQuantity > 0)
            {
                chickenMenuItem = new Chicken(chickenQuantity);
                
            }//TODO: Do we weed "else" parts?
            tableRequests.Add(customerIndex, chickenMenuItem);

            IMenuItem eggMenuItem = null;
            if (eggQuantity > 0)
            {
                eggMenuItem = new Egg(eggQuantity);
            }
            tableRequests.Add(customerIndex, eggMenuItem);

            IMenuItem drinkMenuItem = null;
            if (drink is Drinks)
            {
                var d = (Drinks)drink;
                if (d == Drinks.Coca_Cola)
                {
                    drinkMenuItem = new Coca_Cola();
                } 
                else if (d == Drinks.Juice)
                {
                    drinkMenuItem = new Juice();
                } 
                else if (d == Drinks.RC_Cola)
                {
                    drinkMenuItem = new RC_Cola();
                }
                else if (d == Drinks.Tea)
                {
                    drinkMenuItem = new Tea();
                }
            }
            tableRequests.Add(customerIndex, drinkMenuItem);
            customerIndex++;
            if (eggMenuItem is Egg)
            {
                return (Egg)eggMenuItem;
            }
            return null;
        }

        public void SendToCook()
        {
            if (sendedToCook)
            {
                throw new Exception("already cooked!");
            }
            sendedToCook = true;
            cook.Process(tableRequests);
            resultOfCooks = new string[customerIndex];
            for (int i = 0; i < customerIndex; i++)
            {
                var orders = tableRequests[i + 1];
                var ch = 0;
                var e = 0;
                Type t = null;
                if (orders == null)
                {
                    continue;
                }
                for (int j = 0; j < orders.Length; j++)
                {
                    if (orders[j] is Chicken)
                    {
                        var order = (Chicken)orders[0];
                        ch = order.GetQuantity();
                    } 
                    else if (orders[j] is Egg)
                    {
                        var order = (Egg)orders[1];
                        e = order.GetQuantity();
                    } 
                    else if (orders[j] is IMenuItem)
                    {
                        t = orders[j].GetType();
                    }
                }

                resultOfCooks[i] = $"Customer {i} is served {ch} chicken, {e} egg, ";

                if (t != null)
                {
                    resultOfCooks[i] += $"{t}";
                }
                else
                {
                    resultOfCooks[i] += "no drinks";
                }
            }
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

    //TODO: In this project we should have classes for Tea, Juice, RC-Cola and CocaCola instead of enum
  public enum Drinks : short
    {
        Tea,
        Juice,
        RC_Cola,
        Coca_Cola
    }
}
