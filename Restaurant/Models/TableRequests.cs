
using System;

namespace Restaurant.Models
{
    public class TableRequests
    {
        private IMenuItem[][] items = new IMenuItem[8][]; //TODO: This array's type should be IMenuItem
        int j = 0;

        //TODO: 1st parameter should be customer number (int). 2nd parameter should be order (IMenuItem)
        public void Add(int customerIndex, IMenuItem order)
        {
            if (j == 0)
            {
                items[customerIndex] = new IMenuItem[3];
            }
            items[customerIndex][j] = order;
            j++;
            if (j == 3)
            {
                j = 0;
            }
        }

        //TODO: These 2 indexer's return type should be IMenuItem[]
        public IMenuItem[] this [int i]
        {
            get 
            {
                return this.items[i - 1];
            }
        }

        public IMenuItem[] this[Type t]
        {
            get 
            {                
                IMenuItem[] collected = new IMenuItem[8];
                var collectedType = 0;
                
                for(int i = 0; i < 8; i++)
                {
                    if (items[i] == null)
                    {
                        break;
                    }
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
                    IMenuItem[] orders = new IMenuItem[collectedType];
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