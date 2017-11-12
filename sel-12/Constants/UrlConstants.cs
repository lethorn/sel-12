namespace sel_12.Constants
{
    public static class UrlConstants
    {
        public static readonly string RootUrl = "http://localhost/litecart";

        public static readonly string AdminPageUrl = RootUrl + "/admin";

        public static readonly string CountriesPageUrl = AdminPageUrl + "/?app=countries&doc=countries";

        public static readonly string GeoZonesUrl = AdminPageUrl + "/?app=geo_zones&doc=geo_zones";

        public static readonly string CatalogsUrl = AdminPageUrl + "/?app=catalog&doc=catalog";
    }
}
