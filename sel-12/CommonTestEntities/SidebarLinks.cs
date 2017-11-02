using System;
using System.Collections.Generic;

namespace sel_12.CommonTestEntities
{
    public static class SidebarLinks
    {
        // NOTE: Некоторые элементы закомментированы, т.к. по постановке мы проверяем наличие заголовка, а не его текст.
        // Проверка текста затруднительна по причине несоответствия названий ссылок содержанию заголовков.

        public static List<string> AppearenceLinks = new List<string>
        {
            //"Template",
            "Logotype"
        };

        public static List<string> CatalogLinks = new List<string>
        {
            //"Catalog",
            "Product Groups",
            "Option Groups",
            "Manufacturers",
            "Suppliers",
            "Delivery Statuses",
            "Sold Out Statuses",
            "Quantity Units",
            "CSV Import/Export"
        };

        public static List<string> CustomersLinks = new List<string>
        {
            //"Customers",
            "CSV Import/Export",
            "Newsletter"
        };
        
        public static List<string> LanguagesLinks = new List<string>
        {
            //"Languages",
            "Storage Encoding"
        };

        public static List<string> ModulesLinks = new List<string>
        {
            //"Background Jobs",
            "Customer",
            "Shipping",
            "Payment",
            "Order Total",
            "Order Success",
            "Order Action"
        };

        public static List<string> OrdersLinks = new List<string>
        {
            //"Orders",
            "Order Statuses"
        };

        public static List<string> ReportsLinks = new List<string>
        {
            //"Monthly Sales",
            "Most Sold Products",
            "Most Shopping Customers"
        };

        public static List<string> SettingsLinks = new List<string>
        {
            //"Store Info",
            "Defaults",
            "General",
            "Listings",
            "Images",
            "Checkout",
            "Advanced",
            "Security"
        };

        public static List<string> TaxLinks = new List<string>
        {
            //"Tax Classes",
            "Tax Rates"
        };

        public static List<string> TranslationsLinks = new List<string>
        {
            //"Search Translations",
            "Scan Files",
            "CSV Import/Export"
        };

        public static List<string> VQmodsLinks = new List<string>
        {
            //"vQmods"
        };

        public static Tuple<string, List<string>> Appearence = new Tuple<string, List<string>>("Appearence", AppearenceLinks);
        public static Tuple<string, List<string>> Catalog = new Tuple<string, List<string>>("Catalog", CatalogLinks);
        public static Tuple<string, List<string>> Countries = new Tuple<string, List<string>>("Countries", new List<string>());
        public static Tuple<string, List<string>> Currencies = new Tuple<string, List<string>>("Currencies", new List<string>());
        public static Tuple<string, List<string>> Customers = new Tuple<string, List<string>>("Customers", CustomersLinks);
        public static Tuple<string, List<string>> GeoZones = new Tuple<string, List<string>>("Geo Zones", new List<string>());
        public static Tuple<string, List<string>> Languages = new Tuple<string, List<string>>("Languages", LanguagesLinks);
        public static Tuple<string, List<string>> Modules = new Tuple<string, List<string>>("Modules", ModulesLinks);
        public static Tuple<string, List<string>> Orders = new Tuple<string, List<string>>("Orders", OrdersLinks);
        public static Tuple<string, List<string>> Pages = new Tuple<string, List<string>>("Pages", new List<string>());
        public static Tuple<string, List<string>> Reports = new Tuple<string, List<string>>("Reports", ReportsLinks);
        public static Tuple<string, List<string>> Settings = new Tuple<string, List<string>>("Settings", SettingsLinks);
        public static Tuple<string, List<string>> Slides = new Tuple<string, List<string>>("Slides", new List<string>());
        public static Tuple<string, List<string>> Tax = new Tuple<string, List<string>>("Tax", TaxLinks);
        public static Tuple<string, List<string>> Translations = new Tuple<string, List<string>>("Translations", TranslationsLinks);
        public static Tuple<string, List<string>> Users = new Tuple<string, List<string>>("Users", new List<string>());
        public static Tuple<string, List<string>> VQmods= new Tuple<string, List<string>>("vQmods", VQmodsLinks);

        public static List<Tuple<string, List<string>>> AllLinks = new List<Tuple<string, List<string>>>
        {
            Appearence,
            Catalog,
            Countries,
            Currencies,
            Customers,
            GeoZones,
            Languages,
            Modules,
            Orders,
            Pages,
            Reports,
            Settings,
            Slides,
            Tax,
            Translations,
            Users,
            VQmods
        };
    }
}
