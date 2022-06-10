using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickEggGo2
{
    class Order
    {
        private int quantity;
        public Order(int Quantity)
        {
            quantity = Quantity;
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public virtual void Cook()
        {

        }

        public static void SubstractQuantity(ref Order[][] orders)
        {
            orders = new Order[0][];
        }

    }
}
