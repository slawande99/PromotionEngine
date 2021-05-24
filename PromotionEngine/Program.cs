using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Units Used : A, B, C, D ");
            Console.WriteLine("NOTE : Once user enter Unit Name as Empty <Space> and click enter then system will Stop the adding unit in Cart");
            List<Product> units = new List<Product>();

            while (true)
            {
                Console.WriteLine("Enter the Unit Name : ");
                string name = Console.ReadLine();

                if (string.IsNullOrEmpty(name.Trim())) break;

                Console.WriteLine("Enter the Number Of Unit: ");
                string numberofunits = Console.ReadLine();

                Product p = new Product { UnitName = name, NumberOfUnits = String.IsNullOrEmpty(numberofunits) ? 0 : Convert.ToInt32(numberofunits) };
                units.Add(p);
            }


            decimal totalPrice = ProductFactory.GetTotalPrice(units);

            Console.WriteLine(totalPrice);
            Console.ReadLine();
        }
    }
}
