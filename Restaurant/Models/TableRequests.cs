
using System;

namespace Restaurant.Models
{
    public class TableRequests
    {
        private int customerIndex = 0;
        private object[][] items = new object[8][]; //TODO: This array's type should be IMenuItem
        int j = 0;

        //TODO: We don't need with customersCount
        public int customersCount
        {
            get { return customerIndex; }
        }

        //TODO: 1st parameter should be customer number (int). 2nd parameter should be order (IMenuItem)
        public void Add(object order)
        {
            if (customerIndex == 8)
            {
                throw new Exception("All customers gave order!");
            }
            if (j == 0)
            {
                items[customerIndex] = new object[3];
            }
            items[customerIndex][j] = order;
            j++;
            if (j == 3)
            {
                j = 0;
                customerIndex++;
            }
        }

        //TODO: These 2 indexer's return type should be IMenuItem[]
        public object[] this [int i]
        {
            get 
            {
                if (i < 1 || i > customerIndex)
                {
                    throw new Exception("Error customer index!");
                }
                return this.items[i - 1];
            }
        }

        public object[] this[Type t]
        {
            get 
            {                
                object[] collected = new object[customerIndex];
                var collectedType = 0;
                
                for(int i = 0; i < customerIndex; i++)
                {
                    for(int j = 0; j < items[i].Length; j++)
                    {
                        if (items[i][j] != null && items[i][j].GetType() == t)
                        {
                            collected[collectedType] = items[i][j];
                            collectedType++;
                        }
                    }
                }

                if (collectedType == collected.Length)
                {
                    return collected;
                }
                else
                {
                    object[] orders = new object[collectedType];
                    for (int i = 0; i < collectedType; i++)
                    {
                        orders[i] = collected[i];
                    }
                    return orders;
                }
            }
        }
    }
}