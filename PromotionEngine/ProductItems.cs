using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public interface IProductItem
    {
        decimal BasePrice { get; }
        decimal CalculatePrice(int numberOfCount);
    }

    public class ProductItemA : IProductItem
    {
        public decimal BasePrice
        {
            get
            {
                return 50m;
            }
        }

        public string Name { get; set; }

        public decimal CalculatePrice(int numberOfCount)
        {
            return (numberOfCount / 3) * 130 + (numberOfCount % 3 * BasePrice);
        }
    }

    public class ProductItemB : IProductItem
    {
        public decimal BasePrice
        {
            get
            {
                return 30m;
            }
        }

        public string Name { get; set; }

        public decimal CalculatePrice(int numberOfCount)
        {
            return (numberOfCount / 2) * 45 + (numberOfCount % 2 * BasePrice); ;
        }
    }

    public class ProductItemC : IProductItem
    {
        public decimal BasePrice
        {
            get
            {
                return 20m;
            }
        }

        public string Name { get; set; }

        public decimal CalculatePrice(int numberOfCount)
        {
            return (numberOfCount * BasePrice);
        }
    }

    public class ProductItemD : IProductItem
    {
        public decimal BasePrice
        {
            get
            {
                return 15m;
            }
        }

        public string Name { get; set; }


        public decimal CalculatePrice(int numberOfCount)
        {
            return (numberOfCount * BasePrice);
        }
    }

    public class ProductItemCAndD : IProductItem
    {
        public decimal BasePrice
        {
            get
            {
                return 30m;
            }
        }

        public string Name { get; set; }


        public decimal CalculatePrice(int numberOfCount)
        {
            return (numberOfCount * BasePrice);
        }
    }
}
