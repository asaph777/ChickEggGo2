using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickEggGo2
{

    class Server
    {
         enum MenuItems
    {
        Chicken,
        Egg,
        Tea,
        Cola,
        Water
    }
        public static int countRequests = 0;
        MenuItems[][] ors = new MenuItems[0][];
        Cook empCook = new Cook();
        string[] drinks = new string[0];
        Order[][] orders = new Order[0][];
        public void ReciveRequest(int quantityChicken, int quantityEgg, string drink)
        {
            Array.Resize(ref drinks, drinks.Length + 1);
            drinks[drinks.Length - 1] = drink;

            MenuItems[] ordersList = new MenuItems[0];
            
            for (int i = 0; i < quantityChicken; i++)
            {
                Array.Resize(ref ordersList, ordersList.Length + 1);
                ordersList[ordersList.Length - 1] = MenuItems.Chicken;
            }

            for (int i = 0; i < quantityEgg; i++)
            {
                Array.Resize(ref ordersList, ordersList.Length + 1);
                ordersList[ordersList.Length - 1] = MenuItems.Egg;
            }

            Array.Resize(ref ors, ors.Length + 1);
            int lenghtLast = ors.Length - 1;
            ors[lenghtLast] = new MenuItems[quantityChicken + quantityEgg];

            for (int i = 0; i <= ordersList.Length-1; i++)
            {
                ors[lenghtLast][i] = ordersList[i];
            }

            countRequests++;
        }
        public void Send()
        {
            for (int i = 0; i <= ors.Length - 1; i++)
            {
                int quantityChick = 0;
                int quantityEgg = 0;
                for (int j = 0; j < ors[i].Length; j++)
                {
                    if (ors[i][j].ToString() == "Chicken")
                    {
                        quantityChick++;
                    }
                    if (ors[i][j].ToString() == "Egg")
                    {
                        quantityEgg++;
                    }

                }
                empCook.Submit(quantityChick, quantityEgg );
            }
            empCook.Prepare(ref orders);
            
        }

        public string[] Serve()
        {
            string[] result = new string[0];

            for (int i = 0; i <= orders.Length-1; i++)
            {
                Array.Resize(ref result, result.Length + 1);
                result[i] += $"Customer {i} is served {orders[i][0].GetQuantity().ToString()} chicken," +
                    $" {orders[i][1].GetQuantity().ToString()} egg, " + drinks[i];
            }
            Order.SubstractQuantity(ref orders);
            ors = new MenuItems[0][];
            return result;
        }
    }
}
