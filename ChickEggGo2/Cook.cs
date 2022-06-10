using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickEggGo2
{
    class Cook
    {
        Order[][] ordersSubmit  = new Order[0][];
        public void Prepare(ref Order[][] orders)
        {
            for (int i = 0; i < ordersSubmit.Length; i++)
            {
                ChickenOrder ch = new ChickenOrder(ordersSubmit[i][0].GetQuantity());
                for (int c = 0; c < ch.GetQuantity(); c++)
                {
                    ch.CutUp();
                    ch.Cook();
                }
            }
            for (int i = 0; i < ordersSubmit.Length; i++)
            {
                EggOrder egg = new EggOrder(ordersSubmit[i][1].GetQuantity());
                for (int e = 0; e < egg.GetQuantity(); e++)
                {
                    egg.Crack();
                    egg.Discard();
                    egg.Cook();
                }
            }
            orders = ordersSubmit;
            ordersSubmit = new Order[0][];
        }
        public void Submit(int quantityChicken, int quantityEgg)
        {
            ChickenOrder ch = new ChickenOrder(quantityChicken);
            EggOrder egg = new EggOrder(quantityEgg);
            Array.Resize(ref ordersSubmit, ordersSubmit.Length + 1);
            int lenghtLast = ordersSubmit.Length - 1;
            ordersSubmit[lenghtLast] = new Order[2];
            ordersSubmit[lenghtLast][0] = ch;
            ordersSubmit[lenghtLast][1] = egg;
        }
    }
}
