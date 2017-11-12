using System.Collections.Generic;
using sel_12.Constants;
using sel_12.Models;

namespace sel_12.CommonTestEntities
{
    public static class Products
    {
        public static readonly Product BlueDuck = new Product
        {
            ProductName = "Blue Duck",
            Manufacturer = "ACME Corp.",
            ActualPrice = 20M,
            Stickers = new List<string>
            {
                "NEW"
            }
        };

        public static readonly Product PurpleDuck = new Product
        {
            ProductName = "Purple Duck",
            Manufacturer = "ACME Corp.",
            ActualPrice = 0M,
            Stickers = new List<string>
            {
                "NEW"
            }
        };

        public static readonly Product GreenDuck = new Product
        {
            ProductName = "Green Duck",
            Manufacturer = "ACME Corp.",
            ActualPrice = 20M,
            Stickers = new List<string>
            {
                "NEW"
            }
        };

        public static readonly Product RedDuck = new Product
        {
            ProductName = "Red Duck",
            Manufacturer = "ACME Corp.",
            ActualPrice = 20M,
            Stickers = new List<string>
            {
                "NEW"
            }
        };

        public static readonly Product YellowDuck = new Product
        {
            ProductName = "Yellow Duck",
            Manufacturer = "ACME Corp.",
            ActualPrice = 18M,
            OldPrice = 20M,
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

        public static readonly Product ProductToAdd = new Product
        {
            Code = "666",
            ProductName = "Real Duck",
            ImagePath = FileConstants.DataDirectoryPath + "\\duck.jpg",
            Manufacturer = "ACME Corp.",
            ShortDescription = "Test product",
            Description = "Test product for addition",
            HeadTitle = "Real Duck",
            MetaDescription = "Real Duck",
            ActualPrice = 100500M,
            CurrencyCode = "US Dollars"
        };
    }
}
