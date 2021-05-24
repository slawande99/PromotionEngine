using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class ProductFactory
    {
        public static IProductItem GetPriceByUnit(Product product)
        {
            var name = product.UnitName.ToUpper();

            if (name == "A")
            {
                return new ProductItemA();
            }
            else if (name == "B")
            {
                return new ProductItemB();
            }
            else if (name == "C")
            {
                return new ProductItemC();
            }
            else if (name == "D")
            {
                return new ProductItemD();
            }
            else if (name == "CD")
            {
                return new ProductItemCAndD();
            }
            else
            {
                return null;
            }
        }

        public static decimal GetTotalPrice(List<Product> units)
        {
            if (units.Any(x => x.UnitName.ToUpper() == "C" && x.NumberOfUnits == 1) && units.Any(x => x.UnitName.ToUpper() == "D" && x.NumberOfUnits == 1))
            {
                units.Remove(units.First(x => x.UnitName.ToUpper() == "C" && x.NumberOfUnits == 1));
                units.Remove(units.First(x => x.UnitName.ToUpper() == "D" && x.NumberOfUnits == 1));
                units.Add(new Product { UnitName = "CD", NumberOfUnits = 1 });
            }

            decimal totalPrice = 0;
            foreach (var item in units)
            {
                IProductItem productItem = GetPriceByUnit(item);
                totalPrice += productItem.CalculatePrice(item.NumberOfUnits);
            }

            return totalPrice;
        }
    }
}
