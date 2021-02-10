using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Moels
{
    public class Chicken : Food
    {
        public Chicken(int quantity) : base(quantity)
        {
        }

        public override void Cook()
        {
            base.Cook();
        }

        public void CutUp() { }
    }
}
