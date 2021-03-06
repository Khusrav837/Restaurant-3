﻿using Restaurant.Moels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class Cook
    {
        public void Process(TableRequests table)
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
                using (var egg = (Egg)eggs[i])
                {
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
            }            
        }
    }
}
