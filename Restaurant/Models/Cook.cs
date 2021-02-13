using Restaurant.Moels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class Cook
    {
        public string[] Process(TableRequests table)
        {
            var chickens = table[typeof(Chicken)];
            for(int i = 0; i < chickens.Length; i++)
            {
                var chicken = (Chicken)chickens[i];
                chicken.Obtain();
                chicken.CutUp();
                chicken.Cook();
            }

            var eggs = table[typeof(Egg)];
            for (int i = 0; i < eggs.Length; i++)
            {
                var egg = (Egg)eggs[i];
                egg.Obtain();                
                try
                {

                    egg.Crack();
                }
                catch
                {

                }
                egg.Cook();
            }

            //TODO: Cook shouldn't know about customers. Only the server knows and create results for customers. Then the Process method return type can be void.
            string[] resultOfCooks = new string[table.customersCount];
            for (int i = 0; i < table.customersCount; i++)
            {
                var orders = table[i+1];

                var ch = 0;
                var e = 0;
                if (orders[0] is Chicken)
                {
                    var order = (Chicken)orders[0];
                    ch = order.GetQuantity();
                }

                if (orders[1] is Egg)
                {
                    var order = (Egg)orders[1];
                    e = order.GetQuantity();
                }

                resultOfCooks[i] = $"Customer {i} is served {ch} chicken, {e} egg, ";
                if (orders[2] is Drink)
                {
                    var drink = (Drink)orders[2];
                    resultOfCooks[i] += $"{drink.drink}";
                }
                else
                {
                    resultOfCooks[i] += "no drinks";
                }
            }
            return resultOfCooks;
        }
    }
}
