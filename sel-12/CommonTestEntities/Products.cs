using System.Collections.Generic;
using sel_12.Models;

namespace sel_12.CommonTestEntities
{
    public static class Products
    {
        public static readonly Product BlueDuck = new Product
        {
            ProductName = "Blue Duck",
            Manufacturer = "ACME Corp.",
            Price = 20M,
            Stickers = new List<string>
            {
                "NEW"
            }
        };

        public static readonly Product PurpleDuck = new Product
        {
            ProductName = "Purple Duck",
            Manufacturer = "ACME Corp.",
            Price = 0M,
            Stickers = new List<string>
            {
                "NEW"
            }
        };

        public static readonly Product GreenDuck = new Product
        {
            ProductName = "Green Duck",
            Manufacturer = "ACME Corp.",
            Price = 20M,
            Stickers = new List<string>
            {
                "NEW"
            }
        };

        public static readonly Product RedDuck = new Product
        {
            ProductName = "Red Duck",
            Manufacturer = "ACME Corp.",
            Price = 20M,
            Stickers = new List<string>
            {
                "NEW"
            }
        };

        public static readonly Product YellowDuck = new Product
        {
            ProductName = "Yellow Duck",
            Manufacturer = "ACME Corp.",
            Price = 18M,
            Stickers = new List<string>
            {
                "SALE"
            }
        };

        public static readonly List<Product> AllProducts = new List<Product>
        {
            BlueDuck,
            PurpleDuck,
            GreenDuck,
            RedDuck,
            YellowDuck
        };
    }
}
